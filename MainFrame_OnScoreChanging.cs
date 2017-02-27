using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System;
using System.Diagnostics;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void OnScoreOveranalyChanging(int new_value)
        {
            if (vb.score_overanaly >= 0 && vb.score_overanaly <= 1)
            {
                score_overanaly_buttons[vb.score_overanaly].BackColor = SystemColors.Control;
                score_overanaly_buttons[vb.score_overanaly].UseVisualStyleBackColor = true;
            }
            if (new_value == 0)
                score_overanaly_buttons[new_value].BackColor = Color.Green;
            else if (new_value == 1)
                score_overanaly_buttons[new_value].BackColor = Color.Red;
        }
        private void OnScoreMissanalyChanging(int new_value)
        {
            if (vb.score_missanaly >= 0 && vb.score_missanaly <= 1)
            {
                score_missanaly_buttons[vb.score_missanaly].BackColor = SystemColors.Control;
                score_missanaly_buttons[vb.score_missanaly].UseVisualStyleBackColor = true;
            }
            if (new_value == 0)
                score_missanaly_buttons[new_value].BackColor = Color.Green;
            else if (new_value == 1)
                score_missanaly_buttons[new_value].BackColor = Color.Red;
        }
        private void OnScoreGroupChanging(int new_value)
        {
            if (vb.score_group >= 0 && vb.score_group <= 1)
            {
                score_group_buttons[vb.score_group].BackColor = SystemColors.Control;
                score_group_buttons[vb.score_group].UseVisualStyleBackColor = true;
            }
            if (new_value == 0)
                score_group_buttons[new_value].BackColor = Color.Green;
            else if (new_value == 1)
                score_group_buttons[new_value].BackColor = Color.Red;
        }
        private void OnScoreTimeChanging(int new_value)
        {
            if (vb.score_time >= 0 && vb.score_time <= 1)
            {
                score_time_buttons[vb.score_time].BackColor = SystemColors.Control;
                score_time_buttons[vb.score_time].UseVisualStyleBackColor = true;
            }
            if (new_value == 0)
                score_time_buttons[new_value].BackColor = Color.Green;
            else if (new_value == 1)
                score_time_buttons[new_value].BackColor = Color.Red;
        }
        private void OnScoreGraphChanging(int new_value)
        {
            if (vb.score_graph >= 0 && vb.score_graph <= 2)
            {
                score_graph_buttons[vb.score_graph].BackColor = SystemColors.Control;
                score_graph_buttons[vb.score_graph].UseVisualStyleBackColor = true;
            }
            if (new_value == 0)
                score_graph_buttons[new_value].BackColor = Color.Green;
            else if (new_value == 1)
                score_graph_buttons[new_value].BackColor = Color.Yellow;
            else if(new_value == 2)
                score_graph_buttons[new_value].BackColor = Color.Red;
        }
        private void OnScoreLogChanging(int new_value)
        {
            if (vb.score_log >= 0 && vb.score_log <= 2)
            {
                score_log_buttons[vb.score_log].BackColor = SystemColors.Control;
                score_log_buttons[vb.score_log].UseVisualStyleBackColor = true;
            }
            if (new_value == 0)
                score_log_buttons[new_value].BackColor = Color.Green;
            else if (new_value == 1)
                score_log_buttons[new_value].BackColor = Color.Yellow;
            else if (new_value == 2)
                score_log_buttons[new_value].BackColor = Color.Red;
        }
        private void OnScoreGSetChanging(int new_value)
        {
            if (vb.score_gset >= 0 && vb.score_gset <= 4)
            {
                if (vb.score_gset == 0)
                {
                    score_gset_buttons[vb.score_gset].BackColor = Color.LightGreen;
                }
                else if(vb.score_gset == 2)
                {
                    score_gset_buttons[vb.score_gset].BackColor = Color.LightBlue;
                }
                else if (vb.score_gset == 3)
                {
                    score_gset_buttons[vb.score_gset].BackColor = Color.YellowGreen;
                }
                else
                {
                    score_gset_buttons[vb.score_gset].BackColor = SystemColors.Control;
                    score_gset_buttons[vb.score_gset].UseVisualStyleBackColor = true;
                }
     
            }
            if (new_value == 0)
                score_gset_buttons[new_value].BackColor = Color.Green;
            else if (new_value == 1)
                score_gset_buttons[new_value].BackColor = Color.GreenYellow;
            else if (new_value == 2)
                score_gset_buttons[new_value].BackColor = Color.Yellow;
            else if(new_value == 3)
                score_gset_buttons[new_value].BackColor = Color.Red;
            else if(new_value == 4)
                score_gset_buttons[new_value].BackColor = Color.LightSkyBlue;
        }
        private void OnScoreGSetClassChanging(int new_value)
        {
            if (vb.score_gsetclass >= 0 && vb.score_gsetclass <= 1)
            {
                score_gsetclass_buttons[vb.score_gsetclass].BackColor = SystemColors.Control;
                score_gsetclass_buttons[vb.score_gsetclass].UseVisualStyleBackColor = true;
            }
            if (new_value == 0)
                score_gsetclass_buttons[new_value].BackColor = Color.GreenYellow;
            else if (new_value == 1)
                score_gsetclass_buttons[new_value].BackColor = Color.Green;
        }
     

        private void WSTD_CC_T(string col, double v)
        {
            WriteScoreToDt_T(col, v);
            CheckColor(dataGridView_Logs.CurrentRow);
     //       RecordTime();
        }

        private void WriteScoreToDt_T(string col, double v)
        {
            if (!score_change_observe)
                return;
            if (dataGridView_Logs.CurrentRow != null && dataGridView_Logs.CurrentRow.DataBoundItem != null)
            {
                lock (locker_dt_logs)
                {
                    (dataGridView_Logs.CurrentRow.DataBoundItem as DataRowView).Row[col] = v;
                    (dataGridView_Logs.CurrentRow.DataBoundItem as DataRowView).Row["AUDIT_TIME"] = DateTime.Now;
                }
            }
        }

        private void CheckColor(DataGridViewRow row)
        {
    //        Debug.WriteLine("checkcolor" + sta++);
            if (row != null && row.DataBoundItem != null)
            {
                Color color;
                DataRow r = (row.DataBoundItem as DataRowView).Row;
                if (!(r["POSTPONE"] is DBNull) && Convert.ToBoolean(r["POSTPONE"]))
                {
                    color = Color.LightSkyBlue;
                }
                else
                {
                    if (IS_GSET)
                    {
                        if (r["SCORE_GSET"] is DBNull)
                        {
                            color = Color.White;
                        }
                        else
                        {
                            int sco = Convert.ToInt32(r["SCORE_GSET"]);    
                            if (sco == 0)
                                color = Color.Green;
                            else if (sco == 1)
                                color = Color.GreenYellow;
                            else if (sco == 2)
                                color = Color.Yellow;
                            else if (sco == 3)
                                color = Color.PaleVioletRed;
                            else if (sco == 4)
                                color = Color.LightSkyBlue;
                            else
                                color = Color.White;
                        }
                    }
                    else
                    {
                        if (!(r["SCORE_GROUP"] is DBNull || r["SCORE_TIME"] is DBNull || r["SCORE_LOG1"] is DBNull || r["SCORE_LOG2"] is DBNull || r["SCORE_LOG3"] is DBNull || r["SCORE_LOG2PLUS"] is DBNull || r["SCORE_GRAPH"] is DBNull) && r.Field<double>("SCORE_GROUP") >= 0 && r.Field<double>("SCORE_TIME") >= 0 && r.Field<double>("SCORE_LOG1") >= 0 && r.Field<double>("SCORE_LOG2") >= 0 && r.Field<double>("SCORE_LOG3") >= 0 && r.Field<double>("SCORE_LOG2PLUS") >= 0 && r.Field<double>("SCORE_GRAPH") >= 0)
                        {
                            double vlog2 = r.Field<double>("SCORE_LOG2") + r.Field<double>("SCORE_LOG2PLUS");
                            if (vlog2 > 9)
                                vlog2 = 9;
                            double re = r.Field<double>("SCORE_GROUP") + r.Field<double>("SCORE_TIME") + r.Field<double>("SCORE_LOG1") + vlog2 + r.Field<double>("SCORE_LOG3") + r.Field<double>("SCORE_GRAPH");
                            if (re >= 28 && re <= 35)
                                color = Color.LightGreen;
                            else if (re >= 21 && re < 28)
                                color = Color.Yellow;
                            else if(re >= 0 && re < 21)
                                color = Color.PaleVioletRed;
                            else
                                color = Color.LightSkyBlue;
                            if (can_change_label_showscore)
                            {
                                label_ShowScore.Text = "当前事件得分  " + Math.Round(re, 2);
                            }
                        }
                        else
                        {
                            color = Color.White;
                        }
                    }
                }
                row.DefaultCellStyle.BackColor = color;
                bool set_red = false;
                int total = dataGridView_Logs.Rows.Count;
                int n = 0;
                foreach (DataGridViewRow _r in dataGridView_Logs.Rows)
                {
                    if (set_red)
                        break;
                    if (_r.DefaultCellStyle.BackColor != Color.White)
                    {
                        n++;
                    }
                    if (_r == null || _r.Cells["LOG_ID"].Value == null)
                        continue;
                    if (_r != row && _r.Cells["LOG_ID"].Value.ToString() == row.Cells["LOG_ID"].Value.ToString())
                    {
                        set_red = true;
                    }
                }
                label_Finished.Text = "已完成 " + n + "/" + total + "\n进度 "  + Math.Round(n*100.0/total,2) + "%";

                if (set_red)
                {
                    row.Cells["LOG_ID"].Style.BackColor = Color.Red;
                }
                else
                {
                    row.Cells["LOG_ID"].Style.BackColor = row.DefaultCellStyle.BackColor;
                }
            }
        }

        private void CheckAllColor()
        {
            can_change_label_showscore = false;
            foreach (DataGridViewRow gr in dataGridView_Logs.Rows)
            {
                CheckColor(gr);
            }
            can_change_label_showscore = true;
        }

        private void button_TimeGood_Click(object sender, EventArgs e)
        {
            vb.score_time = 0;
            WSTD_CC_T("SCORE_TIME", 3);
        }
        private void button_TimeBad_Click(object sender, EventArgs e)
        {
            vb.score_time = 1;
            WSTD_CC_T("SCORE_TIME", 0);
        }
        private void button_GraphGood_Click(object sender, EventArgs e)
        {
            vb.score_graph = 0;
            WSTD_CC_T("SCORE_LOG3", 2);
        }
        private void button_GraphMiddle_Click(object sender, EventArgs e)
        {
            vb.score_graph = 1;
            WSTD_CC_T("SCORE_LOG3", 2*0.7);
        }
        private void button_GraphBad_Click(object sender, EventArgs e)
        {
            vb.score_graph = 2;
            WSTD_CC_T("SCORE_LOG3", 0);
        }
        private void button_LogGood_Click(object sender, EventArgs e)
        {
            vb.score_log = 0;
            WSTD_CC_T("SCORE_LOG2", 9);
        }
        private void button_LogMiddle_Click(object sender, EventArgs e)
        {
            vb.score_log = 1;
            WSTD_CC_T("SCORE_LOG2", 9*0.8);
        }
        private void button_LogBad_Click(object sender, EventArgs e)
        {
            vb.score_log = 2;
            WSTD_CC_T("SCORE_LOG2", 0);
        }
        private void button_GroupGood_Click(object sender, EventArgs e)
        {
            vb.score_group = 0;
            WSTD_CC_T("SCORE_GROUP", 4);
        }
        private void button_GroupBad_Click(object sender, EventArgs e)
        {
            vb.score_group = 1;
            WSTD_CC_T("SCORE_GROUP", 0);
        }

        private void button_GSet0_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GSET", vb.score_gset = 0);
        }

        private void button_GSet1_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GSET", vb.score_gset = 1);
        }

        private void button_GSet2_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GSET", vb.score_gset = 2);
        }

        private void button_GSet3_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GSET", vb.score_gset = 3);
        }

        private void button_GSet4_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GSET", vb.score_gset = 4);
        }

        private void button_GSetClass1_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GSETCLASS", vb.score_gsetclass = 1);
        }

        private void button_GSetClass0_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GSETCLASS", vb.score_gsetclass = 0);
        }

        private void numeric_Log_ValueChanged(object sender, EventArgs e)
        {
            if (!numeric_and_check_change_observe)
                return;
            WSTD_CC_T("SCORE_LOG1", 9 - 9.0 / 3 * Convert.ToDouble(numeric_Log.Value));
        }

        private void numeric_Graph_ValueChanged(object sender, EventArgs e)
        {
            if (!numeric_and_check_change_observe)
                return;
            WSTD_CC_T("SCORE_GRAPH", 8 - 8.0 / 3 * Convert.ToDouble(numeric_Graph.Value));
        }

        private void checkBox_Log2_CheckedChanged(object sender, EventArgs e)
        {
            if (!numeric_and_check_change_observe)
                return;
            double v;
            if (checkBox_Log2.CheckState == CheckState.Checked)
            {
                v = 18;
            }
            else
                v = 0;
            WSTD_CC_T("SCORE_LOG2PLUS", v);
        }

        private void button_OveranalyGood_Click(object sender, EventArgs e)
        {
            WriteScoreToDt_T("SCORE_OVERANALY", vb.score_overanaly = 0);
        }

        private void button_OveranalyBad_Click(object sender, EventArgs e)
        {
            WriteScoreToDt_T("SCORE_OVERANALY", vb.score_overanaly = 1);
        }

        private void button_MissanalyGood_Click(object sender, EventArgs e)
        {
            WriteScoreToDt_T("SCORE_MISSANALY", vb.score_missanaly = 0);
        }

        private void button_MissanalyBad_Click(object sender, EventArgs e)
        {
            WriteScoreToDt_T("SCORE_MISSANALY", vb.score_missanaly = 1);
        }


    }
}