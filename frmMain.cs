using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ControlsDat
{
    public partial class frmMain : Form
    {
        private ListViewColumnSorter m_lvwColumnSorter;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[VERSION]", Global.Version);

            LogFile.WriteEntry("Reading Config");
            ConfigIO.ReadConfig();
            ConfigIO.LoadWindowPosition(this);

            m_lvwColumnSorter = new ListViewColumnSorter();
            lvwGameList.ListViewItemSorter = m_lvwColumnSorter;

            mnuShowAll.Checked = Settings.Filters.ShowAll;
            mnuControlsDat.Checked = Settings.Filters.ControlsDat;
            mnuParents.Checked = Settings.Filters.Parents;
            mnuClones.Checked = Settings.Filters.Clones;
            mnuVerified.Checked = Settings.Filters.Verified;
            mnuUnVerified.Checked = Settings.Filters.UnVerified;

            this.Show();

            if (Settings.General.FirstRun)
            {
                ShowOptionsForm();
            }
            else
            {
                using (frmInfo loadingForm = new frmInfo(this, "Loading Please Wait...", false, false))
                {
                    loadingForm.Show();
                    Application.DoEvents();
                    this.Cursor = Cursors.WaitCursor;
                    Global.MameManager.LoadMameData();
                    this.Cursor = Cursors.Default;

                    /* List<string> textList = new List<string>();

                    foreach (MameXml.GameNode gameNode in Global.MameXml.GameArray)
                    {
						//if (gameNode.Parent == null && gameNode.CloneOf == null && gameNode.RomOf == null)
						//	textList.Add(String.Format("{0}|{1}|{2}|{3}|{4}", gameNode.Parent != null ? gameNode.Parent.Name : "", gameNode.CloneOf, gameNode.RomOf, gameNode.Name, gameNode.Description));

                        if (gameNode.Parent == null && gameNode.CloneOf == null && gameNode.RomOf == null)
                            textList.Add(gameNode.Name + ".ico");

						if(gameNode.Description.Equals("Zzyzzyxx (set 2)"))
							break;
                    }

                    textList.Sort();

                    //File.WriteAllLines(Path.Combine(Application.StartupPath, "MameGames.txt"), textList.ToArray());
					//File.WriteAllLines(Path.Combine(Application.StartupPath, "MameGames_Parents.txt"), textList.ToArray());
                    File.WriteAllLines(Path.Combine(Application.StartupPath, "!include.txt"), textList.ToArray()); */
                }

                PopulateGameList();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            PromptToSave();
            LogFile.WriteEntry("Writing Config");
            ConfigIO.WriteConfig();
            ConfigIO.SaveWindowPosition(this);
        }

        private void PromptToSave()
        {
            if (Settings.General.PromptToSave)
            {
                if (MessageBox.Show(this, "Save Data?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }
        }

        public void SortGameList(MameXml.ColumnType columnType)
        {
            // Determine if clicked column is already the column that is being sorted.
            if ((int)columnType == m_lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (m_lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    m_lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    m_lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                m_lvwColumnSorter.SortColumn = (int)columnType;
                m_lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvwGameList.Sort();
        }

        public void PopulateGameList()
        {
            if (Global.MameXml == null)
                return;

            try
            {
                int lastRomSelectedIndex = 0;
                int parentCount = 0;
                int cloneCount = 0;

                Global.MameXml.GameArray.Sort();

                lvwGameList.Items.Clear();

                List<ListViewItem> lvwItems = new List<ListViewItem>();

                for (int i = 0; i < Global.MameXml.GameArray.Count; i++)
                {
                    MameXml.GameNode gameNode = Global.MameXml.GameArray[i];

                    if (gameNode.IsClone())
                        cloneCount++;
                    else
                        parentCount++;

                    if (!Settings.Filters.ShowAll)
                    {
                        if (Settings.Filters.ControlsDat && !gameNode.HasControlsDat())
                            continue;

                        if (Settings.Filters.Parents && gameNode.IsClone())
                            continue;

                        if (Settings.Filters.Clones && !gameNode.IsClone())
                            continue;

                        if (Settings.Filters.Verified && !gameNode.IsVerified())
                            continue;

                        if (Settings.Filters.UnVerified && gameNode.IsVerified())
                            continue;
                    }

                    ListViewItem lvwItem = GetListViewItem(gameNode);

                    lvwItems.Add(lvwItem);

                    if (gameNode.Name == Settings.General.LastRomSelected)
                        lastRomSelectedIndex = lvwItems.Count - 1;
                }

                lvwGameList.Items.AddRange(lvwItems.ToArray());

                if (lvwGameList.Items.Count > 0)
                {
                    lvwGameList.SelectedIndices.Add(lastRomSelectedIndex);
                    lvwGameList.EnsureVisible(lastRomSelectedIndex);
                }

                UpdateColumns();

                toolStripStatusLabel1.Text = String.Format("MAME Version {0}", Settings.Mame.Version);
                toolStripStatusLabel2.Text = String.Format("{0} Clones", cloneCount);
                toolStripStatusLabel3.Text = String.Format("{0} Parents", parentCount);
                toolStripStatusLabel4.Text = String.Format("{0} Total", Global.MameXml.GameArray.Count);
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("PopulateGameList", "frmMain", ex.Message, ex.StackTrace);
            }
        }

        private bool TryGetSelectedGame(out MameXml.GameNode gameNode, out int selectedGame)
        {
            gameNode = null;
            selectedGame = -1;

            if (lvwGameList.SelectedItems.Count == 0)
                return false;

            selectedGame = lvwGameList.SelectedIndices[0];

            gameNode = Global.MameXml.GameHash[lvwGameList.SelectedItems[0].SubItems[2].Text];

            return true;
        }

        private bool TryGetSelectedGameArray(out MameXml.GameNode[] gameArray, out int[] selectedIndicies)
        {
            gameArray = null;
            selectedIndicies = null;

            if (lvwGameList.SelectedItems.Count == 0)
                return false;

           gameArray = new MameXml.GameNode[lvwGameList.SelectedItems.Count];
           selectedIndicies = new int[lvwGameList.SelectedItems.Count];

           for (int i = 0; i < lvwGameList.SelectedItems.Count; i++)
           {
               gameArray[i] = Global.MameXml.GameHash[lvwGameList.SelectedItems[i].SubItems[2].Text];
               selectedIndicies[i] = lvwGameList.SelectedIndices[i];
           }

            return true;
        }

        private bool TryUpdateGame(MameXml.GameNode gameNode, int index)
        {
            lvwGameList.Items[index] = GetListViewItem(gameNode);

            return true;
        }

        private ListViewItem GetListViewItem(MameXml.GameNode gameNode)
        {
            Color red = Color.FromArgb(255, 240, 240);
            Color green = Color.FromArgb(240, 255, 240);
            Color blue = Color.FromArgb(240, 240, 255);

            string Name = gameNode.GetDescriptionString();
            string ROM = gameNode.GetNameString();
            string SourceFile = gameNode.GetSourceFileString();
            string CloneOf = gameNode.GetCloneOfString();
            string RomOf = gameNode.GetRomOfString();
            string Parent = gameNode.GetParentString();
            string Category = String.Empty;
            string Version = String.Empty;
            string Constants = gameNode.GetConstantsString();
            string Controls = gameNode.GetControlsString();
            string NumPlayers = gameNode.GetNumPlayersString();
            string NumButtons = gameNode.GetNumButtonsString();
            string Alternating = gameNode.GetAlternatingString();
            string Mirrored = gameNode.GetMirroredString();
            string UsesService = gameNode.GetUsesServiceString();
            string Tilt = gameNode.GetTiltString();
            string Cocktail = gameNode.GetCocktailString();
            bool Verified = gameNode.IsVerified();
            string MiscDetails = gameNode.GetMiscDetailsString();

            if (gameNode.CatVer != null)
            {
                Category = gameNode.CatVer.Category;
                Version = gameNode.CatVer.VerAdded;
            }

            ListViewItem lvwItem = new ListViewItem(new string[] { (gameNode.HasControlsDat() ? (Verified ? " " : "  ") : ""), Name, ROM, SourceFile, CloneOf, RomOf, Parent, Category, Version, Constants, Controls, NumPlayers, NumButtons, Alternating, Mirrored, UsesService, Tilt, Cocktail, MiscDetails });
            lvwItem.ImageIndex = (gameNode.HasControlsDat() ? (Verified ? 1 : 2) : 0);

            lvwItem.SubItems[0].BackColor = (gameNode.HasControlsDat() ? (gameNode.IsClone() ? blue : green) : red);

            return lvwItem;
        }

        private void UpdateColumns()
        {
            try
            {
                for (int i = 0; i < lvwGameList.Columns.Count; i++)
                    lvwGameList.Columns[i].Width = -2;
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("UpdateColumns", "frmMain", ex.Message, ex.StackTrace);
            }
        }

        private void ShowCPanel()
        {
            if(Global.CPanelForm == null)
            {
                Global.CPanelForm = new frmCPanel();
                Global.CPanelForm.Show();
            }

            MameXml.GameNode gameNode = null;
            int selectedIndex = 0;

            TryGetSelectedGame(out gameNode, out selectedIndex);

            Global.CPanelForm.LoadPanel(gameNode);
        }

        private void MameDiff()
        {
            using (frmMameDiff mameDiffForm = new frmMameDiff())
                mameDiffForm.ShowDialog(this);
        }

        private void New(MameXml.GameNode gameNode)
        {
            Global.ControlsDat.TryAddNew(gameNode);
        }

        private void Copy()
        {
            MameXml.GameNode gameNode = null;
            int selectedIndex = 0;

            TryGetSelectedGame(out gameNode, out selectedIndex);

            if(gameNode.HasControlsDat())
                Global.ControlsDat.Copy(gameNode.ControlsDat);
        }

        private void Paste()
        {
            MameXml.GameNode[] gameArray = null;
            int[] selectedIndicies = null;

            if (TryGetSelectedGameArray(out gameArray, out selectedIndicies))
            {
                for (int i = 0; i < gameArray.Length; i++)
                {
                    if (Global.ControlsDat.GameClipBoard != null)
                    {
                        New(gameArray[i]);

                        if (Global.ControlsDat.TryPaste(gameArray[i].ControlsDat))
                        {
                            TryUpdateGame(gameArray[i], selectedIndicies[i]);

                            Settings.General.PromptToSave = true;
                        }
                    }
                }
            }
        }

        private void Delete()
        {
            MameXml.GameNode[] gameArray = null;
            int[] selectedIndicies = null;

            if (TryGetSelectedGameArray(out gameArray, out selectedIndicies))
            {
                if (MessageBox.Show(this, "Delete ControlsDat Data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    for (int i = 0; i < gameArray.Length; i++)
                    {
                        if (gameArray[i].HasControlsDat())
                        {
                            Global.ControlsDat.Delete(gameArray[i].ControlsDat);

                            MameXml.GameNode gameNode = gameArray[i];
                            gameNode.ControlsDat = null;

                            TryUpdateGame(gameNode, selectedIndicies[i]);

                            Settings.General.PromptToSave = true;
                        }
                    }
                }
            }
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            ShowOptionsForm();
        }

        private void ShowOptionsForm()
        {
            using (frmOptions optionsForm = new frmOptions())
            {
                optionsForm.ShowDialog(this);

                if (optionsForm.DoLoadMameData)
                    PopulateGameList();
            }
        }

        private void EditControls()
        {
            bool done = false;
            int selectedGame = -1;

            while (!done)
            {
                MameXml.GameNode gameNode = null;

                if (TryGetSelectedGame(out gameNode, out selectedGame))
                {
                    using (frmGameInfo gameInfo = new frmGameInfo(gameNode))
                    {
                        gameInfo.ShowDialog(this);

                        switch (gameInfo.MyDialogResult)
                        {
                            case frmGameInfo.MyDialogResultType.OK:
                                TryUpdateGame(gameNode, selectedGame);

                                done = true;

                                lvwGameList.SelectedIndices.Clear();
                                lvwGameList.SelectedIndices.Add(selectedGame);
                                lvwGameList.EnsureVisible(selectedGame);
                                break;
                            case frmGameInfo.MyDialogResultType.OKNext:
                                TryUpdateGame(gameNode, selectedGame);

                                if (selectedGame < lvwGameList.Items.Count - 1)
                                    selectedGame++;
                                else
                                    done = true;

                                lvwGameList.SelectedIndices.Clear();
                                lvwGameList.SelectedIndices.Add(selectedGame);
                                lvwGameList.EnsureVisible(selectedGame);
                                break;
                            case frmGameInfo.MyDialogResultType.Cancel:
                                TryUpdateGame(gameNode, selectedGame);

                                done = true;

                                lvwGameList.SelectedIndices.Clear();
                                lvwGameList.SelectedIndices.Add(selectedGame);
                                lvwGameList.EnsureVisible(selectedGame);
                                break;
                        }
                    }
                }
                else
                    done = true;
            }
        }

        private void SaveData()
        {
            Global.ControlsDat.WriteControlsDatXml(Settings.Files.ControlsDat, ControlsDat.SaveType.All, true);
            Settings.General.PromptToSave = false;
        }

        private void lvwGameList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortGameList((MameXml.ColumnType) e.Column);
            
            //MameXml.SortMode = (MameXml.SortModeType)e.Column;

            //PopulateGameList();
        }

        private void lvwGameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGameList.SelectedItems.Count == 0)
                return;

            MameXml.GameNode gameNode = null;
            int selectedIndex = 0;

            if (TryGetSelectedGame(out gameNode, out selectedIndex))
            {
                Settings.General.LastRomSelected = gameNode.Name;

                if (Global.CPanelForm != null)
                    Global.CPanelForm.LoadPanel(gameNode);
            }
        }

        private void lvwGameList_DoubleClick(object sender, EventArgs e)
        {
            EditControls();
        }

        private void mnuEditControl_Click(object sender, EventArgs e)
        {
            EditControls();
        }

        private void tsbEditControl_Click(object sender, EventArgs e)
        {
            EditControls();
        }

        private void mnuLaunchGame_Click(object sender, EventArgs e)
        {
            MameXml.GameNode gameNode = null;
            int selectedIndex = 0;

            if (TryGetSelectedGame(out gameNode, out selectedIndex))
                Global.MameManager.LaunchGame(this, gameNode);
        }

        private void tsbLaunchGame_Click(object sender, EventArgs e)
        {
            MameXml.GameNode gameNode = null;
            int selectedIndex = 0;

            if (TryGetSelectedGame(out gameNode, out selectedIndex))
                Global.MameManager.LaunchGame(this, gameNode);
        }

        private void mnuShowCPanel_Click(object sender, EventArgs e)
        {
            ShowCPanel();
        }

        private void tsbShowCPanel_Click(object sender, EventArgs e)
        {
            ShowCPanel();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout aboutForm = new frmAbout())
                aboutForm.ShowDialog(this);
        }

        private void mnuMame_Click(object sender, EventArgs e)
        {
            if (Settings.Filters.ShowAll != mnuShowAll.Checked)
            {
                Settings.Filters.ShowAll = mnuShowAll.Checked;

                if (Settings.Filters.ShowAll)
                {
                    Settings.Filters.ControlsDat = false;
                    Settings.Filters.Parents = false;
                    Settings.Filters.Clones = false;
                    Settings.Filters.Verified = false;
                    Settings.Filters.UnVerified = false;

                    mnuControlsDat.Checked = false;
                    mnuParents.Checked = false;
                    mnuClones.Checked = false;
                    mnuVerified.Checked = false;
                    mnuUnVerified.Checked = false;
                }

                PopulateGameList();
            }
        }

        private void mnuControlsDat_Click(object sender, EventArgs e)
        {
            if (Settings.Filters.ControlsDat != mnuControlsDat.Checked)
            {
                Settings.Filters.ControlsDat = mnuControlsDat.Checked;

                if (Settings.Filters.ControlsDat)
                {
                    Settings.Filters.ShowAll = false;
                    mnuShowAll.Checked = false;
                }

                PopulateGameList();
            }
        }

        private void mnuParents_Click(object sender, EventArgs e)
        {
            if (Settings.Filters.Parents != mnuParents.Checked)
            {
                Settings.Filters.Parents = mnuParents.Checked;

                if (Settings.Filters.Parents)
                {
                    Settings.Filters.ShowAll = false;
                    Settings.Filters.Clones = false;

                    mnuShowAll.Checked = false;
                    mnuClones.Checked = false;
                }

                PopulateGameList();
            }
        }

        private void mnuClones_Click(object sender, EventArgs e)
        {
            if (Settings.Filters.Clones != mnuClones.Checked)
            {
                Settings.Filters.Clones = mnuClones.Checked;

                if (Settings.Filters.Clones)
                {
                    Settings.Filters.ShowAll = false;
                    Settings.Filters.Parents = false;

                    mnuShowAll.Checked = false;
                    mnuParents.Checked = false;
                }

                PopulateGameList();
            }
        }

        private void mnuVerified_Click(object sender, EventArgs e)
        {
            if (Settings.Filters.Verified != mnuVerified.Checked)
            {
                Settings.Filters.Verified = mnuVerified.Checked;

                if (Settings.Filters.Verified)
                {
                    Settings.Filters.ShowAll = false;
                    Settings.Filters.UnVerified = false;

                    mnuShowAll.Checked = false;
                    mnuUnVerified.Checked = false;
                }

                PopulateGameList();
            }
        }

        private void mnuUnVerified_Click(object sender, EventArgs e)
        {
            if (Settings.Filters.UnVerified != mnuUnVerified.Checked)
            {
                Settings.Filters.UnVerified = mnuUnVerified.Checked;

                if (Settings.Filters.UnVerified)
                {
                    Settings.Filters.ShowAll = false;
                    Settings.Filters.Verified = false;

                    mnuShowAll.Checked = false;
                    mnuVerified.Checked = false;
                }

                PopulateGameList();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (lvwGameList.SelectedItems.Count == 0)
                return;

            Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (lvwGameList.SelectedItems.Count == 0)
                return;

            Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (lvwGameList.SelectedItems.Count == 0)
                return;

            Delete();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (lvwGameList.SelectedItems.Count == 0)
                return;

            Copy();
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            if (lvwGameList.SelectedItems.Count == 0)
                return;

            Paste();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (lvwGameList.SelectedItems.Count == 0)
                return;

            Delete();
        }

        private void mnuImportControlsXml_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, null, "Controls.xml", ".xml", out fileName))
            {
                ControlsDat controlsDat = new ControlsDat();

                controlsDat.ReadControlsXml(fileName);

                foreach (ControlsDat.GameNode gameNode in controlsDat.GameArray)
                    Global.ControlsDat.TryAddNew(gameNode);
            }
        }

        private void mnuImportColorsIni_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, Settings.Folders.Data, "Colors.ini", ".ini", out fileName))
            {
                ColorsIni colorsIni = new ColorsIni();

                colorsIni.ReadColorsIni(fileName);
                Global.ControlsDat.AddColorsIni(colorsIni);
            }
        }

        private void mnuExportControlsDat_Click(object sender, EventArgs e)
        {
            using (frmExport exportForm = new frmExport())
            {
                if (exportForm.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = null;

                    switch (exportForm.FormatType)
                    {
                        case ControlsDat.FormatType.Xml:
                            if (FileIO.TrySaveFile(this, null, "Controls.xml", ".xml", out fileName))
                                Global.ControlsDat.WriteControlsDatXml(fileName, exportForm.SaveType, exportForm.IncludeColorData);
                            break;
                        case ControlsDat.FormatType.Ini:
                            if (FileIO.TrySaveFile(this, null, "Controls.xml", ".ini", out fileName))
                                Global.ControlsDat.WriteControlsDatIni(fileName, exportForm.SaveType, exportForm.IncludeColorData);
                            break;
                    }
                }
            }
        }

        private void mnuExportColorsIni_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TrySaveFile(this, null, "Colors.ini", ".ini", out fileName))
                Global.ControlsDat.WriteColorsIni(fileName);
        }

        private void mnuMameDiff_Click(object sender, EventArgs e)
        {
            MameDiff();
        }

        private void tsbMameDiff_Click(object sender, EventArgs e)
        {
            MameDiff();
        }
    }
}