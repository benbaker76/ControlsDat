using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ControlsDat
{
    class MameManager
    {
        public void LoadMameData()
        {
            try
            {
                LogFile.WriteEntry("Reading Mame Data");

                if (File.Exists(Settings.Mame.Files.Exe))
                {
                    if (Global.MameXml != null)
                    {
                        Global.MameXml.Dispose();
                        Global.MameXml = null;
                    }

                    Global.MameXml = new MameXml();

                    Settings.Mame.Folders.Root = Path.GetDirectoryName(Settings.Mame.Files.Exe);

                    if (Settings.LastWriteTime.Mame != ConfigIO.GetLastWriteTime(Settings.Mame.Files.Exe) ||
                    Settings.Mame.Version != MameXml.GetMameVersion(Settings.Mame.Files.Exe) ||
                    !File.Exists(Settings.Files.MiniInfo))
                    {
                        Settings.Mame.Version = MameXml.GetMameVersion(Settings.Mame.Files.Exe);

                        if (File.Exists(Settings.Files.ListInfo))
                            File.Delete(Settings.Files.ListInfo);

                        CreateMiniInfo();
                    }
                    else
                    {
                        LogFile.WriteEntry("Reading MiniInfo Xml");
                        Global.MameXml.ReadListInfoXml(Settings.Mame.Files.Exe, Settings.Files.MiniInfo);
                    }

                    LogFile.WriteEntry("Mame Version " + Settings.Mame.Version);

                    LogFile.WriteEntry("Reading Controls Xml");
                    Global.ControlsDat = new ControlsDat();
                    Global.ControlsDat.ReadControlsXml(Settings.Files.ControlsDat);

                    LogFile.WriteEntry("Reading CatVer Ini");
                    Global.CatVer = new CatVer();
                    Global.CatVer.ReadCatVerIni(Settings.Files.CatVer);

                    //LogFile.WriteEntry("Reading Colors Ini");
                    //Global.ColorsIni = new ColorsIni();
                    //Global.ColorsIni.ReadColorsIni(Settings.Files.ColorsIni);

                    //LogFile.WriteEntry("Adding Colors to ControlsDat");
                    //Global.ControlsDat.AddColorsIni(Global.ColorsIni);

                    LogFile.WriteEntry("Adding Data to Mame Xml");
                    Global.MameXml.AddData();

                    LogFile.WriteEntry("Getting Parent Roms");
                    Global.MameManager.GetParentROMs();
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("LoadMameData", "MameManager", ex.Message, ex.StackTrace);
            }
        }

        public void CreateMiniInfo()
        {
            try
            {
                LogFile.WriteEntry("Reading ListInfo Xml");
                Global.MameXml.ReadListInfoXml(Settings.Mame.Files.Exe, Settings.Files.ListInfo);

                LogFile.WriteEntry("Writing MiniInfo Xml");
                Global.MameXml.WriteMiniInfoXml(Settings.Files.MiniInfo);
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("CreateMiniInfo", "MameManager", ex.Message, ex.StackTrace);
            }
        }

        private MameXml.GameNode GetParentROM(MameXml.GameNode game)
        {
            if (game.IsParent())
                return null;

            MameXml.GameNode parentGameInfo = game;

            try
            {
                do
                {
                    if (parentGameInfo.CloneOf != null) // Game has a clone?
                        Global.MameXml.GameHash.TryGetValue(parentGameInfo.CloneOf, out parentGameInfo);

                    if (parentGameInfo.RomOf != null)
                        Global.MameXml.GameHash.TryGetValue(parentGameInfo.RomOf, out parentGameInfo);
                }
                while (parentGameInfo.RomOf != null);
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("GetParentROM", "MameManager", ex.Message, ex.StackTrace);
            }

            return parentGameInfo;
        }

        public void GetParentROMs()
        {
            try
            {
                for (int i = 0; i < Global.MameXml.GameArray.Count; i++)
                {
                    MameXml.GameNode GameNode = Global.MameXml.GameArray[i];
                    GameNode.Parent = GetParentROM(GameNode);
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("GetParentROMs", "MameManager", ex.Message, ex.StackTrace);
            }
        }

        public void LaunchGame(System.Windows.Forms.Control parent, MameXml.GameNode gameNode)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.WorkingDirectory = Settings.Mame.Folders.Root;
                process.StartInfo.FileName = Settings.Mame.Files.Exe;
                process.StartInfo.Arguments = gameNode.Name;
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.SynchronizingObject = parent;
                process.Exited += new System.EventHandler(MameExited);

                process.Start();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("LaunchGame", "MameManager", ex.Message, ex.StackTrace);
            }
        }

        private void MameExited(object sender, EventArgs e)
        {
            Global.MainForm.Activate();
        }
    }
}
