using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ControlsDat
{
    class ControlsData
    {
        public class LabelNode
        {
            public string Name = null;
            public string Label = null;

            public LabelNode(string name, string label)
            {
                Name = name;
                Label = label;
            }
        }

        public class ControlLabelNode : IComparable<ControlLabelNode>
        {
            public string Name = null;
            public List<LabelNode> LabelArray = null;

            public ControlLabelNode(string name)
            {
                Name = name;
                LabelArray = new List<LabelNode>();
            }

            #region IComparable<ControlLabelNode> Members

            public int CompareTo(ControlLabelNode other)
            {
                return this.Name.CompareTo(other.Name);
            }

            #endregion
        }

        public class DescriptionControlNode : IComparable<DescriptionControlNode>
        {
            public string Name = null;
            public List<string> CodeArray = null;

            public DescriptionControlNode(string name, string code)
            {
                Name = name;
                CodeArray = new List<string>();
                CodeArray.Add(code);
            }

            #region IComparable<DescriptionControlNode> Members

            public int CompareTo(DescriptionControlNode other)
            {
                return this.Name.CompareTo(other.Name);
            }

            #endregion
        }

        public static List<ControlLabelNode> ControlsToLabelsArray = null;
        public static List<DescriptionControlNode> DescriptionsToControlsArray = null;

        static ControlsData()
        {
            ControlsToLabelsArray = new List<ControlLabelNode>();
            DescriptionsToControlsArray = new List<DescriptionControlNode>();
        }

        public static void ReadControlsToLabels(string fileName)
        {
            try
            {
                ControlsToLabelsArray.Clear();

                string[] strLines = File.ReadAllLines(fileName);
                Dictionary<string, ControlLabelNode> controlHash = new Dictionary<string, ControlLabelNode>();

                for (int i = 0; i < strLines.Length; i++)
                {
                    string[] strSplit = strLines[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    if (strSplit.Length == 3)
                    {
                        ControlLabelNode controlLabelNode = null;

                        if (controlHash.TryGetValue(strSplit[0], out controlLabelNode))
                            controlLabelNode.LabelArray.Add(new LabelNode(strSplit[1], strSplit[2]));
                        else
                        {
                            controlLabelNode = new ControlLabelNode(strSplit[0]);
                            controlLabelNode.LabelArray.Add(new LabelNode(strSplit[1], strSplit[2]));
                            ControlsToLabelsArray.Add(controlLabelNode);
                            controlHash.Add(strSplit[0], controlLabelNode);
                        }
                    }
                }

                ControlsToLabelsArray.Sort();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("ReadControlsToLabels", "ControlsData", ex.Message, ex.StackTrace);
            }
        }

        public static void ReadDescriptionsToControls(string fileName)
        {
            try
            {
                DescriptionsToControlsArray.Clear();

                string[] strLines = File.ReadAllLines(fileName);
                Dictionary<string, DescriptionControlNode> controlHash = new Dictionary<string, DescriptionControlNode>();

                for (int i = 0; i < strLines.Length; i++)
                {
                    string[] strSplit = strLines[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    if (strSplit.Length == 2)
                    {
                        DescriptionControlNode descriptionControlNode = null;

                        if (controlHash.TryGetValue(strSplit[0], out descriptionControlNode))
                            descriptionControlNode.CodeArray.Add(strSplit[1]);
                        else
                        {
                            descriptionControlNode = new DescriptionControlNode(strSplit[0], strSplit[1]);
                            DescriptionsToControlsArray.Add(descriptionControlNode);
                            controlHash.Add(strSplit[0], descriptionControlNode);
                        }
                    }
                }

                DescriptionsToControlsArray.Sort();
            }
            catch (Exception ex)
            {
                LogFile.WriteEntry("ReadDescriptionsToControls", "ControlsData", ex.Message, ex.StackTrace);
            }
        }

        public static string[] GetControlArray()
        {
            List<string> controlArray = new List<string>();

            foreach (DescriptionControlNode descriptionControlNode in DescriptionsToControlsArray)
                controlArray.Add(descriptionControlNode.Name);

            return controlArray.ToArray();
        }

        public static string[] GetConstantArray(string controlName)
        {
            List<string> constantArray = new List<string>();

            foreach (DescriptionControlNode descriptionControlNode in DescriptionsToControlsArray)
            {
                if(descriptionControlNode.Name == controlName)
                    constantArray.AddRange(descriptionControlNode.CodeArray);
            }

            return constantArray.ToArray();
        }

        public static string[] GetButtonArray()
        {
            List<string> buttonArray = new List<string>();

            for (int i = 0; i < 16; i++)
                buttonArray.Add(String.Format("P1_BUTTON{0}", (i + 1)));

            return buttonArray.ToArray();
        }

        public static void GetControlLabelArray(string constantName, out string[] nameArray, out string[] labelArray)
        {
            List<string> NameArray = new List<string>();
            List<string> LabelArray = new List<string>();

            foreach (ControlLabelNode controlLabelNode in ControlsToLabelsArray)
            {
                if (constantName == controlLabelNode.Name)
                {
                    foreach(LabelNode labelNode in controlLabelNode.LabelArray)
                    {
                        NameArray.Add(labelNode.Name);
                        LabelArray.Add(labelNode.Label);
                    }
                }
            }

            nameArray = NameArray.ToArray();
            labelArray = LabelArray.ToArray();
        }

        public static string[] GetControlCodeArray()
        {
            List<string> ControlArray = new List<string>();
            Dictionary<string, string> ControlHash = new Dictionary<string, string>();

            foreach (ControlLabelNode controlLabelNode in ControlsToLabelsArray)
            {
                foreach (LabelNode labelNode in controlLabelNode.LabelArray)
                {
                    if(labelNode.Name == "BUTTON")
                    {
                        for(int i=0; i<16; i++)
                        {
                            string labelName = String.Format("P1_{0}{1}",labelNode.Name, i + 1);

                            if (!ControlHash.ContainsKey(labelName))
                            {
                                ControlArray.Add(labelName);
                                ControlHash.Add(labelName, null);
                            }
                        }
                    }
                    else
                    {
                        string labelName = String.Format("P1_{0}", labelNode.Name);

                        if (!ControlHash.ContainsKey(labelName))
                        {
                            ControlArray.Add(labelName);
                            ControlHash.Add(labelName, null);
                        }
                    }
                }
            }

            ControlArray.Sort();

            return ControlArray.ToArray();
        }
    }
}
