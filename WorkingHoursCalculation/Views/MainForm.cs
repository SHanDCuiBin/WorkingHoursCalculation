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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //初始化人员数据
            Initialize();
        }

        /// <summary>
        /// 初始化数据集合
        /// </summary>
        private void Initialize()
        {
            //不显示未绑定的列
            this.datagridview.AutoGenerateColumns = false;

            try
            {
                string sql = "Select ID,name from Personnel where enable='1' order by ID;";
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
            string sql = "Select * from WorkingHours where enable='1'";
            if (string.IsNullOrEmpty(cboxUsers.Text))
            {
                sql += " and workername=@workername ";
                dic.Add("workername", DESJiaMi.Encrypt(cboxUsers.Text));
            }
            if (true)
            {

            }

            DataTable dt = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
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
                MessageBox.Show("清先选择员工的\"姓名\"！", "新增", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 【更新】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 【删除】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 【导出】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_outPut_Click(object sender, EventArgs e)
        {

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
        }
        #endregion

    }
}
