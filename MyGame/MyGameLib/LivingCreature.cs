using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class LivingCreature
    {
        
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int CurrHP { get; set; }
        public int MinDMG { get; set; }
        public int MaxDMG { get; set; }
        public int Level { get; set; }


      public LivingCreature(string name, int maxHP, int currHP, int minDMG, int maxDMG, int level)
      {
          
          Name = name;
          MaxHP = maxHP;
          CurrHP = currHP;
          MinDMG = minDMG;
          MaxDMG = maxDMG;
          Level = level;
      }
    }
}
