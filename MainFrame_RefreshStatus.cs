using System.Windows.Forms;

namespace Audit
{
    public partial class MainFrame : Form
    {
        public void RefreshStatus(string s)
        {
            if (this.richTextBox_Status.InvokeRequired)
                this.Invoke(new StrCallback(RefreshStatus), new object[] { s });
            else
            {
                if (this.richTextBox_Status.Text.Length == 0)
                    this.richTextBox_Status.Text = s;
                else
                {
                    this.richTextBox_Status.Text += "\n" + s;
                }
                this.richTextBox_Status.SelectionStart = this.richTextBox_Status.Text.Length;
                this.richTextBox_Status.SelectionLength = 0;
                this.richTextBox_Status.Focus();
            }
        }
    }
}