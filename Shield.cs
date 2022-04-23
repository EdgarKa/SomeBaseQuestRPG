using System;

namespace someBaseQuestRPG
{
    class Shield
    {
        private string name;
        private int defence;
        private int price;

        public Shield() { }

        public Shield(string name, int defence)
        {
            this.name = name;
            this.defence = defence;
        }

        public Shield(string name, int defence, int price)
        {
            this.name = name;
            this.defence = defence;
            this.price = price;
        }

        public string Name { get => name; set => name = value; }
        public int Defence { get => defence; set => defence = value; }
        public int Price { get => price; set => price = value; }

        public void ListForShop()
        {
            Console.WriteLine($"{name} -> Defence:  {defence}, Price: {price}");
        }
    }
}
