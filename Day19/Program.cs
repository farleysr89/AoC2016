using System;
using System.IO;

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
            Console.WriteLine("Winner = " + GetSafePosition(elves));
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var elves = int.Parse(input.Split('\n')[0]);
            Console.WriteLine("Winner = " + GetSafePosition2(elves));
        }
        private static int GetSafePosition(int n)
        {
            var binary = Convert.ToString(n, 2); ;
            binary = binary[1..] + binary[0];
            return Convert.ToInt32(binary, 2);
        }
        private static int GetSafePosition2(int n)
        {
            var l = (int)Math.Log(n, 3);
            var e = (int)Math.Pow(3, l);
            var r = n - e;
            return r > e * 2 ? r * 2 : r;
        }
    }
}
