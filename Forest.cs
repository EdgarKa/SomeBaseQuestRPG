using System;

namespace someBaseQuestRPG
{
    class Forest
    {
        private Player player;
        private Enemy spider;
        private Enemy wolf;
        private Food[] food;

        public Forest() { }

        public void InitForest(Player player, Enemy spider, Enemy wolf, Food[] food)
        {
            this.spider = spider;
            this.player = player;
            this.wolf = wolf;
            this.food = food;
            GameSystem.SetHeader("Forest");

            Welcome();
        }

        private void Welcome()
        {

            Console.WriteLine("Select from the following options:" +
                    "\n\t1. Find food" +
                    "\n\t2. Fight Enemies" +
                    "\n\t0. Go back");

            int choice = GameSystem.GetInteger();

            switch (choice)
            {
                case 1:
                    FindFood();
                    break;
                case 2:
                    ChooseEnemy();
                    break;
                default: 
                    GameSystem.ClearScreen();
                    Game.ShowInitialOptions();
                    break;
            }
        }

        private void FindFood()
        {
            int prob = GameSystem.GetRandNumber();
            if (prob > 90)
            {
                Console.WriteLine("You've got lucky and got 26 Berries!");
                food[3].Quantity += 26;
                
            }
            else if (prob >= 40)
            {
                int qnt = GameSystem.GetRandMinMax(1, 3);
                Console.WriteLine($"You found: {qnt} berries");
                food[3].Quantity += qnt;
            }
            else
            {
                Console.WriteLine("You didn't find anything");
            }
            Welcome();
        }

        private void ChooseEnemy()
        {
            Fight fight = new Fight();
            Console.WriteLine("Choose Enemy: " +
                    "\n1. Spider" +
                    "\n2. Wolf" +
                    "\n3. Random Difficulty" +
                    "\n0. Leave");
            int selection = GameSystem.GetInteger();

            if (selection == 3)
            {
                selection = GameSystem.GetRandMinMax(1, 3);
            }

            switch (selection)
            {
                case 1:
                    Console.WriteLine("You are going to fight a spider");
                    fight.StartFighting(player, spider);
                    break;
                case 2:
                    Console.WriteLine("You are going to fight a wolf");
                    fight.StartFighting(player, wolf);
                    break;
                case 0:
                    Game.ShowInitialOptions();
                    break;
                default:
                    Console.WriteLine("Not recognized");
                    ChooseEnemy();
                    break;
            }
        }
    }
}
