using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using someBaseQuestRPG.text;

namespace someBaseQuestRPG
{
    class Menu
    {
        public static void MainMenu()
        {

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|       Some Base Text RPG        |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("\n\nSelect from the following options:" +
                    "\n\t1. New Game" +
                    "\n\t2. Load Game" +
                    "\n\t3. Tutorial" +
                    "\n\t4. Leave");

            int choice = GameSystem.GetInteger();
            switch (choice)
            {
                case 1:
                    Game.Start();
                    break;
                case 2:
                    Save save = new();
                    save.LoadGame();
                    MainMenu();
                    break;
                case 3:
                    Tutorial.WelcomeText();
                    GameSystem.PressEnter();
                    Console.Clear();
                    MainMenu();
                    break;
                case 4:
                    CheckToLeave();
                    break;
                default:
                    Console.WriteLine("Misunderstood output");
                    GameSystem.PressEnter();
                    MainMenu();
                    break;
            }
        }

        private static void CheckToLeave()
        {
            Console.WriteLine("Are you sure you want to leave? All your progress will not be saved (y/n)");
            string ans = GameSystem.GetString();

            if (ans.Equals("n"))
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("You've decided to leave");
                Environment.Exit(0);
            }
        }
    }
}
