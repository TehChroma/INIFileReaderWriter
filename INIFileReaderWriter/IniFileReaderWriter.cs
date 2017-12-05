using System.Text;
using System.Runtime.InteropServices;

namespace INIFileReaderWriter
{
    class IniFileReaderWriter
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //INI Constructor.
        public IniFileReaderWriter(string INIPath)
        {
            path = INIPath;
        }

        //Writes To The INI File.
        public void INIWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.path);
        }

        //Reads From The INI File.
        public string INIReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int I = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
    }
}
