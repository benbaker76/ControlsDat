using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlsDat
{
    public partial class frmGameInfo : Form
    {
        public enum MyDialogResultType
        {
            OK,
            OKNext,
            Cancel
        }

        private MameXml.GameNode m_gameNode = null;
        private MyDialogResultType m_myDialogResult = MyDialogResultType.Cancel;

        public frmGameInfo(MameXml.GameNode gameNode)
        {
            m_gameNode = gameNode;

            InitializeComponent();
        }

        private void frmGameInfo_Load(object sender, EventArgs e)
        {
            ConfigIO.LoadWindowPosition(this);

            if (Global.CPanelForm != null)
            {
                Global.CPanelForm.Close();
                ShowCPanel();
            }

            CreateColorSwatches();
            GetData();
        }

        private void frmGameInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigIO.SaveWindowPosition(this);
        }

        private void GetData()
        {
            txtName.Text = m_gameNode.GetNameString();
            txtSourceFile.Text = m_gameNode.GetSourceFileString();
            txtCloneOf.Text = m_gameNode.GetCloneOfString();
            txtRomOf.Text = m_gameNode.GetRomOfString();
            txtParent.Text = m_gameNode.GetParentString();
            txtDescription.Text = m_gameNode.GetDescriptionString();

            if (m_gameNode.CatVer != null)
            {
                txtCategory.Text = m_gameNode.CatVer.Category;
                txtVersion.Text = m_gameNode.CatVer.VerAdded;
            }

            txtPlayers.Text = m_gameNode.InputArray[0].Players.ToString();
            txtButtons.Text = m_gameNode.InputArray[0].Buttons.ToString();

            txtControls.Text = null;

            foreach(MameXml.ControlNode controlNode in m_gameNode.InputArray[0].ControlArray)
                txtControls.Text += controlNode.Constant + " ";

            trvDipSwitch.Nodes.Clear();

            foreach (MameXml.DipSwitchNode dipSwitchNode in m_gameNode.DipSwitchArray)
            {
                TreeNode treeNode = new TreeNode(dipSwitchNode.Name);
                trvDipSwitch.Nodes.Add(treeNode);

                foreach (MameXml.DipValueNode dipValueNode in dipSwitchNode.DipValueArray)
                    treeNode.Nodes.Add(new TreeNode(dipValueNode.Name));
            }

            //trvDipSwitch.ExpandAll();

            nudPlayers.Value = Convert.StrToInt(m_gameNode.GetNumPlayersString());
            nudButtons.Value = Convert.StrToInt(m_gameNode.GetNumButtonsString());
            chkAlternating.Checked = (m_gameNode.GetAlternatingString() == "Yes" ? true : false);
            chkMirrored.Checked = (m_gameNode.GetMirroredString() == "Yes" ? true : false);
            chkUsesService.Checked = (m_gameNode.GetUsesServiceString() == "Yes" ? true : false);
            chkTilt.Checked = (m_gameNode.GetTiltString() == "Yes" ? true : false);
            chkCocktail.Checked = (m_gameNode.GetCocktailString() == "Yes" ? true : false);
            chkVerified.Checked = m_gameNode.IsVerified();
            txtMiscDetails.Text = m_gameNode.GetMiscDetailsString();

            if (m_gameNode.HasControlsDat())
            {
                picControlsDat.Image = m_gameNode.ControlsDat.Verified == 1 ? imageList1.Images[1] : imageList1.Images[2];
                PopulateControlsListView();
                PopulateButtonsListView();
                PopulateLabelsListView();
                grpControlsDat.Enabled = true;
            }
            else
            {
                picControlsDat.Image = imageList1.Images[0];
                grpControlsDat.Enabled = false;
            }
        }

        private void SetData()
        {
            if (!m_gameNode.HasControlsDat())
                return;

            ControlsDat.GameNode gameNode = m_gameNode.ControlsDat;

            gameNode.NumPlayers = (int) nudPlayers.Value;
            gameNode.Alternating = (chkAlternating.Checked ? 1 : 0);
            gameNode.Mirrored = (chkMirrored.Checked ? 1 : 0);
            gameNode.UsesService = (chkUsesService.Checked ? 1 : 0);
            gameNode.Tilt = (chkTilt.Checked ? 1 : 0);
            gameNode.Cocktail = (chkCocktail.Checked ? 1 : 0);
            gameNode.Verified = (chkVerified.Checked ? 1 : 0);
            gameNode.MiscDetails = txtMiscDetails.Text;

            ControlsDat.PlayerNode playerNode = gameNode.PlayerArray[0];

            playerNode.NumButtons = (int) nudButtons.Value;
            playerNode.ControlArray.Clear();
            playerNode.LabelArray.Clear();

            foreach (ListViewItem lviControl in lvwControls.Items)
            {
                ControlsDat.ControlNode controlNode = new ControlsDat.ControlNode(lviControl.SubItems[0].Text);

                controlNode.ConstantArray.Add(lviControl.SubItems[1].Text);

                foreach (ListViewItem lviButton in lvwSpecialButtons.Items)
                    if(lviButton.SubItems[0].Text == lviControl.SubItems[0].Text)
                        controlNode.ButtonArray.Add(lviButton.SubItems[1].Text);

                playerNode.ControlArray.Add(controlNode);
            }

            foreach (ListViewItem lviLabel in lvwLabels.Items)
            {
                ControlsDat.LabelNode newLabelNode = new ControlsDat.LabelNode(lviLabel.SubItems[0].Text, lviLabel.SubItems[1].Text, lviLabel.SubItems[2].Text);

                playerNode.LabelArray.Add(newLabelNode);
            }

            Settings.General.PromptToSave = true;
        }

        private void New()
        {
            if (Global.ControlsDat.TryAddNew(m_gameNode))
            {
                lvwControls.ItemChanged += new CPWizard.ListViewEx.ItemChangedHandler(lvwControls_ItemChanged);

                GetData();
            }
        }

        private void CreateColorSwatches()
        {
            Button butColor = null;

            for (int i = 0; i < Global.SwatchArray.Length; i++)
            {
                butColor = new Button();
                butColor.Width = 16;
                butColor.Height = 16;
                butColor.Left = i * 16;
                butColor.Top = 0;
                butColor.Visible = true;
                butColor.Enabled = true;
                butColor.BackColor = Global.SwatchArray[i];
                butColor.Cursor = Cursors.Hand;
                butColor.Click += new EventHandler(butColor_Click);

                ToolTip tooltip = new ToolTip();
                tooltip.SetToolTip(butColor, Global.SwatchArray[i].Name);

                pnlSwatches.Controls.Add(butColor);
            }
        }

        private string[] GetControlArray()
        {
            string[] controlArray = new string[lvwControls.Items.Count];

            for (int i = 0; i < lvwControls.Items.Count; i++)
                controlArray[i] = lvwControls.Items[i].SubItems[0].Text;

            return controlArray;
        }

        private void AddControlsListViewItem(string name, string constant)
        {
            if (name == null)
                name = String.Empty;

            if (constant == null)
                constant = String.Empty;

            this.lvwControls.Items.Add(name);
            this.lvwControls.Items[this.lvwControls.Items.Count - 1].SubItems.AddRange(new string[] { constant });

            this.lvwControls.AddComboBoxCell(-1, 0, ControlsData.GetControlArray());
            this.lvwControls.AddComboBoxCell(this.lvwControls.Items.Count - 1, 1, ControlsData.GetConstantArray(name));
        }

        private void PopulateControlsListView()
        {
            lvwControls.ItemChanged -= new CPWizard.ListViewEx.ItemChangedHandler(lvwControls_ItemChanged);

            this.lvwControls.Items.Clear();

            foreach (ControlsDat.PlayerNode playerNode in m_gameNode.ControlsDat.PlayerArray)
            {
                foreach (ControlsDat.ControlNode controlNode in playerNode.ControlArray)
                {
                    foreach (string constant in controlNode.ConstantArray)
                    {
                        AddControlsListViewItem(controlNode.Name, constant);
                    }
                }
            }

            lvwControls.ItemChanged += new CPWizard.ListViewEx.ItemChangedHandler(lvwControls_ItemChanged);
        }

        private void AddButtonsListViewItem(string name, string button)
        {
            if (name == null)
                name = String.Empty;

            if (button == null)
                button = String.Empty;

            this.lvwSpecialButtons.Items.Add(name);
            this.lvwSpecialButtons.Items[this.lvwSpecialButtons.Items.Count - 1].SubItems.AddRange(new string[] { button });

            this.lvwSpecialButtons.AddComboBoxCell(-1, 0, GetControlArray());
            this.lvwSpecialButtons.AddComboBoxCell(this.lvwSpecialButtons.Items.Count - 1, 1, ControlsData.GetButtonArray());
        }

        private void PopulateButtonsListView()
        {
            this.lvwSpecialButtons.Items.Clear();

            foreach (ControlsDat.PlayerNode playerNode in m_gameNode.ControlsDat.PlayerArray)
            {
                foreach (ControlsDat.ControlNode controlNode in playerNode.ControlArray)
                {
                    foreach (string button in controlNode.ButtonArray)
                    {
                        AddButtonsListViewItem(controlNode.Name, button);
                    }
                }
            }
        }

        private void AddLabelsListViewItem(string name, string value, string color)
        {
            if (name == null)
                name = String.Empty;

            if (value == null)
                value = String.Empty;

            if (color == null)
                color = String.Empty;

            this.lvwLabels.Items.Add(name);
            this.lvwLabels.Items[this.lvwLabels.Items.Count - 1].UseItemStyleForSubItems = false;
            this.lvwLabels.Items[this.lvwLabels.Items.Count - 1].SubItems.AddRange(new string[] { value, color });

            if (!String.IsNullOrEmpty(color))
                this.lvwLabels.Items[this.lvwLabels.Items.Count - 1].SubItems[2].BackColor = Color.FromName(color);

            this.lvwLabels.AddComboBoxCell(-1, 0, ControlsData.GetControlCodeArray());
            this.lvwLabels.AddTextBoxCell(-1, 1);
            //this.lvwLabels.AddButtonCell(-1, 2);
        }

        private void PopulateLabelsListView()
        {
            lvwLabels.ItemChanged -= new CPWizard.ListViewEx.ItemChangedHandler(lvwLabels_ItemChanged);

            this.lvwLabels.Items.Clear();

            foreach (ControlsDat.PlayerNode playerNode in m_gameNode.ControlsDat.PlayerArray)
            {
                foreach (ControlsDat.LabelNode labelNode in playerNode.LabelArray)
                {
                    AddLabelsListViewItem(labelNode.Name, labelNode.Value, labelNode.Color);
                }
            }

            lvwLabels.ItemChanged += new CPWizard.ListViewEx.ItemChangedHandler(lvwLabels_ItemChanged);
        }

        private void CreateControlsDat()
        {
            if (m_gameNode.ControlsDat == null)
            {
                m_gameNode.ControlsDat = new ControlsDat.GameNode(m_gameNode.Name, m_gameNode.Description, 0, 0, 0, (m_gameNode.InputArray[0].Service ? 1 : 0), 0, 0);
                picControlsDat.Image = imageList1.Images[2];
            }
        }

        private void AddMissingLabels(string[] nameArray, string[] labelArray)
        {
            for(int i=0; i<nameArray.Length; i++)
            {
                bool labelFound = false;
                string labelName = null;

                if (nameArray[i] == "BUTTON")
                {
                    for (int b = 0; b < Convert.StrToInt(m_gameNode.GetNumButtonsString()); b++)
                    {
                        labelName = String.Format("P1_BUTTON{0}", b + 1);

                        foreach (ListViewItem listViewItem in lvwLabels.Items)
                        {
                            if (labelName == listViewItem.Text)
                            {
                                labelFound = true;
                                break;
                            }
                        }

                        if (!labelFound)
                            AddLabelsListViewItem(labelName, labelArray[i], null);
                    }
                }
                else
                {
                    labelName = String.Format("P1_{0}", nameArray[i]);

                    foreach (ListViewItem listViewItem in lvwLabels.Items)
                    {
                        if (labelName == listViewItem.Text)
                        {
                            labelFound = true;
                            break;
                        }
                    }

                    if (!labelFound)
                        AddLabelsListViewItem(labelName, labelArray[i], null);
                }
            }
        }

        private void MoveListViewItemsUp(ListView listView)
        {
            for (int i = 0; i < listView.SelectedIndices.Count; i++)
            {
                int selectedIndex = listView.SelectedIndices[i];

                if (selectedIndex > 0)
                {
                    ListViewItem listViewItem = listView.Items[selectedIndex];
                    listView.Items.RemoveAt(selectedIndex);
                    listView.Items.Insert(selectedIndex - 1, listViewItem);
                }
            }
        }

        private void MoveListViewItemsDown(ListView listView)
        {
            for (int i = listView.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int selectedIndex = listView.SelectedIndices[i];

                if (selectedIndex < listView.Items.Count - 1)
                {
                    ListViewItem listViewItem = listView.Items[selectedIndex];
                    listView.Items.RemoveAt(selectedIndex);
                    listView.Items.Insert(selectedIndex + 1, listViewItem);
                }
            }
        }

        private void DeleteListViewItems(ListView listView)
        {
            for (int i = listView.SelectedIndices.Count - 1; i >= 0; i--)
                listView.Items.RemoveAt(listView.SelectedIndices[i]);
        }

        private void SelectColor(Color color)
        {
            if (lvwLabels.SelectedItems.Count == 0)
                return;

            int selectedIndex = lvwLabels.SelectedIndices[0];

            lvwLabels.SelectedItems[0].SubItems[2].BackColor = color;
            lvwLabels.SelectedItems[0].SubItems[2].Text = color.Name;

            if (selectedIndex < lvwLabels.Items.Count - 1)
            {
                selectedIndex++;
                lvwLabels.SelectedIndices.Clear();
                lvwLabels.SelectedIndices.Add(selectedIndex);
                lvwLabels.EnsureVisible(selectedIndex);
            }
        }

        private void ShowCPanel()
        {
            if (Global.CPanelForm == null)
            {
                Global.CPanelForm = new frmCPanel();
                Global.CPanelForm.PixelSelect += new frmCPanel.PixelSelectDelegate(OnPixelSelect);
                Global.CPanelForm.Show();
            }

            Global.CPanelForm.LoadPanel(m_gameNode);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            m_myDialogResult = MyDialogResultType.Cancel;
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            m_myDialogResult = MyDialogResultType.OK;
            SetData();
            this.Close();
        }

        private void butOKNext_Click(object sender, EventArgs e)
        {
            m_myDialogResult = MyDialogResultType.OKNext;
            SetData();
            this.Close();
        }

        public MyDialogResultType MyDialogResult
        {
            get { return m_myDialogResult; }
        }

        private void tsbShowCPanel_Click(object sender, EventArgs e)
        {
            ShowCPanel();
        }

        private void tsbLaunchGame_Click(object sender, EventArgs e)
        {
            Global.MameManager.LaunchGame(this, m_gameNode);
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (m_gameNode.HasControlsDat())
            {
                Global.ControlsDat.Copy(m_gameNode.ControlsDat);
            }
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            New();

            if (m_gameNode.HasControlsDat())
            {
                if (Global.ControlsDat.TryPaste(m_gameNode.ControlsDat))
                {
                    GetData();

                    Settings.General.PromptToSave = true;
                }
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (m_gameNode.HasControlsDat())
            {
                if (MessageBox.Show(this, "Delete ControlsDat Data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    Global.ControlsDat.Delete(m_gameNode.ControlsDat);
                    m_gameNode.ControlsDat = null;

                    picControlsDat.Image = imageList1.Images[0];
                    grpControlsDat.Enabled = false;

                    lvwControls.ItemChanged -= new CPWizard.ListViewEx.ItemChangedHandler(lvwControls_ItemChanged);

                    Settings.General.PromptToSave = true;
                }
            }
        }

        private void lvwControls_ItemChanged(int row, int col, string oldText, string newText)
        {
            switch (col)
            {
                case 0: // Name
                    string[] constantArray = ControlsData.GetConstantArray(newText);
                    lvwControls.AddComboBoxCell(row, 1, constantArray);
                    lvwSpecialButtons.AddComboBoxCell(-1, 0, GetControlArray());
                    break;
                case 1: // Constant
                    string[] nameArray = null, labelArray = null;
                    ControlsData.GetControlLabelArray(newText, out nameArray, out labelArray);
                    AddMissingLabels(nameArray, labelArray);
                    break;
            }
        }

        private void lvwLabels_ItemChanged(int row, int col, string oldText, string newText)
        {
            switch (col)
            {
                case 0: // Name
                    break;
                case 1: // Value
                    break;
                case 2: // Color
                    break;
            }
        }

        private void butAddControl_Click(object sender, EventArgs e)
        {
            AddControlsListViewItem("??", "??");
        }

        private void butRemoveControl_Click(object sender, EventArgs e)
        {
            DeleteListViewItems(lvwControls);
            lvwSpecialButtons.AddComboBoxCell(-1, 0, GetControlArray());
        }

        private void butControlsUp_Click(object sender, EventArgs e)
        {
            MoveListViewItemsUp(lvwControls);
        }

        private void butControlsDown_Click(object sender, EventArgs e)
        {
            MoveListViewItemsDown(lvwControls);
        }

        private void butAddLabel_Click(object sender, EventArgs e)
        {
            AddLabelsListViewItem("??", "??", null);
        }

        private void butRemoveLabel_Click(object sender, EventArgs e)
        {
            DeleteListViewItems(lvwLabels);
        }

        private void butLabelsUp_Click(object sender, EventArgs e)
        {
            MoveListViewItemsUp(lvwLabels);
        }

        private void butLabelsDown_Click(object sender, EventArgs e)
        {
            MoveListViewItemsDown(lvwLabels);
        }

        private void butAddButton_Click(object sender, EventArgs e)
        {
            AddButtonsListViewItem("??", "??");
        }

        private void butRemoveButton_Click(object sender, EventArgs e)
        {
            DeleteListViewItems(lvwSpecialButtons);
        }

        private void butButtonsUp_Click(object sender, EventArgs e)
        {
            MoveListViewItemsUp(lvwSpecialButtons);
        }

        private void butButtonsDown_Click(object sender, EventArgs e)
        {
            MoveListViewItemsDown(lvwSpecialButtons);
        }

        void OnPixelSelect(Color color)
        {
            SelectColor(color);
        }

        private void butColor_Click(object sender, System.EventArgs e)
        {
            SelectColor(((Button)sender).BackColor);
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void chkVerified_CheckedChanged(object sender, EventArgs e)
        {
            picControlsDat.Image = (chkVerified.Checked ? imageList1.Images[1] : imageList1.Images[2]);
        }
    }
}