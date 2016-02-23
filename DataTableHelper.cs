using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Audit
{
    class DataTableHelper
    {
            public object[,] Folio2DTable_HasColName(object[,] t)
            {
                int rowcount = t.GetLength(0) - 1, colcount = t.GetLength(1);
                int newrowcount = (rowcount + 1) / 2, newcolcount = colcount * 2;
                object[,] newtable = new object[newrowcount + 1, newcolcount];
                for (int j = 0; j < colcount; j++)
                {
                    newtable[0, j] = newtable[0, colcount + j] = t[0, j];
                }
                for (int i = 0; i < newrowcount; i++)
                {
                    for (int j = 0; j < colcount; j++)
                    {
                        newtable[1 + i, j] = t[1 + i, j];
                        if (!(i == newrowcount - 1 && rowcount % 2 == 1))
                        {
                            newtable[1 + i, colcount + j] = t[1 + i + newrowcount, j];
                        }
                    }
                }
                return newtable;
            }
            public object[,] DataTableTo2DTable(DataTable dt)
            {
                object[,] t = new object[dt.Rows.Count + 1, dt.Columns.Count];
                for (int j = 0; j < t.GetLength(1); j++)
                    t[0, j] = dt.Columns[j].ToString();
                for (int i = 0; i < t.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < t.GetLength(1); j++)
                    {
                        t[i + 1, j] = dt.Rows[i][j];
                    }
                }
                return t;
            }
            public object[] ExtractRowByLeftFirstCol_WithoutKey(DataTable dt, string key)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == key)
                    {
                        object[] r = new object[dt.Columns.Count - 1];
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            r[j - 1] = dt.Rows[i][j];
                        }
                        return r;
                    }
                }
                return null;
            }
            public object ExtractRowByLeftFirstCol_SingleValue(DataTable dt, string key)
            {
                object[] r = ExtractRowByLeftFirstCol_WithoutKey(dt, key);
                if (r == null)
                    return null;
                return r[0];
            }
            public int? ExtractRowByLeftFirstCol_Int(DataTable dt, string key)
            {
                object r = ExtractRowByLeftFirstCol_SingleValue(dt, key);
                if (r == null)
                    return null;
                return Convert.ToInt32(r);
            }
            public decimal? ExtractRowByLeftFirstCol_Decimal(DataTable dt, string key)
            {
                object r = ExtractRowByLeftFirstCol_SingleValue(dt, key);
                if (r == null)
                    return null;
                return Convert.ToDecimal(r);
            }
    }
}
