namespace Audit
{
    partial class MainFrame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.richTextBox_Time = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.button_TimeGood = new System.Windows.Forms.Button();
            this.button_LogGood = new System.Windows.Forms.Button();
            this.button_LogMiddle = new System.Windows.Forms.Button();
            this.button_LogBad = new System.Windows.Forms.Button();
            this.button_PrevLog = new System.Windows.Forms.Button();
            this.richTextBox_LogCheck = new System.Windows.Forms.RichTextBox();
            this.richTextBox_GraphCheck = new System.Windows.Forms.RichTextBox();
            this.button_GraphMiddle = new System.Windows.Forms.Button();
            this.button_GraphBad = new System.Windows.Forms.Button();
            this.richTextBox_TimeCheck = new System.Windows.Forms.RichTextBox();
            this.button_TimeBad = new System.Windows.Forms.Button();
            this.button_NextLog = new System.Windows.Forms.Button();
            this.button_Output = new System.Windows.Forms.Button();
            this.listView_Logs = new System.Windows.Forms.ListView();
            this.button_Input = new System.Windows.Forms.Button();
            this.richTextBox_Group = new System.Windows.Forms.RichTextBox();
            this.button_GroupGood = new System.Windows.Forms.Button();
            this.button_GroupBad = new System.Windows.Forms.Button();
            this.richTextBox_GroupCheck = new System.Windows.Forms.RichTextBox();
            this.button_GraphCheckHelp = new System.Windows.Forms.Button();
            this.button_LogCheckHelp = new System.Windows.Forms.Button();
            this.pictureBox_Graph = new System.Windows.Forms.PictureBox();
            this.button_GraphGood = new System.Windows.Forms.Button();
            this.label_Group = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.label_Log = new System.Windows.Forms.Label();
            this.label_Graph = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox_Time
            // 
            this.richTextBox_Time.Location = new System.Drawing.Point(207, 166);
            this.richTextBox_Time.Name = "richTextBox_Time";
            this.richTextBox_Time.Size = new System.Drawing.Size(194, 26);
            this.richTextBox_Time.TabIndex = 0;
            this.richTextBox_Time.Text = "起止时间";
            this.richTextBox_Time.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(196, 324);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.Size = new System.Drawing.Size(194, 84);
            this.richTextBox_Log.TabIndex = 0;
            this.richTextBox_Log.Text = "事件记录";
            // 
            // button_TimeGood
            // 
            this.button_TimeGood.Location = new System.Drawing.Point(137, 166);
            this.button_TimeGood.Name = "button_TimeGood";
            this.button_TimeGood.Size = new System.Drawing.Size(49, 44);
            this.button_TimeGood.TabIndex = 2;
            this.button_TimeGood.Text = "对";
            this.button_TimeGood.UseVisualStyleBackColor = true;
            this.button_TimeGood.Click += new System.EventHandler(this.button_TimeGood_Click);
            // 
            // button_LogGood
            // 
            this.button_LogGood.Location = new System.Drawing.Point(137, 327);
            this.button_LogGood.Name = "button_LogGood";
            this.button_LogGood.Size = new System.Drawing.Size(49, 44);
            this.button_LogGood.TabIndex = 2;
            this.button_LogGood.Text = "好";
            this.button_LogGood.UseVisualStyleBackColor = true;
            this.button_LogGood.Click += new System.EventHandler(this.button_LogGood_Click);
            // 
            // button_LogMiddle
            // 
            this.button_LogMiddle.Location = new System.Drawing.Point(396, 314);
            this.button_LogMiddle.Name = "button_LogMiddle";
            this.button_LogMiddle.Size = new System.Drawing.Size(59, 39);
            this.button_LogMiddle.TabIndex = 2;
            this.button_LogMiddle.Text = "中";
            this.button_LogMiddle.UseVisualStyleBackColor = true;
            this.button_LogMiddle.Click += new System.EventHandler(this.button_LogMiddle_Click);
            // 
            // button_LogBad
            // 
            this.button_LogBad.Location = new System.Drawing.Point(396, 369);
            this.button_LogBad.Name = "button_LogBad";
            this.button_LogBad.Size = new System.Drawing.Size(59, 39);
            this.button_LogBad.TabIndex = 2;
            this.button_LogBad.Text = "差";
            this.button_LogBad.UseVisualStyleBackColor = true;
            this.button_LogBad.Click += new System.EventHandler(this.button_LogBad_Click);
            // 
            // button_PrevLog
            // 
            this.button_PrevLog.Location = new System.Drawing.Point(196, 493);
            this.button_PrevLog.Name = "button_PrevLog";
            this.button_PrevLog.Size = new System.Drawing.Size(49, 86);
            this.button_PrevLog.TabIndex = 3;
            this.button_PrevLog.Text = "上一事件(P)";
            this.button_PrevLog.UseVisualStyleBackColor = true;
            // 
            // richTextBox_LogCheck
            // 
            this.richTextBox_LogCheck.Location = new System.Drawing.Point(196, 414);
            this.richTextBox_LogCheck.Name = "richTextBox_LogCheck";
            this.richTextBox_LogCheck.Size = new System.Drawing.Size(194, 51);
            this.richTextBox_LogCheck.TabIndex = 0;
            this.richTextBox_LogCheck.Text = "";
            // 
            // richTextBox_GraphCheck
            // 
            this.richTextBox_GraphCheck.Location = new System.Drawing.Point(672, 459);
            this.richTextBox_GraphCheck.Name = "richTextBox_GraphCheck";
            this.richTextBox_GraphCheck.Size = new System.Drawing.Size(256, 61);
            this.richTextBox_GraphCheck.TabIndex = 0;
            this.richTextBox_GraphCheck.Text = "";
            // 
            // button_GraphMiddle
            // 
            this.button_GraphMiddle.Location = new System.Drawing.Point(728, 404);
            this.button_GraphMiddle.Name = "button_GraphMiddle";
            this.button_GraphMiddle.Size = new System.Drawing.Size(60, 39);
            this.button_GraphMiddle.TabIndex = 2;
            this.button_GraphMiddle.Text = "中";
            this.button_GraphMiddle.UseVisualStyleBackColor = true;
            this.button_GraphMiddle.Click += new System.EventHandler(this.button_GraphMiddle_Click);
            // 
            // button_GraphBad
            // 
            this.button_GraphBad.Location = new System.Drawing.Point(835, 398);
            this.button_GraphBad.Name = "button_GraphBad";
            this.button_GraphBad.Size = new System.Drawing.Size(59, 39);
            this.button_GraphBad.TabIndex = 2;
            this.button_GraphBad.Text = "差";
            this.button_GraphBad.UseVisualStyleBackColor = true;
            this.button_GraphBad.Click += new System.EventHandler(this.button_GraphBad_Click);
            // 
            // richTextBox_TimeCheck
            // 
            this.richTextBox_TimeCheck.Location = new System.Drawing.Point(196, 220);
            this.richTextBox_TimeCheck.Name = "richTextBox_TimeCheck";
            this.richTextBox_TimeCheck.Size = new System.Drawing.Size(194, 51);
            this.richTextBox_TimeCheck.TabIndex = 0;
            this.richTextBox_TimeCheck.Text = "";
            // 
            // button_TimeBad
            // 
            this.button_TimeBad.Location = new System.Drawing.Point(405, 175);
            this.button_TimeBad.Name = "button_TimeBad";
            this.button_TimeBad.Size = new System.Drawing.Size(60, 44);
            this.button_TimeBad.TabIndex = 2;
            this.button_TimeBad.Text = "错";
            this.button_TimeBad.UseVisualStyleBackColor = true;
            this.button_TimeBad.Click += new System.EventHandler(this.button_TimeBad_Click);
            // 
            // button_NextLog
            // 
            this.button_NextLog.Location = new System.Drawing.Point(319, 493);
            this.button_NextLog.Name = "button_NextLog";
            this.button_NextLog.Size = new System.Drawing.Size(49, 86);
            this.button_NextLog.TabIndex = 3;
            this.button_NextLog.Text = "下一事件(N)";
            this.button_NextLog.UseVisualStyleBackColor = true;
            this.button_NextLog.Click += new System.EventHandler(this.button9_Click);
            // 
            // button_Output
            // 
            this.button_Output.Location = new System.Drawing.Point(12, 493);
            this.button_Output.Name = "button_Output";
            this.button_Output.Size = new System.Drawing.Size(49, 86);
            this.button_Output.TabIndex = 3;
            this.button_Output.Text = "产出报表";
            this.button_Output.UseVisualStyleBackColor = true;
            this.button_Output.Click += new System.EventHandler(this.button9_Click);
            // 
            // listView_Logs
            // 
            this.listView_Logs.Location = new System.Drawing.Point(12, 85);
            this.listView_Logs.Name = "listView_Logs";
            this.listView_Logs.Size = new System.Drawing.Size(97, 286);
            this.listView_Logs.TabIndex = 4;
            this.listView_Logs.UseCompatibleStateImageBehavior = false;
            this.listView_Logs.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button_Input
            // 
            this.button_Input.Location = new System.Drawing.Point(12, 29);
            this.button_Input.Name = "button_Input";
            this.button_Input.Size = new System.Drawing.Size(96, 38);
            this.button_Input.TabIndex = 5;
            this.button_Input.Text = "按指定规则生成事件集";
            this.button_Input.UseVisualStyleBackColor = true;
            this.button_Input.Click += new System.EventHandler(this.button_Input_Click);
            // 
            // richTextBox_Group
            // 
            this.richTextBox_Group.Location = new System.Drawing.Point(196, 39);
            this.richTextBox_Group.Name = "richTextBox_Group";
            this.richTextBox_Group.Size = new System.Drawing.Size(194, 29);
            this.richTextBox_Group.TabIndex = 0;
            this.richTextBox_Group.Text = "事件分类";
            // 
            // button_GroupGood
            // 
            this.button_GroupGood.Location = new System.Drawing.Point(137, 23);
            this.button_GroupGood.Name = "button_GroupGood";
            this.button_GroupGood.Size = new System.Drawing.Size(49, 44);
            this.button_GroupGood.TabIndex = 2;
            this.button_GroupGood.Text = "对";
            this.button_GroupGood.UseVisualStyleBackColor = true;
            this.button_GroupGood.Click += new System.EventHandler(this.button_GroupGood_Click);
            // 
            // button_GroupBad
            // 
            this.button_GroupBad.Location = new System.Drawing.Point(405, 39);
            this.button_GroupBad.Name = "button_GroupBad";
            this.button_GroupBad.Size = new System.Drawing.Size(49, 44);
            this.button_GroupBad.TabIndex = 2;
            this.button_GroupBad.Text = "错";
            this.button_GroupBad.UseVisualStyleBackColor = true;
            this.button_GroupBad.Click += new System.EventHandler(this.button_GroupBad_Click);
            // 
            // richTextBox_GroupCheck
            // 
            this.richTextBox_GroupCheck.Location = new System.Drawing.Point(196, 85);
            this.richTextBox_GroupCheck.Name = "richTextBox_GroupCheck";
            this.richTextBox_GroupCheck.Size = new System.Drawing.Size(205, 55);
            this.richTextBox_GroupCheck.TabIndex = 0;
            this.richTextBox_GroupCheck.Text = "";
            this.richTextBox_GroupCheck.TextChanged += new System.EventHandler(this.richTextBox_GroupCheck_TextChanged);
            // 
            // button_GraphCheckHelp
            // 
            this.button_GraphCheckHelp.Location = new System.Drawing.Point(900, 526);
            this.button_GraphCheckHelp.Name = "button_GraphCheckHelp";
            this.button_GraphCheckHelp.Size = new System.Drawing.Size(28, 20);
            this.button_GraphCheckHelp.TabIndex = 6;
            this.button_GraphCheckHelp.Text = "?";
            this.button_GraphCheckHelp.UseVisualStyleBackColor = true;
            // 
            // button_LogCheckHelp
            // 
            this.button_LogCheckHelp.Location = new System.Drawing.Point(405, 444);
            this.button_LogCheckHelp.Name = "button_LogCheckHelp";
            this.button_LogCheckHelp.Size = new System.Drawing.Size(28, 20);
            this.button_LogCheckHelp.TabIndex = 6;
            this.button_LogCheckHelp.Text = "?";
            this.button_LogCheckHelp.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Graph
            // 
            this.pictureBox_Graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Graph.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Graph.Image")));
            this.pictureBox_Graph.Location = new System.Drawing.Point(560, 15);
            this.pictureBox_Graph.Name = "pictureBox_Graph";
            this.pictureBox_Graph.Size = new System.Drawing.Size(334, 377);
            this.pictureBox_Graph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Graph.TabIndex = 1;
            this.pictureBox_Graph.TabStop = false;
            this.pictureBox_Graph.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // button_GraphGood
            // 
            this.button_GraphGood.Location = new System.Drawing.Point(615, 398);
            this.button_GraphGood.Name = "button_GraphGood";
            this.button_GraphGood.Size = new System.Drawing.Size(49, 44);
            this.button_GraphGood.TabIndex = 2;
            this.button_GraphGood.Text = "好";
            this.button_GraphGood.UseVisualStyleBackColor = true;
            this.button_GraphGood.Click += new System.EventHandler(this.button_GraphGood_Click);
            // 
            // label_Group
            // 
            this.label_Group.AutoSize = true;
            this.label_Group.Location = new System.Drawing.Point(135, 88);
            this.label_Group.Name = "label_Group";
            this.label_Group.Size = new System.Drawing.Size(53, 24);
            this.label_Group.TabIndex = 7;
            this.label_Group.Text = "事件分类\r\n审核意见";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Location = new System.Drawing.Point(135, 236);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(53, 24);
            this.label_Time.TabIndex = 7;
            this.label_Time.Text = "起止时间\r\n审核意见";
            // 
            // label_Log
            // 
            this.label_Log.AutoSize = true;
            this.label_Log.Location = new System.Drawing.Point(137, 425);
            this.label_Log.Name = "label_Log";
            this.label_Log.Size = new System.Drawing.Size(53, 24);
            this.label_Log.TabIndex = 7;
            this.label_Log.Text = "事件记录\r\n审核意见";
            // 
            // label_Graph
            // 
            this.label_Graph.AutoSize = true;
            this.label_Graph.Location = new System.Drawing.Point(611, 476);
            this.label_Graph.Name = "label_Graph";
            this.label_Graph.Size = new System.Drawing.Size(53, 24);
            this.label_Graph.TabIndex = 7;
            this.label_Graph.Text = "图件标注\r\n审核意见";
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(149, 587);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(77, 12);
            this.label_Status.TabIndex = 8;
            this.label_Status.Text = "label_Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 608);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_Graph);
            this.Controls.Add(this.label_Log);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.label_Group);
            this.Controls.Add(this.pictureBox_Graph);
            this.Controls.Add(this.button_GraphGood);
            this.Controls.Add(this.button_LogCheckHelp);
            this.Controls.Add(this.button_GraphCheckHelp);
            this.Controls.Add(this.button_Input);
            this.Controls.Add(this.listView_Logs);
            this.Controls.Add(this.button_Output);
            this.Controls.Add(this.button_NextLog);
            this.Controls.Add(this.button_PrevLog);
            this.Controls.Add(this.button_GraphBad);
            this.Controls.Add(this.button_LogBad);
            this.Controls.Add(this.button_GraphMiddle);
            this.Controls.Add(this.button_LogMiddle);
            this.Controls.Add(this.button_LogGood);
            this.Controls.Add(this.button_TimeBad);
            this.Controls.Add(this.button_GroupBad);
            this.Controls.Add(this.button_GroupGood);
            this.Controls.Add(this.button_TimeGood);
            this.Controls.Add(this.richTextBox_TimeCheck);
            this.Controls.Add(this.richTextBox_GraphCheck);
            this.Controls.Add(this.richTextBox_LogCheck);
            this.Controls.Add(this.richTextBox_Log);
            this.Controls.Add(this.richTextBox_GroupCheck);
            this.Controls.Add(this.richTextBox_Group);
            this.Controls.Add(this.richTextBox_Time);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Time;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.Button button_TimeGood;
        private System.Windows.Forms.Button button_LogGood;
        private System.Windows.Forms.Button button_LogMiddle;
        private System.Windows.Forms.Button button_LogBad;
        private System.Windows.Forms.Button button_PrevLog;
        private System.Windows.Forms.RichTextBox richTextBox_LogCheck;
        private System.Windows.Forms.RichTextBox richTextBox_GraphCheck;
        private System.Windows.Forms.Button button_GraphMiddle;
        private System.Windows.Forms.Button button_GraphBad;
        private System.Windows.Forms.RichTextBox richTextBox_TimeCheck;
        private System.Windows.Forms.Button button_TimeBad;
        private System.Windows.Forms.Button button_NextLog;
        private System.Windows.Forms.Button button_Output;
        private System.Windows.Forms.ListView listView_Logs;
        private System.Windows.Forms.Button button_Input;
        private System.Windows.Forms.RichTextBox richTextBox_Group;
        private System.Windows.Forms.Button button_GroupGood;
        private System.Windows.Forms.Button button_GroupBad;
        private System.Windows.Forms.RichTextBox richTextBox_GroupCheck;
        private System.Windows.Forms.Button button_GraphCheckHelp;
        private System.Windows.Forms.Button button_LogCheckHelp;
        private System.Windows.Forms.PictureBox pictureBox_Graph;
        private System.Windows.Forms.Button button_GraphGood;
        private System.Windows.Forms.Label label_Group;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label_Log;
        private System.Windows.Forms.Label label_Graph;
        private System.Windows.Forms.Label label_Status;
    }
}

