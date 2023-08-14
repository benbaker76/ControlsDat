using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

public partial class Win32
{
    [DllImport("kernel32")]
    public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    [DllImport("kernel32")]
    public static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
}

public class IniFile
{
    public string path;

    public IniFile(string INIPath)
    {
        path = INIPath;
    }

    public void WriteBoolean(string Section, string Key, bool Value)
    {
        Win32.WritePrivateProfileString(Section, Key, Value.ToString(), this.path);
    }

    public void WriteInteger(string Section, string Key, int Value)
    {
        Win32.WritePrivateProfileString(Section, Key, Value.ToString(), this.path);
    }

    public void WriteString(string Section, string Key, string Value)
    {
        Win32.WritePrivateProfileString(Section, Key, Value, this.path);
    }

    public void WriteValueArrayList(string Section, List<IniKey> KeyArray)
    {
        foreach (IniKey Key in KeyArray)
            WriteString(Section, Key.Key, Key.Value);
    }

    public string ReadString(string Section, string Key)
    {
        StringBuilder sb = new StringBuilder(512);

        int i = Win32.GetPrivateProfileString(Section, Key, String.Empty, sb, 511, this.path);

        return sb.ToString();
    }

    public int ReadInteger(string Section, string Key)
    {
        return Convert.StrToInt(ReadString(Section, Key));
    }

    public int ReadIntegerDefault(string Section, string Key, int Default)
    {
        return Convert.StrToInt(ReadStringDefault(Section, Key, Default.ToString()));
    }

    public bool ReadBoolean(string Section, string Key)
    {
        return Convert.StrToBool(ReadString(Section, Key));
    }

    public bool ReadBooleanDefault(string Section, string Key, bool Default)
    {
        return Convert.StrToBool(ReadStringDefault(Section, Key, Default.ToString()));
    }

    public string ReadStringDefault(string Section, string Key, string Default)
    {
        StringBuilder sb = new StringBuilder(512);

        int i = Win32.GetPrivateProfileString(Section, Key, String.Empty, sb, 511, this.path);

        if (i == 0)
            return Default;

        return sb.ToString();
    }

    public void DeleteKey(string Section, string Key)
    {
        WriteString(Section, Key, null);
    }

    public void DeleteSection(string Section)
    {
        WriteString(Section, null, null);
    }

    public List<string> EnumerateSections()
    {
        byte[] buf = new byte[16384];

        int i = Win32.GetPrivateProfileString(null, null, null, buf, 16384, this.path);

        String s = System.Text.Encoding.Default.GetString(buf);

        String[] sections = s.Split('\0');

        List<string> al = new List<string>();

        foreach (String section in sections)
        {
            if (section == "")
                break;

            al.Add(section);
        }

        return al;
    }

    public List<string> EnumerateSectionKeys(string Section)
    {
        byte[] buf = new byte[16384];

        int i = Win32.GetPrivateProfileString(Section, null, null, buf, 16384, this.path);

        String s = System.Text.Encoding.Default.GetString(buf);

        string[] keys = s.Split('\0');

        List<string> al = new List<string>();

        foreach (string key in keys)
        {
            if (key == "")
                break;

            al.Add(key);
        }

        return al;
    }

    public List<string> EnumerateSectionValues(string Section)
    {
        int i = 0;

        List<string> keys = EnumerateSectionKeys(Section);
        List<string> values = new List<string>();

        foreach (string key in keys)
            values[i++] = ReadString(Section, key);

        return values;
    }

    public List<IniKey> EnumerateSectionArrayList(string Section)
    {
        List<string> keys = EnumerateSectionKeys(Section);
        List<IniKey> values = new List<IniKey>();

        foreach (String key in keys)
            values.Add(new IniKey(key, ReadString(Section, key)));

        return values;
    }
}

public class IniKey
{
    public string Key = null;
    public string Value = null;

    public IniKey(string key, string value)
    {
        Key = key;
        Value = value;
    }
}
