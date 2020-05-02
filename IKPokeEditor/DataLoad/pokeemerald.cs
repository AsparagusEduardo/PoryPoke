using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IKPokeEditor.DataLoad
{
    public class pokeemerald
    {
        public static void LoadTypes(string str, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index = 0;
            int lastIndex = 0;

            var totalTypes = Regex.Matches(str, "TYPE_").Cast<Match>().Count() - 1;

            for (int i = 0; i <= totalTypes; i++)
            {
                index = str.IndexOf("TYPE_", lastIndex + 2);
                lastIndex = index;

                var typeName = str.Substring((index + 5), ((str.IndexOf(" ", index)) - (index + 5)));

                infoData["tipos"][i.ToString()] = typeName;
                //MessageBox.Show("Tipo: " + infoData["tipos"][i.ToString()]);
            }
        }
        public static void LoadItems(string str, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index = 0;
            int lastIndex = 0;

            var totalItems = Regex.Matches(str, ".name =").Cast<Match>().Count() - 1;
            var countMT = Regex.Matches(str, "ITEM_TM").Cast<Match>().Count();
            var countMO = Regex.Matches(str, "ITEM_HM").Cast<Match>().Count();

            totalItems = totalItems - (countMT + countMO);

            for (int i = 0; i <= totalItems; i++)
            {
                index = str.IndexOf(".itemId", lastIndex + 2);
                lastIndex = index;

                var item = str.Substring((index + 15), ((str.IndexOf(",", index)) - (index + 15)));

                item = item.Replace(@"_", " ");

                infoData["objetos"][i.ToString()] = item;
                //MessageBox.Show("Item: " + infoData["objetos"][i.ToString()]);
            }
        }
        public static void LoadEggGroups(string str, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index = 0;
            int lastIndex = 0;

            var EggGroup = Regex.Matches(str, "EGG_GROUP_").Cast<Match>().Count() - 1;

            for (int i = 0; i <= EggGroup; i++)
            {
                index = str.IndexOf("EGG_GROUP_", lastIndex + 2);
                lastIndex = index;

                var eggGroup = str.Substring((index + 10), (str.IndexOf("\n", index) - (index + 10)));
                eggGroup = eggGroup.Split(' ')[0];
                eggGroup = eggGroup.Replace(@"_", " ");

                infoData["grupos_huevo"][i.ToString()] = eggGroup;
            }
        }
        public static void LoadBodyColors(string str, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index = 0;
            int lastIndex = 0;

            var BodyColor = Regex.Matches(str, "BODY_COLOR_").Cast<Match>().Count() - 1;

            for (int i = 0; i <= BodyColor; i++)
            {
                index = str.IndexOf("BODY_COLOR_", lastIndex + 2);
                lastIndex = index;

                var bodyColor = str.Substring((index + 11), (str.IndexOf("\n", index) - (index + 11)));
                bodyColor = bodyColor.Split(' ')[0];
                bodyColor = bodyColor.Replace(@"_", " ");

                infoData["color_cuerpo"][i.ToString()] = bodyColor;
                //MessageBox.Show("Color cuerpo: " + infoData["color_cuerpo"][i.ToString()]);
            }
        }
    }
}
