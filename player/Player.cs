using someBaseQuestRPG.player;
using System;
using System.Collections.Generic;

namespace someBaseQuestRPG
{
    class Player
    {
        private string name;
        private int health;
        private int maxHealth;
        private int attack;
        private int defense;
        private int coins;
        private Weapon weapon;
        private Shield shield;
        private Armor headDefence;
        private Armor torsoDefence;
        private Armor waistDefence;
        private Armor legsDefence;
        private Food[] food;
        private Potion[] potion;
        private Dictionary<string, int> potionsConsumed;
        private int hunger;
        private int hungerMax;
        private int wins;
        private int losses;
        private int xp;
        private int level;
        private PlayerProgress progress;

        public Player() { }

        public Player(string name, Weapon weapon, Shield shield, Armor armor)
        {
            this.name = name;
            this.weapon = weapon;
            this.shield = shield;
            health = 100;
            maxHealth = 100;
            coins = 1000;
            wins = 0;
            losses = 0;
            attack = weapon.Damage;
            defense = shield.Defence;
            headDefence = armor;
            torsoDefence = armor;
            waistDefence = armor;
            legsDefence = armor;
            potionsConsumed = new Dictionary<string, int>();
            xp = 0;
            level = 1;
            food = new Food[1000];
            potion = new Potion[1000];
            hunger = 100;
            hungerMax = 100;
            progress = new();
        }

        public Player(string name, int health, int maxHealth, int attack, int defense, int coins, Weapon weapon, Shield shield,
                      Armor headDefence, Armor torsoDefence, Armor waistDefence, Armor legsDefence, Food[] food, int wins, int losses,
                      int xp, int level, int hunger, int hungerMax)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = maxHealth;
            this.attack = attack;
            this.defense = defense;
            this.coins = coins;
            this.weapon = weapon;
            this.food = food;
            this.shield = shield;
            this.headDefence = headDefence;
            this.torsoDefence = torsoDefence;
            this.waistDefence = waistDefence;
            this.legsDefence = legsDefence;
            this.wins = wins;
            this.losses = losses;
            this.xp = xp;
            this.level = level;
            this.hunger = hunger;
            this.hungerMax = hungerMax;
        }

        public void GetDetails()
        {
            GameSystem.SetHeader("Player Stats");
            Console.WriteLine("******************");
            Console.WriteLine(
                    "Name: " + name +
                            "\nLevel: " + level +
                            "\nExp: " + xp + "/" + Progress.CountTotalXp(level) +
                            "\nCoins: " + coins +
                            "\nHealth: " + health + "/" + maxHealth +
                            "\nHunger: " + hunger + "/" + hungerMax +
                            "\nCurrent Weapon: " + weapon.Name +
                            "\nCurrent Shield: " + shield.Name +
                            "\nHead protection: " + headDefence.Name +
                            "\nChest protection: " + torsoDefence.Name +
                            "\nWaist protection: " + waistDefence.Name +
                            "\nLegs protection: " + legsDefence.Name +
                            "\nAttack: " + attack +
                            "\nDefence: " + defense +
                            "\nWins: " + wins +
                            "\nLosses: " + losses);
            Console.WriteLine("------------------");
            Console.WriteLine("Food:");
            foreach (Food f in food)
                if (f.Quantity > 0)
                    f.ListForPlayer();
            Console.WriteLine("------------------");
            Console.WriteLine("Potions:");
            foreach (Potion p in potion)
                p.ListForPlayer();
            Console.WriteLine("******************");
            GameSystem.PressEnter();
        }

        public Dictionary<string, int> GetPotionsConsumed()
        {
            return potionsConsumed;
        }

        public void SetPotionsConsumed(string type, int quantity)
        {
            potionsConsumed.Add(type, quantity);
        }

        public string Name
        {
            get => name; set => name = value;
        }
        public int Health
        {
            get => health; set => health = value;
        }
        public int MaxHealth
        {
            get => maxHealth; set => maxHealth = value;
        }
        public int Attack
        {
            get => attack; set => attack = value;
        }
        public int Defense
        {
            get => defense; set => defense = value;
        }
        public int Coins
        {
            get => coins; set => coins = value;
        }
        public Weapon Weapon
        {
            get => weapon; set => weapon = value;
        }
        public Shield Shield
        {
            get => shield; set => shield = value;
        }
        public Armor HeadDefence
        {
            get => headDefence; set => headDefence = value;
        }
        public Armor TorsoDefence
        {
            get => torsoDefence; set => torsoDefence = value;
        }
        public Armor WaistDefence
        {
            get => waistDefence; set => waistDefence = value;
        }
        public Armor LegsDefence
        {
            get => legsDefence; set => legsDefence = value;
        }
        public Food[] Food { get => food; }
        public Potion[] Potion
        {
            get => potion; set => potion = value;
        }
        public Food[] GetFood()
        {
            return food;
        }

        public void SetFood(Food[] food)
        {
            this.food = food;
        }

        public Potion[] GetPotion()
        {
            return potion;
        }

        public void SetPotion(Potion[] potion)
        {
            this.potion = potion;
        }
        //public Dictionary<string, int> PotionsConsumed { set; }
        public void SetPotionsConsumed(Dictionary<string, int> potionsConsumed)
        {
            this.potionsConsumed = potionsConsumed;
        }
        public int Hunger
        {
            get => hunger; set => hunger = value;
        }
        public int HungerMax
        {
            get => hungerMax; set => hungerMax = value;
        }
        public int Wins
        {
            get => wins; set => wins = value;
        }
        public int Losses
        {
            get => losses; set => losses = value;
        }
        public int Xp
        {
            get => xp; set => xp = value;
        }
        public int Level
        {
            get => level; set => level = value;
        }
    }
}
