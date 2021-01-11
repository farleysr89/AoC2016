using System;
using System.IO;
using System.Linq;

namespace Day25
{
    internal class Program
    {
        private static void Main()
        {
            SolvePart1();
        }

        private static void SolvePart1()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var x = int.Parse(data[1].Split(" ")[1]) * int.Parse(data[2].Split(" ")[1]);
            var y = 0;
            while (true)
            {
                if (CheckValid(x + y)) break;
                y++;
            }
            Console.WriteLine("Solution equals " + y);
        }

        private static bool CheckValid(int x)
        {
            var prev = '\0';
            foreach (var c in Convert.ToString(x, 2))
            {
                if (prev == '\0') prev = c;
                else if (prev == c) return false;
                prev = c;
            }

            return true;
        }
    }
}
