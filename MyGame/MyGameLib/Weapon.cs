using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Durability { get; set; }

        public Weapon(int itemID, string itemName, string itemDescription, int minDamage, int maxDamage, int durability, int dropChance, string itemType, int requiredLevel) : base(
            itemID, itemName, itemDescription, dropChance, itemType, requiredLevel)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Durability = durability;
        }
    }
}
