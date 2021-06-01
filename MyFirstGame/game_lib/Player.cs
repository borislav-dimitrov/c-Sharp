using System;
using System.Collections.Generic;
using System.Text;

namespace My_app_lib
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int CurrHP { get; set; }
        public int MinDMG { get; set; }
        public int MaxDMG { get; set; }
        public int CurrEXP { get; set; }
        public int Level { get; set; }

        public Location currentLocation;

        public Player(int id, string name, int maxHP, int currHP, int minDMG, int maxDMG, int currEXP, int level)
        {
            ID = id;
            Name = name;
            MaxHP = maxHP;
            CurrHP = currHP;
            MinDMG = minDMG;
            MaxDMG = maxDMG;
            CurrEXP = currEXP;
            Level = level;
        }
    }
}
