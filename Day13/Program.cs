using System;
using System.IO;
using System.Linq;

namespace Day13
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
            var code = int.Parse(input.Split('\n')[0]);
            for (var x = 0; x < 50; x++)
            {
                var line = "";
                for (var y = 0; y < 50; y++)
                {
                    if (x == 1 && y == 1) line += "&";
                    else if (x == 31 && y == 39) line += "E";
                    else
                    {
                        int num = x * x + 3 * x + 2 * x * y + y + y * y + code;
                        var bin = Convert.ToString(num, 2);
                        line += bin.Count(c => c == '1') % 2 == 0 ? "-" : "#";
                    }
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("");
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
