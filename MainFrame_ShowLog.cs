using System.Windows.Forms;
using System.Data;
using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;


namespace Audit
{
    public partial class MainFrame : Form
    {
       
        public void ShowLog(DataRow r)
        {
            if (!log_shown)
                return;
            if (r != null && r.RowState != DataRowState.Deleted)
            {
                text_change_observe = false;
                numeric_and_check_change_observe = false;
                if ((r["SCORE_GROUP"] is DBNull || r.Field<double>("SCORE_GROUP") < 0) &&
                    (r["SCORE_TIME"] is DBNull || r.Field<double>("SCORE_TIME") < 0) &&
                    (r["SCORE_LOG1"] is DBNull || r.Field<double>("SCORE_LOG1") < 0 || r.Field<double>("SCORE_LOG1") == 9) &&
                    (r["SCORE_LOG2"] is DBNull || r.Field<double>("SCORE_LOG2") < 0) &&
                    (r["SCORE_LOG3"] is DBNull || r.Field<double>("SCORE_LOG3") < 0) &&
                    (r["SCORE_GRAPH"] is DBNull || r.Field<double>("SCORE_GRAPH") < 0 || r.Field<double>("SCORE_GRAPH") == 8) &&
                    (!IS_GSET || (r["SCORE_GSET"] is DBNull || Convert.ToInt32(r["SCORE_GSET"]) == -1))
                    && (!IS_GSET || (r["SCORE_GSETCLASS"] is DBNull || Convert.ToInt32(r["SCORE_GSETCLASS"]) == -1)) &&
                    (r["SCORE_OVERANALY"] is DBNull || Convert.ToInt32(r["SCORE_OVERANALY"]) == -1) &&
                    (r["SCORE_MISSANALY"] is DBNull || Convert.ToInt32(r["SCORE_MISSANALY"]) == -1) &&
                    MenuItem_AutoGood.Checked)
                {
                    button_AllGood_Click(null, null);
                }

                //if (r["LOG_ID"].ToString() == prev_logid)
                //{
                //    text_change_observe = true;
                //    return;
                //}
                prev_logid = r["LOG_ID"].ToString();
                
                //            this.cur_log = rowid;
      
                this.richTextBox_Group.Text = r["AB_TYPE_NAME"].ToString();
                this.richTextBox_Time.Text = r["START_DATE"].ToString() + " - \n" + (r["END_DATE"] is DBNull ? "未结束" : r["END_DATE"].ToString());
                this.richTextBox_Log.Text = r["AB_DESC"].ToString().Trim() + "\n";
                CheckResultHelper cr = new CheckResultHelper();
                cr.Fill(dt_check, r["LOG_ID"].ToString());
                ItemlogInfoHelper ii = new ItemlogInfoHelper();
                ii.Fill(dt_itemloginfo, r["LOG_ID"].ToString());

                if (!IS_GSET)
                {
                }

                MemoryStream mstream = new MemoryStream((byte[])r["GRAPH"]);
                this.pictureBox_Graph.Image = Image.FromStream(mstream);
                if (pictureBox_Graph.Height >= pictureBox_Graph.Image.Height && pictureBox_Graph.Width >= pictureBox_Graph.Image.Width)
                {
                    pictureBox_Graph.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    pictureBox_Graph.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                mstream.Close();
                this.label_LogInfo.Text = string.Format("{0} {1}{2}{3}{4}[{5}]", r["SCIENCE"], r["UNITNAME"], r["STATIONNAME"], r["INSTRCODE"], r["INSTRNAME"], r["POINTID"]);

                if (IS_GSET)
                {
                    richTextBox_WholeInfo.Text = label_LogInfo.Text + "\n\n事件类别：" + richTextBox_Group.Text + "\n\n影响因素：" + ii.wholestr + "\n\n测项：" + r["ITEM"] + "\n\n起止时间：" + richTextBox_Time.Text + "\n\n事件描述：" + richTextBox_Log.Text;
                }
                else
                {
                    richTextBox_WholeInfo.Text = label_LogInfo.Text + "\n\n事件类别：" + richTextBox_Group.Text + "  影响因素：" + ii.wholestr + "\n\n起止时间：" + richTextBox_Time.Text + "\n\n事件描述：" + richTextBox_Log.Text + "异常核实报告：" + (r["CHECK_LOG"] is DBNull ? "无\n" : "有\n");
                }
                if (r["CHECK_LOG"] is DBNull)
                {
                    button_SaveChecklog.BackColor = SystemColors.Control;
                    button_SaveChecklog.UseVisualStyleBackColor = true;
                }
                else
                {
                    button_SaveChecklog.BackColor = Color.Yellow;
                }

                int start = richTextBox_WholeInfo.TextLength;
                richTextBox_WholeInfo.AppendText(cr.wholestr[0] + "\n");
                richTextBox_WholeInfo.Select(start, cr.wholestr[0].Length);
                richTextBox_WholeInfo.SelectionColor = Color.Blue;

                start = richTextBox_WholeInfo.TextLength;
                richTextBox_WholeInfo.AppendText(cr.wholestr[1] + "\n");
                richTextBox_WholeInfo.Select(start, cr.wholestr[1].Length);
                richTextBox_WholeInfo.SelectionColor = Color.Red;
                richTextBox_WholeInfo.Select(0, 0);

                if (IS_GSET)
                {
                    richTextBox_GSetComments.Text = Convert.ToString(r["COMMENTS_GSET"]);
                    vb.score_gset = Convert.ToInt32(r["SCORE_GSET"]);
          //          vb.score_gsetclass = Convert.ToInt32(r["SCORE_GSETCLASS"]);
                }
                else
                {
                    richTextBox_GroupCheck.Text = r["COMMENTS_GROUP"] is DBNull ? "" : r.Field<string>("COMMENTS_GROUP");
                    richTextBox_TimeCheck.Text = r["COMMENTS_TIME"] is DBNull ? "" : r.Field<string>("COMMENTS_TIME");
                    richTextBox_LogCheck.Text = r["COMMENTS_LOG"] is DBNull ? "" : r.Field<string>("COMMENTS_LOG");
                    richTextBox_GraphCheck.Text = r["COMMENTS_GRAPH"] is DBNull ? "" : r.Field<string>("COMMENTS_GRAPH");
                    if (r["SCORE_GROUP"] is DBNull || r.Field<double>("SCORE_GROUP") < 0)
                        vb.score_group = -1;
                    else
                    {
                        if (r.Field<double>("SCORE_GROUP") == 0)
                            vb.score_group = 1;
                        else
                            vb.score_group = 0;
                    }

                    if (r["SCORE_TIME"] is DBNull || r.Field<double>("SCORE_TIME") < 0)
                        vb.score_time = -1;
                    else
                    {
                        if (r.Field<double>("SCORE_TIME") == 0)
                            vb.score_time = 1;
                        else
                            vb.score_time = 0;
                    }

                    if (r["SCORE_LOG2"] is DBNull || r.Field<double>("SCORE_LOG2") < 0)
                        vb.score_log = -1;
                    else
                    {
                        if (r.Field<double>("SCORE_LOG2") == 0)
                            vb.score_log = 2;
                        else if (r.Field<double>("SCORE_LOG2") == 9)
                            vb.score_log = 0;
                        else
                            vb.score_log = 1;
                    }

                    if (r["SCORE_LOG3"] is DBNull || r.Field<double>("SCORE_LOG3") < 0)
                        vb.score_graph = -1;
                    else
                    {
                        if (r.Field<double>("SCORE_LOG3") == 0)
                            vb.score_graph = 2;
                        else if (r.Field<double>("SCORE_LOG3") == 2)
                            vb.score_graph = 0;
                        else
                            vb.score_graph = 1;
                    }
                    if (r["SCORE_LOG1"] is DBNull || r.Field<double>("SCORE_LOG1") < 0)
                        numeric_Log.Value = 0;
                    else
                        numeric_Log.Value = Convert.ToDecimal(Math.Round((9 - r.Field<double>("SCORE_LOG1")) / (9.0 / 3), 1));
                    if (r["SCORE_GRAPH"] is DBNull || r.Field<double>("SCORE_GRAPH") < 0)
                        numeric_Graph.Value = 0;
                    else
                        numeric_Graph.Value = Convert.ToDecimal(Math.Round((8 - r.Field<double>("SCORE_GRAPH")) / (8.0 / 3), 1));
                    if (!(r["SCORE_LOG2PLUS"] is DBNull) && r.Field<double>("SCORE_LOG2PLUS") == 18)
                        checkBox_Log2.Checked = true;
                    else
                        checkBox_Log2.Checked = false;

                    if (!(r["SCORE_GROUP"] is DBNull || r.Field<double>("SCORE_GROUP") < 0) && !(r["SCORE_TIME"] is DBNull || r.Field<double>("SCORE_TIME") < 0) && !(r["SCORE_LOG1"] is DBNull || r.Field<double>("SCORE_LOG1") < 0) && !(r["SCORE_LOG2"] is DBNull || r.Field<double>("SCORE_LOG2") < 0) && !(r["SCORE_LOG2PLUS"] is DBNull || r.Field<double>("SCORE_LOG2PLUS") < 0) && !(r["SCORE_LOG3"] is DBNull || r.Field<double>("SCORE_LOG3") < 0) && !(r["SCORE_GRAPH"] is DBNull || r.Field<double>("SCORE_GRAPH") < 0))
                    {
                        double vlog2 = r.Field<double>("SCORE_LOG2") + r.Field<double>("SCORE_LOG2PLUS");
                        if (vlog2 > 9)
                            vlog2 = 9;
                        double sum = r.Field<double>("SCORE_GROUP") + r.Field<double>("SCORE_TIME") + r.Field<double>("SCORE_LOG1") + vlog2 + r.Field<double>("SCORE_LOG3") + r.Field<double>("SCORE_GRAPH");
                        label_ShowScore.Text = "当前事件得分  " + Math.Round(sum, 2);
                    }
                    else
                    {
                        label_ShowScore.Text = "当前事件得分  " + 0;
                    }
                    
                    vb.score_overanaly = r["SCORE_OVERANALY"] is DBNull ? -1 : Convert.ToInt32(r["SCORE_OVERANALY"]);
                    vb.score_missanaly = r["SCORE_MISSANALY"] is DBNull ? -1 : Convert.ToInt32(r["SCORE_MISSANALY"]);
                    checkBox_Postpone.Checked = r["POSTPONE"] is DBNull ? false : Convert.ToBoolean(r["POSTPONE"]);
                }
                
                //           CheckColor(dataGridView_Logs.CurrentRow);   

                text_change_observe = true;
                numeric_and_check_change_observe = true;
            }
            else
            {
                text_change_observe = false;
                numeric_and_check_change_observe = false;

                prev_logid = null;
                richTextBox_Group.Clear();
                richTextBox_Time.Clear();
                richTextBox_Log.Clear();
                pictureBox_Graph.Image = null;
                label_LogInfo.Text = "LogInfo";
                richTextBox_GroupCheck.Clear();
                richTextBox_TimeCheck.Clear();
                richTextBox_LogCheck.Clear();
                richTextBox_GraphCheck.Clear();
                richTextBox_GSetComments.Clear();
                richTextBox_WholeInfo.Clear();
                vb.score_group = -1;
                vb.score_time = -1;
                vb.score_log = -1;
                vb.score_graph = -1;
                vb.score_gset = -1;
                vb.score_gsetclass = -1;
                vb.score_overanaly = -1;
                vb.score_missanaly = -1;
                checkBox_Postpone.Checked = false;
                button_SaveChecklog.BackColor = SystemColors.Control;
                button_SaveChecklog.UseVisualStyleBackColor = true;
                checkBox_Log2.Checked = false;
                numeric_Graph.Value = 0;
                numeric_Log.Value = 0;
                label_ShowScore.Text = "当前事件得分  0";

                text_change_observe = true;
                numeric_and_check_change_observe = true;
            }
        }
        private void ShowLog(DataGridViewRow gr)
        {
            if (gr != null && gr.DataBoundItem != null)
                ShowLog((gr.DataBoundItem as DataRowView).Row);
            else
                ShowLog((DataRow)null);
        }
    }
}