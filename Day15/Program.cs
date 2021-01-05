using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day15
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
            var discs = new List<Disc>();
            foreach (var s in data)
            {
                var parts = s.Split(" ");
                if (s == "") continue;
                discs.Add(new Disc
                {
                    id = int.Parse(parts[1][1].ToString()),
                    numPositions = int.Parse(parts[3]),
                    position = int.Parse(parts[11].Replace(".", ""))
                });
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
    public class Disc
    {
        public int id;
        public int position;
        public int numPositions;
    }
}
