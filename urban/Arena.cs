using System;

using someBaseQuestRPG.text;

namespace someBaseQuestRPG.urban
{
    class Arena : Shop
    {
        private Player player;
        private Enemy[] enemies;
        private Weapon[] weapons;
        private Shield[] shields;
        private static bool beenHere = false;

        public Arena() { }

        public void InitArena(Player player, Enemy[] enemies, Weapon[] weapons, Shield[] shields)
        {
            this.player = player;
            this.enemies = enemies;
            this.weapons = weapons;
            this.shields = shields;

            ImportPlayer(player);
            ImportWeapons(weapons);
            ImportShields(shields);

            if (!beenHere)
            {
                Tutorial.ArenaText();
                beenHere = true;
            }

            Welcome();
        }

        private void Welcome()
        {

            GameSystem.SetHeader("Arena");
            Console.WriteLine("Select from the following options:" +
                    "\n\t1. Fight" +
                    "\n\t2. Local Shop" +
                    "\n\t0. Go back");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    ChooseEnemy();
                    break;
                case 2:
                    LocalShop();
                    break;
                default:
                    Console.WriteLine("Coming back");
                    break;
            }
        }

        private void ChooseEnemy()
        {
            Fight fight = new Fight();

            Console.WriteLine("Choose Enemy: " +
                    "\n1. Easy" +
                    "\n2. Medium" +
                    "\n3. Hard" +
                    "\n4. Random Difficulty" +
                    "\n0. Leave");
            int selection = GameSystem.GetInteger();

            if (selection == 4)
            {
                selection = GameSystem.GetRandMinMax(1, 3);
            }

            switch (selection)
            {
                case 1:
                    Console.WriteLine("You are going to fight Easy char");
                    fight.StartFighting(player, FindEnemyByName("Easy"));
                    break;
                case 2:
                    Console.WriteLine("You are going to fight Medium char");
                    fight.StartFighting(player, FindEnemyByName("Street"));
                    break;
                case 3:
                    Console.WriteLine("You are going to fight Hard char");
                    fight.StartFighting(player, FindEnemyByName("Pro"));
                    break;
                case 0:
                    Welcome();
                    break;
                default:
                    Console.WriteLine("Not recognized");
                    ChooseEnemy();
                    break;
            }
        }
        
        private void LocalShop()
        {
            Console.WriteLine("What would you like to buy?" +
                    "\n\t1. " + weapons[0].Name +
                    "\n\t2. " + shields[0].Name +
                    "\n\t0. Leave");
            int choice = GameSystem.GetInteger();
            switch (choice)
            {
                case 1:
                    //BuyAttributes(0);
                    LocalShop();
                    break;
                case 2:
                    //BuyAttributes(1);
                    LocalShop();
                    break;
                default:
                    Console.WriteLine("You are leaving the shop");
                    Welcome();
                    break;
            }
        }

        /*protected void BuyAttributes(int sel)
        {
            if (player.Coins >= attributes[sel].GetPrice())
            {
                if (attributes[sel].GetType().Equals("Attack"))
                {
                    player.Weapon = attributes[sel];
                    player.Attack = attributes[sel].GetDamage();
                }
                else
                {
                    player.Shield = attributes[sel];
                    player.Defense = attributes[sel].GetDefence();
                }
                player.Coins -= attributes[sel].Price;
                Console.WriteLine($"{attributes[sel].GetName()} was replaced in your inventory");
            }
            else
            {
                Console.WriteLine("You don't have enough cash");
            }
            GameSystem.PressEnter();
        }*/

        private Enemy FindEnemyByName(string reqName)
        {
            foreach (Enemy e in enemies)
                if (e.Name.Equals(reqName))
                    return e;
            return null;
        }
    }
}
