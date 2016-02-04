using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Audit
{

    public delegate void singleValueChanging(int new_value);
    public partial class MainFrame : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private int sta = 0;
   //     delegate void InitDtLogsCallback();
   //     delegate void SetDtCallback(DataTable dt);
   //     delegate void RefreshStatusCallback(string s);
        delegate void Param0Callback();
        delegate void Param1Callback(object param);
        delegate void StrCallback(string s);
        public ValueBox vb = new ValueBox();
        private Button[] score_group_buttons = new Button[2], 
            score_time_buttons = new Button[2], 
            score_graph_buttons = new Button[3], 
            score_log_buttons = new Button[3];
        private Control[] ctrl_list = new Control[33];
        private OraHelper orahlper = new OraHelper("server = 127.0.0.1/orcx; user id = qzdata; password = xie51");
  //      private OraHelper orahlper = new OraHelper("server = 10.5.67.11/pdbqz; user id = qzdata; password = qz9401tw");
        public DataSet dtset = new DataSet("dt_set");
        public DataTable dt_units, dt_logs, dt_logs_copy;
        private object locker_dt_logs = new object(), locker_dtset = new object();
    //    private int cur_log = -1;
        private bool log_shown = false, alt_down = false, ctrl_down = false, text_change_observe = true, score_change_observe = true;
        private RichTextBox rtb_active = null;
        private RichTextBox[] rtbs_check = new RichTextBox[4];
        private int rtb_text_end = -1;
        private bool omit_rtb_keyup = false;
        private string cur_file = null;
        
        public object[,] UNIT_NUM = { { "IGP", 10 }, { "IGL", 10 }, { "ICD", 10 }, { "BJ", 15 }, { "TJ", 20 }, { "HE", 20 }, { "SX", 20 }, { "NM", 15 }, { "IES", 10 }, { "DPC", 0 }, { "LN", 20 }, { "JL", 15 }, { "HL", 15 }, { "SH", 15 }, { "JS", 15 }, { "ZJ", 15 }, { "AH", 15 }, { "FJ", 20 }, { "JX", 15 }, { "SD", 20 }, { "HA", 15 }, { "HB", 15 }, { "HN", 15 }, { "GD", 15 }, { "GX", 15 }, { "HI", 10 }, { "SC", 20 }, { "YN", 20 }, { "XZ", 10 }, { "CQ", 15 }, { "SN", 20 }, { "GS", 20 }, { "QH", 15 }, { "NX", 20 }, { "XJ", 20 } };
        public MainFrame()
        {
            InitializeComponent();
            vb.SetDelegate(OnScoreGroupChanging, OnScoreTimeChanging, OnScoreGraphChanging, OnScoreLogChanging);
            score_group_buttons[0] = this.button_GroupGood;
            score_group_buttons[1] = this.button_GroupBad;
            score_time_buttons[0] = this.button_TimeGood;
            score_time_buttons[1] = this.button_TimeBad;
            score_graph_buttons[0] = this.button_GraphGood;
            score_graph_buttons[1] = this.button_GraphMiddle;
            score_graph_buttons[2] = this.button_GraphBad;
            score_log_buttons[0] = this.button_LogGood;
            score_log_buttons[1] = this.button_LogMiddle;
            score_log_buttons[2] = this.button_LogBad;

            rtbs_check[0] = richTextBox_GroupCheck;
            rtbs_check[1] = richTextBox_TimeCheck;
            rtbs_check[2] = richTextBox_LogCheck;
            rtbs_check[3] = richTextBox_GraphCheck;

    //        MenuItem_SaveSchema.Enabled = true;
            MenuItem_Save.Enabled = false;
            if (false)
            {
                this.richTextBox_GroupCheck.Text = "对事件分类的审核意见";
                this.richTextBox_TimeCheck.Text = "对起止时间的审核意见";
                this.richTextBox_LogCheck.Text = "对事件记录的审核意见";
                this.richTextBox_GraphCheck.Text = "对图件的审核意见";
            }
            this.FillCtrlList();
            this.Form1_Resize(null, null);
            this.button_Input.Enabled = false;

            listBox_Sentences.Visible = false;

            for (int i = 0; i < 4; i++)
            {
                rtbs_check[i].TextChanged += new EventHandler(richTextBox_TextChanged);
                rtbs_check[i].KeyDown += new KeyEventHandler(richTextBox_KeyDown);
                rtbs_check[i].HideSelection = false;
            }

            foreach (Control c in this.Controls)
            {
                c.MouseClick += new MouseEventHandler(Global_MainFrame_Click);
       //         c.KeyDown += new KeyEventHandler(Global_MainFrame_KeyDown);
            }
            this.MouseClick += new MouseEventHandler(Global_MainFrame_Click);
       //     this.KeyDown += new KeyEventHandler(Global_MainFrame_KeyDown);

        }
        ~MainFrame()
        {
            this.orahlper.oracon.Close();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!text_change_observe)
                return;
            RichTextBox rtb = sender as RichTextBox;
            string col = null;
            switch (rtb.Name)
            {
                case "richTextBox_GroupCheck":
                    col = "COMMENTS_GROUP";
                    break;
                case "richTextBox_TimeCheck":
                    col = "COMMENTS_TIME";
                    break;
                case "richTextBox_LogCheck":
                    col = "COMMENTS_LOG";
                    break;
                case "richTextBox_GraphCheck":
                    col = "COMMENTS_GRAPH";
                    break;
            }
            if (col != null)
            {
                var r = dataGridView_Logs.CurrentRow;
                if (r != null && r.DataBoundItem != null)
                {
                    lock (locker_dt_logs)
                    {
                        (r.DataBoundItem as DataRowView).Row[col] = rtb.Text;
                    }
                }
            }
        }     

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            ImageShower f2 = new ImageShower(this.pictureBox_Graph.Image);
            f2.Show();
        }

        private void button_Input_Click(object sender, EventArgs e)
        {
            Rule rl = new Rule(this.dt_units);
            if (rl.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            if (backgroundWorker_LogFetcher.IsBusy == false)
                backgroundWorker_LogFetcher.RunWorkerAsync(rl);
            else
                MessageBox.Show("事件抽取器正忙！");

    //        MemoryStream mstream = new MemoryStream((byte[])dt.Rows[0]["graph"]);
    //              this.pictureBox_Graph.Image = Image.FromStream(mstream);
        }        

        private void dataGridView_Logs_SelectionChanged(object sender, EventArgs e)
        {
            ShowLog(dataGridView_Logs.CurrentRow);
        }

        private void GoPrevLog()
        {
            SendMessage(this.dataGridView_Logs.Handle, 0x0100, 38, 0);
        }
        private void GoNextLog()
        {
            SendMessage(this.dataGridView_Logs.Handle, 0x0100, 40, 0);
        }

        private void Global_MainFrame_Click(object sender, EventArgs e)
        {
            //if ((sender as Control).Name != "listBox_Sentences")
            //{
            //    if (listBox_Sentences.Visible)
            //    {
            //        listBox_Sentences.Visible = false;
            //    }
            //}
        }
        private void Global_MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
      //      Debug.WriteLine(e.KeyData);
        }   

        private void dataGridView_Logs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CheckAllColor();
        }

        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            rtb_active = sender as RichTextBox;
            rtb_text_end = rtb_active.TextLength;
            if (e.KeyCode == Keys.Right && rtb_active.SelectionStart == rtb_active.TextLength)
            {
                if (Reload_LB_Sentences(MenuItem_AutoCompletionLimit.Checked) <= 0)
                {
                    return;
                }
                Rectangle r = new Rectangle(rtb_active.Right, rtb_active.Top, Convert.ToInt32(rtb_active.Width * 0.7 > 200 ? 200 : rtb_active.Width * 0.7), rtb_active.Height);
                listBox_Sentences.Location = r.Location;
                listBox_Sentences.Size = r.Size;

                listBox_Sentences.Visible = true;
                listBox_Sentences.Focus();
                listBox_Sentences.SelectedIndex = 0;
                timer_ReSelect.Start();
            }
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
                if (Reload_LB_Sentences(MenuItem_AutoCompletionLimit.Checked) > 0)
                {
                    listBox_Sentences.SelectedIndex = 0;
                }
                e.Handled = true;
            }
        }

        private void timer_ReSelect_Tick(object sender, EventArgs e)
        {
            timer_ReSelect.Stop();
            if (rtb_active != null)
            {
                rtb_active.Select(rtb_text_end, rtb_active.TextLength - rtb_text_end);
            }
        }

        private void listBox_Sentences_Leave(object sender, EventArgs e)
        {
            if (listBox_Sentences.Visible)
            {
                listBox_Sentences.Visible = false;
            }
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            if (cur_file == null)
            {
                MenuItem_SaveAs_Click(null, null);
            }
            else
            {
                if (backgroundWorker_DTAccessor.IsBusy == false)
                {
                    DTAccessorParam p = new DTAccessorParam();
                    p.is_read = false;
                    p.filename = cur_file;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
                }
                else
                    MessageBox.Show("文件保存器正忙！");
            }
        }

        private void MenuItem_SaveSchema_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "sch文件|*.sch";
            sd.FilterIndex = 1;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                dtset.WriteXml(sd.FileName, XmlWriteMode.WriteSchema);
              //  dtset.WriteXmlSchema(sd.FileName);
            }
        }

        private void MenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "dt文件|*.dt";
            sd.FilterIndex = 1;
            sd.FileName = cur_file;
            if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (backgroundWorker_DTAccessor.IsBusy == false)
                {
                    DTAccessorParam p = new DTAccessorParam();
                    p.is_read = false;
                    p.filename = sd.FileName;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
                }
                else
                    MessageBox.Show("文件存取器正忙！");
            }
        }

        private void MenuItem_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "dt文件|*.dt";
            od.FilterIndex = 1;
            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (backgroundWorker_DTAccessor.IsBusy == false)
                {
                    DTAccessorParam p = new DTAccessorParam();
                    p.is_read = true;
                    p.filename = od.FileName;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
                }
                else
                    MessageBox.Show("文件存取器正忙！");
            }
        }

        private void backgroundWorker_DTAccessor_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DTAccessorParam p = e.Argument as DTAccessorParam;
            if (p.is_read)
            {
                this.Invoke(new Param0Callback(() =>
                {
                    RefreshStatus("正在读取文件……");
                    lock (locker_dt_logs)
                    {
                        dt_logs.ReadXml(p.filename);
                    }
                    RefreshStatus("文件读取成功");
                    this.CheckAllColor();
                }
                ));
            }
            else
            {
                this.Invoke(new Param0Callback(()=>
                    dt_logs_copy = dt_logs.Copy()
                    ));
                RefreshStatus("正在保存文件……");
                dt_logs_copy.WriteXml(p.filename);
                RefreshStatus("文件保存成功");
            }
            this.Invoke(new Param0Callback(() =>
            {
                this.Text = p.filename + "  保存于" +
                    File.GetLastWriteTime(p.filename).ToString("yyyy/MM/dd HH:mm:ss");
                if (p.is_read && dt_logs.Rows.Count > 0)
                {
                    this.log_shown = true;
                    this.ShowLog(dt_logs.Rows[0]);
                }
            }));
            cur_file = p.filename;

        }
    }
}
