using System;

namespace someBaseQuestRPG
{
    class Attributes
    {
        private string name;
        private string type;
        private int damage;
        private int defence;
        private int price;

        public Attributes() { }

        public Attributes(string name, string type, int damage, int defence)
        {
            this.name = name;
            this.type = type;
            this.damage = damage;
            this.defence = defence;
        }

        public Attributes(string name, string type, int damage, int defence, int price)
        {
            this.name = name;
            this.type = type;
            this.damage = damage;
            this.defence = defence;
            this.price = price;
        }

        public void ListForShop()
        {
            Console.WriteLine("Name: " + name +
                (type.Equals("Attack") ?
                        ", attack: " + damage :
                        ", defence: " + defence) +
                ", price: " + price);
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Defence { get => defence; set => defence = value; }
        public int Price { get => price; set => price = value; }
    }
}
