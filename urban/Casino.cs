using System;

namespace someBaseQuestRPG.urban
{
    class Casino
    {
        public Casino() { }

        public void Welcome()
        {
            GameSystem.SetHeader("Casino");
            Console.WriteLine("Hi there! It's under construction here right now, so drop by later");
            GameSystem.PressEnter();
        }
    }
}
