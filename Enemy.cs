using System;

namespace someBaseQuestRPG
{
    class Enemy
    {
        private string name;
        private int health;
        private int healthMax;
        private Weapon weapon;
        private Shield shield;
        private string baseWeapon;
        private int attack;
        private int defence;
        private int throwXp;

        public Enemy(string name, int health, Weapon weapon, Shield shield, int throwXp)
        {
            this.name = name;
            this.health = health;
            healthMax = health;
            this.weapon = weapon;
            this.shield = shield;
            this.throwXp = throwXp;
            attack = weapon.Damage;
            defence = shield.Defence;
        }

        public Enemy(string name, int health, string baseWeapon, int attack, int defence, int throwXp)
        {
            this.name = name;
            this.health = health;
            healthMax = health;
            this.baseWeapon = baseWeapon;
            this.attack = attack;
            this.defence = defence;
            this.throwXp = throwXp;
        }

        public void GetDetails()
        {
            Console.WriteLine("******************");
            Console.WriteLine(
                "Name: " + name +
                        "\nHealth: " + healthMax);
            Console.WriteLine((baseWeapon == null ?
                "\nCurrent Weapon: " + weapon.Name +
                        "\nCurrent Shield: " + shield.Name :
                "Attack type: " + baseWeapon));

        Console.WriteLine(
                "\nAttack: " + attack +
                "\nDefence: " + defence);
        Console.WriteLine("******************");
    }

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public int HealthMax { get => healthMax; set => healthMax = value; }
        public string BaseWeapon { get => baseWeapon; set => baseWeapon = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defence { get => defence; set => defence = value; }
        public int ThrowXp { get => throwXp; set => throwXp = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }
        public Shield Shield { get => shield; set => shield = value; }
    }
}
