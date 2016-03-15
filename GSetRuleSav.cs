using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Audit
{
    public class GSetRuleSav
    {
        public DateTime begin_time, end_time;
        public bool begin_time_trim, end_time_trim;
        public bool nation_good, area_good, science_good;
        public string sql, science, bitem, abtype, abtype2, unit, station;
        public string cal_abtype2, cal_unit, cal_station;
        public DataTable dt_science, dt_bitem, dt_abtype, dt_abtype2, dt_units, dt_stations;
   //     public DataView dv_bitem, dv_abtype2, dv_stations;
        public string dv_bitem_rf, dv_abtype2_rf, dv_stations_rf;
        public string dv_bitem_st, dv_abtype2_st, dv_stations_st;
        public int[] sl_science, sl_bitem, sl_abtype, sl_abtype2, sl_units, sl_stations;
    }
}
