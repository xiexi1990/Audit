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
            if (false)
            {
                bool has_red = false;
                bool has_blank = false;
                foreach (DataGridViewRow r in dataGridView_Logs.Rows)
                {
                    if (r == null || r.DataBoundItem == null)
                        continue;
                    if (r.Cells["LOG_ID"].Style.BackColor == Color.Red)
                    {
                        has_red = true;
                    }
                    DataRow dr = (r.DataBoundItem as DataRowView).Row;
                    if (!(!(dr["SCORE_GROUP"] is DBNull) && dr.Field<double>("SCORE_GROUP") < 0 &&
                        !(dr["SCORE_TIME"] is DBNull) && dr.Field<double>("SCORE_TIME") < 0 &&
                        !(dr["SCORE_LOG1"] is DBNull) && dr.Field<double>("SCORE_LOG1") < 0 &&
                        !(dr["SCORE_GRAPH"] is DBNull) && dr.Field<double>("SCORE_GRAPH") < 0))
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
                    p.dt_itemloginfo = this.dt_itemloginfo.Copy();
                    p.dt_units = this.dt_units.Copy();
                    backgroundWorker_ReportWriter.RunWorkerAsync(p);
                }
                else
                    MessageBox.Show("报表生成器正忙！");
            }
        }
        private void backgroundWorker_ReportWriter_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                RefreshStatus("正在生成报表……\n");
                ReportWriterParam p = e.Argument as ReportWriterParam;
                DataView dv_log = new DataView(p.dt_logs);
                DataView dv_units = new DataView(p.dt_units);
                //     DataTable units = dv_log.ToTable(true, "UNITNAME");
                DataTable output = new DataTable();
                output.Columns.Add("单位名称");
                output.Columns.Add("序号");
                output.Columns.Add("事件ID");
                output.Columns.Add("台站ID");
                output.Columns.Add("台站名称");
                output.Columns.Add("测点");
                output.Columns.Add("仪器编码");
                output.Columns.Add("仪器名称");
                output.Columns.Add("起始时间", typeof(DateTime));
                output.Columns.Add("结束时间", typeof(DateTime));
                output.Columns.Add("事件类型");

                output.Columns.Add("事件分类");
                output.Columns.Add("事件分类说明");
                output.Columns.Add("事件分类得分");
                output.Columns.Add("起止时间");
                output.Columns.Add("起止时间说明");
                output.Columns.Add("起止时间得分");
                output.Columns.Add("图件标注扣分点");
                output.Columns.Add("图件标注说明");
                output.Columns.Add("图件标注得分");
                output.Columns.Add("事件信息描述扣分点");
                output.Columns.Add("事件调查研究");
                output.Columns.Add("事件调查研究加分");
                output.Columns.Add("处置措施与结果");
                output.Columns.Add("事件分析及描述说明");
                output.Columns.Add("事件分析及描述得分");
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
                        r["事件ID"] = "'" + dv_log[i]["LOG_ID"];
                        r["台站ID"] = "'" + dv_log[i]["STATIONID"];
                        r["台站名称"] = "'" + dv_log[i]["STATIONNAME"];

                        r["测点"] = "'" + dv_log[i]["POINTID"];
                        r["仪器编码"] = "'" + dv_log[i]["INSTRCODE"];
                        r["仪器名称"] = dv_log[i]["INSTRNAME"];
                        r["起始时间"] = dv_log[i]["START_DATE"];
                        r["结束时间"] = dv_log[i]["END_DATE"];
                        r["事件类型"] = dv_log[i]["AB_TYPE_NAME"];

                        double s_group = Convert.ToDouble(dv_log[i]["SCORE_GROUP"]);
                        r["事件分类"] = s_group == 0 ? "错误" : "正确";
                        r["事件分类说明"] = dv_log[i]["COMMENTS_GROUP"];
                        double s_time = Convert.ToDouble(dv_log[i]["SCORE_TIME"]);
                        r["起止时间"] = s_time == 0 ? "错误" : "正确";
                        r["起止时间说明"] = dv_log[i]["COMMENTS_TIME"];
                        double s_graph = Convert.ToDouble(dv_log[i]["SCORE_GRAPH"]);
                        r["图件标注扣分点"] = Math.Round((8 - s_graph) / (8.0 / 3), 1);
                        r["图件标注说明"] = dv_log[i]["COMMENTS_GRAPH"];
                        double s_log1 = Convert.ToDouble(dv_log[i]["SCORE_LOG1"]);
                        r["事件信息描述扣分点"] = Math.Round((9 - s_log1) / (9.0 / 3), 1);
                        double s_log2 = Convert.ToDouble(dv_log[i]["SCORE_LOG2"]);
                        if (s_log2 == 9)
                            r["事件调查研究"] = "好";
                        else if (s_log2 == 0)
                            r["事件调查研究"] = "差";
                        else
                            r["事件调查研究"] = "中";
                        double s_log2plus = Convert.ToDouble(dv_log[i]["SCORE_LOG2PLUS"]);
                        if (s_log2plus > 0)
                        {
                            r["事件调查研究加分"] = "是";
                        }
                        else
                        {
                            r["事件调查研究加分"] = "";
                        }
                        double s_log3 = Convert.ToDouble(dv_log[i]["SCORE_LOG3"]);
                        if (s_log3 == 2)
                            r["处置措施与结果"] = "好";
                        else if (s_log3 == 0)
                            r["处置措施与结果"] = "差";
                        else
                            r["处置措施与结果"] = "中";
                        r["事件分析及描述说明"] = dv_log[i]["COMMENTS_LOG"];

                        double vlog2 = s_log2 + s_log2plus;
                        if (vlog2 > 9)
                            vlog2 = 9;
                        double s_whole = s_group + s_time + s_graph + s_log1 + vlog2 + s_log3;
                        if (s_whole >= 21 && s_whole < 28)
                            r["国家中心审核"] = "中";
                        else if (s_whole >= 0 && s_whole < 21)
                            r["国家中心审核"] = "差";
                        else
                            r["国家中心审核"] = "好";

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

                        sum_group += s_group;
                        sum_time += s_time;
                        sum_graph += s_graph;
                        sum_log += s_log1 + vlog2 + s_log3;
                        sum_checkright += 1.0 - s_checkright;

                        output.Rows.Add(r);
                    }
                    if (i > 0)
                    {
                        output.Rows[h]["单位名称"] = u_name;
                        double sum = 0;
                        output.Rows[h]["事件分类得分"] = sum_group / i;
                        output.Rows[h]["起止时间得分"] = sum_time / i;
                        output.Rows[h]["图件标注得分"] = sum_graph / i;
                        output.Rows[h]["事件分析及描述得分"] = sum_log / i;
                        output.Rows[h]["审核正确率得分"] = sum_checkright * 2.0 / i;
                        output.Rows[h]["合计"] = Convert.ToDouble(output.Rows[h]["事件分类得分"]) +
                            Convert.ToDouble(output.Rows[h]["起止时间得分"]) +
                            Convert.ToDouble(output.Rows[h]["图件标注得分"]) +
                            Convert.ToDouble(output.Rows[h]["事件分析及描述得分"]) +
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
                DataTableHelper dth = new DataTableHelper();
                dth.DTToExcel(output, p.filename, true, false);
                RefreshStatus("写入完毕");
            }
            catch (Exception exc)
            {
                RefreshStatus("ReportWriter error: \n" + exc.Message);
            }
        }


        private void backgroundWorker_ReportWriter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

    }
}