using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Audit
{
    public class CheckResultHelper
    {
        public int[] graph = new int[2], log = new int[2], time = new int[2], group = new int[2], concern = new int[2], overanaly = new int[2], wholeresult = new int[2];
        public string[] reason = new string[2], suggestion = new string[2], result = new string[2], wholestr = new string[2];
        public DateTime[] checkdate = new DateTime[2];

        public void Fill(DataTable _check, string log_id)
        {
            wholestr[0] = "区域" + _getwholestr(_check, log_id, 0);
            wholestr[1] = "学科" + _getwholestr(_check, log_id, 1);
        }

        private string _getwholestr(DataTable _check, string log_id, int type)
        {
            string s;
            DataView dv = new DataView(_check);
            dv.Sort = "CHECK_DATE desc";
            if(type == 0)
                dv.RowFilter = "LOG_ID = '" + log_id + "' and USER_TYPE = 'SH'";
            else if(type == 1)
                dv.RowFilter = "LOG_ID = '" + log_id + "' and (USER_TYPE = 'XB' or USER_TYPE = 'ZL' or USER_TYPE = 'DC' or USER_TYPE = 'DD' or USER_TYPE = 'LT')";
            if (dv.Count == 0)
            {
                s = "审核：未审核";
                wholeresult[type] = -1;
            }
            else
            {
                DataRow r = dv.ToTable().Rows[0];
                graph[type] = Convert.ToInt32(r["IS_AGREE"] is DBNull ? 0 : r["IS_AGREE"]);
                log[type] = Convert.ToInt32(r["FLAG_2"] is DBNull ? 0 : r["FLAG_2"]);
                time[type] = Convert.ToInt32(r["FLAG_3"] is DBNull ? 0 : r["FLAG_3"]);
                concern[type] = Convert.ToInt32(r["FLAG_4"] is DBNull ? 0 : r["FLAG_4"]);
                group[type] = Convert.ToInt32(r["FLAG_5"] is DBNull ? 0 : r["FLAG_5"]);
                overanaly[type] = Convert.ToInt32(r["FLAG_6"] is DBNull ? 0 : r["FLAG_6"]);
                reason[type] = Convert.ToString(r["REASON"]);
                suggestion[type] = Convert.ToString(r["SUGGESTION"]);
                result[type] = Convert.ToString(r["RESULT"]);
                checkdate[type] = Convert.ToDateTime(r["CHECK_DATE"] is DBNull ? "1970/1/1" : r["CHECK_DATE"]);
                int re = graph[type] + log[type] + time[type] * 2 + group[type] * 2;
                wholeresult[type] = re > 2 ? 2 : re;
                string[] re3 = { "好", "中", "差" };
                string[] re2 = { "对", "错" };
                s = string.Format(@"审核（{0}）：审核时间（{1}）、事件归类（{4}）、事件时间（{5}）、事件分析（{3}）、图件标注（{2}）", re3[wholeresult[type]], checkdate[type].ToString("MM/dd HH:mm"), re3[graph[type]], re3[log[type]], re2[group[type]], re2[time[type]]);
                if(!(r["REASON"] is DBNull))
                {
                    s += " 说明理由：" + reason[type];
                }
                if(!(r["SUGGESTION"] is DBNull))
                {
                    s += " 处置建议：" + suggestion[type];
                }
                if(!(r["RESULT"] is DBNull))
                {
                    s += " 处置结果：" + result[type];
                }
            }
            return s;
        }
    }
}
