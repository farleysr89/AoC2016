using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
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
            List<Dictionary<char, int>> counts = new List<Dictionary<char, int>>();
            foreach (var s in data)
            {
                if (s == "") continue;
                var index = 0;
                foreach (var c in s)
                {
                    if (counts.ElementAtOrDefault(index) == null) counts.Add(new Dictionary<char, int>());
                    if (counts[index].ContainsKey(c)) counts[index][c]++;
                    else counts[index].Add(c, 1);
                    index++;
                }
            }

            var password = counts.Aggregate("", (current, d) => current + d.First(x => x.Value == d.Max(y => y.Value)).Key);
            Console.WriteLine("Password = " + password);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
