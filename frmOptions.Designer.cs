namespace ControlsDat
{
    partial class frmOptions
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.tabMame = new System.Windows.Forms.TabPage();
            this.grpMamePaths = new System.Windows.Forms.GroupBox();
            this.lblCPanel = new System.Windows.Forms.Label();
            this.butCPanel = new System.Windows.Forms.Button();
            this.txtCPanel = new System.Windows.Forms.TextBox();
            this.lblMameExe = new System.Windows.Forms.Label();
            this.butMameExe = new System.Windows.Forms.Button();
            this.txtMameExe = new System.Windows.Forms.TextBox();
            this.colColor = new System.Windows.Forms.ColumnHeader();
            this.colImage = new System.Windows.Forms.ColumnHeader();
            this.colLayoutMapEnabled = new System.Windows.Forms.ColumnHeader();
            this.colLayoutMapConstant = new System.Windows.Forms.ColumnHeader();
            this.colLayoutMapControl = new System.Windows.Forms.ColumnHeader();
            this.colLayoutMapNumPlayers = new System.Windows.Forms.ColumnHeader();
            this.colLayoutMapAlternating = new System.Windows.Forms.ColumnHeader();
            this.colLayoutMapLayout = new System.Windows.Forms.ColumnHeader();
            this.colProfileEnabled = new System.Windows.Forms.ColumnHeader();
            this.colProfileName = new System.Windows.Forms.ColumnHeader();
            this.colProfileType = new System.Windows.Forms.ColumnHeader();
            this.colProfileLayout = new System.Windows.Forms.ColumnHeader();
            this.colProfileLayoutOverride = new System.Windows.Forms.ColumnHeader();
            this.colProfileLabels = new System.Windows.Forms.ColumnHeader();
            this.colProfileDatabase = new System.Windows.Forms.ColumnHeader();
            this.colProfileExecutable = new System.Windows.Forms.ColumnHeader();
            this.colProfileWindowTitle = new System.Windows.Forms.ColumnHeader();
            this.colProfileWindowClass = new System.Windows.Forms.ColumnHeader();
            this.colProfileUseExe = new System.Windows.Forms.ColumnHeader();
            this.colProfileScreenshot = new System.Windows.Forms.ColumnHeader();
            this.colProfileMinimize = new System.Windows.Forms.ColumnHeader();
            this.colProfileMaximize = new System.Windows.Forms.ColumnHeader();
            this.colProfileShowKey = new System.Windows.Forms.ColumnHeader();
            this.colProfileHideKey = new System.Windows.Forms.ColumnHeader();
            this.colProfileShowSendKeys = new System.Windows.Forms.ColumnHeader();
            this.colProfileHideSendKeys = new System.Windows.Forms.ColumnHeader();
            this.colProfileUseOverlay = new System.Windows.Forms.ColumnHeader();
            this.colProfileManuals = new System.Windows.Forms.ColumnHeader();
            this.colProfileOpCards = new System.Windows.Forms.ColumnHeader();
            this.colProfileSnaps = new System.Windows.Forms.ColumnHeader();
            this.colProfileTitles = new System.Windows.Forms.ColumnHeader();
            this.colProfileCarts = new System.Windows.Forms.ColumnHeader();
            this.colProfileBoxes = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.tabMame.SuspendLayout();
            this.grpMamePaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(307, 154);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(102, 28);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(12, 154);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(102, 28);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabMame);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(397, 136);
            this.tabControl1.TabIndex = 3;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.grpGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(389, 110);
            this.tabGeneral.TabIndex = 5;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblUserName);
            this.grpGeneral.Controls.Add(this.txtUserName);
            this.grpGeneral.Location = new System.Drawing.Point(13, 10);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(364, 87);
            this.grpGeneral.TabIndex = 37;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(10, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "UserName:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(73, 21);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(241, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // tabMame
            // 
            this.tabMame.Controls.Add(this.grpMamePaths);
            this.tabMame.Location = new System.Drawing.Point(4, 22);
            this.tabMame.Name = "tabMame";
            this.tabMame.Size = new System.Drawing.Size(389, 110);
            this.tabMame.TabIndex = 9;
            this.tabMame.Text = "Mame";
            this.tabMame.UseVisualStyleBackColor = true;
            // 
            // grpMamePaths
            // 
            this.grpMamePaths.Controls.Add(this.lblCPanel);
            this.grpMamePaths.Controls.Add(this.butCPanel);
            this.grpMamePaths.Controls.Add(this.txtCPanel);
            this.grpMamePaths.Controls.Add(this.lblMameExe);
            this.grpMamePaths.Controls.Add(this.butMameExe);
            this.grpMamePaths.Controls.Add(this.txtMameExe);
            this.grpMamePaths.Location = new System.Drawing.Point(13, 10);
            this.grpMamePaths.Name = "grpMamePaths";
            this.grpMamePaths.Size = new System.Drawing.Size(364, 87);
            this.grpMamePaths.TabIndex = 36;
            this.grpMamePaths.TabStop = false;
            this.grpMamePaths.Text = "Mame Paths";
            // 
            // lblCPanel
            // 
            this.lblCPanel.AutoSize = true;
            this.lblCPanel.Location = new System.Drawing.Point(10, 50);
            this.lblCPanel.Name = "lblCPanel";
            this.lblCPanel.Size = new System.Drawing.Size(44, 13);
            this.lblCPanel.TabIndex = 9;
            this.lblCPanel.Text = "CPanel:";
            // 
            // butCPanel
            // 
            this.butCPanel.Location = new System.Drawing.Point(320, 46);
            this.butCPanel.Name = "butCPanel";
            this.butCPanel.Size = new System.Drawing.Size(27, 21);
            this.butCPanel.TabIndex = 8;
            this.butCPanel.Text = "...";
            this.butCPanel.UseVisualStyleBackColor = true;
            this.butCPanel.Click += new System.EventHandler(this.butCPanel_Click);
            // 
            // txtCPanel
            // 
            this.txtCPanel.Location = new System.Drawing.Point(73, 47);
            this.txtCPanel.Name = "txtCPanel";
            this.txtCPanel.ReadOnly = true;
            this.txtCPanel.Size = new System.Drawing.Size(241, 20);
            this.txtCPanel.TabIndex = 7;
            // 
            // lblMameExe
            // 
            this.lblMameExe.AutoSize = true;
            this.lblMameExe.Location = new System.Drawing.Point(10, 24);
            this.lblMameExe.Name = "lblMameExe";
            this.lblMameExe.Size = new System.Drawing.Size(60, 13);
            this.lblMameExe.TabIndex = 3;
            this.lblMameExe.Text = "Mame Exe:";
            // 
            // butMameExe
            // 
            this.butMameExe.Location = new System.Drawing.Point(320, 20);
            this.butMameExe.Name = "butMameExe";
            this.butMameExe.Size = new System.Drawing.Size(27, 21);
            this.butMameExe.TabIndex = 2;
            this.butMameExe.Text = "...";
            this.butMameExe.UseVisualStyleBackColor = true;
            this.butMameExe.Click += new System.EventHandler(this.butMameExe_Click);
            // 
            // txtMameExe
            // 
            this.txtMameExe.Location = new System.Drawing.Point(73, 21);
            this.txtMameExe.Name = "txtMameExe";
            this.txtMameExe.ReadOnly = true;
            this.txtMameExe.Size = new System.Drawing.Size(241, 20);
            this.txtMameExe.TabIndex = 0;
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            this.colColor.Width = 143;
            // 
            // colImage
            // 
            this.colImage.Text = "Image";
            this.colImage.Width = 142;
            // 
            // colLayoutMapEnabled
            // 
            this.colLayoutMapEnabled.Text = "";
            this.colLayoutMapEnabled.Width = 32;
            // 
            // colLayoutMapConstant
            // 
            this.colLayoutMapConstant.Text = "Constant";
            this.colLayoutMapConstant.Width = 100;
            // 
            // colLayoutMapControl
            // 
            this.colLayoutMapControl.Text = "Control";
            this.colLayoutMapControl.Width = 100;
            // 
            // colLayoutMapNumPlayers
            // 
            this.colLayoutMapNumPlayers.Text = "NumPlayers";
            this.colLayoutMapNumPlayers.Width = 100;
            // 
            // colLayoutMapAlternating
            // 
            this.colLayoutMapAlternating.Text = "Alternating";
            this.colLayoutMapAlternating.Width = 100;
            // 
            // colLayoutMapLayout
            // 
            this.colLayoutMapLayout.Text = "Layout";
            this.colLayoutMapLayout.Width = 100;
            // 
            // colProfileEnabled
            // 
            this.colProfileEnabled.Text = "";
            this.colProfileEnabled.Width = 30;
            // 
            // colProfileName
            // 
            this.colProfileName.Text = "Name";
            this.colProfileName.Width = 100;
            // 
            // colProfileType
            // 
            this.colProfileType.Text = "Type";
            this.colProfileType.Width = 100;
            // 
            // colProfileLayout
            // 
            this.colProfileLayout.Text = "Layout";
            this.colProfileLayout.Width = 100;
            // 
            // colProfileLayoutOverride
            // 
            this.colProfileLayoutOverride.Text = "Layout Override";
            this.colProfileLayoutOverride.Width = 100;
            // 
            // colProfileLabels
            // 
            this.colProfileLabels.Text = "Labels";
            this.colProfileLabels.Width = 100;
            // 
            // colProfileDatabase
            // 
            this.colProfileDatabase.Text = "Database";
            this.colProfileDatabase.Width = 100;
            // 
            // colProfileExecutable
            // 
            this.colProfileExecutable.Text = "Executable";
            this.colProfileExecutable.Width = 100;
            // 
            // colProfileWindowTitle
            // 
            this.colProfileWindowTitle.Text = "Window Title";
            this.colProfileWindowTitle.Width = 100;
            // 
            // colProfileWindowClass
            // 
            this.colProfileWindowClass.Text = "Window Class";
            this.colProfileWindowClass.Width = 100;
            // 
            // colProfileUseExe
            // 
            this.colProfileUseExe.Text = "Use Exe";
            this.colProfileUseExe.Width = 100;
            // 
            // colProfileScreenshot
            // 
            this.colProfileScreenshot.Text = "Take Screenshot";
            this.colProfileScreenshot.Width = 100;
            // 
            // colProfileMinimize
            // 
            this.colProfileMinimize.Text = "Minimize";
            this.colProfileMinimize.Width = 100;
            // 
            // colProfileMaximize
            // 
            this.colProfileMaximize.Text = "Maximize";
            this.colProfileMaximize.Width = 100;
            // 
            // colProfileShowKey
            // 
            this.colProfileShowKey.Text = "Show Key";
            this.colProfileShowKey.Width = 100;
            // 
            // colProfileHideKey
            // 
            this.colProfileHideKey.Text = "Hide Key";
            this.colProfileHideKey.Width = 100;
            // 
            // colProfileShowSendKeys
            // 
            this.colProfileShowSendKeys.Text = "Show SendKeys";
            this.colProfileShowSendKeys.Width = 100;
            // 
            // colProfileHideSendKeys
            // 
            this.colProfileHideSendKeys.Text = "Hide SendKeys";
            this.colProfileHideSendKeys.Width = 100;
            // 
            // colProfileUseOverlay
            // 
            this.colProfileUseOverlay.Text = "Use Overlay";
            this.colProfileUseOverlay.Width = 100;
            // 
            // colProfileManuals
            // 
            this.colProfileManuals.Text = "Manuals Path";
            this.colProfileManuals.Width = 100;
            // 
            // colProfileOpCards
            // 
            this.colProfileOpCards.Text = "Op Cards Path";
            this.colProfileOpCards.Width = 100;
            // 
            // colProfileSnaps
            // 
            this.colProfileSnaps.Text = "Snaps Path";
            this.colProfileSnaps.Width = 100;
            // 
            // colProfileTitles
            // 
            this.colProfileTitles.Text = "Titles Folder";
            this.colProfileTitles.Width = 100;
            // 
            // colProfileCarts
            // 
            this.colProfileCarts.Text = "Carts Folder";
            this.colProfileCarts.Width = 100;
            // 
            // colProfileBoxes
            // 
            this.colProfileBoxes.Text = "Boxes Folder";
            this.colProfileBoxes.Width = 100;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 194);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tabMame.ResumeLayout(false);
            this.grpMamePaths.ResumeLayout(false);
            this.grpMamePaths.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabMame;
        private System.Windows.Forms.GroupBox grpMamePaths;
        private System.Windows.Forms.Label lblCPanel;
        private System.Windows.Forms.Button butCPanel;
        private System.Windows.Forms.TextBox txtCPanel;
        private System.Windows.Forms.Label lblMameExe;
        private System.Windows.Forms.Button butMameExe;
        private System.Windows.Forms.TextBox txtMameExe;
        private System.Windows.Forms.ColumnHeader colColor;
        private System.Windows.Forms.ColumnHeader colImage;
        private System.Windows.Forms.ColumnHeader colLayoutMapEnabled;
        private System.Windows.Forms.ColumnHeader colLayoutMapConstant;
        private System.Windows.Forms.ColumnHeader colLayoutMapControl;
        private System.Windows.Forms.ColumnHeader colLayoutMapNumPlayers;
        private System.Windows.Forms.ColumnHeader colLayoutMapAlternating;
        private System.Windows.Forms.ColumnHeader colLayoutMapLayout;
        private System.Windows.Forms.ColumnHeader colProfileEnabled;
        private System.Windows.Forms.ColumnHeader colProfileName;
        private System.Windows.Forms.ColumnHeader colProfileType;
        private System.Windows.Forms.ColumnHeader colProfileLayout;
        private System.Windows.Forms.ColumnHeader colProfileLayoutOverride;
        private System.Windows.Forms.ColumnHeader colProfileLabels;
        private System.Windows.Forms.ColumnHeader colProfileDatabase;
        private System.Windows.Forms.ColumnHeader colProfileExecutable;
        private System.Windows.Forms.ColumnHeader colProfileWindowTitle;
        private System.Windows.Forms.ColumnHeader colProfileWindowClass;
        private System.Windows.Forms.ColumnHeader colProfileUseExe;
        private System.Windows.Forms.ColumnHeader colProfileScreenshot;
        private System.Windows.Forms.ColumnHeader colProfileMinimize;
        private System.Windows.Forms.ColumnHeader colProfileMaximize;
        private System.Windows.Forms.ColumnHeader colProfileShowKey;
        private System.Windows.Forms.ColumnHeader colProfileHideKey;
        private System.Windows.Forms.ColumnHeader colProfileShowSendKeys;
        private System.Windows.Forms.ColumnHeader colProfileHideSendKeys;
        private System.Windows.Forms.ColumnHeader colProfileUseOverlay;
        private System.Windows.Forms.ColumnHeader colProfileManuals;
        private System.Windows.Forms.ColumnHeader colProfileOpCards;
        private System.Windows.Forms.ColumnHeader colProfileSnaps;
        private System.Windows.Forms.ColumnHeader colProfileTitles;
        private System.Windows.Forms.ColumnHeader colProfileCarts;
        private System.Windows.Forms.ColumnHeader colProfileBoxes;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
    }
}