using System;

namespace someBaseQuestRPG.urban
{
    class Tavern
    {
        public Tavern() { }

        public void Welcome()
        {
            GameSystem.SetHeader("Tavern");
            Console.WriteLine("Hi there! It's under construction here right now, so drop by later");
            GameSystem.PressEnter();
        }
    }
}
