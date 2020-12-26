using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Helpers;

namespace WorkingHoursCalculation
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


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
        #endregion

        #region 按钮功能
        /// <summary>
        /// 【登陆】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            DataTable dt = DbHelperOleDb.Query().Tables[0];
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

    }
}
