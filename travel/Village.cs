using System;

namespace someBaseQuestRPG.travel
{
    class Village
    {
        public void VillageInit()
        {
            Console.WriteLine("Welcome to the Village");
            Welcome();
        }

        private void Welcome()
        {
            Console.WriteLine("What would you like to do here?" +
                "1. Leave");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    Game.ShowInitialOptions();
                    break;
                default:
                    Console.WriteLine("Misunderstood input");
                    Welcome();
                    break;
            }
        }
    }
}
