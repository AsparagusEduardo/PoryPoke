using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IKPokeEditor
{
    public class Language
    {
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
                foreach(string fil in files)
                {
                    Dictionary<string, string> LanguageDic = new Dictionary<string, string>();
                    StreamReader sr = new StreamReader(fil);
                    string[] content = sr.ReadToEnd().Split('\n');
                    sr.Close();
                    foreach(string row in content)
                    {
                        if(!row.Trim().Equals(""))
                            LanguageDic.Add(row.Split('=')[0], row.Replace("\r", "").Split('=')[1]);
                    }
                    string langName = fil.Split('\\')[fil.Split('\\').Length - 1].Split('.')[0];

                    LanguageFiles.Add(langName, LanguageDic);
                }
            }
        }

        public static Dictionary<string, Dictionary<string, string>> LanguageFiles { get; set; }
    }
}
