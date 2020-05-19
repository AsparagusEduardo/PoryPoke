using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PoryPoke.DataLoad
{
    public class pokeemerald
    {
        public static void LoadBaseStat(string str, string prefix, string infoID, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index;
            int lastIndex = 0;
            prefix = "#define " + prefix;

            var totalStats = Regex.Matches(str, prefix).Cast<Match>().Count() - 1;

            for (int i = 0; i <= totalStats; i++)
            {
                index = str.IndexOf(prefix, lastIndex + 2);
                lastIndex = index;
                int index2 = index + prefix.Length;

                var baseStatName = str.Substring(index2, str.IndexOf(" ", index2) - (index2)).Replace(@"_", " ");
                infoData[infoID][i.ToString()] = baseStatName;
            }
        }

        public static void LoadItems(string str, ref Dictionary<string, Dictionary<string, string>> infoData)
        {
            int index = 0;
            int lastIndex = 0;

            var totalItems = Regex.Matches(str, ".name =").Cast<Match>().Count() - 1;

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
            string[] mons = str.Split(new string[] { "[SPECIES_NONE]" }, StringSplitOptions.None)[1].Split(new string[] { "[SPECIES_" }, StringSplitOptions.None);

            PokemonDictionary.Clear();
            Class.Pokemon poke;
            for (int i = 1; i < mons.Length; i++)
            {
                string mon = mons[i];
                int index = 0;
                poke = new Class.Pokemon();
                poke.ID = mon.Substring(0, mon.IndexOf("]"));

                if (!(poke.ID.Substring(0, Math.Min(poke.ID.Length, 9)).Equals("OLD_UNOWN")))
                {
                    poke.BaseHP = int.Parse(LoadStat(ref mon, ref poke, index, "baseHP"));
                    poke.BaseAttack = int.Parse(LoadStat(ref mon, ref poke, index, "baseAttack"));
                    poke.BaseDefense = int.Parse(LoadStat(ref mon, ref poke, index, "baseDefense"));
                    poke.BaseSpeed = int.Parse(LoadStat(ref mon, ref poke, index, "baseSpeed"));
                    poke.BaseSpAttack = int.Parse(LoadStat(ref mon, ref poke, index, "baseSpAttack"));
                    poke.BaseSpDefense = int.Parse(LoadStat(ref mon, ref poke, index, "baseSpDefense"));
                    poke.Type1 = LoadStat(ref mon, ref poke, index, "type1");
                    poke.Type2 = LoadStat(ref mon, ref poke, index, "type2");
                    poke.CatchRate = int.Parse(LoadStat(ref mon, ref poke, index, "catchRate"));
                    poke.ExpYield = int.Parse(LoadStat(ref mon, ref poke, index, "expYield"));
                    poke.EvHP = int.Parse(LoadStat(ref mon, ref poke, index, "evYield_HP"));
                    poke.EvAttack = int.Parse(LoadStat(ref mon, ref poke, index, "evYield_Attack"));
                    poke.EvDefense = int.Parse(LoadStat(ref mon, ref poke, index, "evYield_Defense"));
                    poke.EvSpeed = int.Parse(LoadStat(ref mon, ref poke, index, "evYield_Speed"));
                    poke.EvSpAttack = int.Parse(LoadStat(ref mon, ref poke, index, "evYield_SpAttack"));
                    poke.EvSpDefense = int.Parse(LoadStat(ref mon, ref poke, index, "evYield_SpDefense"));
                    poke.Item1 = LoadStat(ref mon, ref poke, index, "item1");
                    poke.Item2 = LoadStat(ref mon, ref poke, index, "item2");

                    string gender = LoadStat(ref mon, ref poke, index, "genderRatio");
                    if (gender != "MON_GENDERLESS")
                    {
                        if (gender == "MON_FEMALE")
                            poke.GenderRatio = 100;
                        else if (gender == "MON_MALE" || gender == "0")
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
                    poke.EggCycles = int.Parse(LoadStat(ref mon, ref poke, index, "eggCycles"));
                    poke.Friendship = int.Parse(LoadStat(ref mon, ref poke, index, "friendship"));
                    poke.GrowthRate = LoadStat(ref mon, ref poke, index, "growthRate");
                    poke.EggGroup1 = LoadStat(ref mon, ref poke, index, "eggGroup1");
                    poke.EggGroup2 = LoadStat(ref mon, ref poke, index, "eggGroup2");

                    string abilities = LoadStat(ref mon, ref poke, index, "abilities");
                    poke.Ability1 = abilities.Substring(1, abilities.IndexOf(",") - 1);
                    poke.Ability2 = abilities.Substring(abilities.IndexOf(",") + 2, abilities.IndexOf("}") - abilities.IndexOf(",") - 2);
                    poke.SafariFleeRate = int.Parse(LoadStat(ref mon, ref poke, index, "safariZoneFleeRate"));
                    poke.BodyColor = LoadStat(ref mon, ref poke, index, "bodyColor");
                    poke.NoFlip = bool.Parse(LoadStat(ref mon, ref poke, index, "noFlip"));
                }
                else
                {
                    LoadOldUnownBaseStats(ref poke, str);
                }
                PokemonDictionary.Add(poke.ID, poke);
            }
        }
        private static string LoadStat(ref string str, ref Class.Pokemon poke, int index, string statName)
        {
            index = str.IndexOf(statName, str.IndexOf(".", index));
            if (index == -1)
            {
                switch (statName)
                {
                    case "item1":
                    case "item2":
                        return "ITEM_NONE";
                    default:
                        return "0";
                }
            }
            int offset = str.IndexOf("=", index) + 2;
            return str.Substring(offset, str.IndexOf(",\n", index) - (offset));
        }

        public static void LoadOldUnownBaseStats(ref Class.Pokemon poke, string str)
        {
            int index;
            poke.IsOldUnown = true;

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

            poke.Ability1 = poke.Ability2 = "ABILITY_NONE";
            poke.BodyColor = "BODY_COLOR_BLACK";
        }
    }
}
