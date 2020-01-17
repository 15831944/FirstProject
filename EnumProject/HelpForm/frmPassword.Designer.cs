namespace EnumProject.HelpForm
{
    partial class frmPassword
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
            this.txtPassword = new EnumProject.OwerControl.TTTextBox();
            this.txtText = new EnumProject.OwerControl.TTTextBox();
            this.btnToPassword = new EnumProject.OwerControl.TTButton();
            this.btnToText = new EnumProject.OwerControl.TTButton();
            this.lblPassword = new EnumProject.OwerControl.TTLabel();
            this.lblText = new EnumProject.OwerControl.TTLabel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.ttLabel1 = new EnumProject.OwerControl.TTLabel();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(118, 62);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(495, 103);
            this.txtPassword.TabIndex = 0;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(118, 265);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(495, 120);
            this.txtText.TabIndex = 1;
            // 
            // btnToPassword
            // 
            this.btnToPassword.Location = new System.Drawing.Point(147, 199);
            this.btnToPassword.Name = "btnToPassword";
            this.btnToPassword.Size = new System.Drawing.Size(75, 36);
            this.btnToPassword.TabIndex = 2;
            this.btnToPassword.Text = "解密";
            this.btnToPassword.UseVisualStyleBackColor = true;
            this.btnToPassword.Click += new System.EventHandler(this.btnToPassword_Click);
            // 
            // btnToText
            // 
            this.btnToText.Location = new System.Drawing.Point(240, 199);
            this.btnToText.Name = "btnToText";
            this.btnToText.Size = new System.Drawing.Size(75, 36);
            this.btnToText.TabIndex = 3;
            this.btnToText.Text = "加密";
            this.btnToText.UseVisualStyleBackColor = true;
            this.btnToText.Click += new System.EventHandler(this.btnToText_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(39, 87);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(41, 12);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "密文：";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(39, 306);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(41, 12);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "明文：";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(469, 208);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 20);
            this.cboType.TabIndex = 6;
            // 
            // ttLabel1
            // 
            this.ttLabel1.AutoSize = true;
            this.ttLabel1.Location = new System.Drawing.Point(370, 211);
            this.ttLabel1.Name = "ttLabel1";
            this.ttLabel1.Size = new System.Drawing.Size(77, 12);
            this.ttLabel1.TabIndex = 7;
            this.ttLabel1.Text = "加解密类型：";
            // 
            // frmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 450);
            this.Controls.Add(this.ttLabel1);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnToText);
            this.Controls.Add(this.btnToPassword);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtPassword);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.Load += new System.EventHandler(this.Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OwerControl.TTTextBox txtPassword;
        private OwerControl.TTTextBox txtText;
        private OwerControl.TTButton btnToPassword;
        private OwerControl.TTButton btnToText;
        private OwerControl.TTLabel lblPassword;
        private OwerControl.TTLabel lblText;
        private System.Windows.Forms.ComboBox cboType;
        private OwerControl.TTLabel ttLabel1;
    }
}