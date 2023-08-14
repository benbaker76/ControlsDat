using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlsDat
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = lblAbout.Text.Replace("[VERSION]", Global.Version);
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}