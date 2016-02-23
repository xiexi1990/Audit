using System.Windows.Forms;
using System;

namespace Audit
{
    public partial class MainFrame : Form
    {
        public void RefreshStatus(string s)
        {
            RefreshStatus(s, false);
        }
        public void RefreshStatus(string s, bool remove_last_line)
        {
            if (this.richTextBox_Status.InvokeRequired)
                this.Invoke(new RefreshStatusCallback(RefreshStatus), new object[] { s, remove_last_line });
            else
            {
                if (this.richTextBox_Status.TextLength == 0)
                    this.richTextBox_Status.Text = s;
                else
                {
                    if (remove_last_line)
                    {
                        richTextBox_Status.Text = richTextBox_Status.Text.Substring(0, richTextBox_Status.TextLength - richTextBox_Status.Lines[richTextBox_Status.Lines.Length - 1].Length);
                        richTextBox_Status.Text += s;
                    }
                    else
                    {
                        richTextBox_Status.Text += "\n" + s;
                    }
                }
                this.richTextBox_Status.SelectionStart = this.richTextBox_Status.TextLength;
                this.richTextBox_Status.SelectionLength = 0;
                this.richTextBox_Status.Focus();
            }
        }
    }
}