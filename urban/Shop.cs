using System;
using System.Collections.Generic;

namespace someBaseQuestRPG.urban
{
    class Shop
    {

        private Player player;
        private Weapon[] weapons;
        private Shield[] shields;
        private Armor[] armor;
        private Food[] food;
        private Potion[] potions;

        public void ImportPlayer(Player player)
        {
            this.player = player;
        }

        public void ImportWeapons(Weapon[] weapons)
        {
            this.weapons = weapons;
        }

        public void ImportShields(Shield[] shields)
        {
            this.shields = shields;
        }

        public void ImportArmor(Armor[] armor)
        {
            this.armor = armor;
        }

        public void ImportFood(Food[] food)
        {
            this.food = food;
        }

        public void ImportPotion(Potion[] potions)
        {
            this.potions = potions;
        }

        protected void PotionsMenu()
        {

            Console.WriteLine("Potions:");
            int i = 1;
            foreach (Potion p in potions)
            {
                Console.Write($"{i}.");
                p.ListForShop();
                i++;
            }
            Console.WriteLine("0. Leave");

            int choice = GameSystem.GetInteger();

            if (choice == 0)
                return;

            int quantity;
            if (choice > 0 && choice < potions.Length)
            {
                quantity = ChooseQuantity();
                BuyPotion(potions[choice - 1], quantity);
                PotionsMenu();
            }
            else
            {
                Console.WriteLine("Wrong input");
                PotionsMenu();
            }
            PotionsMenu();
        }

        protected void FoodMenu()
        {

            Console.WriteLine("Food:");
            int i = 1;
            foreach (Food f in food)
            {
                Console.Write($"{i}.");
                f.ListForShop();
                i++;
            }

            Console.WriteLine("0. Leave");
            int choice = GameSystem.GetInteger();

            if (choice == 0)
                return;

            int quantity;
            if (choice > 0 && choice <= food.Length)
            {
                quantity = ChooseQuantity();
                BuyFood(food[choice - 1], quantity);
                FoodMenu();
            }
            else
            {
                Console.WriteLine("Wrong input");
                FoodMenu();
            }
            FoodMenu();
        }

        protected void WeaponsMenu()
        {
            Console.WriteLine("Weapons");
            int i = 1;
            foreach (Weapon w in weapons)
            {
                Console.Write($"{i}.");
                w.ListForShop();
                i++;
            }

            Console.WriteLine("0. Leave");
            int choice = GameSystem.GetInteger();

            if (choice == 0)
                return;

            if (choice > 0 && choice <= weapons.Length)
            {
                BuyWeapon(weapons[choice - 1]);
                WeaponsMenu();
            }
            else
            {
                Console.WriteLine("Wrong input");
                WeaponsMenu();
            }
        }


        protected void ShieldsMenu()
        {
            Console.WriteLine("Shields: ");
            int i = 1;
            foreach (Shield s in shields)
            {
                Console.Write($"{i}.");
                s.ListForShop();
                i++;
            }

            Console.WriteLine("0. Leave");
            int choice = GameSystem.GetInteger();

            if (choice == 0)
                return;

            if (choice > 0 && choice <= shields.Length)
            {
                BuyShield(shields[choice - 1]);
                ShieldsMenu();
            }
            else
            {
                Console.WriteLine("Wrong input");
                ShieldsMenu();
            }
        }

        protected void SelectArmorMenu()
        {
            Console.WriteLine("Select from the following options:" +
                    "\n\t1. Head" +
                    "\n\t2. Torso" +
                    "\n\t3. Waist" +
                    "\n\t4. Legs" +
                    "\n\t0. Leave");
            int choice = GameSystem.GetInteger();
            if (choice == 0) return;
            switch (choice)
            {
                case 1:
                    MenuArmor("Head");
                    break;
                case 2:
                    MenuArmor("Torso");
                    break;
                case 3:
                    MenuArmor("Waist");
                    break;
                case 4:
                    MenuArmor("Legs");
                    break;
                default:
                    Console.WriteLine("Wrong input, try again");
                    SelectArmorMenu();
                    break;
            }
        }

        private void MenuArmor(string bodyPart)
        {
            Console.WriteLine($"{bodyPart} Armor:");
            int i = 1;
            foreach (Armor a in armor)
            {
                if (a.PartProtecting.Equals(bodyPart))
                {
                    Console.Write($"{i}.");
                    a.ListForShop();
                    i++;
                }
            }
            Console.WriteLine("0. Leave");
            int choice = GameSystem.GetInteger();

            if (choice == 0)
                SelectArmorMenu();

            if (choice > 0 && choice <= armor.Length)
            {
                BuyArmor(armor[choice - 1]);
            }
            else
            {
                Console.WriteLine("Wrong input");
                MenuArmor(bodyPart);
            }
        }

        private void BuyPotion(Potion potion, int quantity)
        {
            Console.WriteLine("*******************");
            if (player.Coins >= potion.Price)
            {
                player.Coins -= potion.Price;
                potion.Quantity += quantity;
                Console.WriteLine((quantity == 1) ?
                        $"{quantity} product \"{potion.Name}\" was added to your inventory" :
                        $"{quantity} products \"{potion.Name}\" were added to your inventory");
            }
            else
            {
                Console.WriteLine("You don't have enough coins");
            }
            Console.WriteLine("*******************");
            GameSystem.PressEnter();
        }

        private void BuyFood(Food food, int quantity)
        {
            Console.WriteLine("*******************");
            if (player.Coins >= food.Price)
            {
                player.Coins -= food.Price;
                food.Quantity += quantity;
                Console.WriteLine((quantity == 1) ? $"{quantity} product \"{food.Name}\" was added to your inventory" :
                        $"{quantity} products \"{food.Name}\" were added to your inventory");
            }
            else
            {
                Console.WriteLine("You don't have enough coins");
            }
            Console.WriteLine("*******************");
            GameSystem.PressEnter();
        }

        protected void BuyWeapon(Weapon weapon)
        {
            if (player.Coins >= weapon.Price)
            {
                player.Weapon = weapon;
                player.Attack = weapon.Damage;

                player.Coins -= weapon.Price;
                Console.WriteLine($"{weapon.Name} was replaced in your inventory");
            }
            else
            {
                Console.WriteLine("You don't have enough cash");
            }
            GameSystem.PressEnter();
        }

        protected void BuyShield(Shield shield)
        {
            if (player.Coins >= shield.Price)
            {
                player.Shield = shield;
                player.Defense = shield.Defence;
                player.Coins -= shield.Price;
                Console.WriteLine($"{shield.Name} was replaced in your inventory");
            }
            else
            {
                Console.WriteLine("You don't have enough cash");
            }
            GameSystem.PressEnter();
        }

        protected void BuyArmor(Armor armor)
        {
            if (player.Coins >= armor.Price)
            {
                if (armor.PartProtecting.Equals("Head"))
                    player.HeadDefence = armor;
                else if (armor.PartProtecting.Equals("Chest") || armor.PartProtecting.Equals("Torso"))
                    player.TorsoDefence = armor;
                else if (armor.PartProtecting.Equals("Waist"))
                    player.WaistDefence = armor;
                else if (armor.PartProtecting.Equals("Legs"))
                    player.LegsDefence = armor;

                player.Coins -= armor.Price;
                Console.WriteLine($"{armor.Name} was replaced in your inventory");
            }
            else
            {
                Console.WriteLine("You don't have enough cash");
            }
            GameSystem.PressEnter();
        }

        private int ChooseQuantity()
        {
            Console.Write("How many? > ");
            return GameSystem.GetInteger();
        }
    }
}
/*
 * protected void PotionsMenu()
        {

            Console.Write("Potions:\n");
            int i = 1;
            foreach (Potion p in potions)
            {
                Console.Write(i + ". ");
                p.ListForShop();
                potionMap.Add(i, p);
                i++;
            }

            Console.WriteLine("0. Leave");
            int choice = GameSystem.GetInteger();

            if (choice == 0)
                return;

            int quantity;
            if (choice > 0 && choice <= potionMap.Count)
            {
                quantity = ChooseQuantity();
                BuyPotion(potionMap[choice], quantity);
                PotionsMenu();
            }
            else
            {
                Console.WriteLine("Wrong input");
                PotionsMenu();
            }
            PotionsMenu();
        }
 */