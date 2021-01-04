using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkingHoursCalculation.Views.UserControls
{
    public partial class timeInfo : UserControl
    {
        public timeInfo()
        {
            InitializeComponent();
        }

        public timeInfo(string indexnum)
        {
            InitializeComponent();

            this.labIndex.Text = indexnum + "、";
        }

        /// <summary>
        /// 设置结束时间的最小选择时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startTime_ValueChanged(object sender, EventArgs e)
        {
            endtime.MinDate = startTime.Value;
        }

        /// <summary>
        /// 限制输入内容  只允许数字和可包含小数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符 
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.txtDeduct.Text.Length == 0)//小数点 
                {
                    e.Handled = true;
                }
                if (txtDeduct.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
