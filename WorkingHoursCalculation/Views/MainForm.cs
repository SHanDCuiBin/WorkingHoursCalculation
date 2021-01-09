using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Bll;
using WorkingHoursCalculation.Helpers;
using WorkingHoursCalculation.Models;

namespace WorkingHoursCalculation.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //不显示未绑定的列
            this.datagridview.AutoGenerateColumns = false;

            //初始化人员数据
            Initialize();
        }

        /// <summary>
        /// 初始化数据集合
        /// </summary>
        private void Initialize()
        {
            try
            {
                string sql = "Select ID,name from Personnel where enable='1'  order by ID;";
                DataTable userdt = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
                if (userdt != null && userdt.Rows.Count > 0)
                {
                    for (int i = 0; i < userdt.Rows.Count; i++)
                    {
                        userdt.Rows[i]["name"] = DESJiaMi.Decrypt(userdt.Rows[i]["name"].ToString());
                    }
                    cboxUsers.DataSource = userdt;
                    cboxUsers.DisplayMember = "name";
                    cboxUsers.ValueMember = "ID";
                    cboxUsers.SelectedIndex = -1;
                }
                else
                {
                    cboxUsers.DataSource = null;
                }
            }
            catch (Exception ee)
            {
                cboxUsers.DataSource = null;
            }
        }

        /// <summary>
        /// 【退出程序】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// 自适应大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            panel4.Size = new System.Drawing.Size(this.Width - 22, this.Height - (this.panel4.Location.Y) - 84);
        }

        #region 按钮功能
        /// <summary>
        /// 【查询】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Chaxun_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string sql = "Select * from WorkingHours where isdelete='1'";
            if (!string.IsNullOrEmpty(cboxUsers.Text))
            {
                sql += " and workername=@workername ";
                dic.Add("workername", DESJiaMi.Encrypt(cboxUsers.Text));
            }
            if (startData.Value <= endData.Value)
            {
                sql += " and workdate>=@workdate1";
                dic.Add("workdate1", startData.Value.ToString("yyyy-MM-dd"));

                sql += " and workdate<=@workdate2 ";
                dic.Add("workdate2", endData.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                MessageBox.Show("开始时间大于结束时间，未获取到结果！", "查询", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = DbHelperOleDb.Query(sql + "  order by workdate,starttime", dic).Tables[0];
            datagridview.DataSource = dt;

            if (!backTianShu.IsBusy)
            {
                backTianShu.RunWorkerAsync(dt);
            }
        }

        /// <summary>
        /// 【新增】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboxUsers.Text))
            {
                Frm_AddWorkStatu frm_AddWorkStatu = new Frm_AddWorkStatu(cboxUsers.Text);
                frm_AddWorkStatu.ShowDialog();
                if (frm_AddWorkStatu.isAddSuccess)   //表示成功添加了信息，需进行刷新
                {
                    btn_Chaxun_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("请先选择员工的\"姓名\"！", "新增", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 【删除】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int num = datagridview.SelectedRows.Count;
            if (num != 1)
            {
                MessageBox.Show("请只选择一条记录进行删除！！！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string workername = datagridview.SelectedRows[0].Cells["workername"].Value.ToString();
                string workerDate = datagridview.SelectedRows[0].Cells["workdate"].Value.ToString();
                if (!string.IsNullOrEmpty(workername) && !string.IsNullOrEmpty(workerDate))
                {
                    if (MessageBox.Show("是否确认删除员工：" + DESJiaMi.Decrypt(workername) + "，日期：" + workerDate + " 的工作记录！", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string deleteSql = " Delete from WorkingHours where workername='" + workername + "' and workdate='" + workerDate + "' and isdelete='1' ;";
                        DbHelperOleDb.ExecuteSql(deleteSql, new Dictionary<string, object>());
                        MessageBox.Show("删除成功！", "删除", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_Chaxun_Click(null, null);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("删除操作失败！！！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        /// <summary>
        /// 【导出】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_outPut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboxUsers.Text))
            {
                if (startData.Value <= endData.Value)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    string sql = "Select * from WorkingHours where isdelete='1'";

                    sql += " and workername=@workername ";
                    dic.Add("workername", DESJiaMi.Encrypt(cboxUsers.Text));

                    sql += " and workdate>=@workdate1";
                    dic.Add("workdate1", startData.Value.ToString("yyyy-MM-dd"));

                    sql += " and workdate<=@workdate2 ";
                    dic.Add("workdate2", endData.Value.ToString("yyyy-MM-dd"));

                    DataTable dt = DbHelperOleDb.Query(sql + " order by workdate,starttime", dic).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ReportBll reportBll = new ReportBll();
                        string timeLimit = startData.Value.ToString("yyyy.MM.dd") + "-" + endData.Value.ToString("yyyy.MM.dd");
                        reportBll.RegisterData(dt, cboxUsers.Text, timeLimit);
                        if (reportBll.ReportExport(cboxUsers.Text + "_" + timeLimit + ".pdf"))
                        {
                            MessageBox.Show("工作报表生成完成！", "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("工作报表生成失败！", "导出", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该员工在当前选择的时间段内无工作信息记录，无法进行导出！！！", "导出", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("导出的“开始时间”大于“结束时间”，无法进行导出！！！", "导出", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请先选择要导出的员工姓名！！！", "导出", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 【个人信息维护】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Personnel_Click(object sender, EventArgs e)
        {
            Frm_PersonelInfo frm_PersonelInfo = new Frm_PersonelInfo();
            frm_PersonelInfo.ShowDialog();
            if (frm_PersonelInfo.updateORAddSuccess)   //重新刷新用户列表
            {
                Initialize();
                datagridview.DataSource = null;
            }
        }
        #endregion


        /// <summary>
        /// 列显示转义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagridview_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = datagridview.Columns[e.ColumnIndex].Name;
            if (columnName == "workername")
            {
                if (!string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = DESJiaMi.Decrypt(e.Value.ToString());
                }
            }
            else if (columnName == "duration")
            {
                try
                {
                    string timeStart = datagridview.Rows[e.RowIndex].Cells["starttime"].Value.ToString();
                    string timeEnd = datagridview.Rows[e.RowIndex].Cells["endtime"].Value.ToString();
                    if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
                    {
                        DateTime dtStart = DateTime.Now;   //开始时间
                        DateTime dtEnd = DateTime.Now;     //结束时间
                        if (DateTime.TryParse(timeStart, out dtStart) && DateTime.TryParse(timeEnd, out dtEnd))
                        {
                            double times = GetTimeDuration(dtStart, dtEnd);
                            string deductTime = datagridview.Rows[e.RowIndex].Cells["deduct"].Value.ToString();
                            if (!string.IsNullOrEmpty(deductTime))
                            {
                                e.Value = (times - double.Parse(deductTime)).ToString("0.000");
                            }
                            else
                            {
                                e.Value = times.ToString("0.000");
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        #region 统计天数 工作总时长

        double worktimers = 0.0;    //工作时长
        private void backTianShu_DoWork(object sender, DoWorkEventArgs e)
        {
            worktimers = 0.0;    //工作时长
            DataTable dt = e.Argument as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime dtStart = DateTime.Now;   //开始时间
                DateTime dtEnd = DateTime.Now;     //结束时间
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string timeStart = dt.Rows[i]["starttime"].ToString();
                    string timeEnd = dt.Rows[i]["endtime"].ToString();
                    if (DateTime.TryParse(timeStart, out dtStart) && DateTime.TryParse(timeEnd, out dtEnd))
                    {
                        double times = GetTimeDuration(dtStart, dtEnd);
                        string deductTime = dt.Rows[i]["deduct"].ToString();
                        if (!string.IsNullOrEmpty(deductTime))
                        {
                            worktimers += (times - double.Parse(deductTime));
                        }
                        else
                        {
                            worktimers += times;
                        }
                    }
                }
            }

        }

        private void backTianShu_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labShiChang.Text = worktimers.ToString("0.000") + "小时";
        }
        #endregion

        /// <summary>
        /// 根据时间获取时间差
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        private double GetTimeDuration(DateTime dtStart, DateTime dtEnd)
        {
            TimeSpan ts1 = new TimeSpan(dtStart.Ticks);
            TimeSpan ts2 = new TimeSpan(dtEnd.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            return ts.TotalHours;
        }
    }
}
