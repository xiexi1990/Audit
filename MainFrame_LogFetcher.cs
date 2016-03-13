using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void backgroundWorker_LogFetcher_DoWork(object sender, DoWorkEventArgs e)
        {
            LogFetcherParam lp = e.Argument as LogFetcherParam;
            //   BackgroundWorker wker = sender as BackgroundWorker;
            if (lp.type == LogFetcherParamType.Rule)
            {
                for (int i = 0; i < lp.rl.unit_num.GetLength(0); i++)
                {
                    this.RefreshStatus("正在抽取" + lp.rl.unit_num[i, 0] + "的事件……");
                    SqlGenerator sg = new SqlGenerator();
                    string esql = sg.GenExtractionSql(Convert.ToInt32(lp.rl.unit_num[i, 1]), lp.rl.unit_num[i, 2], lp.rl.after_date.Year, lp.rl.after_date.Month, lp.rl.after_date.Day, lp.rl.no_earlier);
                    DataTable dt = orahlper.GetDataTable(esql);
                    DataTable dt2 = orahlper.GetDataTable(sg.GenCheckSql(dt));
                    this.Invoke(new Param0Callback(() =>
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            lock (locker_dt_logs)
                            {
                                dt_logs.Columns["ROWID"].AutoIncrement = true;
                                dt_logs.ImportRow(r);
                                dt_logs.Columns["ROWID"].AutoIncrement = false;
                                dt_logs.Rows[dt_logs.Rows.Count - 1]["SCORE_GROUP"] = -1;
                                dt_logs.Rows[dt_logs.Rows.Count - 1]["SCORE_TIME"] = -1;
                                dt_logs.Rows[dt_logs.Rows.Count - 1]["SCORE_LOG"] = -1;
                                dt_logs.Rows[dt_logs.Rows.Count - 1]["SCORE_GRAPH"] = -1;
                            }
                        }
                        dt_check.Merge(dt2);
                        this.RefreshStatus(lp.rl.unit_num[i, 0] + "共抽取" + dt.Rows.Count + "条");
                        if (this.log_shown == false)
                        {
                            this.log_shown = true;
                            ShowLog(dt_logs.Rows[0]);
                        }
                    }
                        ));
                }
                this.Invoke(new Param0Callback(() =>
                {
                    DataView dv = new DataView(dt_check);
                    dt_check = dv.ToTable(true);
                    CheckAllColor();
                    RefreshStatus("抽取事件完成");
                }
            ));
            }
            else if (lp.type == LogFetcherParamType.GSetRule)
            {
                RefreshStatus("正在抽取事件……");
                DataTable dt = orahlper.GetDataTable(lp.gs.sql);
                dt.Columns.Add("SCORE_GROUP", typeof(int));
                dt.Columns.Add("SCORE_TIME", typeof(int));
                dt.Columns.Add("SCORE_LOG", typeof(int));
                dt.Columns.Add("SCORE_GRAPH", typeof(int));
                dt.Columns.Add("SCORE_GSET", typeof(int));
                dt.Columns.Add("SCORE_GSETCLASS", typeof(int));
                foreach (DataRow r in dt.Rows)
                {
                    r["SCORE_GROUP"] = -1;
                    r["SCORE_TIME"] = -1;
                    r["SCORE_LOG"] = -1;
                    r["SCORE_GRAPH"] = -1;
                    r["SCORE_GSET"] = -1;
                    r["SCORE_GSETCLASS"] = -1;
                }
                this.Invoke(new Param0Callback(() =>
                    {
                        lock (locker_dt_logs)
                        {
                            dt_logs.Merge(dt);
                        }
                        RefreshStatus("抽取事件完成");
                        if (this.log_shown == false)
                        {
                            this.log_shown = true;
                            ShowLog(dataGridView_Logs.CurrentRow);
                        }
                        CheckAllColor();
                    }));
                RefreshStatus("正在获取审核信息……");
                SqlGenerator sg = new SqlGenerator();
                DataTable dt2 = orahlper.GetDataTable(sg.GenCheckSql(dt));
                dt_check.Merge(dt2);
                DataView dv = new DataView(dt_check);
                dt_check = dv.ToTable(true);
                this.Invoke(new Param0Callback(() =>
                {
                    RefreshStatus("获取审核信息完成");
                    ShowLog(dataGridView_Logs.CurrentRow);
                    CheckAllColor();
                }
            ));
            }

        }
    }
}