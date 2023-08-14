using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace ControlsDat
{
    public class ControlsDat : IDisposable
    {
        public class LabelNode
        {
            public string Name = null;
            public string Value = null;
            public string Color = null;

            public LabelNode(string name, string value, string color)
            {
                Name = name;
                Value = value;
                Color = color;
            }
        }

        public class ControlNode
        {
            public string Name = null;
            public List<string> ConstantArray = null;
            public List<string> ButtonArray = null;

            public ControlNode(string name)
            {
                Name = name;
                ConstantArray = new List<string>();
                ButtonArray = new List<string>();
            }
        }

        public class PlayerNode
        {
            public int Number = 0;
            public int NumButtons = 0;
            public List<ControlNode> ControlArray;
            public List<LabelNode> LabelArray;

            public PlayerNode(int number, int numbuttons)
            {
                Number = number;
                NumButtons = numbuttons;
                ControlArray = new List<ControlNode>();
                LabelArray = new List<LabelNode>();
            }
        }

        public class GameNode
        {
            public string RomName = null;
            public string GameName = null;
            public int NumPlayers = 0;
            public int Alternating = 0;
            public int Mirrored = 0;
            public int UsesService = 0;
            public int Tilt = 0;
            public int Cocktail = 0;
            public int Verified = 0;
            public string MiscDetails = null;
            public List<PlayerNode> PlayerArray = null;

            public GameNode(string romName, string gameName, int numPlayers, int alternating, int mirrored, int usesService, int tilt, int cocktail)
            {
                RomName = romName;
                GameName = gameName;
                NumPlayers = numPlayers;
                Alternating = alternating;
                Mirrored = mirrored;
                UsesService = usesService;
                Tilt = tilt;
                Cocktail = cocktail;
                PlayerArray = new List<PlayerNode>();
            }

            public string GetControlsString()
            {
                string retString = String.Empty;

                foreach (PlayerNode playerNode in PlayerArray)
                {
                    foreach (ControlNode controlNode in playerNode.ControlArray)
                        retString += controlNode.Name + " ";
                }

                return retString.Trim();
            }

            public string GetConstantsString()
            {
                string retString = String.Empty;

                foreach (PlayerNode playerNode in PlayerArray)
                {
                    foreach (ControlNode controlNode in playerNode.ControlArray)
                    {
                        foreach (string constant in controlNode.ConstantArray)
                            retString += constant + " ";
                    }
                }

                return retString.Trim();
            }
        }

        public enum xmlElement
        {
            Nothing,
            Game,
            Status,
            MiscDetails,
            Player,
            Control,
            Constant,
            Button,
            Label
        }

        public enum FormatType
        {
            Xml,
            Ini
        }

        public enum SaveType
        {
            All,
            Verified,
            UnVerified
        }

        public List<GameNode> GameArray = null;
        public Dictionary<string, GameNode> GameHash = null;

        private GameNode m_gameClipboard = null;

        public ControlsDat()
        {
            GameArray = new List<GameNode>();
            GameHash = new Dictionary<string, GameNode>();
        }

        public void ReadControlsXml(string FileName)
        {
            xmlElement CurrentElement = xmlElement.Nothing;
            Hashtable AttribHash = new Hashtable();

            GameNode CurrentGame = null;
            PlayerNode CurrentPlayer = null;
            ControlNode CurrentControl = null;
            LabelNode CurrentLabel = null;

            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(FileName);

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
                                case "status":
                                    CurrentElement = xmlElement.Status;
                                    break;
                                case "miscdetails":
                                    CurrentElement = xmlElement.MiscDetails;
                                    break;
                                case "player":
                                    CurrentElement = xmlElement.Player;
                                    break;
                                case "control":
                                    CurrentElement = xmlElement.Control;
                                    break;
                                case "constant":
                                    CurrentElement = xmlElement.Constant;
                                    break;
                                case "button":
                                    CurrentElement = xmlElement.Button;
                                    break;
                                case "label":
                                    CurrentElement = xmlElement.Label;
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
                                    string RomName = (string)AttribHash["romname"];
                                    CurrentGame = new GameNode(RomName, (string)AttribHash["gamename"], Convert.StrToInt((string)AttribHash["numplayers"]), Convert.StrToInt((string)AttribHash["alternating"]), Convert.StrToInt((string)AttribHash["mirrored"]), Convert.StrToInt((string)AttribHash["usesservice"]), Convert.StrToInt((string)AttribHash["tilt"]), Convert.StrToInt((string)AttribHash["cocktail"]));
                                    GameArray.Add(CurrentGame);
                                    GameHash.Add(RomName, CurrentGame);
                                    break;
                                case xmlElement.Status:
                                    if (CurrentGame != null)
                                    {
                                        CurrentGame.Verified = Convert.StrToInt((string)AttribHash["verified"]);
                                    }
                                    break;
                                case xmlElement.MiscDetails:
                                    break;
                                case xmlElement.Player:
                                    if (CurrentGame != null)
                                    {
                                        CurrentPlayer = new PlayerNode(Convert.StrToInt((string)AttribHash["number"]), Convert.StrToInt((string)AttribHash["numbuttons"]));
                                        CurrentGame.PlayerArray.Add(CurrentPlayer);
                                    }
                                    break;
                                case xmlElement.Control:
                                    if (CurrentPlayer != null)
                                    {
                                        CurrentControl = new ControlNode((string)AttribHash["name"]);
                                        CurrentPlayer.ControlArray.Add(CurrentControl);
                                    }
                                    break;
                                case xmlElement.Constant:
                                    if (CurrentControl != null)
                                    {
                                        CurrentControl.ConstantArray.Add((string)AttribHash["name"]);
                                    }
                                    break;
                                case xmlElement.Button:
                                    if (CurrentControl != null)
                                    {
                                        CurrentControl.ButtonArray.Add((string)AttribHash["name"]);
                                    }
                                    break;
                                case xmlElement.Label:
                                    if (CurrentPlayer != null)
                                    {
                                        CurrentLabel = new LabelNode((string)AttribHash["name"], (string)AttribHash["value"], (string)AttribHash["color"]);
                                        CurrentPlayer.LabelArray.Add(CurrentLabel);
                                    }
                                    break;
                                default:
                                    break;
                            }
                            reader.MoveToElement();
                            break;

                        case XmlNodeType.Text:
                            string Text = reader.Value.Trim();
                            switch (CurrentElement)
                            {
                                case xmlElement.MiscDetails:
                                    CurrentGame.MiscDetails = Text;
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
                                case xmlElement.MiscDetails:
                                    break;
                                case xmlElement.Player:
                                    CurrentPlayer = null;
                                    break;
                                case xmlElement.Control:
                                    CurrentControl = null;
                                    break;
                                case xmlElement.Constant:
                                    break;
                                case xmlElement.Button:
                                    break;
                                case xmlElement.Label:
                                    CurrentLabel = null;
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
                LogFile.WriteEntry("ReadControlsXml", "ControlsDat", ex.Message, ex.StackTrace);
            }

            if (reader != null)
                reader.Close();
        }

        public void WriteColorsIni(string fileName)
        {
            List<string> iniArray = new List<string>();

            try
            {
                foreach (GameNode gameNode in GameArray)
                {
                    bool foundColor = false;
                    List<string> iniGame = new List<string>();

                    iniGame.Add(String.Format("[{0}]", gameNode.RomName));

                    foreach (PlayerNode playerNode in gameNode.PlayerArray)
                    {
                        foreach (LabelNode labelNode in playerNode.LabelArray)
                        {
                            if (!String.IsNullOrEmpty(labelNode.Color))
                                foundColor = true;

                            iniGame.Add(String.Format("{0}={1}", labelNode.Name, labelNode.Color));
                        }
                    }

                    if (foundColor)
                        iniArray.AddRange(iniGame);
                }

                File.WriteAllLines(fileName, iniArray.ToArray());
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("WriteColorsIni", "ControlsDat", ex.Message, ex.StackTrace);
            }
            finally
            {
            }
        }

        public void WriteControlsDatXml(string fileName, SaveType saveType, bool includeColorData)
        {
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter(fileName, null);

                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();
                writer.WriteStartElement("Dat");

                writer.WriteStartElement("Meta");

                writer.WriteStartElement("Description");
                writer.WriteAttributeString("Name", "Controls.Dat XML File");
                writer.WriteEndElement();

                writer.WriteStartElement("Version");
                writer.WriteAttributeString("Name", Settings.Mame.Version);
                writer.WriteEndElement();

                writer.WriteStartElement("Time");
                writer.WriteAttributeString("Name", DateTime.Now.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("GeneratedBy");
                writer.WriteAttributeString("Name", Settings.General.UserName);
                writer.WriteEndElement();

                writer.WriteEndElement();

                foreach (GameNode gameNode in GameArray)
                {
                    if (saveType == SaveType.Verified && (gameNode.Verified == 0))
                        continue;

                    if (saveType == SaveType.UnVerified && (gameNode.Verified == 1))
                        continue;

                    writer.WriteStartElement("Game");
                    writer.WriteAttributeString("RomName", gameNode.RomName);
                    writer.WriteAttributeString("GameName", gameNode.GameName);

                    writer.WriteAttributeString("NumPlayers", gameNode.NumPlayers.ToString());
                    writer.WriteAttributeString("Alternating", gameNode.Alternating.ToString());
                    writer.WriteAttributeString("Mirrored", gameNode.Mirrored.ToString());
                    writer.WriteAttributeString("UsesService", gameNode.UsesService.ToString());
                    writer.WriteAttributeString("Tilt", gameNode.Tilt.ToString());
                    writer.WriteAttributeString("Cocktail", gameNode.Cocktail.ToString());

                    writer.WriteStartElement("Status");
                    writer.WriteAttributeString("Verified", gameNode.Verified.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("MiscDetails");
                    writer.WriteString(gameNode.MiscDetails);
                    writer.WriteEndElement();

                    foreach (PlayerNode playerNode in gameNode.PlayerArray)
                    {
                        writer.WriteStartElement("Player");
                        writer.WriteAttributeString("Number", playerNode.Number.ToString());
                        writer.WriteAttributeString("NumButtons", playerNode.NumButtons.ToString());

                        writer.WriteStartElement("Controls");

                        foreach (ControlNode controlNode in playerNode.ControlArray)
                        {
                            writer.WriteStartElement("Control");
                            writer.WriteAttributeString("Name", controlNode.Name);

                            foreach (string constant in controlNode.ConstantArray)
                            {
                                writer.WriteStartElement("Constant");
                                writer.WriteAttributeString("Name", constant);
                                writer.WriteEndElement();
                            }

                            foreach (string button in controlNode.ButtonArray)
                            {
                                writer.WriteStartElement("Button");
                                writer.WriteAttributeString("Name", button);
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteStartElement("Labels");

                        foreach (LabelNode labelNode in playerNode.LabelArray)
                        {
                            writer.WriteStartElement("Label");
                            writer.WriteAttributeString("Name", labelNode.Name);
                            writer.WriteAttributeString("Value", labelNode.Value);

                            if (!String.IsNullOrEmpty(labelNode.Color) && includeColorData)
                                writer.WriteAttributeString("Color", labelNode.Color);

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("WriteControlsDatXml", "ControlsDat", ex.Message, ex.StackTrace);
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

        public void WriteControlsDatIni(string fileName, SaveType saveType, bool includeColorData)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                List<string> strLines = new List<string>();

                strLines.Add(String.Format(";;Controls.dat INI file Version={0}, Time={1}, Generated by={2}", Settings.Mame.Version, DateTime.Now.ToString(), Settings.General.UserName));
                strLines.Add(String.Empty);

                foreach (GameNode gameNode in GameArray)
                {
                    if (saveType == SaveType.Verified && (gameNode.Verified == 0))
                        continue;

                    if (saveType == SaveType.UnVerified && (gameNode.Verified == 1))
                        continue;

                    strLines.Add(String.Format("[{0}]", gameNode.RomName));
                    strLines.Add(String.Format("GameName={0}", gameNode.GameName));
                    strLines.Add(String.Format("NumPlayers={0}", gameNode.NumPlayers));
                    strLines.Add(String.Format("Alternating={0}", gameNode.Alternating));
                    strLines.Add(String.Format("Mirrored={0}", gameNode.Mirrored));
                    strLines.Add(String.Format("UsesService={0}", gameNode.UsesService));
                    strLines.Add(String.Format("Tilt={0}", gameNode.Tilt));
                    strLines.Add(String.Format("Cocktail={0}", gameNode.Cocktail));
                    strLines.Add(String.Format("Verified={0}", gameNode.Verified));
                    strLines.Add(String.Format("MiscDetails={0}", gameNode.MiscDetails));

                    foreach (PlayerNode playerNode in gameNode.PlayerArray)
                    {
                        strLines.Add(String.Format("P{0}NumButtons={1}", playerNode.Number, playerNode.NumButtons.ToString()));

                        string strControls = String.Empty;

                        foreach (ControlNode controlNode in playerNode.ControlArray)
                        {
                            strControls += String.Format(controlNode.Name);

                            foreach (string constant in controlNode.ConstantArray)
                                strControls += String.Format("+{0}", constant);

                            foreach (string button in controlNode.ButtonArray)
                                strControls += String.Format("+{0}", button);

                            strControls += "|";
                        }

                        if(strControls.Length > 1)
                            strControls = strControls.Substring(0, strControls.Length - 1);

                        strLines.Add(String.Format("P{0}Controls={1}", playerNode.Number, strControls));

                        foreach (LabelNode labelNode in playerNode.LabelArray)
                            strLines.Add(String.Format("{0}={1}", labelNode.Name, String.Format(labelNode.Value + (includeColorData ? "|" + labelNode.Color : ""))));
                    }

                    strLines.Add(String.Empty);
                }

                File.WriteAllLines(fileName, strLines.ToArray());
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("WriteControlsDatIni", "ControlsDat", ex.Message, ex.StackTrace);
            }
        }

        public void AddColorsIni(ColorsIni colorsIni)
        {
            foreach (GameNode gameNode in GameArray)
            {
                foreach (ControlsDat.PlayerNode player in gameNode.PlayerArray)
                {
                    foreach (ControlsDat.LabelNode label in player.LabelArray)
                    {
                        ColorsIni.ColorsIniNode Colors = null;

                        if (colorsIni.ColorsIniHash.TryGetValue(gameNode.RomName, out Colors))
                        {
                            foreach (ColorsIni.ColorsNode Color in Colors.Colors)
                            {
                                if (label.Name.StartsWith(Color.Control))
                                {
                                    label.Color = Color.Color;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool TryAddNew(GameNode gameNode)
        {
            if (!GameHash.ContainsKey(gameNode.RomName))
            {
                GameArray.Add(gameNode);
                GameHash.Add(gameNode.RomName, gameNode);

                return true;
            }

            return false;
        }

        public bool TryAddNew(MameXml.GameNode gameNode)
        {
            if (!gameNode.HasControlsDat())
            {
                if (!GameHash.ContainsKey(gameNode.Name))
                {
                    gameNode.ControlsDat = new GameNode(gameNode.Name, gameNode.Description, 0, 0, 0, 0, 0, 0);
                    gameNode.ControlsDat.PlayerArray.Add(new PlayerNode(1, gameNode.InputArray[0].Buttons));

                    gameNode.ControlsDat.NumPlayers = gameNode.InputArray[0].Players;
                    gameNode.ControlsDat.UsesService = (gameNode.InputArray[0].Service ? 1 : 0);

                    foreach (MameXml.DipSwitchNode dipSwitchNode in gameNode.DipSwitchArray)
                    {
                        if (dipSwitchNode.Name == "Alternate Controls")
                            gameNode.ControlsDat.Alternating = 1;

                        foreach (MameXml.DipValueNode dipValueNode in dipSwitchNode.DipValueArray)
                            if (dipValueNode.Name == "Cocktail")
                                gameNode.ControlsDat.Cocktail = 1;
                    }

                    for(int i=0; i<gameNode.ControlsDat.PlayerArray[0].NumButtons; i++)
                        gameNode.ControlsDat.PlayerArray[0].LabelArray.Add(new LabelNode(String.Format("P1_BUTTON{0}", i + 1), "??", null));

                    GameArray.Add(gameNode.ControlsDat);
                    GameHash.Add(gameNode.Name, gameNode.ControlsDat);

                    return true;
                }
            }

            return false;
        }

        private bool TryCopyData(GameNode destGameNode, GameNode srcGameNode)
        {
            if (destGameNode.RomName == srcGameNode.RomName)
                return false;

            destGameNode.NumPlayers = srcGameNode.NumPlayers;
            destGameNode.Alternating = srcGameNode.Alternating;
            destGameNode.Mirrored = srcGameNode.Mirrored;
            destGameNode.UsesService = srcGameNode.UsesService;
            destGameNode.Tilt = srcGameNode.Tilt;
            destGameNode.Cocktail = srcGameNode.Cocktail;
            destGameNode.Verified = 0;
            destGameNode.MiscDetails = srcGameNode.MiscDetails;

            destGameNode.PlayerArray.Clear();

            foreach (PlayerNode playerNode in srcGameNode.PlayerArray)
            {
                PlayerNode newPlayerNode = new PlayerNode(playerNode.Number, playerNode.NumButtons);

                foreach (ControlNode controlNode in playerNode.ControlArray)
                {
                    ControlNode newControlNode = new ControlNode(controlNode.Name);

                    foreach (string constant in controlNode.ConstantArray)
                        newControlNode.ConstantArray.Add(constant);

                    foreach (string button in controlNode.ButtonArray)
                        newControlNode.ButtonArray.Add(button);

                    newPlayerNode.ControlArray.Add(newControlNode);
                }

                foreach (LabelNode labelNode in playerNode.LabelArray)
                {
                    LabelNode newLabelNode = new LabelNode(labelNode.Name, labelNode.Value, labelNode.Color);

                    newPlayerNode.LabelArray.Add(newLabelNode);
                }

                destGameNode.PlayerArray.Add(newPlayerNode);
            }

            return true;
        }

        public void Copy(GameNode gameNode)
        {
            m_gameClipboard = gameNode;
        }

        public bool TryPaste(GameNode gameNode)
        {
            if (m_gameClipboard == null)
                return false;

            return TryCopyData(gameNode, m_gameClipboard);
        }

        public void Delete(GameNode gameNode)
        {
            GameArray.Remove(gameNode);
            GameHash.Remove(gameNode.RomName);
            gameNode = null;
        }

        public GameNode GameClipBoard
        {
            get { return m_gameClipboard; }
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