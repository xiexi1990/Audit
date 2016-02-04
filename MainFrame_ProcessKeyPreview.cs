using System.Windows.Forms;

namespace Audit
{
    public partial class MainFrame : Form
    {
        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == 0x0100) /// WM_KEYDOWN
            {
                //Debug.WriteLine(string.Format("hwnd = {0}", m.HWnd));
                //Debug.WriteLine(string.Format("msg = {0}", m.Msg));
                //Debug.WriteLine(string.Format("wparam = {0}", m.WParam));
                //Debug.WriteLine(string.Format("lparam = {0}\n", m.LParam));
                if (!MenuItem_PageWithAlt.Checked)
                {
                    if (!(m.HWnd == dataGridView_Logs.Handle))
                    {
                        //     this.Text = string.Format("keydown {0}", sta++);
                        if ((int)m.WParam == 33)
                        {
                            GoPrevLog();
                            return true;
                        }
                        else if ((int)m.WParam == 34)
                        {
                            GoNextLog();
                            return true;
                        }
                    }
                }
                if ((int)m.WParam == 0x11)
                {
                    ctrl_down = true;
                }
                //      else if
            }
            else if (m.Msg == 0x101) /// WM_KEYUP
            {
                if ((int)m.WParam == 0x11)
                {
                    ctrl_down = false;
                }
                if (m.HWnd == richTextBox_GroupCheck.Handle)
                {
                }
            }
            else if (m.Msg == 0x104) /// WM_SYSKEYDOWN
            {
                if ((int)m.WParam == 0x12)
                {
                    alt_down = true;
                }
                if (MenuItem_PageWithAlt.Checked)
                {
                    if ((int)m.WParam == 33)
                    {
                        GoPrevLog();
                        return true;
                    }
                    else if ((int)m.WParam == 34)
                    {
                        GoNextLog();
                        return true;
                    }
                }
            }
            else if (m.Msg == 0x105) /// WM_SYSKEYUP
            {
                if ((int)m.WParam == 0x12)
                {
                    alt_down = false;
                }
            }

            return base.ProcessKeyPreview(ref m);
        }
    }
}