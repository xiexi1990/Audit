using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Audit
{
    class ItemlogInfoHelper
    {
        public string wholestr;
        public void Fill(DataTable _itemloginfo, string log_id)
        {
            string s = "";
            DataView dv = new DataView(_itemloginfo);
            dv.RowFilter = "LOG_ID = '" + log_id + "'";
            foreach (DataRow r in dv.ToTable(true, "TYPE2_NAME").Rows)
            {
                s += r["TYPE2_NAME"] + " ";
            }
            wholestr = s;
        }
    }
}
