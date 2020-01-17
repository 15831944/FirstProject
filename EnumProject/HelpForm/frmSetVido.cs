using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnumProject.HelpForm
{
    public partial class frmSetVido : Form
    {
        public frmSetVido()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdateFile_Click(object sender, EventArgs e)
        {

        }
    }
}
