namespace EnumProject.HelpForm
{
    partial class frmSendEmail
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
            this.txtContent = new EnumProject.OwerControl.TTTextBox();
            this.txtToUser = new EnumProject.OwerControl.TTTextBox();
            this.lblToUser = new EnumProject.OwerControl.TTLabel();
            this.btnSend = new EnumProject.OwerControl.TTButton();
            this.btnClear = new EnumProject.OwerControl.TTButton();
            this.lblTitle = new EnumProject.OwerControl.TTLabel();
            this.txtTitle = new EnumProject.OwerControl.TTTextBox();
            this.lblType = new EnumProject.OwerControl.TTLabel();
            this.comType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 35);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(776, 277);
            this.txtContent.TabIndex = 0;
            // 
            // txtToUser
            // 
            this.txtToUser.Location = new System.Drawing.Point(92, 339);
            this.txtToUser.Name = "txtToUser";
            this.txtToUser.Size = new System.Drawing.Size(687, 21);
            this.txtToUser.TabIndex = 1;
            // 
            // lblToUser
            // 
            this.lblToUser.AutoSize = true;
            this.lblToUser.Location = new System.Drawing.Point(16, 342);
            this.lblToUser.Name = "lblToUser";
            this.lblToUser.Size = new System.Drawing.Size(53, 12);
            this.lblToUser.TabIndex = 2;
            this.lblToUser.Text = "发送人：";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(568, 396);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(678, 396);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 12);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "标题：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(92, 8);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(687, 21);
            this.txtTitle.TabIndex = 5;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(16, 401);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(65, 12);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "邮箱类型：";
            // 
            // comType
            // 
            this.comType.FormattingEnabled = true;
            this.comType.Location = new System.Drawing.Point(87, 398);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(121, 20);
            this.comType.TabIndex = 9;
            // 
            // frmSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblToUser);
            this.Controls.Add(this.txtToUser);
            this.Controls.Add(this.txtContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发送邮件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OwerControl.TTTextBox txtContent;
        private OwerControl.TTTextBox txtToUser;
        private OwerControl.TTLabel lblToUser;
        private OwerControl.TTButton btnSend;
        private OwerControl.TTButton btnClear;
        private OwerControl.TTLabel lblTitle;
        private OwerControl.TTTextBox txtTitle;
        private OwerControl.TTLabel lblType;
        private System.Windows.Forms.ComboBox comType;
    }
}