using System.Windows.Forms;
using System;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void button_PrevLog_Click(object sender, EventArgs e)
        {
            GoPrevLog();
        }

        private void button_NextLog_Click(object sender, EventArgs e)
        {
            GoNextLog();
        }

        private void MenuItem_PageWithAlt_Click(object sender, EventArgs e)
        {
            if (MenuItem_PageWithAlt.Checked == true)
            {
                button_PrevLog.Text = "上一事件(Alt+PageUp)";
                button_NextLog.Text = "下一事件(Alt+PageDown)";
            }
            else
            {
                button_PrevLog.Text = "上一事件(PageUp)";
                button_NextLog.Text = "下一事件(PageDown)";
            }
        }

        private void button_ClearScore_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_GROUP", vb.score_group = -1);
            WriteScoreToDt("SCORE_TIME", vb.score_time = -1);
            WriteScoreToDt("SCORE_LOG", vb.score_log = -1);
            WriteScoreToDt("SCORE_GRAPH", vb.score_graph = -1);
            CheckColor();
        }

        private void button_AllGood_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_GROUP", vb.score_group = 0);
            WriteScoreToDt("SCORE_TIME", vb.score_time = 0);
            WriteScoreToDt("SCORE_LOG", vb.score_log = 0);
            WriteScoreToDt("SCORE_GRAPH", vb.score_graph = 0);
            CheckColor();
        }
    }
}