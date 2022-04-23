using System;

namespace someBaseQuestRPG.travel
{
    class Valley
    {
        public void ValleyInit()
        {
            GameSystem.SetHeader("Valley");
            Welcome();
        }

        private void Welcome()
        {
            Console.WriteLine("What would you like to do here?\n" +
                "1. Leave");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    break;
                default:
                    Console.WriteLine("Misunderstood input");
                    Welcome();
                    break;
            }
        }
    }
}
