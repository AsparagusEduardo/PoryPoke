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

        public static void LoadLanguageFiles()
        {
            LanguageFiles = new Dictionary<string, Dictionary<string, string>>();
            string dir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(dir + "/lang"))
            {
                Directory.CreateDirectory(dir + "/lang");
            }
            else
            {
                string[] files = Directory.GetFiles(dir + "\\lang");
                foreach (string fil in files)
                {
                    Dictionary<string, string> LanguageDic = new Dictionary<string, string>();
                    StreamReader sr = new StreamReader(fil);
                    string[] content = sr.ReadToEnd().Split('\n');
                    sr.Close();
                    foreach (string row in content)
                    {
                        if (!row.Trim().Equals(""))
                            LanguageDic.Add(row.Split('=')[0], row.Replace("\r", "").Split('=')[1]);
                    }
                    string langName = fil.Split('\\')[fil.Split('\\').Length - 1].Split('.')[0];

                    LanguageFiles.Add(langName, LanguageDic);
                }
            }
        }

        public static Dictionary<string, string> Config;
        public static Dictionary<string, Dictionary<string, string>> LanguageFiles { get; set; }

        private static string defaultValues = "language=English\n" +
                                              "hideEmptyBaseStats=true\n";
    }
}
