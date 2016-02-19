#define LOGTEST1
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using System;
using System.Diagnostics;

namespace Audit
{
    public partial class MainFrame : Form
    {
        public void InitDtLogs(object usefile)
        {
            DataTable dt = null, dt2 = null;
            if ((bool)usefile)
            {
                this.RefreshStatus("正在初始化事件表（通过文件）……");
            }
            else
            {
                this.RefreshStatus("正在初始化事件表（通过连接数据库）……");
                SqlGenerator sg = new SqlGenerator();
                string esql;
#if LOGTEST
            DataTable dt = this.orahlper.GetDataTable(sg.GenExtractionSql(1, "HB", 2014, 1, 1, false));
#else
                esql = sg.GenExtractionSql(0, "HB", 2014, 1, 1, false);
                dt = orahlper.GetDataTable(esql).Clone();
                dt2 = orahlper.GetDataTable(sg.GenCheckSql(null)).Clone();
#endif
                DataColumn dc_rowid = new DataColumn("ROWID", typeof(int));
                dc_rowid.AutoIncrement = false;
                dc_rowid.AutoIncrementSeed = 1;
                dt.Columns.Add(dc_rowid);
  //              dt.Columns["ROWID"].SetOrdinal(0);
                dt.Columns.Add("AUDIT_TIME", typeof(DateTime));
                dt.Columns["AUDIT_TIME"].SetOrdinal(0);
                dt.Columns.Add("AUDIT_USER");
                dt.Columns.Add("POSTPONE", typeof(bool));
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
            this.Invoke(new Param0Callback(() =>
            {
                if ((bool)usefile == false)
                {
                    lock (locker_dt_logs)
                    {
                        this.dt_logs = dt;
                        this.dt_logs.TableName = "dt_logs";
                    }
                    this.dt_check = dt2;
                    this.dt_check.TableName = "dt_check";
                }
                dv_dt_logs = new DataView(dt_logs);
                this.dataGridView_Logs.DataSource = this.dv_dt_logs;
                foreach (DataGridViewColumn c in dataGridView_Logs.Columns)
                {
                    if (c.Name == "UNITNAME" || c.Name == "STATIONNAME" || c.Name == "INSTRCODE" || c.Name == "INSTRNAME" || c.Name == "AB_TYPE_NAME" || c.Name == "SCIENCE" || c.Name == "START_DATE" || c.Name == "END_DATE" || c.Name == "LOG_ID" || c.Name == "AUDIT_TIME")
                    {
                        c.Width = 50;
                        c.SortMode = DataGridViewColumnSortMode.Programmatic;
                        continue;
                    }
                    c.Visible = false;
                }
                dataGridView_Logs.Columns["ROWID"].HeaderText = "序号";
                dataGridView_Logs.Columns["AUDIT_TIME"].DefaultCellStyle.Format = "MM/dd HH:mm";
                dataGridView_Logs.Columns["AUDIT_TIME"].Width = 72;
                dataGridView_Logs.Columns["LOG_ID"].Width = 60;
                dataGridView_Logs.RowHeadersWidth = 24;
#if LOGTEST
                this.ShowLog(1);
#endif
                lock (locker_dt_logs)
                {
                    dt_logs.RowChanged += new DataRowChangeEventHandler(DT_RowChanged);
                }
                this.RefreshStatus("初始化事件表完成");
                this.button_Input.Enabled = true;
            }

            ));
                
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
                DataTable dt = orahlper.GetDataTable("select unit_code, unitname from qzdata.qz_abnormity_units where unit_code != 'CEN' order by unitname");
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
                this.Invoke(new Param0Callback(() =>
                {
                    this.dt_units = dt;
                    dt_units.TableName = "dt_units";
                }));
            }
            this.RefreshStatus("加载省局列表完成");
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            if (File.Exists("load.info"))
            {
                RefreshStatus("正在读取load.info……");
                DataSet ds = new DataSet();
                ds.ReadXml("load.info", XmlReadMode.ReadSchema);
                dt_units = ds.Tables["dt_units"];
                lock (locker_dt_logs)
                {
                    dt_logs = ds.Tables["dt_logs"];
                }
                dt_check = ds.Tables["dt_check"];
                RefreshStatus("读取完成");
                new Thread(new ParameterizedThreadStart(ReloadDtUnits)).Start(true);
                new Thread(new ParameterizedThreadStart(InitDtLogs)).Start(true);
            }
            else
            {
                if (MessageBox.Show("是否通过连接数据库加载表信息？", "未能找到load.info", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new Thread(new ParameterizedThreadStart(ReloadDtUnits)).Start(false);
                    new Thread(new ParameterizedThreadStart(InitDtLogs)).Start(false);
                }
            }
        }

        private void DT_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataTable dt = sender as DataTable;
            if (dt.TableName == "dt_logs" || dt.TableName == "dt_units_comments")
            {
                newsaved = false;
            }
            else
            {
                MessageBox.Show("unexpected datatable rowchanged event!");
            }
    //        Debug.WriteLine("rowchanged" + sta++);
        }
    }
}