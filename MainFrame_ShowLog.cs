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
    //            this.cur_log = rowid;
                this.richTextBox_Group.Text = r["AB_TYPE_NAME"].ToString();
                this.richTextBox_Time.Text = r["START_DATE"].ToString() + " - \n" + (r["END_DATE"] is DBNull ? "未结束" : r["END_DATE"].ToString());
                this.richTextBox_Log.Text = r["AB_DESC"].ToString();
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

                richTextBox_GroupCheck.Text = Convert.ToString(r["COMMENTS_GROUP"]);
                richTextBox_TimeCheck.Text = Convert.ToString(r["COMMENTS_TIME"]);
                richTextBox_LogCheck.Text = Convert.ToString(r["COMMENTS_LOG"]);
                richTextBox_GraphCheck.Text = Convert.ToString(r["COMMENTS_GRAPH"]);

                vb.score_group = Convert.ToInt32(r["SCORE_GROUP"]);
                vb.score_time = Convert.ToInt32(r["SCORE_TIME"]);
                vb.score_log = Convert.ToInt32(r["SCORE_LOG"]);
                vb.score_graph = Convert.ToInt32(r["SCORE_GRAPH"]);
                CheckColor();
                if (vb.score_group == -1 && vb.score_time == -1 && vb.score_log == -1 && vb.score_graph == -1 && MenuItem_AutoGood.Checked)
                {
                    button_AllGood_Click(null, null);
                }
                    
                text_change_observe = true;
            }
        }
        private void ShowLog(DataGridViewRow gr)
        {
            if(gr != null && gr.DataBoundItem != null)
                ShowLog((gr.DataBoundItem as DataRowView).Row);
        }
    }
}