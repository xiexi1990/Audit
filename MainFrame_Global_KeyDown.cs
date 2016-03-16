using System.Windows.Forms;
using System.Diagnostics;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void MainFrame_Global_KeyDown(object sender, KeyEventArgs e)
        {
   //         Debug.WriteLine((sender as Control).Name);
            if (true)
            {
                if (e.KeyCode == Keys.PageUp && e.Alt && MenuItem_PageWithAlt.Checked ||
                    e.KeyCode == Keys.PageUp && !e.Alt && !MenuItem_PageWithAlt.Checked)
                {
                    GoPrevLog();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.PageDown && e.Alt && MenuItem_PageWithAlt.Checked ||
                    e.KeyCode == Keys.PageDown && !e.Alt && !MenuItem_PageWithAlt.Checked)
                {
                    GoNextLog();
                    e.Handled = true;
                }
            }
        }
    }
}