using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class Player : LivingCreature
    {
        public int CurrEXP { get; set; }
        public bool IsAlive = true;
        public double ExpToLvlUp = 3074;
        public int HPregen = 1;
        public int Armor = 0;
        public int BlockValue = 0;

        public Location currentLocation;

        public Weapon EquippedWeapon;
        public Shield EquippedShield;
        public BodyArmor EquippedBodyArmor;
        public Helmet EquippedHelmet;
        public Gloves EquippedGloves;
        public Belt EquippedBelt;
        public Boots EquippedBoots;

        public List<Item> Inventory = new List<Item>();
        
        

        public Player(string name, int maxHP, int currHP, int minDMG, int maxDMG, int currEXP, int level) : base(name, maxHP, currHP, minDMG, maxDMG, level)
        {
            
            CurrEXP = currEXP;
            
        }
    }
}
