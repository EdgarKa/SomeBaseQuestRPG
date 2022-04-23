using System;
using System.Collections.Generic;

namespace someBaseQuestRPG
{
    class PlayerOptions
    {
        private Player player;
        private Food[] food;
        private Potion[] potions;

        Dictionary<int, Food> foodMap = new Dictionary<int, Food>();
        Dictionary<int, Potion> potionsMap = new Dictionary<int, Potion>();

        public PlayerOptions() {  }

        public void PlayerOptionsInit(Player player, Food[] food, Potion[] potions)
        {
            this.player = player;
            this.food = food;
            this.potions = potions;
            ShowPlayerOptions();
        }

        private void ShowPlayerOptions()
        {
            GameSystem.SetHeaderForPlayer("Player Menu", player);
            Console.WriteLine("Select from the following options:" +
                    "\n\t1. Show Stats" +
                    "\n\t2. Show Inventory" +
                    "\n\t3. Consume food" +
                    "\n\t4. Consume potion" +
                    "\n\t0. Leave");

            int choice = GameSystem.GetInteger();
            switch (choice)
            {
                case 1:
                    player.GetDetails();
                    ShowPlayerOptions();
                    break;
                case 2:
                    Console.WriteLine("There's nothing in your inventory");
                    GameSystem.PressEnter();
                    ShowPlayerOptions();
                    break;
                case 3:
                    ConsumeFood();
                    ShowPlayerOptions();
                    break;
                case 4:
                    ConsumePotion();
                    Console.WriteLine("*******************");
                    ShowPlayerOptions();
                    break;
                case 0:
                    Game.ShowInitialOptions();
                    break;
                default:
                    Console.WriteLine("Not recognized");
                    ShowPlayerOptions();
                    break;
            }
        }

        private void ConsumePotion()
        {
            int i = 0;
            foreach (Potion p in potions)
            {
                if (p.Quantity > 0)
                {
                    i++;
                    Console.WriteLine(i + ". ");
                    p.ListForPlayer();
                    potionsMap.Add(i, p);
                }
            }
            if (i == 0)
            {
                Console.WriteLine("You don't have any potions");
                GameSystem.PressEnter();
                ShowPlayerOptions();
            }

            Console.WriteLine("Which potion would you like?");
            int x = GameSystem.GetInteger();

            //reduce potion by 1
            potionsMap[x].Quantity--;

            //apply effect
            int quantity = potionsMap[x].EffectPoints;
            switch (potionsMap[x].Effect)
            {
                case "heal":
                    player.Health += quantity;
                    if (player.Health > player.MaxHealth)
                        player.Health = player.MaxHealth;
                    break;
                case "attackBoost":
                    player.Attack += quantity;
                    Console.WriteLine("You consumed attack boost potion");
                    player.SetPotionsConsumed("attackBoost", quantity);
                    break;
                case "defenceBoost":
                    player.Defense += quantity;
                    Console.WriteLine("You consumed defence boost potion");
                    player.SetPotionsConsumed("defenceBoost", quantity);
                    break;
                default:
                    Console.WriteLine("Nothing");
                    break;
            }
        }

        private void ConsumeFood()
        {
            int i = 0;
            foreach (Food f in food)
                if (f.Quantity > 0)
                {
                    i++;
                    Console.Write(i + ". ");
                    f.ListForPlayer();
                    foodMap.Add(i, f);
                }
            if (i == 0)
            {
                Console.WriteLine("You don't have any food");
                GameSystem.PressEnter();
                ShowPlayerOptions();
            }

            Console.WriteLine("What would you like to eat?");
            int x = GameSystem.GetInteger();

            //reduce food by 1
            foodMap[x].Quantity--;

            // replenish hunger
            player.Hunger += foodMap[x].Hunger;
            if (player.Hunger > player.HungerMax)
                player.Hunger = player.HungerMax;

            // replenish health
            player.Health += foodMap[x].Heal;
            if (player.Health > player.MaxHealth)
                player.Health = player.MaxHealth;

            foodMap[x].Consume();
            Console.WriteLine("*******************");
        }
    }
}
