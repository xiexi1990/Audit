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
            this.components = new System.ComponentModel.Container();
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
            this.dataGridView_Logs = new System.Windows.Forms.DataGridView();
            this.backgroundWorker_LogFetcher = new System.ComponentModel.BackgroundWorker();
            this.richTextBox_Status = new System.Windows.Forms.RichTextBox();
            this.label_LogInfo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_PageWithAlt = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_AutoGood = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_AutoCompletionLimit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ReadSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.button_ClearScore = new System.Windows.Forms.Button();
            this.listBox_Sentences = new System.Windows.Forms.ListBox();
            this.button_AllGood = new System.Windows.Forms.Button();
            this.timer_ReSelect = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker_DTAccessor = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_ReportWriter = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_Time
            // 
            this.richTextBox_Time.Location = new System.Drawing.Point(207, 166);
            this.richTextBox_Time.Name = "richTextBox_Time";
            this.richTextBox_Time.ReadOnly = true;
            this.richTextBox_Time.Size = new System.Drawing.Size(194, 26);
            this.richTextBox_Time.TabIndex = 0;
            this.richTextBox_Time.TabStop = false;
            this.richTextBox_Time.Text = "起止时间";
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(196, 324);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.ReadOnly = true;
            this.richTextBox_Log.Size = new System.Drawing.Size(194, 84);
            this.richTextBox_Log.TabIndex = 0;
            this.richTextBox_Log.TabStop = false;
            this.richTextBox_Log.Text = "事件记录";
            // 
            // button_TimeGood
            // 
            this.button_TimeGood.Location = new System.Drawing.Point(137, 166);
            this.button_TimeGood.Name = "button_TimeGood";
            this.button_TimeGood.Size = new System.Drawing.Size(49, 44);
            this.button_TimeGood.TabIndex = 6;
            this.button_TimeGood.Text = "对";
            this.button_TimeGood.UseVisualStyleBackColor = true;
            this.button_TimeGood.Click += new System.EventHandler(this.button_TimeGood_Click);
            // 
            // button_LogGood
            // 
            this.button_LogGood.Location = new System.Drawing.Point(137, 327);
            this.button_LogGood.Name = "button_LogGood";
            this.button_LogGood.Size = new System.Drawing.Size(49, 44);
            this.button_LogGood.TabIndex = 8;
            this.button_LogGood.Text = "好";
            this.button_LogGood.UseVisualStyleBackColor = true;
            this.button_LogGood.Click += new System.EventHandler(this.button_LogGood_Click);
            // 
            // button_LogMiddle
            // 
            this.button_LogMiddle.Location = new System.Drawing.Point(396, 314);
            this.button_LogMiddle.Name = "button_LogMiddle";
            this.button_LogMiddle.Size = new System.Drawing.Size(59, 39);
            this.button_LogMiddle.TabIndex = 9;
            this.button_LogMiddle.Text = "中";
            this.button_LogMiddle.UseVisualStyleBackColor = true;
            this.button_LogMiddle.Click += new System.EventHandler(this.button_LogMiddle_Click);
            // 
            // button_LogBad
            // 
            this.button_LogBad.Location = new System.Drawing.Point(396, 369);
            this.button_LogBad.Name = "button_LogBad";
            this.button_LogBad.Size = new System.Drawing.Size(59, 39);
            this.button_LogBad.TabIndex = 10;
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
            this.button_PrevLog.TabStop = false;
            this.button_PrevLog.Text = "上一事件(PageUp)";
            this.button_PrevLog.UseVisualStyleBackColor = true;
            this.button_PrevLog.Click += new System.EventHandler(this.button_PrevLog_Click);
            // 
            // richTextBox_LogCheck
            // 
            this.richTextBox_LogCheck.Location = new System.Drawing.Point(196, 414);
            this.richTextBox_LogCheck.Name = "richTextBox_LogCheck";
            this.richTextBox_LogCheck.Size = new System.Drawing.Size(194, 51);
            this.richTextBox_LogCheck.TabIndex = 2;
            this.richTextBox_LogCheck.Text = "";
            // 
            // richTextBox_GraphCheck
            // 
            this.richTextBox_GraphCheck.Location = new System.Drawing.Point(672, 459);
            this.richTextBox_GraphCheck.Name = "richTextBox_GraphCheck";
            this.richTextBox_GraphCheck.Size = new System.Drawing.Size(256, 61);
            this.richTextBox_GraphCheck.TabIndex = 3;
            this.richTextBox_GraphCheck.Text = "";
            // 
            // button_GraphMiddle
            // 
            this.button_GraphMiddle.Location = new System.Drawing.Point(728, 404);
            this.button_GraphMiddle.Name = "button_GraphMiddle";
            this.button_GraphMiddle.Size = new System.Drawing.Size(60, 39);
            this.button_GraphMiddle.TabIndex = 12;
            this.button_GraphMiddle.Text = "中";
            this.button_GraphMiddle.UseVisualStyleBackColor = true;
            this.button_GraphMiddle.Click += new System.EventHandler(this.button_GraphMiddle_Click);
            // 
            // button_GraphBad
            // 
            this.button_GraphBad.Location = new System.Drawing.Point(835, 398);
            this.button_GraphBad.Name = "button_GraphBad";
            this.button_GraphBad.Size = new System.Drawing.Size(59, 39);
            this.button_GraphBad.TabIndex = 13;
            this.button_GraphBad.Text = "差";
            this.button_GraphBad.UseVisualStyleBackColor = true;
            this.button_GraphBad.Click += new System.EventHandler(this.button_GraphBad_Click);
            // 
            // richTextBox_TimeCheck
            // 
            this.richTextBox_TimeCheck.Location = new System.Drawing.Point(196, 220);
            this.richTextBox_TimeCheck.Name = "richTextBox_TimeCheck";
            this.richTextBox_TimeCheck.Size = new System.Drawing.Size(194, 51);
            this.richTextBox_TimeCheck.TabIndex = 1;
            this.richTextBox_TimeCheck.Text = "";
            // 
            // button_TimeBad
            // 
            this.button_TimeBad.Location = new System.Drawing.Point(405, 175);
            this.button_TimeBad.Name = "button_TimeBad";
            this.button_TimeBad.Size = new System.Drawing.Size(60, 44);
            this.button_TimeBad.TabIndex = 7;
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
            this.button_NextLog.TabStop = false;
            this.button_NextLog.Text = "下一事件(PageDown)";
            this.button_NextLog.UseVisualStyleBackColor = true;
            this.button_NextLog.Click += new System.EventHandler(this.button_NextLog_Click);
            // 
            // button_Output
            // 
            this.button_Output.Location = new System.Drawing.Point(26, 404);
            this.button_Output.Name = "button_Output";
            this.button_Output.Size = new System.Drawing.Size(49, 86);
            this.button_Output.TabIndex = 3;
            this.button_Output.TabStop = false;
            this.button_Output.Text = "产出报表";
            this.button_Output.UseVisualStyleBackColor = true;
            this.button_Output.Click += new System.EventHandler(this.button_Output_Click);
            // 
            // button_Input
            // 
            this.button_Input.Location = new System.Drawing.Point(12, 29);
            this.button_Input.Name = "button_Input";
            this.button_Input.Size = new System.Drawing.Size(96, 38);
            this.button_Input.TabIndex = 5;
            this.button_Input.TabStop = false;
            this.button_Input.Text = "按指定规则生成事件集";
            this.button_Input.UseVisualStyleBackColor = true;
            this.button_Input.Click += new System.EventHandler(this.button_Input_Click);
            // 
            // richTextBox_Group
            // 
            this.richTextBox_Group.Location = new System.Drawing.Point(196, 39);
            this.richTextBox_Group.Name = "richTextBox_Group";
            this.richTextBox_Group.ReadOnly = true;
            this.richTextBox_Group.Size = new System.Drawing.Size(194, 29);
            this.richTextBox_Group.TabIndex = 0;
            this.richTextBox_Group.TabStop = false;
            this.richTextBox_Group.Text = "事件分类";
            // 
            // button_GroupGood
            // 
            this.button_GroupGood.Location = new System.Drawing.Point(137, 23);
            this.button_GroupGood.Name = "button_GroupGood";
            this.button_GroupGood.Size = new System.Drawing.Size(49, 44);
            this.button_GroupGood.TabIndex = 4;
            this.button_GroupGood.Text = "对";
            this.button_GroupGood.UseVisualStyleBackColor = true;
            this.button_GroupGood.Click += new System.EventHandler(this.button_GroupGood_Click);
            // 
            // button_GroupBad
            // 
            this.button_GroupBad.Location = new System.Drawing.Point(405, 39);
            this.button_GroupBad.Name = "button_GroupBad";
            this.button_GroupBad.Size = new System.Drawing.Size(49, 44);
            this.button_GroupBad.TabIndex = 5;
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
            // 
            // button_GraphCheckHelp
            // 
            this.button_GraphCheckHelp.Location = new System.Drawing.Point(900, 526);
            this.button_GraphCheckHelp.Name = "button_GraphCheckHelp";
            this.button_GraphCheckHelp.Size = new System.Drawing.Size(28, 20);
            this.button_GraphCheckHelp.TabIndex = 6;
            this.button_GraphCheckHelp.TabStop = false;
            this.button_GraphCheckHelp.Text = "?";
            this.button_GraphCheckHelp.UseVisualStyleBackColor = true;
            // 
            // button_LogCheckHelp
            // 
            this.button_LogCheckHelp.Location = new System.Drawing.Point(405, 444);
            this.button_LogCheckHelp.Name = "button_LogCheckHelp";
            this.button_LogCheckHelp.Size = new System.Drawing.Size(28, 20);
            this.button_LogCheckHelp.TabIndex = 6;
            this.button_LogCheckHelp.TabStop = false;
            this.button_LogCheckHelp.Text = "?";
            this.button_LogCheckHelp.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Graph
            // 
            this.pictureBox_Graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.button_GraphGood.TabIndex = 11;
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
            // dataGridView_Logs
            // 
            this.dataGridView_Logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Logs.Location = new System.Drawing.Point(16, 78);
            this.dataGridView_Logs.MultiSelect = false;
            this.dataGridView_Logs.Name = "dataGridView_Logs";
            this.dataGridView_Logs.ReadOnly = true;
            this.dataGridView_Logs.RowTemplate.Height = 23;
            this.dataGridView_Logs.Size = new System.Drawing.Size(80, 249);
            this.dataGridView_Logs.TabIndex = 9;
            this.dataGridView_Logs.TabStop = false;
            this.dataGridView_Logs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Logs_ColumnHeaderMouseClick);
            this.dataGridView_Logs.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_Logs_RowsRemoved);
            this.dataGridView_Logs.SelectionChanged += new System.EventHandler(this.dataGridView_Logs_SelectionChanged);
            this.dataGridView_Logs.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_Logs_SortCompare);
            this.dataGridView_Logs.Sorted += new System.EventHandler(this.dataGridView_Logs_Sorted);
            // 
            // backgroundWorker_LogFetcher
            // 
            this.backgroundWorker_LogFetcher.WorkerReportsProgress = true;
            this.backgroundWorker_LogFetcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_LogFetcher_DoWork);
            // 
            // richTextBox_Status
            // 
            this.richTextBox_Status.Location = new System.Drawing.Point(26, 518);
            this.richTextBox_Status.Name = "richTextBox_Status";
            this.richTextBox_Status.Size = new System.Drawing.Size(100, 74);
            this.richTextBox_Status.TabIndex = 10;
            this.richTextBox_Status.TabStop = false;
            this.richTextBox_Status.Text = "";
            // 
            // label_LogInfo
            // 
            this.label_LogInfo.AutoSize = true;
            this.label_LogInfo.Location = new System.Drawing.Point(214, 7);
            this.label_LogInfo.Name = "label_LogInfo";
            this.label_LogInfo.Size = new System.Drawing.Size(47, 12);
            this.label_LogInfo.TabIndex = 11;
            this.label_LogInfo.Text = "LogInfo";
            this.label_LogInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Settings,
            this.MenuItem_File});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_Settings
            // 
            this.MenuItem_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_PageWithAlt,
            this.MenuItem_AutoGood,
            this.MenuItem_AutoCompletionLimit});
            this.MenuItem_Settings.Name = "MenuItem_Settings";
            this.MenuItem_Settings.Size = new System.Drawing.Size(44, 21);
            this.MenuItem_Settings.Text = "设置";
            // 
            // MenuItem_PageWithAlt
            // 
            this.MenuItem_PageWithAlt.CheckOnClick = true;
            this.MenuItem_PageWithAlt.Name = "MenuItem_PageWithAlt";
            this.MenuItem_PageWithAlt.Size = new System.Drawing.Size(220, 22);
            this.MenuItem_PageWithAlt.Text = "翻页快捷键Alt+";
            this.MenuItem_PageWithAlt.Click += new System.EventHandler(this.MenuItem_PageWithAlt_Click);
            // 
            // MenuItem_AutoGood
            // 
            this.MenuItem_AutoGood.CheckOnClick = true;
            this.MenuItem_AutoGood.Name = "MenuItem_AutoGood";
            this.MenuItem_AutoGood.Size = new System.Drawing.Size(220, 22);
            this.MenuItem_AutoGood.Text = "自动评为全好";
            // 
            // MenuItem_AutoCompletionLimit
            // 
            this.MenuItem_AutoCompletionLimit.CheckOnClick = true;
            this.MenuItem_AutoCompletionLimit.Name = "MenuItem_AutoCompletionLimit";
            this.MenuItem_AutoCompletionLimit.Size = new System.Drawing.Size(220, 22);
            this.MenuItem_AutoCompletionLimit.Text = "自动补全内容限为同类事件";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Add,
            this.MenuItem_Save,
            this.MenuItem_SaveAs,
            this.MenuItem_ReadSchema,
            this.MenuItem_SaveSchema});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(44, 21);
            this.MenuItem_File.Text = "文件";
            // 
            // MenuItem_Add
            // 
            this.MenuItem_Add.Name = "MenuItem_Add";
            this.MenuItem_Add.Size = new System.Drawing.Size(136, 22);
            this.MenuItem_Add.Text = "加载";
            this.MenuItem_Add.Click += new System.EventHandler(this.MenuItem_Add_Click);
            // 
            // MenuItem_Save
            // 
            this.MenuItem_Save.Name = "MenuItem_Save";
            this.MenuItem_Save.Size = new System.Drawing.Size(136, 22);
            this.MenuItem_Save.Text = "保存";
            this.MenuItem_Save.Click += new System.EventHandler(this.MenuItem_Save_Click);
            // 
            // MenuItem_SaveAs
            // 
            this.MenuItem_SaveAs.Name = "MenuItem_SaveAs";
            this.MenuItem_SaveAs.Size = new System.Drawing.Size(136, 22);
            this.MenuItem_SaveAs.Text = "另存为";
            this.MenuItem_SaveAs.Click += new System.EventHandler(this.MenuItem_SaveAs_Click);
            // 
            // MenuItem_ReadSchema
            // 
            this.MenuItem_ReadSchema.Enabled = false;
            this.MenuItem_ReadSchema.Name = "MenuItem_ReadSchema";
            this.MenuItem_ReadSchema.Size = new System.Drawing.Size(136, 22);
            this.MenuItem_ReadSchema.Text = "读取表信息";
            // 
            // MenuItem_SaveSchema
            // 
            this.MenuItem_SaveSchema.Enabled = false;
            this.MenuItem_SaveSchema.Name = "MenuItem_SaveSchema";
            this.MenuItem_SaveSchema.Size = new System.Drawing.Size(136, 22);
            this.MenuItem_SaveSchema.Text = "保存表信息";
            this.MenuItem_SaveSchema.Click += new System.EventHandler(this.MenuItem_SaveSchema_Click);
            // 
            // button_ClearScore
            // 
            this.button_ClearScore.Location = new System.Drawing.Point(433, 509);
            this.button_ClearScore.Name = "button_ClearScore";
            this.button_ClearScore.Size = new System.Drawing.Size(59, 69);
            this.button_ClearScore.TabIndex = 13;
            this.button_ClearScore.TabStop = false;
            this.button_ClearScore.Text = "清除得分";
            this.button_ClearScore.UseVisualStyleBackColor = true;
            this.button_ClearScore.Click += new System.EventHandler(this.button_ClearScore_Click);
            // 
            // listBox_Sentences
            // 
            this.listBox_Sentences.FormattingEnabled = true;
            this.listBox_Sentences.ItemHeight = 12;
            this.listBox_Sentences.Location = new System.Drawing.Point(460, 85);
            this.listBox_Sentences.Name = "listBox_Sentences";
            this.listBox_Sentences.Size = new System.Drawing.Size(85, 76);
            this.listBox_Sentences.TabIndex = 14;
            this.listBox_Sentences.SelectedIndexChanged += new System.EventHandler(this.listBox_Sentences_SelectedIndexChanged);
            this.listBox_Sentences.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_Sentences_KeyDown);
            this.listBox_Sentences.Leave += new System.EventHandler(this.listBox_Sentences_Leave);
            // 
            // button_AllGood
            // 
            this.button_AllGood.Location = new System.Drawing.Point(450, 256);
            this.button_AllGood.Name = "button_AllGood";
            this.button_AllGood.Size = new System.Drawing.Size(80, 39);
            this.button_AllGood.TabIndex = 15;
            this.button_AllGood.Text = "全评为好(&A)";
            this.button_AllGood.UseVisualStyleBackColor = true;
            this.button_AllGood.Click += new System.EventHandler(this.button_AllGood_Click);
            // 
            // timer_ReSelect
            // 
            this.timer_ReSelect.Interval = 1;
            this.timer_ReSelect.Tick += new System.EventHandler(this.timer_ReSelect_Tick);
            // 
            // backgroundWorker_DTAccessor
            // 
            this.backgroundWorker_DTAccessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DTAccessor_DoWork);
            // 
            // backgroundWorker_ReportWriter
            // 
            this.backgroundWorker_ReportWriter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_ReportWriter_DoWork);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 608);
            this.Controls.Add(this.button_AllGood);
            this.Controls.Add(this.listBox_Sentences);
            this.Controls.Add(this.button_ClearScore);
            this.Controls.Add(this.label_LogInfo);
            this.Controls.Add(this.richTextBox_Status);
            this.Controls.Add(this.dataGridView_Logs);
            this.Controls.Add(this.label_Graph);
            this.Controls.Add(this.label_Log);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.label_Group);
            this.Controls.Add(this.pictureBox_Graph);
            this.Controls.Add(this.button_GraphGood);
            this.Controls.Add(this.button_LogCheckHelp);
            this.Controls.Add(this.button_GraphCheckHelp);
            this.Controls.Add(this.button_Input);
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
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridView_Logs;
        private System.ComponentModel.BackgroundWorker backgroundWorker_LogFetcher;
        private System.Windows.Forms.RichTextBox richTextBox_Status;
        private System.Windows.Forms.Label label_LogInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Settings;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_PageWithAlt;
        private System.Windows.Forms.Button button_ClearScore;
        private System.Windows.Forms.ListBox listBox_Sentences;
        private System.Windows.Forms.Button button_AllGood;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_AutoGood;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Add;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_AutoCompletionLimit;
        private System.Windows.Forms.Timer timer_ReSelect;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ReadSchema;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveSchema;
        private System.ComponentModel.BackgroundWorker backgroundWorker_DTAccessor;
        private System.ComponentModel.BackgroundWorker backgroundWorker_ReportWriter;
    }
}

