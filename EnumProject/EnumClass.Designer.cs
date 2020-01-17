using EnumProject.OwerControl;
using System;
using System.Collections.Generic;
using System.Linq;
using EnumProject.ButtonLogic;

namespace EnumSpace
{
    partial class EnumClass
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnumClass));
            this.Nicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemOne = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.scan = new EnumProject.OwerControl.TTGroupBox();
            this.btnPT = new EnumProject.OwerControl.TTButton();
            this.btnAppUp = new EnumProject.OwerControl.TTButton();
            this.btnAppDown = new EnumProject.OwerControl.TTButton();
            this.btnAppTop = new EnumProject.OwerControl.TTButton();
            this.btnWebUp = new EnumProject.OwerControl.TTButton();
            this.btnWebDown = new EnumProject.OwerControl.TTButton();
            this.btnWebTop = new EnumProject.OwerControl.TTButton();
            this.btnWebCreate = new EnumProject.OwerControl.TTButton();
            this.webbtn = new EnumProject.OwerControl.TTTextBox();
            this.webwldz = new EnumProject.OwerControl.TTLabel();
            this.webanmc = new EnumProject.OwerControl.TTLabel();
            this.appurl = new EnumProject.OwerControl.TTTextBox();
            this.btnWebClear = new EnumProject.OwerControl.TTButton();
            this.btnAppClear = new EnumProject.OwerControl.TTButton();
            this.webllq = new EnumProject.OwerControl.TTTextBox();
            this.btnAppCreate = new EnumProject.OwerControl.TTButton();
            this.webllqmc = new EnumProject.OwerControl.TTLabel();
            this.appanmc = new EnumProject.OwerControl.TTLabel();
            this.weburl = new EnumProject.OwerControl.TTTextBox();
            this.appname = new EnumProject.OwerControl.TTTextBox();
            this.webwz = new EnumProject.OwerControl.TTLabel();
            this.btnClose = new EnumProject.OwerControl.TTButton();
            this.appan = new EnumProject.OwerControl.TTGroupBox();
            this.panApp = new EnumProject.OwerControl.TTPanel();
            this.AppSB = new EnumProject.OwerControl.TTVScrollBar();
            this.hf = new EnumProject.OwerControl.TTButton();
            this.sc = new EnumProject.OwerControl.TTButton();
            this.ycxs = new EnumProject.OwerControl.TTButton();
            this.weban = new EnumProject.OwerControl.TTGroupBox();
            this.panWeb = new EnumProject.OwerControl.TTPanel();
            this.WebSB = new EnumProject.OwerControl.TTVScrollBar();
            this.hfan = new EnumProject.OwerControl.TTGroupBox();
            this.panHF = new EnumProject.OwerControl.TTPanel();
            this.HfSB = new EnumProject.OwerControl.TTVScrollBar();
            this.CMS.SuspendLayout();
            this.scan.SuspendLayout();
            this.appan.SuspendLayout();
            this.panApp.SuspendLayout();
            this.weban.SuspendLayout();
            this.panWeb.SuspendLayout();
            this.hfan.SuspendLayout();
            this.panHF.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nicon
            // 
            this.Nicon.ContextMenuStrip = this.CMS;
            this.Nicon.Icon = ((System.Drawing.Icon)(resources.GetObject("Nicon.Icon")));
            this.Nicon.Text = "快捷菜单";
            this.Nicon.Visible = true;
            // 
            // CMS
            // 
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemOne,
            this.ItemTwo});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(101, 48);
            // 
            // ItemOne
            // 
            this.ItemOne.Name = "ItemOne";
            this.ItemOne.Size = new System.Drawing.Size(100, 22);
            this.ItemOne.Text = "显示";
            // 
            // ItemTwo
            // 
            this.ItemTwo.Name = "ItemTwo";
            this.ItemTwo.Size = new System.Drawing.Size(100, 22);
            this.ItemTwo.Text = "退出";
            // 
            // scan
            // 
            this.scan.Controls.Add(this.btnPT);
            this.scan.Controls.Add(this.btnAppUp);
            this.scan.Controls.Add(this.btnAppDown);
            this.scan.Controls.Add(this.btnAppTop);
            this.scan.Controls.Add(this.btnWebUp);
            this.scan.Controls.Add(this.btnWebDown);
            this.scan.Controls.Add(this.btnWebTop);
            this.scan.Controls.Add(this.btnWebCreate);
            this.scan.Controls.Add(this.webbtn);
            this.scan.Controls.Add(this.webwldz);
            this.scan.Controls.Add(this.webanmc);
            this.scan.Controls.Add(this.appurl);
            this.scan.Controls.Add(this.btnWebClear);
            this.scan.Controls.Add(this.btnAppClear);
            this.scan.Controls.Add(this.webllq);
            this.scan.Controls.Add(this.btnAppCreate);
            this.scan.Controls.Add(this.webllqmc);
            this.scan.Controls.Add(this.appanmc);
            this.scan.Controls.Add(this.weburl);
            this.scan.Controls.Add(this.appname);
            this.scan.Controls.Add(this.webwz);
            this.scan.Location = new System.Drawing.Point(530, 20);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(540, 330);
            this.scan.TabIndex = 34;
            this.scan.TabStop = false;
            this.scan.Text = "生成按钮";
            this.scan.Visible = false;
            // 
            // btnPT
            // 
            this.btnPT.Location = new System.Drawing.Point(63, 104);
            this.btnPT.Name = "btnPT";
            this.btnPT.Size = new System.Drawing.Size(44, 34);
            this.btnPT.TabIndex = 39;
            this.btnPT.Text = "其他";
            this.btnPT.UseVisualStyleBackColor = true;
            // 
            // btnAppUp
            // 
            this.btnAppUp.Location = new System.Drawing.Point(399, 249);
            this.btnAppUp.Name = "btnAppUp";
            this.btnAppUp.Size = new System.Drawing.Size(44, 28);
            this.btnAppUp.TabIndex = 38;
            this.btnAppUp.Text = "👆";
            this.btnAppUp.UseVisualStyleBackColor = true;
            // 
            // btnAppDown
            // 
            this.btnAppDown.Location = new System.Drawing.Point(399, 276);
            this.btnAppDown.Name = "btnAppDown";
            this.btnAppDown.Size = new System.Drawing.Size(44, 28);
            this.btnAppDown.TabIndex = 37;
            this.btnAppDown.Text = "👇";
            this.btnAppDown.UseVisualStyleBackColor = true;
            // 
            // btnAppTop
            // 
            this.btnAppTop.Location = new System.Drawing.Point(136, 260);
            this.btnAppTop.Name = "btnAppTop";
            this.btnAppTop.Size = new System.Drawing.Size(44, 34);
            this.btnAppTop.TabIndex = 36;
            this.btnAppTop.Text = "置顶";
            this.btnAppTop.UseVisualStyleBackColor = true;
            // 
            // btnWebUp
            // 
            this.btnWebUp.Location = new System.Drawing.Point(399, 92);
            this.btnWebUp.Name = "btnWebUp";
            this.btnWebUp.Size = new System.Drawing.Size(44, 28);
            this.btnWebUp.TabIndex = 35;
            this.btnWebUp.Text = "👆";
            this.btnWebUp.UseVisualStyleBackColor = true;
            // 
            // btnWebDown
            // 
            this.btnWebDown.Location = new System.Drawing.Point(399, 119);
            this.btnWebDown.Name = "btnWebDown";
            this.btnWebDown.Size = new System.Drawing.Size(44, 28);
            this.btnWebDown.TabIndex = 34;
            this.btnWebDown.Text = "👇";
            this.btnWebDown.UseVisualStyleBackColor = true;
            // 
            // btnWebTop
            // 
            this.btnWebTop.Location = new System.Drawing.Point(136, 104);
            this.btnWebTop.Name = "btnWebTop";
            this.btnWebTop.Size = new System.Drawing.Size(44, 34);
            this.btnWebTop.TabIndex = 33;
            this.btnWebTop.Text = "置顶";
            this.btnWebTop.UseVisualStyleBackColor = true;
            // 
            // btnWebCreate
            // 
            this.btnWebCreate.Location = new System.Drawing.Point(203, 104);
            this.btnWebCreate.Name = "btnWebCreate";
            this.btnWebCreate.Size = new System.Drawing.Size(75, 34);
            this.btnWebCreate.TabIndex = 18;
            this.btnWebCreate.Text = "生成按钮";
            this.btnWebCreate.UseVisualStyleBackColor = true;
            // 
            // webbtn
            // 
            this.webbtn.BackColor = System.Drawing.SystemColors.Window;
            this.webbtn.Location = new System.Drawing.Point(113, 36);
            this.webbtn.Name = "webbtn";
            this.webbtn.Size = new System.Drawing.Size(109, 21);
            this.webbtn.TabIndex = 16;
            // 
            // webwldz
            // 
            this.webwldz.AutoSize = true;
            this.webwldz.Location = new System.Drawing.Point(42, 221);
            this.webwldz.Name = "webwldz";
            this.webwldz.Size = new System.Drawing.Size(65, 12);
            this.webwldz.TabIndex = 32;
            this.webwldz.Text = "物理地址：";
            // 
            // webanmc
            // 
            this.webanmc.AutoSize = true;
            this.webanmc.Location = new System.Drawing.Point(42, 39);
            this.webanmc.Name = "webanmc";
            this.webanmc.Size = new System.Drawing.Size(65, 12);
            this.webanmc.TabIndex = 17;
            this.webanmc.Text = "按钮名称：";
            // 
            // appurl
            // 
            this.appurl.Location = new System.Drawing.Point(113, 218);
            this.appurl.Name = "appurl";
            this.appurl.Size = new System.Drawing.Size(359, 21);
            this.appurl.TabIndex = 31;
            // 
            // btnWebClear
            // 
            this.btnWebClear.Location = new System.Drawing.Point(301, 104);
            this.btnWebClear.Name = "btnWebClear";
            this.btnWebClear.Size = new System.Drawing.Size(75, 34);
            this.btnWebClear.TabIndex = 19;
            this.btnWebClear.Text = "清空数据";
            this.btnWebClear.UseVisualStyleBackColor = true;
            // 
            // btnAppClear
            // 
            this.btnAppClear.Location = new System.Drawing.Point(301, 260);
            this.btnAppClear.Name = "btnAppClear";
            this.btnAppClear.Size = new System.Drawing.Size(75, 34);
            this.btnAppClear.TabIndex = 28;
            this.btnAppClear.Text = "清空数据";
            this.btnAppClear.UseVisualStyleBackColor = true;
            // 
            // webllq
            // 
            this.webllq.Location = new System.Drawing.Point(359, 36);
            this.webllq.Name = "webllq";
            this.webllq.Size = new System.Drawing.Size(113, 21);
            this.webllq.TabIndex = 21;
            // 
            // btnAppCreate
            // 
            this.btnAppCreate.Location = new System.Drawing.Point(203, 260);
            this.btnAppCreate.Name = "btnAppCreate";
            this.btnAppCreate.Size = new System.Drawing.Size(75, 34);
            this.btnAppCreate.TabIndex = 27;
            this.btnAppCreate.Text = "生成按钮";
            this.btnAppCreate.UseVisualStyleBackColor = true;
            // 
            // webllqmc
            // 
            this.webllqmc.AutoSize = true;
            this.webllqmc.Location = new System.Drawing.Point(264, 39);
            this.webllqmc.Name = "webllqmc";
            this.webllqmc.Size = new System.Drawing.Size(77, 12);
            this.webllqmc.TabIndex = 22;
            this.webllqmc.Text = "浏览器名称：";
            // 
            // appanmc
            // 
            this.appanmc.AutoSize = true;
            this.appanmc.Location = new System.Drawing.Point(42, 192);
            this.appanmc.Name = "appanmc";
            this.appanmc.Size = new System.Drawing.Size(65, 12);
            this.appanmc.TabIndex = 26;
            this.appanmc.Text = "按钮名称：";
            // 
            // weburl
            // 
            this.weburl.Location = new System.Drawing.Point(113, 65);
            this.weburl.Name = "weburl";
            this.weburl.Size = new System.Drawing.Size(359, 21);
            this.weburl.TabIndex = 23;
            // 
            // appname
            // 
            this.appname.Location = new System.Drawing.Point(113, 189);
            this.appname.Name = "appname";
            this.appname.Size = new System.Drawing.Size(359, 21);
            this.appname.TabIndex = 25;
            // 
            // webwz
            // 
            this.webwz.AutoSize = true;
            this.webwz.Location = new System.Drawing.Point(66, 68);
            this.webwz.Name = "webwz";
            this.webwz.Size = new System.Drawing.Size(41, 12);
            this.webwz.TabIndex = 24;
            this.webwz.Text = "网址：";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(417, 439);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 41);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // appan
            // 
            this.appan.Controls.Add(this.panApp);
            this.appan.Location = new System.Drawing.Point(220, 20);
            this.appan.Name = "appan";
            this.appan.Size = new System.Drawing.Size(170, 460);
            this.appan.TabIndex = 38;
            this.appan.TabStop = false;
            this.appan.Text = "本地链接";
            // 
            // panApp
            // 
            this.panApp.Controls.Add(this.AppSB);
            this.panApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panApp.Location = new System.Drawing.Point(3, 17);
            this.panApp.Name = "panApp";
            this.panApp.Size = new System.Drawing.Size(164, 440);
            this.panApp.TabIndex = 1;
            // 
            // AppSB
            // 
            this.AppSB.LargeChange = 1;
            this.AppSB.Location = new System.Drawing.Point(147, 3);
            this.AppSB.Maximum = 0;
            this.AppSB.Name = "AppSB";
            this.AppSB.Size = new System.Drawing.Size(17, 440);
            this.AppSB.TabIndex = 1;
            // 
            // hf
            // 
            this.hf.Location = new System.Drawing.Point(417, 295);
            this.hf.Name = "hf";
            this.hf.Size = new System.Drawing.Size(75, 126);
            this.hf.TabIndex = 37;
            this.hf.Text = "恢复";
            // 
            // sc
            // 
            this.sc.Location = new System.Drawing.Point(417, 163);
            this.sc.Name = "sc";
            this.sc.Size = new System.Drawing.Size(75, 126);
            this.sc.TabIndex = 36;
            this.sc.Text = "删除";
            // 
            // ycxs
            // 
            this.ycxs.Location = new System.Drawing.Point(417, 34);
            this.ycxs.Name = "ycxs";
            this.ycxs.Size = new System.Drawing.Size(75, 122);
            this.ycxs.TabIndex = 35;
            this.ycxs.Text = "隐藏/显示";
            // 
            // weban
            // 
            this.weban.Controls.Add(this.panWeb);
            this.weban.Location = new System.Drawing.Point(30, 20);
            this.weban.Name = "weban";
            this.weban.Size = new System.Drawing.Size(170, 460);
            this.weban.TabIndex = 33;
            this.weban.TabStop = false;
            this.weban.Text = "网页按钮";
            // 
            // panWeb
            // 
            this.panWeb.Controls.Add(this.WebSB);
            this.panWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panWeb.Location = new System.Drawing.Point(3, 17);
            this.panWeb.Name = "panWeb";
            this.panWeb.Size = new System.Drawing.Size(164, 440);
            this.panWeb.TabIndex = 0;
            // 
            // WebSB
            // 
            this.WebSB.LargeChange = 1;
            this.WebSB.Location = new System.Drawing.Point(147, 0);
            this.WebSB.Maximum = 0;
            this.WebSB.Name = "WebSB";
            this.WebSB.Size = new System.Drawing.Size(17, 440);
            this.WebSB.TabIndex = 0;
            // 
            // hfan
            // 
            this.hfan.Controls.Add(this.panHF);
            this.hfan.Location = new System.Drawing.Point(530, 20);
            this.hfan.Name = "hfan";
            this.hfan.Size = new System.Drawing.Size(170, 460);
            this.hfan.TabIndex = 39;
            this.hfan.TabStop = false;
            this.hfan.Text = "恢复按钮";
            // 
            // panHF
            // 
            this.panHF.Controls.Add(this.HfSB);
            this.panHF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panHF.Location = new System.Drawing.Point(3, 17);
            this.panHF.Name = "panHF";
            this.panHF.Size = new System.Drawing.Size(164, 440);
            this.panHF.TabIndex = 1;
            // 
            // HfSB
            // 
            this.HfSB.LargeChange = 1;
            this.HfSB.Location = new System.Drawing.Point(147, 3);
            this.HfSB.Maximum = 0;
            this.HfSB.Name = "HfSB";
            this.HfSB.Size = new System.Drawing.Size(17, 440);
            this.HfSB.TabIndex = 2;
            // 
            // EnumClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1164, 550);
            this.Controls.Add(this.scan);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.appan);
            this.Controls.Add(this.hf);
            this.Controls.Add(this.sc);
            this.Controls.Add(this.ycxs);
            this.Controls.Add(this.weban);
            this.Controls.Add(this.hfan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnumClass";
            this.ShowInTaskbar = false;
            this.Text = "Enum";
            this.Load += new System.EventHandler(this.myLoad);
            this.CMS.ResumeLayout(false);
            this.scan.ResumeLayout(false);
            this.scan.PerformLayout();
            this.appan.ResumeLayout(false);
            this.panApp.ResumeLayout(false);
            this.weban.ResumeLayout(false);
            this.panWeb.ResumeLayout(false);
            this.hfan.ResumeLayout(false);
            this.panHF.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion
        private TTTextBox webbtn;
        private TTLabel webanmc;
        private TTButton btnWebCreate;
        private TTButton btnWebClear;
        private TTLabel webllqmc;
        private TTTextBox webllq;
        private TTLabel webwz;
        private TTTextBox weburl;
        private TTLabel webwldz;
        private TTTextBox appurl;
        private TTButton btnAppClear;
        private TTButton btnAppCreate;
        private TTLabel appanmc;
        private TTTextBox appname;
        private TTGroupBox weban;
        private TTGroupBox scan;
        private TTButton ycxs;
        private TTButton sc;
        private TTButton hf;
        private TTGroupBox appan;
        private System.Windows.Forms.NotifyIcon Nicon;
        private TTGroupBox hfan;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem ItemOne;
        private System.Windows.Forms.ToolStripMenuItem ItemTwo;
        private TTButton btnClose;
        private TTPanel panWeb;
        private TTPanel panApp;
        private TTPanel panHF;
        private TTVScrollBar WebSB;
        private TTVScrollBar AppSB;
        private TTVScrollBar HfSB;
        private TTButton btnWebTop;
        private TTButton btnWebUp;
        private TTButton btnWebDown;
        private TTButton btnAppUp;
        private TTButton btnAppDown;
        private TTButton btnAppTop;
        private TTButton btnPT;
    }




}

