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
using WorkingHoursCalculation.Views;

namespace WorkingHoursCalculation
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            //初始化账号信息
            InitializationAccount();
        }

        #region 系统初始化
        /// <summary>
        /// 初始化账号信息
        /// </summary>
        private void InitializationAccount()
        {
            string isrember = ConfigOperator.GetValueFromConfig("isremeber");
            if (isrember.Contains("true"))
            {

                string Account = ConfigOperator.GetValueFromConfig("Account");
                string password = ConfigOperator.GetValueFromConfig("password");
                if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(password))
                {
                    checkIsRemeber.Checked = true;
                    txtUserName.Text = Account;
                    txtPassword.Text = password;
                }
            }
        }
        #endregion



        #region 按钮功能
        /// <summary>
        /// 【登陆】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    try
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("@username", DESJiaMi.Encrypt(txtUserName.Text));
                        dic.Add("@password", DESJiaMi.Encrypt(txtPassword.Text));
                        string sql = "Select * from Users where enable=1 and  username=@username and password =@password ";
                        
                        DataTable userdt = DbHelperOleDb.Query(sql, dic).Tables[0];
                        if (userdt != null && userdt.Rows.Count > 0)
                        {
                            //登陆账号
                            UserInfo.userName = userdt.Rows[0]["login_name"].ToString();
                            //登陆密码
                            UserInfo.password = userdt.Rows[0]["password"].ToString();
                            this.Hide();

                            //记住账号密码信息
                            IsRemeberAccount();

                            MainForm mainForm = new MainForm();
                            mainForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("\"账号\"或\"密码\"信息错误,请重新检查之后输入！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("数据库或网络设置错误，请重新检查！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("请先输入\"密码\"!", "登陆", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请先输入\"账号\"!", "登陆", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void IsRemeberAccount()
        {
            try
            {
                if (checkIsRemeber.Checked && !string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    ConfigOperator.SetValueFromConfig("isremeber", DESJiaMi.Encrypt("true " + DateTime.Now.ToString()));
                    ConfigOperator.SetValueFromConfig("Account", DESJiaMi.Encrypt(txtUserName.Text));
                    ConfigOperator.SetValueFromConfig("password", DESJiaMi.Encrypt(txtPassword.Text));
                }
                else
                {
                    ConfigOperator.SetValueFromConfig("isremeber", DESJiaMi.Encrypt("false " + DateTime.Now.ToString()));
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 【取消】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region 窗体动画、按钮样式
        private Point mPoint = new Point();
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        private void BtnSDSRSave_MouseEnter(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt != null)
            {
                bt.Size = new Size(bt.Size.Width + 3, bt.Size.Height + 2);
            }
        }

        /// <summary>
        /// 鼠标离开的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSDSRSave_MouseLeave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if (bt != null)
            {
                bt.Size = new Size(bt.Size.Width - 3, bt.Size.Height - 2);
            }
        }
        #endregion
    }
}
