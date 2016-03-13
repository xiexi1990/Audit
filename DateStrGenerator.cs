using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    class DateStrGenerator
    {
        public string GetDateStr(DateTime end_no_earlier, DateTime begin_no_later, DateTime? begin_no_earlier = null, DateTime? end_no_later = null, string tablename = "a")
        {
            string dstr1 = string.Format("{0}.end_date >= to_date('{1}', 'yyyymmdd hh24miss')", tablename,  end_no_earlier.ToString("yyyyMMdd HHmmss"));
            if (end_no_later == null)
            {
                dstr1 += string.Format(" or {0}.end_date is null", tablename);
            }
            else
            {
                dstr1 += string.Format("and {0}.end_date <= to_date('", tablename) + ((DateTime)end_no_later).ToString("yyyyMMdd HHmmss") + "', 'yyyymmdd hh24miss')";
            }
            dstr1 = "(" + dstr1 + ")";
            string dstr2 = string.Format("{0}.start_date <= to_date('", tablename) + begin_no_later.ToString("yyyyMMdd HHmmss") + "', 'yyyymmdd hh24miss')";
            if (begin_no_earlier != null)
            {
                dstr2 += string.Format("and {0}.start_date >= to_date('", tablename) + ((DateTime)begin_no_earlier).ToString("yyyyMMdd HHmmss") + "', 'yyyymmdd hh24miss')";
            }
            dstr2 = "(" + dstr2 + ")";

            string dstr = "(" + dstr1 + " and " + dstr2 + ")";
            return dstr;
        }
    }
}
