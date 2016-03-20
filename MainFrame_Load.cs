﻿#define LOGTEST1
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
                if (GSET)
                {
                    esql = sg.GenGSetSql(GSetSqlType.Normal, null, null, null, new string[]{"2"}, new string[]{"2"}, null, null, true, true, true, DateTime.Now, DateTime.Now);
                }
                else
                {
                    esql = sg.GenExtractionSql(0, "HB", 2014, 1, 1, false);
                }
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
                dt.Columns.Add("SCORE_GSET", typeof(int));
                dt.Columns["SCORE_GSET"].SetOrdinal(1);
                dt.Columns.Add("SCORE_GSETCLASS", typeof(int));
                dt.Columns.Add("COMMENTS_GSET", typeof(string));
                dt.Columns.Add("SET_ID", typeof(string));
                dt.Columns.Add("SET_NAME", typeof(string));
                dt.Columns.Add("SPAN", typeof(decimal));
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
                dv_dt_logs.AllowNew = false;
                this.dataGridView_Logs.DataSource = this.dv_dt_logs;
                foreach (DataGridViewColumn c in dataGridView_Logs.Columns)
                {
                    if (c.Name == "UNITNAME" || c.Name == "STATIONNAME" || c.Name == "INSTRCODE" || c.Name == "INSTRNAME" || c.Name == "AB_TYPE_NAME" || c.Name == "SCIENCE" || c.Name == "START_DATE" || c.Name == "END_DATE" || c.Name == "LOG_ID" || c.Name == "AUDIT_TIME" || c.Name == "INSTRID" || c.Name == "SCORE_GSET" || c.Name == "TYPE2_NAME")
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

        public void ReloadMinorDt(object param)
        {
            ReloadDtParam p = param as ReloadDtParam;
            string typename = " ";
            if (p.type == ReloadDtParamType.Unit)
            {
                typename = "省局列表";
            }
            else if (p.type == ReloadDtParamType.Item)
            {
                typename = "测项列表";
            }
            else if (p.type == ReloadDtParamType.AbType)
            {
                typename = "事件类型列表";
            }
            else if (p.type == ReloadDtParamType.AbType2)
            {
                typename = "影响因素列表";
            }
            else if (p.type == ReloadDtParamType.Station)
            {
                typename = "台站列表";
            }

            if (p.use_file)
            {
                this.RefreshStatus("正在加载" + typename + "（通过文件）……");
            }
            else
            {
                this.RefreshStatus("正在加载" + typename + "（通过连接数据库）……");
                DataTable dt = null;
                if (p.type == ReloadDtParamType.Unit)
                {
                    dt = orahlper.GetDataTable("select unit_code, unitname from qzdata.qz_abnormity_units where unit_code != 'CEN' order by unitname");
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
                }
                else if (p.type == ReloadDtParamType.Item)
                {
                    dt = orahlper.GetDataTable("select distinct item, science from qzdata.qz_abnormity_instrinfo where science != '辅助' order by science");
                }
                else if (p.type == ReloadDtParamType.AbType)
                {
                    dt = orahlper.GetDataTable("select * from qzdata.qz_abnormity_type where ab_id >= 2 and ab_id <= 7");
                }
                else if (p.type == ReloadDtParamType.AbType2)
                {
                    dt = orahlper.GetDataTable("select ab_id, type2_id, science, type2_name from qzdata.qz_abnormity_type2 where ab_id >= 2 and ab_id <= 7 ");
                }
                else if (p.type == ReloadDtParamType.Station)
                {
                    dt = orahlper.GetDataTable("select stationid, stationname, unitcode from qzdata.qz_dict_stations");
                }

                this.Invoke(new Param0Callback(() =>
                {
                    if (p.type == ReloadDtParamType.Unit)
                    {
                        this.dt_units = dt;
                        dt_units.TableName = "dt_units";
                    }
                    else if (p.type == ReloadDtParamType.Item)
                    {
                        this.dt_item = dt;
                        dt_item.TableName = "dt_item";
                    }
                    else if(p.type == ReloadDtParamType.AbType)
                    {
                        dt_abtype = dt;
                        dt_abtype.TableName = "dt_abtype";
                    }
                    else if (p.type == ReloadDtParamType.AbType2)
                    {
                        dt_abtype2 = dt;
                        dt_abtype2.TableName = "dt_abtype2";
                    }
                    else if (p.type == ReloadDtParamType.Station)
                    {
                        dt_stations = dt;
                        dt_stations.TableName = "dt_stations";
                    }

                }));
            }
            this.RefreshStatus("加载" + typename + "完成");
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            if (File.Exists("load.info"))
            {
                RefreshStatus("正在读取load.info……");
                DataSet ds = new DataSet();
                ds.ReadXml("load.info", XmlReadMode.ReadSchema);
                dt_units = ds.Tables["dt_units"];
                dt_item = ds.Tables["dt_item"];
                dt_abtype = ds.Tables["dt_abtype"];
                dt_abtype2 = ds.Tables["dt_abtype2"];
                dt_stations = ds.Tables["dt_stations"];
                lock (locker_dt_logs)
                {
                    dt_logs = ds.Tables["dt_logs"];
                }
                dt_check = ds.Tables["dt_check"];
                RefreshStatus("读取完成");
                new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(true, ReloadDtParamType.Unit));
                new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(true, ReloadDtParamType.Item));
                new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(true, ReloadDtParamType.AbType));
                new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(true, ReloadDtParamType.AbType2));
                new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(true, ReloadDtParamType.Station));
                new Thread(new ParameterizedThreadStart(InitDtLogs)).Start(true);
            }
            else
            {
                if (MessageBox.Show("是否通过连接数据库加载表信息？", "未能找到load.info", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(false, ReloadDtParamType.Unit));
                    new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(false, ReloadDtParamType.Item));
                    new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(false, ReloadDtParamType.AbType));
                    new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(false, ReloadDtParamType.AbType2));
                    new Thread(new ParameterizedThreadStart(ReloadMinorDt)).Start(new ReloadDtParam(false, ReloadDtParamType.Station));
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
                newsaved_tmp = false;
            }
            else
            {
                MessageBox.Show("unexpected datatable rowchanged event!");
            }
    //        Debug.WriteLine("rowchanged" + sta++);
        }
    }
}