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

namespace WorkingHoursCalculation.Views
{
    public partial class Frm_logon : Form
    {
        public Frm_logon()
        {
            InitializeComponent();
        }

        #region 按钮功能
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckResutOut())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("@username", txtUserName.Text);
                    string sql = "Select * from Users where enable='1' and  username=@username ";
                    DataTable userdt = DbHelperOleDb.Query(sql, dic).Tables[0];
                    if (userdt == null || userdt.Rows.Count == 0)
                    {
                        Users user = new Users();
                        user.username = txtUserName.Text;
                        user.password = DESJiaMi.Encrypt(txtpassword.Text);
                        user.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        user.enable = "1";
                        if (DbHelperOleDb.Add(user, "Users", null))
                        {
                            MessageBox.Show("注册成功！\r\n账号：" + user.username + "\r\n密码：" + DESJiaMi.Decrypt(user.password) + "\r\n请牢记登陆账号密码!", "注册", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("注册失败！", "注册", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该用户名已经存在，请重新输入其他的用户名！", "注册", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("注册失败！\r\n错误信息：\r\n" + ee.Message.ToString(), "注册", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        /// <summary>
        /// 检查数据合法性
        /// </summary>
        /// <returns></returns>
        private bool CheckResutOut()
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (txtUserName.Text.Length >= 5 && txtpassword.Text.Length >= 5 && txtpassword2.Text.Length >= 5)
                {
                    if (!string.IsNullOrEmpty(txtpassword.Text) && !string.IsNullOrEmpty(txtpassword2.Text))
                    {
                        if (!txtUserName.Text.Contains(" ") && !txtpassword.Text.Contains(" ") && !txtpassword2.Text.Contains(" "))
                        {
                            if (txtpassword.Text == txtpassword2.Text)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("两次输入的密码不一致,请重新收入！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名和密码中不能包含空格！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入密码！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("用户名、密码长度过短，请重新输入。\r\n长度不能少于5个字符！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请先输入用户名！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        /// <summary>
        /// 限制用户名和密码只能输入数字和字母
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (("01234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Contains(e.KeyChar)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
