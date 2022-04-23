using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someBaseQuestRPG
{
    class Food
    {
        private string name;
        private string description;
        private int quantity;
        private int price;
        private int hunger;
        private int heal;

        public Food(string name, string description, int price, int hunger, int heal)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.hunger = hunger;
            this.heal = heal;
        }

        // what player keeps
        public Food(string name, int quantity, int hunger, int heal)
        {
            this.name = name;
            this.quantity = quantity;
            this.hunger = hunger;
            this.heal = heal;
        }

        public void ListForPlayer()
        {
            Console.WriteLine($"{name}" +
                $"\n\tQuantity: {quantity}" +
                $"\n\tHunger: {hunger} " +
                $"\n\tHeal: {heal}" +
                $"\n\tDescription: {description}");
        }

        public void ListForShop()
        {
            Console.WriteLine($"{name} -> Hunger: {hunger}, Heal: {heal}, Description: {description}");
        }

        public void Consume()
        {
            Console.WriteLine($"You've eaten {name}. You Healed {heal} hp and restored {hunger} points of hunger");
        }

        public string Name { get => name; }
        public int Hunger { get => hunger; }
        public int Heal { get => heal; }
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
        public int Price { get => price; }
    }
}
