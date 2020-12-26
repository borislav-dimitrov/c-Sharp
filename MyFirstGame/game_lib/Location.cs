using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace My_app_lib
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        

        public Location(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }

    }
}
