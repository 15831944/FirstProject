using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsharpHttpHelper;
using EnumProject.ButtonLogic;
using EnumProject.Helper;
using EnumSpace;

namespace EnumProject.HelpForm
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        public void btnToPassword_Click(object sender, EventArgs e)
        {
            setText();
        }
        private void btnToText_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string text = txtText.Text;
            string type = cboType.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(type))
            {
                string pwd = PasswordHelper.HashPasswordForStoringInConfigFile(text, type);
                txtPassword.Text = pwd;
                DictionaryPassword dictionaryPassword = new DictionaryPassword();
                dictionaryPassword.Password = txtPassword.Text;
                dictionaryPassword.Plaintext = text;
                dictionaryPassword.PwdType = type;
                dictionaryPassword.CreateDate = DateTime.Now;
                Task.Run(() =>
                {
                    ActionHelper.saveInfo(dictionaryPassword);
                });


            }
        }

        frmMsg frm = null;
        delegate void showmsg();
        Task task = null;
        DateTime dat = new DateTime(0);
        private string getPT(string Password, string type)
        {
            string pwd = "";
            if (!PubulicData.isDicPWD)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(DoWorker);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerComplete);
                worker.RunWorkerAsync();
            }
            else
            {
                List<DictionaryPassword> db = PubulicData.sourceData[PubulicData.ClassName.DictionaryPassword.ToString()] as List<DictionaryPassword>;
                DictionaryPassword model = db.FirstOrDefault(c => c.PwdType == type && c.Password == Password);
                if (model == null)
                {
                    pwd = "密码：" + Password + " 类型：" + type + "未找到对应文本";
                }
                else
                {
                    pwd = model.Plaintext; 
                }
            }
            return pwd;
        }

        private void WorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            while (!PubulicData.isDicPWD)
            {
                Invoke(new showmsg(ShowMsg));
            }
            Invoke(new showmsg(CloseMsg));
           DialogResult dr=MessageBox.Show("加载成功！","提示：",MessageBoxButtons.OK);
            if (dr == DialogResult.OK)
            {
                setText();
            }
        }

        public void setText() {
            string password = txtPassword.Text;
            string type = cboType.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(type))
            {
                txtText.Text = getPT(password, type);
            }
        }

        public void DoWorker(object sender,DoWorkEventArgs e)
        {
            Task.Run(() =>
            {
                frm = new frmMsg();
                frm.ShowDialog();
            });
            Thread.Sleep(500);
        }
        public void ShowMsg()
        {
            dat = dat.AddSeconds(1);
            string dt = dat.ToLongTimeString();
            frm.lblMsg.Text = "正在加载密码字典请等候.";
            Thread.Sleep(250);
            frm.lblMsg.Text = "正在加载密码字典请等候.";
            Thread.Sleep(250);
            frm.lblMsg.Text = "正在加载密码字典请等候..";
            Thread.Sleep(250);
            frm.lblMsg.Text = "正在加载密码字典请等候...";
            Thread.Sleep(250);
            frm.lblTime.Text = dt;
        }

        public void CloseMsg()
        {
            frm.Close();
        }
        private void Password_Load(object sender, EventArgs e)
        {
            List<string> source = new List<string>();
            source.Add("sha1");
            source.Add("md5");
            source.Add("sha256");
            source.Add("sha384");
            source.Add("sha512");
            cboType.DataSource = source;
            cboType.SelectedIndex = 1;
        }

        protected override void OnClosed(EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
