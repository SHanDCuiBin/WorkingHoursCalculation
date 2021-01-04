using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Models;

namespace WorkingHoursCalculation.Views.UserControls
{
    public partial class timeInfo : UserControl
    {
        public timeInfo()
        {
            InitializeComponent();

            deductUnit.SelectedIndex = 0;

        }

        public timeInfo(string indexnum)
        {
            InitializeComponent();

            this.labIndex.Text = indexnum + "、";

            deductUnit.SelectedIndex = 0;
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

        /// <summary>
        /// 获取保存时间实体
        /// </summary>
        /// <returns></returns>
        public WorkingHours GetTimeResult()
        {
            WorkingHours workertime = new WorkingHours();
            workertime.starttime = startTime.Value.ToString("HH:mm:ss");
            workertime.endtime = endtime.Value.ToString("HH:mm:ss");
            if (!string.IsNullOrEmpty(txtDeduct.Text))
            {
                if (deductUnit.Text == "小时")
                {
                    workertime.deduct = (double.Parse(txtDeduct.Text)).ToString("0.00");
                }
                else if (deductUnit.Text == "分钟")
                {
                    workertime.deduct = (double.Parse(txtDeduct.Text) / 60).ToString("0.00");
                }

                if (!string.IsNullOrEmpty(txtdeductReason.Text))
                {
                    workertime.deductreason = txtdeductReason.Text.Trim();
                }
            }
            return workertime;
        }

        /// <summary>
        /// 校验数据是否准确
        /// </summary>
        /// <returns></returns>
        public bool CheckResult(out string error)
        {
            error = "";
            if (startTime.Value < endtime.Value)
            {
                if (!string.IsNullOrEmpty(txtDeduct.Text))
                {
                    if (string.IsNullOrEmpty(deductUnit.Text))
                    {
                        error = labIndex.Text + "中：未选择扣除的时间单位。";
                        return false;
                    }

                    TimeSpan start = new TimeSpan(startTime.Value.Hour, startTime.Value.Minute, startTime.Value.Second);
                    TimeSpan end = new TimeSpan(endtime.Value.Hour, endtime.Value.Minute, endtime.Value.Second);
                    TimeSpan ts3 = start.Subtract(end).Duration();

                    double times = 0;
                    if (deductUnit.Text == "小时")
                    {
                        times = double.Parse(txtDeduct.Text) * 60;
                    }
                    else if (deductUnit.Text == "分钟")
                    {
                        times = double.Parse(txtDeduct.Text);
                    }

                    if (ts3.TotalMinutes < times)
                    {
                        error = labIndex.Text + "中：“扣除时间”大于“结束事件”-“开始时间”。";
                        return false;
                    }

                    if (!string.IsNullOrEmpty(txtdeductReason.Text) && string.IsNullOrEmpty(txtDeduct.Text))
                    {
                        error = labIndex.Text + "中：填写了“扣除原因”，未填写“扣除时间”";
                        return false;
                    }
                }
            }
            else
            {
                error = labIndex.Text + "中：开始时间大约结束时间。";
                return false;
            }
            return true;
        }

    }
}
