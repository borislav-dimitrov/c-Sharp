using System;
using System.Collections.Generic;
using System.Text;

namespace MyGameLib
{
    public class WorldBuilder
    {
        public static readonly List<Location> AllZones = new List<Location>();
        public static readonly List<Monster> AllMonsters = new List<Monster>();
        public static readonly List<Item> AllItems = new List<Item>();

        // Locations ID
        public const int LOC_ID_HOME = 1;
        public const int LOC_ID_STORM_WIND = 2;
        public const int LOC_ID_GOLD_SHIRE = 3;
        // Monsters ID
        public const int MONSTER_ID_BOAR = 1;
        public const int MONSTER_ID_WOLF = 2;
        public const int MONSTER_ID_KOBOLD = 3;
        public const int MONSTER_ID_BEAR = 4;
        public const int MONSTER_ID_MURLOC = 5;
        public const int MONSTER_ID_THIEF = 6;
        
        // Items
        public const int WEAPON_ID_DARIEQKA = 1;
        public const int WEAPON_ID_RUSTY_SWORD = 2;
        public const int WEAPON_ID_STICK = 3;
        public const int POTION_ID_LESSER_HP_POT = 4;
        public const int SHIELD_ID_TRAINEE_SHIELD = 5;
        public const int SHIELD_ID_GOLDEN_FLEET_BUCKLER = 6;
        public const int SHIELD_ID_WORN_TURTLE_SHELL_SHIELD = 7;
        public const int BODYARMOR_ID_ROKIE_LEATHER_ARMOR = 8;
        public const int GLOVES_ID_ROKIE_LEATHER_GLOVES = 9 ;
        public const int BELT_ID_LEATHER_BELT = 10;
        public const int BOOTS_ID_LEATHER_BOOTS = 11;
        public const int HELMET_ID_WOODEN_HELMET = 12;

        
        public static void buildWorld()
        {

            buildItems();
            buildMonsters();
            buildZones();
            
        }

        static void buildItems()
        {
            // Weapons
            Weapon Darieqka = new Weapon(WEAPON_ID_DARIEQKA, "darieqka", "nai-silniq weapon", 999999, 999999, 999999999, 1, "Weapon", 99);
            Weapon Stick = new Weapon(WEAPON_ID_STICK, "Stick", "Just a wooden stick", 1, 2, 25, 10, "Weapon", 1);
            Weapon Rusty_Sword = new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty Sword", "", 3, 5, 25, 10, "Weapon", 1);

            AllItems.Add(Darieqka);
            AllItems.Add(Stick);
            AllItems.Add(Rusty_Sword);

            // Shields
            Shield Trainee_Shield = new Shield(SHIELD_ID_TRAINEE_SHIELD, "Trainee's Shield", "", 10, "Shield", 0, 17, 25, 1);
            Shield Golden_Fleet_Buckler = new Shield(SHIELD_ID_GOLDEN_FLEET_BUCKLER, "Golden Fleet Buckler", "", 10, "Shield", 3, 60, 25, 1);
            Shield Worn_Turtle_Shell_Shield = new Shield(SHIELD_ID_WORN_TURTLE_SHELL_SHIELD, "Worn Turtle Shell Shield", "God bless that turtle", 7, "Shield", 9, 597, 75, 15);

            AllItems.Add(Trainee_Shield);
            AllItems.Add(Golden_Fleet_Buckler);
            AllItems.Add(Worn_Turtle_Shell_Shield);

            // Body Armors
            BodyArmor Rokie_Leather_Armor = new BodyArmor(BODYARMOR_ID_ROKIE_LEATHER_ARMOR, "Rokie Leather Armor", "", 10, "BodyArmor", 15, 25, 1);

            AllItems.Add(Rokie_Leather_Armor);

            // Helmets
            Helmet Wooden_Helmet = new Helmet(HELMET_ID_WOODEN_HELMET, "Wooden Helmet", "", 15, "Helmet", 15, 25, 10);

            AllItems.Add(Wooden_Helmet);

            // Gloves
            Gloves Rokie_Leather_Gloves = new Gloves(GLOVES_ID_ROKIE_LEATHER_GLOVES, "Rokie Leather Gloves", "", 10, "Gloves", 7, 25, 1);

            AllItems.Add(Rokie_Leather_Gloves);

            // Belts
            Belt Leather_Belt = new Belt(BELT_ID_LEATHER_BELT, "Leather Belt", "Poor animals..", 10, "Belt", 12, 25, 15);

            AllItems.Add(Leather_Belt);


            // Boots
            Boots Leather_Boots = new Boots(BOOTS_ID_LEATHER_BOOTS, "Leather Boots", "", 10, "Boots", 16, 25, 15);

            AllItems.Add(Leather_Boots);

            // Potions
            HPPotion Lesser_HP_Potion = new HPPotion(POTION_ID_LESSER_HP_POT, "Lesser HP Potion", "Healing up 20 - 30 HP", 20, 30, 10, "HP Potion", 1);
            

            AllItems.Add(Lesser_HP_Potion);

        }

        static void buildMonsters()
        {
            Monster Pig = new Monster(MONSTER_ID_BOAR, "Wild Boar", 15, 20, 1, 3, 1, "Beast", 53, 15);
            Pig.DropTable.Add(ItemByID(WEAPON_ID_STICK));
            Pig.DropTable.Add(ItemByID(POTION_ID_LESSER_HP_POT));
            Pig.DropTable.Add(ItemByID(SHIELD_ID_TRAINEE_SHIELD));
            

            Monster Wolf = new Monster(MONSTER_ID_WOLF, "Dire Wolf", 30, 30, 2, 4, 3, "Beast", 79, 15);
            Wolf.DropTable.Add(ItemByID(BODYARMOR_ID_ROKIE_LEATHER_ARMOR));
            Wolf.DropTable.Add(ItemByID(GLOVES_ID_ROKIE_LEATHER_GLOVES));
            
            Monster Kobold = new Monster(MONSTER_ID_KOBOLD, "Kobold", 45, 45, 3, 5, 5, "Humanoid", 118, 15);
            Kobold.DropTable.Add(ItemByID(WEAPON_ID_RUSTY_SWORD));
            Kobold.DropTable.Add(ItemByID(SHIELD_ID_GOLDEN_FLEET_BUCKLER));

            
            Monster Bear = new Monster(MONSTER_ID_BEAR, "Bear", 60, 60, 4, 6, 10, "Beast", 177, 15);
            Bear.DropTable.Add(ItemByID(SHIELD_ID_WORN_TURTLE_SHELL_SHIELD));
            Bear.DropTable.Add(ItemByID(HELMET_ID_WOODEN_HELMET));
            
            Monster Murloc = new Monster(MONSTER_ID_MURLOC, "Murloc", 75, 75, 5, 7, 12, "Humanoid", 265, 15);
            Murloc.DropTable.Add(ItemByID(BOOTS_ID_LEATHER_BOOTS));

            Monster Thief = new Monster(MONSTER_ID_THIEF, "Thief", 90, 90, 20, 20, 14, "Humanoid", 397, 15);
            Thief.DropTable.Add(ItemByID(BELT_ID_LEATHER_BELT));

            AllMonsters.Add(Pig);
            AllMonsters.Add(Wolf);
            AllMonsters.Add(Kobold);
            AllMonsters.Add(Bear);
            AllMonsters.Add(Murloc);
            AllMonsters.Add(Thief);

        }

        static void buildZones()
        {
            Location Start_Town = new Location(LOC_ID_HOME, "Start_Town", "This is your starting point. Have fun through your journey!");
            Start_Town.CreaturesLivingHere.Add(MonsterByID(MONSTER_ID_BOAR));
            Start_Town.CreaturesLivingHere.Add(MonsterByID(MONSTER_ID_WOLF));
            Start_Town.CreaturesLivingHere.Add(MonsterByID(MONSTER_ID_KOBOLD));

            Location Storm_Wind = new Location(LOC_ID_STORM_WIND, "Storm_Wind", "A hell of a big big City");

            Location Gold_Shire = new Location(LOC_ID_GOLD_SHIRE, "Gold_Shire", "A small city in the forest");
            Gold_Shire.CreaturesLivingHere.Add(MonsterByID(MONSTER_ID_BEAR));
            Gold_Shire.CreaturesLivingHere.Add(MonsterByID(MONSTER_ID_MURLOC));
            Gold_Shire.CreaturesLivingHere.Add(MonsterByID(MONSTER_ID_THIEF));

            AllZones.Add(Start_Town);
            AllZones.Add(Storm_Wind);
            AllZones.Add(Gold_Shire);

            Start_Town.Down = Gold_Shire;
            

            Gold_Shire.Up = Start_Town;
            Gold_Shire.Left = Storm_Wind;

            Storm_Wind.Right = Gold_Shire;

            
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

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in AllMonsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in AllItems)
            {
                if (item.ItemID == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}

