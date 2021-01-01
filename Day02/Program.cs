using System;
using System.IO;
using System.Linq;

namespace Day02
{
    internal static class Program
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
            var begin = 5;
            var code = "";
            foreach (var s in data)
            {
                var current = begin;
                if (s == "") continue;
                foreach (var c in s)
                {
                    switch (c)
                    {
                        case 'U':
                            if (current < 4) break;
                            current -= 3;
                            break;
                        case 'R':
                            if (current == 3 || current == 6 || current == 9) break;
                            current += 1;
                            break;
                        case 'L':
                            if (current == 1 || current == 4 || current == 7) break;
                            current -= 1;
                            break;
                        case 'D':
                            if (current > 6) break;
                            current += 3;
                            break;
                        default:
                            break;
                    }
                }
                code += current.ToString();
            }

            Console.WriteLine("Door Code is " + code);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
        }
    }
}