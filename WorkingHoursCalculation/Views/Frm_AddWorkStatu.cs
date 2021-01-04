using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Helpers;
using WorkingHoursCalculation.Views.UserControls;

namespace WorkingHoursCalculation.Views
{
    public partial class Frm_AddWorkStatu : Form
    {
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

            //参加人员姓名
            this.labName.Text = workername;

            #region 初始化日期
            string sql = "Select workername,workdate from WorkingHours where workername='" + DESJiaMi.Encrypt(workername) + "' and isdelete='1' order by workdate desc;";
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



        }

        /// <summary>
        /// 【清空】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clearn_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 【保存】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {

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
