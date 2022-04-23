using System;
using System.Threading;

namespace someBaseQuestRPG
{
    class Fight
    {
        private Player player;
        private Enemy enemy;

        public Fight() { }


        public void StartFighting(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;

            Fighting();
        }

        private void Fighting()
        {
            bool process = true;
            bool ifPlayerIsHitting = true;
            enemy.Health = enemy.HealthMax;

            Console.WriteLine("************");
            if (player.GetPotionsConsumed().ContainsKey("attackBoost"))
                Console.WriteLine("You have attack boost");
            if (player.GetPotionsConsumed().ContainsKey("defenceBoost"))
                Console.WriteLine("You have defence boost");
            Console.WriteLine("************");

            while (process)
            {
                if (ifPlayerIsHitting)
                {
                    Console.WriteLine("Your turn. Select where to hit:" +
                            "\n1. Head" +
                            "\n2. Torso" +
                            "\n3. Waist" +
                            "\n4. Legs" +
                            "\n0. Run Away");
                    int answer = GameSystem.GetInteger();

                    if (answer == 0)
                    {
                        Console.WriteLine("Are you sure? (y/n)");
                        string ans = GameSystem.GetString();
                        if (ans.Equals("y") || ans.Equals("Y"))
                        {
                            process = false;
                            PlayerLost();
                        }
                        continue;
                    }
                    CalculateDamageForEnemy(answer);
                    ifPlayerIsHitting = false;

                }
                else
                {
                    Console.WriteLine("Enemy is attacking now");
                    CalculateDamageForPlayer();

                    ifPlayerIsHitting = true;
                }
                Console.WriteLine($"You {player.Health}, Enemy: {enemy.Health}");

                if (enemy.Health <= 0)
                {
                    PlayerWon();
                    process = false;
                    continue;
                }
                else if (player.Health <= 0)
                {
                    PlayerLost();
                    process = false;
                }

                Thread.Sleep(1000);

            }

            if (player.GetPotionsConsumed().ContainsKey("attackBoost"))
                player.Attack -= player.GetPotionsConsumed()["attackBoost"];
            if (player.GetPotionsConsumed().ContainsKey("defenceBoost"))
                player.Defense -= player.GetPotionsConsumed()["defenceBoost"];

            Progress.LevelUp(player);

            Game.ShowInitialOptions();
        }

        private void CalculateDamageForEnemy(int answer)
        {
            int damage = enemy.Health - CalculateDamageByWeapon(answer, player.Attack, enemy.Defence);
            if (damage < 0)
                damage = 0;
            Console.WriteLine($"You hit enemy and give {(enemy.Health - damage)}  damage");
            enemy.Health = damage;
        }

        private void CalculateDamageForPlayer()
        {
            int damage = player.Health - CalculateDamageByWeapon(1, enemy.Attack, player.Defense);
            Console.WriteLine($"Enemy hit you and gave you {player.Health - damage} damage");
            player.Health = damage;
        }

        private static int CalculateDamageByWeapon(int answer, double damage, double defence)
        {
            int bodyPartDmg = 0;
            double realDamage = damage * damage / (damage + defence);
            switch (answer)
            {
                case 1:
                    bodyPartDmg = GameSystem.GetRandMinMax(-1, 1);
                    break;
                case 2:
                    bodyPartDmg = GameSystem.GetRandMinMax(0, 2);
                    break;
                case 3:
                    bodyPartDmg = GameSystem.GetRandMinMax(0, 3);
                    break;
                case 4:
                    bodyPartDmg = GameSystem.GetRandMinMax(0, 4);
                    break;
                default:
                    Console.WriteLine("Misunderstood value! Try again");
                    break;
            }
            return (int)realDamage - bodyPartDmg;
        }

        private void PlayerWon()
        {
            Console.WriteLine("You won!");
            Console.WriteLine($"You've got {enemy.ThrowXp} xp");
            player.Wins++;
            player.Xp += enemy.ThrowXp;
            double newAtk = enemy.Attack * 1.25;
            double newDef = enemy.Defence * 1.25;
            enemy.HealthMax += 15;
            enemy.Attack = (int)newAtk;
            enemy.Defence = (int)newDef;
        }

        private void PlayerLost()
        {
            player.Xp += enemy.ThrowXp / 2;
            Console.WriteLine("You lost!");
            Console.WriteLine($"You've got {enemy.ThrowXp / 2} xp");
            player.Losses++;
        }
    }
}
