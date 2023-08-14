using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ControlsDat
{
    partial class Win32
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            [In] ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll")]
        public static extern bool CreateProcess(string lpApplicationName,
            string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes,
            ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles,
            uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        public static extern Int32 WaitForSingleObject(IntPtr handle, uint milliseconds);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwYSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        public static uint INFINITE = 0xFFFFFFFF;
        public static int WAIT_OBJECT_0 = 0;

        public const Int32 CREATE_NO_WINDOW = 0x08000000;
        public const Int32 NORMAL_PRIORITY_CLASS = 0x0020;
        public const Int32 STARTF_USESTDHANDLES = 0x00000100;
        public const Int32 STARTF_USESHOWWINDOW = 0x00000001;

        public const uint CREATE_ALWAYS = 0x0002;
        public const int STD_OUTPUT_HANDLE = -11;

        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
    }

    public class MameXml : IDisposable
    {
        public class GameNode : IComparable<GameNode>
        {
            public string Name = null;
            public string SourceFile = null;
            public string CloneOf = null;
            public string RomOf = null;
            public GameNode Parent = null;
            public string Description = null;
            public string Year = null;
            public string Manufacturer = null;
            //public DriverNode Driver = null;
            //public List<DisplayNode> DisplayArray = null;
            //public List<ChipNode> ChipArray = null;
            public List<InputNode> InputArray = null;
            public List<DipSwitchNode> DipSwitchArray = null;
            public ControlsDat.GameNode ControlsDat = null;
            public CatVer.CatVerNode CatVer = null;

            public GameNode(string name, string sourcefile, string cloneOf, string romOf)
            {
                Name = name;
                SourceFile = sourcefile;
                CloneOf = cloneOf;
                RomOf = romOf;
                //DisplayArray = new List<DisplayNode>();
                //ChipArray = new List<ChipNode>();
                InputArray = new List<InputNode>();
                DipSwitchArray = new List<DipSwitchNode>();
            }

            public bool HasControlsDat()
            {
                return (ControlsDat != null);
            }

            public bool IsClone()
            {
                return (CloneOf != null || RomOf != null);
            }

            public bool IsParent()
            {
                return (CloneOf == null && RomOf == null);
            }

            public bool IsVerified()
            {
                if (HasControlsDat())
                    return (ControlsDat.Verified == 1);
                else
                    return false;
            }

            public string GetNameString()
            {
                string retString = String.Empty;

                if (Name != null)
                    retString = Name;

                return retString;
            }

            public string GetSourceFileString()
            {
                string retString = String.Empty;

                if (SourceFile != null)
                    retString = SourceFile;

                return retString;
            }

            public string GetCloneOfString()
            {
                string retString = String.Empty;

                if (CloneOf != null)
                    retString = CloneOf;

                return retString;
            }

            public string GetRomOfString()
            {
                string retString = String.Empty;

                if (RomOf != null)
                    retString = RomOf;

                return retString;
            }

            public string GetDescriptionString()
            {
                string retString = String.Empty;

                if (Description != null)
                    retString = Description;

                return retString;
            }

            public string GetParentString()
            {
                string retString = String.Empty;

                if (Parent != null)
                    retString = Parent.Name;

                return retString;
            }

            private string GetConstantsStr()
            {
                string retString = String.Empty;

                foreach (InputNode inputNode in InputArray)
                {
                    foreach (ControlNode controlNode in inputNode.ControlArray)
                        retString += controlNode.Constant + " ";
                }

                return retString;
            }

            public string GetConstantsString()
            {
                string retString = String.Empty;

                if (ControlsDat != null)
                    return ControlsDat.GetConstantsString();
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        return Parent.ControlsDat.GetConstantsString();
                    else
                        return GetConstantsStr();
                }
                else
                    GetConstantsStr();

                return retString.Trim();
            }

            public string GetControlsString()
            {
                string retString = String.Empty;

                if (ControlsDat != null)
                    return ControlsDat.GetControlsString();
                else
                {
                    if (Parent != null)
                    {
                        if (Parent.ControlsDat != null)
                            return Parent.ControlsDat.GetControlsString();
                    }
                }

                return retString.Trim();
            }

            public string GetNumPlayersString()
            {
                string retString = String.Empty;

                if (InputArray.Count > 0)
                    retString = InputArray[0].Players.ToString();

                if (ControlsDat != null)
                    retString = ControlsDat.NumPlayers.ToString();
                else if (Parent != null)
                {
                    if(Parent.ControlsDat != null)
                        retString = Parent.ControlsDat.NumPlayers.ToString();
                }

                return retString;
            }

            public string GetNumButtonsString()
            {
                string retString = String.Empty;

                if (InputArray.Count > 0)
                    retString = InputArray[0].Buttons.ToString();

                if (ControlsDat != null)
                    retString = ControlsDat.PlayerArray[0].NumButtons.ToString();
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        retString = Parent.ControlsDat.PlayerArray[0].NumButtons.ToString();
                }

                return retString;
            }

            public string GetAlternatingString()
            {
                string retString = String.Empty;

                if (ControlsDat != null)
                    retString = (ControlsDat.Alternating == 1 ? "Yes" : "No");
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        retString = (Parent.ControlsDat.Alternating == 1 ? "Yes" : "No");
                }

                return retString;
            }

            public string GetMirroredString()
            {
                string retString = String.Empty;

                if (ControlsDat != null)
                    retString = (ControlsDat.Mirrored == 1 ? "Yes" : "No");
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        retString = (Parent.ControlsDat.Mirrored == 1 ? "Yes" : "No");
                }

                return retString;
            }

            public string GetUsesServiceString()
            {
                string retString = String.Empty;

                if(InputArray.Count > 0)
                    retString = (InputArray[0].Service ? "Yes" : "No");

                if (ControlsDat != null)
                    retString = (ControlsDat.UsesService == 1 ? "Yes" : "No");
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        retString = (Parent.ControlsDat.UsesService == 1 ? "Yes" : "No");
                }

                return retString;
            }

            public string GetTiltString()
            {
                string retString = String.Empty;

                if (ControlsDat != null)
                    retString = (ControlsDat.Tilt == 1 ? "Yes" : "No");
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        retString = (Parent.ControlsDat.Tilt == 1 ? "Yes" : "No");
                }

                return retString;
            }

            public string GetCocktailString()
            {
                string retString = String.Empty;

                if (ControlsDat != null)
                    retString = (ControlsDat.Cocktail == 1 ? "Yes" : "No");
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        retString = (Parent.ControlsDat.Cocktail == 1 ? "Yes" : "No");
                }

                return retString;
            }

            public string GetMiscDetailsString()
            {
                string retString = String.Empty;

                if (ControlsDat != null)
                    retString = ControlsDat.MiscDetails;
                else if (Parent != null)
                {
                    if (Parent.ControlsDat != null)
                        retString = Parent.ControlsDat.MiscDetails;
                }

                return retString;
            }

            public int CompareTo(GameNode other)
            {
                switch (SortMode)
                {
                    case ColumnType.ControlsDat:
                        return this.HasControlsDat().CompareTo(other.HasControlsDat());
                    case ColumnType.Description:
                        return this.GetDescriptionString().CompareTo(other.GetDescriptionString());
                    case ColumnType.Name:
                        return this.GetNameString().CompareTo(other.GetNameString());
                    case ColumnType.SourceFile:
                        return this.GetSourceFileString().CompareTo(other.GetSourceFileString());
                    case ColumnType.CloneOf:
                        return this.GetCloneOfString().CompareTo(other.GetCloneOfString());
                    case ColumnType.RomOf:
                        return this.GetRomOfString().CompareTo(other.GetRomOfString());
                    case ColumnType.Parent:
                        return this.GetParentString().CompareTo(other.GetParentString());
                    case ColumnType.Constants:
                        return this.GetConstantsString().CompareTo(other.GetConstantsString());
                    case ColumnType.Controls:
                        return this.GetControlsString().CompareTo(other.GetControlsString());
                    case ColumnType.NumPlayers:
                        return this.GetNumPlayersString().CompareTo(other.GetNumPlayersString());
                    case ColumnType.NumButtons:
                        return this.GetNumButtonsString().CompareTo(other.GetNumButtonsString());
                    case ColumnType.Alternating:
                        return this.GetAlternatingString().CompareTo(other.GetAlternatingString());
                    case ColumnType.Mirrored:
                        return this.GetMirroredString().CompareTo(other.GetMirroredString());
                    case ColumnType.UsesService:
                        return this.GetUsesServiceString().CompareTo(other.GetUsesServiceString());
                    case ColumnType.Tilt:
                        return this.GetTiltString().CompareTo(other.GetTiltString());
                    case ColumnType.Cocktail:
                        return this.GetCocktailString().CompareTo(other.GetCocktailString());
                    case ColumnType.MiscDetails:
                        return this.GetMiscDetailsString().CompareTo(other.GetMiscDetailsString());
                    default:
                        return this.Description.CompareTo(other.Description);
                }
            }
        }

        public class DriverNode
        {
            public string Status = null;
            public string Emulation = null;
            public string Color = null;
            public string Sound = null;
            public string Graphic = null;
            public string SaveState = null;
            public int PaletteSize;

            public DriverNode(string status, string emulation, string color, string sound, string graphic, string savestate, int palettesize)
            {
                Status = status;
                Emulation = emulation;
                Color = color;
                Sound = sound;
                Graphic = graphic;
                SaveState = savestate;
                PaletteSize = palettesize;
            }
        }

        public class DisplayNode
        {
            public string Type = null;
            public int Rotate = 0;
            public int Width = 0;
            public int Height = 0;
            public float Refresh = 0;

            public DisplayNode(string type, int rotate, int width, int height, float refresh)
            {
                Type = type;
                Rotate = rotate;
                Width = width;
                Height = height;
                Refresh = refresh;
            }
        }

        public class ChipNode
        {
            public string Type = null;
            public string Name = null;
            public string Clock = null;

            public ChipNode(string type, string name, string clock)
            {
                Type = type;
                Name = name;
                Clock = clock;
            }
        }

        public class InputNode
        {
            public int Players = 0;
            public int Buttons = 0;
            public int Coins = 0;
            public bool Service = false;
            public bool Tilt = false;
            public List<ControlNode> ControlArray = null;

            public InputNode(int players, int buttons, int coins, bool service, bool tilt)
            {
                Players = players;
                Buttons = buttons;
                Coins = coins;
                Service = service;
                Tilt = tilt;
                ControlArray = new List<ControlNode>();
            }
        }

        public class ControlNode
        {
            public string Type = null;
            public string Ways = null;
            public string Ways2 = null;
            public string Ways3 = null;
            public int Minimum = 0;
            public int Maximum = 0;
            public int Sensitivity = 0;
            public int KeyDelta = 0;
            public bool Reverse = false;

            public ControlNode(string type, string ways, string ways2, string ways3, int minimum, int maximum, int sensitivity, int keyDelta, bool reverse)
            {
                Type = type;
                Ways = ways;
                Ways2 = ways2;
                Ways3 = ways3;
                Minimum = minimum;
                Maximum = maximum;
                Sensitivity = sensitivity;
                KeyDelta = keyDelta;
                Reverse = reverse;
            }

            public static string GetControlConstant(string type, string ways, string ways2, string ways3)
            {
                if (type.EndsWith("joy"))
                {
                    string vertical = String.Empty;

                    if (ways.Equals("3 (half4)"))
                        ways = "4";
                    else if (ways.Equals("5 (half8)"))
                        ways = "8";
                    else if (ways.Equals("vertical2"))
                    { ways = "2"; vertical = "v"; }

                    return String.Format("{0}{1}{2}way", vertical, type, ways);
                }

                return type;
            }

            public string Constant
            {
                get { return GetControlConstant(Type, Ways, Ways2, Ways3); }
            }
        }

        public class DipSwitchNode
        {
            public string Name = null;
            public List<DipValueNode> DipValueArray = null;

            public DipSwitchNode(string name)
            {
                Name = name;
                DipValueArray = new List<DipValueNode>();
            }
        }

        public class DipValueNode
        {
            public string Name = null;
            public string Default = null;
            
            public DipValueNode(string name, string defaultValue)
            {
                Name = name;
                Default = defaultValue;
            }
        }

        public enum ColumnType
        {
            ControlsDat,
            Description,
            Name,
            SourceFile,
            CloneOf,
            RomOf,
            Parent,
            Constants,
            Controls,
            NumPlayers,
            NumButtons,
            Alternating,
            Mirrored,
            UsesService,
            Tilt,
            Cocktail,
            MiscDetails
        }

        private enum xmlElement
        {
            Nothing,
            Game,
            Description,
            Year,
            Manufacturer,
            Chip,
            Display,
            Input,
            DipSwitch,
            DipValue,
            Control,
            Driver,
            CatVer,
            NPlayers,
            HallOfFame
        }

        private IntPtr hProcess = IntPtr.Zero;

        public List<GameNode> GameArray = null;
        public Dictionary<string, GameNode> GameHash = null;

        public static ColumnType SortMode = ColumnType.Description;

        public MameXml()
        {
            GameArray = new List<GameNode>();
            GameHash = new Dictionary<string, GameNode>();
        }

        public static void CreateListInfoXml(string MamePath, string XmlPath)
        {
            try
            {
                bool retValue;
                string Application = MamePath;
                string CommandLine = " -listxml";
                Win32.PROCESS_INFORMATION pi = new Win32.PROCESS_INFORMATION();
                Win32.STARTUPINFO si = new Win32.STARTUPINFO();
                Win32.SECURITY_ATTRIBUTES sa = new Win32.SECURITY_ATTRIBUTES();
                sa.nLength = Marshal.SizeOf(sa);
                sa.bInheritHandle = 1;
                sa.lpSecurityDescriptor = IntPtr.Zero;

                string sTempFile = XmlPath;
                IntPtr hFile = Win32.CreateFile(sTempFile, Win32.GENERIC_READ | Win32.GENERIC_WRITE, 0, ref sa, Win32.CREATE_ALWAYS, 0, IntPtr.Zero);

                si.cb = Marshal.SizeOf(si);
                si.hStdOutput = hFile;
                si.dwFlags = Win32.STARTF_USESTDHANDLES;

                retValue = Win32.CreateProcess(Application, CommandLine, ref sa, ref sa, true, Win32.NORMAL_PRIORITY_CLASS | Win32.CREATE_NO_WINDOW, IntPtr.Zero, null, ref si, out pi);

                //WaitForSingleObject(pi.hProcess, INFINITE);

                if (retValue)
                {
                    while (Win32.WaitForSingleObject(pi.hProcess, 100) != Win32.WAIT_OBJECT_0)
                        System.Windows.Forms.Application.DoEvents();
                }

                Win32.CloseHandle(hFile);
                Win32.CloseHandle(pi.hProcess);
                Win32.CloseHandle(pi.hThread);
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("CreateListInfoXml", "MameXml", ex.Message, ex.StackTrace);
            }
        }

        public static string GetMameOutput(string MamePath, string Arguments)
        {
            string Output = null;

            if (!File.Exists(MamePath))
                return null;

            try
            {
                Process MameProcess = new Process();

                MameProcess.StartInfo.CreateNoWindow = true;
                MameProcess.StartInfo.UseShellExecute = false;
                MameProcess.StartInfo.RedirectStandardOutput = true;
                MameProcess.StartInfo.FileName = MamePath;
                MameProcess.StartInfo.Arguments = Arguments;
                MameProcess.Start();
                Output = MameProcess.StandardOutput.ReadToEnd();
                MameProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("GetMameOutput", "MameXml", ex.Message, ex.StackTrace);
            }

            return Output;
        }

        public static string GetMameVersion(string MamePath)
        {
            string Output = null;
            try
            {
                Output = GetMameOutput(MamePath, "-help");

                if (Output == null)
                    return null;

                Output = Output.Substring(Output.IndexOf("v"));
                Output = Output.Substring(1, Output.IndexOf(" ") - 1);
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("GetMameVersion", "MameXml", ex.Message, ex.StackTrace);
            }

            return Output;
        }

        public static Stream GetMameROMInfoXml(string MamePath, string ROMName)
        {
            try
            {
                string Output = GetMameOutput(MamePath, "-listxml " + ROMName);

                if (Output == null)
                    return Stream.Null;

                MemoryStream retStream = new MemoryStream(Convert.StrToByteArray(Output));

                return retStream;
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("GetMameROMInfoXml", "MameXml", ex.Message, ex.StackTrace);
            }

            return Stream.Null;
        }

        public static string GetMameROMClones(string MamePath, string ROMName)
        {
            return GetMameOutput(MamePath, ROMName + " -listclones");
        }

        public static string GetMameROMDescription(string MamePath, string ROMName)
        {
            return GetMameOutput(MamePath, ROMName + " -ll");
        }

        public static string GetMameROMDriver(string MamePath, string ROMName)
        {
            return GetMameOutput(MamePath, ROMName + " -ls");
        }

        public void AddData()
        {
            foreach (GameNode gameNode in GameArray)
            {
                ControlsDat.GameNode game = null;
                CatVer.CatVerNode catVer = null;

                if (Global.ControlsDat.GameHash.TryGetValue(gameNode.Name, out game))
                    gameNode.ControlsDat = game;

                if (Global.CatVer.GameHash.TryGetValue(gameNode.Name, out catVer))
                    gameNode.CatVer = catVer;
            }
        }

        /* private void GetListInfoXmlVersion(string XmlPath)
        {
            XmlTextReader reader = null;
            Dictionary<string, string> attribHash = new Dictionary<string, string>();
            XmlDocument doc = new XmlDocument();

            if (!File.Exists(XmlPath))
                return;

            try
            {
                reader = new XmlTextReader(XmlPath);

                doc.Load(XmlPath);

                XmlNode XmlNode = doc.DocumentElement.SelectSingleNode("mame");

                attribHash.Clear();

                foreach (XmlNode xmlNode in XmlNode.Attributes)
                    attribHash.Add(xmlNode.Name.ToLower(), xmlNode.Value);

                System.Windows.Forms.MessageBox.Show(attribHash["build"]);

                reader.Close();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("FindROMData", "MameXml", ex.Message, ex.StackTrace);
            }
        } */

        private void FindROMData(ref XmlTextReader reader, ref XmlTextWriter writer, ref MemoryStream ms, string XmlPath, string ROMName)
        {
            Dictionary<string, string> attribHash = new Dictionary<string, string>();
            XmlDocument doc = new XmlDocument();
            ms = new MemoryStream();

            try
            {
                doc.Load(XmlPath);

                writer = new XmlTextWriter(ms, System.Text.Encoding.Default);

                writer.WriteStartDocument();
                writer.WriteStartElement("Games");

                XmlNode XmlNode = doc.DocumentElement.SelectSingleNode(string.Format("Game[@Name='{0}']", ROMName));

                if (XmlNode != null)
                {
                    XmlNode.WriteTo(writer);

                    foreach (XmlNode xmlNode in XmlNode.Attributes)
                        attribHash.Add(xmlNode.Name.ToLower(), xmlNode.Value);
                }

                string ParentName = null;

                do
                {
                    if (attribHash.TryGetValue("cloneof", out ParentName))
                    {
                        XmlNode = doc.DocumentElement.SelectSingleNode(string.Format("Game[@Name='{0}']", ParentName));

                        if (XmlNode != null)
                            XmlNode.WriteTo(writer);

                        attribHash.Clear();

                        foreach (XmlNode xmlNode in XmlNode.Attributes)
                            attribHash.Add(xmlNode.Name.ToLower(), xmlNode.Value);
                    }

                    if (attribHash.TryGetValue("romof", out ParentName))
                    {
                        XmlNode = doc.DocumentElement.SelectSingleNode(string.Format("Game[@Name='{0}']", ParentName));

                        if (XmlNode != null)
                            XmlNode.WriteTo(writer);

                        attribHash.Clear();

                        foreach (XmlNode xmlNode in XmlNode.Attributes)
                            attribHash.Add(xmlNode.Name.ToLower(), xmlNode.Value);
                    }
                }
                while (attribHash.TryGetValue("romof", out ParentName));

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                reader.Close();
                ms.Position = 0;
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("FindROMData", "MameXml", ex.Message, ex.StackTrace);
            }
        }

        public void ReadListInfoXml(string MamePath, string XmlPath)
        {
            ReadListInfoXml(MamePath, XmlPath, null);
        }

        public void ReadListInfoXml(string MamePath, string XmlPath, string ROMName)
        {
            xmlElement CurrentElement = xmlElement.Nothing;
            Hashtable AttribHash = new Hashtable();

            GameNode CurrentGame = null;
            DisplayNode CurrentDisplay = null;
            InputNode CurrentInput = null;
            DipSwitchNode CurrentDipSwitch = null;
            ControlNode CurrentControl = null;

            XmlTextReader reader = null;
            XmlTextWriter writer = null;
            MemoryStream ms = null;

            GameArray.Clear();
            GameHash.Clear();

            //GetListInfoXmlVersion(XmlPath);

            if (!File.Exists(XmlPath))
                CreateListInfoXml(MamePath, XmlPath);

            try
            {
                reader = new XmlTextReader(XmlPath);

                if (ROMName != null)
                {
                    FindROMData(ref reader, ref writer, ref ms, XmlPath, ROMName);
                    reader = new XmlTextReader(ms);
                }

                reader.Read();

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (reader.LocalName.ToLower())
                            {
                                case "game":
                                    CurrentElement = xmlElement.Game;
                                    break;
                                case "description":
                                    CurrentElement = xmlElement.Description;
                                    break;
                                case "year":
                                    CurrentElement = xmlElement.Year;
                                    break;
                                case "manufacturer":
                                    CurrentElement = xmlElement.Manufacturer;
                                    break;
                                case "chip":
                                    CurrentElement = xmlElement.Chip;
                                    break;
                                case "display":
                                    CurrentElement = xmlElement.Display;
                                    break;
                                case "input":
                                    CurrentElement = xmlElement.Input;
                                    break;
                                case "dipswitch":
                                    CurrentElement = xmlElement.DipSwitch;
                                    break;
                                case "dipvalue":
                                    CurrentElement = xmlElement.DipValue;
                                    break;
                                case "control":
                                    CurrentElement = xmlElement.Control;
                                    break;
                                case "driver":
                                    CurrentElement = xmlElement.Driver;
                                    break;
                                case "catver":
                                    CurrentElement = xmlElement.CatVer;
                                    break;
                                case "nplayers":
                                    CurrentElement = xmlElement.NPlayers;
                                    break;
                                case "halloffame":
                                    CurrentElement = xmlElement.HallOfFame;
                                    break;
                                default:
                                    CurrentElement = xmlElement.Nothing;
                                    break;
                            }
                            if (reader.HasAttributes)
                            {
                                AttribHash.Clear();
                                while (reader.MoveToNextAttribute())
                                    AttribHash.Add(reader.Name.ToLower(), reader.Value);
                            }
                            switch (CurrentElement)
                            {
                                case xmlElement.Game:
                                    string Name = (string)AttribHash["name"];
                                    GameArray.Add(CurrentGame = new GameNode(Name, (string)AttribHash["sourcefile"], (string)AttribHash["cloneof"], (string)AttribHash["romof"]));
                                    if (!GameHash.ContainsKey(Name))
                                        GameHash.Add(Name, CurrentGame);
                                    break;
                                /* case xmlElement.Display:
                                    if (CurrentGame != null)
                                        CurrentGame.DisplayArray.Add(CurrentDisplay = new DisplayNode((string)AttribHash["type"], Convert.StrToInt((string)AttribHash["rotate"]), Convert.StrToInt((string)AttribHash["width"]), Convert.StrToInt((string)AttribHash["height"]), Convert.StrToSingle((string)AttribHash["refresh"])));
                                    break;
                                case xmlElement.Chip:
                                    if (CurrentGame != null)
                                        CurrentGame.ChipArray.Add(new ChipNode((string)AttribHash["type"], (string)AttribHash["name"], (string)AttribHash["clock"]));
                                    break; */
                                case xmlElement.Input:
                                    if (CurrentGame != null)
                                        CurrentGame.InputArray.Add(CurrentInput = new InputNode(Convert.StrToInt((string)AttribHash["players"]), Convert.StrToInt((string)AttribHash["buttons"]), Convert.StrToInt((string)AttribHash["coins"]), Convert.StrToBool((string)AttribHash["service"]), Convert.StrToBool((string)AttribHash["tilt"])));
                                    break;
                                case xmlElement.DipSwitch:
                                    if (CurrentGame != null)
                                        CurrentGame.DipSwitchArray.Add(CurrentDipSwitch = new DipSwitchNode((string)AttribHash["name"]));
                                    break;
                                case xmlElement.DipValue:
                                    if (CurrentDipSwitch != null)
                                        CurrentDipSwitch.DipValueArray.Add(new DipValueNode((string)AttribHash["name"],(string)AttribHash["default"]));
                                    break;
                                case xmlElement.Control:
                                    if (CurrentInput != null)
                                        CurrentInput.ControlArray.Add(CurrentControl = new ControlNode((string)AttribHash["type"], (string)AttribHash["ways"], (string)AttribHash["ways2"], (string)AttribHash["ways3"], Convert.StrToInt((string)AttribHash["minimum"]), Convert.StrToInt((string)AttribHash["maximum"]), Convert.StrToInt((string)AttribHash["sensitivity"]), Convert.StrToInt((string)AttribHash["keydelta"]), Convert.StrToBool((string)AttribHash["reverse"])));
                                    break;
                                /* case xmlElement.Driver:
                                    if (CurrentGame != null)
                                        CurrentGame.Driver = new DriverNode((string)AttribHash["status"], (string)AttribHash["emulation"], (string)AttribHash["color"], (string)AttribHash["sound"], (string)AttribHash["graphic"], (string)AttribHash["savestate"], Convert.StrToInt((string)AttribHash["palettesize"]));
                                    break; */
                                default:
                                    break;
                            }
                            reader.MoveToElement();
                            break;

                        case XmlNodeType.Text:
                            string Text = reader.Value.Trim();
                            switch (CurrentElement)
                            {
                                case xmlElement.Description:
                                    if (CurrentGame != null)
                                        CurrentGame.Description = Text;
                                    break;
                                case xmlElement.Year:
                                    if (CurrentGame != null)
                                        CurrentGame.Year = Text;
                                    break;
                                case xmlElement.Manufacturer:
                                    if (CurrentGame != null)
                                        CurrentGame.Manufacturer = Text;
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            switch (CurrentElement)
                            {
                                case xmlElement.Game:
                                    CurrentGame = null;
                                    break;
                                case xmlElement.Display:
                                    CurrentDisplay = null;
                                    break;
                                case xmlElement.Input:
                                    CurrentInput = null;
                                    break;
                                case xmlElement.Control:
                                    CurrentControl = null;
                                    break;
                                default:
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("ReadListInfoXml", "MameXml", ex.Message, ex.StackTrace);
            }

            if (reader != null)
            {
                reader.Close();
                reader = null;
            }
            if (writer != null)
            {
                writer.Close();
                writer = null;
            }
            if (ms != null)
            {
                ms.Close();
                ms.Dispose();
                ms = null;
            }
        }

        public void WriteMiniInfoXml(string fileName)
        {
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter(fileName, null);

                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();
                writer.WriteStartElement("Mame");

                foreach (GameNode game in GameArray)
                {
                    writer.WriteStartElement("Game");
                    writer.WriteAttributeString("Name", game.Name);

                    if (game.SourceFile != null)
                        writer.WriteAttributeString("SourceFile", game.SourceFile);

                    if (game.CloneOf != null)
                        writer.WriteAttributeString("CloneOf", game.CloneOf);

                    if (game.RomOf != null)
                        writer.WriteAttributeString("RomOf", game.RomOf);

                    writer.WriteStartElement("Description");
                    writer.WriteString(game.Description);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Year");
                    writer.WriteString(game.Year);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Manufacturer");
                    writer.WriteString(game.Manufacturer);
                    writer.WriteEndElement();

                    /* foreach (DisplayNode display in game.Displays)
                    {
                        writer.WriteStartElement("Display");
                        writer.WriteAttributeString("Type", display.Type);
                        writer.WriteAttributeString("Rotate", display.Rotate.ToString());
                        writer.WriteAttributeString("Width", display.Width.ToString());
                        writer.WriteAttributeString("Height", display.Height.ToString());
                        writer.WriteAttributeString("Refresh", display.Refresh.ToString());
                        writer.WriteEndElement();
                    }

                    foreach (ChipNode chip in game.Chips)
                    {
                        writer.WriteStartElement("Chip");
                        writer.WriteAttributeString("Type", chip.Type);
                        writer.WriteAttributeString("Name", chip.Name);
                        writer.WriteAttributeString("Clock", chip.Clock);
                        writer.WriteEndElement();
                    } */

                    foreach (InputNode input in game.InputArray)
                    {
                        writer.WriteStartElement("Input");
                        writer.WriteAttributeString("Players", input.Players.ToString());
                        writer.WriteAttributeString("Buttons", input.Buttons.ToString());
                        writer.WriteAttributeString("Coins", input.Coins.ToString());
                        writer.WriteAttributeString("Service", input.Service.ToString());
                        writer.WriteAttributeString("Tilt", input.Tilt.ToString());

                        foreach (ControlNode control in input.ControlArray)
                        {
                            writer.WriteStartElement("Control");
                            writer.WriteAttributeString("Type", control.Type);
                            writer.WriteAttributeString("Ways", control.Ways);
                            writer.WriteAttributeString("Ways2", control.Ways2);
                            writer.WriteAttributeString("Ways3", control.Ways3);
                            writer.WriteAttributeString("Minimum", control.Minimum.ToString());
                            writer.WriteAttributeString("Maximum", control.Maximum.ToString());
                            writer.WriteAttributeString("Sensitivity", control.Sensitivity.ToString());
                            writer.WriteAttributeString("KeyDelta", control.KeyDelta.ToString());
                            writer.WriteAttributeString("Reverse", control.Reverse.ToString());
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }

                    foreach (DipSwitchNode dipSwitch in game.DipSwitchArray)
                    {
                        writer.WriteStartElement("DipSwitch");
                        writer.WriteAttributeString("Name", dipSwitch.Name);

                        foreach (DipValueNode dipValue in dipSwitch.DipValueArray)
                        {
                            writer.WriteStartElement("DipValue");
                            writer.WriteAttributeString("Name", dipValue.Name);

                            if (dipValue.Default != null)
                                writer.WriteAttributeString("Default", dipValue.Default);

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }

                    /* if (game.Driver != null)
                    {
                        writer.WriteStartElement("Driver");
                        writer.WriteAttributeString("Status", game.Driver.Status);
                        writer.WriteAttributeString("Emulation", game.Driver.Emulation);
                        writer.WriteAttributeString("Color", game.Driver.Color);
                        writer.WriteAttributeString("Sound", game.Driver.Sound);
                        writer.WriteAttributeString("Graphic", game.Driver.Graphic);
                        writer.WriteAttributeString("SaveState", game.Driver.SaveState);
                        writer.WriteAttributeString("PaletteSize", game.Driver.PaletteSize.ToString());
                        writer.WriteEndElement();
                    } */

                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("WriteMiniInfoXml", "MameXml", ex.Message, ex.StackTrace);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            GameArray.Clear();
            GameHash.Clear();
        }

        #endregion
    }
}