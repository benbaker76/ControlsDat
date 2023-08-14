namespace ControlsDat
{
    partial class frmMameDiff
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
            this.grpMame1 = new System.Windows.Forms.GroupBox();
            this.lblMame1Exe = new System.Windows.Forms.Label();
            this.butMame1Exe = new System.Windows.Forms.Button();
            this.txtMame1Exe = new System.Windows.Forms.TextBox();
            this.grpMame2 = new System.Windows.Forms.GroupBox();
            this.lblMame2Exe = new System.Windows.Forms.Label();
            this.butMame2Exe = new System.Windows.Forms.Button();
            this.txtMame2Exe = new System.Windows.Forms.TextBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.chkMergedSets = new System.Windows.Forms.CheckBox();
            this.chkSplitSets = new System.Windows.Forms.CheckBox();
            this.chkNonMergedSets = new System.Windows.Forms.CheckBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.grpMame1.SuspendLayout();
            this.grpMame2.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMame1
            // 
            this.grpMame1.Controls.Add(this.lblMame1Exe);
            this.grpMame1.Controls.Add(this.butMame1Exe);
            this.grpMame1.Controls.Add(this.txtMame1Exe);
            this.grpMame1.Location = new System.Drawing.Point(12, 12);
            this.grpMame1.Name = "grpMame1";
            this.grpMame1.Size = new System.Drawing.Size(364, 59);
            this.grpMame1.TabIndex = 37;
            this.grpMame1.TabStop = false;
            this.grpMame1.Text = "Mame 1";
            // 
            // lblMame1Exe
            // 
            this.lblMame1Exe.AutoSize = true;
            this.lblMame1Exe.Location = new System.Drawing.Point(10, 24);
            this.lblMame1Exe.Name = "lblMame1Exe";
            this.lblMame1Exe.Size = new System.Drawing.Size(60, 13);
            this.lblMame1Exe.TabIndex = 3;
            this.lblMame1Exe.Text = "Mame Exe:";
            // 
            // butMame1Exe
            // 
            this.butMame1Exe.Location = new System.Drawing.Point(320, 20);
            this.butMame1Exe.Name = "butMame1Exe";
            this.butMame1Exe.Size = new System.Drawing.Size(27, 21);
            this.butMame1Exe.TabIndex = 2;
            this.butMame1Exe.Text = "...";
            this.butMame1Exe.UseVisualStyleBackColor = true;
            this.butMame1Exe.Click += new System.EventHandler(this.butMame1Exe_Click);
            // 
            // txtMame1Exe
            // 
            this.txtMame1Exe.Location = new System.Drawing.Point(73, 21);
            this.txtMame1Exe.Name = "txtMame1Exe";
            this.txtMame1Exe.ReadOnly = true;
            this.txtMame1Exe.Size = new System.Drawing.Size(241, 20);
            this.txtMame1Exe.TabIndex = 0;
            // 
            // grpMame2
            // 
            this.grpMame2.Controls.Add(this.lblMame2Exe);
            this.grpMame2.Controls.Add(this.butMame2Exe);
            this.grpMame2.Controls.Add(this.txtMame2Exe);
            this.grpMame2.Location = new System.Drawing.Point(12, 77);
            this.grpMame2.Name = "grpMame2";
            this.grpMame2.Size = new System.Drawing.Size(364, 59);
            this.grpMame2.TabIndex = 38;
            this.grpMame2.TabStop = false;
            this.grpMame2.Text = "Mame 2";
            // 
            // lblMame2Exe
            // 
            this.lblMame2Exe.AutoSize = true;
            this.lblMame2Exe.Location = new System.Drawing.Point(10, 24);
            this.lblMame2Exe.Name = "lblMame2Exe";
            this.lblMame2Exe.Size = new System.Drawing.Size(60, 13);
            this.lblMame2Exe.TabIndex = 3;
            this.lblMame2Exe.Text = "Mame Exe:";
            // 
            // butMame2Exe
            // 
            this.butMame2Exe.Location = new System.Drawing.Point(320, 20);
            this.butMame2Exe.Name = "butMame2Exe";
            this.butMame2Exe.Size = new System.Drawing.Size(27, 21);
            this.butMame2Exe.TabIndex = 2;
            this.butMame2Exe.Text = "...";
            this.butMame2Exe.UseVisualStyleBackColor = true;
            this.butMame2Exe.Click += new System.EventHandler(this.butMame2Exe_Click);
            // 
            // txtMame2Exe
            // 
            this.txtMame2Exe.Location = new System.Drawing.Point(73, 21);
            this.txtMame2Exe.Name = "txtMame2Exe";
            this.txtMame2Exe.ReadOnly = true;
            this.txtMame2Exe.Size = new System.Drawing.Size(241, 20);
            this.txtMame2Exe.TabIndex = 0;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkNonMergedSets);
            this.grpOptions.Controls.Add(this.chkSplitSets);
            this.grpOptions.Controls.Add(this.chkMergedSets);
            this.grpOptions.Controls.Add(this.chkVerbose);
            this.grpOptions.Location = new System.Drawing.Point(12, 142);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(364, 79);
            this.grpOptions.TabIndex = 39;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(19, 25);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(65, 17);
            this.chkVerbose.TabIndex = 0;
            this.chkVerbose.Text = "Verbose";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // chkMergedSets
            // 
            this.chkMergedSets.AutoSize = true;
            this.chkMergedSets.Location = new System.Drawing.Point(137, 25);
            this.chkMergedSets.Name = "chkMergedSets";
            this.chkMergedSets.Size = new System.Drawing.Size(86, 17);
            this.chkMergedSets.TabIndex = 1;
            this.chkMergedSets.Text = "Merged Sets";
            this.chkMergedSets.UseVisualStyleBackColor = true;
            // 
            // chkSplitSets
            // 
            this.chkSplitSets.AutoSize = true;
            this.chkSplitSets.Location = new System.Drawing.Point(249, 25);
            this.chkSplitSets.Name = "chkSplitSets";
            this.chkSplitSets.Size = new System.Drawing.Size(70, 17);
            this.chkSplitSets.TabIndex = 2;
            this.chkSplitSets.Text = "Split Sets";
            this.chkSplitSets.UseVisualStyleBackColor = true;
            // 
            // chkNonMergedSets
            // 
            this.chkNonMergedSets.AutoSize = true;
            this.chkNonMergedSets.Location = new System.Drawing.Point(19, 48);
            this.chkNonMergedSets.Name = "chkNonMergedSets";
            this.chkNonMergedSets.Size = new System.Drawing.Size(109, 17);
            this.chkNonMergedSets.TabIndex = 3;
            this.chkNonMergedSets.Text = "Non-Merged Sets";
            this.chkNonMergedSets.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(274, 227);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(102, 28);
            this.butCancel.TabIndex = 41;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(12, 227);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(102, 28);
            this.butOk.TabIndex = 40;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // frmMameDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 268);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpMame2);
            this.Controls.Add(this.grpMame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMameDiff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MameDiff";
            this.Load += new System.EventHandler(this.frmMameDiff_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMameDiff_FormClosing);
            this.grpMame1.ResumeLayout(false);
            this.grpMame1.PerformLayout();
            this.grpMame2.ResumeLayout(false);
            this.grpMame2.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMame1;
        private System.Windows.Forms.Label lblMame1Exe;
        private System.Windows.Forms.Button butMame1Exe;
        private System.Windows.Forms.TextBox txtMame1Exe;
        private System.Windows.Forms.GroupBox grpMame2;
        private System.Windows.Forms.Label lblMame2Exe;
        private System.Windows.Forms.Button butMame2Exe;
        private System.Windows.Forms.TextBox txtMame2Exe;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.CheckBox chkNonMergedSets;
        private System.Windows.Forms.CheckBox chkSplitSets;
        private System.Windows.Forms.CheckBox chkMergedSets;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOk;
    }
}