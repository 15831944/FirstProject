using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsharpHttpHelper;
using Enum.ButtonLogic;
using Enum.Helper;
using EnumSpace;

namespace Enum.HelpForm
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        public void btnToPassword_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string text = txtText.Text;
            string type = cboType.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(type))
            {
                txtText.Text = getPT(password,type);
            }
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
                savePT(dictionaryPassword);

            }
        }


        private string getPT(string Password, string type)
        {
            EnumDBContext ec = new EnumDBContext();
            var db = ec.Set<DictionaryPassword>();
            string pwd = "";
            DictionaryPassword model = db.FirstOrDefault(c => c.PwdType == type && c.Password == Password);
            if (model == null)
            {
                pwd = "密码：" + Password + " 类型：" + type + "未找到对应文本";
            }
            else
            {
                pwd = model.Plaintext;
            }
            ec.SaveChanges();
            ec.Dispose();
            return pwd;
        }

        private void savePT(DictionaryPassword model)
        {
            EnumDBContext ec = new EnumDBContext();
            var db = ec.Set<DictionaryPassword>();
            if (db.FirstOrDefault(c => c.Password == model.Password && c.Plaintext == model.Plaintext) == null)
            {
                db.Add(model);
            }
            ec.SaveChanges();
            ec.Dispose();
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
