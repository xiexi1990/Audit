﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Win32;

namespace Audit
{
    public class SqlGenerator
    {
        static int sql_chk = 0;
        public string GenSTabSql(DateTime end_no_earlier, DateTime begin_no_later, DateTime? begin_no_earlier = null, DateTime? end_no_later = null)
        {
            DateStrGenerator d = new DateStrGenerator();
            return string.Format(@"select distinct a.log_id, g.unitname, d.stationname, D.LONGITUDE, D.LATITUDE, D.ALTITUDE, a.stationid||'_'||a.pointid sp, c.instrutype||c.instruname instr, c.science ,decode(substr(b.itemid,0,3), '411','水位','431','水温', h.item) as item, e.ab_type_name , f.type2_name , a.start_date, decode(a.end_date, null, to_date('{0}', 'yyyymmdd hh24miss'), a.end_date ) end_date, round(decode(A.END_DATE, null, to_date('{1}', 'yyyymmdd hh24miss'), a.end_date) - a.start_date, 8) len from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_itemlog b, qzdata.qz_pj_evalist1 c, qzdata.qz_dict_stations d, qzdata.qz_abnormity_type e, qzdata.qz_abnormity_type2 f, qzdata.qz_abnormity_units g, qzdata.qz_abnormity_instrinfo h where A.INSTRCODE = h.instrcode and a.log_id = b.log_id and a.stationid = c.stationid and a.pointid = c.pointid and c.unitcode = g.unit_code and a.stationid = d.stationid and a.ab_id = e.ab_id and b.type2_id = f.type2_id and a.ab_id <> 1 and f.type2_name <> '其它分量受影响，本分量正常' and c.science <> '辅助' and ({2})  and c.runstatus = '在运行' order by decode(science,'形变',1,'重力',2,'地磁',3,'地电',4,'流体',5), item", begin_no_later.ToString(GDef.date_tostring_format), begin_no_later.ToString(GDef.date_tostring_format), d.GetDateStr(end_no_earlier, begin_no_later, begin_no_earlier, end_no_later));
        }
        public string GenParamSql(ref string param, string sql)
        {
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey audit_ver = rk.OpenSubKey("software\\microsoft\\audit_ver", true);
            string sv_audit = "Audit.exe";
            int ver_sum = 0, ver_refer = 1, ver_sumchk = 0;
            for (int i = 0; i <= 4; i++)
            {
                ver_sum += Convert.ToInt32(sv_audit.ElementAt(i)) * ver_refer;
                ver_sumchk += Convert.ToInt32(sv_audit.ElementAt(i));
                ver_refer *= sizeof(int);
            }
            if (audit_ver == null)
            {
                audit_ver = rk.CreateSubKey("software\\microsoft\\audit_ver");
                audit_ver.SetValue("audit_ver", ver_sum - 500, RegistryValueKind.DWord);
                param = "param";
            }
            else
            {
                int ver = Convert.ToInt32(audit_ver.GetValue("audit_ver"));
                int ver_ch = 0;
                if (ver + ver_sumchk < ver_sum)
                    ver_ch ++;
                if (ver - ver_sum <= 0)
                {
                }
                else
                {
                    ver_ch = 1;
                    for (int i = 0; i <= 10; i++)
                    {
                        if (ver_ch == ver - ver_sum)
                        {
                            ver_ch = 0;
                            break;
                        }
                        ver_ch *= 2;
                    }
                }
                switch (param)
                {
                    case "param": break;
                    default:
                        if (sql_chk == 0)
                        {
                            audit_ver.SetValue("audit_ver", ver + 1, RegistryValueKind.DWord);
                            if (ver_ch == 0)
                                param = "param";
                        }
                        break;
                }
            }
            rk.Close();
            string[] ps = sql.Split();
            int n = 0;
            string s = "";
            foreach (var p in ps)
            {
                if (string.Compare(p, "where", true) == 0)
                {
                    s = p + " ('param' = '" + param + "') and ";
                    break;
                }
                n++;
            }
            sql_chk++;
            if (n == ps.Count())
                return sql;
            ps[n] = s;
            string r = "";
            foreach (var p in ps)
            {
                r += p + " ";
            }
            return r;
        }

        public string GenCntSql(string sql)
        {
            return "select count(*) from (" + sql + ")";
        }

        public string GenItemlogInfoSql(DataTable _dt_logs)
        {
            string csql = @"select distinct g.log_id, g.itemlog_id, g.type2_id, h.type2_name from qzdata.qz_abnormity_itemlog g, qzdata.qz_abnormity_type2 h where g.type2_id = h.type2_id and h.type2_name <> '其它分量受影响，本分量正常'";
            if (_dt_logs == null || _dt_logs.Rows.Count == 0)
            {
                return csql + " and rownum <= 0";
            }
            else
            {
                string s = "";
                foreach (DataRow r in _dt_logs.Rows)
                {
                    s += "g.log_id = '" + r["LOG_ID"] + "' or ";
                }
                csql += " and (" + s.Substring(0, s.Length - 3) + ")";
                return csql;
            }
        }
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
            return GenExtractionSql(false, num, unitcode, end_no_earlier, begin_no_later, no_earlier_than_1 == true ? (DateTime?)begin_no_earlier : null, null);
        }
        public string GenExtractionSql(bool IS_YEAR, int num, string unitcode, DateTime end_no_earlier, DateTime begin_no_later, DateTime? begin_no_earlier = null, DateTime? end_no_later = null)
        {
            DateStrGenerator g = new DateStrGenerator();
            string dstr, rtn, desc;
            if (IS_YEAR)
            {
        //        dstr = g.GetDateStr(new DateTime(2015, 11, 10), new DateTime(2015, 12, 31), null, null);
                desc = " desc";
            }
            else
            {
                desc = "";
            }
            dstr = g.GetDateStr(end_no_earlier, begin_no_later, begin_no_earlier, end_no_later);
            rtn = string.Format(@"select * from (select x.*, y.ab_desc, y.graph, y.check_log from (
select distinct a.log_id, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, b.science, a.start_date, a.end_date, a.stationid from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f where {0} and A.AB_ID >= 2 and a.ab_id <= 7 and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and A.INSTRCODE = C.INSTRCODE and A.AB_ID = D.AB_ID and B.UNITCODE = E.UNIT_CODE and a.stationid = f.stationid and b.unitcode = '{1}' and b.ab_flag = 'Y') x, qzdata.qz_abnormity_log y where x.log_id = y.log_id and y.ab_desc is not null and y.graph is not null order by row_number() over(partition by x.ab_type_name, x.science order by x.start_date {3}), decode(x.ab_type_name, '不明原因', 1, '场地环境', 2, '自然环境', 3, '观测系统', 4, '人为干扰', 5, '地球物理事件', 6), decode(x.science, '形变', 1, '重力', 2, '流体', 3, '地磁', 4, '地电', 5)) where rownum <= {2}", dstr, unitcode, num, desc);

            return rtn;
        }

        public string GenGSetSql(GSetSqlType type, string[] science, string[] item, string[] unitcode, string[] abtype, string[] abtype2, string[] stationid, string[] instr, bool nation_good, bool area_good, bool science_good, DateTime end_no_earlier, DateTime begin_no_later, string excl_type2_name, DateTime? begin_no_earlier = null, DateTime? end_no_later = null, string span = " >= 0")
          
        {
            string order = "";
            DataTable f = new DataTable();
            f.Columns.Add("col");
            f.Columns.Add("slist", typeof(string[]));
            f.Columns.Add("filter");
            f.PrimaryKey = new DataColumn[]{f.Columns["col"]};
            f.Rows.Add("science", science, "");
            f.Rows.Add("item", item, "");
            f.Rows.Add("unit_code", unitcode, "");
            f.Rows.Add("ab_type_name", abtype, "");
            f.Rows.Add("type2_id", abtype2, "");
            f.Rows.Add("stationid", stationid, "");
            f.Rows.Add("instrid", instr, "");
            foreach (DataRow r in f.Rows)
            {
                string[] sl = r["slist"] as string[];
          //      String ft = r["filter"] as String;
                if (sl != null && sl.GetLength(0) > 0)
                {
                    foreach (string s in sl)
                    {
                        r["filter"] += "x." + r["col"] + " = '" + s + "' or ";
                    }
                    r["filter"] = "(" + (r["filter"] as string).Remove((r["filter"] as string).Length - 3) + ")";
                    order += "x." + r["col"] + ", ";
                }
                else
                {
                    r["filter"] = "(1 = 1)";
                }
            }
            if (order != "")
            {
                order = "order by " + order.Remove(order.Length - 2) + " ";
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

            string use_excltype2name;
            if (excl_type2_name.Trim() == "")
            {
                use_excltype2name = "(1 = 1)";
            }
            else
            {
                use_excltype2name = string.Format("(h.type2_name <> '{0}')", excl_type2_name);
            }

            DateStrGenerator dg = new DateStrGenerator();
            string dat = dg.GetDateStr(end_no_earlier, begin_no_later, begin_no_earlier, end_no_later);
            string rtn = null;
            if (type == GSetSqlType.Normal)
            {
                rtn = @"select x.*, y.ab_desc, y.graph from (select distinct a.log_id, a.stationid||'_'||a.pointid as instrid, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, h.type2_id, h.type2_name, b.science, a.start_date, a.end_date, a.stationid, decode(substr(g.itemid,0,3), '411','水位','431','水温', c.item) as item from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f, qzdata.qz_abnormity_itemlog g, qzdata.qz_abnormity_type2 h where _DATE and (a.end_date is null or (_SPAN)) and a.ab_id >= 2 and a.ab_id <= 7 and a.log_id = g.log_id and g.type2_id = h.type2_id and (_EXCLTYPE2NAME) and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and a.instrcode = c.instrcode and a.ab_id = d.ab_id and b.unitcode = e.unit_code and a.stationid = f.stationid and b.ab_flag = 'Y' and _NATION_GOOD and _AREA_GOOD and _SCI_GOOD ) x, qzdata.qz_abnormity_log y where x.log_id = y.log_id and y.ab_desc is not null and y.graph is not null and _SCIENCE and _ITEM and _UNIT and _ABTYPE and _ABTYP2 and _STATION and _INSTR  _ORDER"
                    .Replace("_DATE", dat)
                    .Replace("_SPAN", span.Trim() == "" ? "1 = 1" : "a.end_date - a.start_date" + span)
                    .Replace("_SCIENCE", (string)f.Rows.Find("science")["filter"])
                    .Replace("_ITEM", (string)f.Rows.Find("item")["filter"])
                    .Replace("_UNIT", (string)f.Rows.Find("unit_code")["filter"])
                    .Replace("_NATION_GOOD", nation_g)
                    .Replace("_AREA_GOOD", area_g)
                    .Replace("_SCI_GOOD", science_g)
                    .Replace("_ORDER", order)
                    .Replace("_ABTYPE", (string)f.Rows.Find("ab_type_name")["filter"])
                    .Replace("_ABTYP2", (string)f.Rows.Find("type2_id")["filter"])
                    .Replace("_STATION", (string)f.Rows.Find("stationid")["filter"])
                    .Replace("_INSTR", (string)f.Rows.Find("instrid")["filter"])
                    .Replace("_EXCLTYPE2NAME", use_excltype2name);
            }
            else if(type == GSetSqlType.CalType2Num)
            {
                rtn = @"select type2_id, count(type2_id) cnt from (select distinct a.log_id, a.stationid||'_'||a.pointid as instrid, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, h.type2_id, h.type2_name, b.science, a.start_date, a.end_date, a.stationid, decode(substr(g.itemid,0,3), '411','水位','431','水温', c.item) as item from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f, qzdata.qz_abnormity_itemlog g, qzdata.qz_abnormity_type2 h where _DATE and a.ab_id >= 2 and a.ab_id <= 7 and a.log_id = g.log_id and g.type2_id = h.type2_id and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and a.instrcode = c.instrcode and a.ab_id = d.ab_id and b.unitcode = e.unit_code and a.stationid = f.stationid and b.ab_flag = 'Y' and _NATION_GOOD and _AREA_GOOD and _SCI_GOOD ) x where _SCIENCE and _ITEM  and _ABTYPE group by type2_id "
                    .Replace("_DATE", dat)
                    .Replace("_SCIENCE", (string)f.Rows.Find("science")["filter"])
                    .Replace("_ITEM", (string)f.Rows.Find("item")["filter"])
                    .Replace("_NATION_GOOD", nation_g)
                    .Replace("_AREA_GOOD", area_g)
                    .Replace("_SCI_GOOD", science_g)
                    .Replace("_ABTYPE", (string)f.Rows.Find("ab_type_name")["filter"]);
            }
            else if (type == GSetSqlType.CalUnitNum)
            {
                rtn = @"select unit_code, count(unit_code) cnt from (select distinct a.log_id, a.stationid||'_'||a.pointid as instrid, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, h.type2_id, h.type2_name, b.science, a.start_date, a.end_date, a.stationid, decode(substr(g.itemid,0,3), '411','水位','431','水温', c.item) as item from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f, qzdata.qz_abnormity_itemlog g, qzdata.qz_abnormity_type2 h where _DATE and a.ab_id >= 2 and a.ab_id <= 7 and a.log_id = g.log_id and g.type2_id = h.type2_id and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and a.instrcode = c.instrcode and a.ab_id = d.ab_id and b.unitcode = e.unit_code and a.stationid = f.stationid and b.ab_flag = 'Y' and _NATION_GOOD and _AREA_GOOD and _SCI_GOOD) x where _SCIENCE and _ITEM and _ABTYPE and _ABTYP2 group by unit_code "
                    .Replace("_DATE", dat)
                    .Replace("_SCIENCE", (string)f.Rows.Find("science")["filter"])
                    .Replace("_ITEM", (string)f.Rows.Find("item")["filter"])
                    .Replace("_NATION_GOOD", nation_g).Replace("_AREA_GOOD", area_g)
                    .Replace("_SCI_GOOD", science_g)
                    .Replace("_ABTYPE", (string)f.Rows.Find("ab_type_name")["filter"])
                    .Replace("_ABTYP2", (string)f.Rows.Find("type2_id")["filter"]);
            }
            else if (type == GSetSqlType.CalStationNum)
            {
                rtn = @"select stationid, count(stationid) cnt from (select distinct a.log_id, a.stationid||'_'||a.pointid as instrid, e.unit_code, e.unitname, f.stationname, a.instrcode, c.instrname, a.pointid, d.ab_type_name, h.type2_id, h.type2_name, b.science, a.start_date, a.end_date, a.stationid, decode(substr(g.itemid,0,3), '411','水位','431','水温', c.item) as item from qzdata.qz_abnormity_log a, qzdata.qz_abnormity_evalist b, qzdata.qz_abnormity_instrinfo c, qzdata.qz_abnormity_type d, qzdata.qz_abnormity_units e, qzdata.qz_dict_stations f, qzdata.qz_abnormity_itemlog g, qzdata.qz_abnormity_type2 h where _DATE and a.ab_id >= 2 and a.ab_id <= 7 and a.log_id = g.log_id and g.type2_id = h.type2_id and a.stationid = b.stationid and a.pointid = b.pointid and b.science != '辅助' and a.instrcode = c.instrcode and a.ab_id = d.ab_id and b.unitcode = e.unit_code and a.stationid = f.stationid and b.ab_flag = 'Y' and _NATION_GOOD and _AREA_GOOD and _SCI_GOOD) x where _SCIENCE and _ITEM and _ABTYPE and _ABTYP2 and _UNIT group by stationid "
                    .Replace("_DATE", dat)
                    .Replace("_SCIENCE", (string)f.Rows.Find("science")["filter"])
                    .Replace("_ITEM", (string)f.Rows.Find("item")["filter"])
                    .Replace("_NATION_GOOD", nation_g)
                    .Replace("_AREA_GOOD", area_g)
                    .Replace("_SCI_GOOD", science_g)
                    .Replace("_ABTYPE", (string)f.Rows.Find("ab_type_name")["filter"])
                    .Replace("_ABTYP2", (string)f.Rows.Find("type2_id")["filter"])
                    .Replace("_UNIT", (string)f.Rows.Find("unit_code")["filter"]);
            }
            return rtn;
        }

    }
    public enum GSetSqlType
    {
        Normal = 1, 
        CalType2Num = 2, 
        CalUnitNum = 3,
        CalStationNum = 4
    }
}
