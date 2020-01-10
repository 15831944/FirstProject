using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumProject.HelpForm
{
    public partial class frmSendEmail : Form
    {
        public string EmailUser = "";
        public string EmailPwd = "";
        public List<string> type = new List<string>();
        public Dictionary<string, string> types = new Dictionary<string, string>();

        public frmSendEmail()
        {
            InitializeComponent();
            setType();
            setEnumSource();
        }
        public void setType()
        {
            types.Add("163邮箱", "smtp.163.com");
            types.Add("QQ邮箱", "smtp.QQ.com");
            types.Add("126邮箱", "smtp.126.com");
            foreach (string item in types.Keys)
            {
                type.Add(item);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string toUserEmail = txtToUser.Text;
            string mailTitle = txtTitle.Text;
            string mailContent = txtContent.Text;
            SendEmail(toUserEmail, mailTitle, mailContent);
        }
        public void setEnumSource()
        {
            comType.DataSource = type;
            comType.SelectedIndex = 0;
        }
        public void SendEmail(string toUserEmail, string mailTitle, string mailContent)
        {
            try
            {
                string host = "smtp.163.com";
                MailMessage mailMessage = new MailMessage();
                //内容格式为html
                mailMessage.IsBodyHtml = true;
                //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
                mailMessage.From = new MailAddress(EmailUser);
                //收件人邮箱地址
                mailMessage.To.Add(new MailAddress(toUserEmail));
                //邮件标题
                mailMessage.Subject = mailTitle;
                //邮件内容
                mailMessage.Body = mailContent;
                //实例化一个SmtpClient类。
                SmtpClient client = new SmtpClient();
                //在这里我使用的是IP，如果是QQ则：smtp.qq.com；126邮箱：smtp.126.com

                if (comType.SelectedValue != null && comType.SelectedValue.ToString() != "")
                {
                    host = types[comType.SelectedValue.ToString()];
                }
                client.Host = host;
                //使用安全加密连接。
                client.EnableSsl = false;
                //不和请求一块发送。
                client.UseDefaultCredentials = false;
                //验证发件人身份(发件人的邮箱账号和密码);
                client.Credentials = new NetworkCredential(EmailUser, EmailPwd);

                if (!string.IsNullOrEmpty(toUserEmail))
                {
                    //发送
                    client.Send(mailMessage);
                }
                MessageBox.Show("发送成功！");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        protected override void OnClosed(EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
