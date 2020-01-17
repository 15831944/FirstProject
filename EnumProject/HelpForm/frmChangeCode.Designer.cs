namespace EnumProject.HelpForm
{
    partial class frmChangeCode
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
            this.lblTwo = new EnumProject.OwerControl.TTLabel();
            this.txtTen = new EnumProject.OwerControl.TTTextBox();
            this.ttLabel2 = new EnumProject.OwerControl.TTLabel();
            this.txtEight = new EnumProject.OwerControl.TTTextBox();
            this.ttLabel3 = new EnumProject.OwerControl.TTLabel();
            this.txtTwo = new EnumProject.OwerControl.TTTextBox();
            this.ttLabel1 = new EnumProject.OwerControl.TTLabel();
            this.txtSixteen = new EnumProject.OwerControl.TTTextBox();
            this.ttLabel7 = new EnumProject.OwerControl.TTLabel();
            this.txtUnicode = new EnumProject.OwerControl.TTTextBox();
            this.SuspendLayout();
            // 
            // lblTwo
            // 
            this.lblTwo.AutoSize = true;
            this.lblTwo.Location = new System.Drawing.Point(80, 96);
            this.lblTwo.Name = "lblTwo";
            this.lblTwo.Size = new System.Drawing.Size(53, 12);
            this.lblTwo.TabIndex = 3;
            this.lblTwo.Text = "二进制：";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(154, 173);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(475, 21);
            this.txtTen.TabIndex = 2;
            this.txtTen.Leave += new System.EventHandler(this.ClickTextChanged);
            // 
            // ttLabel2
            // 
            this.ttLabel2.AutoSize = true;
            this.ttLabel2.Location = new System.Drawing.Point(80, 176);
            this.ttLabel2.Name = "ttLabel2";
            this.ttLabel2.Size = new System.Drawing.Size(53, 12);
            this.ttLabel2.TabIndex = 5;
            this.ttLabel2.Text = "十进制：";
            // 
            // txtEight
            // 
            this.txtEight.Location = new System.Drawing.Point(154, 132);
            this.txtEight.Name = "txtEight";
            this.txtEight.Size = new System.Drawing.Size(475, 21);
            this.txtEight.TabIndex = 4;
            this.txtEight.Leave += new System.EventHandler(this.ClickTextChanged);
            // 
            // ttLabel3
            // 
            this.ttLabel3.AutoSize = true;
            this.ttLabel3.Location = new System.Drawing.Point(80, 135);
            this.ttLabel3.Name = "ttLabel3";
            this.ttLabel3.Size = new System.Drawing.Size(53, 12);
            this.ttLabel3.TabIndex = 7;
            this.ttLabel3.Text = "八进制：";
            // 
            // txtTwo
            // 
            this.txtTwo.Location = new System.Drawing.Point(154, 93);
            this.txtTwo.Name = "txtTwo";
            this.txtTwo.Size = new System.Drawing.Size(475, 21);
            this.txtTwo.TabIndex = 6;
            this.txtTwo.Leave += new System.EventHandler(this.ClickTextChanged);
            // 
            // ttLabel1
            // 
            this.ttLabel1.AutoSize = true;
            this.ttLabel1.Location = new System.Drawing.Point(68, 224);
            this.ttLabel1.Name = "ttLabel1";
            this.ttLabel1.Size = new System.Drawing.Size(65, 12);
            this.ttLabel1.TabIndex = 9;
            this.ttLabel1.Text = "十六进制：";
            // 
            // txtSixteen
            // 
            this.txtSixteen.Location = new System.Drawing.Point(154, 221);
            this.txtSixteen.Name = "txtSixteen";
            this.txtSixteen.Size = new System.Drawing.Size(475, 21);
            this.txtSixteen.TabIndex = 8;
            this.txtSixteen.Leave += new System.EventHandler(this.ClickTextChanged);
            // 
            // ttLabel7
            // 
            this.ttLabel7.AutoSize = true;
            this.ttLabel7.Location = new System.Drawing.Point(62, 267);
            this.ttLabel7.Name = "ttLabel7";
            this.ttLabel7.Size = new System.Drawing.Size(71, 12);
            this.ttLabel7.TabIndex = 17;
            this.ttLabel7.Text = "Unicode码：";
            // 
            // txtUnicode
            // 
            this.txtUnicode.Location = new System.Drawing.Point(154, 264);
            this.txtUnicode.Name = "txtUnicode";
            this.txtUnicode.Size = new System.Drawing.Size(475, 21);
            this.txtUnicode.TabIndex = 16;
            this.txtUnicode.Leave += new System.EventHandler(this.ClickTextChanged);
            // 
            // frmChangeCode
            // 
            this.ClientSize = new System.Drawing.Size(769, 415);
            this.Controls.Add(this.ttLabel7);
            this.Controls.Add(this.txtUnicode);
            this.Controls.Add(this.ttLabel1);
            this.Controls.Add(this.txtSixteen);
            this.Controls.Add(this.ttLabel3);
            this.Controls.Add(this.txtTwo);
            this.Controls.Add(this.ttLabel2);
            this.Controls.Add(this.txtEight);
            this.Controls.Add(this.lblTwo);
            this.Controls.Add(this.txtTen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TextChanged += new System.EventHandler(this.ClickTextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OwerControl.TTLabel lblTwo;
        private OwerControl.TTTextBox txtTen;
        private OwerControl.TTLabel ttLabel2;
        private OwerControl.TTTextBox txtEight;
        private OwerControl.TTLabel ttLabel3;
        private OwerControl.TTTextBox txtTwo;
        private OwerControl.TTLabel ttLabel1;
        private OwerControl.TTTextBox txtSixteen;
        private OwerControl.TTLabel ttLabel7;
        private OwerControl.TTTextBox txtUnicode;
    }
}
