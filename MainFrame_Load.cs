#define LOGTEST1
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using System;

namespace Audit
{
    public partial class MainFrame : Form
    {
        public void InitDtLogs(object usefile)
        {
            DataTable dt = null;
            if ((bool)usefile)
            {
                this.RefreshStatus("正在初始化事件表（通过文件）……");
            }
            else
            {
                this.RefreshStatus("正在初始化事件表（通过连接数据库）……");
                SqlGenerator sg = new SqlGenerator();
#if LOGTEST
            DataTable dt = this.orahlper.GetDataTable(sg.GenExtractionSql(1, "HB", 2014, 1, 1, false));
#else
                dt = this.orahlper.GetDataTable(sg.GenExtractionSql(0, "HB", 2014, 1, 1, false)).Clone();
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
            }
                this.Invoke(new Param1Callback((_dt) =>
                {
                    if ((bool)usefile == false)
                    {
                        lock (locker_dt_logs)
                        {
                            this.dt_logs = (DataTable)_dt;
                            this.dt_logs.TableName = "dt_logs";
                        }
                        lock (locker_dtset)
                        {
                            this.dtset.Tables.Add(dt_logs);
                        }
                    }
                    this.dataGridView_Logs.DataSource = this.dt_logs;
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

        public void ReloadDtUnits(object usefile)
        {
            if ((bool)usefile)
            {
                this.RefreshStatus("正在加载省局列表（通过文件）……");
            }
            else
            {
                this.RefreshStatus("正在加载省局列表（通过连接数据库）……");
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
                this.Invoke(new Param1Callback((_dt) =>
                {
                    this.dt_units = (DataTable)_dt;
                    dt_units.TableName = "dt_units";
                    lock (locker_dtset)
                    {
                        this.dtset.Tables.Add(dt_units);
                    }
                }), new object[] { dt });
            }
            this.RefreshStatus("加载省局列表完成");
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            if (File.Exists("dtset.info"))
            {
                RefreshStatus("正在读取dtset.info……");
                dtset.ReadXml("dtset.info", XmlReadMode.ReadSchema);
                dt_units = dtset.Tables["dt_units"];
                dt_logs = dtset.Tables["dt_logs"];
                RefreshStatus("读取完成");
                new Thread(new ParameterizedThreadStart(ReloadDtUnits)).Start(true);
                new Thread(new ParameterizedThreadStart(InitDtLogs)).Start(true);
            }
            else
            {
                if (MessageBox.Show("是否通过连接数据库加载表信息？", "未能找到dtset.info", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new Thread(new ParameterizedThreadStart(ReloadDtUnits)).Start(false);
                    new Thread(new ParameterizedThreadStart(InitDtLogs)).Start(false);
                }
            }
        }
    }
}