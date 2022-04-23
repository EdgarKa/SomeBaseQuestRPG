using System;

namespace someBaseQuestRPG
{
    class Potion
    {
        private string name;
        private string description;
        private int quantity;
        private int price;
        private string effect;
        private int effectPoints;

        public Potion(string name, string description, int price, string effect, int effectPoints)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.effect = effect;
            this.effectPoints = effectPoints;
        }

        public void ListForPlayer()
        {
            if (this.quantity > 0)
                Console.WriteLine($"{name}" +
                    $"\n\tQuantity: {quantity}" +
                    $"\n\tEffect: {effect}" +
                    $"\n\tPoints: {effectPoints}" +
                    $"\n\tDescription: {description}");
        }

        public void ListForShop()
        {
            Console.WriteLine($"{name} -> Effect type: {effect}, Points: {effectPoints}, Description: {description}");
        }

        public string Name { get => name; }
        public string Effect { get => effect; }
        public int EffectPoints { get => effectPoints; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Price { get => price; }
    }
}
