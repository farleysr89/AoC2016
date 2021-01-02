using System;
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
            var count = data.Where(s => s != "").Select(s => s.Trim().Split(" ").Where(c => c != "").Select(int.Parse).OrderBy(x => x).ToList()).Count(sides => sides[0] + sides[1] > sides[2]);
            Console.WriteLine("Valid triangles count = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
