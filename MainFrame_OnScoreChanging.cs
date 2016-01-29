using System.Drawing;
using System.Windows.Forms;
using System;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void OnScoreGroupChanging(int new_value)
        {
            if (vb.score_group >= 0 && vb.score_group <= 1)
            {
                score_group_buttons[vb.score_group].BackColor = SystemColors.Control;
                score_group_buttons[vb.score_group].UseVisualStyleBackColor = true;
            }
            if (new_value >= 0 && new_value <= 1)
                score_group_buttons[new_value].BackColor = Color.PaleVioletRed;
        }
        private void OnScoreTimeChanging(int new_value)
        {
            if (vb.score_time >= 0 && vb.score_time <= 1)
            {
                score_time_buttons[vb.score_time].BackColor = SystemColors.Control;
                score_time_buttons[vb.score_time].UseVisualStyleBackColor = true;
            }
            if (new_value >= 0 && new_value <= 1)
                score_time_buttons[new_value].BackColor = Color.PaleVioletRed;
        }
        private void OnScoreGraphChanging(int new_value)
        {
            if (vb.score_graph >= 0 && vb.score_graph <= 2)
            {
                score_graph_buttons[vb.score_graph].BackColor = SystemColors.Control;
                score_graph_buttons[vb.score_graph].UseVisualStyleBackColor = true;
            }
            if (new_value >= 0 && new_value <= 2)
                score_graph_buttons[new_value].BackColor = Color.PaleVioletRed;
        }
        private void OnScoreLogChanging(int new_value)
        {
            if (vb.score_log >= 0 && vb.score_log <= 2)
            {
                score_log_buttons[vb.score_log].BackColor = SystemColors.Control;
                score_log_buttons[vb.score_log].UseVisualStyleBackColor = true;
            }
            if (new_value >= 0 && new_value <= 2)
                score_log_buttons[new_value].BackColor = Color.PaleVioletRed;
        }

        private void WriteScoreToDt(string col, int v)
        {
            if (!score_change_observe)
                return;
            if (cur_log - 1 >= 0 && cur_log - 1 < dt_logs.Rows.Count)
            {
                lock (locker_dt_logs)
                {
                    dt_logs.Rows[cur_log - 1][col] = v;
                }
            }
        }

        private void button_TimeGood_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_TIME", vb.score_time = 0);
        }
        private void button_TimeBad_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_TIME", vb.score_time = 1);
        }
        private void button_GraphGood_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_GRAPH", vb.score_graph = 0);
        }
        private void button_GraphMiddle_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_GRAPH", vb.score_graph = 1);
        }
        private void button_GraphBad_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_GRAPH", vb.score_graph = 2);
        }
        private void button_LogGood_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_LOG", vb.score_log = 0);
        }
        private void button_LogMiddle_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_LOG", vb.score_log = 1);
        }
        private void button_LogBad_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_LOG", vb.score_log = 2);
        }
        private void button_GroupGood_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_GROUP", vb.score_group = 0);
        }
        private void button_GroupBad_Click(object sender, EventArgs e)
        {
            WriteScoreToDt("SCORE_GROUP", vb.score_group = 1);
        }
        
    }
}