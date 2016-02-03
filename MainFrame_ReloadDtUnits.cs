using System.Windows.Forms;
using System.Data;

namespace Audit
{
    public partial class MainFrame : Form
    {
        public void ReloadDtUnits()
        {
            this.RefreshStatus("正在加载省局列表……");
            DataTable dt = orahlper.GetDataTable("select unit_code, unitname from qzdata.qz_abnormity_units where unit_code != 'CEN'");
            dt.Columns.Add("NUM");
            foreach (DataRow r in dt.Rows)
            {
                r["NUM"] = 0;
                for (int i = 0; i < UNIT_NUM.GetLength(0); i++)
                {
                    if (r["unit_code"].ToString() == UNIT_NUM[i, 0].ToString())
                    {
                        r["NUM"] = UNIT_NUM[i, 1];
                        break;
                    }
                }
            }
            this.Invoke(new Param1Callback((_dt) => this.dt_units = (DataTable)_dt), new object[] { dt });
            this.RefreshStatus("加载省局列表完成");
        }
    }
}