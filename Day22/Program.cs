using System;
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
            var nodes = (from s in data.Where(s => s != "").Where(s => s[0] == '/')
                         select s.Split(" ").Where(p => p != "").ToArray()
            into parts
                         let path = parts[0].Split('-')
                         let x = int.Parse(path[1][1..])
                         let y = int.Parse(path[2][1..])
                         let size = int.Parse(parts[1][0..^1])
                         let used = int.Parse(parts[2][0..^1])
                         let available = int.Parse(parts[3][0..^1])
                         let usedPercent = int.Parse(parts[4][0..^1])
                         select new Node
                         {
                             X = x,
                             Y = y,
                             Size = size,
                             Used = used,
                             Available = available,
                             UsedPercent = usedPercent
                         }).ToList();

            var count = (from n in nodes.Where(x => x.Used > 0) from nn in nodes.Where(x => x.X != n.X || x.Y != n.Y) where n.Used <= nn.Available select n).Count();
            Console.WriteLine("Valid pairs = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var nodes = (from s in data.Where(s => s != "").Where(s => s[0] == '/')
                         select s.Split(" ").Where(p => p != "").ToArray()
            into parts
                         let path = parts[0].Split('-')
                         let x = int.Parse(path[1][1..])
                         let y = int.Parse(path[2][1..])
                         let size = int.Parse(parts[1][0..^1])
                         let used = int.Parse(parts[2][0..^1])
                         let available = int.Parse(parts[3][0..^1])
                         let usedPercent = int.Parse(parts[4][0..^1])
                         select new Node
                         {
                             X = x,
                             Y = y,
                             Size = size,
                             Used = used,
                             Available = available,
                             UsedPercent = usedPercent
                         }).ToList();

            var startX = nodes.Max(n => n.X);
            const int startY = 0;
            var print = "";
            var dataSize = nodes.First(n => n.X == startX && n.Y == startY).Used;
            var currY = 0;
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
