using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class HPPotion : Item
    {
        public int MinHealed { get; set; }
        public int MaxHealed { get; set; }
        

        public HPPotion(int itemID, string itemName, string itemDescription, int minHealed, int maxHealed, int dropChance, string itemType,int requiredLevel) : base(
            itemID, itemName, itemDescription, dropChance, itemType, requiredLevel)
        {
            MinHealed = minHealed;
            MaxHealed = maxHealed;
        }
    }
}
