using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ControlsDat
{
    public class ColorsIni : IDisposable
    {
        public class ColorsNode
        {
            public string Control = null;
            public string Color = null;

            public ColorsNode(string control, string color)
            {
                Control = control;
                Color = color;
            }
        }

        public class ColorsIniNode
        {
            public string Name = null;
            public List<ColorsNode> Colors = null;

            public ColorsIniNode(string name)
            {
                Name = name;
                Colors = new List<ColorsNode>();
            }
        }

        public Dictionary<string, ColorsIniNode> ColorsIniHash;

        public ColorsIni()
        {
            ColorsIniHash = new Dictionary<string, ColorsIniNode>();
        }

        public void ReadColorsIni(string path)
        {
            try
            {
                ColorsIniNode ColorsIni = null;

                string[] Lines = File.ReadAllLines(path);

                for (int i = 0; i < Lines.Length; i++)
                {
                    string Line = Lines[i].Trim();

                    if (Line.StartsWith("[") && Line.EndsWith("]"))
                    {
                        string Name = Line.Substring(1, Line.IndexOf(']') - 1);

                        ColorsIniHash.Add(Name, ColorsIni = new ColorsIniNode(Name));
                    }
                    else
                    {
                        if (ColorsIni != null)
                        {
                            string[] Values = Line.Split(new char[] { '=' });

                            if (Values.Length == 2)
                                ColorsIni.Colors.Add(new ColorsNode(Values[0], Values[1]));
                        }
                    }

                    //System.Windows.Forms.Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("ReadColorsIni", "ColorsIni", ex.Message, ex.StackTrace);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            ColorsIniHash.Clear();
        }

        #endregion
    }
}
