using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day24
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
            int startX = 0, startY = 0;
            var y = 0;
            var maze = new List<List<char>>();
            var locations = new List<char>();
            foreach (var s in data.Where(s => s != ""))
            {
                var x = 0;
                maze.Add(new List<char>());
                foreach (var c in s)
                {
                    maze[y].Add(c);
                    if (c == '0')
                    {
                        startX = x;
                        startY = y;
                    }
                    else if (char.IsDigit(c)) locations.Add(c);

                    x++;
                }

                y++;
            }

            var minMoves = int.MaxValue;
            //foreach (var l in locations)
            //{
            //    var tmpLoc = new List<char>(locations);
            //    tmpLoc.Remove(l);
            //    minMoves = Math.Min(minMoves, RunMaze(startX, startY, l, tmpLoc, maze, minMoves, 0));
            //}
            var test = RunBFS(startX, startY, maze, locations);
            Console.WriteLine(test);
            //Console.WriteLine("Min moves = " + minMoves);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }

        private static int RunMaze(int x, int y, char nextLoc, IReadOnlyCollection<char> locations, IReadOnlyList<List<char>> maze, int minMoves, int currentMoves)
        {
            var tmpMin = int.MaxValue;
            if (CanMove(x + 1, y, maze, new List<Location>()))
                tmpMin = Math.Min(tmpMin, Move(x + 1, y, nextLoc, maze, 1, new List<Location>()));
            if (CanMove(x - 1, y, maze, new List<Location>()))
                tmpMin = Math.Min(tmpMin, Move(x - 1, y, nextLoc, maze, 1, new List<Location>()));
            if (CanMove(x, y + 1, maze, new List<Location>()))
                tmpMin = Math.Min(tmpMin, Move(x, y + 1, nextLoc, maze, 1, new List<Location>()));
            if (CanMove(x, y - 1, maze, new List<Location>()))
                tmpMin = Math.Min(tmpMin, Move(x, y - 1, nextLoc, maze, 1, new List<Location>()));
            currentMoves += tmpMin;
            foreach (var l in locations)
            {
                var tmpLoc = new List<char>(locations);
                tmpLoc.Remove(l);
                minMoves = Math.Min(minMoves, RunMaze(x, y, l, tmpLoc, maze, minMoves, currentMoves));
            }
            return minMoves;
        }

        private static int Move(int x, int y, char nextLoc, IReadOnlyList<List<char>> maze, int moveCount, IEnumerable<Location> visited)
        {
            if (moveCount > 100) return int.MaxValue;
            if (maze[y][x] == nextLoc) return moveCount;
            var tmpVisited = new List<Location>(visited) { new Location { X = x, Y = y } };
            var tmpMin = int.MaxValue;
            moveCount++;
            if (CanMove(x + 1, y, maze, tmpVisited))
                tmpMin = Math.Min(tmpMin, Move(x + 1, y, nextLoc, maze, moveCount, tmpVisited));
            if (CanMove(x - 1, y, maze, tmpVisited))
                tmpMin = Math.Min(tmpMin, Move(x - 1, y, nextLoc, maze, moveCount, tmpVisited));
            if (CanMove(x, y + 1, maze, tmpVisited))
                tmpMin = Math.Min(tmpMin, Move(x, y + 1, nextLoc, maze, moveCount, tmpVisited));
            if (CanMove(x, y - 1, maze, tmpVisited))
                tmpMin = Math.Min(tmpMin, Move(x, y - 1, nextLoc, maze, moveCount, tmpVisited));
            return tmpMin;
        }

        private static int MoveBFS(int x, int y, char nextLoc, List<List<char>> maze, List<char> locations)
        {
            var moveCount = 0;
            var tmpVisited = new List<Location>() { new Location { X = x, Y = y } };
            var state = new State
            { CurLoc = new Location { X = x, Y = y }, MoveCount = moveCount, Visited = tmpVisited };
            var states = new List<State>(GetNextStates(state, maze, nextLoc, tmpVisited));
            moveCount++;
            int lastX = 0, lastY = 0;
            while (true)
            {
                moveCount++;
                var tmpStates = new List<State>();
                foreach (var nStates in states.Select(s => GetNextStates(s, maze, nextLoc, tmpVisited)))
                {
                    tmpStates.AddRange(nStates);
                    if (tmpStates.Any(ss => ss.Finished))
                    {
                        var ss = tmpStates.First(t => t.Finished);
                        lastX = ss.CurLoc.X;
                        lastY = ss.CurLoc.Y;
                        break;
                    }
                    tmpVisited.AddRange(nStates.Select(ss => ss.CurLoc));
                }
                if (tmpStates.Any(ss => ss.Finished)) break;
                states = new List<State>(tmpStates);
            }

            if (locations.Count == 0) return moveCount;
            var minMoves = int.MaxValue;
            foreach (var l in locations)
            {
                var tmpLoc = new List<char>(locations);
                tmpLoc.Remove(l);
                minMoves = Math.Min(minMoves, moveCount + MoveBFS(lastX, lastY, l, maze, tmpLoc));
            }

            return minMoves;
        }

        private static int RunBFS(int x, int y, List<List<char>> maze, List<char> locations)
        {
            var minMoves = int.MaxValue;
            foreach (var l in locations)
            {
                var tmpLoc = new List<char>(locations);
                tmpLoc.Remove(l);
                minMoves = Math.Min(minMoves, MoveBFS(x, y, l, maze, tmpLoc));
            }
            return minMoves;
        }

        public static bool CanMove(int x, int y, IReadOnlyList<List<char>> maze, List<Location> visited)
        {
            if (x < 0 || y < 0 || x > maze[0].Count || y > maze.Count || visited.Any(l => l.X == x && l.Y == y)) return false;
            return maze[y][x] != '#';
        }

        public static List<State> GetNextStates(State s, List<List<char>> maze, char goal, List<Location> visited)
        {
            var newStates = new List<State>();
            if (CanMove(s.CurLoc.X + 1, s.CurLoc.Y, maze, visited))
                newStates.Add(new State
                {
                    CurLoc = new Location
                    {
                        X = s.CurLoc.X + 1,
                        Y = s.CurLoc.Y
                    },
                    MoveCount = s.MoveCount + 1,
                    Visited = visited.Append(new Location { X = s.CurLoc.X + 1, Y = s.CurLoc.Y }).ToList(),
                    Finished = maze[s.CurLoc.Y][s.CurLoc.X + 1] == goal
                });
            if (CanMove(s.CurLoc.X - 1, s.CurLoc.Y, maze, s.Visited))
                newStates.Add(new State
                {
                    CurLoc = new Location
                    {
                        X = s.CurLoc.X - 1,
                        Y = s.CurLoc.Y
                    },
                    MoveCount = s.MoveCount + 1,
                    Visited = visited.Append(new Location { X = s.CurLoc.X - 1, Y = s.CurLoc.Y }).ToList(),
                    Finished = maze[s.CurLoc.Y][s.CurLoc.X - 1] == goal
                });
            if (CanMove(s.CurLoc.X, s.CurLoc.Y + 1, maze, s.Visited))
                newStates.Add(new State
                {
                    CurLoc = new Location
                    {
                        X = s.CurLoc.X,
                        Y = s.CurLoc.Y + 1
                    },
                    MoveCount = s.MoveCount + 1,
                    Visited = visited.Append(new Location { X = s.CurLoc.X, Y = s.CurLoc.Y + 1 }).ToList(),
                    Finished = maze[s.CurLoc.Y + 1][s.CurLoc.X] == goal
                });
            if (CanMove(s.CurLoc.X, s.CurLoc.Y - 1, maze, s.Visited))
                newStates.Add(new State
                {
                    CurLoc = new Location
                    {
                        X = s.CurLoc.X,
                        Y = s.CurLoc.Y - 1
                    },
                    MoveCount = s.MoveCount + 1,
                    Visited = visited.Append(new Location { X = s.CurLoc.X, Y = s.CurLoc.Y - 1 }).ToList(),
                    Finished = maze[s.CurLoc.Y - 1][s.CurLoc.X] == goal
                });
            return newStates;
        }
    }

    internal class Location
    {
        internal int X;
        internal int Y;
    }

    internal class State
    {
        internal List<Location> Visited;
        internal Location CurLoc;
        internal int MoveCount;
        internal bool Finished = false;
    }
}
