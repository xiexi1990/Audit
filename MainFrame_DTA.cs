using System.Windows.Forms;
using System.Data;
using System;
using System.ComponentModel;
using System.IO;

namespace Audit
{
    public partial class MainFrame : Form
    {
        private void backgroundWorker_DTAccessor_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                DTAccessorParam p = e.Argument as DTAccessorParam;
                if (p.type == DTAccessorParamType.Add)
                {
                    RefreshStatus("正在加载文件……");
                    DataSet ds = new DataSet();
                    ds.ReadXml(p.filename, XmlReadMode.ReadSchema);
                    bool vali = true;
                    try
                    {
                        if (Convert.ToDouble(ds.DataSetName) < 1.5)
                            vali = false;
                    }
                    catch
                    {
                        vali = false;
                    }
                    if (!vali)
                        throw new Exception("版本不兼容，无法读取");

                    int pn = dt_logs.Rows.Count;
                    this.Invoke(new Param0Callback(() =>
                    {
                        if (ds.Tables["dt_logs"] != null)
                        {
                            lock (locker_dt_logs)
                            {
                                dt_logs.Merge(ds.Tables["dt_logs"]);
                            }
                        }
                        if (ds.Tables["dt_check"] != null)
                        {
                            dt_check.Merge(ds.Tables["dt_check"]);
                            dt_check = new DataView(dt_check).ToTable(true);
                        }
                        if (ds.Tables["dt_itemloginfo"] != null)
                        {
                            dt_itemloginfo.Merge(ds.Tables["dt_itemloginfo"]);
                            dt_itemloginfo = new DataView(dt_itemloginfo).ToTable(true);
                        }
                        if (ds.Tables["dt_units_comments"] != null)
                        {
                            lock (locker_dt_units_comments)
                            {
                                //                 dt_units_comments.Merge(ds.Tables["dt_units_comments"]);
                            }
                        }
                        if (ds.Tables["dt_param"] != null)
                        {
                            lock (locker_dt_param)
                            {
                            }
                        }
                        RefreshStatus("文件加载成功，共加载" + (dt_logs.Rows.Count - pn) + "条");
                        this.CheckAllColor();
                    }
                    ));
                }
                else if (p.type == DTAccessorParamType.Save)
                {
                    if (!p.save_tmp)
                        RefreshStatus("正在保存文件……");
                    DataSet ds = new DataSet("1.5");
                    this.Invoke(new Param0Callback(() =>
                        {
                            ds.Tables.Add(dt_logs.Copy());
                            ds.Tables.Add(dt_check.Copy());
                            ds.Tables.Add(dt_itemloginfo.Copy());
                            ds.Tables.Add(dt_units_comments.Copy());
                            ds.Tables.Add(dt_param.Copy());
                        }
                        ));
                    ds.WriteXml(p.filename, XmlWriteMode.WriteSchema);
                    if (!p.save_tmp)
                    {
                        RefreshStatus("文件保存成功");
                        this.Invoke(new Param0Callback(() => MessageBox.Show("保存成功！", "保存")));
                    }
                }
                else
                {
                }
                if (!p.save_tmp)
                {
                    this.Invoke(new Param0Callback(() =>
                    {
                        newsaved = true;
                        this.Text = p.filename + "  保存于" + File.GetLastWriteTime(p.filename).ToString("yyyy/MM/dd HH:mm:ss");
                        if (p.type == DTAccessorParamType.Add && dt_logs.Rows.Count > 0)
                        {
                            this.log_shown = true;
                            this.ShowLog(dt_logs.Rows[0]);
                        }
                    }));
                    cur_file = p.filename;
                }
                else
                {
                    this.Invoke(new Param0Callback(() =>
                        {
                            newsaved_tmp = true;
                        }));
                }
            }
            catch (Exception exc)
            {
                RefreshStatus("DTAccessor error: \n" + exc.Message);
            }
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            if (cur_file == null)
            {
                MenuItem_SaveAs_Click(null, null);
            }
            else
            {
                if (backgroundWorker_DTAccessor.IsBusy == false)
                {
                    backgroundWorker_DTAccessor.RunWorkerAsync(new DTAccessorParam(DTAccessorParamType.Save, cur_file));
                }
                else
                    MessageBox.Show("文件保存器正忙！");
            }
        }

        private void MenuItem_SaveSchema_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "info文件|*.info";
            sd.FilterIndex = 1;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet("1.5");
                ds.Tables.Add(dt_logs.Clone());
                ds.Tables.Add(dt_check.Clone());
                ds.Tables.Add(dt_itemloginfo.Clone());
                ds.Tables.Add(dt_units);
                ds.Tables.Add(dt_item);
                ds.Tables.Add(dt_abtype);
                ds.Tables.Add(dt_abtype2);
                ds.Tables.Add(dt_stations);
                ds.WriteXml(sd.FileName, XmlWriteMode.WriteSchema);
            }
        }

        private void MenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            Saving(false, false);
        }

        private void MenuItem_Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "dt文件|*.dt";
            od.FilterIndex = 1;
            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (backgroundWorker_DTAccessor.IsBusy == false)
                {
                    backgroundWorker_DTAccessor.RunWorkerAsync(new DTAccessorParam(DTAccessorParamType.Add, od.FileName));
                }
                else
                    MessageBox.Show("文件存取器正忙！");
            }
        }

        private DialogResult Saving(bool confirm, bool syn)
        {
            DialogResult r0;
            if (confirm)
            {
                r0 = MessageBox.Show("是否保存当前内容？", "保存", MessageBoxButtons.YesNoCancel);
            }
            else
            {
                r0 = DialogResult.Yes;
            }
            if (r0 == System.Windows.Forms.DialogResult.Cancel)
            {
                return DialogResult.Cancel;
            }
            else if (r0 == System.Windows.Forms.DialogResult.No)
            {
                return DialogResult.No;
            }
            else
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "dt文件|*.dt";
                sd.FilterIndex = 1;
                if (cur_file != null)
                {
                    string[] ff = cur_file.Split('\\');
                    if (ff.Length - 1 >= 0)
                        sd.FileName = ff[ff.Length - 1];
                }
                DialogResult re = sd.ShowDialog();
                if (re == System.Windows.Forms.DialogResult.OK)
                {
                    DTAccessorParam p = new DTAccessorParam(DTAccessorParamType.Save, sd.FileName);
                    if (syn)
                    {
                        DoWorkEventArgs arg = new DoWorkEventArgs(p);
                        backgroundWorker_DTAccessor_DoWork(null, arg);
                        return DialogResult.OK;
                    }
                    else
                    {
                        if (backgroundWorker_DTAccessor.IsBusy == false)
                        {
                            backgroundWorker_DTAccessor.RunWorkerAsync(p);
                            return DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("文件存取器正忙！");
                            return DialogResult.Cancel;
                        }
                    }
                }
                else
                {
                    return DialogResult.Cancel;
                }
            }
        }

        private void MenuItem_Open_Click(object sender, EventArgs e)
        {
            if (!newsaved && dt_logs != null && dt_logs.Rows.Count > 0)
            {
                DialogResult r = Saving(true, true);
                {
                    if (r == DialogResult.Cancel)
                        return;
                }
            }
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "dt文件|*.dt";
            od.FilterIndex = 1;
            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (backgroundWorker_DTAccessor.IsBusy == false)
                {
                    ClearTables();
                    backgroundWorker_DTAccessor.RunWorkerAsync(new DTAccessorParam(DTAccessorParamType.Add, od.FileName));
                }
                else
                    MessageBox.Show("文件存取器正忙！");
            }
        }

        private void timer_AutoSave_Tick(object sender, EventArgs e)
        {
            if (!newsaved_tmp && dt_logs != null && dt_logs.Rows.Count > 0)
            {
                if (!backgroundWorker_DTAccessor.IsBusy)
                {
                    backgroundWorker_DTAccessor.RunWorkerAsync(new DTAccessorParam(DTAccessorParamType.Save, "_TMP.dt", true));
                }
            }
        }

    }
}