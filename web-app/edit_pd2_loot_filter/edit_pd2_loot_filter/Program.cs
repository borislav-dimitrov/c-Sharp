using System;
using System.IO;

namespace edit_pd2_loot_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            main();
        }

        private static void main ()
        {
            string currFilter = @"D:\Diablo II\ProjectD2\loot.filter";
            readFile(currFilter);
        }

        private static void readFile(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            string[] linesToEdit = { "ItemDisplay[MAG !ID amu]: %NAME% // All unidentified amulets", "ItemDisplay[MAG !ID cm1]: %NAME%%MAP-97% // Small Charms", "ItemDisplay[MAG !ID cm2]: %NAME%%MAP-97% // Large Charms", "ItemDisplay[MAG !ID cm3]: %NAME%%MAP-97% // Grand Charms", "ItemDisplay[MAG !ID jew]: %NAME%%DOT-97% // All unidentified jewels", "//ItemDisplay[MAG !ID amc]: %NAME% // Grand Matron Bow", "//ItemDisplay[MAG !ID amb]: %NAME% // Matriarchal Bow", "//ItemDisplay[MAG !ID am7]: %NAME% // Ceremonial Bow", "//ItemDisplay[MAG !ID amf]: %NAME% // Matriarchal Javelin", "//ItemDisplay[MAG !ID ama]: %NAME% // Ceremonial Javelin", "//ItemDisplay[MAG !ID am5]: %NAME% // Maiden Javelin" };
            string[] linesToReplace = { "ItemDisplay[MAG !ID amu]: %PURPLE%%NAME% // All unidentified amulets", "ItemDisplay[MAG !ID cm1]: %PURPLE%%NAME%%MAP-97% // Small Charms", "ItemDisplay[MAG !ID cm2]: %NAME%%MAP-97% // Large Charms", "ItemDisplay[MAG !ID cm3]: %PURPLE%%NAME%%MAP-97% // Grand Charms", "ItemDisplay[MAG !ID jew]: %PURPLE%%NAME%%DOT-97% // All unidentified jewels", "//ItemDisplay[MAG !ID amc]: %RED%%NAME% // Grand Matron Bow", "//ItemDisplay[MAG !ID amb]: %RED%%NAME% // Matriarchal Bow", "//ItemDisplay[MAG !ID am7]: %RED%%NAME% // Ceremonial Bow", "//ItemDisplay[MAG !ID amf]: %RED%%NAME% // Matriarchal Javelin" , "//ItemDisplay[MAG !ID ama]: %RED%%NAME% // Ceremonial Javelin", "//ItemDisplay[MAG !ID am5]: %RED%%NAME% // Maiden Javelin" };

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    if (Array.Exists(linesToEdit, element => element == line))
                    {
                        int indexToReplace = Array.IndexOf(linesToEdit, line);

                        writer.WriteLine(linesToReplace[indexToReplace]);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
        }
    }
}
