﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Audit
{
    class SqlGenerator
    {
        public string GenCheckSql(DataTable _dt_logs)
        {
            string csql = @"select distinct l.log_id, m.user_type, l.check_date, l.suggestion, l.result, l.reason, l.is_agree, l.flag_2, l.flag_3, l.flag_4, l.flag_5, l.flag_6 from  qzdata.qz_abnormity_checkview l, qzdata.qz_abnormity_userview m where l.user_id = m.user_id ";
            if (_dt_logs == null || _dt_logs.Rows.Count == 0)
            {
                return csql + " and rownum <= 0";
            }
            else
            {
                string s = "";
                foreach (DataRow r in _dt_logs.Rows)
                {
                    s += "l.log_id = '" + r["LOG_ID"] + "' or ";
                }
                csql += " and (" + s.Substring(0, s.Length - 3) + ")";
                return csql;
            }
        }
        public string GenExtractionSql(int num, string unitcode, int audit_year, int audit_month, int begin_day, bool no_earlier_than_1)
        {
            DateTime end_no_earlier = new DateTime(audit_year, audit_month, begin_day, 0, 0, 0);
            DateTime begin_no_earlier = new DateTime(audit_year, audit_month, 1, 0, 0, 0);
            DateTime begin_no_later = begin_no_earlier.AddMonths(1).AddSeconds(-1);
            return GenExtractionSql(num, unitcode, end_no_earlier, begin_no_later, no_earlier_than_1 == true ? (DateTime?)begin_no_earlier : null, null);
        }
        public string GenExtractionSql(int num, string unitcode, DateTime end_no_earlier, DateTime begin_no_later, DateTime? begin_no_earlier = null, DateTime? end_no_later = null)
        {
            string dstr1 = string.Format("a.end_date >= to_date('{0}', 'yyyymmdd hh24miss')", end_no_earlier.ToString("yyyyMMdd HHmmss"));
            if (end_no_later == null)
            {
                dstr1 += " or a.end_date is null";
            }
            else
            {
                dstr1 += "and a.end_date <= to_date('" + ((DateTime)end_no_later).ToString("yyyyMMdd HHmmss") + "', 'yyyymmdd hh24miss')";
            }
            dstr1 = "(" + dstr1 + ")";
            string dstr2 = "a.start_date <= to_date('" + begin_no_later.ToString("yyyyMMdd HHmmss") + "', 'yyyymmdd hh24miss')";
            if (begin_no_earlier != null)
            {
                dstr2 += "and a.start_date >= to_date('" + ((DateTime)begin_no_earlier).ToString("yyyyMMdd HHmmss") + "', 'yyyymmdd hh24miss')";
            }
            dstr2 = "(" + dstr2 + ")";

            string dstr = "(" + dstr1 + " and " + dstr2 + ")";
            string rtn = string.Format(@"select * from (select x.*, y.ab_desc, y.graph from (
select distinct a.log_id, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, b.science, a.start_date, a.end_date, a.stationid from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f where {0} and A.AB_ID >= 2 and a.ab_id <= 7 and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and A.INSTRCODE = C.INSTRCODE and A.AB_ID = D.AB_ID and B.UNITCODE = E.UNIT_CODE and a.stationid = f.stationid and b.unitcode = '{1}' and b.ab_flag = 'Y'
) x, qzdata.qz_abnormity_log y where x.log_id = y.log_id and y.ab_desc is not null and y.graph is not null order by row_number() over(partition by x.ab_type_name, x.science order by x.start_date), decode(x.ab_type_name, '不明原因', 1, '场地环境', 2, '自然环境', 3, '观测系统', 4, '人为干扰', 5, '地球物理事件', 6), decode(x.science, '形变', 1, '重力', 2, '流体', 3, '地磁', 4, '地电', 5)) where rownum <= {2}", dstr, unitcode, num);

            return rtn;
        }

    }
}
