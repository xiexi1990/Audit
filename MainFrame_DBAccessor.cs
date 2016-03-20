using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System;
using System.Diagnostics;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void backgroundWorker_DBAccessor_DoWork(object sender, DoWorkEventArgs e)
        {
            DBAccessorParam lp = e.Argument as DBAccessorParam;
            //   BackgroundWorker wker = sender as BackgroundWorker;
            if (lp.type == DBAccessorParamType.Rule)
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
            else if (lp.type == DBAccessorParamType.GSetRule)
            {
                RefreshStatus("正在抽取事件……");
                DataTable dt = orahlper.GetDataTable(lp.gs.sql);
                Debug.WriteLine("抽取" + dt.Rows.Count + "条");

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
            else if (lp.type == DBAccessorParamType.GSetWriteDb)
            {
                RefreshStatus("正在写入数据库……");
                DataTable dt = dv_dt_logs.ToTable();
                int i = 1;
                foreach (DataRow r in dt.Rows)
                {
                    if (i == 1)
                    {
                        RefreshStatus("正在写入第1条……");
                    }
                    else
                    {
                        RefreshStatus(string.Format("正在写入第{0}条……", i), true);
                    }
                    string s = string.Format("delete from qzdata.qz_abnormity_dxtjcheck where log_id = '{0}'", r["LOG_ID"]);
                    orahlper.ExecuteNonQuery(s);
                    int sco = 9;
                    switch(Convert.ToInt32(r["SCORE_GSET"]))
                    {
                        case 0: sco = 0; break;
                        case 2: sco = 1; break;
                        case 3: sco = 2; break;
                    }
                    s = string.Format(@"insert into qzdata.qz_abnormity_dxtjcheck (check_id, log_id, is_agree, is_check, user_id, check_name, reason, flag_2, flag_3, flag_5, check_date, flag_7) values 
('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', to_date('{10}', 'yyyymmdd hh24miss'), '{11}')", 
                        Guid.NewGuid().ToString("N").ToUpper(), 
                        r["LOG_ID"],
                        Convert.ToInt32(r["SCORE_GRAPH"]) == -1 ? 9 : Convert.ToInt32(r["SCORE_GRAPH"]), 
                        "1", 
                        "dxtj", 
                        "dxtj", 
                        r["COMMENTS_GSET"], 
                        Convert.ToInt32(r["SCORE_LOG"]) == -1 ? 9 : Convert.ToInt32(r["SCORE_LOG"]),
                        Convert.ToInt32(r["SCORE_TIME"]) == -1 ? 9 : Convert.ToInt32(r["SCORE_TIME"]),
                        Convert.ToInt32(r["SCORE_GROUP"]) == -1 ? 9 : Convert.ToInt32(r["SCORE_GROUP"]), 
                        Convert.ToDateTime(r["AUDIT_TIME"]).ToString("yyyyMMdd HHmmss"), 
                        sco);
                    orahlper.ExecuteNonQuery(s);
                    Debug.WriteLine(s);
                    i++;
                }
                RefreshStatus("写入数据库完毕");
            }

        }
    }
}