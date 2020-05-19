using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryPoke.DataLoad
{
    public class Configuration
    {
        public static void LoadConfig()
        {
            Config = new Dictionary<string, string>();
            string path = Directory.GetCurrentDirectory() + "/config.ini";
            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Write(defaultValues);
                sw.Close();
            }
            StreamReader sr = new StreamReader(path);
            string[] lines = sr.ReadToEnd().Split('\n');
            foreach (string l in lines)
            {
                string[] option = l.Trim().Split('=');
                if (option.Length > 1)
                {
                    Config.Add(option[0], option[1]);
                }
            }
            sr.Close();
        }
        public static void SaveConfig()
        {
            string path = Directory.GetCurrentDirectory() + "/config.ini";
            StreamWriter sw = new StreamWriter(path);
            foreach (KeyValuePair<string, string> keyValue in Config)
            {
                sw.WriteLine(keyValue.Key + "=" + keyValue.Value);
            }
            sw.Close();
        }

        public static Dictionary<string, string> Config;

        private static string defaultValues = "language=English\nhideEmptyBaseStats=true\n";
    }
}
