using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ControlsDat
{
    class ConfigIO
    {
        public static void LoadWindowPosition(Form form)
        {
            IniFile iniFile = new IniFile(Settings.Files.Ini);

            form.Size = Convert.StrToSize(iniFile.ReadStringDefault(form.Name, "Size", Convert.SizeToStr(form.Size)));
            form.Location = Convert.StrToPoint(iniFile.ReadStringDefault(form.Name, "Location", Convert.PointToStr(form.Location)));
            form.WindowState = (FormWindowState)iniFile.ReadIntegerDefault(form.Name, "WindowState", (int)form.WindowState);
        }

        public static void SaveWindowPosition(Form form)
        {
            IniFile iniFile = new IniFile(Settings.Files.Ini);

            iniFile.WriteString(form.Name, "WindowState", ((int)form.WindowState).ToString());

            if (form.WindowState == FormWindowState.Normal)
            {
                iniFile.WriteString(form.Name, "Size", Convert.SizeToStr(form.Size));
                iniFile.WriteString(form.Name, "Location", Convert.PointToStr(form.Location));
            }
            else
            {
                iniFile.WriteString(form.Name, "Size", Convert.SizeToStr(form.RestoreBounds.Size));
                iniFile.WriteString(form.Name, "Location", Convert.PointToStr(form.RestoreBounds.Location));
            }
        }

        public static string GetLastWriteTime(string FileName)
        {
            try
            {
                if (FileName == null)
                    return null;

                if (!File.Exists(FileName))
                    return null;

                DateTime LastWriteTime = File.GetLastWriteTime(FileName);

                if (LastWriteTime != null)
                    return LastWriteTime.ToString();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("GetLastWriteTime", "ConfigIO", ex.Message, ex.StackTrace);
            }

            return null;
        }

        public static void ReadConfig()
        {
            try
            {
                IniFile iniFile = new IniFile(Settings.Files.Ini);

                if (!File.Exists(Settings.Files.Ini))
                    Settings.General.FirstRun = true;

                Settings.General.UserName = iniFile.ReadStringDefault("General", "UserName", Environment.UserName);
                Settings.General.LastRomSelected = iniFile.ReadStringDefault("General", "LastRomSelected", "");

                Settings.Mame.Version = iniFile.ReadStringDefault("Mame", "Version", null);
                Settings.Mame.Files.Exe = iniFile.ReadStringDefault("Mame", "Exe", null);
                Settings.Mame.Folders.CPanel = iniFile.ReadStringDefault("MameFolders", "CPanel", null);

                Settings.Filters.ShowAll = iniFile.ReadBooleanDefault("Filters", "ShowAll", true);
                Settings.Filters.ControlsDat = iniFile.ReadBooleanDefault("Filters", "ControlsDat", false);
                Settings.Filters.Parents = iniFile.ReadBooleanDefault("Filters", "Parents", false);
                Settings.Filters.Clones = iniFile.ReadBooleanDefault("Filters", "Clones", false);
                Settings.Filters.Verified = iniFile.ReadBooleanDefault("Filters", "Verified", false);
                Settings.Filters.UnVerified = iniFile.ReadBooleanDefault("Filters", "UnVerified", false);

                Settings.MameDiff.Files.MameExe1 = iniFile.ReadStringDefault("MameDiff", "MameExe1", null);
                Settings.MameDiff.Files.MameExe2 = iniFile.ReadStringDefault("MameDiff", "MameExe2", null);
                Settings.MameDiff.Verbose = iniFile.ReadBooleanDefault("MameDiff", "Verbose", false);
                Settings.MameDiff.MergedSets = iniFile.ReadBooleanDefault("MameDiff", "MergedSets", false);
                Settings.MameDiff.SplitSets = iniFile.ReadBooleanDefault("MameDiff", "SplitSets", false);
                Settings.MameDiff.NonMergedSets = iniFile.ReadBooleanDefault("MameDiff", "NonMergedSets", false);

                Settings.LastWriteTime.Mame = iniFile.ReadStringDefault("LastWriteTime", "Mame", null);

                Settings.Files.ControlsDat = iniFile.ReadStringDefault("DataFiles", "ControlsDat", Settings.Files.ControlsDat);
                Settings.Files.ColorsIni = iniFile.ReadStringDefault("DataFiles", "ColorsIni", Settings.Files.ColorsIni);
                Settings.Files.MiniInfo = iniFile.ReadStringDefault("DataFiles", "MiniInfo", Settings.Files.MiniInfo);
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("ReadConfig", "ConfigIO", ex.Message, ex.StackTrace);
            }
        }

        public static void WriteConfig()
        {
            try
            {
                IniFile iniFile = new IniFile(Settings.Files.Ini);

                iniFile.WriteString("General", "UserName", Settings.General.UserName);
                iniFile.WriteString("General", "LastRomSelected", Settings.General.LastRomSelected);

                iniFile.WriteString("Mame", "Version", MameXml.GetMameVersion(Settings.Mame.Files.Exe));
                iniFile.WriteString("Mame", "Exe", Settings.Mame.Files.Exe);
                iniFile.WriteString("MameFolders", "CPanel", Settings.Mame.Folders.CPanel);

                iniFile.WriteBoolean("Filters", "ShowAll", Settings.Filters.ShowAll);
                iniFile.WriteBoolean("Filters", "ControlsDat", Settings.Filters.ControlsDat);
                iniFile.WriteBoolean("Filters", "Parents", Settings.Filters.Parents);
                iniFile.WriteBoolean("Filters", "Clones", Settings.Filters.Clones);
                iniFile.WriteBoolean("Filters", "Verified", Settings.Filters.Verified);
                iniFile.WriteBoolean("Filters", "UnVerified", Settings.Filters.UnVerified);

                iniFile.WriteString("MameDiff", "MameExe1", Settings.MameDiff.Files.MameExe1);
                iniFile.WriteString("MameDiff", "MameExe2", Settings.MameDiff.Files.MameExe2);
                iniFile.WriteBoolean("MameDiff", "Verbose", Settings.MameDiff.Verbose);
                iniFile.WriteBoolean("MameDiff", "MergedSets", Settings.MameDiff.MergedSets);
                iniFile.WriteBoolean("MameDiff", "SplitSets", Settings.MameDiff.SplitSets);
                iniFile.WriteBoolean("MameDiff", "NonMergedSets", Settings.MameDiff.NonMergedSets);

                iniFile.WriteString("LastWriteTime", "ControlsDat", GetLastWriteTime(Settings.Files.ControlsDat));
                iniFile.WriteString("LastWriteTime", "ColorsIni", GetLastWriteTime(Settings.Files.ColorsIni));
                iniFile.WriteString("LastWriteTime", "Mame", GetLastWriteTime(Settings.Mame.Files.Exe));
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("WriteConfig", "ConfigIO", ex.Message, ex.StackTrace);
            }
        }
    }
}
