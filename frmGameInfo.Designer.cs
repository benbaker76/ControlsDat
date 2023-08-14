namespace ControlsDat
{
    partial class frmGameInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGameInfo));
            this.butOK = new System.Windows.Forms.Button();
            this.butOKNext = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.grpMameInfo = new System.Windows.Forms.GroupBox();
            this.tabMameInfo = new System.Windows.Forms.TabControl();
            this.tabGameInfo = new System.Windows.Forms.TabPage();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblControls = new System.Windows.Forms.Label();
            this.txtControls = new System.Windows.Forms.TextBox();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.txtPlayers = new System.Windows.Forms.TextBox();
            this.lblRomOf = new System.Windows.Forms.Label();
            this.txtButtons = new System.Windows.Forms.TextBox();
            this.lblMameButtons = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRomOf = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCloneOf = new System.Windows.Forms.Label();
            this.txtParent = new System.Windows.Forms.TextBox();
            this.txtCloneOf = new System.Windows.Forms.TextBox();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.tabDipSwitches = new System.Windows.Forms.TabPage();
            this.trvDipSwitch = new System.Windows.Forms.TreeView();
            this.grpControlsDat = new System.Windows.Forms.GroupBox();
            this.tabControlsDat = new System.Windows.Forms.TabControl();
            this.tabControlInfo = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkVerified = new System.Windows.Forms.CheckBox();
            this.lblNumPlayers = new System.Windows.Forms.Label();
            this.nudButtons = new System.Windows.Forms.NumericUpDown();
            this.nudPlayers = new System.Windows.Forms.NumericUpDown();
            this.lblButtons = new System.Windows.Forms.Label();
            this.chkCocktail = new System.Windows.Forms.CheckBox();
            this.chkTilt = new System.Windows.Forms.CheckBox();
            this.chkUsesService = new System.Windows.Forms.CheckBox();
            this.chkMirrored = new System.Windows.Forms.CheckBox();
            this.chkAlternating = new System.Windows.Forms.CheckBox();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.butControlsDown = new System.Windows.Forms.Button();
            this.butControlsUp = new System.Windows.Forms.Button();
            this.butRemoveControl = new System.Windows.Forms.Button();
            this.butAddControl = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.grpSpecialButtons = new System.Windows.Forms.GroupBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.butButtonsDown = new System.Windows.Forms.Button();
            this.butButtonsUp = new System.Windows.Forms.Button();
            this.butRemoveButton = new System.Windows.Forms.Button();
            this.butAddButton = new System.Windows.Forms.Button();
            this.grpLabels = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.butLabelsDown = new System.Windows.Forms.Button();
            this.butLabelsUp = new System.Windows.Forms.Button();
            this.butRemoveLabel = new System.Windows.Forms.Button();
            this.butAddLabel = new System.Windows.Forms.Button();
            this.tabMiscDetails = new System.Windows.Forms.TabPage();
            this.grpMiscDetails = new System.Windows.Forms.GroupBox();
            this.txtMiscDetails = new System.Windows.Forms.TextBox();
            this.picControlsDat = new System.Windows.Forms.PictureBox();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.pnlSwatches = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowCPanel = new System.Windows.Forms.ToolStripButton();
            this.tsbLaunchGame = new System.Windows.Forms.ToolStripButton();
            this.lvwControls = new CPWizard.ListViewEx(this.components);
            this.colControlName = new System.Windows.Forms.ColumnHeader();
            this.colControlConstant = new System.Windows.Forms.ColumnHeader();
            this.lvwSpecialButtons = new CPWizard.ListViewEx(this.components);
            this.colButtonControl = new System.Windows.Forms.ColumnHeader();
            this.colButtonButton = new System.Windows.Forms.ColumnHeader();
            this.lvwLabels = new CPWizard.ListViewEx(this.components);
            this.colLabelName = new System.Windows.Forms.ColumnHeader();
            this.colLabelValue = new System.Windows.Forms.ColumnHeader();
            this.colLabelColor = new System.Windows.Forms.ColumnHeader();
            this.grpMameInfo.SuspendLayout();
            this.tabMameInfo.SuspendLayout();
            this.tabGameInfo.SuspendLayout();
            this.tabDipSwitches.SuspendLayout();
            this.grpControlsDat.SuspendLayout();
            this.tabControlsDat.SuspendLayout();
            this.tabControlInfo.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayers)).BeginInit();
            this.grpControls.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.grpSpecialButtons.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.grpLabels.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabMiscDetails.SuspendLayout();
            this.grpMiscDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picControlsDat)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(9, -1);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(67, 31);
            this.butOK.TabIndex = 0;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butOKNext
            // 
            this.butOKNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOKNext.Location = new System.Drawing.Point(78, -1);
            this.butOKNext.Name = "butOKNext";
            this.butOKNext.Size = new System.Drawing.Size(67, 31);
            this.butOKNext.TabIndex = 1;
            this.butOKNext.Text = "OK + Next";
            this.butOKNext.UseVisualStyleBackColor = true;
            this.butOKNext.Click += new System.EventHandler(this.butOKNext_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Location = new System.Drawing.Point(550, -1);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(67, 31);
            this.butCancel.TabIndex = 6;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // grpMameInfo
            // 
            this.grpMameInfo.Controls.Add(this.tabMameInfo);
            this.grpMameInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMameInfo.Location = new System.Drawing.Point(0, 0);
            this.grpMameInfo.Name = "grpMameInfo";
            this.grpMameInfo.Size = new System.Drawing.Size(632, 114);
            this.grpMameInfo.TabIndex = 57;
            this.grpMameInfo.TabStop = false;
            this.grpMameInfo.Text = "Mame Info";
            // 
            // tabMameInfo
            // 
            this.tabMameInfo.Controls.Add(this.tabGameInfo);
            this.tabMameInfo.Controls.Add(this.tabDipSwitches);
            this.tabMameInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMameInfo.Location = new System.Drawing.Point(3, 16);
            this.tabMameInfo.Name = "tabMameInfo";
            this.tabMameInfo.SelectedIndex = 0;
            this.tabMameInfo.Size = new System.Drawing.Size(626, 95);
            this.tabMameInfo.TabIndex = 3;
            // 
            // tabGameInfo
            // 
            this.tabGameInfo.Controls.Add(this.lblDescription);
            this.tabGameInfo.Controls.Add(this.lblPlayers);
            this.tabGameInfo.Controls.Add(this.lblVersion);
            this.tabGameInfo.Controls.Add(this.txtVersion);
            this.tabGameInfo.Controls.Add(this.lblCategory);
            this.tabGameInfo.Controls.Add(this.txtCategory);
            this.tabGameInfo.Controls.Add(this.txtDescription);
            this.tabGameInfo.Controls.Add(this.lblControls);
            this.tabGameInfo.Controls.Add(this.txtControls);
            this.tabGameInfo.Controls.Add(this.txtSourceFile);
            this.tabGameInfo.Controls.Add(this.txtPlayers);
            this.tabGameInfo.Controls.Add(this.lblRomOf);
            this.tabGameInfo.Controls.Add(this.txtButtons);
            this.tabGameInfo.Controls.Add(this.lblMameButtons);
            this.tabGameInfo.Controls.Add(this.txtName);
            this.tabGameInfo.Controls.Add(this.txtRomOf);
            this.tabGameInfo.Controls.Add(this.lblName);
            this.tabGameInfo.Controls.Add(this.lblCloneOf);
            this.tabGameInfo.Controls.Add(this.txtParent);
            this.tabGameInfo.Controls.Add(this.txtCloneOf);
            this.tabGameInfo.Controls.Add(this.lblParent);
            this.tabGameInfo.Controls.Add(this.lblSourceFile);
            this.tabGameInfo.Location = new System.Drawing.Point(4, 22);
            this.tabGameInfo.Name = "tabGameInfo";
            this.tabGameInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabGameInfo.Size = new System.Drawing.Size(618, 69);
            this.tabGameInfo.TabIndex = 0;
            this.tabGameInfo.Text = "Game Info";
            this.tabGameInfo.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(5, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 15);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayers
            // 
            this.lblPlayers.Location = new System.Drawing.Point(24, 50);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(46, 15);
            this.lblPlayers.TabIndex = 6;
            this.lblPlayers.Text = "Players:";
            this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Location = new System.Drawing.Point(450, 34);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(54, 15);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.Location = new System.Drawing.Point(505, 36);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(83, 13);
            this.txtVersion.TabIndex = 25;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Location = new System.Drawing.Point(16, 34);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(54, 15);
            this.lblCategory.TabIndex = 22;
            this.lblCategory.Text = "Category:";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(70, 36);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(370, 13);
            this.txtCategory.TabIndex = 23;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(70, 20);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(370, 13);
            this.txtDescription.TabIndex = 3;
            // 
            // lblControls
            // 
            this.lblControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblControls.Location = new System.Drawing.Point(301, 51);
            this.lblControls.Name = "lblControls";
            this.lblControls.Size = new System.Drawing.Size(54, 15);
            this.lblControls.TabIndex = 20;
            this.lblControls.Text = "Controls:";
            this.lblControls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtControls
            // 
            this.txtControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtControls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControls.Location = new System.Drawing.Point(357, 52);
            this.txtControls.Name = "txtControls";
            this.txtControls.ReadOnly = true;
            this.txtControls.Size = new System.Drawing.Size(231, 13);
            this.txtControls.TabIndex = 21;
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSourceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceFile.Location = new System.Drawing.Point(205, 4);
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.ReadOnly = true;
            this.txtSourceFile.Size = new System.Drawing.Size(83, 13);
            this.txtSourceFile.TabIndex = 19;
            // 
            // txtPlayers
            // 
            this.txtPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayers.Location = new System.Drawing.Point(71, 52);
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.ReadOnly = true;
            this.txtPlayers.Size = new System.Drawing.Size(83, 13);
            this.txtPlayers.TabIndex = 7;
            // 
            // lblRomOf
            // 
            this.lblRomOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRomOf.Location = new System.Drawing.Point(458, 3);
            this.lblRomOf.Name = "lblRomOf";
            this.lblRomOf.Size = new System.Drawing.Size(46, 15);
            this.lblRomOf.TabIndex = 16;
            this.lblRomOf.Text = "RomOf:";
            this.lblRomOf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtButtons
            // 
            this.txtButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtButtons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtButtons.Location = new System.Drawing.Point(205, 52);
            this.txtButtons.Name = "txtButtons";
            this.txtButtons.ReadOnly = true;
            this.txtButtons.Size = new System.Drawing.Size(83, 13);
            this.txtButtons.TabIndex = 11;
            // 
            // lblMameButtons
            // 
            this.lblMameButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMameButtons.Location = new System.Drawing.Point(156, 50);
            this.lblMameButtons.Name = "lblMameButtons";
            this.lblMameButtons.Size = new System.Drawing.Size(49, 15);
            this.lblMameButtons.TabIndex = 10;
            this.lblMameButtons.Text = "Buttons:";
            this.lblMameButtons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(70, 4);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(83, 13);
            this.txtName.TabIndex = 1;
            // 
            // txtRomOf
            // 
            this.txtRomOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRomOf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRomOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRomOf.Location = new System.Drawing.Point(505, 4);
            this.txtRomOf.Name = "txtRomOf";
            this.txtRomOf.ReadOnly = true;
            this.txtRomOf.Size = new System.Drawing.Size(83, 13);
            this.txtRomOf.TabIndex = 17;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(30, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCloneOf
            // 
            this.lblCloneOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCloneOf.Location = new System.Drawing.Point(301, 4);
            this.lblCloneOf.Name = "lblCloneOf";
            this.lblCloneOf.Size = new System.Drawing.Size(54, 15);
            this.lblCloneOf.TabIndex = 14;
            this.lblCloneOf.Text = "CloneOf:";
            this.lblCloneOf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParent
            // 
            this.txtParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParent.Location = new System.Drawing.Point(505, 20);
            this.txtParent.Name = "txtParent";
            this.txtParent.ReadOnly = true;
            this.txtParent.Size = new System.Drawing.Size(83, 13);
            this.txtParent.TabIndex = 13;
            // 
            // txtCloneOf
            // 
            this.txtCloneOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCloneOf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCloneOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCloneOf.Location = new System.Drawing.Point(357, 4);
            this.txtCloneOf.Name = "txtCloneOf";
            this.txtCloneOf.ReadOnly = true;
            this.txtCloneOf.Size = new System.Drawing.Size(83, 13);
            this.txtCloneOf.TabIndex = 15;
            // 
            // lblParent
            // 
            this.lblParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParent.Location = new System.Drawing.Point(458, 19);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(46, 15);
            this.lblParent.TabIndex = 12;
            this.lblParent.Text = "Parent:";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSourceFile.Location = new System.Drawing.Point(155, 3);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(49, 15);
            this.lblSourceFile.TabIndex = 18;
            this.lblSourceFile.Text = "Source:";
            this.lblSourceFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabDipSwitches
            // 
            this.tabDipSwitches.Controls.Add(this.trvDipSwitch);
            this.tabDipSwitches.Location = new System.Drawing.Point(4, 22);
            this.tabDipSwitches.Name = "tabDipSwitches";
            this.tabDipSwitches.Size = new System.Drawing.Size(618, 69);
            this.tabDipSwitches.TabIndex = 2;
            this.tabDipSwitches.Text = "Dip Switches";
            this.tabDipSwitches.UseVisualStyleBackColor = true;
            // 
            // trvDipSwitch
            // 
            this.trvDipSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDipSwitch.Location = new System.Drawing.Point(0, 0);
            this.trvDipSwitch.Name = "trvDipSwitch";
            this.trvDipSwitch.Size = new System.Drawing.Size(618, 69);
            this.trvDipSwitch.TabIndex = 1;
            // 
            // grpControlsDat
            // 
            this.grpControlsDat.Controls.Add(this.tabControlsDat);
            this.grpControlsDat.Controls.Add(this.picControlsDat);
            this.grpControlsDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControlsDat.Location = new System.Drawing.Point(0, 0);
            this.grpControlsDat.Name = "grpControlsDat";
            this.grpControlsDat.Size = new System.Drawing.Size(632, 265);
            this.grpControlsDat.TabIndex = 58;
            this.grpControlsDat.TabStop = false;
            this.grpControlsDat.Text = "       ControlsDat";
            // 
            // tabControlsDat
            // 
            this.tabControlsDat.Controls.Add(this.tabControlInfo);
            this.tabControlsDat.Controls.Add(this.tabMiscDetails);
            this.tabControlsDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlsDat.Location = new System.Drawing.Point(3, 16);
            this.tabControlsDat.Name = "tabControlsDat";
            this.tabControlsDat.SelectedIndex = 0;
            this.tabControlsDat.Size = new System.Drawing.Size(626, 246);
            this.tabControlsDat.TabIndex = 58;
            // 
            // tabControlInfo
            // 
            this.tabControlInfo.Controls.Add(this.splitContainer3);
            this.tabControlInfo.Location = new System.Drawing.Point(4, 22);
            this.tabControlInfo.Name = "tabControlInfo";
            this.tabControlInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlInfo.Size = new System.Drawing.Size(618, 220);
            this.tabControlInfo.TabIndex = 0;
            this.tabControlInfo.Text = "Control Info";
            this.tabControlInfo.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(612, 214);
            this.splitContainer3.SplitterDistance = 105;
            this.splitContainer3.TabIndex = 57;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.grpOptions);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.grpControls);
            this.splitContainer4.Size = new System.Drawing.Size(612, 105);
            this.splitContainer4.SplitterDistance = 297;
            this.splitContainer4.TabIndex = 1;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkVerified);
            this.grpOptions.Controls.Add(this.lblNumPlayers);
            this.grpOptions.Controls.Add(this.nudButtons);
            this.grpOptions.Controls.Add(this.nudPlayers);
            this.grpOptions.Controls.Add(this.lblButtons);
            this.grpOptions.Controls.Add(this.chkCocktail);
            this.grpOptions.Controls.Add(this.chkTilt);
            this.grpOptions.Controls.Add(this.chkUsesService);
            this.grpOptions.Controls.Add(this.chkMirrored);
            this.grpOptions.Controls.Add(this.chkAlternating);
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOptions.Location = new System.Drawing.Point(0, 0);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(297, 105);
            this.grpOptions.TabIndex = 18;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkVerified
            // 
            this.chkVerified.AutoSize = true;
            this.chkVerified.Location = new System.Drawing.Point(225, 67);
            this.chkVerified.Name = "chkVerified";
            this.chkVerified.Size = new System.Drawing.Size(61, 17);
            this.chkVerified.TabIndex = 18;
            this.chkVerified.Text = "Verified";
            this.chkVerified.UseVisualStyleBackColor = true;
            this.chkVerified.CheckedChanged += new System.EventHandler(this.chkVerified_CheckedChanged);
            // 
            // lblNumPlayers
            // 
            this.lblNumPlayers.Location = new System.Drawing.Point(10, 14);
            this.lblNumPlayers.Name = "lblNumPlayers";
            this.lblNumPlayers.Size = new System.Drawing.Size(57, 20);
            this.lblNumPlayers.TabIndex = 8;
            this.lblNumPlayers.Text = "Players:";
            this.lblNumPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudButtons
            // 
            this.nudButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudButtons.Location = new System.Drawing.Point(202, 16);
            this.nudButtons.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudButtons.Name = "nudButtons";
            this.nudButtons.Size = new System.Drawing.Size(83, 20);
            this.nudButtons.TabIndex = 17;
            // 
            // nudPlayers
            // 
            this.nudPlayers.Location = new System.Drawing.Point(67, 16);
            this.nudPlayers.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudPlayers.Name = "nudPlayers";
            this.nudPlayers.Size = new System.Drawing.Size(83, 20);
            this.nudPlayers.TabIndex = 16;
            // 
            // lblButtons
            // 
            this.lblButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblButtons.Location = new System.Drawing.Point(152, 14);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(49, 20);
            this.lblButtons.TabIndex = 15;
            this.lblButtons.Text = "Buttons:";
            this.lblButtons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCocktail
            // 
            this.chkCocktail.AutoSize = true;
            this.chkCocktail.Location = new System.Drawing.Point(225, 46);
            this.chkCocktail.Name = "chkCocktail";
            this.chkCocktail.Size = new System.Drawing.Size(64, 17);
            this.chkCocktail.TabIndex = 14;
            this.chkCocktail.Text = "Cocktail";
            this.chkCocktail.UseVisualStyleBackColor = true;
            // 
            // chkTilt
            // 
            this.chkTilt.AutoSize = true;
            this.chkTilt.Location = new System.Drawing.Point(119, 67);
            this.chkTilt.Name = "chkTilt";
            this.chkTilt.Size = new System.Drawing.Size(40, 17);
            this.chkTilt.TabIndex = 13;
            this.chkTilt.Text = "Tilt";
            this.chkTilt.UseVisualStyleBackColor = true;
            // 
            // chkUsesService
            // 
            this.chkUsesService.AutoSize = true;
            this.chkUsesService.Location = new System.Drawing.Point(119, 46);
            this.chkUsesService.Name = "chkUsesService";
            this.chkUsesService.Size = new System.Drawing.Size(86, 17);
            this.chkUsesService.TabIndex = 12;
            this.chkUsesService.Text = "UsesService";
            this.chkUsesService.UseVisualStyleBackColor = true;
            // 
            // chkMirrored
            // 
            this.chkMirrored.AutoSize = true;
            this.chkMirrored.Location = new System.Drawing.Point(13, 67);
            this.chkMirrored.Name = "chkMirrored";
            this.chkMirrored.Size = new System.Drawing.Size(64, 17);
            this.chkMirrored.TabIndex = 11;
            this.chkMirrored.Text = "Mirrored";
            this.chkMirrored.UseVisualStyleBackColor = true;
            // 
            // chkAlternating
            // 
            this.chkAlternating.AutoSize = true;
            this.chkAlternating.Location = new System.Drawing.Point(13, 46);
            this.chkAlternating.Name = "chkAlternating";
            this.chkAlternating.Size = new System.Drawing.Size(76, 17);
            this.chkAlternating.TabIndex = 10;
            this.chkAlternating.Text = "Alternating";
            this.chkAlternating.UseVisualStyleBackColor = true;
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.splitContainer1);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControls.Location = new System.Drawing.Point(0, 0);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(311, 105);
            this.grpControls.TabIndex = 0;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Controls";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwControls);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.butControlsDown);
            this.splitContainer1.Panel2.Controls.Add(this.butControlsUp);
            this.splitContainer1.Panel2.Controls.Add(this.butRemoveControl);
            this.splitContainer1.Panel2.Controls.Add(this.butAddControl);
            this.splitContainer1.Size = new System.Drawing.Size(305, 86);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 3;
            // 
            // butControlsDown
            // 
            this.butControlsDown.Image = ((System.Drawing.Image)(resources.GetObject("butControlsDown.Image")));
            this.butControlsDown.Location = new System.Drawing.Point(2, 63);
            this.butControlsDown.Name = "butControlsDown";
            this.butControlsDown.Size = new System.Drawing.Size(22, 22);
            this.butControlsDown.TabIndex = 6;
            this.butControlsDown.UseVisualStyleBackColor = true;
            this.butControlsDown.Click += new System.EventHandler(this.butControlsDown_Click);
            // 
            // butControlsUp
            // 
            this.butControlsUp.Image = ((System.Drawing.Image)(resources.GetObject("butControlsUp.Image")));
            this.butControlsUp.Location = new System.Drawing.Point(2, 42);
            this.butControlsUp.Name = "butControlsUp";
            this.butControlsUp.Size = new System.Drawing.Size(22, 22);
            this.butControlsUp.TabIndex = 5;
            this.butControlsUp.UseVisualStyleBackColor = true;
            this.butControlsUp.Click += new System.EventHandler(this.butControlsUp_Click);
            // 
            // butRemoveControl
            // 
            this.butRemoveControl.Image = ((System.Drawing.Image)(resources.GetObject("butRemoveControl.Image")));
            this.butRemoveControl.Location = new System.Drawing.Point(2, 21);
            this.butRemoveControl.Name = "butRemoveControl";
            this.butRemoveControl.Size = new System.Drawing.Size(22, 22);
            this.butRemoveControl.TabIndex = 4;
            this.butRemoveControl.UseVisualStyleBackColor = true;
            this.butRemoveControl.Click += new System.EventHandler(this.butRemoveControl_Click);
            // 
            // butAddControl
            // 
            this.butAddControl.Image = ((System.Drawing.Image)(resources.GetObject("butAddControl.Image")));
            this.butAddControl.Location = new System.Drawing.Point(2, 0);
            this.butAddControl.Name = "butAddControl";
            this.butAddControl.Size = new System.Drawing.Size(22, 22);
            this.butAddControl.TabIndex = 0;
            this.butAddControl.UseVisualStyleBackColor = true;
            this.butAddControl.Click += new System.EventHandler(this.butAddControl_Click);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.grpSpecialButtons);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.grpLabels);
            this.splitContainer5.Size = new System.Drawing.Size(612, 105);
            this.splitContainer5.SplitterDistance = 297;
            this.splitContainer5.TabIndex = 2;
            // 
            // grpSpecialButtons
            // 
            this.grpSpecialButtons.Controls.Add(this.splitContainer6);
            this.grpSpecialButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSpecialButtons.Location = new System.Drawing.Point(0, 0);
            this.grpSpecialButtons.Name = "grpSpecialButtons";
            this.grpSpecialButtons.Size = new System.Drawing.Size(297, 105);
            this.grpSpecialButtons.TabIndex = 18;
            this.grpSpecialButtons.TabStop = false;
            this.grpSpecialButtons.Text = "Special Buttons";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(3, 16);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.lvwSpecialButtons);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.butButtonsDown);
            this.splitContainer6.Panel2.Controls.Add(this.butButtonsUp);
            this.splitContainer6.Panel2.Controls.Add(this.butRemoveButton);
            this.splitContainer6.Panel2.Controls.Add(this.butAddButton);
            this.splitContainer6.Size = new System.Drawing.Size(291, 86);
            this.splitContainer6.SplitterDistance = 262;
            this.splitContainer6.TabIndex = 61;
            // 
            // butButtonsDown
            // 
            this.butButtonsDown.Image = ((System.Drawing.Image)(resources.GetObject("butButtonsDown.Image")));
            this.butButtonsDown.Location = new System.Drawing.Point(2, 63);
            this.butButtonsDown.Name = "butButtonsDown";
            this.butButtonsDown.Size = new System.Drawing.Size(22, 22);
            this.butButtonsDown.TabIndex = 7;
            this.butButtonsDown.UseVisualStyleBackColor = true;
            this.butButtonsDown.Click += new System.EventHandler(this.butButtonsDown_Click);
            // 
            // butButtonsUp
            // 
            this.butButtonsUp.Image = ((System.Drawing.Image)(resources.GetObject("butButtonsUp.Image")));
            this.butButtonsUp.Location = new System.Drawing.Point(2, 42);
            this.butButtonsUp.Name = "butButtonsUp";
            this.butButtonsUp.Size = new System.Drawing.Size(22, 22);
            this.butButtonsUp.TabIndex = 6;
            this.butButtonsUp.UseVisualStyleBackColor = true;
            this.butButtonsUp.Click += new System.EventHandler(this.butButtonsUp_Click);
            // 
            // butRemoveButton
            // 
            this.butRemoveButton.Image = ((System.Drawing.Image)(resources.GetObject("butRemoveButton.Image")));
            this.butRemoveButton.Location = new System.Drawing.Point(2, 21);
            this.butRemoveButton.Name = "butRemoveButton";
            this.butRemoveButton.Size = new System.Drawing.Size(22, 22);
            this.butRemoveButton.TabIndex = 4;
            this.butRemoveButton.UseVisualStyleBackColor = true;
            this.butRemoveButton.Click += new System.EventHandler(this.butRemoveButton_Click);
            // 
            // butAddButton
            // 
            this.butAddButton.Image = ((System.Drawing.Image)(resources.GetObject("butAddButton.Image")));
            this.butAddButton.Location = new System.Drawing.Point(2, 0);
            this.butAddButton.Name = "butAddButton";
            this.butAddButton.Size = new System.Drawing.Size(22, 22);
            this.butAddButton.TabIndex = 0;
            this.butAddButton.UseVisualStyleBackColor = true;
            this.butAddButton.Click += new System.EventHandler(this.butAddButton_Click);
            // 
            // grpLabels
            // 
            this.grpLabels.Controls.Add(this.splitContainer2);
            this.grpLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLabels.Location = new System.Drawing.Point(0, 0);
            this.grpLabels.Name = "grpLabels";
            this.grpLabels.Size = new System.Drawing.Size(311, 105);
            this.grpLabels.TabIndex = 0;
            this.grpLabels.TabStop = false;
            this.grpLabels.Text = "Labels";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 16);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvwLabels);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.butLabelsDown);
            this.splitContainer2.Panel2.Controls.Add(this.butLabelsUp);
            this.splitContainer2.Panel2.Controls.Add(this.butRemoveLabel);
            this.splitContainer2.Panel2.Controls.Add(this.butAddLabel);
            this.splitContainer2.Size = new System.Drawing.Size(305, 86);
            this.splitContainer2.SplitterDistance = 276;
            this.splitContainer2.TabIndex = 60;
            // 
            // butLabelsDown
            // 
            this.butLabelsDown.Image = ((System.Drawing.Image)(resources.GetObject("butLabelsDown.Image")));
            this.butLabelsDown.Location = new System.Drawing.Point(2, 63);
            this.butLabelsDown.Name = "butLabelsDown";
            this.butLabelsDown.Size = new System.Drawing.Size(22, 22);
            this.butLabelsDown.TabIndex = 7;
            this.butLabelsDown.UseVisualStyleBackColor = true;
            this.butLabelsDown.Click += new System.EventHandler(this.butLabelsDown_Click);
            // 
            // butLabelsUp
            // 
            this.butLabelsUp.Image = ((System.Drawing.Image)(resources.GetObject("butLabelsUp.Image")));
            this.butLabelsUp.Location = new System.Drawing.Point(2, 42);
            this.butLabelsUp.Name = "butLabelsUp";
            this.butLabelsUp.Size = new System.Drawing.Size(22, 22);
            this.butLabelsUp.TabIndex = 6;
            this.butLabelsUp.UseVisualStyleBackColor = true;
            this.butLabelsUp.Click += new System.EventHandler(this.butLabelsUp_Click);
            // 
            // butRemoveLabel
            // 
            this.butRemoveLabel.Image = ((System.Drawing.Image)(resources.GetObject("butRemoveLabel.Image")));
            this.butRemoveLabel.Location = new System.Drawing.Point(2, 21);
            this.butRemoveLabel.Name = "butRemoveLabel";
            this.butRemoveLabel.Size = new System.Drawing.Size(22, 22);
            this.butRemoveLabel.TabIndex = 4;
            this.butRemoveLabel.UseVisualStyleBackColor = true;
            this.butRemoveLabel.Click += new System.EventHandler(this.butRemoveLabel_Click);
            // 
            // butAddLabel
            // 
            this.butAddLabel.Image = ((System.Drawing.Image)(resources.GetObject("butAddLabel.Image")));
            this.butAddLabel.Location = new System.Drawing.Point(2, 0);
            this.butAddLabel.Name = "butAddLabel";
            this.butAddLabel.Size = new System.Drawing.Size(22, 22);
            this.butAddLabel.TabIndex = 0;
            this.butAddLabel.UseVisualStyleBackColor = true;
            this.butAddLabel.Click += new System.EventHandler(this.butAddLabel_Click);
            // 
            // tabMiscDetails
            // 
            this.tabMiscDetails.Controls.Add(this.grpMiscDetails);
            this.tabMiscDetails.Location = new System.Drawing.Point(4, 22);
            this.tabMiscDetails.Name = "tabMiscDetails";
            this.tabMiscDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabMiscDetails.Size = new System.Drawing.Size(618, 220);
            this.tabMiscDetails.TabIndex = 1;
            this.tabMiscDetails.Text = "Misc Details";
            this.tabMiscDetails.UseVisualStyleBackColor = true;
            // 
            // grpMiscDetails
            // 
            this.grpMiscDetails.Controls.Add(this.txtMiscDetails);
            this.grpMiscDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMiscDetails.Location = new System.Drawing.Point(3, 3);
            this.grpMiscDetails.Name = "grpMiscDetails";
            this.grpMiscDetails.Size = new System.Drawing.Size(612, 214);
            this.grpMiscDetails.TabIndex = 1;
            this.grpMiscDetails.TabStop = false;
            this.grpMiscDetails.Text = "Misc Details";
            // 
            // txtMiscDetails
            // 
            this.txtMiscDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMiscDetails.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiscDetails.Location = new System.Drawing.Point(3, 16);
            this.txtMiscDetails.Multiline = true;
            this.txtMiscDetails.Name = "txtMiscDetails";
            this.txtMiscDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMiscDetails.Size = new System.Drawing.Size(606, 195);
            this.txtMiscDetails.TabIndex = 1;
            // 
            // picControlsDat
            // 
            this.picControlsDat.Location = new System.Drawing.Point(11, 0);
            this.picControlsDat.Name = "picControlsDat";
            this.picControlsDat.Size = new System.Drawing.Size(16, 16);
            this.picControlsDat.TabIndex = 17;
            this.picControlsDat.TabStop = false;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 25);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.grpMameInfo);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer10);
            this.splitContainer7.Size = new System.Drawing.Size(632, 417);
            this.splitContainer7.SplitterDistance = 114;
            this.splitContainer7.TabIndex = 59;
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.Location = new System.Drawing.Point(0, 0);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.grpControlsDat);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.pnlSwatches);
            this.splitContainer10.Panel2.Controls.Add(this.butOK);
            this.splitContainer10.Panel2.Controls.Add(this.butOKNext);
            this.splitContainer10.Panel2.Controls.Add(this.butCancel);
            this.splitContainer10.Size = new System.Drawing.Size(632, 299);
            this.splitContainer10.SplitterDistance = 265;
            this.splitContainer10.TabIndex = 59;
            // 
            // pnlSwatches
            // 
            this.pnlSwatches.Location = new System.Drawing.Point(233, 6);
            this.pnlSwatches.Name = "pnlSwatches";
            this.pnlSwatches.Size = new System.Drawing.Size(208, 16);
            this.pnlSwatches.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 60;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "No.png");
            this.imageList1.Images.SetKeyName(1, "Yes.png");
            this.imageList1.Images.SetKeyName(2, "UnVerified.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbCopy,
            this.tsbPaste,
            this.tsbDelete,
            this.toolStripSeparator2,
            this.tsbShowCPanel,
            this.tsbLaunchGame});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
            this.toolStrip1.TabIndex = 61;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 22);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbPaste.Text = "Paste";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbShowCPanel
            // 
            this.tsbShowCPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowCPanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowCPanel.Image")));
            this.tsbShowCPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowCPanel.Name = "tsbShowCPanel";
            this.tsbShowCPanel.Size = new System.Drawing.Size(23, 22);
            this.tsbShowCPanel.Text = "Show CPanel";
            this.tsbShowCPanel.ToolTipText = "Show CPanel";
            this.tsbShowCPanel.Click += new System.EventHandler(this.tsbShowCPanel_Click);
            // 
            // tsbLaunchGame
            // 
            this.tsbLaunchGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLaunchGame.Image = ((System.Drawing.Image)(resources.GetObject("tsbLaunchGame.Image")));
            this.tsbLaunchGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLaunchGame.Name = "tsbLaunchGame";
            this.tsbLaunchGame.Size = new System.Drawing.Size(23, 22);
            this.tsbLaunchGame.Text = "Launch Game";
            this.tsbLaunchGame.ToolTipText = "Launch Game";
            this.tsbLaunchGame.Click += new System.EventHandler(this.tsbLaunchGame_Click);
            // 
            // lvwControls
            // 
            this.lvwControls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colControlName,
            this.colControlConstant});
            this.lvwControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwControls.DoubleClickDoesCheck = false;
            this.lvwControls.FullRowSelect = true;
            this.lvwControls.GridLines = true;
            this.lvwControls.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwControls.HideSelection = false;
            this.lvwControls.Location = new System.Drawing.Point(0, 0);
            this.lvwControls.Name = "lvwControls";
            this.lvwControls.Size = new System.Drawing.Size(276, 86);
            this.lvwControls.TabIndex = 1;
            this.lvwControls.UseCompatibleStateImageBehavior = false;
            this.lvwControls.View = System.Windows.Forms.View.Details;
            // 
            // colControlName
            // 
            this.colControlName.Text = "Name";
            this.colControlName.Width = 159;
            // 
            // colControlConstant
            // 
            this.colControlConstant.Text = "Constant";
            this.colControlConstant.Width = 92;
            // 
            // lvwSpecialButtons
            // 
            this.lvwSpecialButtons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colButtonControl,
            this.colButtonButton});
            this.lvwSpecialButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSpecialButtons.DoubleClickDoesCheck = false;
            this.lvwSpecialButtons.FullRowSelect = true;
            this.lvwSpecialButtons.GridLines = true;
            this.lvwSpecialButtons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwSpecialButtons.HideSelection = false;
            this.lvwSpecialButtons.Location = new System.Drawing.Point(0, 0);
            this.lvwSpecialButtons.Name = "lvwSpecialButtons";
            this.lvwSpecialButtons.Size = new System.Drawing.Size(262, 86);
            this.lvwSpecialButtons.TabIndex = 0;
            this.lvwSpecialButtons.UseCompatibleStateImageBehavior = false;
            this.lvwSpecialButtons.View = System.Windows.Forms.View.Details;
            // 
            // colButtonControl
            // 
            this.colButtonControl.Text = "Control";
            this.colButtonControl.Width = 139;
            // 
            // colButtonButton
            // 
            this.colButtonButton.Text = "Button";
            this.colButtonButton.Width = 95;
            // 
            // lvwLabels
            // 
            this.lvwLabels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLabelName,
            this.colLabelValue,
            this.colLabelColor});
            this.lvwLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwLabels.DoubleClickDoesCheck = false;
            this.lvwLabels.FullRowSelect = true;
            this.lvwLabels.GridLines = true;
            this.lvwLabels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwLabels.HideSelection = false;
            this.lvwLabels.Location = new System.Drawing.Point(0, 0);
            this.lvwLabels.Name = "lvwLabels";
            this.lvwLabels.Size = new System.Drawing.Size(276, 86);
            this.lvwLabels.TabIndex = 0;
            this.lvwLabels.UseCompatibleStateImageBehavior = false;
            this.lvwLabels.View = System.Windows.Forms.View.Details;
            // 
            // colLabelName
            // 
            this.colLabelName.Text = "Name";
            this.colLabelName.Width = 133;
            // 
            // colLabelValue
            // 
            this.colLabelValue.Text = "Value";
            this.colLabelValue.Width = 74;
            // 
            // colLabelColor
            // 
            this.colLabelColor.Text = "Color";
            this.colLabelColor.Width = 42;
            // 
            // frmGameInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 464);
            this.Controls.Add(this.splitContainer7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(640, 490);
            this.Name = "frmGameInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Info";
            this.Load += new System.EventHandler(this.frmGameInfo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGameInfo_FormClosing);
            this.grpMameInfo.ResumeLayout(false);
            this.tabMameInfo.ResumeLayout(false);
            this.tabGameInfo.ResumeLayout(false);
            this.tabGameInfo.PerformLayout();
            this.tabDipSwitches.ResumeLayout(false);
            this.grpControlsDat.ResumeLayout(false);
            this.tabControlsDat.ResumeLayout(false);
            this.tabControlInfo.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayers)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.grpSpecialButtons.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            this.grpLabels.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabMiscDetails.ResumeLayout(false);
            this.grpMiscDetails.ResumeLayout(false);
            this.grpMiscDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picControlsDat)).EndInit();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            this.splitContainer10.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butOKNext;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.GroupBox grpMameInfo;
        private System.Windows.Forms.TextBox txtPlayers;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtButtons;
        private System.Windows.Forms.Label lblMameButtons;
        private System.Windows.Forms.GroupBox grpControlsDat;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label lblButtons;
        private System.Windows.Forms.CheckBox chkCocktail;
        private System.Windows.Forms.CheckBox chkTilt;
        private System.Windows.Forms.CheckBox chkUsesService;
        private System.Windows.Forms.CheckBox chkMirrored;
        private System.Windows.Forms.CheckBox chkAlternating;
        private System.Windows.Forms.Label lblNumPlayers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picControlsDat;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtParent;
        private System.Windows.Forms.Label lblRomOf;
        private System.Windows.Forms.TextBox txtRomOf;
        private System.Windows.Forms.Label lblCloneOf;
        private System.Windows.Forms.TextBox txtCloneOf;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbShowCPanel;
        private System.Windows.Forms.ToolStripButton tsbLaunchGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.NumericUpDown nudButtons;
        private System.Windows.Forms.NumericUpDown nudPlayers;
        private System.Windows.Forms.TabControl tabMameInfo;
        private System.Windows.Forms.TabPage tabGameInfo;
        private System.Windows.Forms.TabPage tabDipSwitches;
        private System.Windows.Forms.TreeView trvDipSwitch;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.Label lblSourceFile;
        private System.Windows.Forms.Label lblControls;
        private System.Windows.Forms.TextBox txtControls;
        private System.Windows.Forms.TabControl tabControlsDat;
        private System.Windows.Forms.TabPage tabControlInfo;
        private System.Windows.Forms.TabPage tabMiscDetails;
        private System.Windows.Forms.GroupBox grpMiscDetails;
        private System.Windows.Forms.TextBox txtMiscDetails;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Button butRemoveControl;
        private System.Windows.Forms.Button butAddControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CPWizard.ListViewEx lvwControls;
        private System.Windows.Forms.ColumnHeader colControlName;
        private System.Windows.Forms.ColumnHeader colControlConstant;
        private System.Windows.Forms.Button butControlsDown;
        private System.Windows.Forms.Button butControlsUp;
        private System.Windows.Forms.Panel pnlSwatches;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.GroupBox grpSpecialButtons;
        private System.Windows.Forms.GroupBox grpLabels;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CPWizard.ListViewEx lvwLabels;
        private System.Windows.Forms.ColumnHeader colLabelName;
        private System.Windows.Forms.ColumnHeader colLabelValue;
        private System.Windows.Forms.ColumnHeader colLabelColor;
        private System.Windows.Forms.Button butLabelsDown;
        private System.Windows.Forms.Button butLabelsUp;
        private System.Windows.Forms.Button butRemoveLabel;
        private System.Windows.Forms.Button butAddLabel;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private CPWizard.ListViewEx lvwSpecialButtons;
        private System.Windows.Forms.ColumnHeader colButtonControl;
        private System.Windows.Forms.Button butButtonsDown;
        private System.Windows.Forms.Button butButtonsUp;
        private System.Windows.Forms.Button butRemoveButton;
        private System.Windows.Forms.Button butAddButton;
        private System.Windows.Forms.ColumnHeader colButtonButton;
        private System.Windows.Forms.CheckBox chkVerified;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
    }
}