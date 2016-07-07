namespace Audit
{
    partial class GSetRule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.checkBox_BeginTrim = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_EndTrim = new System.Windows.Forms.CheckBox();
            this.dataGridView_Item = new System.Windows.Forms.DataGridView();
            this.dataGridView_Unit = new System.Windows.Forms.DataGridView();
            this.dataGridView_Science = new System.Windows.Forms.DataGridView();
            this.richTextBox_Science = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Item = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Unit = new System.Windows.Forms.RichTextBox();
            this.label_Science = new System.Windows.Forms.Label();
            this.label_Item = new System.Windows.Forms.Label();
            this.label_Unit = new System.Windows.Forms.Label();
            this.button_Do = new System.Windows.Forms.Button();
            this.richTextBox_Sql = new System.Windows.Forms.RichTextBox();
            this.checkBox_NationGood = new System.Windows.Forms.CheckBox();
            this.checkBox_AreaGood = new System.Windows.Forms.CheckBox();
            this.checkBox_ScienceGood = new System.Windows.Forms.CheckBox();
            this.dataGridView_AbType = new System.Windows.Forms.DataGridView();
            this.dataGridView_AbType2 = new System.Windows.Forms.DataGridView();
            this.label_AbType = new System.Windows.Forms.Label();
            this.label_AbType2 = new System.Windows.Forms.Label();
            this.richTextBox_AbType = new System.Windows.Forms.RichTextBox();
            this.richTextBox_AbType2 = new System.Windows.Forms.RichTextBox();
            this.dataGridView_Station = new System.Windows.Forms.DataGridView();
            this.richTextBox_Station = new System.Windows.Forms.RichTextBox();
            this.label_Station = new System.Windows.Forms.Label();
            this.button_CalType2Num = new System.Windows.Forms.Button();
            this.button_CalUnitNum = new System.Windows.Forms.Button();
            this.button_CalStationNum = new System.Windows.Forms.Button();
            this.label_CalType2 = new System.Windows.Forms.Label();
            this.label_CalUnit = new System.Windows.Forms.Label();
            this.label_CalStation = new System.Windows.Forms.Label();
            this.richTextBox_Debug = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton_ShowMain = new System.Windows.Forms.RadioButton();
            this.radioButton_ShowTable1 = new System.Windows.Forms.RadioButton();
            this.richTextBox_Instr = new System.Windows.Forms.RichTextBox();
            this.button_LoadTable1 = new System.Windows.Forms.Button();
            this.dataGridView_Table1 = new System.Windows.Forms.DataGridView();
            this.checkBox_Day10 = new System.Windows.Forms.CheckBox();
            this.checkBox_Freq10 = new System.Windows.Forms.CheckBox();
            this.checkBox_Day10OrFreq10 = new System.Windows.Forms.CheckBox();
            this.richTextBox_Span = new System.Windows.Forms.RichTextBox();
            this.label_Span = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Science)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Station)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Table1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(66, 12);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_Begin.TabIndex = 0;
            this.dateTimePicker_Begin.ValueChanged += new System.EventHandler(this.dateTimePicker_Begin_ValueChanged);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(66, 39);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_End.TabIndex = 0;
            this.dateTimePicker_End.ValueChanged += new System.EventHandler(this.dateTimePicker_End_ValueChanged);
            // 
            // checkBox_BeginTrim
            // 
            this.checkBox_BeginTrim.AutoSize = true;
            this.checkBox_BeginTrim.Location = new System.Drawing.Point(11, 77);
            this.checkBox_BeginTrim.Name = "checkBox_BeginTrim";
            this.checkBox_BeginTrim.Size = new System.Drawing.Size(96, 16);
            this.checkBox_BeginTrim.TabIndex = 1;
            this.checkBox_BeginTrim.Text = "起始时间截断";
            this.checkBox_BeginTrim.UseVisualStyleBackColor = true;
            this.checkBox_BeginTrim.CheckedChanged += new System.EventHandler(this.checkBox_BeginTrim_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "起始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间";
            // 
            // checkBox_EndTrim
            // 
            this.checkBox_EndTrim.AutoSize = true;
            this.checkBox_EndTrim.Location = new System.Drawing.Point(11, 99);
            this.checkBox_EndTrim.Name = "checkBox_EndTrim";
            this.checkBox_EndTrim.Size = new System.Drawing.Size(96, 16);
            this.checkBox_EndTrim.TabIndex = 1;
            this.checkBox_EndTrim.Text = "结束时间截断";
            this.checkBox_EndTrim.UseVisualStyleBackColor = true;
            this.checkBox_EndTrim.CheckedChanged += new System.EventHandler(this.checkBox_EndTrim_CheckedChanged);
            // 
            // dataGridView_Item
            // 
            this.dataGridView_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Item.Location = new System.Drawing.Point(295, 30);
            this.dataGridView_Item.Name = "dataGridView_Item";
            this.dataGridView_Item.ReadOnly = true;
            this.dataGridView_Item.RowTemplate.Height = 23;
            this.dataGridView_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Item.Size = new System.Drawing.Size(123, 455);
            this.dataGridView_Item.TabIndex = 3;
            this.dataGridView_Item.SelectionChanged += new System.EventHandler(this.dataGridView_Item_SelectionChanged);
            // 
            // dataGridView_Unit
            // 
            this.dataGridView_Unit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Unit.Location = new System.Drawing.Point(807, 30);
            this.dataGridView_Unit.Name = "dataGridView_Unit";
            this.dataGridView_Unit.ReadOnly = true;
            this.dataGridView_Unit.RowTemplate.Height = 23;
            this.dataGridView_Unit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Unit.Size = new System.Drawing.Size(203, 455);
            this.dataGridView_Unit.TabIndex = 3;
            this.dataGridView_Unit.SelectionChanged += new System.EventHandler(this.dataGridView_Unit_SelectionChanged);
            // 
            // dataGridView_Science
            // 
            this.dataGridView_Science.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Science.Location = new System.Drawing.Point(196, 99);
            this.dataGridView_Science.Name = "dataGridView_Science";
            this.dataGridView_Science.ReadOnly = true;
            this.dataGridView_Science.RowTemplate.Height = 23;
            this.dataGridView_Science.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Science.Size = new System.Drawing.Size(93, 386);
            this.dataGridView_Science.TabIndex = 3;
            this.dataGridView_Science.SelectionChanged += new System.EventHandler(this.dataGridView_Science_SelectionChanged);
            // 
            // richTextBox_Science
            // 
            this.richTextBox_Science.Location = new System.Drawing.Point(196, 491);
            this.richTextBox_Science.Name = "richTextBox_Science";
            this.richTextBox_Science.Size = new System.Drawing.Size(93, 62);
            this.richTextBox_Science.TabIndex = 4;
            this.richTextBox_Science.Text = "";
            this.richTextBox_Science.TextChanged += new System.EventHandler(this.richTextBox_Science_TextChanged);
            // 
            // richTextBox_Item
            // 
            this.richTextBox_Item.Location = new System.Drawing.Point(295, 491);
            this.richTextBox_Item.Name = "richTextBox_Item";
            this.richTextBox_Item.Size = new System.Drawing.Size(123, 62);
            this.richTextBox_Item.TabIndex = 4;
            this.richTextBox_Item.Text = "";
            this.richTextBox_Item.TextChanged += new System.EventHandler(this.richTextBox_Item_TextChanged);
            // 
            // richTextBox_Unit
            // 
            this.richTextBox_Unit.Location = new System.Drawing.Point(807, 491);
            this.richTextBox_Unit.Name = "richTextBox_Unit";
            this.richTextBox_Unit.Size = new System.Drawing.Size(203, 62);
            this.richTextBox_Unit.TabIndex = 4;
            this.richTextBox_Unit.Text = "";
            this.richTextBox_Unit.TextChanged += new System.EventHandler(this.richTextBox_Unit_TextChanged);
            // 
            // label_Science
            // 
            this.label_Science.AutoSize = true;
            this.label_Science.Location = new System.Drawing.Point(194, 77);
            this.label_Science.Name = "label_Science";
            this.label_Science.Size = new System.Drawing.Size(29, 12);
            this.label_Science.TabIndex = 5;
            this.label_Science.Text = "学科";
            // 
            // label_Item
            // 
            this.label_Item.AutoSize = true;
            this.label_Item.Location = new System.Drawing.Point(293, 9);
            this.label_Item.Name = "label_Item";
            this.label_Item.Size = new System.Drawing.Size(29, 12);
            this.label_Item.TabIndex = 5;
            this.label_Item.Text = "测项";
            // 
            // label_Unit
            // 
            this.label_Unit.AutoSize = true;
            this.label_Unit.Location = new System.Drawing.Point(805, 9);
            this.label_Unit.Name = "label_Unit";
            this.label_Unit.Size = new System.Drawing.Size(29, 12);
            this.label_Unit.TabIndex = 5;
            this.label_Unit.Text = "省局";
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(11, 268);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(119, 62);
            this.button_Do.TabIndex = 6;
            this.button_Do.Text = "执行抽取";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // richTextBox_Sql
            // 
            this.richTextBox_Sql.Location = new System.Drawing.Point(12, 351);
            this.richTextBox_Sql.Name = "richTextBox_Sql";
            this.richTextBox_Sql.Size = new System.Drawing.Size(131, 202);
            this.richTextBox_Sql.TabIndex = 7;
            this.richTextBox_Sql.Text = "";
            // 
            // checkBox_NationGood
            // 
            this.checkBox_NationGood.AutoSize = true;
            this.checkBox_NationGood.Location = new System.Drawing.Point(11, 192);
            this.checkBox_NationGood.Name = "checkBox_NationGood";
            this.checkBox_NationGood.Size = new System.Drawing.Size(120, 16);
            this.checkBox_NationGood.TabIndex = 8;
            this.checkBox_NationGood.Text = "国家中心审核为好";
            this.checkBox_NationGood.UseVisualStyleBackColor = true;
            this.checkBox_NationGood.CheckedChanged += new System.EventHandler(this.checkBox_NationGood_CheckedChanged);
            // 
            // checkBox_AreaGood
            // 
            this.checkBox_AreaGood.AutoSize = true;
            this.checkBox_AreaGood.Location = new System.Drawing.Point(11, 214);
            this.checkBox_AreaGood.Name = "checkBox_AreaGood";
            this.checkBox_AreaGood.Size = new System.Drawing.Size(96, 16);
            this.checkBox_AreaGood.TabIndex = 8;
            this.checkBox_AreaGood.Text = "区域审核为好";
            this.checkBox_AreaGood.UseVisualStyleBackColor = true;
            this.checkBox_AreaGood.CheckedChanged += new System.EventHandler(this.checkBox_AreaGood_CheckedChanged);
            // 
            // checkBox_ScienceGood
            // 
            this.checkBox_ScienceGood.AutoSize = true;
            this.checkBox_ScienceGood.Location = new System.Drawing.Point(11, 236);
            this.checkBox_ScienceGood.Name = "checkBox_ScienceGood";
            this.checkBox_ScienceGood.Size = new System.Drawing.Size(96, 16);
            this.checkBox_ScienceGood.TabIndex = 8;
            this.checkBox_ScienceGood.Text = "学科审核为好";
            this.checkBox_ScienceGood.UseVisualStyleBackColor = true;
            this.checkBox_ScienceGood.CheckedChanged += new System.EventHandler(this.checkBox_ScienceGood_CheckedChanged);
            // 
            // dataGridView_AbType
            // 
            this.dataGridView_AbType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AbType.Location = new System.Drawing.Point(424, 30);
            this.dataGridView_AbType.Name = "dataGridView_AbType";
            this.dataGridView_AbType.ReadOnly = true;
            this.dataGridView_AbType.RowTemplate.Height = 23;
            this.dataGridView_AbType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_AbType.Size = new System.Drawing.Size(131, 455);
            this.dataGridView_AbType.TabIndex = 3;
            this.dataGridView_AbType.SelectionChanged += new System.EventHandler(this.dataGridView_AbType_SelectionChanged);
            // 
            // dataGridView_AbType2
            // 
            this.dataGridView_AbType2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AbType2.Location = new System.Drawing.Point(561, 30);
            this.dataGridView_AbType2.Name = "dataGridView_AbType2";
            this.dataGridView_AbType2.ReadOnly = true;
            this.dataGridView_AbType2.RowTemplate.Height = 23;
            this.dataGridView_AbType2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_AbType2.Size = new System.Drawing.Size(218, 455);
            this.dataGridView_AbType2.TabIndex = 3;
            this.dataGridView_AbType2.SelectionChanged += new System.EventHandler(this.dataGridView_AbType2_SelectionChanged);
            // 
            // label_AbType
            // 
            this.label_AbType.AutoSize = true;
            this.label_AbType.Location = new System.Drawing.Point(422, 9);
            this.label_AbType.Name = "label_AbType";
            this.label_AbType.Size = new System.Drawing.Size(53, 12);
            this.label_AbType.TabIndex = 5;
            this.label_AbType.Text = "事件类别";
            // 
            // label_AbType2
            // 
            this.label_AbType2.AutoSize = true;
            this.label_AbType2.Location = new System.Drawing.Point(559, 9);
            this.label_AbType2.Name = "label_AbType2";
            this.label_AbType2.Size = new System.Drawing.Size(53, 12);
            this.label_AbType2.TabIndex = 5;
            this.label_AbType2.Text = "影响因素";
            // 
            // richTextBox_AbType
            // 
            this.richTextBox_AbType.Location = new System.Drawing.Point(424, 491);
            this.richTextBox_AbType.Name = "richTextBox_AbType";
            this.richTextBox_AbType.Size = new System.Drawing.Size(131, 62);
            this.richTextBox_AbType.TabIndex = 4;
            this.richTextBox_AbType.Text = "";
            this.richTextBox_AbType.TextChanged += new System.EventHandler(this.richTextBox_AbType_TextChanged);
            // 
            // richTextBox_AbType2
            // 
            this.richTextBox_AbType2.Location = new System.Drawing.Point(561, 491);
            this.richTextBox_AbType2.Name = "richTextBox_AbType2";
            this.richTextBox_AbType2.Size = new System.Drawing.Size(218, 62);
            this.richTextBox_AbType2.TabIndex = 4;
            this.richTextBox_AbType2.Text = "";
            this.richTextBox_AbType2.TextChanged += new System.EventHandler(this.richTextBox_AbType2_TextChanged);
            // 
            // dataGridView_Station
            // 
            this.dataGridView_Station.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Station.Location = new System.Drawing.Point(1032, 30);
            this.dataGridView_Station.Name = "dataGridView_Station";
            this.dataGridView_Station.ReadOnly = true;
            this.dataGridView_Station.RowTemplate.Height = 23;
            this.dataGridView_Station.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Station.Size = new System.Drawing.Size(222, 455);
            this.dataGridView_Station.TabIndex = 3;
            this.dataGridView_Station.SelectionChanged += new System.EventHandler(this.dataGridView_Station_SelectionChanged);
            // 
            // richTextBox_Station
            // 
            this.richTextBox_Station.Location = new System.Drawing.Point(1032, 491);
            this.richTextBox_Station.Name = "richTextBox_Station";
            this.richTextBox_Station.Size = new System.Drawing.Size(222, 62);
            this.richTextBox_Station.TabIndex = 4;
            this.richTextBox_Station.Text = "";
            this.richTextBox_Station.TextChanged += new System.EventHandler(this.richTextBox_Station_TextChanged);
            // 
            // label_Station
            // 
            this.label_Station.AutoSize = true;
            this.label_Station.Location = new System.Drawing.Point(1030, 9);
            this.label_Station.Name = "label_Station";
            this.label_Station.Size = new System.Drawing.Size(29, 12);
            this.label_Station.TabIndex = 5;
            this.label_Station.Text = "台站";
            // 
            // button_CalType2Num
            // 
            this.button_CalType2Num.Location = new System.Drawing.Point(591, 559);
            this.button_CalType2Num.Name = "button_CalType2Num";
            this.button_CalType2Num.Size = new System.Drawing.Size(172, 48);
            this.button_CalType2Num.TabIndex = 9;
            this.button_CalType2Num.Text = "计算影响因素分布\r\n（指定学科、测项、事件类别）\r\n";
            this.button_CalType2Num.UseVisualStyleBackColor = true;
            this.button_CalType2Num.Click += new System.EventHandler(this.button_CalType2Num_Click);
            // 
            // button_CalUnitNum
            // 
            this.button_CalUnitNum.Location = new System.Drawing.Point(825, 559);
            this.button_CalUnitNum.Name = "button_CalUnitNum";
            this.button_CalUnitNum.Size = new System.Drawing.Size(172, 48);
            this.button_CalUnitNum.TabIndex = 9;
            this.button_CalUnitNum.Text = "计算省局分布\r\n（指定学科、测项、事件类别、影响因素）\r\n";
            this.button_CalUnitNum.UseVisualStyleBackColor = true;
            this.button_CalUnitNum.Click += new System.EventHandler(this.button_CalUnitNum_Click);
            // 
            // button_CalStationNum
            // 
            this.button_CalStationNum.Location = new System.Drawing.Point(1057, 559);
            this.button_CalStationNum.Name = "button_CalStationNum";
            this.button_CalStationNum.Size = new System.Drawing.Size(172, 48);
            this.button_CalStationNum.TabIndex = 9;
            this.button_CalStationNum.Text = "计算台站分布\r\n（指定学科、测项、事件类别、影响因素、省局）\r\n";
            this.button_CalStationNum.UseVisualStyleBackColor = true;
            this.button_CalStationNum.Click += new System.EventHandler(this.button_CalStationNum_Click);
            // 
            // label_CalType2
            // 
            this.label_CalType2.AutoSize = true;
            this.label_CalType2.Location = new System.Drawing.Point(701, 9);
            this.label_CalType2.Name = "label_CalType2";
            this.label_CalType2.Size = new System.Drawing.Size(29, 12);
            this.label_CalType2.TabIndex = 10;
            this.label_CalType2.Text = "总数";
            // 
            // label_CalUnit
            // 
            this.label_CalUnit.AutoSize = true;
            this.label_CalUnit.Location = new System.Drawing.Point(932, 9);
            this.label_CalUnit.Name = "label_CalUnit";
            this.label_CalUnit.Size = new System.Drawing.Size(29, 12);
            this.label_CalUnit.TabIndex = 10;
            this.label_CalUnit.Text = "总数";
            // 
            // label_CalStation
            // 
            this.label_CalStation.AutoSize = true;
            this.label_CalStation.Location = new System.Drawing.Point(1164, 9);
            this.label_CalStation.Name = "label_CalStation";
            this.label_CalStation.Size = new System.Drawing.Size(29, 12);
            this.label_CalStation.TabIndex = 10;
            this.label_CalStation.Text = "总数";
            // 
            // richTextBox_Debug
            // 
            this.richTextBox_Debug.Location = new System.Drawing.Point(214, 562);
            this.richTextBox_Debug.Name = "richTextBox_Debug";
            this.richTextBox_Debug.Size = new System.Drawing.Size(251, 45);
            this.richTextBox_Debug.TabIndex = 11;
            this.richTextBox_Debug.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(155, 577);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "调试窗口";
            // 
            // radioButton_ShowMain
            // 
            this.radioButton_ShowMain.AutoSize = true;
            this.radioButton_ShowMain.Location = new System.Drawing.Point(12, 563);
            this.radioButton_ShowMain.Name = "radioButton_ShowMain";
            this.radioButton_ShowMain.Size = new System.Drawing.Size(83, 16);
            this.radioButton_ShowMain.TabIndex = 13;
            this.radioButton_ShowMain.TabStop = true;
            this.radioButton_ShowMain.Text = "显示主界面";
            this.radioButton_ShowMain.UseVisualStyleBackColor = true;
            this.radioButton_ShowMain.CheckedChanged += new System.EventHandler(this.radioButton_ShowMain_CheckedChanged);
            // 
            // radioButton_ShowTable1
            // 
            this.radioButton_ShowTable1.AutoSize = true;
            this.radioButton_ShowTable1.Location = new System.Drawing.Point(12, 585);
            this.radioButton_ShowTable1.Name = "radioButton_ShowTable1";
            this.radioButton_ShowTable1.Size = new System.Drawing.Size(83, 16);
            this.radioButton_ShowTable1.TabIndex = 13;
            this.radioButton_ShowTable1.TabStop = true;
            this.radioButton_ShowTable1.Text = "显示统计表";
            this.radioButton_ShowTable1.UseVisualStyleBackColor = true;
            this.radioButton_ShowTable1.CheckedChanged += new System.EventHandler(this.radioButton_ShowTable_CheckedChanged);
            this.radioButton_ShowTable1.Click += new System.EventHandler(this.radioButton_ShowTable1_Click);
            // 
            // richTextBox_Instr
            // 
            this.richTextBox_Instr.Location = new System.Drawing.Point(1270, 74);
            this.richTextBox_Instr.Name = "richTextBox_Instr";
            this.richTextBox_Instr.Size = new System.Drawing.Size(80, 140);
            this.richTextBox_Instr.TabIndex = 14;
            this.richTextBox_Instr.Text = "";
            this.richTextBox_Instr.TextChanged += new System.EventHandler(this.richTextBox_Instr_TextChanged);
            // 
            // button_LoadTable1
            // 
            this.button_LoadTable1.Location = new System.Drawing.Point(1270, 30);
            this.button_LoadTable1.Name = "button_LoadTable1";
            this.button_LoadTable1.Size = new System.Drawing.Size(80, 31);
            this.button_LoadTable1.TabIndex = 15;
            this.button_LoadTable1.Text = "导入统计表";
            this.button_LoadTable1.UseVisualStyleBackColor = true;
            this.button_LoadTable1.Click += new System.EventHandler(this.button_LoadTable1_Click);
            // 
            // dataGridView_Table1
            // 
            this.dataGridView_Table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Table1.Location = new System.Drawing.Point(295, 12);
            this.dataGridView_Table1.Name = "dataGridView_Table1";
            this.dataGridView_Table1.ReadOnly = true;
            this.dataGridView_Table1.RowTemplate.Height = 23;
            this.dataGridView_Table1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Table1.Size = new System.Drawing.Size(959, 473);
            this.dataGridView_Table1.TabIndex = 16;
            this.dataGridView_Table1.SelectionChanged += new System.EventHandler(this.dataGridView_Table1_SelectionChanged);
            // 
            // checkBox_Day10
            // 
            this.checkBox_Day10.AutoSize = true;
            this.checkBox_Day10.Location = new System.Drawing.Point(1270, 236);
            this.checkBox_Day10.Name = "checkBox_Day10";
            this.checkBox_Day10.Size = new System.Drawing.Size(96, 16);
            this.checkBox_Day10.TabIndex = 17;
            this.checkBox_Day10.Text = "累计天数≥10";
            this.checkBox_Day10.UseVisualStyleBackColor = true;
            this.checkBox_Day10.CheckedChanged += new System.EventHandler(this.checkBox_Day10_CheckedChanged);
            // 
            // checkBox_Freq10
            // 
            this.checkBox_Freq10.AutoSize = true;
            this.checkBox_Freq10.Location = new System.Drawing.Point(1270, 258);
            this.checkBox_Freq10.Name = "checkBox_Freq10";
            this.checkBox_Freq10.Size = new System.Drawing.Size(96, 16);
            this.checkBox_Freq10.TabIndex = 17;
            this.checkBox_Freq10.Text = "事件次数≥10";
            this.checkBox_Freq10.UseVisualStyleBackColor = true;
            this.checkBox_Freq10.CheckedChanged += new System.EventHandler(this.checkBox_Freq10_CheckedChanged);
            // 
            // checkBox_Day10OrFreq10
            // 
            this.checkBox_Day10OrFreq10.AutoSize = true;
            this.checkBox_Day10OrFreq10.Location = new System.Drawing.Point(1260, 290);
            this.checkBox_Day10OrFreq10.Name = "checkBox_Day10OrFreq10";
            this.checkBox_Day10OrFreq10.Size = new System.Drawing.Size(108, 28);
            this.checkBox_Day10OrFreq10.TabIndex = 17;
            this.checkBox_Day10OrFreq10.Text = "累计天数≥10 \r\n或事件次数≥10";
            this.checkBox_Day10OrFreq10.UseVisualStyleBackColor = true;
            this.checkBox_Day10OrFreq10.CheckedChanged += new System.EventHandler(this.checkBox_Day10OrFreq10_CheckedChanged);
            // 
            // richTextBox_Span
            // 
            this.richTextBox_Span.Location = new System.Drawing.Point(67, 123);
            this.richTextBox_Span.Multiline = false;
            this.richTextBox_Span.Name = "richTextBox_Span";
            this.richTextBox_Span.Size = new System.Drawing.Size(64, 17);
            this.richTextBox_Span.TabIndex = 18;
            this.richTextBox_Span.Text = ">=0";
            this.richTextBox_Span.TextChanged += new System.EventHandler(this.richTextBox_Span_TextChanged);
            // 
            // label_Span
            // 
            this.label_Span.AutoSize = true;
            this.label_Span.Location = new System.Drawing.Point(10, 126);
            this.label_Span.Name = "label_Span";
            this.label_Span.Size = new System.Drawing.Size(53, 12);
            this.label_Span.TabIndex = 5;
            this.label_Span.Text = "持续时间";
            // 
            // GSetRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 619);
            this.Controls.Add(this.richTextBox_Span);
            this.Controls.Add(this.checkBox_Day10OrFreq10);
            this.Controls.Add(this.checkBox_Freq10);
            this.Controls.Add(this.checkBox_Day10);
            this.Controls.Add(this.button_LoadTable1);
            this.Controls.Add(this.richTextBox_Instr);
            this.Controls.Add(this.radioButton_ShowTable1);
            this.Controls.Add(this.radioButton_ShowMain);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.richTextBox_Debug);
            this.Controls.Add(this.label_CalStation);
            this.Controls.Add(this.label_CalUnit);
            this.Controls.Add(this.label_CalType2);
            this.Controls.Add(this.button_CalStationNum);
            this.Controls.Add(this.button_CalUnitNum);
            this.Controls.Add(this.button_CalType2Num);
            this.Controls.Add(this.checkBox_ScienceGood);
            this.Controls.Add(this.checkBox_AreaGood);
            this.Controls.Add(this.checkBox_NationGood);
            this.Controls.Add(this.richTextBox_Sql);
            this.Controls.Add(this.button_Do);
            this.Controls.Add(this.label_AbType2);
            this.Controls.Add(this.label_AbType);
            this.Controls.Add(this.label_Station);
            this.Controls.Add(this.label_Unit);
            this.Controls.Add(this.label_Item);
            this.Controls.Add(this.label_Span);
            this.Controls.Add(this.label_Science);
            this.Controls.Add(this.richTextBox_AbType2);
            this.Controls.Add(this.richTextBox_AbType);
            this.Controls.Add(this.richTextBox_Station);
            this.Controls.Add(this.richTextBox_Unit);
            this.Controls.Add(this.richTextBox_Item);
            this.Controls.Add(this.richTextBox_Science);
            this.Controls.Add(this.dataGridView_AbType2);
            this.Controls.Add(this.dataGridView_AbType);
            this.Controls.Add(this.dataGridView_Station);
            this.Controls.Add(this.dataGridView_Unit);
            this.Controls.Add(this.dataGridView_Science);
            this.Controls.Add(this.dataGridView_Item);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_EndTrim);
            this.Controls.Add(this.checkBox_BeginTrim);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.dateTimePicker_Begin);
            this.Controls.Add(this.dataGridView_Table1);
            this.Name = "GSetRule";
            this.Text = "GSetRule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GSetRule_FormClosing);
            this.Load += new System.EventHandler(this.GSetRule_Load);
            this.Shown += new System.EventHandler(this.GSetRule_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Science)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Station)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Table1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Begin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.CheckBox checkBox_BeginTrim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_EndTrim;
        private System.Windows.Forms.DataGridView dataGridView_Item;
        private System.Windows.Forms.DataGridView dataGridView_Unit;
        private System.Windows.Forms.DataGridView dataGridView_Science;
        private System.Windows.Forms.RichTextBox richTextBox_Science;
        private System.Windows.Forms.RichTextBox richTextBox_Item;
        private System.Windows.Forms.RichTextBox richTextBox_Unit;
        private System.Windows.Forms.Label label_Science;
        private System.Windows.Forms.Label label_Item;
        private System.Windows.Forms.Label label_Unit;
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.RichTextBox richTextBox_Sql;
        private System.Windows.Forms.CheckBox checkBox_NationGood;
        private System.Windows.Forms.CheckBox checkBox_AreaGood;
        private System.Windows.Forms.CheckBox checkBox_ScienceGood;
        private System.Windows.Forms.DataGridView dataGridView_AbType;
        private System.Windows.Forms.DataGridView dataGridView_AbType2;
        private System.Windows.Forms.Label label_AbType;
        private System.Windows.Forms.Label label_AbType2;
        private System.Windows.Forms.RichTextBox richTextBox_AbType;
        private System.Windows.Forms.RichTextBox richTextBox_AbType2;
        private System.Windows.Forms.DataGridView dataGridView_Station;
        private System.Windows.Forms.RichTextBox richTextBox_Station;
        private System.Windows.Forms.Label label_Station;
        private System.Windows.Forms.Button button_CalType2Num;
        private System.Windows.Forms.Button button_CalUnitNum;
        private System.Windows.Forms.Button button_CalStationNum;
        private System.Windows.Forms.Label label_CalType2;
        private System.Windows.Forms.Label label_CalUnit;
        private System.Windows.Forms.Label label_CalStation;
        private System.Windows.Forms.RichTextBox richTextBox_Debug;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton_ShowMain;
        private System.Windows.Forms.RadioButton radioButton_ShowTable1;
        private System.Windows.Forms.RichTextBox richTextBox_Instr;
        private System.Windows.Forms.Button button_LoadTable1;
        private System.Windows.Forms.DataGridView dataGridView_Table1;
        private System.Windows.Forms.CheckBox checkBox_Day10;
        private System.Windows.Forms.CheckBox checkBox_Freq10;
        private System.Windows.Forms.CheckBox checkBox_Day10OrFreq10;
        private System.Windows.Forms.RichTextBox richTextBox_Span;
        private System.Windows.Forms.Label label_Span;
    }
}