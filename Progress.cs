using System;

using someBaseQuestRPG.text;

namespace someBaseQuestRPG
{
    class Progress
    {
        private static bool showProgressTutorial = false;

        public static void LevelUp(Player player)
        {
            int xpNeeded = CountTotalXp(player.Level);
            if (player.Xp > xpNeeded)
            {
                // LEVEL UP
                if (!showProgressTutorial)
                {
                    Tutorial.ProgressText();
                    showProgressTutorial = true;
                }

                player.Xp -= xpNeeded;
                player.Level += 1;
                player.MaxHealth += 10;
                player.Health = player.MaxHealth;
                Console.WriteLine("***************");
                Console.WriteLine("You are now level " + player.Level + "!");
                Console.WriteLine("You receive additional " + xpNeeded / 2 + " coins!");
                Console.WriteLine("Your health raises by 10 points!");
                Console.WriteLine("***************");
                player.Coins += xpNeeded / 2;
            }
        }

        public static int CountTotalXp(int level)
        {
            int lvl = level + 1;
            return 50 * (lvl * lvl) - (50 * lvl);
        }
    }
}
