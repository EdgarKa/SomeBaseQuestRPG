using System;

using someBaseQuestRPG.text;

namespace someBaseQuestRPG.urban
{
    class Hospital : Shop
    {
        private Player player;
        private Potion[] potion;

        public Hospital() { }

        public void HospitalInit(Player player, Potion[] potion)
        {
            this.player = player;
            this.potion = potion;

            ImportPlayer(player);
            ImportPotion(potion);
            HospitalWelcome();
        }

        private void HospitalWelcome()
        {
            GameSystem.SetHeader("Hospital");
            Console.WriteLine("What would you like to do?" +
                    "\n1. Heal" +
                    "\n2. Buy healing potions" +
                    "\n3. Chat with locals" +
                    "\n0. Leave");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    int diff = player.MaxHealth - player.Health;
                    if (diff == 0)
                    {
                        Console.WriteLine("You're perfectly fine!");
                    }
                    else
                    {
                        player.Coins -= diff;
                        Console.WriteLine($"Your health was Set to {player.MaxHealth}");
                        Console.WriteLine($"You were charged {diff} coins");
                        player.Health = player.MaxHealth;
                        HospitalWelcome();
                    }
                    HospitalWelcome();
                    break;
                case 2:
                    PotionsMenu();
                    break;
                case 3:
                    Chat();
                    break;
                case 0:
                    Console.WriteLine("Coming back");
                    Game.ShowInitialOptions();
                    break;
                default:
                    Console.WriteLine("Input is not recognized");
                    HospitalWelcome();
                    break;
            }
        }

        private void Chat()
        {
            Console.WriteLine(OneLiners.GetHospitalLine());
            GameSystem.PressEnter();
            HospitalWelcome();
        }

        protected void PotionsMenu()
        {
            HospitalWelcome();
        }
    }
}
