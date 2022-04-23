using System;
using System.IO;
using System.Collections.Generic;

namespace someBaseQuestRPG
{
    class Save
    {
        Player player;
        string dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "someBaseQuestRPG");

        public void SaveGame(Player player)
        {
            // Create folder
            DirectoryInfo di = Directory.CreateDirectory(dirPath);
            Console.WriteLine($"Full name: {di.FullName}, Name: {di.Name}, Parent: {di.Parent}");

            // Create file
            var path = $"{dirPath}\\save_{player.Name}";

            using (StreamWriter sw = new(path))
            {
                sw.WriteLine(player.Name); // Name
                sw.WriteLine(player.Level); // Level
                sw.WriteLine(player.Xp); // Xp
                sw.WriteLine(player.Coins); // Coins
                sw.WriteLine(player.Health); // Health
                sw.WriteLine(player.MaxHealth); // HealthMax
                sw.WriteLine(player.Hunger); // Hunger
                sw.WriteLine(player.Weapon.Name); // Weapon
                sw.WriteLine(player.Shield.Name); // Shield
                sw.WriteLine(player.HeadDefence.Name); // Head
                sw.WriteLine(player.TorsoDefence.Name); // Torso
                sw.WriteLine(player.WaistDefence.Name); // Waist
                sw.WriteLine(player.LegsDefence.Name); // Legs
                sw.WriteLine(player.Attack); // Attack
                sw.WriteLine(player.Defense); // Defence
                sw.WriteLine(player.Wins); // Wins
                sw.WriteLine(player.Losses); // Losses
            }

            GameSystem.ClearScreen();
            Console.WriteLine("Game successfully saved");
            GameSystem.PressEnter();
            GameSystem.ClearScreen();

            Game.ShowInitialOptions();


        }

        // TODO: work out the food. And proper Attributes. Perhaps Init in a separate file
        public void LoadGame()
        {
            GameSystem.SetHeader("Load");
            List<string> filenames = new();
            var count = 1;

            Console.WriteLine("Select one of the following saves:");

            foreach (string file in Directory.GetFiles(dirPath))
            {
                Console.WriteLine($"{count}. {Path.GetFileName(file)}");
                filenames.Add(file);
                count++;
            }

            var intSelect = GameSystem.GetInteger();

            if (intSelect > count - 1 )
            {
                Console.WriteLine("It appears you entered wrong number. Try again");
                LoadGame();
            }
            if (intSelect == 0)
            {
                Menu.MainMenu();
            }

            using (StreamReader sr = new(Path.Combine(dirPath, filenames[intSelect-1])))
            {

                if (sr == null)
                {
                    Console.WriteLine("File was not found");
                    GameSystem.PressEnter();
                    Menu.MainMenu();
                }

                player = new Player();
                Attributes Attributes = new Attributes();
                Armor armor = new Armor("empty", "Base", 0, 0);
                
                Console.WriteLine("---------");

                var lines = File.ReadAllLines(filenames[intSelect-1]);

                // name
                player.Name = lines[0];
                // level
                player.Level = Int32.Parse(lines[1]);
                // xp
                player.Xp = Int32.Parse(lines[2]);
                // coins
                player.Coins = Int32.Parse(lines[3]);
                // health
                player.Health = Int32.Parse(lines[4]);
                // healthMax
                player.MaxHealth = Int32.Parse(lines[5]);
                // hunger
                player.Hunger = Int32.Parse(lines[6]);
                // weapon
                //player.SetWeapon.Name(lines[7]);
                // shield
                //player.SetShield(lines[8]);
                // head
                //player.SetHead.(lines[9]);
                // torso
                //player.SetTorso(lines[10]);
                // waist
                //player.SetWaist(lines[11]);
                // legs
                //player.SetLegs(lines[12]);
                // attack
                //player.SetAttack(lines[13]);
                // defence
                //player.SetDe(lines[14]);
                // wins
                player.Wins = Int32.Parse(lines[15]);
                // losses
                player.Losses = Int32.Parse(lines[16]);
            }

            Console.WriteLine("---------");
            GameSystem.PressEnter();
            GameSystem.ClearScreen();

            Menu.MainMenu();
        }

        internal static Player CheckIfPlayerLoaded(Player playerToCompare)
        {
            throw new NotImplementedException();
        }
    }
}
