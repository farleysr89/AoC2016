using System;
using System.IO;
using System.Linq;

namespace Day07
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
            var count = 0;
            foreach (var s in data)
            {
                if (s == "") continue;

            }
            Console.WriteLine("");
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }

        private static bool Check(string s)
        {
            if (s[0] == s[3] && s[1] == s[2] && s[0] != s[1]) return true;
            return false;
        }
    }
}
