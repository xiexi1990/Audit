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
        public OraHelper orah;
        public DataView dv_bitem, dv_abtype2, dv_stations;
        public DataTable dt_abtype2, dt_units, dt_stations;
        public string[] science, bitem, unitcode, abtype, abtype2, stationid;
        public string sql;
        public bool text_change_observe = false, firstshown = true;
 

        public GSetRule(OraHelper orah, DataTable dt_science, DataTable dt_bitem, DataTable dt_units, DataTable dt_abtype, DataTable dt_abtype2, DataTable dt_stations)
        {
            InitializeComponent();
            this.orah = orah;

            dataGridView_Science.DataSource = dt_science;
            dataGridView_Science.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dt_units = dt_units.Copy();
            this.dt_units.Columns.Remove("NUM");
            this.dt_units.Columns.Add("NUM", typeof(int));
            dataGridView_Unit.DataSource = this.dt_units;
            dataGridView_Unit.Columns["UNIT_CODE"].Visible = false;

            dataGridView_Unit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dv_bitem = new DataView(dt_bitem);
            dataGridView_Bitem.DataSource = dv_bitem;
            dataGridView_Bitem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Bitem.Columns["SCIENCE"].Visible = false;

            dataGridView_AbType.DataSource = dt_abtype;
            dataGridView_AbType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_AbType.Columns["AB_TYPE"].Visible = false;
            dataGridView_AbType.Columns["AB_ID"].Visible = false;

            this.dt_abtype2 = dt_abtype2.Copy();
            this.dt_abtype2.Columns.Add("NUM", typeof(int));
            dv_abtype2 = new DataView(this.dt_abtype2);

            dataGridView_AbType2.DataSource = dv_abtype2;
            dataGridView_AbType2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_AbType2.Columns["AB_ID"].Visible = false;
            dataGridView_AbType2.Columns["TYPE2_ID"].Visible = false;
            dataGridView_AbType2.Columns["SCIENCE"].Visible = false;

            this.dt_stations = dt_stations.Copy();
            this.dt_stations.Columns.Add("NUM", typeof(int));
            dv_stations = new DataView(this.dt_stations);
            dataGridView_Station.DataSource = dv_stations;
            dataGridView_Station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Station.Columns["UNITCODE"].Visible = false;
            dataGridView_Station.Columns["STATIONID"].Visible = false;

            dateTimePicker_Begin.Value = DateTime.Parse("2015/1/1 00:00:00");
            dateTimePicker_Begin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Begin.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimePicker_End.Value = DateTime.Parse("2015/12/31 23:59:59");
            dateTimePicker_End.Format = DateTimePickerFormat.Custom;
            dateTimePicker_End.CustomFormat = "yyyy/MM/dd HH:mm:ss";
      //      richTextBox_Sql.ReadOnly = true;

            button_CalType2Num.BackColor = button_CalUnitNum.BackColor = button_CalStationNum.BackColor = Color.PaleVioletRed;

        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            this.sql = richTextBox_Sql.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

      //      SaveStatus(this.gssav);
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
     //       MessageBox.Show("show");
            if (firstshown)
            {
                firstshown = false;
                dataGridView_Science.ClearSelection();
                dataGridView_Bitem.ClearSelection();
                dataGridView_Unit.ClearSelection();
                dataGridView_AbType.ClearSelection();
                dataGridView_AbType2.ClearSelection();
                dataGridView_Station.ClearSelection();
            }
            text_change_observe = true;
        }

        private void RefreshSql()
        {
            SqlGenerator sg = new SqlGenerator();
            richTextBox_Sql.Text = sg.GenGSetSql(GSetSqlType.Normal, science, bitem, unitcode, abtype, abtype2, stationid, checkBox_NationGood.Checked, checkBox_AreaGood.Checked, checkBox_ScienceGood.Checked, dateTimePicker_Begin.Value, dateTimePicker_End.Value, checkBox_BeginTrim.Checked ? dateTimePicker_Begin.Value : (DateTime?)null, checkBox_EndTrim.Checked ? dateTimePicker_End.Value : (DateTime?)null);
        }

        private string AbTypeNameToId(string abtypename)
        {
            switch(abtypename)
            {
                case "正常动态": return "1";
                case "观测系统": return "2";
                case "自然环境": return "3";
                case "场地环境": return "4";
                case "人为干扰": return "5";
                case "地球物理事件": return "6";
                case "不明原因": return "7";
                default: return "";
            }
        }

        private string ScienceNameToCode(string sciencename)
        {
            switch (sciencename)
            {
                case "形变": return "XB";
                case "重力": return "ZL";
                case "地磁": return "DC";
                case "地电": return "DD";
                case "流体": return "LT";
                default: return "";
            }
        }

        private void SetAbType2Filter()
        {
            string f1 = "";
            if (science != null)
            {
                for (int i = 0; i < science.GetLength(0); i++)
                {
                    f1 += "science = '" + ScienceNameToCode(science[i]) + "' or ";
                }
            }
            if (f1 != "")
            {
                f1 = f1.Remove(f1.Length - 3);
            }
            string f2 = "";
            if (abtype != null)
            {
                for (int i = 0; i < abtype.GetLength(0); i++)
                {
                    f2 += "ab_id = '" + AbTypeNameToId(abtype[i]) + "' or ";
                }
            }
            if (f2 != "")
            {
                f2 = f2.Remove(f2.Length - 3);
            }

            if (f1 != "" && f2 != "")
            {
                dv_abtype2.RowFilter = string.Format("({0}) and ({1})", f1, f2);
            }
            else if (f1 == "" && f2 == "")
            {
                dv_abtype2.RowFilter = null;
            }
            else
            {
                dv_abtype2.RowFilter = f1 + f2;
            }
            dataGridView_AbType2.ClearSelection();
        }

        private void richTextBox_Science_TextChanged(object sender, EventArgs e)
        {
            if (!text_change_observe)
                return;
            science = richTextBox_Science.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            string f = "";
            for(int i = 0; i < science.GetLength(0); i++)
            {
                f += "science = '" + science[i] + "' or ";
            }
            if (f != "")
            {
                dv_bitem.RowFilter = f.Remove(f.Length - 3);
            }
            else
            {
                dv_bitem.RowFilter = null;
            }
            dataGridView_Bitem.ClearSelection();
            SetAbType2Filter();
            RefreshSql();
        }

        private void richTextBox_Bitem_TextChanged(object sender, EventArgs e)
        {
            if (!text_change_observe)
                return;
            bitem = richTextBox_Bitem.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            RefreshSql();
        }

        private void richTextBox_Unit_TextChanged(object sender, EventArgs e)
        {
            if (!text_change_observe)
                return;
            unitcode = richTextBox_Unit.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            string f = "";
            for (int i = 0; i < unitcode.GetLength(0); i++)
            {
                f += "unitcode = '" + unitcode[i] + "' or ";
            }
            if (f != "")
            {
                dv_stations.RowFilter = f.Remove(f.Length - 3);
            }
            else
            {
                dv_stations.RowFilter = null;
            }
            dataGridView_Station.ClearSelection();
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

        private void dataGridView_AbType_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            for (int i = dataGridView_AbType.SelectedRows.Count - 1; i >= 0; i--)
            {
                s += dataGridView_AbType.SelectedRows[i].Cells["AB_TYPE_NAME"].Value + " ";
            }
            richTextBox_AbType.Text = s;
        }

        private void dataGridView_AbType2_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            for (int i = dataGridView_AbType2.SelectedRows.Count - 1; i >= 0; i--)
            {
                s += dataGridView_AbType2.SelectedRows[i].Cells["TYPE2_ID"].Value + " ";
            }
            richTextBox_AbType2.Text = s;
        }

        private void richTextBox_AbType_TextChanged(object sender, EventArgs e)
        {
            if (!text_change_observe)
                return;
            abtype = richTextBox_AbType.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            SetAbType2Filter();
            RefreshSql();
        }

        private void richTextBox_AbType2_TextChanged(object sender, EventArgs e)
        {
            if (!text_change_observe)
                return;
            abtype2 = richTextBox_AbType2.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            RefreshSql();
        }

        private void button_CalType2Num_Click(object sender, EventArgs e)
        {
            label_CalType2.Text = "计算中……";
            SqlGenerator sg = new SqlGenerator();
            string csql = sg.GenGSetSql(GSetSqlType.CalType2Num, science, bitem, unitcode, abtype, abtype2, stationid, checkBox_NationGood.Checked, checkBox_AreaGood.Checked, checkBox_ScienceGood.Checked, dateTimePicker_Begin.Value, dateTimePicker_End.Value, checkBox_BeginTrim.Checked ? dateTimePicker_Begin.Value : (DateTime?)null, checkBox_EndTrim.Checked ? dateTimePicker_End.Value : (DateTime?)null);
            DataTable dt = orah.GetDataTable(csql);
            int sum = 0;
            foreach (DataRow r in this.dt_abtype2.Rows)
            {
                DataTableHelper dth = new DataTableHelper();
                int? num = dth.ExtractRowByLeftFirstCol_Int(dt, r["TYPE2_ID"].ToString());
                if (num == null)
                    r["NUM"] = DBNull.Value;
                else
                {
                    r["NUM"] = num;
                    sum += (int)num;
                }
            }
            label_CalType2.Text = sum.ToString();
            richTextBox_Debug.Text += csql + "\n";
        }

        private void button_CalUnitNum_Click(object sender, EventArgs e)
        {
            label_CalUnit.Text = "计算中……";
            SqlGenerator sg = new SqlGenerator();
            string csql = sg.GenGSetSql(GSetSqlType.CalUnitNum, science, bitem, unitcode, abtype, abtype2, stationid, checkBox_NationGood.Checked, checkBox_AreaGood.Checked, checkBox_ScienceGood.Checked, dateTimePicker_Begin.Value, dateTimePicker_End.Value, checkBox_BeginTrim.Checked ? dateTimePicker_Begin.Value : (DateTime?)null, checkBox_EndTrim.Checked ? dateTimePicker_End.Value : (DateTime?)null);
            DataTable dt = orah.GetDataTable(csql);
            int sum = 0;
            foreach (DataRow r in this.dt_units.Rows)
            {
                DataTableHelper dth = new DataTableHelper();
                int? num = dth.ExtractRowByLeftFirstCol_Int(dt, r["UNIT_CODE"].ToString());
                if (num == null)
                    r["NUM"] = DBNull.Value;
                else
                {
                    r["NUM"] = num;
                    sum += (int)num;
                }
            }
            label_CalUnit.Text = sum.ToString();
            richTextBox_Debug.Text += csql + "\n";
        }

        private void button_CalStationNum_Click(object sender, EventArgs e)
        {
            label_CalStation.Text = "计算中……";
            SqlGenerator sg = new SqlGenerator();
            string csql = sg.GenGSetSql(GSetSqlType.CalStationNum, science, bitem, unitcode, abtype, abtype2, stationid, checkBox_NationGood.Checked, checkBox_AreaGood.Checked, checkBox_ScienceGood.Checked, dateTimePicker_Begin.Value, dateTimePicker_End.Value, checkBox_BeginTrim.Checked ? dateTimePicker_Begin.Value : (DateTime?)null, checkBox_EndTrim.Checked ? dateTimePicker_End.Value : (DateTime?)null);
            DataTable dt = orah.GetDataTable(csql);
            int sum = 0;
            foreach (DataRow r in this.dt_stations.Rows)
            {
                DataTableHelper dth = new DataTableHelper();
                int? num = dth.ExtractRowByLeftFirstCol_Int(dt, r["STATIONID"].ToString());
                if (num == null)
                    r["NUM"] = DBNull.Value;
                else
                {
                    r["NUM"] = num;
                    sum += (int)num;
                }
            }
            label_CalStation.Text = sum.ToString();
            richTextBox_Debug.Text += csql + "\n";
        }

        private void dataGridView_Station_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            for (int i = dataGridView_Station.SelectedRows.Count - 1; i >= 0; i--)
            {
                s += dataGridView_Station.SelectedRows[i].Cells["STATIONID"].Value + " ";
            }
            richTextBox_Station.Text = s;
        }

        private void richTextBox_Station_TextChanged(object sender, EventArgs e)
        {
            if (!text_change_observe)
                return;
            stationid = richTextBox_Station.Text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            RefreshSql();
        }

        private void GSetRule_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  MessageBox.Show("close");
        }

        private void GSetRule_Load(object sender, EventArgs e)
        {
            this.text_change_observe = false;
        }
    }
}
