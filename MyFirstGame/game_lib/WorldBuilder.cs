using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace My_app_lib
{
    public class WorldBuilder
    {
        public static readonly List<Location> AllZones = new List<Location>();
        public static readonly List<Monster> AllMonsters = new List<Monster>();


        public const int LOC_ID_HOME = 1;
        public const int LOC_ID_STORM_WIND = 2;
        public const int LOC_ID_GOLD_SHIRE = 3;


        public void buildWorld()
        {
            buildZones();
            //buildMonsters();
        }
        

        private void buildZones()
        {
            Location Home = new Location(LOC_ID_HOME, "Home", "This is your Home");
            Location Storm_Wind = new Location(LOC_ID_STORM_WIND, "Storm_Wind", "A hell of a big big City");
            Location Gold_Shire=  new Location(LOC_ID_GOLD_SHIRE, "Gold_Shire", "A small city in Elwyin Forest");

            AllZones.Add(Home);
            AllZones.Add(Storm_Wind);
            AllZones.Add(Gold_Shire);
        }





        public static Location LocationByID(int id)
        {
            foreach (Location item in AllZones)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }


    }
}
