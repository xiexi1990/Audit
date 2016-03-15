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
            this.dataGridView_Bitem = new System.Windows.Forms.DataGridView();
            this.dataGridView_Unit = new System.Windows.Forms.DataGridView();
            this.dataGridView_Science = new System.Windows.Forms.DataGridView();
            this.richTextBox_Science = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Bitem = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Unit = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Do = new System.Windows.Forms.Button();
            this.richTextBox_Sql = new System.Windows.Forms.RichTextBox();
            this.checkBox_NationGood = new System.Windows.Forms.CheckBox();
            this.checkBox_AreaGood = new System.Windows.Forms.CheckBox();
            this.checkBox_ScienceGood = new System.Windows.Forms.CheckBox();
            this.dataGridView_AbType = new System.Windows.Forms.DataGridView();
            this.dataGridView_AbType2 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox_AbType = new System.Windows.Forms.RichTextBox();
            this.richTextBox_AbType2 = new System.Windows.Forms.RichTextBox();
            this.dataGridView_Station = new System.Windows.Forms.DataGridView();
            this.richTextBox_Station = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_CalType2Num = new System.Windows.Forms.Button();
            this.button_CalUnitNum = new System.Windows.Forms.Button();
            this.button_CalStationNum = new System.Windows.Forms.Button();
            this.label_CalType2 = new System.Windows.Forms.Label();
            this.label_CalUnit = new System.Windows.Forms.Label();
            this.label_CalStation = new System.Windows.Forms.Label();
            this.richTextBox_Debug = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Science)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Station)).BeginInit();
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
            // dataGridView_Bitem
            // 
            this.dataGridView_Bitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Bitem.Location = new System.Drawing.Point(295, 30);
            this.dataGridView_Bitem.Name = "dataGridView_Bitem";
            this.dataGridView_Bitem.ReadOnly = true;
            this.dataGridView_Bitem.RowTemplate.Height = 23;
            this.dataGridView_Bitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Bitem.Size = new System.Drawing.Size(123, 455);
            this.dataGridView_Bitem.TabIndex = 3;
            this.dataGridView_Bitem.SelectionChanged += new System.EventHandler(this.dataGridView_Bitem_SelectionChanged);
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
            // richTextBox_Bitem
            // 
            this.richTextBox_Bitem.Location = new System.Drawing.Point(295, 491);
            this.richTextBox_Bitem.Name = "richTextBox_Bitem";
            this.richTextBox_Bitem.Size = new System.Drawing.Size(123, 62);
            this.richTextBox_Bitem.TabIndex = 4;
            this.richTextBox_Bitem.Text = "";
            this.richTextBox_Bitem.TextChanged += new System.EventHandler(this.richTextBox_Bitem_TextChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "学科";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "测项";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(805, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "省局";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "事件类别";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(559, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "影响因素";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1030, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "台站";
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
            // GSetRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 619);
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
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_AbType2);
            this.Controls.Add(this.richTextBox_AbType);
            this.Controls.Add(this.richTextBox_Station);
            this.Controls.Add(this.richTextBox_Unit);
            this.Controls.Add(this.richTextBox_Bitem);
            this.Controls.Add(this.richTextBox_Science);
            this.Controls.Add(this.dataGridView_AbType2);
            this.Controls.Add(this.dataGridView_AbType);
            this.Controls.Add(this.dataGridView_Station);
            this.Controls.Add(this.dataGridView_Unit);
            this.Controls.Add(this.dataGridView_Science);
            this.Controls.Add(this.dataGridView_Bitem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_EndTrim);
            this.Controls.Add(this.checkBox_BeginTrim);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.dateTimePicker_Begin);
            this.Name = "GSetRule";
            this.Text = "GSetRule";
            this.Shown += new System.EventHandler(this.GSetRule_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Science)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AbType2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Station)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView_Bitem;
        private System.Windows.Forms.DataGridView dataGridView_Unit;
        private System.Windows.Forms.DataGridView dataGridView_Science;
        private System.Windows.Forms.RichTextBox richTextBox_Science;
        private System.Windows.Forms.RichTextBox richTextBox_Bitem;
        private System.Windows.Forms.RichTextBox richTextBox_Unit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.RichTextBox richTextBox_Sql;
        private System.Windows.Forms.CheckBox checkBox_NationGood;
        private System.Windows.Forms.CheckBox checkBox_AreaGood;
        private System.Windows.Forms.CheckBox checkBox_ScienceGood;
        private System.Windows.Forms.DataGridView dataGridView_AbType;
        private System.Windows.Forms.DataGridView dataGridView_AbType2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox_AbType;
        private System.Windows.Forms.RichTextBox richTextBox_AbType2;
        private System.Windows.Forms.DataGridView dataGridView_Station;
        private System.Windows.Forms.RichTextBox richTextBox_Station;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_CalType2Num;
        private System.Windows.Forms.Button button_CalUnitNum;
        private System.Windows.Forms.Button button_CalStationNum;
        private System.Windows.Forms.Label label_CalType2;
        private System.Windows.Forms.Label label_CalUnit;
        private System.Windows.Forms.Label label_CalStation;
        private System.Windows.Forms.RichTextBox richTextBox_Debug;
        private System.Windows.Forms.Label label9;
    }
}