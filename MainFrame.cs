#define LOGTEST1
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Audit
{
    public delegate void singleValueChanging(int new_value);

    public partial class MainFrame : Form
    {
        delegate void InitDtLogsCallback();
        delegate void SetDtCallback(DataTable dt);
        delegate void RefreshStatusCallback(string s);
        public ValueBox vb = new ValueBox();
        private Button[] score_group_buttons = new Button[2], 
            score_time_buttons = new Button[2], 
            score_graph_buttons = new Button[3], 
            score_log_buttons = new Button[3];
        private Control[] ctrl_list = new Control[31];
        private OraHelper orahlper = new OraHelper("server = 127.0.0.1/orcx; user id = qzdata; password = xie51");
        public DataTable dt_units, dt_logs;
        private object locker_dt_logs = new object();
        private int cur_log = -1;
        private bool log_shown = false;
        
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

            if (false)
            {
                this.richTextBox_GroupCheck.Text = "对事件分类的审核意见";
                this.richTextBox_TimeCheck.Text = "对起止时间的审核意见";
                this.richTextBox_LogCheck.Text = "对事件记录的审核意见";
                this.richTextBox_GraphCheck.Text = "对图件的审核意见";
            }
            this.FillCtrlList();
            this.Form1_Resize(null, null);

        }
        ~MainFrame()
        {
            this.orahlper.oracon.Close();
        }
        public void InitDtLogs()
        {
            this.RefreshStatus("正在初始化事件表……");
            SqlGenerator sg = new SqlGenerator();
#if LOGTEST
            DataTable dt = this.orahlper.GetDataTable(sg.GenExtractionSql(1, "HB", 2014, 1, 1, false));
#else
            DataTable dt = this.orahlper.GetDataTable(sg.GenExtractionSql(0, "HB", 2014, 1, 1, false)).Clone();
#endif       
            DataColumn dc_rowid = new DataColumn("ROWID", typeof(int));
            dc_rowid.AutoIncrement = false;
            dc_rowid.AutoIncrementSeed = 1;
            dt.Columns.Add(dc_rowid);
            dt.Columns["ROWID"].SetOrdinal(0);
#if LOGTEST
            dt.Rows[0]["ROWID"] = 1;
#endif
            dt.Columns.Add("SCORE_GROUP", typeof(int));
            dt.Columns.Add("SCORE_TIME", typeof(int));
            dt.Columns.Add("SCORE_LOG", typeof(int));
            dt.Columns.Add("SCORE_GRAPH", typeof(int));
            dt.Columns.Add("COMMENTS_GROUP", typeof(string));
            dt.Columns.Add("COMMENTS_TIME", typeof(string));
            dt.Columns.Add("COMMENTS_LOG", typeof(string));
            dt.Columns.Add("COMMENTS_GRAPH", typeof(string));
            this.Invoke(new SetDtCallback((_dt) =>
            {
                lock (locker_dt_logs)
                {
                    this.dt_logs = _dt;
                    this.dataGridView_Logs.DataSource = this.dt_logs;
                }
                foreach (DataGridViewColumn c in dataGridView_Logs.Columns)
                {
                    if (c.Name == "ROWID" || c.Name == "UNITNAME" || c.Name == "STATIONNAME" || c.Name == "INSTRCODE" || c.Name == "INSTRNAME" || c.Name == "AB_TYPE_NAME" || c.Name == "SCIENCE" || c.Name == "START_DATE" || c.Name == "END_DATE")
                    {
                        c.Width = 50;
                        continue;
                    }
                    c.Visible = false;
                }
                dataGridView_Logs.Columns["ROWID"].HeaderText = "序号";
#if LOGTEST
                this.ShowLog(1);
#endif
            }
            ), new object[] { dt });
            this.RefreshStatus("初始化事件表完成");
        }
        public void RefreshStatus(string s)
        {
            if (this.richTextBox_Status.InvokeRequired)
                this.Invoke(new RefreshStatusCallback(RefreshStatus), new object[] { s });
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

        public void ReloadDtUnits()
        {
            this.RefreshStatus("正在加载省局列表……");
            DataTable dt = orahlper.GetDataTable("select unit_code, unitname from qzdata.qz_abnormity_units where unit_code != 'CEN'");
            dt.Columns.Add("NUM");
            foreach (DataRow r in dt.Rows)
            {
                r["NUM"] = 0;
                for (int i = 0; i < UNIT_NUM.GetLength(0); i++)
                {
                    if (r["unit_code"].ToString() == UNIT_NUM[i, 0].ToString())
                    {
                        r["NUM"] = UNIT_NUM[i, 1];
                        break;
                    }
                }
            }
            this.Invoke(new SetDtCallback((_dt) => this.dt_units = _dt), new object[]{dt});
            this.RefreshStatus("加载省局列表完成");
        }

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


        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button_TimeGood_Click(object sender, EventArgs e) { vb.score_time = 0; }
        private void button_TimeBad_Click(object sender, EventArgs e) { vb.score_time = 1; }
        private void button_GraphGood_Click(object sender, EventArgs e) { vb.score_graph = 0; }
        private void button_GraphMiddle_Click(object sender, EventArgs e) { vb.score_graph = 1; }
        private void button_GraphBad_Click(object sender, EventArgs e) { vb.score_graph = 2; }
        private void button_LogGood_Click(object sender, EventArgs e) { vb.score_log = 0; }
        private void button_LogMiddle_Click(object sender, EventArgs e) { vb.score_log = 1; }
        private void button_LogBad_Click(object sender, EventArgs e) { vb.score_log = 2; }
        private void button_GroupGood_Click(object sender, EventArgs e) { vb.score_group = 0; }
        private void button_GroupBad_Click(object sender, EventArgs e) { vb.score_group = 1; }


        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            ImageShower f2 = new ImageShower(this.pictureBox_Graph.Image);
            f2.Show();
        }
        
        private void richTextBox_GroupCheck_TextChanged(object sender, EventArgs e)
        {

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
        public void ShowLog(int rowid)
        {
            foreach (DataRow r in this.dt_logs.Rows)
            {
                if (Convert.ToInt32(r["ROWID"]) == rowid)
                {
                    this.cur_log = rowid;
                    this.richTextBox_Group.Text = r["AB_TYPE_NAME"].ToString();
                    this.richTextBox_Time.Text = r["START_DATE"].ToString() + " - \n" + (r["END_DATE"] is DBNull ? "未结束" : r["END_DATE"].ToString());
                    this.richTextBox_Log.Text = r["AB_DESC"].ToString();
                    MemoryStream mstream = new MemoryStream((byte[])r["GRAPH"]);
                    this.pictureBox_Graph.Image = Image.FromStream(mstream);
                    if (pictureBox_Graph.Height >= pictureBox_Graph.Image.Height && pictureBox_Graph.Width >= pictureBox_Graph.Image.Width)
                    {
                        pictureBox_Graph.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    else
                    {
                        pictureBox_Graph.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    this.label_LogInfo.Text = string.Format("{0} {1}{2}{3}{4}[{5}]", r["SCIENCE"], r["UNITNAME"], r["STATIONNAME"], r["INSTRCODE"], r["INSTRNAME"], r["POINTID"]);

                    break;
                }
            }
        }
        private void ShowLog(string log_id)
        {
            foreach (DataRow r in this.dt_logs.Rows)
            {
                if (r["log_id"].ToString() == log_id)
                {
                    ShowLog(Convert.ToInt32(r["rowid"]));
                    break;
                }
            }
        }

        private void backgroundWorker_LogFetcher_DoWork(object sender, DoWorkEventArgs e)
        {
            Rule rl = e.Argument as Rule;
            BackgroundWorker wker = sender as BackgroundWorker;
            for (int i = 0; i < rl.unit_num.GetLength(0); i++)
            {
                this.RefreshStatus("正在抽取" + rl.unit_num[i, 0] + "的事件……");
                SqlGenerator sg = new SqlGenerator();
                DataTable dt = orahlper.GetDataTable(sg.GenExtractionSql(Convert.ToInt32(rl.unit_num[i, 1]), rl.unit_num[i, 2], rl.after_date.Year, rl.after_date.Month, rl.after_date.Day, rl.no_earlier));
                this.Invoke(new SetDtCallback((_dt) =>
                {
                    foreach (DataRow r in _dt.Rows)
                    {
                        lock (locker_dt_logs)
                        {
                            dt_logs.Columns["ROWID"].AutoIncrement = true;
                            dt_logs.ImportRow(r);
                            dt_logs.Columns["ROWID"].AutoIncrement = false;
                        }
                        if (this.log_shown == false)
                        {
                            this.log_shown = true;
                            this.ShowLog(r["log_id"].ToString());
                        }
                    }
                }
                    ), new object[] { dt });
                
            }
            RefreshStatus("事件抽取完成");

        }

        private void backgroundWorker_LogFetcher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            new Thread(ReloadDtUnits).Start();
            new Thread(InitDtLogs).Start();
        }

        private void dataGridView_Logs_SelectionChanged(object sender, EventArgs e)
        {
            if (dt_logs != null && dt_logs.Rows.Count > 0)
            {
                object rid = this.dataGridView_Logs.CurrentRow.Cells["rowid"].Value;
                if(!(rid is DBNull))
                    this.ShowLog(Convert.ToInt32(rid));
            }
        }
        
    }
}
