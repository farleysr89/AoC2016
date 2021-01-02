using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day03
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
            var count = data.Where(s => s != "").Select(s => s.Split(" ").Where(c => c != "").Select(int.Parse).OrderBy(x => x).ToList()).Count(sides => sides[0] + sides[1] > sides[2]);
            Console.WriteLine("Valid triangles count = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var count = 0;
            for (var i = 0; i < data.Count; i += 3)
            {
                var line1 = data[i].Split(" ").Where(c => c != "").Select(int.Parse).ToList();
                var line2 = data[i + 1].Split(" ").Where(c => c != "").Select(int.Parse).ToList();
                var line3 = data[i + 2].Split(" ").Where(c => c != "").Select(int.Parse).ToList();
                var col1 = new List<int> { line1[0], line2[0], line3[0] }.OrderBy(x => x).ToList();
                var col2 = new List<int> { line1[1], line2[1], line3[1] }.OrderBy(x => x).ToList();
                var col3 = new List<int> { line1[2], line2[2], line3[2] }.OrderBy(x => x).ToList();
                if (col1[0] + col1[1] > col1[2]) count++;
                if (col2[0] + col2[1] > col2[2]) count++;
                if (col3[0] + col3[1] > col3[2]) count++;
            }
            Console.WriteLine("Valid triangles count = " + count);
        }
    }
}
