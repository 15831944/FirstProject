namespace EnumProject.HelpForm
{
    partial class frmMsg
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
            this.lblTime = new EnumProject.OwerControl.TTLabel();
            this.ttLabel2 = new EnumProject.OwerControl.TTLabel();
            this.lblMsg = new EnumProject.OwerControl.TTLabel();
            this.lblTitle = new EnumProject.OwerControl.TTLabel();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(150, 85);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(53, 12);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00:00";
            // 
            // ttLabel2
            // 
            this.ttLabel2.AutoSize = true;
            this.ttLabel2.Location = new System.Drawing.Point(85, 85);
            this.ttLabel2.Name = "ttLabel2";
            this.ttLabel2.Size = new System.Drawing.Size(59, 12);
            this.ttLabel2.TabIndex = 2;
            this.ttLabel2.Text = "时    间:";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(150, 64);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(53, 12);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "ttLabel1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(85, 64);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(59, 12);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "系统提示:";
            // 
            // frmMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 164);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.ttLabel2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提示窗体";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public EnumProject.OwerControl.TTLabel lblTitle;
        public EnumProject.OwerControl.TTLabel lblMsg;
        public OwerControl.TTLabel lblTime;
        public OwerControl.TTLabel ttLabel2;
    }
}