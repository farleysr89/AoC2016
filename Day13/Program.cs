using System;
using System.Collections.Generic;
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
                    switch (x)
                    {
                        case 1 when y == 1:
                            line += "&";
                            break;
                        case 31 when y == 39:
                            line += "E";
                            break;
                        default:
                            var num = x * x + 3 * x + 2 * x * y + y + y * y + code;
                            var bin = Convert.ToString(num, 2);
                            line += bin.Count(c => c == '1') % 2 == 0 ? "-" : "#";
                            break;
                    }
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("");
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var code = int.Parse(input.Split('\n')[0]);
            var maze = new List<string>();
            for (var x = 0; x < 50; x++)
            {
                var line = "";
                for (var y = 0; y < 50; y++)
                {
                    switch (x)
                    {
                        case 1 when y == 1:
                            line += "&";
                            break;
                        case 31 when y == 39:
                            line += "E";
                            break;
                        default:
                            var num = x * x + 3 * x + 2 * x * y + y + y * y + code;
                            var bin = Convert.ToString(num, 2);
                            line += bin.Count(c => c == '1') % 2 == 0 ? "-" : "#";
                            break;
                    }
                }
                maze.Add(line);
            }

            int xx = 1, yy = 1;
            var locations = new HashSet<Move> { new Move { coords = (1, 1), count = 0 } };
            locations.UnionWith(CountMoves(xx + 1, yy, locations, 1, maze));
            locations.UnionWith(CountMoves(xx, yy + 1, locations, 1, maze));
            locations.UnionWith(CountMoves(xx - 1, yy, locations, 1, maze));
            locations.UnionWith(CountMoves(xx, yy - 1, locations, 1, maze));

            Console.WriteLine("Unique Moves = " + locations.Count);
        }

        public static HashSet<Move> CountMoves(int x, int y, HashSet<Move> moves, int moveCount, List<string> maze)
        {
            if (x < 0 || y < 0) return moves;
            if (maze[x][y] == '#') return moves;
            if (moves.Any(m => m.coords.Item1 == x && m.coords.Item2 == y))
            {
                var mm = moves.First(m => m.coords.Item1 == x && m.coords.Item2 == y);
                if (mm.count > moveCount) mm.count = moveCount;
                else return moves;
            }
            else moves.Add(new Move { coords = (x, y), count = moveCount });
            if (moveCount == 50) return moves;
            moves.UnionWith(CountMoves(x + 1, y, moves, moveCount + 1, maze));
            moves.UnionWith(CountMoves(x, y + 1, moves, moveCount + 1, maze));
            moves.UnionWith(CountMoves(x - 1, y, moves, moveCount + 1, maze));
            moves.UnionWith(CountMoves(x, y - 1, moves, moveCount + 1, maze));

            return moves;
        }
    }

    public class Move
    {
        public (int, int) coords;
        public int count;
    }
}
