using System.Data;
using excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
namespace Audit
{
    public partial class MainFrame : Form
    {
        private void button_Output_Click(object sender, EventArgs e)
        {
            bool has_red = false;
            bool has_blank = false;
            foreach (DataGridViewRow r in dataGridView_Logs.Rows)
            {
                if (r.Cells["LOG_ID"].Style.BackColor == Color.Red)
                {
                    has_red = true;
                }
                if (!(r.Cells["UNITNAME"].Style.BackColor == Color.LightGreen || r.Cells["UNITNAME"].Style.BackColor == Color.Yellow || r.Cells["UNITNAME"].Style.BackColor == Color.PaleVioletRed))
                {
                    has_blank = true;
                }
                if (has_red && has_blank)
                    break;
            }
            if (has_blank)
            {
                if (MessageBox.Show("检测到存在未审核事件，是否强行生成？", "生成报表", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }
            if (has_red)
            {
                if (MessageBox.Show("检测到存在LOG_ID冲突，是否强行生成？", "生成报表", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel文件|*.xlsx";
            sd.FilterIndex = 1;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                if (backgroundWorker_ReportWriter.IsBusy == false)
                {
                    ReportWriterParam p = new ReportWriterParam();
                    p.filename = sd.FileName;
                    lock (locker_dt_logs)
                    {
                        p.dt_logs = this.dt_logs.Copy();
                    }
                    p.dt_check = this.dt_check.Copy();
                    p.dt_units = this.dt_units.Copy();
                    backgroundWorker_ReportWriter.RunWorkerAsync(p);
                }
                else
                    MessageBox.Show("报表生成器正忙！");
            }
        }
        private void backgroundWorker_ReportWriter_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            RefreshStatus("正在生成报表……\n");
            ReportWriterParam p = e.Argument as ReportWriterParam;
            DataView dv_log = new DataView(p.dt_logs);
            DataView dv_units = new DataView(p.dt_units);
            //     DataTable units = dv_log.ToTable(true, "UNITNAME");
            DataTable output = new DataTable();
            output.Columns.Add("单位名称");
            output.Columns.Add("序号");
            output.Columns.Add("事件记录关键信息");
            output.Columns.Add("事件分类");
            output.Columns.Add("事件分类说明");
            output.Columns.Add("事件分类得分");
            output.Columns.Add("起止时间");
            output.Columns.Add("起止时间说明");
            output.Columns.Add("起止时间得分");
            output.Columns.Add("图件标注");
            output.Columns.Add("图件标注说明");
            output.Columns.Add("图件标注得分");
            output.Columns.Add("事件分析");
            output.Columns.Add("事件分析说明");
            output.Columns.Add("事件分析得分");
            output.Columns.Add("国家中心审核");
            output.Columns.Add("区域中心审核");
            output.Columns.Add("审核正确率得分");
            output.Columns.Add("合计");

            int j = 0, h = 0;
            for (int k = 0; k < UNIT_NUM.GetLength(0); k++)
            {
                dv_units.RowFilter = dv_log.RowFilter = "UNIT_CODE = '" + UNIT_NUM[k, 0] + "'";
                string u_name;
                if (dv_units.Count > 0)
                {
                    u_name = dv_units[0]["UNITNAME"].ToString();
                }
                else
                {
                    u_name = UNIT_NUM[k, 0].ToString();
                }
                RefreshStatus("正在生成" + u_name + "……", true);
            
                if (Convert.ToInt32(UNIT_NUM[k, 1]) == 0)
                {
                    DataRow r = output.NewRow();
                    r["单位名称"] = u_name;
                    output.Rows.Add(r);
                    j++;
                    continue;
                }
                int i = 0;
                double sum_group = 0, sum_time = 0, sum_graph = 0, sum_log = 0, sum_checkright = 0;

                h = j;
                for (; i < Math.Min(dv_log.Count, Convert.ToInt32(UNIT_NUM[k, 1])); i++, j++)
                {
                    DataRow r = output.NewRow();
                    r["序号"] = i + 1;
                    r["事件记录关键信息"] = dv_log[i]["LOG_ID"];
                    int s_group = Convert.ToInt32(dv_log[i]["SCORE_GROUP"]);
                    r["事件分类"] = s_group == 0 ? "正确" : "错误";
                    r["事件分类说明"] = dv_log[i]["COMMENTS_GROUP"];
                    int s_time = Convert.ToInt32(dv_log[i]["SCORE_TIME"]);
                    r["起止时间"] = s_time == 0 ? "正确" : "错误";
                    r["起止时间说明"] = dv_log[i]["COMMENTS_TIME"];
                    int s_graph = Convert.ToInt32(dv_log[i]["SCORE_GRAPH"]);
                    r["图件标注"] = s_graph == 0 ? "好" : s_graph == 1 ? "中" : "差";
                    r["图件标注说明"] = dv_log[i]["COMMENTS_GRAPH"];
                    int s_log = Convert.ToInt32(dv_log[i]["SCORE_LOG"]);
                    r["事件分析"] = s_log == 0 ? "好" : s_log == 1 ? "中" : "差";
                    r["事件分析说明"] = dv_log[i]["COMMENTS_LOG"];

                    int s_whole = s_group * 2 + s_time * 2 + s_graph + s_log;
                    if (s_whole > 2)
                        s_whole = 2;
                    r["国家中心审核"] = s_whole == 0 ? "好" : s_whole == 1 ? "中" : "差";

                    CheckResultHelper cr = new CheckResultHelper();
                    cr.Fill(p.dt_check, dv_log[i]["LOG_ID"].ToString());

                    r["区域中心审核"] = cr.wholeresult[0] == -1 ? "未审核" : (cr.wholeresult[0] == 0 ? "好" : cr.wholeresult[0] == 1 ? "中" : "差");
                    int s_checkright;
                    if (((cr.wholeresult[0] == -1 || cr.wholeresult[0] == 0) && s_whole == 2) ||
                        (cr.wholeresult[0] == 2 && s_whole == 0))
                    {
                        s_checkright = 1;
                    }
                    else
                    {
                        s_checkright = 0;
                    }

                    sum_group += 1.0 - s_group;
                    sum_time += 1.0 - s_time;
                    sum_graph += 1.0 - s_graph / 2.0;
                    sum_log += 1.0 - s_log / 2.0;
                    sum_checkright += 1.0 - s_checkright;

                    output.Rows.Add(r);
                }
                if (i > 0)
                {
                    output.Rows[h]["单位名称"] = u_name;
                    double sum = 0;
                    output.Rows[h]["事件分类得分"] = sum_group * 2.0 / i;
                    output.Rows[h]["起止时间得分"] = sum_time * 1.0 / i;
                    output.Rows[h]["图件标注得分"] = sum_graph * 2.0 / i;
                    output.Rows[h]["事件分析得分"] = sum_log * 2.0 / i;
                    output.Rows[h]["审核正确率得分"] = sum_checkright * 1.0 / i;
                    output.Rows[h]["合计"] = Convert.ToDouble(output.Rows[h]["事件分类得分"]) +
                        Convert.ToDouble(output.Rows[h]["起止时间得分"]) +
                        Convert.ToDouble(output.Rows[h]["图件标注得分"]) +
                        Convert.ToDouble(output.Rows[h]["事件分析得分"]) +
                        Convert.ToDouble(output.Rows[h]["审核正确率得分"]);

                }
                for (; i < Convert.ToInt32(UNIT_NUM[k, 1]); i++, j++)
                {
                    DataRow r = output.NewRow();
                    if (i == 0)
                    {
                        r["单位名称"] = u_name;
                    }
                    output.Rows.Add(r);
                }
            }
            RefreshStatus("生成完毕", true);
            RefreshStatus("正在写入Excel文件……");
            DTToExcel(output, p.filename);
            RefreshStatus("写入完毕");
        }

        public void DTToExcel(DataTable dt, string filename)
        {
            DataTableHelper dh = new DataTableHelper();
            object[,] t = dh.DataTableTo2DTable(dt);
            excel.Application eapp = new excel.Application();
            excel.Workbook book = eapp.Workbooks.Add();
            excel.Worksheet sheet = book.Worksheets[1];

            sheet.Range["A1", sheet.Cells[t.GetLength(0) , t.GetLength(1) ]].Value = t;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        sheet.Cells[j + 1][i + 1] = dt.Rows[i][j];
            //    }
            //}
            eapp.Visible = true;
            book.SaveAs(filename);
        }

        private void backgroundWorker_ReportWriter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

    }
}