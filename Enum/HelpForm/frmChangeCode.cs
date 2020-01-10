using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EnumProject.OwerControl;

namespace EnumProject.HelpForm
{
    public partial class frmChangeCode : Form
    {
        public frmChangeCode()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ClickTextChanged(object sender, EventArgs e)
        {

            if (sender is TTTextBox) {
                TTTextBox txtNow = sender as TTTextBox;
                SetEm(txtNow.Name);
                setTxt(txtNow.Name, txtNow.Text);
            }
        }

        public void setTxt(string name,string value) {
             List<long> iten = new List<long>();
            if (!string.IsNullOrEmpty(value))
            {
                string[] vs = value.Split(' ');
                foreach (string item in vs) {
                    switch (name)
                    {
                        case "txtTwo":
                            if (Regex.IsMatch(item, @"^[0-1]+$"))
                            {
                                iten.Add(Convert.ToInt64(item, 2));
                            }
                            break;
                        case "txtTen":
                            if (Regex.IsMatch(item, @"^\d+$"))
                            {
                                iten.Add(Convert.ToInt64(item));
                            }
                            break;
                        case "txtEight":
                            if (Regex.IsMatch(item, @"^[0-7]+$"))
                            {
                                iten.Add(Convert.ToInt64(item, 8));
                            }
                            break;
                        case "txtSixteen":
                            if (Regex.IsMatch(item, @"^[A-Fa-f0-9]+$"))
                            {
                                iten.Add(Convert.ToInt64(item, 16));
                            }
                            break;
                        case "txtUnicode":
                            iten = IntToUnicode(value);
                            break;
                    }
                }
                foreach (long it in iten) {
                    setMode(it, name);
                }
                
            }
        }

        public void setMode(long iten,string type) {
            if (iten == 0)
            {
                SetEm(type);
            }
            else
            {
                if (type != txtTwo.Name) { txtTwo.Text += Convert.ToString(iten, 2)+" "; }
                if (type != txtTen.Name) { txtTen.Text += Convert.ToString(iten) + " "; }
                if (type != txtEight.Name) { txtEight.Text += Convert.ToString(iten, 8) + " "; }
                if (type != txtSixteen.Name) { txtSixteen.Text += Convert.ToString(iten, 16) + " "; }
                if (type != txtUnicode.Name) { txtUnicode.Text += ((char)iten).ToString(); }   
            }
        }
        public List<long> IntToUnicode(string text)
        {
            
            char[] ch=text.ToCharArray();
            List<long> lg = new List<long>();
                for (int i=0;i<ch.Length;i++) {
                    lg.Add(Convert.ToInt64(ch[i]));
                }
            return lg;
        }
        public void SetEm(string type) {
            if (type != txtTwo.Name) { txtTwo.Text = ""; }
            if (type != txtTen.Name) { txtTen.Text = ""; }
            if (type != txtEight.Name) { txtEight.Text = ""; }
            if (type != txtSixteen.Name) { txtSixteen.Text = ""; }
            if (type != txtUnicode.Name) { txtUnicode.Text = ""; }
        }

    }
}
