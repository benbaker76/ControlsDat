using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ControlsDat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Settings.Folders.App = Application.StartupPath;
            Settings.Folders.Data = Path.Combine(Settings.Folders.App, "Data");
            Settings.Folders.Temp = Path.GetTempPath();

            Settings.MameDiff.Folders.MameDiff = Path.Combine(Settings.Folders.App, "MameDiff");
            Settings.MameDiff.Files.MameDiffExe = Path.Combine(Settings.MameDiff.Folders.MameDiff, "mamediff.exe");
            Settings.MameDiff.Files.LogFile = Path.Combine(Settings.MameDiff.Folders.MameDiff, "mamediff.log");

            Settings.Files.LogFile = Path.Combine(Settings.Folders.App, "ControlsDat.log");
            Settings.Files.Ini = Path.Combine(Settings.Folders.App, "ControlsDat.ini");
            Settings.Files.ControlsDat = Path.Combine(Settings.Folders.Data, "controls.xml");
            Settings.Files.CatVer = Path.Combine(Settings.Folders.Data, "catver.ini");
            Settings.Files.ColorsIni = Path.Combine(Settings.Folders.Data, "colors.ini");
            Settings.Files.ListInfo = Path.Combine(Settings.Folders.Data, "ListInfo.xml");
            Settings.Files.MiniInfo = Path.Combine(Settings.Folders.Data, "MiniInfo.xml");
            Settings.Files.ControlsToLabels = Path.Combine(Settings.Folders.Data, "FEDEV_controls_to_labels.txt");
            Settings.Files.DescriptionsToControls = Path.Combine(Settings.Folders.Data, "FEDEV_descriptions_to_controls.txt");

            LogFile.FileName = Settings.Files.LogFile;
            LogFile.ClearLog();

            try
            {
                using (Global.MainForm = new frmMain())
                {
                    Global.MameManager = new MameManager();

                    ControlsData.ReadControlsToLabels(Settings.Files.ControlsToLabels);
                    ControlsData.ReadDescriptionsToControls(Settings.Files.DescriptionsToControls);

                    Application.Run(Global.MainForm);
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("Main", "Program", ex.Message, ex.StackTrace);
            }
        }
    }
}