using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Location Up;
        public Location Left;
        public Location Right;
        public Location Down;

        public List<Monster> CreaturesLivingHere = new List<Monster>();

        public Location(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }

    }
}
