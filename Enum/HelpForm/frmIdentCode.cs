using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enum.HelpForm
{
    public partial class frmIdentCode : Form
    {
        private static string Code = "";
        public frmIdentCode()
        {
            InitializeComponent();
            setPic();
        }

        public void getCode() {
            int[] ar = new int[62];
            byte[] cr = new byte[6];
            for (int i = 0; i < ar.Length; i++) {
                if (i < 10)
                {
                    ar[i] = i + 48;
                }
                else if (i < 36)
                {
                    ar[i] = i + 55;
                }
                else {
                    ar[i] = i + 61;
                }
            }
            Random rd = new Random();

            for (int j = 0; j < cr.Length; j++) {
                int c = rd.Next(0, 62);
                cr[j] = (byte)ar[c];
            }
            Code = Encoding.ASCII.GetString(cr);
        }

        public byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        public void setPic() {
            getCode();
            byte[] bt = CreateValidateGraphic(Code);
            MemoryStream mstm = new MemoryStream();
            mstm.Write(bt, 0, bt.Length);
            picIdentCode.Image = Image.FromStream(mstm);
        }

        private void picIdentCode_Click(object sender, EventArgs e)
        {
            setPic();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string wr = txtIdentCode.Text;
            string uc= txtUser.Text;
            string pw = txtPwd.Text;
            if (string.IsNullOrEmpty(uc) || string.IsNullOrEmpty(pw)) 
            {
                MessageBox.Show("邮箱账户或密码不能为空!");
                return;
            }
            if (wr.ToLower() == Code.ToLower())
            {
                
                frmSendEmail frmse = new frmSendEmail();
                frmse.EmailUser = uc;
                frmse.EmailPwd = pw;
                this.Hide();
                frmse.ShowDialog();
                if (frmse.DialogResult == DialogResult.OK) {
                    this.Show();
                }
            }
            else {
                MessageBox.Show("验证码输入有误,请检查！");
            }

        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
