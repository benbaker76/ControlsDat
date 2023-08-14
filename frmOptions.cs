using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ControlsDat
{
    public partial class frmOptions : Form
    {
        public bool DoLoadMameData = false;

        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            GetOptions();
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void GetOptions()
        {
            txtUserName.Text = Settings.General.UserName;

            txtMameExe.Text = Settings.Mame.Files.Exe;
            txtCPanel.Text = Settings.Mame.Folders.CPanel;
        }

        private void SetFolder(string mameFolder, TextBox txtFolder, string name)
        {
            string newPath = Path.Combine(mameFolder, name);

            if (Directory.Exists(txtFolder.Text))
                return;

            if (Directory.Exists(newPath))
                txtFolder.Text = newPath;
        }

        private void CalcMameFolders(string mameExe)
        {
            string mameFolder = Path.GetDirectoryName(mameExe);

            SetFolder(mameFolder, txtCPanel, "cpanel");
        }

        private void LoadMameData()
        {
            try
            {
                if (DoLoadMameData)
                {
                    using (frmInfo loadingForm = new frmInfo(this, "Loading Please Wait...", false, false))
                    {
                        loadingForm.Show();
                        Application.DoEvents();
                        this.Cursor = Cursors.WaitCursor;
                        butOk.Enabled = false;
                        butCancel.Enabled = false;
                        Global.MameManager.LoadMameData();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("LoadMameData", "OptionsForm", ex.Message, ex.StackTrace);
            }
        }

        private void SetOptions()
        {
            Settings.General.UserName = txtUserName.Text;

            Settings.Mame.Files.Exe = txtMameExe.Text;
            Settings.Mame.Folders.CPanel = txtCPanel.Text;

            ConfigIO.WriteConfig();

            LoadMameData();

            if (File.Exists(Settings.Mame.Files.Exe))
                Settings.Mame.Folders.Root = Path.GetDirectoryName(Settings.Mame.Files.Exe);
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            SetOptions();
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butMameExe_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, FileIO.GetPath(txtMameExe.Text), FileIO.GetFile(txtMameExe.Text), ".exe", out fileName))
            {
                txtMameExe.Text = fileName;
                CalcMameFolders(fileName);
                DoLoadMameData = true;
            }
        }

        private void butCPanel_Click(object sender, EventArgs e)
        {
            string Folder = null;

            if (FileIO.TryOpenFolder(this, txtCPanel.Text, out Folder))
                txtCPanel.Text = Folder;
        }
    }
}