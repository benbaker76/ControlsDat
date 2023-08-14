using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ControlsDat
{
    class Global
    {
        public static string Version = "1.2.3 BETA";

        public static frmMain MainForm = null;
        public static frmCPanel CPanelForm = null;

        public static MameManager MameManager = null;
        public static ControlsDat ControlsDat = null;
        public static CatVer CatVer = null;
        public static ColorsIni ColorsIni = null;
        public static MameXml MameXml = null;

        public static Color[] SwatchArray = new Color[]
	    {
		    Color.Black,
		    Color.White,
		    Color.Red,
		    Color.Yellow,
		    Color.Orange,
		    Color.Lime,
		    Color.Green,
		    Color.Cyan,
		    Color.Blue,
		    Color.Purple,
		    Color.Violet,
		    Color.Magenta,
		    Color.Brown
	    };
    }

    class Settings
    {
        public class General
        {
            public static bool FirstRun = false;
            public static string LastRomSelected = null;
            public static bool PromptToSave = false;
            public static string UserName = null;
        }

        public class Folders
        {
            public static string App = null;
            public static string Data = null;
            public static string Temp = null;
        }

        public class Files
        {
            public static string LogFile = null;
            public static string Ini = null;
            public static string ControlsDat = null;
            public static string CatVer = null;
            public static string ColorsIni = null;
            public static string ListInfo = null;
            public static string MiniInfo = null;
            public static string ControlsToLabels = null;
            public static string DescriptionsToControls = null;
        }

        public class Mame
        {
            public class Folders
            {
                public static string Root = null;
                public static string CPanel = null;
            }

            public class Files
            {
                public static string Exe = null;
            }

            public static string Version = null;
        }

        public class Filters
        {
            public static bool ShowAll = true;
            public static bool ControlsDat = false;
            public static bool Parents = false;
            public static bool Clones = false;
            public static bool Verified = false;
            public static bool UnVerified = false;
        }

        public class LastWriteTime
        {
            public static string Mame = null;
        }

        public class MameDiff
        {
            public class Folders
            {
                public static string MameDiff = null;
            }

            public class Files
            {
                public static string MameDiffExe = null;
                public static string MameExe1 = null;
                public static string MameExe2 = null;
                public static string LogFile = null;
            }

            public static bool Verbose = false;
            public static bool MergedSets = false;
            public static bool SplitSets = false;
            public static bool NonMergedSets = false;
        }
    }
}
