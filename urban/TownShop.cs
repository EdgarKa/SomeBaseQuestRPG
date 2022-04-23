using System;

namespace someBaseQuestRPG.urban
{
    class TownShop : Shop
    {
        private Player player;
        private Weapon[] weapons;
        private Shield[] shields;
        private Armor[] armor;
        private Food[] food;
        private Potion[] potion;

        public TownShop() { }

        public void ShopInit(Player player, Weapon[] weapons, Shield[] shields, Armor[] armor, Food[] food, Potion[] potions)
        {
            this.player = player;
            this.weapons = weapons;
            this.shields = shields;
            this.armor = armor;
            this.food = food;
            this.potion = potions;

            ImportPlayer(player);
            ImportWeapons(weapons);
            ImportShields(shields);
            ImportFood(food);
            ImportPotion(potion);
            ImportArmor(armor);

            Greeting();
        }


        private void Greeting()
        {
            GameSystem.SetHeader("Shop");
            Console.WriteLine("Welcome to the shop! " +
                    "You have " + player.Coins + " coins" +
                    "\nWhat would you like to buy?" +
                    "\n1. Weapons" +
                    "\n2. Shields" +
                    "\n3. Armor" +
                    "\n4. Food" +
                    "\n5. Potions" +
                    "\n0. Leave");

            int choice = GameSystem.GetInteger();
            switch (choice)
            {
                case 1:
                    WeaponsMenu();
                    Greeting();
                    break;
                case 2:
                    ShieldsMenu();
                    Greeting();
                    break;
                case 3:
                    SelectArmorMenu();
                    // TODO: Sort out armor at some point
                    Console.WriteLine("Armor is in development for a long while. No need for it now");
                    Greeting();
                    break;
                case 4:
                    FoodMenu();
                    Greeting();
                    break;
                case 5:
                    PotionsMenu();
                    Greeting();
                    break;
                case 0:
                    Game.ShowInitialOptions();
                    break;
                default:
                    Console.WriteLine("Input not recognized");
                    Greeting();
                    break;
            }
        }
    }
}
