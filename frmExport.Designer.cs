namespace ControlsDat
{
    partial class frmExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.chkIncludeColorData = new System.Windows.Forms.CheckBox();
            this.rdoUnVerified = new System.Windows.Forms.RadioButton();
            this.rdoVerified = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoIni = new System.Windows.Forms.RadioButton();
            this.rdoXml = new System.Windows.Forms.RadioButton();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.grpFormat.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.chkIncludeColorData);
            this.grpFormat.Controls.Add(this.rdoIni);
            this.grpFormat.Controls.Add(this.rdoXml);
            this.grpFormat.Location = new System.Drawing.Point(13, 11);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(165, 91);
            this.grpFormat.TabIndex = 0;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Format";
            // 
            // chkIncludeColorData
            // 
            this.chkIncludeColorData.AutoSize = true;
            this.chkIncludeColorData.Location = new System.Drawing.Point(25, 58);
            this.chkIncludeColorData.Name = "chkIncludeColorData";
            this.chkIncludeColorData.Size = new System.Drawing.Size(114, 17);
            this.chkIncludeColorData.TabIndex = 7;
            this.chkIncludeColorData.Text = "Include Color Data";
            this.chkIncludeColorData.UseVisualStyleBackColor = true;
            // 
            // rdoUnVerified
            // 
            this.rdoUnVerified.AutoSize = true;
            this.rdoUnVerified.Location = new System.Drawing.Point(29, 50);
            this.rdoUnVerified.Name = "rdoUnVerified";
            this.rdoUnVerified.Size = new System.Drawing.Size(74, 17);
            this.rdoUnVerified.TabIndex = 6;
            this.rdoUnVerified.TabStop = true;
            this.rdoUnVerified.Text = "UnVerified";
            this.rdoUnVerified.UseVisualStyleBackColor = true;
            // 
            // rdoVerified
            // 
            this.rdoVerified.AutoSize = true;
            this.rdoVerified.Location = new System.Drawing.Point(29, 32);
            this.rdoVerified.Name = "rdoVerified";
            this.rdoVerified.Size = new System.Drawing.Size(60, 17);
            this.rdoVerified.TabIndex = 5;
            this.rdoVerified.TabStop = true;
            this.rdoVerified.Text = "Verified";
            this.rdoVerified.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(29, 15);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 4;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoIni
            // 
            this.rdoIni.AutoSize = true;
            this.rdoIni.Location = new System.Drawing.Point(25, 36);
            this.rdoIni.Name = "rdoIni";
            this.rdoIni.Size = new System.Drawing.Size(36, 17);
            this.rdoIni.TabIndex = 3;
            this.rdoIni.TabStop = true;
            this.rdoIni.Text = "Ini";
            this.rdoIni.UseVisualStyleBackColor = true;
            // 
            // rdoXml
            // 
            this.rdoXml.AutoSize = true;
            this.rdoXml.Location = new System.Drawing.Point(25, 19);
            this.rdoXml.Name = "rdoXml";
            this.rdoXml.Size = new System.Drawing.Size(42, 17);
            this.rdoXml.TabIndex = 2;
            this.rdoXml.TabStop = true;
            this.rdoXml.Text = "Xml";
            this.rdoXml.UseVisualStyleBackColor = true;
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(13, 115);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(102, 28);
            this.butOk.TabIndex = 1;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(241, 115);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(102, 28);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.rdoVerified);
            this.grpFilter.Controls.Add(this.rdoUnVerified);
            this.grpFilter.Controls.Add(this.rdoAll);
            this.grpFilter.Location = new System.Drawing.Point(184, 15);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(160, 87);
            this.grpFilter.TabIndex = 3;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 156);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export ControlsDat";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExport_FormClosing);
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.CheckBox chkIncludeColorData;
        private System.Windows.Forms.RadioButton rdoUnVerified;
        private System.Windows.Forms.RadioButton rdoVerified;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoIni;
        private System.Windows.Forms.RadioButton rdoXml;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.GroupBox grpFilter;
    }
}