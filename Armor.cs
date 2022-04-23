using System;

namespace someBaseQuestRPG
{
    class Armor
    {
        private string name;
        private string partProtecting;
        private int _value;
        private int price;

        public Armor() { }

        public Armor(string name, string partProtecting, int value, int price)
        {
            this.name = name;
            this.partProtecting = partProtecting;
            _value = value;
            this.price = price;
        }

        public Armor(string name, string partProtecting, int value)
        {
            this.name = name;
            this.partProtecting = partProtecting;
            _value = value;
        }

        public void ListForShop()
        {
            Console.WriteLine($"Name: {this.name}, Defence: {_value}");
        }

        public string Name
        {
            get => name; set => name = value;
        }
        public string PartProtecting
        {
            get => partProtecting; set => partProtecting = value;
        }
        public int Value
        {
            get => _value; set => _value = value;
        }
        public int Price
        {
            get => price; set => price = value;
        }
    }
}
