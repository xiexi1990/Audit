﻿using System.Drawing;
using System.Windows.Forms;
using System.Data;
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

        private void WSTD_CC_T(string col, int v)
        {
            WriteScoreToDt_T(col, v);
            CheckColor(dataGridView_Logs.CurrentRow);
     //       RecordTime();
        }

        private void WriteScoreToDt_T(string col, int v)
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
            if (row != null && row.DataBoundItem != null)
            {
                Color color;
                DataRow r = (row.DataBoundItem as DataRowView).Row;
                if (Convert.ToInt32(r["SCORE_GROUP"]) != -1 && Convert.ToInt32(r["SCORE_TIME"]) != -1 && Convert.ToInt32(r["SCORE_LOG"]) != -1 && Convert.ToInt32(r["SCORE_GRAPH"]) != -1)
                {
                    color = Color.LightGreen;
                }
                else
                {
                    color = Color.White;
                }
                foreach (DataGridViewCell c in row.Cells)
                {
                    c.Style.BackColor = color;
                }
                foreach (DataGridViewRow _r in dataGridView_Logs.Rows)
                {
                    if (_r == null || _r.Cells["LOG_ID"].Value == null)
                        continue;
                    if (_r != row && _r.Cells["LOG_ID"].Value.ToString() == row.Cells["LOG_ID"].Value.ToString())
                    {
                        row.Cells["LOG_ID"].Style.BackColor = Color.PaleVioletRed;
                        break;
                    }
                }
            }
        }

        private void CheckAllColor()
        {
            foreach (DataGridViewRow gr in dataGridView_Logs.Rows)
            {
                CheckColor(gr);
            }
        }

        private void button_TimeGood_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_TIME", vb.score_time = 0);
        }
        private void button_TimeBad_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_TIME", vb.score_time = 1);
        }
        private void button_GraphGood_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GRAPH", vb.score_graph = 0);
        }
        private void button_GraphMiddle_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GRAPH", vb.score_graph = 1);
        }
        private void button_GraphBad_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GRAPH", vb.score_graph = 2);
        }
        private void button_LogGood_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_LOG", vb.score_log = 0);
        }
        private void button_LogMiddle_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_LOG", vb.score_log = 1);
        }
        private void button_LogBad_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_LOG", vb.score_log = 2);
        }
        private void button_GroupGood_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GROUP", vb.score_group = 0);
        }
        private void button_GroupBad_Click(object sender, EventArgs e)
        {
            WSTD_CC_T("SCORE_GROUP", vb.score_group = 1);
        }
        
    }
}