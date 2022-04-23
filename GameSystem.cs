using System;

namespace someBaseQuestRPG
{
    class GameSystem
    {

        public static int GetRandNumber()
        {
            Random random = new();
            return random.Next(100);
        }

        public static int GetRandMinMax(int min, int max)
        {
            Random random = new();
            return random.Next(max - min) + min;
        }

        public static int GetInteger()
        {
            bool numberFormatCorrect = false;
            int value;
            do
            {
                Console.Write("Your input: ");
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("That was invalid. Enter the number.");
                }
                else numberFormatCorrect = true;

            } while (!numberFormatCorrect);

            Console.Clear();
            return value;
        }

        public static string GetString()
        {
            return Console.ReadLine();
        }

        public static void PressEnter()
        {
            Console.Write("Press Enter to continue...");
            string input = Console.ReadLine();
            if (!(string.IsNullOrWhiteSpace(input)))
                PressEnter();
            Console.Clear();
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void SetHeaderForPlayer(string location, Player player)
        {
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine(location + "\n");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Name {player.Name}");
            Console.WriteLine($"HP {player.Health}/{player.MaxHealth}, Hunger {player.Hunger}/{player.HungerMax} {player.Coins} Coins");
            Console.WriteLine("------------------------------------------------");
        }

        public static void SetHeader(string location)
        {
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine(location + "\n");
            Console.WriteLine("------------------------------------------------");
        }
        // Console.WriteLine("HP {0}/{1}, Hunger {2}/{3} {4} Coins", 
        //player.Health, player.MaxHealth, player.Hunger, player.HungerMax, player.Coins);
    }
}
