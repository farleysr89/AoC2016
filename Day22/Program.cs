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
            foreach (var s in data.Where(s => s != "").Where(s => s[0] == '/'))
            {
                var parts = s.Split(" ").Where(p => p != "").ToArray();
                var path = parts[0].Split('-');
                var x = int.Parse(path[1][1..]);
                var y = int.Parse(path[2][1..]);
                var size = int.Parse(parts[1][0..^1]);
                var used = int.Parse(parts[2][0..^1]);
                var available = int.Parse(parts[3][0..^1]);
                var usedPercent = int.Parse(parts[4][0..^1]);
                nodes.Add(new Node { X = x, Y = y, Size = size, Used = used, Available = available, UsedPercent = usedPercent });
            }

            var count = (from n in nodes.Where(x => x.Used > 0) from nn in nodes.Where(x => x.X != n.X || x.Y != n.Y) where n.Used <= nn.Available select n).Count();
            Console.WriteLine("Valid pairs = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var nodes = new List<Node>();
            foreach (var s in data.Where(s => s != "").Where(s => s[0] == '/'))
            {
                var parts = s.Split(" ").Where(p => p != "").ToArray();
                var path = parts[0].Split('-');
                var x = int.Parse(path[1][1..]);
                var y = int.Parse(path[2][1..]);
                var size = int.Parse(parts[1][0..^1]);
                var used = int.Parse(parts[2][0..^1]);
                var available = int.Parse(parts[3][0..^1]);
                var usedPercent = int.Parse(parts[4][0..^1]);
                nodes.Add(new Node { X = x, Y = y, Size = size, Used = used, Available = available, UsedPercent = usedPercent });
            }

            var startX = nodes.Max(n => n.X);
            var startY = 0;
            var goalX = 0;
            var goalY = 0;
            var print = "";
            int dataSize = nodes.First(n => n.X == startX && n.Y == startY).Used;
            int currY = 0;
            var maxFree = nodes.Max(n => n.Available);
            nodes = nodes.OrderBy(n => n.Y).ThenBy(n => n.X).ToList();
            foreach (var n in nodes)
            {
                if (n.Y != currY)
                {
                    currY++;
                    Console.WriteLine(print);
                    print = "";
                }

                print += n.Used > maxFree ? "#" : dataSize > n.Available ? "|" : "_";
            }
            //var count = (from n in nodes.Where(x => x.Used > 0) from nn in nodes.Where(x => x.X != n.X || x.Y != n.Y) where n.Used <= nn.Available select n).Count();
            //Console.WriteLine("Valid pairs = " + count);
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
