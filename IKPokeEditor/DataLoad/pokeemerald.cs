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
        public static void LoadAbilities(string str, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index = 0;
            int lastIndex = 0;

            var totalAbilities = Regex.Matches(str, "ABILITY_").Cast<Match>().Count() - 1;

            for (int i = 0; i <= totalAbilities; i++)
            {
                index = str.IndexOf("ABILITY_", lastIndex + 2);
                lastIndex = index;

                var typeName = str.Substring((index + 8), (str.IndexOf(" ", index)) - (index + 8));

                typeName = typeName.Replace(@"_", " ");

                infoData["habilidades"][i.ToString()] = typeName;
                //MessageBox.Show("Habilidades: " + infoData["habilidades"][i.ToString()]);
            }
        }
        public static void LoadGrowthRate(string str, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index = 0;
            int lastIndex = 0;

            var totalGrowthModes = Regex.Matches(str, "GROWTH_").Cast<Match>().Count() - 1;

            for (int i = 0; i <= totalGrowthModes; i++)
            {
                index = str.IndexOf("GROWTH_", lastIndex + 2);
                lastIndex = index;

                var growthName = str.Substring((index + 7), (str.IndexOf("\n", index) - (index + 7)));
                growthName = growthName.Split(' ')[0];
                growthName = growthName.Replace(@"_", " ");

                infoData["crecimiento"][i.ToString()] = growthName;
                //MessageBox.Show("Crecimiento: " + infoData["crecimiento"][i.ToString()]);
            }
        }

        public static void LoadMonBaseStats(string str, string speciesNames, ref Dictionary<string, Class.Pokemon> PokemonDictionary)
        {
            int pokeAmount, index, pastIndex, statIndex, indexName, pastValueName;
            string baseHP, baseAttack, baseDefense, baseSpeed, baseSpAttack, baseSpDefense, type1, type2;

            PokemonDictionary.Clear();

            pokeAmount = Regex.Matches(str, "SPECIES_").Cast<Match>().Count() - 1;

            pastIndex = str.IndexOf("SPECIES_", 0);
            pastValueName = speciesNames.IndexOf("SPECIES_", 0);

            Class.Pokemon poke;

            for (int i = 0; i < pokeAmount; i++)
            {
                poke = new Class.Pokemon();

                // BASE HP
                index = str.IndexOf("SPECIES_", pastIndex + 2);
                pastIndex = index;
                var nextBrac = str.IndexOf("]", index + 1) - index;
                poke.ID = str.Substring(index + 8, nextBrac - 8);

                if (!(poke.ID.Substring(0, Math.Min(poke.ID.Length, 9)).Equals("OLD_UNOWN")))
                {
                    statIndex = index + nextBrac + 35;
                    baseHP = str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex);

                    // BASE ATTACK
                    index = (str.IndexOf(",", statIndex));
                    statIndex = str.IndexOf("baseAttack", index);
                    baseAttack = str.Substring(statIndex + 16, str.IndexOf(",", statIndex) - (statIndex + 16));

                    // BASE DEFENSE
                    index = str.IndexOf(",", statIndex) + 2;
                    statIndex = str.IndexOf("baseDefense", index);
                    baseDefense = str.Substring(statIndex + 16, str.IndexOf(",", statIndex) - (statIndex + 16));

                    // BASE SPEED
                    index = str.IndexOf(",", statIndex) + 2;
                    statIndex = str.IndexOf("baseSpeed", index);
                    baseSpeed = str.Substring(statIndex + 16, str.IndexOf(",", index) - (statIndex + 16));

                    // BASE SP ATTACK
                    index = (str.IndexOf(",", statIndex)) + 2;
                    statIndex = str.IndexOf("baseSpAttack", index);
                    baseSpAttack = str.Substring(statIndex + 16, str.IndexOf(",", index) - (statIndex + 16));

                    // BASE SP DEFENSE
                    index = (str.IndexOf(",", statIndex)) + 2;
                    statIndex = str.IndexOf("baseSpDefense", index);
                    baseSpDefense = str.Substring(statIndex + 16, str.IndexOf(",", index) - (statIndex + 16));

                    // TYPE 1
                    index = (str.IndexOf(",", statIndex)) + 2;
                    statIndex = str.IndexOf("type1", index);
                    type1 = str.Substring(statIndex + 8, str.IndexOf(",", index) - (statIndex + 8));

                    // TYPE 2
                    index = (str.IndexOf(",", statIndex)) + 2;
                    statIndex = str.IndexOf("type2", index);
                    type2 = str.Substring(statIndex + 8, str.IndexOf(",", index) - (statIndex + 8));

                    poke.BaseHP = int.Parse(baseHP);
                    poke.BaseAttack = int.Parse(baseAttack);
                    poke.BaseDefense = int.Parse(baseDefense);
                    poke.BaseSpeed = int.Parse(baseSpeed);
                    poke.BaseSpAttack = int.Parse(baseSpAttack);
                    poke.BaseSpDefense = int.Parse(baseSpDefense);
                    poke.Type1 = type1;
                    poke.Type2 = type2;
                }
                else
                {
                    LoadOldUnownBaseStats(ref poke, str);
                }

                PokemonDictionary.Add(poke.ID, poke);
            }
        }

        public static void LoadOldUnownBaseStats(ref Class.Pokemon poke, string str)
        {
            int statIndex;

            // BASE HP
            statIndex = str.IndexOf("baseHP", str.IndexOf("#define OLD_UNOWN_BASE_STATS", 0)) + 9;
            poke.BaseHP = int.Parse(str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex));

            // BASE ATTACK
            statIndex = str.IndexOf("baseAttack", str.IndexOf(",", statIndex)) + 13;
            poke.BaseAttack = int.Parse(str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex));

            // BASE DEFENSE
            statIndex = str.IndexOf("baseDefense", str.IndexOf(",", statIndex)) + 14;
            poke.BaseDefense = int.Parse(str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex));

            // BASE SPEED
            statIndex = str.IndexOf("baseSpeed", str.IndexOf(",", statIndex)) + 12;
            poke.BaseSpeed = int.Parse(str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex));

            // BASE SP ATTACK
            statIndex = str.IndexOf("baseSpAttack", str.IndexOf(",", statIndex)) + 15;
            poke.BaseSpAttack = int.Parse(str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex));

            // BASE SP DEFENSE
            statIndex = str.IndexOf("baseSpDefense", str.IndexOf(",", statIndex)) + 16;
            poke.BaseSpDefense = int.Parse(str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex));

            // TYPE 1
            statIndex = str.IndexOf("type1", str.IndexOf(",", statIndex)) + 8;
            poke.Type1 = str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex);

            // TYPE 2
            statIndex = str.IndexOf("type2", str.IndexOf(",", statIndex)) + 8;
            poke.Type2 = str.Substring(statIndex, str.IndexOf(",", statIndex) - statIndex);
        }
    }
}
