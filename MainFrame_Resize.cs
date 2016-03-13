using System;
using System.Drawing;
using System.Windows.Forms;

namespace Audit
{
    public partial class MainFrame : Form
    {
        public Rectangle[] GetResizeRectList(Point lefttop, Size siz)
        {
            double[] v = new double[10] { 0.01, 0.21, 0.22, 0.27, 0.28, 0.45, 0.46, 0.51, 0.53, 0.98 };
            double[] h = new double[16] { 0.02, 0.04, 0.09, 0.11, 0.19, 0.21, 0.27, 0.29, 0.37, 0.39, 0.68, 0.7, 0.82, 0.83, 0.92, 0.98 };

            Rectangle[] rl = new Rectangle[45];
            RectHelper rh = new RectHelper();
            rh.lefttop = lefttop;
            rh.siz = siz;
            Size sizbtn = rh.GetRectByProp(v[2], h[3], v[3], h[4]).Size;
            Size sizlabel = new Size(50, 20);
            Size sizhlp = new Size(20, 20);
            Size sizsysbtn = rh.GetRectByProp(0, 0, 0.07, 0.06).Size;
            Size sizmidbtns = rh.GetRectByProp(0, 0, 0.07, 0.06).Size;
            Size sizgsetbtns = rh.GetRectByProp(0, 0, 0.07, 0.08).Size;

            rl[0] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(v[0], h[0], v[1], h[2]), 0, 0, 0.5, 1), sizsysbtn);
            
            rl[1] = rh.GetRectByProp(v[0], h[3], v[1], 0.74);
            rl[2] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(v[0], h[0], v[1], h[2]), 0.5, 0, 1, 1), sizsysbtn);

            rl[34] = rh.GetCenterRect(rh.GetRectByProp(v[0], 0.76, v[1], 0.8), sizsysbtn);

            rl[3] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[1], v[3], h[4]), sizbtn, RectHelper._ALIGNTOP);
            rl[4] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[3], v[3], h[4]), sizlabel, RectHelper._ALIGNRIGHT);

            rl[5] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[5], v[3], h[8]), sizbtn, RectHelper._ALIGNTOP);
            rl[6] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[7], v[3], h[8]), sizlabel, RectHelper._ALIGNRIGHT);

            rl[7] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[9], v[3], h[12]), sizbtn, RectHelper._ALIGNCENTER);
            rl[8] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[11], v[3], h[12]), sizlabel, RectHelper._ALIGNRIGHT);

            rl[9] = rh.GetRectByProp(v[4], h[1], v[5], h[2]);
            rl[10] = rh.GetRectByProp(v[4], h[3], v[5], h[4]);
            rl[11] = rh.GetRectByProp(v[4], h[5], v[5], h[6]);
            rl[12] = rh.GetRectByProp(v[4], h[7], v[5], h[8]);
            rl[13] = rh.GetRectByProp(v[4], h[9], v[5], h[10]);
            rl[14] = rh.GetRectByProp(v[4], h[11], v[5], h[12]);

            rl[15] = rh.GetAlignRect(rh.GetRectByProp(v[6], h[1], v[7], h[4]), sizbtn, RectHelper._ALIGNTOP);
            rl[16] = rh.GetAlignRect(rh.GetRectByProp(v[6], h[5], v[7], h[8]), sizbtn, RectHelper._ALIGNTOP);

            rl[17] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[6], h[9], v[7], h[12]), 0, 0, 1, 0.45), sizbtn, RectHelper._ALIGNBOTTOM);
            rl[18] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[6], h[9], v[7], h[12]), 0, 0.55, 1, 1), sizbtn, RectHelper._ALIGNTOP);

            rl[19] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[11], v[3], h[12]), sizhlp, RectHelper._ALIGNBOTTOM | RectHelper._ALIGNRIGHT);


            rl[20] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[2], h[13], v[7], h[14]), 0, 0, 1/4.0, 1), sizmidbtns, RectHelper._ALIGNCENTER);
            rl[21] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[2], h[13], v[7], h[14]), 1 / 4.0, 0, 2 / 4.0, 1), sizmidbtns, RectHelper._ALIGNCENTER);


            rl[22] = rh.GetRectByProp(v[8], h[1], v[9], h[12]);

            rl[23] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(rh.GetRectByProp(v[8], h[13], v[9], h[14]), 0.6, 0, 1, 1), 0, 0, 1 / 3.0, 1), sizbtn);
            rl[24] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(rh.GetRectByProp(v[8], h[13], v[9], h[14]), 0.6, 0, 1, 1), 1 / 3.0, 0, 2 / 3.0, 1), sizbtn);
            rl[25] = rh.GetCenterRect(rh.GetRectByProp(rh.GetRectByProp(rh.GetRectByProp(v[8], h[13], v[9], h[14]), 0.6, 0, 1, 1), 2 / 3.0, 0, 1, 1), sizbtn);



            rl[26] = rh.GetRectByProp(rh.GetRectByProp(v[8], h[13], v[9], h[14]), 1 / 6.0, 0, 0.6, 1);
            rl[27] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[8], h[13], v[9], h[14]), 0, 0, 0.9 / 6.0, 1), sizlabel, RectHelper._ALIGNRIGHT);
            rl[28] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[8], h[13], v[9], h[14]), 0, 0, 0.9 / 6.0, 1), sizhlp, RectHelper._ALIGNRIGHT | RectHelper._ALIGNBOTTOM);
            rl[29] = rh.GetRectByProp(v[0], h[13], v[1], h[14]);
            rl[30] = rh.GetCenterRect(rh.GetRectByProp(v[2], h[0], v[9], h[1]), new Size(200,20));
            rl[33] = rh.GetAlignRect(rh.GetRectByProp(v[2], h[0], v[6], h[1]), new Size(50, 20), 0);

            rl[31] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[2], h[13], v[7], h[14]), 2 / 4.0, 0, 3 / 4.0, 1), sizmidbtns, RectHelper._ALIGNCENTER);
            rl[32] = rh.GetAlignRect(rh.GetRectByProp(rh.GetRectByProp(v[2], h[13], v[7], h[14]), 3 / 4.0, 0, 4 / 4.0, 1), sizmidbtns, RectHelper._ALIGNCENTER);

            if (GSET)
            {
                rl[35] = rh.GetRectByProp(v[2], h[0], 0.4, h[10]);
                rl[44] = rh.GetAlignRect(rh.GetRectByProp(v[2], 0.7, 0.4, 0.72), sizlabel, RectHelper._ALIGNLEFT);
                rl[43] = rh.GetRectByProp(v[2], 0.72, 0.4, h[12]);
                rl[22] = rh.GetRectByProp(0.41, h[0], 0.82, h[12]);
                Rectangle rightmost = rh.GetRectByProp(0.83, 0.64, 0.98, 0.92);
                rl[20] = rh.GetCenterRect(rh.GetRectByProp(rightmost, 0, 0, 1, 1 / 4.0), sizmidbtns);
                rl[21] = rh.GetCenterRect(rh.GetRectByProp(rightmost, 0, 1 / 4.0, 1, 2 / 4.0), sizmidbtns);
                rl[31] = rh.GetCenterRect(rh.GetRectByProp(rightmost, 0, 2 / 4.0, 1, 3 / 4.0), sizmidbtns);
                rl[32] = rh.GetCenterRect(rh.GetRectByProp(rightmost, 0, 3 / 4.0, 1, 4 / 4.0), sizmidbtns);
                Rectangle downmost = rh.GetRectByProp(v[2], h[13], 0.84, h[14]);
                rl[36] = rh.GetAlignRect(rh.GetRectByProp(downmost, 0, 0, 1 / 8.0, 1), sizgsetbtns, RectHelper._ALIGNCENTER);
                rl[37] = rh.GetAlignRect(rh.GetRectByProp(downmost, 1 / 8.0, 0, 2 / 8.0, 1), sizgsetbtns, RectHelper._ALIGNCENTER);
                rl[38] = rh.GetAlignRect(rh.GetRectByProp(downmost, 2 / 8.0, 0, 3 / 8.0, 1), sizgsetbtns, RectHelper._ALIGNCENTER);
                rl[39] = rh.GetAlignRect(rh.GetRectByProp(downmost, 3 / 8.0, 0, 4 / 8.0, 1), sizgsetbtns, RectHelper._ALIGNCENTER);
                rl[40] = rh.GetAlignRect(rh.GetRectByProp(downmost, 4 / 8.0, 0, 5 / 8.0, 1), sizgsetbtns, RectHelper._ALIGNCENTER);
                rl[41] = rh.GetAlignRect(rh.GetRectByProp(downmost, 6 / 8.0, 0, 7 / 8.0, 1), sizgsetbtns, RectHelper._ALIGNCENTER);
                rl[42] = rh.GetAlignRect(rh.GetRectByProp(downmost, 7 / 8.0, 0, 8 / 8.0, 1), sizgsetbtns, RectHelper._ALIGNCENTER);
                {
                    Rectangle right1 = rh.GetRectByProp(0.83, 0.02, 0.98, 0.15);
                    Rectangle right1up = rh.GetRectByProp(right1, 0, 0, 1, 0.5);
                    Rectangle right1down = rh.GetRectByProp(right1, 0, 0.5, 1, 1);
                    Size rightsiz = rh.GetRectByProp(right1up, 0, 0, 0.3, 0.8).Size;
                    rl[4] = rh.GetAlignRect(right1down, sizlabel, RectHelper._ALIGNLEFT);
                    rl[3] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNLEFT);
                    rl[15] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNRIGHT);
                    rl[10] = rh.GetRectByProp(right1down, 0.3, 0, 1, 1);
                }

                {
                    Rectangle right1 = rh.GetRectByProp(0.83, 0.17, 0.98, 0.3);
                    Rectangle right1up = rh.GetRectByProp(right1, 0, 0, 1, 0.5);
                    Rectangle right1down = rh.GetRectByProp(right1, 0, 0.5, 1, 1);
                    Size rightsiz = rh.GetRectByProp(right1up, 0, 0, 0.3, 0.8).Size;
                    rl[6] = rh.GetAlignRect(right1down, sizlabel, RectHelper._ALIGNLEFT);
                    rl[5] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNLEFT);
                    rl[16] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNRIGHT);
                    rl[12] = rh.GetRectByProp(right1down, 0.3, 0, 1, 1);
                }

                {
                    Rectangle right1 = rh.GetRectByProp(0.83, 0.32, 0.98, 0.45);
                    Rectangle right1up = rh.GetRectByProp(right1, 0, 0, 1, 0.5);
                    Rectangle right1down = rh.GetRectByProp(right1, 0, 0.5, 1, 1);
                    Size rightsiz = rh.GetRectByProp(right1up, 0, 0, 0.3, 0.8).Size;
                    rl[8] = rh.GetAlignRect(right1down, sizlabel, RectHelper._ALIGNLEFT);
                    rl[7] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNLEFT);
                    rl[17] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNCENTER);
                    rl[18] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNRIGHT);
                    rl[14] = rh.GetRectByProp(right1down, 0.3, 0, 1, 1);
                }

                {
                    Rectangle right1 = rh.GetRectByProp(0.83, 0.47, 0.98, 0.6);
                    Rectangle right1up = rh.GetRectByProp(right1, 0, 0, 1, 0.5);
                    Rectangle right1down = rh.GetRectByProp(right1, 0, 0.5, 1, 1);
                    Size rightsiz = rh.GetRectByProp(right1up, 0, 0, 0.3, 0.8).Size;
                    rl[27] = rh.GetAlignRect(right1down, sizlabel, RectHelper._ALIGNLEFT);
                    rl[23] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNLEFT);
                    rl[24] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNCENTER);
                    rl[25] = rh.GetAlignRect(right1up, rightsiz, RectHelper._ALIGNRIGHT);
                    rl[26] = rh.GetRectByProp(right1down, 0.3, 0, 1, 1);
                }

            }
            
            return rl;
        }
        private void FillCtrlList()
        {
            ctrl_list[0] = button_Input;
            ctrl_list[1] = dataGridView_Logs;
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
            ctrl_list[29] = richTextBox_Status;
            ctrl_list[30] = label_LogInfo;
            ctrl_list[31] = button_ClearScore;
            ctrl_list[32] = button_AllGood;
            ctrl_list[33] = checkBox_Postpone;
            ctrl_list[34] = button_ClearDTLogs;

            ctrl_list[35] = richTextBox_WholeInfo;
            ctrl_list[36] = button_GSet0;
            ctrl_list[37] = button_GSet1;
            ctrl_list[38] = button_GSet2;
            ctrl_list[39] = button_GSet3;
            ctrl_list[40] = button_GSet4;
            ctrl_list[41] = button_GSetClass1;
            ctrl_list[42] = button_GSetClass0;
            ctrl_list[43] = richTextBox_GSetComments;
            ctrl_list[44] = label_GSetComments;

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Rectangle[] rlist = this.GetResizeRectList(new Point(0, menuStrip1.Height), new Size(this.Size.Width, this.Size.Height - menuStrip1.Height));
            for (int i = 0; i < this.ctrl_list.GetLength(0); i++)
            {
                this.ctrl_list[i].Location = rlist[i].Location;
                this.ctrl_list[i].Size = rlist[i].Size;
            }
            if (pictureBox_Graph.Image != null)
            {
                if (pictureBox_Graph.Height >= pictureBox_Graph.Image.Height && pictureBox_Graph.Width >= pictureBox_Graph.Image.Width)
                {
                    pictureBox_Graph.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    pictureBox_Graph.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}