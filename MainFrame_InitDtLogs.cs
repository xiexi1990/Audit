#define LOGTEST1
using System.Windows.Forms;
using System.Data;

namespace Audit
{
    public partial class MainFrame : Form
    {
        public void InitDtLogs()
        {
            this.RefreshStatus("正在初始化事件表……");
            SqlGenerator sg = new SqlGenerator();
#if LOGTEST
            DataTable dt = this.orahlper.GetDataTable(sg.GenExtractionSql(1, "HB", 2014, 1, 1, false));
#else
            DataTable dt = this.orahlper.GetDataTable(sg.GenExtractionSql(0, "HB", 2014, 1, 1, false)).Clone();
#endif
            DataColumn dc_rowid = new DataColumn("ROWID", typeof(int));
            dc_rowid.AutoIncrement = false;
            dc_rowid.AutoIncrementSeed = 1;
            dt.Columns.Add(dc_rowid);
            dt.Columns["ROWID"].SetOrdinal(0);
#if LOGTEST
            dt.Rows[0]["ROWID"] = 1;
#endif
            dt.Columns.Add("SCORE_GROUP", typeof(int));
            dt.Columns.Add("SCORE_TIME", typeof(int));
            dt.Columns.Add("SCORE_LOG", typeof(int));
            dt.Columns.Add("SCORE_GRAPH", typeof(int));
            dt.Columns.Add("COMMENTS_GROUP", typeof(string));
            dt.Columns.Add("COMMENTS_TIME", typeof(string));
            dt.Columns.Add("COMMENTS_LOG", typeof(string));
            dt.Columns.Add("COMMENTS_GRAPH", typeof(string));
            this.Invoke(new Param1Callback((_dt) =>
            {
                lock (locker_dt_logs)
                {
                    this.dt_logs = (DataTable)_dt;
                    this.dataGridView_Logs.DataSource = this.dt_logs;
                }
                foreach (DataGridViewColumn c in dataGridView_Logs.Columns)
                {
                    if (c.Name == "ROWID" || c.Name == "UNITNAME" || c.Name == "STATIONNAME" || c.Name == "INSTRCODE" || c.Name == "INSTRNAME" || c.Name == "AB_TYPE_NAME" || c.Name == "SCIENCE" || c.Name == "START_DATE" || c.Name == "END_DATE")
                    {
                        c.Width = 50;
                        continue;
                    }
                    c.Visible = false;
                }
                dataGridView_Logs.Columns["ROWID"].HeaderText = "序号";
#if LOGTEST
                this.ShowLog(1);
#endif
            }
            ), new object[] { dt });
            this.RefreshStatus("初始化事件表完成");

            if (this.button_Input.InvokeRequired)
            {
                this.Invoke(new Param0Callback(() => { this.button_Input.Enabled = true; }));
            }
            else
                this.button_Input.Enabled = true;
        }
    }
}