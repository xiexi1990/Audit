﻿using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void backgroundWorker_LogFetcher_DoWork(object sender, DoWorkEventArgs e)
        {
            Rule rl = e.Argument as Rule;
            BackgroundWorker wker = sender as BackgroundWorker;
            for (int i = 0; i < rl.unit_num.GetLength(0); i++)
            {
                this.RefreshStatus("正在抽取" + rl.unit_num[i, 0] + "的事件……");
                SqlGenerator sg = new SqlGenerator();
                DataTable dt = orahlper.GetDataTable(sg.GenExtractionSql(Convert.ToInt32(rl.unit_num[i, 1]), rl.unit_num[i, 2], rl.after_date.Year, rl.after_date.Month, rl.after_date.Day, rl.no_earlier));
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
                        if (this.log_shown == false)
                        {
                            this.log_shown = true;
                            //this.Invoke(new Param0Callback(()=>
                            //ShowLog(dt_logs.Rows[dt_logs.Rows.Count - 1])
                            //));
                            ShowLog(dt_logs.Rows[dt_logs.Rows.Count - 1]);
                        }
                    }
                    this.RefreshStatus(rl.unit_num[i, 0] + "共抽取" + dt.Rows.Count + "条");
                }
                    ));

            }
            this.Invoke(new Param0Callback(() =>
            {
                CheckAllColor();
                RefreshStatus("事件抽取完成");
            }
            ));
        }
    }
}