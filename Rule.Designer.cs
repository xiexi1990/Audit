namespace Audit
{
    partial class Rule
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
            this.radioButton_TimeDetermin = new System.Windows.Forms.RadioButton();
            this.radioButton_TypeDetermin = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_Units = new System.Windows.Forms.RichTextBox();
            this.checkBox_NoEarlier = new System.Windows.Forms.CheckBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Execute = new System.Windows.Forms.Button();
            this.dataGridView_Units = new System.Windows.Forms.DataGridView();
            this.dateTimePicker_AfterDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Units)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_TimeDetermin
            // 
            this.radioButton_TimeDetermin.AutoCheck = false;
            this.radioButton_TimeDetermin.AutoSize = true;
            this.radioButton_TimeDetermin.Location = new System.Drawing.Point(12, 28);
            this.radioButton_TimeDetermin.Name = "radioButton_TimeDetermin";
            this.radioButton_TimeDetermin.Size = new System.Drawing.Size(149, 28);
            this.radioButton_TimeDetermin.TabIndex = 0;
            this.radioButton_TimeDetermin.TabStop = true;
            this.radioButton_TimeDetermin.Text = "从指定日期之后抽取\r\n若不满则从当月1日起补";
            this.radioButton_TimeDetermin.UseVisualStyleBackColor = true;
            // 
            // radioButton_TypeDetermin
            // 
            this.radioButton_TypeDetermin.AutoCheck = false;
            this.radioButton_TypeDetermin.AutoSize = true;
            this.radioButton_TypeDetermin.Location = new System.Drawing.Point(12, 180);
            this.radioButton_TypeDetermin.Name = "radioButton_TypeDetermin";
            this.radioButton_TypeDetermin.Size = new System.Drawing.Size(239, 52);
            this.radioButton_TypeDetermin.TabIndex = 1;
            this.radioButton_TypeDetermin.TabStop = true;
            this.radioButton_TypeDetermin.Text = "轮流从每类事件（不明原因、场地环境、\r\n自然环境、观测系统、人为干扰、地球物\r\n理事件）每个学科（形变、重力、流体、\r\n地磁、地电）中抽取";
            this.radioButton_TypeDetermin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "时间确定方式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "类型确定方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "省局列表";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "抽查省局";
            // 
            // richTextBox_Units
            // 
            this.richTextBox_Units.Location = new System.Drawing.Point(12, 280);
            this.richTextBox_Units.Name = "richTextBox_Units";
            this.richTextBox_Units.Size = new System.Drawing.Size(229, 85);
            this.richTextBox_Units.TabIndex = 4;
            this.richTextBox_Units.Text = "";
            // 
            // checkBox_NoEarlier
            // 
            this.checkBox_NoEarlier.AutoSize = true;
            this.checkBox_NoEarlier.Location = new System.Drawing.Point(12, 120);
            this.checkBox_NoEarlier.Name = "checkBox_NoEarlier";
            this.checkBox_NoEarlier.Size = new System.Drawing.Size(198, 16);
            this.checkBox_NoEarlier.TabIndex = 5;
            this.checkBox_NoEarlier.Text = "抽查事件起始时间不早于当月1日";
            this.checkBox_NoEarlier.UseVisualStyleBackColor = true;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(574, 9);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(44, 21);
            this.button_Add.TabIndex = 6;
            this.button_Add.Text = "添加";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(532, 371);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(86, 27);
            this.button_Execute.TabIndex = 7;
            this.button_Execute.Text = "执行抽查";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // dataGridView_Units
            // 
            this.dataGridView_Units.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Units.Location = new System.Drawing.Point(267, 36);
            this.dataGridView_Units.Name = "dataGridView_Units";
            this.dataGridView_Units.ReadOnly = true;
            this.dataGridView_Units.RowTemplate.Height = 23;
            this.dataGridView_Units.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Units.Size = new System.Drawing.Size(351, 329);
            this.dataGridView_Units.TabIndex = 8;
            // 
            // dateTimePicker_AfterDate
            // 
            this.dateTimePicker_AfterDate.Location = new System.Drawing.Point(69, 62);
            this.dateTimePicker_AfterDate.Name = "dateTimePicker_AfterDate";
            this.dateTimePicker_AfterDate.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_AfterDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "指定日期";
            // 
            // Rule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 410);
            this.Controls.Add(this.dateTimePicker_AfterDate);
            this.Controls.Add(this.dataGridView_Units);
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.checkBox_NoEarlier);
            this.Controls.Add(this.richTextBox_Units);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton_TypeDetermin);
            this.Controls.Add(this.radioButton_TimeDetermin);
            this.Name = "Rule";
            this.Text = "Rule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Units)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_TimeDetermin;
        private System.Windows.Forms.RadioButton radioButton_TypeDetermin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox_Units;
        private System.Windows.Forms.CheckBox checkBox_NoEarlier;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.DataGridView dataGridView_Units;
        private System.Windows.Forms.DateTimePicker dateTimePicker_AfterDate;
        private System.Windows.Forms.Label label5;
    }
}