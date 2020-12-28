using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Helpers;

namespace WorkingHoursCalculation.Views
{
    public partial class Frm_PersonelInfo : Form
    {
        /// <summary>
        /// 用户数据集
        /// </summary>
        DataTable userdt = new DataTable();
        public Frm_PersonelInfo()
        {
            InitializeComponent();

            //加载员工列表
            LoadPersonelInfo();
        }

        /// <summary>
        /// 加载所有有效的员工列表
        /// </summary>
        private void LoadPersonelInfo()
        {
            string sql = "Select * from Personnel where enable='1' order by ID;";
            userdt = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
            if (userdt != null && userdt.Rows.Count > 0)
            {
                datagridview.DataSource = userdt;
            }
            else
            {
                datagridview.DataSource = null;
            }
        }

        /// <summary>
        /// 双击查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.datagridview.CurrentRow != null)
                {
                    string id = this.datagridview.CurrentRow.Cells["ID"].Value.ToString();
                    string name = this.datagridview.CurrentRow.Cells["name"].Value.ToString();
                    if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name))
                    {
                        DataRow[] dr = userdt.Select();
                        if (dr != null && dr.Length > 0)
                        {
                            txtName.Text = DESJiaMi.Encrypt(dr[0]["name"].ToString());
                            cboxGender.Text = DESJiaMi.Encrypt(dr[0]["gender"].ToString());
                            txtLxdh.Text = DESJiaMi.Encrypt(dr[0]["lxdh"].ToString());
                            richMainjob.Text = DESJiaMi.Encrypt(dr[0]["mainwork"].ToString());
                            labCreateTime.Text = DESJiaMi.Encrypt(dr[0]["createtime"].ToString());
                        }
                        else
                        {
                            ClearnNeiRong();
                        }
                    }
                    else
                    {
                        ClearnNeiRong();
                    }
                }
            }
            catch (Exception)
            {
                ClearnNeiRong();
            }
        }



        #region 按钮功能

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (btn_Add.Text == "新 增")
            {
                //设置按钮状态
                SetButtonStatus(false, false, true);
                //清空数据
                ClearnNeiRong();
                //可编辑状态
                IsAddNeiRong(true);
                //创建时间
                labCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");

                btn_Add.Text = "保 存";
            }
            else  //(btn_Add.Text == "保存")
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {

                }
                else
                {
                    MessageBox.Show("请先输入需要保存的姓名！");
                }
            }
        }
        #endregion


        /// <summary>
        /// 设置按钮的状态
        /// </summary>
        private void SetButtonStatus(bool isupdata, bool isdelete, bool isAdd)
        {
            btn_Update.Visible = isupdata;
            btn_Delete.Visible = isdelete;
            btn_Add.Visible = isAdd;
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearnNeiRong()
        {
            txtName.Text = cboxGender.Text = txtLxdh.Text = richMainjob.Text = labCreateTime.Text = "";
        }

        /// <summary>
        /// 可编辑状态
        /// </summary>
        private void IsAddNeiRong(bool isStatus)
        {
            txtName.Enabled = cboxGender.Enabled = txtLxdh.Enabled = richMainjob.Enabled = isStatus;
        }
    }
}
