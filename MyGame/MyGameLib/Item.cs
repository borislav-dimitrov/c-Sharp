using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int DropChance { get; set; }
        public string ItemType { get; set; }
        public int RequiredLevel { get; set; }
        //public bool IsSelected = false;

        public int Quantity = 1;

        public Item(int itemID, string itemName, string itemDescription, int dropChance, string itemType, int requiredLevel)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemDescription = itemDescription;
            DropChance = dropChance;
            ItemType = itemType;
            RequiredLevel = requiredLevel;
        }
    }
}
