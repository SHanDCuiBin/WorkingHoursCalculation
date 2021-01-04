namespace WorkingHoursCalculation.Views
{
    partial class Frm_AddWorkStatu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.dateWorkDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Clearn = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_AddTimeInfo = new System.Windows.Forms.Button();
            this.btn_DeletetimeInfo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.timeInfo1 = new WorkingHoursCalculation.Views.UserControls.timeInfo();
            this.timeInfo2 = new WorkingHoursCalculation.Views.UserControls.timeInfo();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(90, 11);
            this.labName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(0, 20);
            this.labName.TabIndex = 1;
            // 
            // dateWorkDate
            // 
            this.dateWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateWorkDate.Location = new System.Drawing.Point(259, 8);
            this.dateWorkDate.Name = "dateWorkDate";
            this.dateWorkDate.Size = new System.Drawing.Size(123, 27);
            this.dateWorkDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "开始时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "结束时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "扣除时间（选填）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(509, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "扣除原因（选填）";
            // 
            // btn_Clearn
            // 
            this.btn_Clearn.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Clearn.Location = new System.Drawing.Point(12, 228);
            this.btn_Clearn.Name = "btn_Clearn";
            this.btn_Clearn.Size = new System.Drawing.Size(78, 35);
            this.btn_Clearn.TabIndex = 10;
            this.btn_Clearn.Text = "清 空";
            this.btn_Clearn.UseVisualStyleBackColor = true;
            this.btn_Clearn.Click += new System.EventHandler(this.btn_Clearn_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Save.Location = new System.Drawing.Point(567, 228);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(78, 35);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Text = "保 存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_AddTimeInfo
            // 
            this.btn_AddTimeInfo.Location = new System.Drawing.Point(651, 82);
            this.btn_AddTimeInfo.Name = "btn_AddTimeInfo";
            this.btn_AddTimeInfo.Size = new System.Drawing.Size(40, 52);
            this.btn_AddTimeInfo.TabIndex = 12;
            this.btn_AddTimeInfo.Text = "添 加";
            this.btn_AddTimeInfo.UseVisualStyleBackColor = true;
            this.btn_AddTimeInfo.Click += new System.EventHandler(this.btn_AddTimeInfo_Click);
            // 
            // btn_DeletetimeInfo
            // 
            this.btn_DeletetimeInfo.Location = new System.Drawing.Point(651, 149);
            this.btn_DeletetimeInfo.Name = "btn_DeletetimeInfo";
            this.btn_DeletetimeInfo.Size = new System.Drawing.Size(40, 52);
            this.btn_DeletetimeInfo.TabIndex = 13;
            this.btn_DeletetimeInfo.Text = "删 除";
            this.btn_DeletetimeInfo.UseVisualStyleBackColor = true;
            this.btn_DeletetimeInfo.Click += new System.EventHandler(this.btn_DeletetimeInfo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.timeInfo1);
            this.flowLayoutPanel1.Controls.Add(this.timeInfo2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(637, 150);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "编号";
            // 
            // timeInfo1
            // 
            this.timeInfo1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeInfo1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.timeInfo1.Location = new System.Drawing.Point(4, 5);
            this.timeInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeInfo1.Name = "timeInfo1";
            this.timeInfo1.Size = new System.Drawing.Size(627, 38);
            this.timeInfo1.TabIndex = 0;
            // 
            // timeInfo2
            // 
            this.timeInfo2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeInfo2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.timeInfo2.Location = new System.Drawing.Point(4, 53);
            this.timeInfo2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeInfo2.Name = "timeInfo2";
            this.timeInfo2.Size = new System.Drawing.Size(627, 38);
            this.timeInfo2.TabIndex = 1;
            // 
            // Frm_AddWorkStatu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(694, 270);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_DeletetimeInfo);
            this.Controls.Add(this.btn_AddTimeInfo);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Clearn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateWorkDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AddWorkStatu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.DateTimePicker dateWorkDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Clearn;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_AddTimeInfo;
        private System.Windows.Forms.Button btn_DeletetimeInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private UserControls.timeInfo timeInfo1;
        private UserControls.timeInfo timeInfo2;
    }
}