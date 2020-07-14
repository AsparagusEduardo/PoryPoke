using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryPoke.Class
{
    public class Pokemon
    {
        public bool IsOldUnown { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public int BaseHP { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSpeed { get; set; }
        public int BaseSpAttack { get; set; }
        public int BaseSpDefense { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int CatchRate { get; set; }
        public int ExpYield { get; set; }
        public int EvHP { get; set; }
        public int EvAttack { get; set; }
        public int EvDefense { get; set; }
        public int EvSpeed { get; set; }
        public int EvSpAttack { get; set; }
        public int EvSpDefense { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public bool HasGender { get; set; }
        public decimal GenderRatio { get; set; }
        public int EggCycles { get; set; }
        public int Friendship { get; set; }
        public string GrowthRate { get; set; }
        public string EggGroup1 { get; set; }
        public string EggGroup2 { get; set; }
        public string Ability1 { get; set; }
        public string Ability2 { get; set; }
        public int SafariFleeRate { get; set; }
        public string BodyColor { get; set; }
        public bool NoFlip { get; set; }
        public Dictionary<string, string[]> CustomBaseStats { get; set; } // statID, dataType

        public Pokemon()
        {
            IsOldUnown = false;
            BaseHP = BaseAttack = BaseDefense = BaseSpeed = BaseSpAttack = BaseSpDefense = 1;
            Type1 = Type2 = "TYPE_NONE";
            CatchRate = ExpYield = 0;
            EvHP = EvAttack = EvDefense = EvSpeed = EvSpAttack = EvSpDefense = 0;
            Item1 = Item2 = "ITEM_NONE";
            HasGender = false;
            GenderRatio = EggCycles = Friendship = 0;
            GrowthRate = "GROWTH_SLOW";
            EggGroup1 = EggGroup2 = "EGG_GROUP_UNDISCOVERED";
            Ability1 = Ability2 = "ABILITY_NONE";
            SafariFleeRate = 0;
            BodyColor = "BODY_COLOR_GREEN";
            NoFlip = false;
        }
    }
}
