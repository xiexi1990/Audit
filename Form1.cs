using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audit
{
    public delegate void singleValueChanging(int new_value);

    public partial class Form1 : Form
    {
        public ValueBox vb = new ValueBox();
        private Button[] score_group_buttons = new Button[2], 
            score_time_buttons = new Button[2], 
            score_graph_buttons = new Button[3], 
            score_log_buttons = new Button[3];
        private Control[] ctrl_list = new Control[29];
        public Form1()
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

            if (true)
            {
                this.richTextBox_GroupCheck.Text = "对事件分类的审核意见";
                this.richTextBox_TimeCheck.Text = "对起止时间的审核意见";
                this.richTextBox_LogCheck.Text = "对事件记录的审核意见";
                this.richTextBox_GraphCheck.Text = "对图件的审核意见";
            }

            this.FillCtrlList();
            this.Form1_Resize(null, null);
        }
        private void OnScoreGroupChanging(int new_value)
        {
            if (vb.score_group >= 0 && vb.score_group <= 1)
            {
                score_group_buttons[vb.score_group].BackColor = SystemColors.Control;
                score_group_buttons[vb.score_group].UseVisualStyleBackColor = true;
            }
            score_group_buttons[new_value].BackColor = Color.PaleVioletRed;   
        }
        private void OnScoreTimeChanging(int new_value)
        {
            if (vb.score_time >= 0 && vb.score_time <= 1)
            {
                score_time_buttons[vb.score_time].BackColor = SystemColors.Control;
                score_time_buttons[vb.score_time].UseVisualStyleBackColor = true;
            }
            score_time_buttons[new_value].BackColor = Color.PaleVioletRed;
        }
        private void OnScoreGraphChanging(int new_value)
        {
            if (vb.score_graph >= 0 && vb.score_graph <= 2)
            {
                score_graph_buttons[vb.score_graph].BackColor = SystemColors.Control;
                score_graph_buttons[vb.score_graph].UseVisualStyleBackColor = true;
            }
            score_graph_buttons[new_value].BackColor = Color.PaleVioletRed;   
        }
        private void OnScoreLogChanging(int new_value)
        {
            if (vb.score_log >= 0 && vb.score_log <= 2)
            {
                score_log_buttons[vb.score_log].BackColor = SystemColors.Control;
                score_log_buttons[vb.score_log].UseVisualStyleBackColor = true;
            }
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

        private void button_TimeGood_Click(object sender, EventArgs e)
        {
            vb.score_time = 0;
        }

        private void button_TimeBad_Click(object sender, EventArgs e)
        {
            vb.score_time = 1;
        }

        private void button_GraphGood_Click(object sender, EventArgs e)
        {
            vb.score_graph = 0;
        }

        private void button_GraphMiddle_Click(object sender, EventArgs e)
        {
            vb.score_graph = 1;
        }

        private void button_GraphBad_Click(object sender, EventArgs e)
        {
            vb.score_graph = 2;
        }

        private void button_LogGood_Click(object sender, EventArgs e)
        {
            vb.score_log = 0;
        }

        private void button_LogMiddle_Click(object sender, EventArgs e)
        {
            vb.score_log = 1;
        }

        private void button_LogBad_Click(object sender, EventArgs e)
        {
            vb.score_log = 2;
        }

        private void button_GroupGood_Click(object sender, EventArgs e)
        {
            vb.score_group = 0;
        }

        private void button_GroupBad_Click(object sender, EventArgs e)
        {
            vb.score_group = 1;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
           
            Rectangle[] rlist = this.GetResizeRectList(new Point(0,0), this.Size);
            for (int i = 0; i < this.ctrl_list.GetLength(0); i++)
            {
                this.ctrl_list[i].Location = rlist[i].Location;
                this.ctrl_list[i].Size = rlist[i].Size;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        public Rectangle[] GetResizeRectList(Point lefttop, Size siz)
        {
            double[] v = new double[10] { 0.02, 0.2, 0.22, 0.27, 0.28, 0.42, 0.43, 0.48, 0.5, 0.98 };
            double[] h = new double[14] { 0.02, 0.07, 0.09, 0.19, 0.21, 0.26, 0.28, 0.38, 0.4, 0.6, 0.62, 0.83, 0.84, 0.94 };
            
            Rectangle[] rl = new Rectangle[29];
            RectHelper rh = new RectHelper();
            rh.lefttop = lefttop;
            rh.siz = siz;
            Size sizbtn = rh.GetRectByProp(v[2], h[2], v[3], h[3]).Size;
            Size sizlabel = new Size(50, 20);
            Size sizhlp = new Size(20, 20);
            Size sizsysbtn = rh.GetRectByProp(rh.GetRectByProp(v[2], h[2], v[7], h[3]), 0, 0, 0.4, 0.7).Size;

            rl[0] = rh.GetRectByProp(v[0], h[0], v[1], h[1]);
            rl[1] = rh.GetRectByProp(v[0], h[2], v[1], h[11]);
            rl[2] = rh.GetCenterRect(rh.GetRectByProp(v[0], h[12], v[1], h[13]),sizsysbtn);
            
           

            rl[3] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[0], v[3], h[3]), sizbtn, RectHelper._ALIGNTOP);
            rl[4] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[2], v[3], h[3]), sizlabel, RectHelper._ALIGNRIGHT);

            rl[5] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[4], v[3], h[7]), sizbtn, RectHelper._ALIGNTOP);
            rl[6] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[6], v[3], h[7]), sizlabel, RectHelper._ALIGNRIGHT);

            rl[7] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[8], v[3], h[11]), sizbtn, RectHelper._ALIGNCENTER);
            rl[8] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[10], v[3], h[11]), sizlabel, RectHelper._ALIGNRIGHT);

            
            rl[9] = rh.GetRectByProp(v[4], h[0], v[5], h[1]);
            rl[10] = rh.GetRectByProp(v[4], h[2], v[5], h[3]);
            rl[11] = rh.GetRectByProp(v[4], h[4], v[5], h[5]);
            rl[12] = rh.GetRectByProp(v[4], h[6], v[5], h[7]);
            rl[13] = rh.GetRectByProp(v[4], h[8], v[5], h[9]);
            rl[14] = rh.GetRectByProp(v[4], h[10], v[5], h[11]);


            rl[15] = rh.GetAlignRect(rh.GetRectByProp(v[6], h[0], v[7], h[3]), sizbtn, RectHelper._ALIGNTOP);
            rl[16] = rh.GetAlignRect(rh.GetRectByProp(v[6], h[4], v[7], h[7]), sizbtn, RectHelper._ALIGNTOP);

            rl[17] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[6], h[8], v[7], h[11]), 0, 0, 1, 0.45),sizbtn, RectHelper._ALIGNBOTTOM);
            rl[18] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[6], h[8], v[7], h[11]), 0, 0.55, 1, 1), sizbtn, RectHelper._ALIGNTOP);
   
            rl[19] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[10], v[3], h[11]),sizhlp, RectHelper._ALIGNBOTTOM|RectHelper._ALIGNRIGHT);

            rl[20] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[2], h[12], v[7], h[13]), 0, 0, 0.5, 1), sizsysbtn, RectHelper._ALIGNCENTER);
            rl[21] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[2], h[12], v[7], h[13]), 0.5, 0, 1, 1), sizsysbtn, RectHelper._ALIGNCENTER);
                 

            rl[22] = rh.GetRectByProp(v[8], h[0], v[9], h[11]);

            rl[23] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(rh.GetRectByProp(v[8], h[12], v[9], h[13]),2/3.0,0,1,1),0,0,1/3.0,1), sizbtn);
            rl[24] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(rh.GetRectByProp(v[8], h[12], v[9], h[13]), 2 / 3.0, 0, 1, 1), 1/3.0, 0, 2 / 3.0, 1), sizbtn);
            rl[25] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(rh.GetRectByProp(v[8], h[12], v[9], h[13]), 2 / 3.0, 0, 1, 1), 2/3.0, 0, 1, 1), sizbtn);
        
        

            rl[26] = rh.GetRectByProp(rh.GetRectByProp(v[8], h[12], v[9], h[13]),1/6.0,0,2/3.0,1);
            rl[27] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[8], h[12], v[9], h[13]), 0,0,0.9/6.0,1), sizlabel, RectHelper._ALIGNRIGHT);
            rl[28] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[8], h[12], v[9], h[13]), 0, 0, 0.9 / 6.0, 1), sizhlp, RectHelper._ALIGNRIGHT|RectHelper._ALIGNBOTTOM);

            return rl;
        }
        private void FillCtrlList()
        {
            ctrl_list[0] = button_Input;
            ctrl_list[1] = listView_Logs;
            ctrl_list[2] = button_Output;
            ctrl_list[3] = button_GroupGood;
            ctrl_list[4] = label_Group;
            ctrl_list[5] = button_TimeGood;
            ctrl_list[6] = label_Time;
            ctrl_list[7] = button_LogGood;
            ctrl_list[8] = label_Log;
            
            ctrl_list[9] = richTextBox_Group;
            ctrl_list[10] = richTextBox_GroupCheck;
            ctrl_list[11] = richTextBox_Time;
            ctrl_list[12] = richTextBox_TimeCheck;
            ctrl_list[13] = richTextBox_Log;
            ctrl_list[14] = richTextBox_LogCheck;
            ctrl_list[15] = button_GroupBad;
            ctrl_list[16] = button_TimeBad;
            ctrl_list[17] = button_LogMiddle;
            ctrl_list[18] = button_LogBad;
            ctrl_list[19] = button_LogCheckHelp;
            ctrl_list[20] = button_PrevLog;
            ctrl_list[21] = button_NextLog;
            ctrl_list[22] = pictureBox_Graph;
            ctrl_list[23] = button_GraphGood;
            ctrl_list[24] = button_GraphMiddle;
            ctrl_list[25] = button_GraphBad;
            ctrl_list[26] = richTextBox_GraphCheck;
            ctrl_list[27] = label_Graph;
            ctrl_list[28] = button_GraphCheckHelp;
        }

        private void richTextBox_GroupCheck_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
