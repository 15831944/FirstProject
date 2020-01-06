using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enum.HelpForm
{
    public partial class frmOtherFormMain : Form
    {
        Action a = null;
        public frmOtherFormMain(Action ac)
        {
            if (a == null)
            {
                a = ac;
            }
            InitializeComponent();
        }

        private void btnPassWordOrText_Click(object sender, EventArgs e)
        {
           
            frmPassword password = new frmPassword();
            this.Hide();
            password.ShowDialog();
            if (password.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnVido_Click(object sender, EventArgs e)
        {
            frmSetVido frmSetVido = new frmSetVido();
            this.Hide();
            frmSetVido.ShowDialog();
            if (frmSetVido.DialogResult == DialogResult.OK) {
                this.Show();
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            frmChangeCode frmChangeCode = new frmChangeCode();
            this.Hide();
            frmChangeCode.ShowDialog();
            if (frmChangeCode.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            frmIdentCode fic = new frmIdentCode();
            this.Hide();
            fic.ShowDialog();
            if (fic.DialogResult == DialogResult.OK)
            {
                this.Show();
            }

        }
        protected override void OnClosed(EventArgs e)
        {
            Invoke(a);
        }
    }
}
