using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlsDat
{
    public partial class frmInfo : Form
    {
        private Form m_parent = null;
        private ProgressBar progressBar1;
        private Button butCancel;
        private Label lblOutput;

        public bool Exit = false;

        public frmInfo(Form parent, string message, bool ShowCancel, bool ShowProgressBar)
        {
            InitializeComponent();

            m_parent = parent;

            lblOutput.Text = message;

            if (ShowCancel)
                butCancel.Enabled = true;
            else
                butCancel.Enabled = false;

            if (ShowProgressBar)
                progressBar1.Visible = true;
            else
                progressBar1.Visible = false;

            Exit = false;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            int x = m_parent.Location.X + (m_parent.Width / 2) - (this.Width / 2);
            int y = m_parent.Location.Y + (m_parent.Height / 2) - (this.Height / 2);
            this.Location = new Point(x, y);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Exit = true;
        }

        public void SetProgressBar(int Percentage)
        {
            progressBar1.Value = Percentage;
        }

        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.butCancel = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 79);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(261, 16);
            this.progressBar1.TabIndex = 5;
            // 
            // butCancel
            // 
            this.butCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.butCancel.Location = new System.Drawing.Point(15, 104);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(262, 32);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(12, 9);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(268, 58);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.Text = "Output";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInfo
            // 
            this.ClientSize = new System.Drawing.Size(292, 148);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.lblOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.ResumeLayout(false);

        }
    }
}