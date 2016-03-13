using System;
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
            DateStrGenerator g = new DateStrGenerator();
            string dstr = g.GetDateStr(end_no_earlier, begin_no_later, begin_no_earlier, end_no_later);
            string rtn = string.Format(@"select * from (select x.*, y.ab_desc, y.graph from (
select distinct a.log_id, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, b.science, a.start_date, a.end_date, a.stationid from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f where {0} and A.AB_ID >= 2 and a.ab_id <= 7 and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and A.INSTRCODE = C.INSTRCODE and A.AB_ID = D.AB_ID and B.UNITCODE = E.UNIT_CODE and a.stationid = f.stationid and b.unitcode = '{1}' and b.ab_flag = 'Y'
) x, qzdata.qz_abnormity_log y where x.log_id = y.log_id and y.ab_desc is not null and y.graph is not null order by row_number() over(partition by x.ab_type_name, x.science order by x.start_date), decode(x.ab_type_name, '不明原因', 1, '场地环境', 2, '自然环境', 3, '观测系统', 4, '人为干扰', 5, '地球物理事件', 6), decode(x.science, '形变', 1, '重力', 2, '流体', 3, '地磁', 4, '地电', 5)) where rownum <= {2}", dstr, unitcode, num);

            return rtn;
        }

        public string GenGSetSql(string[] science, string[] bitem, string[] unitcode, bool nation_good, bool area_good, bool science_good, DateTime end_no_earlier, DateTime begin_no_later, DateTime? begin_no_earlier = null, DateTime? end_no_later = null)
        {
            string order = "";
            string sci;
            if (science != null && science.GetLength(0) > 0)
            {
                sci = "(";
                foreach (string s in science)
                {
                    sci += "b.science = '" + s + "' or ";
                }
                sci = sci.Remove(sci.Length - 3) + ")";
                order += "x.science,";
            }
            else
            {
                sci = "(1 = 1)";
            }

            string bi;
            if (bitem != null && bitem.GetLength(0) > 0)
            {
                bi = "(";
                foreach (string s in bitem)
                {
                    bi += "c.bitem = '" + s + "' or ";
                }
                bi = bi.Remove(bi.Length - 3) + ")";
                order += "x.bitem,";
            }
            else
            {
                bi = "(1 = 1)";
            }

            string uni;
            if (unitcode != null && unitcode.GetLength(0) > 0)
            {
                uni = "(";
                foreach (string s in unitcode)
                {
                    uni += "e.unit_code = '" + s + "' or ";
                }
                uni = uni.Remove(uni.Length - 3) + ")";
                order += "x.unit_code,";
            }
            else
            {
                uni = "(1 = 1)";
            }
            if (order != "")
            {
                order = "order by " + order.Remove(order.Length - 1) + " ";
            }

            string nation_g;
            if(nation_good)
            {
                nation_g = "(1 = 1)";
            }
            else
            {
                nation_g = "(1 = 1)";
            }
            string area_g;
            if(area_good)
            {
                area_g = "(a.log_id in (select aa.log_id from qzdata.qz_abnormity_checkview aa, qzdata.qz_abnormity_userview bb where aa.user_id = bb.user_id and bb.USER_TYPE = 'SH' and aa.is_agree = 0 and aa.flag_2 = 0 and aa.flag_3 = 0 and aa.flag_5 = 0))";
            }
            else
            {
                area_g = "(1 = 1)";
            }
            string science_g;
            if(science_good)
            {
                science_g = "(a.log_id in (select aa.log_id from qzdata.qz_abnormity_checkview aa, qzdata.qz_abnormity_userview bb where aa.user_id = bb.user_id and (bb.USER_TYPE = 'XB' or bb.USER_TYPE = 'ZL' or bb.USER_TYPE = 'DC' or bb.USER_TYPE = 'DD' or bb.USER_TYPE = 'LT') and aa.is_agree = 0 and aa.flag_2 = 0 and aa.flag_3 = 0 and aa.flag_5 = 0))";
            }
            else
            {
                science_g = "(1 = 1)";
            }

            DateStrGenerator dg = new DateStrGenerator();
            string dat = dg.GetDateStr(end_no_earlier, begin_no_later, begin_no_earlier, end_no_later);

            string rtn = @"select x.*, y.ab_desc, y.graph from (select distinct a.log_id, a.stationid||'x'||a.pointid as instrid, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, b.science, a.start_date, a.end_date, a.stationid, c.bitem from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f where _DATE and A.AB_ID >= 2 and a.ab_id <= 7 and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and A.INSTRCODE = C.INSTRCODE and A.AB_ID = D.AB_ID and B.UNITCODE = E.UNIT_CODE and a.stationid = f.stationid and b.ab_flag = 'Y'  and _SCIENCE and _BITEM and _UNIT and _NATION_GOOD and _AREA_GOOD and _SCI_GOOD ) x, qzdata.qz_abnormity_log y where x.log_id = y.log_id and y.ab_desc is not null and y.graph is not null _ORDER".Replace("_DATE", dat).Replace("_SCIENCE", sci).Replace("_BITEM", bi).Replace("_UNIT", uni).Replace("_NATION_GOOD", nation_g).Replace("_AREA_GOOD", area_g).Replace("_SCI_GOOD", science_g).Replace("_ORDER", order);

            return rtn;

        }

    }
}
