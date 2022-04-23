using System;

using someBaseQuestRPG.travel;
using someBaseQuestRPG.urban;

namespace someBaseQuestRPG
{
    class Game
    {

        // Player and enemies
        private static Player player;
        private static PlayerOptions po;
        private static Enemy enemyEasy;
        private static Enemy enemyMedium;
        private static Enemy enemyHard;
        private static Enemy darkKnight;
        private static Enemy spider;
        private static Enemy wolf;
        private static Enemy[] enemy;

        // Locations
        private static Arena arena;
        private static TownShop townShop;
        private static Forest forest;
        private static Hospital hospital;
        private static Casino casino;
        private static Tavern tavern;

        // Travel Locations
        private static ForbiddenForest fForest;
        private static Valley valley;
        private static Lake lake;
        private static Mountain mountain;
        private static AbandonedCastle castle;
        private static GhostTown ghostTown;
        private static Desert desert;
        //private static BossLair bossLair;

        // Attributes - weapon, shield
        public static Weapon fistsA;
        public static Weapon axe;
        private static Weapon wornAxe;
        private static Weapon sword;
        private static Weapon dragonSlayer;
        public static Shield fistsD;
        private static Shield woodenShield;
        private static Shield wornWoodenShield;
        private static Shield ironShield;
        private static Weapon[] weapons;
        private static Weapon[] arenaWeapons;
        private static Shield[] shields;
        private static Shield[] arenaShields;

        // Armor - head, torso, waist, legs
        private static Armor noArmor;
        private static Armor headBase;
        private static Armor headMedium;
        private static Armor headAdvanced;
        private static Armor torsoBase;
        private static Armor torsoMedium;
        private static Armor torsoAdvanced;
        private static Armor waistBase;
        private static Armor waistMedium;
        private static Armor waistAdvanced;
        private static Armor legsBase;
        private static Armor legsMedium;
        private static Armor legsAdvanced;
        private static Armor[] allHead;
        private static Armor[] allTorso;
        private static Armor[] allWaist;
        private static Armor[] allLegs;
        private static Armor[] allArmor;

        // Food
        public static Food apple;
        public static Food ham;
        public static Food meal;
        public static Food berry;
        private static Food[] food;

        // Potion
        private static Potion healingPotion;
        private static Potion atkBoostPotion;
        private static Potion defBoostPotion;
        private static Potion[] potions;


        public static void Start()
        {
            GameSystem.SetHeader("Entering Name");
            Console.Write("Welcome to Some Base Text RPG, text-based RPG game" +
                "\nType in your name below to continue: ");
            string name = Console.ReadLine();
            GameSystem.ClearScreen();
            // ----------------------------------------------------------
            // Initialize weapons and shields
            fistsA = new Weapon("Fists", 5, 0);
            fistsD = new Shield("Fists", 5, 0);
            axe = new Weapon("Axe", 20, 20);
            wornAxe = new Weapon("Worn Axe", 10, 10);
            sword = new Weapon("Sword", 50, 50);
            woodenShield = new Shield("Wooden Shield", 20, 20);
            wornWoodenShield = new Shield("Worn Wooden Shield", 10, 10);
            ironShield = new Shield("Iron Shield", 50, 50);
            //attributes = new Attributes[] { fists, axe, sword, woodenShield, ironShield };
            //arenaAttributes = new Attributes[] { wornAxe, wornWoodenShield };
            weapons = new Weapon[] { axe, sword };
            shields = new Shield[] { woodenShield, ironShield };
            arenaWeapons = new Weapon[] { wornAxe };
            arenaShields = new Shield[] { wornWoodenShield };

            dragonSlayer = new Weapon("DragonSlayer", 70, 100);

            // Initialize Armor
            noArmor = new Armor("empty", "Base", 0, 0);
            headBase = new Armor("headBase", "Head", 5, 15);
            headMedium = new Armor("headMedium", "Head", 10, 20);
            headAdvanced = new Armor("headAdvanced", "Head", 15, 25);
            torsoBase = new Armor("torsoBase", "Torso", 5, 15);
            torsoMedium = new Armor("torsoMedium", "Torso", 10, 20);
            torsoAdvanced = new Armor("torsoAdvanced", "Torso", 15, 25);
            waistBase = new Armor("waistBase", "Waist", 5, 15);
            waistMedium = new Armor("waistMedium", "Waist", 10, 20);
            waistAdvanced = new Armor("waistAdvanced", "Waist", 15, 25);
            legsBase = new Armor("legsBase", "Legs", 5, 15);
            legsMedium = new Armor("legsMedium", "Legs", 10, 20);
            legsAdvanced = new Armor("legsAdvanced", "Legs", 15, 25);
            allArmor = new Armor[] {headBase, headMedium, headAdvanced,
                                torsoBase, torsoMedium, torsoAdvanced,
                                waistBase, waistMedium, waistAdvanced,
                                legsBase, legsMedium, legsAdvanced};


            // Initialize player and enemies
            player = new Player(name, fistsA, fistsD, noArmor);
            po = new PlayerOptions();
            enemyEasy = new Enemy("Easy", 50, fistsA, fistsD, 10);
            enemyMedium = new Enemy("Street", 100, axe, woodenShield, 20);
            enemyHard = new Enemy("Pro", 150, sword, ironShield, 50);
            darkKnight = new Enemy("Dark Knight", 250, dragonSlayer, ironShield, 100);
            spider = new Enemy("Spider", 100, "strike", 20, 50, 45);
            wolf = new Enemy("Wolf", 100, "bite", 50, 20, 45);
            enemy = new Enemy[] { enemyEasy, enemyMedium, enemyHard, darkKnight, spider, wolf, spider };


            // Initialize locations
            arena = new Arena();
            townShop = new TownShop();
            forest = new Forest();
            hospital = new Hospital();
            casino = new Casino();
            tavern = new Tavern();

            // Initialize travel locations
            fForest = new ForbiddenForest();
            valley = new Valley();
            lake = new Lake();
            mountain = new Mountain();
            castle = new AbandonedCastle();
            ghostTown = new GhostTown();
            desert = new Desert();
            //bossLair = new BossLair();

            // Initialize food
            apple = new Food("Apple", "Nice. Red. Healthy", 5, 10, 5);
            ham = new Food("Ham", "You love it (most likely)", 15, 15, 10);
            meal = new Food("Meal", "You won't think about eatin' for a while!", 25, 30, 25);
            berry = new Food("Berries", "", 0, 2, 2);
            food = new Food[] { apple, ham, meal, berry };
            player.SetFood(food);


            // Initialize potions
            healingPotion = new Potion("Healing potion", "It will slightly heal you helping in the intense battle", 50, "heal", 15);
            atkBoostPotion = new Potion("Attack Boost potion", "Overestimated your capabilities? This potion should help", 50, "attackBoost", 15);
            defBoostPotion = new Potion("Defence Boost potion", "Your shield made of paper? Drink it and you'll have a cardboard!", 50, "defenceBoost", 15);
            potions = new Potion[] { healingPotion, atkBoostPotion, defBoostPotion };
            player.SetPotion(potions);
            // ----------------------------------------------------------

            //player = Save.CheckIfPlayerLoaded(player);

            ShowInitialOptions();
        }

        public static void ShowInitialOptions()
        {
            GameSystem.SetHeaderForPlayer("Main Menu", player);
            Console.WriteLine("Select from the following options: " +
                "\n\t1. Player" +
                "\n\t2. Show Enemies" +
                "\n\t3. Forest" +
                "\n\t4. Travel" +
                "\n\t5. Urban Locations" +
                "\n\t6. Save Game" +
                "\n\t7. God Mode" +
                "\n\t0. Quit");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    po.PlayerOptionsInit(player, food, potions);
                    break;
                case 2:
                    GameSystem.SetHeader("Enemies");
                    foreach (Enemy e in enemy)
                    {
                        e.GetDetails();
                        Console.WriteLine("\n");
                    }
                    GameSystem.PressEnter();
                    ShowInitialOptions();
                    break;
                case 3:
                    forest.InitForest(player, spider, wolf, food);
                    break;
                case 4:
                    Travel();
                    break;
                case 5:
                    UrbanLocations();
                    break;
                case 6:
                    Save save = new();
                    save.SaveGame(player);
                    GameSystem.ClearScreen();
                    ShowInitialOptions();
                    break;
                case 7:
                    player.Coins = 10000;
                    player.Health = 10000;
                    player.MaxHealth = 100000;
                    player.Attack = 500;
                    player.Defense = 500;
                    GameSystem.ClearScreen();
                    ShowInitialOptions();
                    break;
                case 0:
                    CheckToLeave();
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    ShowInitialOptions();
                    break;
            }
        }

        private static void CheckToLeave()
        {
            GameSystem.SetHeader("Leave the game");
            Console.WriteLine("Are you sure you want to leave? All your progress will not be saved (y/n)");
            String ans = GameSystem.GetString();

            if (ans.Equals("n"))
            {
                ShowInitialOptions();
            }
            else
            {
                Console.WriteLine("You've decided to leave");
                Environment.Exit(0);
            }
        }

        private static void UrbanLocations()
        {
            GameSystem.ClearScreen();
            GameSystem.SetHeader("Town");
            Console.WriteLine("Which location you want to visit?" +
                    "\n\t1. Hospital" +
                    "\n\t2. Town Shop" +
                    "\n\t3. Arena" +
                    "\n\t4. Casino" +
                    "\n\t5. Tavern" +
                    "\n\t0. Leave");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    hospital.HospitalInit(player, potions);
                    break;
                case 2:
                    townShop.ShopInit(player, weapons, shields, allArmor, food, potions);
                    break;
                case 3:
                    arena.InitArena(player, enemy, arenaWeapons, arenaShields);
                    break;
                case 4:
                    casino.Welcome();
                    break;
                case 5:
                    tavern.Welcome();
                    break;
                case 0:
                    ShowInitialOptions();
                    break;
                default:
                    Console.WriteLine("Misunderstood input");
                    UrbanLocations();
                    break;
            }
            UrbanLocations();

        }

        private static void Travel()
        {
            GameSystem.SetHeader("Travel");
            Console.WriteLine("Where would you like to go?" +
                    "\n\t1. Forbidden Forest" +
                    "\n\t2. Valley" +
                    "\n\t3. Lake" +
                    "\n\t4. Mountain" +
                    "\n\t5. Abandoned Castle" +
                    "\n\t6. Ghost Town" +
                    "\n\t7. Desert" +
                    "\n\t8. Boss' Lair" +
                    "\n\t0. Leave");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    fForest.ForbiddenForestInit();
                    break;
                case 2:
                    valley.ValleyInit();
                    break;
                case 3:
                    lake.LakeInit();
                    break;
                case 4:
                    mountain.MountainInit();
                    break;
                case 5:
                    castle.CastleInit();
                    break;
                case 6:
                    ghostTown.GhostTownInit();
                    break;
                case 7:
                    desert.DesertInit();
                    break;
                case 8:
                    Console.WriteLine("Not implemented yet");
                    GameSystem.PressEnter();
                    //bossLair.bossLairInit(player);
                    break;
                case 0:
                    Console.WriteLine("Leaving");
                    Game.ShowInitialOptions();
                    break;
                default:
                    Console.WriteLine("Misunderstood input");
                    GameSystem.PressEnter();
                    GameSystem.ClearScreen();
                    Travel();
                    break;
            }
            Travel();
        }
    }
}
