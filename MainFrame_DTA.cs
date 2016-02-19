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
            DTAccessorParam p = e.Argument as DTAccessorParam;
            if (p.DTAP_mode == DTAccessorParam.DTAP_add)
            {
                RefreshStatus("正在加载文件……");
                DataSet ds = new DataSet();
                ds.ReadXml(p.filename, XmlReadMode.ReadSchema);
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
                        DataView dv = new DataView(dt_check);
                        dt_check = dv.ToTable(true);
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
            else if (p.DTAP_mode == DTAccessorParam.DTAP_save)
            {
                if (!p.save_tmp)
                    RefreshStatus("正在保存文件……");
                DataSet ds = new DataSet();
                this.Invoke(new Param0Callback(() =>
                    {
                        ds.Tables.Add(dt_logs.Copy());
                        ds.Tables.Add(dt_check.Copy());
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
                    if (p.DTAP_mode == DTAccessorParam.DTAP_add && dt_logs.Rows.Count > 0)
                    {
                        this.log_shown = true;
                        this.ShowLog(dt_logs.Rows[0]);
                    }
                }));
                cur_file = p.filename;
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
                    DTAccessorParam p = new DTAccessorParam();
                    p.DTAP_mode = DTAccessorParam.DTAP_save;
                    p.filename = cur_file;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
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
                DataSet ds = new DataSet("schsave");
                ds.Tables.Add(dt_logs.Clone());
                ds.Tables.Add(dt_check.Clone());
                ds.Tables.Add(dt_units);
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
                    DTAccessorParam p = new DTAccessorParam();
                    p.DTAP_mode = DTAccessorParam.DTAP_add;
                    p.filename = od.FileName;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
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
                    DTAccessorParam p = new DTAccessorParam();
                    p.DTAP_mode = DTAccessorParam.DTAP_save;
                    p.filename = sd.FileName;
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
                    lock (locker_dt_logs)
                    {
                        dt_logs.Clear();
                    }
                    DTAccessorParam p = new DTAccessorParam();
                    p.DTAP_mode = DTAccessorParam.DTAP_add;
                    p.filename = od.FileName;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
                }
                else
                    MessageBox.Show("文件存取器正忙！");
            }
        }

        private void timer_AutoSave_Tick(object sender, EventArgs e)
        {
            if (!newsaved && dt_logs != null && dt_logs.Rows.Count > 0)
            {
                if (!backgroundWorker_DTAccessor.IsBusy)
                {
                    DTAccessorParam p = new DTAccessorParam();
                    p.DTAP_mode = DTAccessorParam.DTAP_save;
                    p.filename = "_TMP.dt";
                    p.save_tmp = true;
                    backgroundWorker_DTAccessor.RunWorkerAsync(p);
                }
            }
        }

    }
}