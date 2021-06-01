using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class Shield : Item
    {
        public int Armor { get; set; }
        public int Durability { get; set; }
        public int BlockValue { get; set; }

        public Shield(int itemID, string itemName,string itemDescription,int dropChance,string itemType, int blockValue, int armor, int durability, int requiredLevel) : base(
            itemID, itemName, itemDescription, dropChance, itemType, requiredLevel)
        {
            BlockValue = blockValue;
            Armor = armor;
            Durability = durability;
            RequiredLevel = requiredLevel;

        }
    }
}
