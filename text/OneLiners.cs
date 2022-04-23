using System;
using System.Collections;

namespace someBaseQuestRPG.text
{
    class OneLiners
    {
        private static ArrayList lines;

        private static void HospitalLinesInit()
        {
            lines = new ArrayList();
            lines.Add("Line 1");
            lines.Add("Line 2");
            lines.Add("Line 3");
            lines.Add("Line 4");
            lines.Add("Line 5");
        }

        public static string GetHospitalLine()
        {
            HospitalLinesInit();

            int num = GameSystem.GetRandMinMax(0, lines.Count);
            return (string)lines[num];
        }
    }
}
