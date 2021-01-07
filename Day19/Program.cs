using System;
using System.IO;
using System.Linq;

namespace Day19
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
            var elves = int.Parse(input.Split('\n')[0]);
            Console.WriteLine(getSafePosition(elves));
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
        private static int getSafePosition(int n)
        {
            var binary = Convert.ToString(n, 2); ;
            binary = binary[1..] + binary[0];
            return Convert.ToInt32(binary, 2);
        }
    }
}
