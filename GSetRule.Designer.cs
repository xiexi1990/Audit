﻿namespace Audit
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Science)).BeginInit();
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
            this.dataGridView_Bitem.Location = new System.Drawing.Point(401, 30);
            this.dataGridView_Bitem.Name = "dataGridView_Bitem";
            this.dataGridView_Bitem.ReadOnly = true;
            this.dataGridView_Bitem.RowTemplate.Height = 23;
            this.dataGridView_Bitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Bitem.Size = new System.Drawing.Size(225, 299);
            this.dataGridView_Bitem.TabIndex = 3;
            this.dataGridView_Bitem.SelectionChanged += new System.EventHandler(this.dataGridView_Bitem_SelectionChanged);
            // 
            // dataGridView_Unit
            // 
            this.dataGridView_Unit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Unit.Location = new System.Drawing.Point(653, 30);
            this.dataGridView_Unit.Name = "dataGridView_Unit";
            this.dataGridView_Unit.ReadOnly = true;
            this.dataGridView_Unit.RowTemplate.Height = 23;
            this.dataGridView_Unit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Unit.Size = new System.Drawing.Size(257, 299);
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
            this.dataGridView_Science.Size = new System.Drawing.Size(180, 230);
            this.dataGridView_Science.TabIndex = 3;
            this.dataGridView_Science.SelectionChanged += new System.EventHandler(this.dataGridView_Science_SelectionChanged);
            // 
            // richTextBox_Science
            // 
            this.richTextBox_Science.Location = new System.Drawing.Point(196, 335);
            this.richTextBox_Science.Name = "richTextBox_Science";
            this.richTextBox_Science.Size = new System.Drawing.Size(180, 62);
            this.richTextBox_Science.TabIndex = 4;
            this.richTextBox_Science.Text = "";
            this.richTextBox_Science.TextChanged += new System.EventHandler(this.richTextBox_Science_TextChanged);
            // 
            // richTextBox_Bitem
            // 
            this.richTextBox_Bitem.Location = new System.Drawing.Point(401, 335);
            this.richTextBox_Bitem.Name = "richTextBox_Bitem";
            this.richTextBox_Bitem.Size = new System.Drawing.Size(225, 62);
            this.richTextBox_Bitem.TabIndex = 4;
            this.richTextBox_Bitem.Text = "";
            this.richTextBox_Bitem.TextChanged += new System.EventHandler(this.richTextBox_Bitem_TextChanged);
            // 
            // richTextBox_Unit
            // 
            this.richTextBox_Unit.Location = new System.Drawing.Point(653, 335);
            this.richTextBox_Unit.Name = "richTextBox_Unit";
            this.richTextBox_Unit.Size = new System.Drawing.Size(257, 62);
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
            this.label4.Location = new System.Drawing.Point(399, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "测项";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(651, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "省局";
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(844, 528);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(66, 34);
            this.button_Do.TabIndex = 6;
            this.button_Do.Text = "执行抽取";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // richTextBox_Sql
            // 
            this.richTextBox_Sql.Location = new System.Drawing.Point(11, 415);
            this.richTextBox_Sql.Name = "richTextBox_Sql";
            this.richTextBox_Sql.Size = new System.Drawing.Size(827, 147);
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
            // GSetRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 574);
            this.Controls.Add(this.checkBox_ScienceGood);
            this.Controls.Add(this.checkBox_AreaGood);
            this.Controls.Add(this.checkBox_NationGood);
            this.Controls.Add(this.richTextBox_Sql);
            this.Controls.Add(this.button_Do);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_Unit);
            this.Controls.Add(this.richTextBox_Bitem);
            this.Controls.Add(this.richTextBox_Science);
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
    }
}