using System.Windows.Forms;
using System.Data;
using System;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private int ReloadLBSentences(bool limit)
        {
            if (dataGridView_Logs.CurrentRow == null || dataGridView_Logs.CurrentRow.DataBoundItem == null)
                return -1;
            DataView dv = new DataView(dt_logs);
            dv.RowStateFilter = DataViewRowState.CurrentRows;
            string rf = "rowid <> " + dataGridView_Logs.CurrentRow.Cells["ROWID"].Value;
            string col = null;
            switch (rtb_active.Name)
            {
                case "richTextBox_GroupCheck": col = "COMMENTS_GROUP"; break;
                case "richTextBox_TimeCheck": col = "COMMENTS_TIME"; break;
                case "richTextBox_LogCheck": col = "COMMENTS_LOG"; break;
                case "richTextBox_GraphCheck": col = "COMMENTS_GRAPH"; break;
            }
            rf += " and " + col + " is not null and trim(" + col + ") <> ''";
            if (limit)
            {
                rf += " and ab_type_name = '" + dataGridView_Logs.CurrentRow.Cells["AB_TYPE_NAME"].Value + "'";
            }
            dv.RowFilter = rf;
            listBox_Sentences.DataSource = dv.ToTable(true, new string[] { col });
            listBox_Sentences.DisplayMember = col;
            listBox_Sentences.ValueMember = col;
            listBox_Sentences.SelectedIndex = -1;
            return dv.Count;
        }

        private void listBox_Sentences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!listBox_Sentences.Visible || listBox_Sentences.SelectedIndex == -1)
                return;
            rtb_active.Text = rtb_active.Text.Substring(0, rtb_text_end) + listBox_Sentences.SelectedValue;
            rtb_active.Select(rtb_text_end, rtb_active.TextLength - rtb_text_end);
        }

        private void listBox_Sentences_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                listBox_Sentences.Visible = false;
                listBox_Sentences.SelectedIndex = -1;
                rtb_active.SelectionStart = rtb_active.TextLength;
                rtb_active.Focus();
            }
            else if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back)
            {
                listBox_Sentences.Visible = false;
                listBox_Sentences.SelectedIndex = -1;
                rtb_active.Text = rtb_active.Text.Substring(0, rtb_text_end);
                rtb_active.SelectionStart = rtb_active.TextLength;
                rtb_active.Focus();
            }
            if (e.Alt && e.KeyCode == Keys.Menu)
            {
                //        Debug.Write(e.KeyCode);
                //        Debug.Write(e.KeyData + "\n");
                MenuItem_AutoCompletionLimit.Checked = MenuItem_AutoCompletionLimit.Checked ^ true;
                if (ReloadLBSentences(MenuItem_AutoCompletionLimit.Checked) > 0)
                {
                    listBox_Sentences.SelectedIndex = 0;
                }
                e.Handled = true;
            }
        }

        private void listBox_Sentences_Leave(object sender, EventArgs e)
        {
            if (listBox_Sentences.Visible)
            {
                listBox_Sentences.Visible = false;
            }
        }
    }
}