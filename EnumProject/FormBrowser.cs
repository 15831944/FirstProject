using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace EnumSpace
{
    public partial class FormBrowser : Form
    {
        public FormBrowser(string url)
        {
            InitializeComponent();
            ShowBrower(url);
        }
        // public ChromiumWebBrowser browser;
        public void ShowBrower(string url)
        {
            //if (Cef.IsInitialized)
            //{
            //    Cef.();
            //}
            if (!Cef.IsInitialized)
            {
                Cef.Initialize(new CefSettings());
            }
            ChromiumWebBrowser browser = new ChromiumWebBrowser(url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

        }

        protected override void OnClosed(EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
