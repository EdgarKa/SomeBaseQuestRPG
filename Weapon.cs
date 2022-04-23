using System;

namespace someBaseQuestRPG
{
    class Weapon
    {
        private string name;
        private int damage;
        private int price;

        public Weapon() { }

        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public Weapon(string name, int damage, int price)
        {
            this.name = name;
            this.damage = damage;
            this.price = price;
        }

        public string Name { get => name; set => name = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Price { get => price; set => price = value; }

        public void ListForShop()
        {
            Console.WriteLine($"{name} -> Attack: {damage}, Price: {price}");
        }
    }
}
