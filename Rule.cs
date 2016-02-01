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
    public partial class Rule : Form
    {
        public string[,] unit_num = null;
        public DateTime after_date;
        public bool no_earlier = true;
        public Rule(DataTable dt_units)
        {
            InitializeComponent();
            radioButton_TimeDetermin.Checked = true;
            radioButton_TypeDetermin.Checked = true;
            this.dataGridView_Units.DataSource = dt_units;
            this.dataGridView_Units.Columns[0].Visible = false;
            this.dataGridView_Units.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.checkBox_NoEarlier.Checked = true;

            if (true)
            {
                dateTimePicker_AfterDate.Value = new DateTime(2014, 9, 1);
                richTextBox_Units.Text = @"辽宁省 20,河南省 15,湖北省 15";
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {   
            for(int i = dataGridView_Units.SelectedRows.Count - 1; i >= 0; i--)
            {
                richTextBox_Units.Text += 
                dataGridView_Units.SelectedRows[i].Cells["unitname"].Value + " " +
                    dataGridView_Units.SelectedRows[i].Cells["num"].Value + ",";
            }
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            
            string[] p1 = richTextBox_Units.Text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            unit_num = new string[p1.GetLength(0), 3];
            for(int i = 0; i < p1.GetLength(0); i++)
            {
                string[] p2 = p1[i].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                if (p2.GetLength(0) != 2)
                {
                    MessageBox.Show("错误：解析字符串 " + p1[i] + " 失败");
                    return;
                }
                unit_num[i, 0] = p2[0];
                unit_num[i, 1] = p2[1];
                bool find = false;
                foreach (DataRow r in ((DataTable)this.dataGridView_Units.DataSource).Rows)
                {
                    if (r["unitname"].ToString() == p2[0])
                    {
                        find = true;
                        unit_num[i, 2] = r["unit_code"].ToString();
                        break;
                    }
                }
                if (find == false)
                {
                    MessageBox.Show("错误：未从省局列表中找到 " + p2[0]);
                    return;
                }
            }
            this.no_earlier = this.checkBox_NoEarlier.Checked;
            this.after_date = this.dateTimePicker_AfterDate.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
