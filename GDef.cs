using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audit
{
    public class GDef
    {
        public static string[] unitcodelist = { "AH", "BJ", "CQ", "DPC", "FJ", "GD", "GS", "GX", "HA", "HB", "HE", "HI", "HL", "HN", "ICD", "IES", "IGL", "IGP", "JL", "JS", "JX", "LN", "NM", "NX", "QH", "SC", "SD", "SH", "SN", "SX", "TJ", "XJ", "XZ", "YN", "ZJ" };
        public static string[] abbrunitnamelist = { "安徽", "北京", "重庆", "震防中心", "福建", "广东", "甘肃", "广西", "河南", "湖北", "河北", "海南", "黑龙江", "湖南", "地壳所", "预测所", "地质所", "地球所", "吉林", "江苏", "江西", "辽宁", "内蒙古", "宁夏", "青海", "四川", "山东", "上海", "陕西", "山西", "天津", "新疆", "西藏", "云南", "浙江" };
        public static string[] unitnamelist = { "安徽省", "北京市", "重庆市", "震防中心", "福建省", "广东省", "甘肃省", "广西壮族自治区", "河南省", "湖北省", "河北省", "海南省", "黑龙江省", "湖南省", "地壳应力研究所", "地震预测研究所", "地质研究所", "地球物理研究所", "吉林省", "江苏省", "江西省", "辽宁省", "内蒙古自治区", "宁夏回族自治区", "青海省", "四川省", "山东省", "上海市", "陕西省", "山西省", "天津市", "新疆维吾尔自治区", "西藏自治区", "云南省", "浙江省" };
        public static string store_qztemp = "c:\\qztemp\\";
        public static string store_dtprefix = "_dtstore_";
        public static string date_tostring_format = "yyyyMMdd HHmmss";
        public static string[] sciencelist = { "形变", "重力", "地磁", "地电", "流体" };
        public static string[] abtypelist = { "观测系统", "自然环境", "场地环境", "人为干扰", "地球物理事件", "不明原因" };
        public static string[] abtypelist_event = { "观测系统事件", "自然环境事件", "场地环境事件", "人为干扰事件", "地球物理事件", "不明原因事件" };
        public static string std_datestr(DateTime end_no_earlier, DateTime begin_no_later, DateTime? begin_no_earlier = null, DateTime? end_no_later = null, string tablename = "a")
        {
            DateStrGenerator dg = new DateStrGenerator();
            return dg.GetDateStr(end_no_earlier, begin_no_later, begin_no_earlier, end_no_later, tablename);
        }

        public static string unitcode2unitname(string unitcode)
        {
            for (int i = 0; i < unitcodelist.Length; i++)
            {
                if (unitcodelist[i] == unitcode)
                    return unitnamelist[i];
            }
            return "";
        }

        public static string unitcode2abbrunitname(string unitcode)
        {
            for (int i = 0; i < unitcodelist.Length; i++)
            {
                if (unitcodelist[i] == unitcode)
                    return abbrunitnamelist[i];
            }
            return "";
        }

        
    }
}
