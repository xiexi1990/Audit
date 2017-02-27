using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace Audit
{
    public class DataTableHelper
    {
        public int outcnt;
        public DataTable DTNewTitle(DataTable dt, string[] title)
        {
            for (int i = 0; i < title.GetLength(0); i++)
            {
                dt.Columns[i].ColumnName = title[i];
            }
            return dt;
        }

        public DataTable QueryToDT(IQueryable query)
        {
            DataTable dtList = new DataTable();
            foreach (var p in query.ElementType.GetProperties())
            {
                    dtList.Columns.Add(p.Name, p.PropertyType);
            }
            foreach (var item in query)
            {
                var row = dtList.NewRow();
                foreach (var p in item.GetType().GetProperties())
                {
                    row[p.Name] = p.GetValue(item, null);
                }
                dtList.Rows.Add(row);
            }
            return dtList;
        }

        public object[,] DupFold2DTable_HasColHeader(int dup, object[,] t)
        {
            int rowcount = t.GetLength(0) - 1, colcount = t.GetLength(1);
            int newrowcount = rowcount / dup + 1, newcolcount = colcount * dup;
            if (rowcount % dup != 0)
                newrowcount++;
            object[,] newtable = new object[newrowcount, newcolcount];
            for (int j = 0; j < colcount; j++)
            {
                for (int k = 0; k < dup; k++)
                    newtable[0, j + k * colcount] = t[0, j];
            }
            for (int i = 0; i < rowcount; i++)
            {
                for (int j = 0; j < colcount; j++)
                {
                    newtable[i % (newrowcount - 1) + 1, j + (i / (newrowcount - 1)) * colcount] = t[i + 1, j];
                }
            }
            return newtable;
        }
        public object[,] DataTableTo2DTable(DataTable dt)
        {
            object[,] t = new object[dt.Rows.Count + 1, dt.Columns.Count];
            for (int j = 0; j < t.GetLength(1); j++)
                t[0, j] = dt.Columns[j].ColumnName;
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

        public void DTToExcelSheet(DataTable dt, excel.Workbook book, string sheetname, excel.Worksheet _sheet = null)
        {
            outcnt++;
            excel.Worksheet sheet;
            if(_sheet != null)
            {
                sheet = _sheet;
            }
            else
            {
                sheet = book.Worksheets.Add();
                sheet.Name = sheetname;
            }
            object[,] t = DataTableTo2DTable(dt);
            sheet.Range["A1", sheet.Cells[t.GetLength(0), t.GetLength(1)]].Value = t;
            if (t.GetLength(0) > 1)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    if (dt.Columns[j].DataType == typeof(DateTime))
                    {
                        sheet.Range[sheet.Cells[2, j + 1], sheet.Cells[t.GetLength(0), j + 1]].NumberFormat = "yyyy/m/d h:mm";
                    }
                }
            }
        }

        public void DTToExcel(DataTable dt, string filename, bool show, bool overwrite)
        {
            outcnt++;
            if (overwrite)
            {
                if (File.Exists(filename))
                    File.Delete(filename);
            }
            
            excel.Application eapp = new excel.Application();
            excel.Workbook book = eapp.Workbooks.Add();
            excel.Worksheet sheet = book.Worksheets[1];
            DTToExcelSheet(dt, book, null, sheet);
            book.SaveAs(filename);
            if (show)
            {
                eapp.Visible = true;
            }
            else
            {
                book.Close();
                eapp.Quit();
            }
        }

        public DataTable Transpose(DataTable dt)
        {
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add(dt.Columns[0].ColumnName);
            foreach (DataRow r in dt.Rows)
            {
                dtNew.Columns.Add(r[0].ToString());
            }

            int j = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                if (j == 0)
                {
                    j++;
                    continue;
                }
                DataRow drNew = dtNew.NewRow();
                drNew[0] = dc.ColumnName;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drNew[i + 1] = dt.Rows[i][dc].ToString();
                }
                dtNew.Rows.Add(drNew);
                j++;
            }
            return dtNew;
        }
    }
}
