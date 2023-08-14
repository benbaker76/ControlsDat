using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ControlsDat
{
    public class CatVer : IDisposable
    {
        public class CatVerNode
        {
            public string Name = null;
            public string Category = null;
            public string VerAdded = null;

            public CatVerNode()
            {
            }

            public CatVerNode(string name, string category, string veradded)
            {
                Name = name;
                Category = category;
                VerAdded = veradded;
            }
        }

        public Dictionary<string, CatVerNode> GameHash;

        public enum CatVerType
        {
            None,
            Category,
            VerAdded
        }

        public CatVer()
        {
            GameHash = new Dictionary<string, CatVerNode>();
        }

        public void ReadCatVerIni(string path)
        {
            try
            {
                CatVerNode catVer = null;
                CatVerType CurrentType = CatVerType.None;

                string[] Lines = File.ReadAllLines(path);

                for (int i = 0; i < Lines.Length; i++)
                {
                    string Line = Lines[i].Trim();

                    if (Line.StartsWith("[") && Line.EndsWith("]"))
                    {
                        string Section = Line.Substring(1, Line.IndexOf(']') - 1);

                        if (Section != null)
                        {
                            switch (Section.ToLower())
                            {
                                case "category":
                                    CurrentType = CatVerType.Category;
                                    break;
                                case "veradded":
                                    CurrentType = CatVerType.VerAdded;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        string[] Values = Line.Split(new char[] { '=' });

                        if (Values.Length == 2)
                        {
                            switch (CurrentType)
                            {
                                case CatVerType.Category:
                                    if (!GameHash.TryGetValue(Values[0], out catVer))
                                    {
                                        catVer = new CatVerNode();
                                        catVer.Name = Values[0];
                                        GameHash.Add(Values[0], catVer);
                                    }
                                    catVer.Category = Values[1];
                                    break;
                                case CatVerType.VerAdded:
                                    if (!GameHash.TryGetValue(Values[0], out catVer))
                                    {
                                        catVer = new CatVerNode();
                                        catVer.Name = Values[0];
                                        GameHash.Add(Values[0], catVer);
                                    }
                                    catVer.VerAdded = Values[1];
                                    break;
                            }
                        }
                    }

                    //System.Windows.Forms.Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("ReadCatVerIni", "CatVer", ex.Message, ex.StackTrace);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            GameHash.Clear();
        }

        #endregion
    }
}
