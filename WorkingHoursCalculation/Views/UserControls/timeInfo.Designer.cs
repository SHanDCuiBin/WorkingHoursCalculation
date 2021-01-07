namespace WorkingHoursCalculation.Views.UserControls
{
    partial class timeInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.endtime = new System.Windows.Forms.DateTimePicker();
            this.txtDeduct = new System.Windows.Forms.TextBox();
            this.deductUnit = new System.Windows.Forms.ComboBox();
            this.txtdeductReason = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labIndex = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startTime
            // 
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTime.Location = new System.Drawing.Point(52, 4);
            this.startTime.Name = "startTime";
            this.startTime.ShowUpDown = true;
            this.startTime.Size = new System.Drawing.Size(101, 27);
            this.startTime.TabIndex = 0;
            this.startTime.ValueChanged += new System.EventHandler(this.startTime_ValueChanged);
            // 
            // endtime
            // 
            this.endtime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endtime.Location = new System.Drawing.Point(169, 4);
            this.endtime.Name = "endtime";
            this.endtime.ShowUpDown = true;
            this.endtime.Size = new System.Drawing.Size(99, 27);
            this.endtime.TabIndex = 1;
            // 
            // txtDeduct
            // 
            this.txtDeduct.Location = new System.Drawing.Point(293, 4);
            this.txtDeduct.Name = "txtDeduct";
            this.txtDeduct.Size = new System.Drawing.Size(60, 27);
            this.txtDeduct.TabIndex = 2;
            this.txtDeduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeduct_KeyPress);
            // 
            // deductUnit
            // 
            this.deductUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deductUnit.FormattingEnabled = true;
            this.deductUnit.Items.AddRange(new object[] {
            "小时",
            "分钟"});
            this.deductUnit.Location = new System.Drawing.Point(359, 3);
            this.deductUnit.Name = "deductUnit";
            this.deductUnit.Size = new System.Drawing.Size(62, 28);
            this.deductUnit.TabIndex = 3;
            // 
            // txtdeductReason
            // 
            this.txtdeductReason.Location = new System.Drawing.Point(445, 4);
            this.txtdeductReason.Name = "txtdeductReason";
            this.txtdeductReason.Size = new System.Drawing.Size(168, 27);
            this.txtdeductReason.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labIndex);
            this.panel1.Controls.Add(this.txtdeductReason);
            this.panel1.Controls.Add(this.startTime);
            this.panel1.Controls.Add(this.deductUnit);
            this.panel1.Controls.Add(this.endtime);
            this.panel1.Controls.Add(this.txtDeduct);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 35);
            this.panel1.TabIndex = 5;
            // 
            // labIndex
            // 
            this.labIndex.AutoSize = true;
            this.labIndex.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labIndex.Location = new System.Drawing.Point(19, 7);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new System.Drawing.Size(0, 19);
            this.labIndex.TabIndex = 5;
            // 
            // timeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "timeInfo";
            this.Size = new System.Drawing.Size(627, 38);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker startTime;
        public System.Windows.Forms.DateTimePicker endtime;
        private System.Windows.Forms.TextBox txtDeduct;
        private System.Windows.Forms.ComboBox deductUnit;
        private System.Windows.Forms.TextBox txtdeductReason;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labIndex;
    }
}
