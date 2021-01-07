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
    public partial class Frm_AddWorkStatuSet : Form
    {
        public Frm_AddWorkStatuSet()
        {
            InitializeComponent();

            string ContinuousAddition = ConfigOperator.GetValueFromConfig("ContinuousAddition");
            if (!string.IsNullOrEmpty(ContinuousAddition) && ContinuousAddition == "true")
            {
                checkContinuousAddition.Checked = true;
            }
            else
            {
                checkContinuousAddition.Checked = false;
            }

            string defaultTimeSet = ConfigOperator.GetValueFromConfig("defaultTimeSet");
            if (!string.IsNullOrEmpty(defaultTimeSet) && defaultTimeSet == "true")
            {
                checkSetTime.Checked = true;

                DateTime dateTime = DateTime.Now;

                string staTime1 = ConfigOperator.GetValueFromConfig("startTime1");
                if (!string.IsNullOrEmpty(staTime1) && DateTime.TryParse(staTime1, out dateTime))
                {
                    startTime1.Value = dateTime;
                }
                
                string eTime = ConfigOperator.GetValueFromConfig("endTime1");
                if (!string.IsNullOrEmpty(eTime) && DateTime.TryParse(eTime, out dateTime))
                {
                    endTime1.Value = dateTime;
                }
                
                string staTime2 = ConfigOperator.GetValueFromConfig("startTime2");
                if (!string.IsNullOrEmpty(staTime2) && DateTime.TryParse(staTime2, out dateTime))
                {
                    startTime2.Value = dateTime;
                }
                string eTime2 = ConfigOperator.GetValueFromConfig("endTime2");
                if (!string.IsNullOrEmpty(eTime2) && DateTime.TryParse(eTime2, out dateTime))
                {
                    endTime2.Value = dateTime;
                }
            }
            else
            {
                checkSetTime.Checked = false;
            }

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkSetTime.Checked)
            {
                //时间段1
                if (startTime1.Value >= endTime1.Value)
                {
                    MessageBox.Show("“时段1”的开始时间大于等于结束时间，保存失败", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //时间段2
                if (startTime2.Value >= endTime2.Value)
                {
                    MessageBox.Show("“时段2”的开始时间大于等于结束时间，保存失败", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ConfigOperator.SetValueFromConfig("defaultTimeSet", "true");
                ConfigOperator.SetValueFromConfig("startTime1", startTime1.Text);
                ConfigOperator.SetValueFromConfig("endTime1", endTime1.Text);
                ConfigOperator.SetValueFromConfig("startTime2", startTime2.Text);
                ConfigOperator.SetValueFromConfig("endTime2", endTime2.Text);
            }
            else
            {
                ConfigOperator.SetValueFromConfig("defaultTimeSet", "false");
            }
            if (checkContinuousAddition.Checked)
            {
                ConfigOperator.SetValueFromConfig("ContinuousAddition", "true");
            }
            else
            {
                ConfigOperator.SetValueFromConfig("ContinuousAddition", "false");
            }
            MessageBox.Show("保存完成", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;

        }

        private void checkSetTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSetTime.Checked)
            {
                startTime1.Enabled = endTime1.Enabled = startTime2.Enabled = endTime2.Enabled = true;
            }
            else
            {
                startTime1.Enabled = endTime1.Enabled = startTime2.Enabled = endTime2.Enabled = false;
            }
        }
    }
}
