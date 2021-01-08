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

            Random random = new Random();
            int index = random.Next(0, 32);
            SetPicture(index, this.pictureBox1);

            //初始化账号信息
            InitializationAccount();


        }

        #region 系统初始化
        /// <summary>
        /// 初始化账号信息
        /// </summary>
        private void InitializationAccount()
        {
            string isrember = DESJiaMi.Decrypt(ConfigOperator.GetValueFromConfig("isremeber"));
            if (isrember.Contains("true"))
            {
                string Account = ConfigOperator.GetValueFromConfig("Account");
                string password = DESJiaMi.Decrypt(ConfigOperator.GetValueFromConfig("password"));
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
                        dic.Add("@username", txtUserName.Text);
                        dic.Add("@password", DESJiaMi.Encrypt(txtPassword.Text));

                        //dic.Add("@username", txtUserName.Text);
                        //dic.Add("@password", txtPassword.Text);
                        string sql = "Select * from Users where enable='1' and  username=@username and password =@password ";

                        DataTable userdt = DbHelperOleDb.Query(sql, dic).Tables[0];
                        if (userdt != null && userdt.Rows.Count > 0)
                        {
                            //登陆账号
                            UserInfo.userName = userdt.Rows[0]["username"].ToString();
                            //登陆密码
                            UserInfo.password = DESJiaMi.Decrypt(userdt.Rows[0]["password"].ToString());
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
                    ConfigOperator.SetValueFromConfig("Account", txtUserName.Text);
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


        private void SetPicture(int index, PictureBox pictureBox)
        {

            switch (index)
            {
                case 1: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠01; break;
                case 2: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠02; break;
                case 3: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠03; break;
                case 4: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠04; break;
                case 5: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠05; break;
                case 6: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠06; break;
                case 7: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠07; break;
                case 8: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠08; break;
                case 9: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠09; break;
                case 10: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠10; break;
                case 11: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠11; break;
                case 12: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠12; break;
                case 13: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠13; break;
                case 14: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠14; break;
                case 15: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠15; break;
                case 16: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠16; break;
                case 17: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠17; break;
                case 18: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠18; break;
                case 19: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠19; break;
                case 20: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠20; break;
                case 21: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠21; break;
                case 22: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠22; break;
                case 23: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠23; break;
                case 24: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠24; break;
                case 25: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠25; break;
                case 26: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠26; break;
                case 27: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠27; break;
                case 28: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠28; break;
                case 29: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠29; break;
                case 30: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠30; break;
                case 31: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠31; break;
                case 32: pictureBox.Image = global::WorkingHoursCalculation.Properties.Resources.爱宠32; break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Frm_logon frm_Logon = new Frm_logon();
            frm_Logon.ShowDialog();
        }
    }
}
