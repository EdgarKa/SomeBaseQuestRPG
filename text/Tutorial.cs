using System;

namespace someBaseQuestRPG.text
{
    class Tutorial
    {
        public void ReceiveValue(int i)
        {
            switch (i)
            {
                case 1:
                    WelcomeText();
                    break;
                case 2:
                    ArenaText();
                    break;
                case 3:
                    ForestText();
                    break;
                case 4:
                    TownShopText();
                    break;
                case 5:
                    ProgressText();
                    break;
                default:
                    Console.WriteLine("There's nothing more");
                    break;
            }
        }

        public static void WelcomeText()
        {
            Console.WriteLine("\t*** Campaign - Start ***" +
                    "\n| You appear here, in this small, unknown village. You're free     |" +
                    "\n| to explore around. You can go to shop and buy food, potions      |" +
                    "\n| weapons and shields. You can go to the arena and fight enemies   |" +
                    "\n| there with a simple combat. Or you can go to the forest, fight   |" +
                    "\n| creatures there. It's not too muh to explore right now, but the  |" +
                    "\n| world will be populated with more stuff that you can do. Enjoy!  |");
        }

        public static void ArenaText()
        {
            Console.WriteLine("*** Tutorial - Arena ***" +
                    "\nWelcome to the arena! Here you can fight 3 types of enemies" +
                    "\nor explore the local shop for some cheap threads.");
            GameSystem.PressEnter();
        }

        public static void ForestText()
        {
            Console.WriteLine("*** Tutorial - Forest ***" +
                    "\nWelcome to the forest! There's couple of creatures you can" +
                    "\nfight, or get some free food if you wish.");
            GameSystem.PressEnter();
        }

        public static void TownShopText()
        {
            Console.WriteLine("*** Tutorial - Town Shop ***" +
                    "\nWelcome to the town shop! Here you can buy food, potions," +
                    "\nweapon and shields. Only best stuff for the right price!");
            GameSystem.PressEnter();
        }

        public static void ProgressText()
        {
            Console.WriteLine("*** Tutorial - Progress ***" +
                    "\nYou've gained enough experience, so you level up. You'll" +
                    "\nbe getting some coins and your health will be raised.");
            GameSystem.PressEnter();
        }
    }
}
