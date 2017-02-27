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
            vb.score_group = -1;
            vb.score_time = -1;
            vb.score_log = -1;
            vb.score_graph = -1;
            numeric_and_check_change_observe = false;
            numeric_Graph.Value = 0;
            numeric_Log.Value = 0;
            checkBox_Log2.Checked = false;
       //     label_ShowScore.Text = "当前事件得分  0";
            numeric_and_check_change_observe = true;
            WriteScoreToDt_T("SCORE_GROUP", -1);
            WriteScoreToDt_T("SCORE_TIME", -1);
            WriteScoreToDt_T("SCORE_LOG1", -1);
            WriteScoreToDt_T("SCORE_LOG2", -1);
            WriteScoreToDt_T("SCORE_LOG2PLUS", -1);
            WriteScoreToDt_T("SCORE_LOG3", -1);
            WriteScoreToDt_T("SCORE_GRAPH", -1);
            WriteScoreToDt_T("SCORE_OVERANALY", vb.score_overanaly = -1);
            WriteScoreToDt_T("SCORE_MISSANALY", vb.score_missanaly = -1);
            if (IS_GSET)
            {
                WriteScoreToDt_T("SCORE_GSET", vb.score_gset = -1);
                WriteScoreToDt_T("SCORE_GSETCLASS", vb.score_gsetclass = -1);
            }
            CheckColor(dataGridView_Logs.CurrentRow);
        }

        private void button_AllGood_Click(object sender, EventArgs e)
        {
            if (IS_GSET)
            {
                WriteScoreToDt_T("SCORE_GSET", vb.score_gset = 2);
            }
            else
            {
                vb.score_group = 0;
                vb.score_time = 0;
                vb.score_log = 0;
                vb.score_graph = 0;
                numeric_and_check_change_observe = false;
                numeric_Graph.Value = 0;
                numeric_Log.Value = 0;
                checkBox_Log2.Checked = false;
                numeric_and_check_change_observe = true;
                WriteScoreToDt_T("SCORE_GROUP", 4);
                WriteScoreToDt_T("SCORE_TIME", 3);
                WriteScoreToDt_T("SCORE_LOG1", 9);
                WriteScoreToDt_T("SCORE_LOG2", 9);
                WriteScoreToDt_T("SCORE_LOG2PLUS", 0);
                WriteScoreToDt_T("SCORE_LOG3", 2);
                WriteScoreToDt_T("SCORE_GRAPH", 8);
    //            WriteScoreToDt_T("SCORE_GSET", vb.score_gset = 0);
    //            WriteScoreToDt_T("SCORE_GSETCLASS", vb.score_gsetclass = 0);
                WriteScoreToDt_T("SCORE_OVERANALY", vb.score_overanaly = 0);
                WriteScoreToDt_T("SCORE_MISSANALY", vb.score_missanaly = 0);
            }
            CheckColor(dataGridView_Logs.CurrentRow);
        }
    }
}