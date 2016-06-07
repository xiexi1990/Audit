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
                if (Convert.ToInt32(r["SCORE_GROUP"]) == -1 && Convert.ToInt32(r["SCORE_TIME"]) == -1 && Convert.ToInt32(r["SCORE_LOG"]) == -1 && Convert.ToInt32(r["SCORE_GRAPH"]) == -1 &&
                    (!IS_GSET || Convert.ToInt32(r["SCORE_GSET"]) == -1)
                    && (!IS_GSET || Convert.ToInt32(r["SCORE_GSETCLASS"]) == -1)
                    && MenuItem_AutoGood.Checked)
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
                this.label_LogInfo.Text = string.Format("{0} {1}{2}{3}{4}[{5}]", r["SCIENCE"], r["UNITNAME"], r["STATIONNAME"], r["INSTRCODE"], r["INSTRNAME"], r["POINTID"]);

                if (IS_GSET)
                {
                    richTextBox_WholeInfo.Text = label_LogInfo.Text + "\n\n事件类别：" + richTextBox_Group.Text + "\n\n影响因素：" + r["TYPE2_NAME"] + "\n\n测项：" + r["ITEM"] + "\n\n起止时间：" + richTextBox_Time.Text + "\n\n事件描述：" + richTextBox_Log.Text;
                }
                else
                {
                    richTextBox_WholeInfo.Text = label_LogInfo.Text + "\n\n事件类别：" + richTextBox_Group.Text + "  影响因素：" + ii.wholestr + "\n\n起止时间：" + richTextBox_Time.Text + "\n\n事件描述：" + richTextBox_Log.Text;
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
                    richTextBox_GroupCheck.Text = Convert.ToString(r["COMMENTS_GROUP"]);
                    richTextBox_TimeCheck.Text = Convert.ToString(r["COMMENTS_TIME"]);
                    richTextBox_LogCheck.Text = Convert.ToString(r["COMMENTS_LOG"]);
                    richTextBox_GraphCheck.Text = Convert.ToString(r["COMMENTS_GRAPH"]);
                    vb.score_group = Convert.ToInt32(r["SCORE_GROUP"]);
                    vb.score_time = Convert.ToInt32(r["SCORE_TIME"]);
                    vb.score_log = Convert.ToInt32(r["SCORE_LOG"]);
                    vb.score_graph = Convert.ToInt32(r["SCORE_GRAPH"]);        
                    checkBox_Postpone.Checked = r["POSTPONE"] is DBNull ? false : Convert.ToBoolean(r["POSTPONE"]);
                }
                
                //           CheckColor(dataGridView_Logs.CurrentRow);   

                text_change_observe = true;
            }
            else
            {
                text_change_observe = false;
                prev_logid = null;
                this.richTextBox_Group.Clear();
                this.richTextBox_Time.Clear();
                this.richTextBox_Log.Clear();
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
                checkBox_Postpone.Checked = false;
                text_change_observe = true;
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