using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils = Utilities.Utils;

namespace Day17
{
    internal class Program
    {
        const string ValidChars = "bcdef";
        private static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        private static void SolvePart1()
        {
            var input = File.ReadAllText("Input.txt");
            // ReSharper disable once StringLiteralTypo

            var passcode = input.Split('\n')[0];
            const int x = 0;
            const int y = 0;
            const int destX = 3;
            const int destY = 3;
            var s = Utils.GetHash(passcode)[0..4];
            var solutions = new List<string>();
            if (ValidChars.Contains(s[1]))
            {
                solutions.AddRange(Solve(x, y + 1, destX, destY, passcode + "D"));
            }
            if (ValidChars.Contains(s[3]))
            {
                solutions.AddRange(Solve(x + 1, y, destX, destY, passcode + "R"));
            }
            Console.WriteLine("Shortest Path is " + solutions.OrderBy(p => p.Length).First()[passcode.Length..]);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var passcode = input.Split('\n')[0];
            const int x = 0;
            const int y = 0;
            const int destX = 3;
            const int destY = 3;
            var s = Utils.GetHash(passcode)[0..4];
            var solutions = new List<string>();
            if (ValidChars.Contains(s[1]))
            {
                solutions.AddRange(Solve(x, y + 1, destX, destY, passcode + "D"));
            }
            if (ValidChars.Contains(s[3]))
            {
                solutions.AddRange(Solve(x + 1, y, destX, destY, passcode + "R"));
            }
            Console.WriteLine("Shortest Path is " + solutions.OrderByDescending(p => p.Length).First()[passcode.Length..].Length);
        }

        private static IEnumerable<string> Solve(int x, int y, int destX, int destY, string passcode)
        {
            if (x == destX && y == destY)
            {
                return new List<string> { passcode };
            }
            var solutions = new List<string>();
            var s = Utils.GetHash(passcode)[0..4];
            if (y > 0 && ValidChars.Contains(s[0]))
            {
                solutions.AddRange(Solve(x, y - 1, destX, destY, passcode + "U"));
            }
            if (y < destY && ValidChars.Contains(s[1]))
            {
                solutions.AddRange(Solve(x, y + 1, destX, destY, passcode + "D"));
            }
            if (x > 0 && ValidChars.Contains(s[2]))
            {
                solutions.AddRange(Solve(x - 1, y, destX, destY, passcode + "L"));
            }
            if (x < destX && ValidChars.Contains(s[3]))
            {
                solutions.AddRange(Solve(x + 1, y, destX, destY, passcode + "R"));
            }
            return solutions;
        }
    }
}
