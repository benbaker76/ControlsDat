using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlsDat
{
    public partial class frmExport : Form
    {
        public ControlsDat.FormatType FormatType = ControlsDat.FormatType.Xml;
        public ControlsDat.SaveType SaveType = ControlsDat.SaveType.All;
        public bool IncludeColorData = false;

        public frmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            rdoXml.Checked = true;
            rdoAll.Checked = true;
        }

        private void frmExport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rdoXml.Checked)
                FormatType = ControlsDat.FormatType.Xml;
            else
                FormatType = ControlsDat.FormatType.Ini;

            if (rdoAll.Checked)
                SaveType = ControlsDat.SaveType.All;
            else if (rdoVerified.Checked)
                SaveType = ControlsDat.SaveType.Verified;
            else if (rdoUnVerified.Checked)
                SaveType = ControlsDat.SaveType.UnVerified;

            IncludeColorData = chkIncludeColorData.Checked;
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}