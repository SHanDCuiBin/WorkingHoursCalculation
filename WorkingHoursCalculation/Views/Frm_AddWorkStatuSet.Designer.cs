
namespace WorkingHoursCalculation.Views
{
    partial class Frm_AddWorkStatuSet
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkContinuousAddition = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endTime1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.startTime1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.endTime2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.startTime2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.checkSetTime = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 271);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkContinuousAddition
            // 
            this.checkContinuousAddition.AutoSize = true;
            this.checkContinuousAddition.Location = new System.Drawing.Point(20, 11);
            this.checkContinuousAddition.Name = "checkContinuousAddition";
            this.checkContinuousAddition.Size = new System.Drawing.Size(84, 24);
            this.checkContinuousAddition.TabIndex = 1;
            this.checkContinuousAddition.Text = "连续添加";
            this.checkContinuousAddition.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endTime1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startTime1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间段1";
            // 
            // endTime1
            // 
            this.endTime1.Enabled = false;
            this.endTime1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.endTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTime1.Location = new System.Drawing.Point(88, 56);
            this.endTime1.Name = "endTime1";
            this.endTime1.ShowUpDown = true;
            this.endTime1.Size = new System.Drawing.Size(95, 25);
            this.endTime1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间：";
            // 
            // startTime1
            // 
            this.startTime1.Enabled = false;
            this.startTime1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.startTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTime1.Location = new System.Drawing.Point(88, 25);
            this.startTime1.Name = "startTime1";
            this.startTime1.ShowUpDown = true;
            this.startTime1.Size = new System.Drawing.Size(95, 25);
            this.startTime1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.endTime2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.startTime2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(22, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 89);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "时间段2";
            // 
            // endTime2
            // 
            this.endTime2.Enabled = false;
            this.endTime2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.endTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTime2.Location = new System.Drawing.Point(88, 56);
            this.endTime2.Name = "endTime2";
            this.endTime2.ShowUpDown = true;
            this.endTime2.Size = new System.Drawing.Size(95, 25);
            this.endTime2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "结束时间：";
            // 
            // startTime2
            // 
            this.startTime2.Enabled = false;
            this.startTime2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.startTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTime2.Location = new System.Drawing.Point(88, 25);
            this.startTime2.Name = "startTime2";
            this.startTime2.ShowUpDown = true;
            this.startTime2.Size = new System.Drawing.Size(95, 25);
            this.startTime2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "开始时间：";
            // 
            // checkSetTime
            // 
            this.checkSetTime.AutoSize = true;
            this.checkSetTime.Location = new System.Drawing.Point(20, 43);
            this.checkSetTime.Name = "checkSetTime";
            this.checkSetTime.Size = new System.Drawing.Size(140, 24);
            this.checkSetTime.TabIndex = 5;
            this.checkSetTime.Text = "采用默认设置时间";
            this.checkSetTime.UseVisualStyleBackColor = true;
            this.checkSetTime.CheckedChanged += new System.EventHandler(this.checkSetTime_CheckedChanged);
            // 
            // Frm_AddWorkStatuSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(236, 312);
            this.Controls.Add(this.checkSetTime);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkContinuousAddition);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AddWorkStatuSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkContinuousAddition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker startTime1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endTime1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker endTime2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startTime2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkSetTime;
    }
}