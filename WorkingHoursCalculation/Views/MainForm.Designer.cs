namespace WorkingHoursCalculation.Views
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.startData = new System.Windows.Forms.DateTimePicker();
            this.endData = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxUsers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_outPut = new System.Windows.Forms.Button();
            this.btn_Personnel = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Chaxun = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.workername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deductreason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labShiChang = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backTianShu = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1181, 524);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.startData);
            this.panel2.Controls.Add(this.endData);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboxUsers);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 38);
            this.panel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label4.Location = new System.Drawing.Point(365, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "—";
            // 
            // startData
            // 
            this.startData.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.startData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startData.Location = new System.Drawing.Point(235, 6);
            this.startData.Name = "startData";
            this.startData.Size = new System.Drawing.Size(125, 27);
            this.startData.TabIndex = 2;
            // 
            // endData
            // 
            this.endData.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.endData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endData.Location = new System.Drawing.Point(392, 6);
            this.endData.Name = "endData";
            this.endData.Size = new System.Drawing.Size(125, 27);
            this.endData.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label3.Location = new System.Drawing.Point(193, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "时间：";
            // 
            // cboxUsers
            // 
            this.cboxUsers.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.cboxUsers.FormattingEnabled = true;
            this.cboxUsers.Location = new System.Drawing.Point(50, 5);
            this.cboxUsers.Name = "cboxUsers";
            this.cboxUsers.Size = new System.Drawing.Size(121, 28);
            this.cboxUsers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_outPut);
            this.panel3.Controls.Add(this.btn_Personnel);
            this.panel3.Controls.Add(this.btn_Add);
            this.panel3.Controls.Add(this.btn_Delete);
            this.panel3.Controls.Add(this.btn_Chaxun);
            this.panel3.Location = new System.Drawing.Point(534, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 38);
            this.panel3.TabIndex = 1;
            // 
            // btn_outPut
            // 
            this.btn_outPut.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_outPut.Location = new System.Drawing.Point(280, 5);
            this.btn_outPut.Name = "btn_outPut";
            this.btn_outPut.Size = new System.Drawing.Size(75, 30);
            this.btn_outPut.TabIndex = 6;
            this.btn_outPut.Text = "导 出";
            this.btn_outPut.UseVisualStyleBackColor = true;
            this.btn_outPut.Click += new System.EventHandler(this.btn_outPut_Click);
            // 
            // btn_Personnel
            // 
            this.btn_Personnel.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Personnel.Location = new System.Drawing.Point(370, 5);
            this.btn_Personnel.Name = "btn_Personnel";
            this.btn_Personnel.Size = new System.Drawing.Size(82, 30);
            this.btn_Personnel.TabIndex = 5;
            this.btn_Personnel.Text = "员工信息";
            this.btn_Personnel.UseVisualStyleBackColor = true;
            this.btn_Personnel.Click += new System.EventHandler(this.btn_Personnel_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Add.Location = new System.Drawing.Point(100, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 30);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "新 增";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Delete.Location = new System.Drawing.Point(190, 5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 30);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "删 除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Chaxun
            // 
            this.btn_Chaxun.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Chaxun.Location = new System.Drawing.Point(10, 4);
            this.btn_Chaxun.Name = "btn_Chaxun";
            this.btn_Chaxun.Size = new System.Drawing.Size(75, 30);
            this.btn_Chaxun.TabIndex = 0;
            this.btn_Chaxun.Text = "查 询";
            this.btn_Chaxun.UseVisualStyleBackColor = true;
            this.btn_Chaxun.Click += new System.EventHandler(this.btn_Chaxun_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.datagridview);
            this.panel4.Location = new System.Drawing.Point(3, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1178, 469);
            this.panel4.TabIndex = 2;
            // 
            // datagridview
            // 
            this.datagridview.AllowUserToAddRows = false;
            this.datagridview.AllowUserToDeleteRows = false;
            this.datagridview.AllowUserToResizeRows = false;
            this.datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridview.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workername,
            this.workdate,
            this.starttime,
            this.endtime,
            this.deduct,
            this.duration,
            this.deductreason});
            this.datagridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridview.Location = new System.Drawing.Point(0, 0);
            this.datagridview.Name = "datagridview";
            this.datagridview.RowTemplate.Height = 23;
            this.datagridview.Size = new System.Drawing.Size(1178, 469);
            this.datagridview.TabIndex = 0;
            this.datagridview.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.datagridview_CellFormatting);
            // 
            // workername
            // 
            this.workername.DataPropertyName = "workername";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.workername.DefaultCellStyle = dataGridViewCellStyle2;
            this.workername.HeaderText = "姓名";
            this.workername.Name = "workername";
            // 
            // workdate
            // 
            this.workdate.DataPropertyName = "workdate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.workdate.DefaultCellStyle = dataGridViewCellStyle3;
            this.workdate.HeaderText = "工作日期";
            this.workdate.Name = "workdate";
            // 
            // starttime
            // 
            this.starttime.DataPropertyName = "starttime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.starttime.DefaultCellStyle = dataGridViewCellStyle4;
            this.starttime.HeaderText = "开始时间";
            this.starttime.Name = "starttime";
            // 
            // endtime
            // 
            this.endtime.DataPropertyName = "endtime";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.endtime.DefaultCellStyle = dataGridViewCellStyle5;
            this.endtime.HeaderText = "结束时间";
            this.endtime.Name = "endtime";
            // 
            // deduct
            // 
            this.deduct.DataPropertyName = "deduct";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.deduct.DefaultCellStyle = dataGridViewCellStyle6;
            this.deduct.HeaderText = "扣除时间(小时)";
            this.deduct.Name = "deduct";
            // 
            // duration
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.duration.DefaultCellStyle = dataGridViewCellStyle7;
            this.duration.HeaderText = "时长（小时）";
            this.duration.Name = "duration";
            // 
            // deductreason
            // 
            this.deductreason.DataPropertyName = "deductreason";
            this.deductreason.HeaderText = "扣除原因";
            this.deductreason.Name = "deductreason";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.labShiChang);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(2, 526);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 33);
            this.panel1.TabIndex = 1;
            // 
            // labShiChang
            // 
            this.labShiChang.AutoSize = true;
            this.labShiChang.Location = new System.Drawing.Point(66, 9);
            this.labShiChang.Name = "labShiChang";
            this.labShiChang.Size = new System.Drawing.Size(32, 17);
            this.labShiChang.TabIndex = 3;
            this.labShiChang.Text = "      ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "总时长：";
            // 
            // backTianShu
            // 
            this.backTianShu.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backTianShu_DoWork);
            this.backTianShu.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backTianShu_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.button1.Location = new System.Drawing.Point(1001, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "导 出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboxUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
         private System.Windows.Forms.DateTimePicker endData;
        private System.Windows.Forms.DateTimePicker startData;
        private System.Windows.Forms.Label label4;
       
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Chaxun;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Personnel;
        private System.Windows.Forms.Button btn_outPut;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn workername;
        private System.Windows.Forms.DataGridViewTextBoxColumn workdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn deduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn deductreason;
        private System.ComponentModel.BackgroundWorker backTianShu;
        private System.Windows.Forms.Label labShiChang;
        private System.Windows.Forms.Button button1;
    }
}