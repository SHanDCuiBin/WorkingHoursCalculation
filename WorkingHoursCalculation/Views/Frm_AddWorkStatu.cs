using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Helpers;
using WorkingHoursCalculation.Models;
using WorkingHoursCalculation.Views.UserControls;

namespace WorkingHoursCalculation.Views
{
    public partial class Frm_AddWorkStatu : Form
    {
        /// <summary>
        /// 当前添加采集人员的姓名
        /// </summary>
        private string gWorkerName = string.Empty;
        /// <summary>
        /// 标记打开此页面是否成功添加工作信息
        /// </summary>
        public bool isAddSuccess = false;
        public Frm_AddWorkStatu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="workerid"></param>
        public Frm_AddWorkStatu(string workername)
        {
            InitializeComponent();

            this.gWorkerName = workername;
            Initialize();
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="workername"></param>
        private void Initialize()
        {
            //参加人员姓名
            this.labName.Text = this.gWorkerName;

            #region 初始化日期
            string sql = "Select workername,workdate from WorkingHours where workername='" + DESJiaMi.Encrypt(this.gWorkerName) + "' and isdelete='1' order by workdate desc;";
            DataTable workdt = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
            if (workdt != null && workdt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(workdt.Rows[0]["workdate"].ToString()))
                {
                    DateTime dateTime = DateTime.Now;
                    if (DateTime.TryParse(workdt.Rows[0]["workdate"].ToString(), out dateTime))
                    {
                        dateWorkDate.Value = dateTime.AddDays(1);
                    }
                }
            }
            #endregion

            int index = 1;
            foreach (timeInfo item in flowLayoutPanel1.Controls)
            {
                item.labIndex.Text = (index++).ToString() + "、";
            }
        }


        /// <summary>
        /// 【清空】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clearn_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            //重新初始化
            Initialize();

        }

        /// <summary>
        /// 【保存】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labName.Text))
            {

                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    List<WorkingHours> worktimes = new List<WorkingHours>();
                    foreach (timeInfo item in flowLayoutPanel1.Controls)
                    {
                        string error = "";
                        if (!item.CheckResult(out error))
                        {
                            WorkingHours times = item.GetTimeResult();

                            times.workername = DESJiaMi.Encrypt(this.gWorkerName);
                            times.workdate = dateWorkDate.Value.ToString("yyyy-MM-dd");
                            times.isdelete = "1";
                            worktimes.Add(times);
                        }
                        else
                        {
                            MessageBox.Show("保存失败！\r\n" + error, "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        #region 判断时间是否有交叉选择的情况

                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("未添加待保存的时间信息，保存失败！！！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("姓名信息错误，保存失败！！！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 添加时间段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddTimeInfo_Click(object sender, EventArgs e)
        {
            timeInfo timeInfo = new timeInfo();
            flowLayoutPanel1.Controls.Add(timeInfo);
        }

        /// <summary>
        /// 删除时间段控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeletetimeInfo_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
            }
        }
    }
}
