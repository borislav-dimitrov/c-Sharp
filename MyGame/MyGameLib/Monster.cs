using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class Monster : LivingCreature
    {
        public int ID { get; set; }
        public string Race { get; set; }
        public int Quantity { get; set; }
        public bool IsAlive = true;
        public int ExpReward { get; set; }

        public List<Item> DropTable = new List<Item>();

        public Monster(int id, string name, int maxHP, int currHP, int minDMG, int maxDMG, int level, string race, int expReward, int quantity) : base(name, maxHP, currHP, minDMG, maxDMG, level)
        {
            ID = id;
            Race = race;
            Quantity = quantity;
            ExpReward = expReward;
        }
    }
}
