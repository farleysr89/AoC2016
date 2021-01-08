using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day22
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
            var nodes = new List<Node>();
            foreach (var s in data.Where(s => s[0] == '/'))
            {
                var parts = s.Split(" ");
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

    internal class Node
    {
        public int X;
        public int Y;
        public int Size;
        public int Used;
        public int Available;
        public int UsedPercent;
    }
}
