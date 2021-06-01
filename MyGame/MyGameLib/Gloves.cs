﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class Gloves : Item
    {
        public int Armor { get; set; }
        public int Durability { get; set; }
        
        public Gloves(int itemID, string itemName, string itemDescription, int dropChance, string itemType, int armor, int durability, int requiredLevel) : base(
            itemID, itemName, itemDescription, dropChance, itemType, requiredLevel)
        {
            Armor = armor;
            Durability = durability;
            
        }
    }
}
