namespace ControlsDat
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.grpAbout = new System.Windows.Forms.GroupBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butOK = new System.Windows.Forms.Button();
            this.grpAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAbout
            // 
            this.grpAbout.Controls.Add(this.lblAbout);
            this.grpAbout.Controls.Add(this.pictureBox1);
            this.grpAbout.Location = new System.Drawing.Point(12, 12);
            this.grpAbout.Name = "grpAbout";
            this.grpAbout.Size = new System.Drawing.Size(325, 126);
            this.grpAbout.TabIndex = 3;
            this.grpAbout.TabStop = false;
            this.grpAbout.Text = "About";
            // 
            // lblAbout
            // 
            this.lblAbout.Location = new System.Drawing.Point(101, 21);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(207, 72);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.Text = "ControlsDat [VERSION]\r\n\r\n(C) Copyright 2008 By Ben Baker\r\n\r\nThanks To: SirPoonga," +
                " Howard Casto\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(100, 150);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(138, 36);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 202);
            this.Controls.Add(this.grpAbout);
            this.Controls.Add(this.butOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.grpAbout.ResumeLayout(false);
            this.grpAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAbout;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butOK;
    }
}