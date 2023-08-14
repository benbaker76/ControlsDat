namespace ControlsDat
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportControlsXml = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportColorsIni = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportControlsDat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportColorsIni = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditControls = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowCPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLaunchGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMameDiff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuControlsDat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuParents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerified = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnVerified = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvwGameList = new System.Windows.Forms.ListView();
            this.colControlsDat = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colROM = new System.Windows.Forms.ColumnHeader();
            this.colSourceFile = new System.Windows.Forms.ColumnHeader();
            this.colCloneOf = new System.Windows.Forms.ColumnHeader();
            this.colRomOf = new System.Windows.Forms.ColumnHeader();
            this.colParent = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.colVersion = new System.Windows.Forms.ColumnHeader();
            this.colConstants = new System.Windows.Forms.ColumnHeader();
            this.colControls = new System.Windows.Forms.ColumnHeader();
            this.colNumPlayers = new System.Windows.Forms.ColumnHeader();
            this.colNumButtons = new System.Windows.Forms.ColumnHeader();
            this.colAlternating = new System.Windows.Forms.ColumnHeader();
            this.colMirrored = new System.Windows.Forms.ColumnHeader();
            this.colUsesService = new System.Windows.Forms.ColumnHeader();
            this.colTilt = new System.Windows.Forms.ColumnHeader();
            this.colCocktail = new System.Windows.Forms.ColumnHeader();
            this.colMiscDetails = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditControls = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowCPanel = new System.Windows.Forms.ToolStripButton();
            this.tsbLaunchGame = new System.Windows.Forms.ToolStripButton();
            this.tsbMameDiff = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuTools,
            this.mnuFilters,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImport,
            this.mnuExport,
            this.toolStripMenuItem3,
            this.mnuSave});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuImport
            // 
            this.mnuImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportControlsXml,
            this.mnuImportColorsIni});
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(110, 22);
            this.mnuImport.Text = "Import";
            // 
            // mnuImportControlsXml
            // 
            this.mnuImportControlsXml.Name = "mnuImportControlsXml";
            this.mnuImportControlsXml.Size = new System.Drawing.Size(142, 22);
            this.mnuImportControlsXml.Text = "Controls.xml";
            this.mnuImportControlsXml.Click += new System.EventHandler(this.mnuImportControlsXml_Click);
            // 
            // mnuImportColorsIni
            // 
            this.mnuImportColorsIni.Name = "mnuImportColorsIni";
            this.mnuImportColorsIni.Size = new System.Drawing.Size(142, 22);
            this.mnuImportColorsIni.Text = "Colors.ini";
            this.mnuImportColorsIni.Click += new System.EventHandler(this.mnuImportColorsIni_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportControlsDat,
            this.mnuExportColorsIni});
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(110, 22);
            this.mnuExport.Text = "Export";
            // 
            // mnuExportControlsDat
            // 
            this.mnuExportControlsDat.Name = "mnuExportControlsDat";
            this.mnuExportControlsDat.Size = new System.Drawing.Size(137, 22);
            this.mnuExportControlsDat.Text = "ControlsDat";
            this.mnuExportControlsDat.Click += new System.EventHandler(this.mnuExportControlsDat_Click);
            // 
            // mnuExportColorsIni
            // 
            this.mnuExportColorsIni.Name = "mnuExportColorsIni";
            this.mnuExportColorsIni.Size = new System.Drawing.Size(137, 22);
            this.mnuExportColorsIni.Text = "Colors.ini";
            this.mnuExportColorsIni.Click += new System.EventHandler(this.mnuExportColorsIni_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(107, 6);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(110, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuPaste,
            this.mnuDelete});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(107, 22);
            this.mnuCopy.Text = "Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(107, 22);
            this.mnuPaste.Text = "Paste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditControls,
            this.toolStripMenuItem2,
            this.mnuShowCPanel,
            this.mnuLaunchGame,
            this.mnuMameDiff,
            this.toolStripMenuItem1,
            this.mnuOptions});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuEditControls
            // 
            this.mnuEditControls.Name = "mnuEditControls";
            this.mnuEditControls.Size = new System.Drawing.Size(150, 22);
            this.mnuEditControls.Text = "Edit Control(s)";
            this.mnuEditControls.Click += new System.EventHandler(this.mnuEditControl_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // mnuShowCPanel
            // 
            this.mnuShowCPanel.Name = "mnuShowCPanel";
            this.mnuShowCPanel.Size = new System.Drawing.Size(150, 22);
            this.mnuShowCPanel.Text = "Show CPanel";
            this.mnuShowCPanel.Click += new System.EventHandler(this.mnuShowCPanel_Click);
            // 
            // mnuLaunchGame
            // 
            this.mnuLaunchGame.Name = "mnuLaunchGame";
            this.mnuLaunchGame.Size = new System.Drawing.Size(150, 22);
            this.mnuLaunchGame.Text = "Launch Game";
            this.mnuLaunchGame.Click += new System.EventHandler(this.mnuLaunchGame_Click);
            // 
            // mnuMameDiff
            // 
            this.mnuMameDiff.Name = "mnuMameDiff";
            this.mnuMameDiff.Size = new System.Drawing.Size(150, 22);
            this.mnuMameDiff.Text = "MameDiff";
            this.mnuMameDiff.Click += new System.EventHandler(this.mnuMameDiff_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(150, 22);
            this.mnuOptions.Text = "Options";
            this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // mnuFilters
            // 
            this.mnuFilters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow});
            this.mnuFilters.Name = "mnuFilters";
            this.mnuFilters.Size = new System.Drawing.Size(50, 20);
            this.mnuFilters.Text = "Filters";
            // 
            // mnuShow
            // 
            this.mnuShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowAll,
            this.mnuControlsDat,
            this.mnuParents,
            this.mnuClones,
            this.mnuVerified,
            this.mnuUnVerified});
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(103, 22);
            this.mnuShow.Text = "Show";
            // 
            // mnuShowAll
            // 
            this.mnuShowAll.Checked = true;
            this.mnuShowAll.CheckOnClick = true;
            this.mnuShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuShowAll.Name = "mnuShowAll";
            this.mnuShowAll.Size = new System.Drawing.Size(137, 22);
            this.mnuShowAll.Text = "Show All";
            this.mnuShowAll.Click += new System.EventHandler(this.mnuMame_Click);
            // 
            // mnuControlsDat
            // 
            this.mnuControlsDat.CheckOnClick = true;
            this.mnuControlsDat.Name = "mnuControlsDat";
            this.mnuControlsDat.Size = new System.Drawing.Size(137, 22);
            this.mnuControlsDat.Text = "ControlsDat";
            this.mnuControlsDat.Click += new System.EventHandler(this.mnuControlsDat_Click);
            // 
            // mnuParents
            // 
            this.mnuParents.CheckOnClick = true;
            this.mnuParents.Name = "mnuParents";
            this.mnuParents.Size = new System.Drawing.Size(137, 22);
            this.mnuParents.Text = "Parents";
            this.mnuParents.Click += new System.EventHandler(this.mnuParents_Click);
            // 
            // mnuClones
            // 
            this.mnuClones.CheckOnClick = true;
            this.mnuClones.Name = "mnuClones";
            this.mnuClones.Size = new System.Drawing.Size(137, 22);
            this.mnuClones.Text = "Clones";
            this.mnuClones.Click += new System.EventHandler(this.mnuClones_Click);
            // 
            // mnuVerified
            // 
            this.mnuVerified.CheckOnClick = true;
            this.mnuVerified.Name = "mnuVerified";
            this.mnuVerified.Size = new System.Drawing.Size(137, 22);
            this.mnuVerified.Text = "Verified";
            this.mnuVerified.Click += new System.EventHandler(this.mnuVerified_Click);
            // 
            // mnuUnVerified
            // 
            this.mnuUnVerified.CheckOnClick = true;
            this.mnuUnVerified.Name = "mnuUnVerified";
            this.mnuUnVerified.Size = new System.Drawing.Size(137, 22);
            this.mnuUnVerified.Text = "UnVerified";
            this.mnuUnVerified.Click += new System.EventHandler(this.mnuUnVerified_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(605, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(4, 17);
            // 
            // lvwGameList
            // 
            this.lvwGameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colControlsDat,
            this.colName,
            this.colROM,
            this.colSourceFile,
            this.colCloneOf,
            this.colRomOf,
            this.colParent,
            this.colCategory,
            this.colVersion,
            this.colConstants,
            this.colControls,
            this.colNumPlayers,
            this.colNumButtons,
            this.colAlternating,
            this.colMirrored,
            this.colUsesService,
            this.colTilt,
            this.colCocktail,
            this.colMiscDetails});
            this.lvwGameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGameList.FullRowSelect = true;
            this.lvwGameList.GridLines = true;
            this.lvwGameList.HideSelection = false;
            this.lvwGameList.Location = new System.Drawing.Point(0, 49);
            this.lvwGameList.Name = "lvwGameList";
            this.lvwGameList.Size = new System.Drawing.Size(632, 382);
            this.lvwGameList.SmallImageList = this.imageList1;
            this.lvwGameList.TabIndex = 2;
            this.lvwGameList.UseCompatibleStateImageBehavior = false;
            this.lvwGameList.View = System.Windows.Forms.View.Details;
            this.lvwGameList.SelectedIndexChanged += new System.EventHandler(this.lvwGameList_SelectedIndexChanged);
            this.lvwGameList.DoubleClick += new System.EventHandler(this.lvwGameList_DoubleClick);
            this.lvwGameList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwGameList_ColumnClick);
            // 
            // colControlsDat
            // 
            this.colControlsDat.Text = "";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colROM
            // 
            this.colROM.Text = "ROM";
            // 
            // colSourceFile
            // 
            this.colSourceFile.Text = "SourceFile";
            // 
            // colCloneOf
            // 
            this.colCloneOf.Text = "CloneOf";
            // 
            // colRomOf
            // 
            this.colRomOf.Text = "RomOf";
            // 
            // colParent
            // 
            this.colParent.Text = "Parent";
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            // 
            // colConstants
            // 
            this.colConstants.Text = "Constants";
            // 
            // colControls
            // 
            this.colControls.Text = "Controls";
            // 
            // colNumPlayers
            // 
            this.colNumPlayers.Text = "NumPlayers";
            // 
            // colNumButtons
            // 
            this.colNumButtons.Text = "NumButtons";
            // 
            // colAlternating
            // 
            this.colAlternating.Text = "Alternating";
            // 
            // colMirrored
            // 
            this.colMirrored.Text = "Mirrored";
            // 
            // colUsesService
            // 
            this.colUsesService.Text = "UsesService";
            // 
            // colTilt
            // 
            this.colTilt.Text = "Tilt";
            // 
            // colCocktail
            // 
            this.colCocktail.Text = "Cocktail";
            // 
            // colMiscDetails
            // 
            this.colMiscDetails.Text = "MiscDetails";
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
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbEditControls,
            this.toolStripSeparator2,
            this.tsbCopy,
            this.tsbPaste,
            this.tsbDelete,
            this.toolStripSeparator3,
            this.tsbShowCPanel,
            this.tsbLaunchGame,
            this.tsbMameDiff});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.ToolTipText = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEditControls
            // 
            this.tsbEditControls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditControls.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditControls.Image")));
            this.tsbEditControls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditControls.Name = "tsbEditControls";
            this.tsbEditControls.Size = new System.Drawing.Size(23, 22);
            this.tsbEditControls.Text = "Edit Control(s)";
            this.tsbEditControls.Click += new System.EventHandler(this.tsbEditControl_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // tsbMameDiff
            // 
            this.tsbMameDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMameDiff.Image = ((System.Drawing.Image)(resources.GetObject("tsbMameDiff.Image")));
            this.tsbMameDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMameDiff.Name = "tsbMameDiff";
            this.tsbMameDiff.Size = new System.Drawing.Size(23, 22);
            this.tsbMameDiff.Text = "MameDiff";
            this.tsbMameDiff.Click += new System.EventHandler(this.tsbMameDiff_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.lvwGameList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControlsDat [VERSION]";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lvwGameList;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colROM;
        private System.Windows.Forms.ColumnHeader colSourceFile;
        private System.Windows.Forms.ColumnHeader colCloneOf;
        private System.Windows.Forms.ColumnHeader colRomOf;
        private System.Windows.Forms.ColumnHeader colParent;
        private System.Windows.Forms.ColumnHeader colConstants;
        private System.Windows.Forms.ColumnHeader colControls;
        private System.Windows.Forms.ColumnHeader colNumPlayers;
        private System.Windows.Forms.ColumnHeader colAlternating;
        private System.Windows.Forms.ColumnHeader colMirrored;
        private System.Windows.Forms.ColumnHeader colUsesService;
        private System.Windows.Forms.ColumnHeader colTilt;
        private System.Windows.Forms.ColumnHeader colCocktail;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ColumnHeader colNumButtons;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbShowCPanel;
        private System.Windows.Forms.ToolStripButton tsbLaunchGame;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuLaunchGame;
        private System.Windows.Forms.ToolStripMenuItem mnuEditControls;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuShowCPanel;
        private System.Windows.Forms.ToolStripButton tsbEditControls;
        private System.Windows.Forms.ColumnHeader colMiscDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuFilters;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.ToolStripMenuItem mnuShowAll;
        private System.Windows.Forms.ToolStripMenuItem mnuControlsDat;
        private System.Windows.Forms.ToolStripMenuItem mnuParents;
        private System.Windows.Forms.ColumnHeader colControlsDat;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private System.Windows.Forms.ToolStripMenuItem mnuImportControlsXml;
        private System.Windows.Forms.ToolStripMenuItem mnuImportColorsIni;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuVerified;
        private System.Windows.Forms.ToolStripMenuItem mnuUnVerified;
        private System.Windows.Forms.ToolStripMenuItem mnuClones;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuMameDiff;
        private System.Windows.Forms.ToolStripButton tsbMameDiff;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripMenuItem mnuExportControlsDat;
        private System.Windows.Forms.ToolStripMenuItem mnuExportColorsIni;
    }
}

