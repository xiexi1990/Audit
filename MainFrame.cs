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
using excel = Microsoft.Office.Interop.Excel;


namespace Audit
{

    public delegate void singleValueChanging(int new_value);
    public partial class MainFrame : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private int sta = 0;
        delegate void Param0Callback();
        delegate void Param1Callback(object param);
        delegate void StrCallback(string s);
        public ValueBox vb = new ValueBox();
        private Button[] score_group_buttons = new Button[2], 
            score_time_buttons = new Button[2], 
            score_graph_buttons = new Button[3], 
            score_log_buttons = new Button[3];
        private Control[] ctrl_list = new Control[33];
 //       private OraHelper orahlper = new OraHelper("server = 127.0.0.1/orcx; user id = qzdata; password = xie51");
        private OraHelper orahlper = new OraHelper("server = 10.5.67.11/pdbqz; user id = qzdata; password = qz9401tw");
        public DataTable dt_units, dt_logs, dt_units_comments, dt_param, dt_check;
     //   public DataTable dt_units_cache_w, dt_logs_cache_w, dt_units_comments_cache_w, dt_param_cache_w, dt_check_cache_w;
  //      public DataSet ds_cache = new DataSet("ds_cache");
        
        public DataView dv_dt_logs;
        int dgv_sorted_index = -1;
        bool dgv_sorted_asc = true, dgv_unit_asc = true;
        
        private object locker_dt_logs = new object(), locker_dt_units_comments = new object(), locker_dt_param = new object();
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

            MenuItem_SaveSchema.Enabled = true;
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

            dt_units_comments = new DataTable();
            dt_units_comments.Columns.Add("UNIT_CODE");
            dt_units_comments.Columns.Add("U_COMMENTS");
            dt_param = new DataTable();
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
                        (r.DataBoundItem as DataRowView).Row["AUDIT_TIME"] = DateTime.Now;
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
            if (orahlper.oracon.DataSource == "127.0.0.1/orcx")
            {
                rl.Set(new DateTime(2014, 9, 1), @"河南省 15,湖北省 15, 辽宁省 20");
            }
            else if (true)
            {
                rl.Set(new DateTime(2016, 1, 1), @"地壳应力研究所 10,地球物理研究所 10,地震预测研究所 10,");
            }
            if (rl.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            if (backgroundWorker_LogFetcher.IsBusy == false)
                backgroundWorker_LogFetcher.RunWorkerAsync(rl);
            else
                MessageBox.Show("事件抽取器正忙！");
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
        }
        private void Global_MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
        }   

        private void dataGridView_Logs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView_Logs.Columns[e.ColumnIndex].Name == "UNITNAME")
            {
                dgv_unit_asc ^= true;
            }
            else
            {
                if (e.ColumnIndex == dgv_sorted_index)
                {
                    dgv_sorted_asc ^= true;
                }
                else
                {
                    dgv_sorted_asc = true;
                    dgv_sorted_index = e.ColumnIndex;
                }
            }
            string sort = "unitname";
            if (!dgv_unit_asc)
                sort += " desc";
            if (dgv_sorted_index >= 0)
            {
                sort += ", " + dataGridView_Logs.Columns[dgv_sorted_index].Name;
                if (!dgv_sorted_asc)
                    sort += " desc";
            }
            this.dv_dt_logs.Sort = sort;
            CheckAllColor();
        }

        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            rtb_active = sender as RichTextBox;
            rtb_text_end = rtb_active.TextLength;
            if (e.KeyCode == Keys.Right && rtb_active.SelectionStart == rtb_active.TextLength)
            {
                if (ReloadLBSentences(MenuItem_AutoCompletionLimit.Checked) <= 0)
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

        private void timer_ReSelect_Tick(object sender, EventArgs e)
        {
            timer_ReSelect.Stop();
            if (rtb_active != null)
            {
                rtb_active.Select(rtb_text_end, rtb_active.TextLength - rtb_text_end);
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
                    p.DTAP_mode = DTAccessorParam.DTAP_save;
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
            sd.Filter = "info文件|*.info";
            sd.FilterIndex = 1;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("schsave");
                ds.Tables.Add(dt_logs.Clone());
                ds.Tables.Add(dt_check.Clone());
                ds.Tables.Add(dt_units);
                ds.WriteXml(sd.FileName, XmlWriteMode.WriteSchema);
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
                    p.DTAP_mode = DTAccessorParam.DTAP_save;
                    p.filename = sd.FileName;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
                }
                else
                    MessageBox.Show("文件存取器正忙！");
            }
        }

        private void MenuItem_Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "dt文件|*.dt";
            od.FilterIndex = 1;
            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (backgroundWorker_DTAccessor.IsBusy == false)
                {
                    DTAccessorParam p = new DTAccessorParam();
                    p.DTAP_mode = DTAccessorParam.DTAP_add;
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
            if (p.DTAP_mode == DTAccessorParam.DTAP_add)
            {
                RefreshStatus("正在加载文件……");
                DataSet ds = new DataSet();
                ds.ReadXml(p.filename, XmlReadMode.ReadSchema);
                int pn = dt_logs.Rows.Count;
                this.Invoke(new Param0Callback(() =>
                {
                    if (ds.Tables["dt_logs"] != null)
                    {
                        lock (locker_dt_logs)
                        {
                            dt_logs.Merge(ds.Tables["dt_logs"]);
                        }
                    }
                    if (ds.Tables["dt_check"] != null)
                    {
                        dt_check.Merge(ds.Tables["dt_check"]);
                        DataView dv = new DataView(dt_check);
                        dt_check = dv.ToTable(true);
                    }
                    if (ds.Tables["dt_units_comments"] != null)
                    {
                        lock (locker_dt_units_comments)
                        {
                            //                 dt_units_comments.Merge(ds.Tables["dt_units_comments"]);
                        }
                    }
                    if (ds.Tables["dt_param"] != null)
                    {
                        lock (locker_dt_param)
                        {
                        }
                    }
                    RefreshStatus("文件加载成功，共加载" + (dt_logs.Rows.Count - pn) + "条");
                    this.CheckAllColor();
                }
                ));
            }
            else if(p.DTAP_mode == DTAccessorParam.DTAP_save)
            {
                RefreshStatus("正在保存文件……");
                DataSet ds = new DataSet();
                this.Invoke(new Param0Callback(()=>
                    {
                        ds.Tables.Add(dt_logs.Copy());
                        ds.Tables.Add(dt_check.Copy());
                        ds.Tables.Add(dt_units_comments.Copy());
                        ds.Tables.Add(dt_param.Copy());
                    }
                    ));
                ds.WriteXml(p.filename, XmlWriteMode.WriteSchema);
                RefreshStatus("文件保存成功");
            }
            this.Invoke(new Param0Callback(() =>
            {
                this.Text = p.filename + "  保存于" +
                    File.GetLastWriteTime(p.filename).ToString("yyyy/MM/dd HH:mm:ss");
                if (p.DTAP_mode == DTAccessorParam.DTAP_add && dt_logs.Rows.Count > 0)
                {
                    this.log_shown = true;
                    this.ShowLog(dt_logs.Rows[0]);
                }
            }));
            cur_file = p.filename;
        }

        private void WriteReportExcel(string filename)
        {
            filename = "c:\\testxml1";
            excel.Application eapp = new excel.Application();
            excel.Workbook book = eapp.Workbooks.Add();
            excel.Worksheet sheet = book.Worksheets[1];
            sheet.Cells[1, 1] = "hello";
            
            eapp.Visible = true;
            book.SaveAs(filename);
        }

        private void button_Output_Click(object sender, EventArgs e)
        {
            WriteReportExcel(null);
        }

        private void backgroundWorker_ReportWriter_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void dataGridView_Logs_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
       //     Text = "compare";
       //     Debug.WriteLine("compare");
        }

        private void dataGridView_Logs_Sorted(object sender, EventArgs e)
        {
            Debug.WriteLine("sorted!");
        }

        private void dataGridView_Logs_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CheckAllColor();
        }
    }
}
