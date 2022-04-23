using someBaseQuestRPG.player;
using someBaseQuestRPG.travel;
using someBaseQuestRPG.urban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someBaseQuestRPG
{
    internal class GameData
    {

        public class InitEverything
        {
            // ----------------------------------------------------------
            // Initialize weapons and shields
            Weapon fistsA = new Weapon("Fists", 5, 0);

            private Weapon axe = new Weapon("Axe", 20, 20);
            public Weapon Axe { get; set; }
            Weapon wornAxe = new Weapon("Worn Axe", 10, 10);
            Weapon sword = new Weapon("Sword", 50, 50);
            Shield fistsD = new Shield("Fists", 5, 0);
            Shield woodenShield = new Shield("Wooden Shield", 20, 20);
            Shield wornWoodenShield = new Shield("Worn Wooden Shield", 10, 10);
            Shield ironShield = new Shield("Iron Shield", 50, 50);
            //Attributes[] attributes = new Attributes[] { fists, axe, sword, woodenShield, ironShield };
            //Attributes[] arenaAttributes = new Attributes[] { wornAxe, wornWoodenShield };
            //Weapon[] weapons = new Weapon[] { axe, sword };
            //Shield[] shields = new Shield[] {woodenShield, ironShield};
            //Weapon[] arenaWeapons = new Weapon[] { wornAxe};
            //Shield[] arenaShields = new Shield[] { wornWoodenShield };

            Weapon dragonSlayer = new Weapon("DragonSlayer", 70, 100);

            // Initialize Armor
            Armor noArmor = new Armor("empty", "Base", 0, 0);
            Armor headBase = new Armor("headBase", "Head", 5, 15);
            Armor headMedium = new Armor("headMedium", "Head", 10, 20);
            Armor headAdvanced = new Armor("headAdvanced", "Head", 15, 25);
            Armor torsoBase = new Armor("torsoBase", "Torso", 5, 15);
            Armor torsoMedium = new Armor("torsoMedium", "Torso", 10, 20);
            Armor torsoAdvanced = new Armor("torsoAdvanced", "Torso", 15, 25);
            Armor waistBase = new Armor("waistBase", "Waist", 5, 15);
            Armor waistMedium = new Armor("waistMedium", "Waist", 10, 20);
            Armor waistAdvanced = new Armor("waistAdvanced", "Waist", 15, 25);
            Armor legsBase = new Armor("legsBase", "Legs", 5, 15);
            Armor legsMedium = new Armor("legsMedium", "Legs", 10, 20);
            Armor legsAdvanced = new Armor("legsAdvanced", "Legs", 15, 25);
            /*Armor allArmor = new Armor[] {headBase, headMedium, headAdvanced,
                                            torsoBase, torsoMedium, torsoAdvanced,
                                            waistBase, waistMedium, waistAdvanced,
                                            legsBase, legsMedium, legsAdvanced};*/


            // Initialize player and enemies
            //Player player = new Player(name, fistsA, fistsD, noArmor);
            PlayerOptions po = new PlayerOptions();
            //Enemy enemyEasy = new Enemy("Easy", 50, fistsA, fistsD, 10);
            //Enemy enemyMedium = new Enemy("Street", 100, axe, woodenShield, 20);
            //Enemy enemyHard = new Enemy("Pro", 150, sword, ironShield, 50);
            //Enemy darkKnight = new Enemy("Dark Knight", 250, dragonSlayer, ironShield, 100);
            Enemy spider = new Enemy("Spider", 100, "strike", 20, 50, 45);
            Enemy wolf = new Enemy("Wolf", 100, "bite", 50, 20, 45);
            //Enemy enemy = new Enemy[] { enemyEasy, enemyMedium, enemyHard, darkKnight, spider, wolf, spider };


            // Initialize locations
            Arena arena = new Arena();
            TownShop townShop = new TownShop();
            Forest forest = new Forest();
            Hospital hospital = new Hospital();
            Casino casino = new Casino();
            Tavern tavern = new Tavern();

            // Initialize travel locations
            ForbiddenForest fForest = new ForbiddenForest();
            Valley valley = new Valley();
            Lake lake = new Lake();
            Mountain mountain = new Mountain();
            AbandonedCastle castle = new AbandonedCastle();
            GhostTown ghostTown = new GhostTown();
            Desert desert = new Desert();
            //bossLair = new BossLair();

            // Initialize food
            Food apple = new Food("Apple", "Nice. Red. Healthy", 5, 10, 5);
            Food ham = new Food("Ham", "You love it (most likely)", 15, 15, 10);
            Food meal = new Food("Meal", "You won't think about eatin' for a while!", 25, 30, 25);
            Food berry = new Food("Berries", "", 0, 2, 2);
            //Food[] food = new Food[] { apple, ham, meal, berry };
            //player.SetFood(food);


            // Initialize potions
            Potion healingPotion = new Potion("Healing potion", "It will slightly heal you helping in the intense battle", 50, "heal", 15);
            Potion atkBoostPotion = new Potion("Attack Boost potion", "Overestimated your capabilities? This potion should help", 50, "attackBoost", 15);
            Potion defBoostPotion = new Potion("Defence Boost potion", "Your shield made of paper? Drink it and you'll have a cardboard!", 50, "defenceBoost", 15);
            //Potion[] potions = new Potion[] { healingPotion, atkBoostPotion, defBoostPotion };
            //player.SetPotion(potions);
            // ----------------------------------------------------------
        }

        // Weapons and Shields
        public Weapon FistsA { get; set; }
        public Weapon Axe { get; set; }
        public Weapon WornAxe { get; set; }
        public Weapon Sword { get; set; }
        public Shield WoodenShield { get; set; }
        public Shield WornWoodenShield { get; set; }
        public Shield IronShield { get; set; }
        public Weapon DragonSlayer { get; set; }

        // Armor
        public Armor NoArmor { get; set; }
        public Armor HeadBase { get; set; }
        public Armor HeadMedium { get; set; }
        public Armor HeadAdvanced { get; set; }
        public Armor TorsoBase { get; set; }
        public Armor TorsoMedium { get; set; }
        public Armor TorsoAdvanced { get; set; }
        public Armor WaistBase { get; set; }
        public Armor WaistMedium { get; set; }
        public Armor WaistAdvanced { get; set; }
        public Armor LegsBase { get; set; }
        public Armor LegsMedium { get; set; }
        public Armor LegsAdvanced { get; set; }

        // Player and enemies
        public Player Player { get; set; }
        public PlayerOptions Po { get; set; }
        Enemy EnemyEasy { get; set; }
        Enemy EnemyMedium { get; set; }
        Enemy EnemyHard { get; set; }
        Enemy DarkKnight { get; set; }
        Enemy Spider { get; set; }
        Enemy Wolf { get; set; }

        // Locations
        Arena Arena { get; set; }
        TownShop TownShop { get; set; }
        Forest Forest { get; set; }
        Hospital Hospital { get; set; }
        Casino Casino { get; set; }
        Tavern Tavern { get; set; }

        // Travel
        ForbiddenForest FForest { get; set; }
        Valley Valley { get; set; }
        Lake Lake { get; set; }
        Mountain Mountain { get; set; }
        AbandonedCastle Castle { get; set; }
        GhostTown GhostTown { get; set; }
        Desert Desert { get; set; }

        // Food
        Food Apple { get; set; }
        Food Ham { get; set; }
        Food Meal { get; set; }
        Food Berry { get; set; }

        Potion HealingPotion { get; set; }
        Potion AtkBootingPotion { get; set; }
        Potion DefBoostPotion { get; set; }




        /*public static class PlayerData
        {
            public static string playerName;
            public static int playerHealth;
            public static int playerMaxHealth;
            public static int playerAttack;
            public static int playerDefense;
            public static int playerCoins;
            public static Weapon playerWeapon;
            public static Shield playerShield;
            public static Armor playerHeadDefence;
            public static Armor playerTorsoDefence;
            public static Armor playerWaistDefence;
            public static Armor playerLegsDefence;
            public static Food[] playerFood;
            public static Potion[] playerPotion;
            public static int playerHunger;
            public static int playerHungerMax;
            public static int playerWins;
            public static int playerLosses;
            public static int playerXp;
            public static int playerLevel;
            public static PlayerProgress playerProgress;

            public static void GetPlayersData(Player player)
            {
                playerName = player.GetName();
                playerHealth = player.GetHealth();
                playerMaxHealth = player.GetMaxHealth();
                playerAttack = player.GetAttack();
                playerDefense = player.GetDefense();
                playerCoins = player.GetCoins();
                playerWeapon = player.GetWeapon();
                playerShield = player.GetShield();
                playerHeadDefence = player.GetHeadDefence();
                playerTorsoDefence = player.GetTorsoDefence();
                playerWaistDefence = player.GetWaistDefence();
                playerLegsDefence = player.GetLegsDefence();
                playerFood = player.GetFood();
                playerPotion = player.GetPotion();
                playerHunger = player.GetHunger();
                playerHungerMax = player.GetHungerMax();
                playerWins = player.GetHungerMax();
                playerLosses = player.GetLosses();
                playerXp = player.GetXp();
                playerLevel = player.GetLevel();
                //playerProgress;
        }
        }

        *//*public static class Locations
        {
            private static Arena arena;
            private static TownShop townShop;
            private static Forest forest;
            private static Hospital hospital;
            private static Casino casino;
            private static Tavern tavern;
        }

        public static class Weapons
        {

        }*/

    }
}
