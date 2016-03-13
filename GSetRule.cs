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
    public partial class GSetRule : Form
    {
        public DataView dv_bitem;
        public string[] science, bitem, unitcode;
        public string sql;
        public GSetRule(DataTable dt_science, DataTable dt_bitem, DataTable dt_units)
        {
            InitializeComponent();
            dataGridView_Science.DataSource = dt_science;
            dataGridView_Science.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Unit.DataSource = dt_units;
    //        dataGridView_Unit.Columns["UNIT_CODE"].Visible = false;
            dataGridView_Unit.Columns["NUM"].Visible = false;
            dataGridView_Unit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dv_bitem = new DataView(dt_bitem);
            dataGridView_Bitem.DataSource = dv_bitem;
            dataGridView_Bitem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dateTimePicker_Begin.Value = DateTime.Parse("2015/1/1 00:00:00");
            dateTimePicker_Begin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Begin.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimePicker_End.Value = DateTime.Parse("2015/12/31 23:59:59");
            dateTimePicker_End.Format = DateTimePickerFormat.Custom;
            dateTimePicker_End.CustomFormat = "yyyy/MM/dd HH:mm:ss";
      //      richTextBox_Sql.ReadOnly = true;
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            this.sql = richTextBox_Sql.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void dataGridView_Science_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            for (int i = dataGridView_Science.SelectedRows.Count - 1; i >= 0; i--)
            {
                s += dataGridView_Science.SelectedRows[i].Cells[0].Value + " ";
            }
            richTextBox_Science.Text = s;
        }

        private void dataGridView_Bitem_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            for (int i = dataGridView_Bitem.SelectedRows.Count - 1; i >= 0; i--)
            {
                s += dataGridView_Bitem.SelectedRows[i].Cells[0].Value + " ";
            }
            richTextBox_Bitem.Text = s;

        }

        private void dataGridView_Unit_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            for (int i = dataGridView_Unit.SelectedRows.Count - 1; i >= 0; i--)
            {
                s += dataGridView_Unit.SelectedRows[i].Cells[0].Value + " ";
            }
            richTextBox_Unit.Text = s;
        }

        private void GSetRule_Shown(object sender, EventArgs e)
        {
            dataGridView_Science.ClearSelection();
            dataGridView_Bitem.ClearSelection();
            dataGridView_Unit.ClearSelection();
        }

        private void RefreshSql()
        {
            SqlGenerator sg = new SqlGenerator();
            richTextBox_Sql.Text = sg.GenGSetSql(science, bitem, unitcode, checkBox_NationGood.Checked, checkBox_AreaGood.Checked, checkBox_ScienceGood.Checked, dateTimePicker_Begin.Value, dateTimePicker_End.Value, checkBox_BeginTrim.Checked ? dateTimePicker_Begin.Value : (DateTime?)null, checkBox_EndTrim.Checked ? dateTimePicker_End.Value : (DateTime?)null);
        }

        private void richTextBox_Science_TextChanged(object sender, EventArgs e)
        {
            science = richTextBox_Science.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            RefreshSql();
        }

        private void richTextBox_Bitem_TextChanged(object sender, EventArgs e)
        {
            bitem = richTextBox_Bitem.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            RefreshSql();
        }

        private void richTextBox_Unit_TextChanged(object sender, EventArgs e)
        {
            unitcode = richTextBox_Unit.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            RefreshSql();
        }

        private void dateTimePicker_Begin_ValueChanged(object sender, EventArgs e)
        {
            RefreshSql();
        }

        private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
        {
            RefreshSql();
        }

        private void checkBox_BeginTrim_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSql();
        }

        private void checkBox_EndTrim_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSql();
        }

        private void checkBox_NationGood_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSql();
        }

        private void checkBox_AreaGood_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSql();
        }

        private void checkBox_ScienceGood_CheckedChanged(object sender, EventArgs e)
        {
            RefreshSql();
        }
    }
}
