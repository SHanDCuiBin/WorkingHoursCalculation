namespace WorkingHoursCalculation
{
    partial class LoginForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.checkIsRemeber = new System.Windows.Forms.CheckBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(267, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(267, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtUserName.Location = new System.Drawing.Point(344, 91);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(197, 29);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPassword.Location = new System.Drawing.Point(344, 141);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(197, 29);
            this.txtPassword.TabIndex = 3;
            // 
            // checkIsRemeber
            // 
            this.checkIsRemeber.AutoSize = true;
            this.checkIsRemeber.Location = new System.Drawing.Point(457, 182);
            this.checkIsRemeber.Name = "checkIsRemeber";
            this.checkIsRemeber.Size = new System.Drawing.Size(84, 24);
            this.checkIsRemeber.TabIndex = 4;
            this.checkIsRemeber.Text = "记住密码";
            this.checkIsRemeber.UseVisualStyleBackColor = true;
            // 
            // btn_Login
            // 
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Login.Location = new System.Drawing.Point(305, 229);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(91, 37);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "登  陆";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            this.btn_Login.MouseEnter += new System.EventHandler(this.BtnSDSRSave_MouseEnter);
            this.btn_Login.MouseLeave += new System.EventHandler(this.BtnSDSRSave_MouseLeave);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Cancel.Location = new System.Drawing.Point(450, 229);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(91, 37);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "取  消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            this.btn_Cancel.MouseEnter += new System.EventHandler(this.BtnSDSRSave_MouseEnter);
            this.btn_Cancel.MouseLeave += new System.EventHandler(this.BtnSDSRSave_MouseLeave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(583, 315);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.checkIsRemeber);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox checkIsRemeber;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Cancel;
    }
}

