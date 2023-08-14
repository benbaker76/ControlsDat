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
    public partial class frmMameDiff : Form
    {
        public frmMameDiff()
        {
            InitializeComponent();
        }

        private void frmMameDiff_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void frmMameDiff_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void GetData()
        {
            txtMame1Exe.Text = Settings.MameDiff.Files.MameExe1;
            txtMame2Exe.Text = Settings.MameDiff.Files.MameExe2;
            chkVerbose.Checked = Settings.MameDiff.Verbose;
            chkMergedSets.Checked = Settings.MameDiff.MergedSets;
            chkSplitSets.Checked = Settings.MameDiff.SplitSets;
            chkNonMergedSets.Checked = Settings.MameDiff.NonMergedSets;

            GetMame1Version();
            GetMame2Version();
        }

        private void SetData()
        {
            Settings.MameDiff.Files.MameExe1 = txtMame1Exe.Text;
            Settings.MameDiff.Files.MameExe2 = txtMame2Exe.Text;
            Settings.MameDiff.Verbose = chkVerbose.Checked;
            Settings.MameDiff.MergedSets = chkMergedSets.Checked;
            Settings.MameDiff.SplitSets = chkSplitSets.Checked;
            Settings.MameDiff.NonMergedSets = chkNonMergedSets.Checked;
        }

        private string CreateArguments()
        {
            string args = null;
            string xmlPath1 = Path.Combine(Settings.Folders.Data, "ListInfo1.xml");
            string xmlPath2 = Path.Combine(Settings.Folders.Data, "ListInfo2.xml");

            if (chkVerbose.Checked)
                args += "-v ";

            if (chkMergedSets.Checked)
                args += "-m ";

            if (chkSplitSets.Checked)
                args += "-s ";

            if (chkNonMergedSets.Checked)
                args += "-n ";

            args += String.Format("\"{0}\" ", xmlPath1);
            args += String.Format("\"{0}\"", xmlPath2);

            LogFile.WriteEntry(args);

            return args;
        }

        private void GetMameDiffOutput()
        {
            try
            {
                Process MameDiffProcess = new Process();

                MameDiffProcess.StartInfo.CreateNoWindow = true;
                MameDiffProcess.StartInfo.UseShellExecute = false;
                MameDiffProcess.StartInfo.RedirectStandardOutput = false;
                MameDiffProcess.StartInfo.WorkingDirectory = Settings.MameDiff.Folders.MameDiff;
                MameDiffProcess.StartInfo.FileName = Settings.MameDiff.Files.MameDiffExe;
                MameDiffProcess.StartInfo.Arguments = CreateArguments();
                MameDiffProcess.EnableRaisingEvents = true;
                MameDiffProcess.Exited += new EventHandler(MameDiffProcess_Exited);
                MameDiffProcess.Start();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("GetMameDiffOutput", "frmMameDiff", ex.Message, ex.StackTrace);
            }
        }

        void MameDiffProcess_Exited(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", Settings.MameDiff.Files.LogFile);
        }

        private void GetMame1Version()
        {
            if (!String.IsNullOrEmpty(txtMame1Exe.Text))
            {
                string Version = MameXml.GetMameVersion(txtMame1Exe.Text);

                grpMame1.Text = String.Format("Mame 1 ({0})", Version);
            }
        }

        private void GetMame2Version()
        {
            if (!String.IsNullOrEmpty(txtMame2Exe.Text))
            {
                string Version = MameXml.GetMameVersion(txtMame2Exe.Text);

                grpMame2.Text = String.Format("Mame 2 ({0})", Version);
            }
        }

        private void GetMameDiff(string fileName1, string fileName2)
        {
            string xmlPath1 = Path.Combine(Settings.Folders.Data, "ListInfo1.xml");
            string xmlPath2 = Path.Combine(Settings.Folders.Data, "ListInfo2.xml");

            using (frmInfo loadingForm = new frmInfo(this, "Loading Please Wait...", false, false))
            {
                loadingForm.Show();
                MameXml.CreateListInfoXml(fileName1, xmlPath1);
                MameXml.CreateListInfoXml(fileName2, xmlPath2);
                GetMameDiffOutput();
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            SetData();

            if(!String.IsNullOrEmpty(txtMame1Exe.Text) && !String.IsNullOrEmpty(txtMame2Exe.Text))
                GetMameDiff(txtMame1Exe.Text, txtMame2Exe.Text);

            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butMame1Exe_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, FileIO.GetPath(txtMame1Exe.Text), FileIO.GetFile(txtMame1Exe.Text), ".exe", out fileName))
            {
                txtMame1Exe.Text = fileName;
                GetMame1Version();
            }
        }

        private void butMame2Exe_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, FileIO.GetPath(txtMame2Exe.Text), FileIO.GetFile(txtMame2Exe.Text), ".exe", out fileName))
            {
                txtMame2Exe.Text = fileName;
                GetMame2Version();
            }
        }
    }
}