namespace EnumProject.HelpForm
{
    partial class frmIdentCode
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
            this.lblYZM = new EnumProject.OwerControl.TTLabel();
            this.txtIdentCode = new EnumProject.OwerControl.TTTextBox();
            this.picIdentCode = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblEmailUser = new EnumProject.OwerControl.TTLabel();
            this.txtUser = new EnumProject.OwerControl.TTTextBox();
            this.lblPassword = new EnumProject.OwerControl.TTLabel();
            this.txtPwd = new EnumProject.OwerControl.TTTextBox();
            this.btnCon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIdentCode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYZM
            // 
            this.lblYZM.AutoSize = true;
            this.lblYZM.Location = new System.Drawing.Point(80, 125);
            this.lblYZM.Name = "lblYZM";
            this.lblYZM.Size = new System.Drawing.Size(53, 12);
            this.lblYZM.TabIndex = 7;
            this.lblYZM.Text = "验证码：";
            // 
            // txtIdentCode
            // 
            this.txtIdentCode.Location = new System.Drawing.Point(234, 119);
            this.txtIdentCode.Name = "txtIdentCode";
            this.txtIdentCode.Size = new System.Drawing.Size(66, 21);
            this.txtIdentCode.TabIndex = 6;
            // 
            // picIdentCode
            // 
            this.picIdentCode.Location = new System.Drawing.Point(128, 119);
            this.picIdentCode.Name = "picIdentCode";
            this.picIdentCode.Size = new System.Drawing.Size(100, 23);
            this.picIdentCode.TabIndex = 5;
            this.picIdentCode.TabStop = false;
            this.picIdentCode.Click += new System.EventHandler(this.picIdentCode_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(87, 159);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "确认";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblEmailUser
            // 
            this.lblEmailUser.AutoSize = true;
            this.lblEmailUser.Location = new System.Drawing.Point(80, 31);
            this.lblEmailUser.Name = "lblEmailUser";
            this.lblEmailUser.Size = new System.Drawing.Size(41, 12);
            this.lblEmailUser.TabIndex = 8;
            this.lblEmailUser.Text = "账号：";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(139, 28);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(161, 21);
            this.txtUser.TabIndex = 9;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(80, 77);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 12);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(139, 74);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(161, 21);
            this.txtPwd.TabIndex = 11;
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(248, 159);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(75, 23);
            this.btnCon.TabIndex = 12;
            this.btnCon.Text = "取消";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // frmIdentCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 202);
            this.Controls.Add(this.btnCon);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblEmailUser);
            this.Controls.Add(this.lblYZM);
            this.Controls.Add(this.txtIdentCode);
            this.Controls.Add(this.picIdentCode);
            this.Controls.Add(this.btnLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIdentCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "验证码";
            ((System.ComponentModel.ISupportInitialize)(this.picIdentCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OwerControl.TTLabel lblYZM;
        private OwerControl.TTTextBox txtIdentCode;
        private System.Windows.Forms.PictureBox picIdentCode;
        private System.Windows.Forms.Button btnLogin;
        private OwerControl.TTLabel lblEmailUser;
        private OwerControl.TTTextBox txtUser;
        private OwerControl.TTLabel lblPassword;
        private OwerControl.TTTextBox txtPwd;
        private System.Windows.Forms.Button btnCon;
    }
}