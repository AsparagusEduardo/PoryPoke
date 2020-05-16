using System;
using System.Collections.Generic;
using System.Globalization;
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
            int pokeAmount, index, pastIndex, pastValueName;
            string currentStat;

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
                    poke.BaseHP = int.Parse(LoadStat(ref str, ref poke, ref index, "baseHP", 16));
                    poke.BaseAttack = int.Parse(LoadStat(ref str, ref poke, ref index, "baseAttack", 16));
                    poke.BaseDefense = int.Parse(LoadStat(ref str, ref poke, ref index, "baseDefense", 16));
                    poke.BaseSpeed = int.Parse(LoadStat(ref str, ref poke, ref index, "baseSpeed", 16));
                    poke.BaseSpAttack = int.Parse(LoadStat(ref str, ref poke, ref index, "baseSpAttack", 16));
                    poke.BaseSpDefense = int.Parse(LoadStat(ref str, ref poke, ref index, "baseSpDefense", 16));
                    poke.Type1 = LoadStat(ref str, ref poke, ref index, "type1", 8);
                    poke.Type2 = LoadStat(ref str, ref poke, ref index, "type2", 8);
                    poke.CatchRate = int.Parse(LoadStat(ref str, ref poke, ref index, "catchRate", 12));
                    poke.ExpYield = int.Parse(LoadStat(ref str, ref poke, ref index, "expYield", 11));
                    poke.EvHP = int.Parse(LoadStat(ref str, ref poke, ref index, "evYield_HP", 20));
                    poke.EvAttack = int.Parse(LoadStat(ref str, ref poke, ref index, "evYield_Attack", 20));
                    poke.EvDefense = int.Parse(LoadStat(ref str, ref poke, ref index, "evYield_Defense", 20));
                    poke.EvSpeed = int.Parse(LoadStat(ref str, ref poke, ref index, "evYield_Speed", 20));
                    poke.EvSpAttack = int.Parse(LoadStat(ref str, ref poke, ref index, "evYield_SpAttack", 20));
                    poke.EvSpDefense = int.Parse(LoadStat(ref str, ref poke, ref index, "evYield_SpDefense", 20));
                    poke.Item1 = LoadStat(ref str, ref poke, ref index, "item1", 8);
                    poke.Item2 = LoadStat(ref str, ref poke, ref index, "item2", 8);

                    string gender = LoadStat(ref str, ref poke, ref index, "genderRatio", 14);
                    if (gender != "MON_GENDERLESS")
                    {
                        if (gender == "MON_FEMALE")
                            poke.GenderRatio = 100;
                        else if (gender == "MON_MALE")
                            poke.GenderRatio = 0;
                        else
                            poke.GenderRatio = decimal.Parse(gender.Substring(15, gender.IndexOf(")") - 15), NumberStyles.Any, new CultureInfo("en-US"));
                        poke.HasGender = true;
                    }
                    else
                    {
                        poke.HasGender = false;
                        poke.GenderRatio = 0;
                    }
                    poke.EggCycles = int.Parse(LoadStat(ref str, ref poke, ref index, "eggCycles", 12));
                    poke.Friendship = int.Parse(LoadStat(ref str, ref poke, ref index, "friendship", 13));
                    poke.GrowthRate = LoadStat(ref str, ref poke, ref index, "growthRate", 13);
                    poke.EggGroup1 = LoadStat(ref str, ref poke, ref index, "eggGroup1", 12);
                    poke.EggGroup2 = LoadStat(ref str, ref poke, ref index, "eggGroup2", 12);
                }
                else
                {
                    LoadOldUnownBaseStats(ref poke, str);
                }

                PokemonDictionary.Add(poke.ID, poke);
            }
        }
        private static string LoadStat(ref string str, ref Class.Pokemon poke, ref int index, string statName, int offset)
        {
            index = str.IndexOf(statName, str.IndexOf(".", index));
            return str.Substring(index + offset, str.IndexOf(",", index) - (index + offset));
        }

        public static void LoadOldUnownBaseStats(ref Class.Pokemon poke, string str)
        {
            int index;

            // BASE HP
            index = str.IndexOf("baseHP", str.IndexOf("#define OLD_UNOWN_BASE_STATS", 0)) + 9;
            poke.BaseHP = int.Parse(str.Substring(index, str.IndexOf(",", index) - index));

            // BASE ATTACK
            index = str.IndexOf("baseAttack", str.IndexOf(",", index)) + 13;
            poke.BaseAttack = int.Parse(str.Substring(index, str.IndexOf(",", index) - index));

            // BASE DEFENSE
            index = str.IndexOf("baseDefense", str.IndexOf(",", index)) + 14;
            poke.BaseDefense = int.Parse(str.Substring(index, str.IndexOf(",", index) - index));

            // BASE SPEED
            index = str.IndexOf("baseSpeed", str.IndexOf(",", index)) + 12;
            poke.BaseSpeed = int.Parse(str.Substring(index, str.IndexOf(",", index) - index));

            // BASE SP ATTACK
            index = str.IndexOf("baseSpAttack", str.IndexOf(",", index)) + 15;
            poke.BaseSpAttack = int.Parse(str.Substring(index, str.IndexOf(",", index) - index));

            // BASE SP DEFENSE
            index = str.IndexOf("baseSpDefense", str.IndexOf(",", index)) + 16;
            poke.BaseSpDefense = int.Parse(str.Substring(index, str.IndexOf(",", index) - index));

            // TYPE 1
            index = str.IndexOf("type1", str.IndexOf(",", index)) + 8;
            poke.Type1 = str.Substring(index, str.IndexOf(",", index) - index);

            // TYPE 2
            index = str.IndexOf("type2", str.IndexOf(",", index)) + 8;
            poke.Type2 = str.Substring(index, str.IndexOf(",", index) - index);

            // ITEM 1
            index = str.IndexOf("item1", str.IndexOf(",", index)) + 8;
            poke.Item1 = str.Substring(index, str.IndexOf(",", index) - index);

            // ITEM 2
            index = str.IndexOf("item2", str.IndexOf(",", index)) + 8;
            poke.Item2 = str.Substring(index, str.IndexOf(",", index) - index);

            // GROWTH RATE
            index = str.IndexOf("growthRate", str.IndexOf(",", index)) + 13;
            poke.GrowthRate = str.Substring(index, str.IndexOf(",", index) - index);

            // EGG GROUP 1
            index = str.IndexOf("eggGroup1", str.IndexOf(",", index)) + 12;
            poke.EggGroup1 = str.Substring(index, str.IndexOf(",", index) - index);

            // EGG GROUP 2
            index = str.IndexOf("eggGroup2", str.IndexOf(",", index)) + 12;
            poke.EggGroup2 = str.Substring(index, str.IndexOf(",", index) - index);
        }
    }
}
