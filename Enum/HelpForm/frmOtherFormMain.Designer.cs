namespace Enum.HelpForm
{
    partial class frmOtherFormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtherFormMain));
            this.btnPassWordOrText = new Enum.OwerControl.TTButton();
            this.btnVido = new Enum.OwerControl.TTButton();
            this.btnDecode = new Enum.OwerControl.TTButton();
            this.btnEmail = new Enum.OwerControl.TTButton();
            this.SuspendLayout();
            // 
            // btnPassWordOrText
            // 
            this.btnPassWordOrText.Location = new System.Drawing.Point(12, 11);
            this.btnPassWordOrText.Name = "btnPassWordOrText";
            this.btnPassWordOrText.Size = new System.Drawing.Size(128, 23);
            this.btnPassWordOrText.TabIndex = 0;
            this.btnPassWordOrText.Text = "加解密";
            this.btnPassWordOrText.UseVisualStyleBackColor = true;
            this.btnPassWordOrText.Click += new System.EventHandler(this.btnPassWordOrText_Click);
            // 
            // btnVido
            // 
            this.btnVido.Location = new System.Drawing.Point(12, 40);
            this.btnVido.Name = "btnVido";
            this.btnVido.Size = new System.Drawing.Size(128, 23);
            this.btnVido.TabIndex = 1;
            this.btnVido.Text = "视频转码";
            this.btnVido.UseVisualStyleBackColor = true;
            this.btnVido.Click += new System.EventHandler(this.btnVido_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(12, 69);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(128, 23);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "编码进制";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(12, 98);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(128, 23);
            this.btnEmail.TabIndex = 3;
            this.btnEmail.Text = "发送邮箱";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // frmOtherFormMain
            // 
            this.ClientSize = new System.Drawing.Size(148, 280);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnVido);
            this.Controls.Add(this.btnPassWordOrText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOtherFormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private OwerControl.TTButton btnPassWordOrText;
        private OwerControl.TTButton btnVido;
        private OwerControl.TTButton btnDecode;
        private OwerControl.TTButton btnEmail;
    }
}
