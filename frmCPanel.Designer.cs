namespace ControlsDat
{
    partial class frmCPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCPanel));
            this.picCPanel = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.picMagnify = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMagnify)).BeginInit();
            this.SuspendLayout();
            // 
            // picCPanel
            // 
            this.picCPanel.BackColor = System.Drawing.Color.Black;
            this.picCPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCPanel.Location = new System.Drawing.Point(0, 0);
            this.picCPanel.Name = "picCPanel";
            this.picCPanel.Size = new System.Drawing.Size(429, 290);
            this.picCPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCPanel.TabIndex = 0;
            this.picCPanel.TabStop = false;
            this.picCPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCPanel_MouseMove);
            this.picCPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCPanel_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 290);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(429, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // picMagnify
            // 
            this.picMagnify.BackColor = System.Drawing.Color.Black;
            this.picMagnify.Location = new System.Drawing.Point(0, 0);
            this.picMagnify.Name = "picMagnify";
            this.picMagnify.Size = new System.Drawing.Size(128, 80);
            this.picMagnify.TabIndex = 16;
            this.picMagnify.TabStop = false;
            // 
            // frmCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 312);
            this.Controls.Add(this.picMagnify);
            this.Controls.Add(this.picCPanel);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPanel";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCPanel_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCPanel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picCPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMagnify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picMagnify;
    }
}