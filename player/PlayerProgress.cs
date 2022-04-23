using someBaseQuestRPG.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someBaseQuestRPG.player
{
    internal class PlayerProgress
    {
        // tutorials
        private bool seenWelcome;
        private bool seenArena;
        private bool seenForest;
        private bool seenTownShop;
        private bool seenProgress;        

        public PlayerProgress()
        {
            seenWelcome = false;
            seenArena = false;
            seenForest = false;
            seenTownShop = false;
            seenProgress = false;
        }

        public void Tutorials(Player player, string tutorial)
        {
            if (tutorial == "welcome" && seenWelcome == false)
            {
                Tutorial.WelcomeText();
                seenProgress = true;
            }
            else if (tutorial == "arena" && seenArena == false)
            {
                Tutorial.ArenaText();
                seenArena = true;
            }
            else if (tutorial == "forest" && seenForest == false)
            {
                Tutorial.ForestText();
                seenForest = true;
            }
            else if (tutorial == "townshop" && seenTownShop == false)
            {
                Tutorial.TownShopText();
                seenTownShop = true;
            }
            else if (tutorial == "progress" && seenProgress == false)
            {
                Tutorial.ProgressText();
                seenProgress = true;
            }
        }

        public bool SeenWelcome { get => seenWelcome; set => seenWelcome = value; }
        public bool SeenArena { get => seenArena; set => seenArena = value; }
        private bool SeenForest { get => seenForest; set => seenForest = value; }
        public bool SeenTownShop { get => seenTownShop; set => seenTownShop = value; }
        public bool SeenProgress { get => seenProgress; set => seenProgress = value; }
    }
}
