using System.Windows.Forms;
using System.Data;

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
    }
}