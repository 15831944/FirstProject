using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enum.HelpForm
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
    }
}
