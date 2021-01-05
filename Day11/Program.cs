using System;
using System.IO;
using System.Linq;

namespace Day11
{
    internal class Program
    {
        private static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        private static void SolvePart1()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var itemCount = 0;
            var moveCount = 0;
            int floor = 1;
            foreach (var s in data)
            {
                if (s == "" || floor == 4) continue;
                var parts = s.Replace(",", "").Replace(".", "").Split((" "));
                itemCount += parts.Count(x => x == "generator" || x == "microchip");
                moveCount += itemCount * 2 - 3;
                floor++;
            }
            Console.WriteLine("Minimum moves = " + moveCount);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var itemCount = 0;
            var moveCount = 0;
            int floor = 1;
            foreach (var s in data)
            {
                if (s == "" || floor == 4) continue;
                if (floor == 1) itemCount += 4;
                var parts = s.Replace(",", "").Replace(".", "").Split((" "));
                itemCount += parts.Count(x => x == "generator" || x == "microchip");
                moveCount += itemCount * 2 - 3;
                floor++;
            }
            Console.WriteLine("Minimum moves = " + moveCount);
        }
    }
}
