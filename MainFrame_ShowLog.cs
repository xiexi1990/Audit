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
        public void ShowLog(int rowid)
        {
            DataRow r = null;

            if (Convert.ToInt32(dt_logs.Rows[rowid - 1]["ROWID"]) == rowid)
            {
                r = dt_logs.Rows[rowid - 1];
            }
            else
            {
                foreach (DataRow _r in this.dt_logs.Rows)
                {
                    if (Convert.ToInt32(_r["ROWID"]) == rowid)
                    {
                        r = _r;
                        Debug.WriteLine("not hit");
                        break;
                    }
                }
            }
            if (r != null && r.RowState != DataRowState.Deleted)
            {
                text_change_observe = false;
                this.cur_log = rowid;
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

                vb.score_group = r["SCORE_GROUP"] is DBNull ? -1 : Convert.ToInt32(r["SCORE_GROUP"]);
                vb.score_time = r["SCORE_TIME"] is DBNull ? -1 : Convert.ToInt32(r["SCORE_TIME"]);
                vb.score_log = r["SCORE_LOG"] is DBNull ? -1 : Convert.ToInt32(r["SCORE_LOG"]);
                vb.score_graph = r["SCORE_GRAPH"] is DBNull ? -1 : Convert.ToInt32(r["SCORE_GRAPH"]);
                    
                text_change_observe = true;
            }
        }
        private void ShowLog(string log_id)
        {
            foreach (DataRow r in this.dt_logs.Rows)
            {
                if (r["log_id"].ToString() == log_id)
                {
                    ShowLog(Convert.ToInt32(r["rowid"]));
                    break;
                }
            }
        }
    }
}