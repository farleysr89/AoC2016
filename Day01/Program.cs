using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01
{
    internal static class Program
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
            var moves = data[0].Split(" ").Select(s => s.Trim(',')).ToList();
            var dir = 'N';
            int x = 0, y = 0;
            foreach (var m in moves)
            {
                switch (m[0])
                {
                    case 'R':
                        switch (dir)
                        {
                            case 'N':
                                dir = 'E';
                                break;
                            case 'E':
                                dir = 'S';
                                break;
                            case 'S':
                                dir = 'W';
                                break;
                            case 'W':
                                dir = 'N';
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                return;
                        }

                        break;
                    case 'L':
                        switch (dir)
                        {
                            case 'N':
                                dir = 'W';
                                break;
                            case 'E':
                                dir = 'N';
                                break;
                            case 'S':
                                dir = 'E';
                                break;
                            case 'W':
                                dir = 'S';
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                return;
                        }
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        return;
                }

                switch (dir)
                {
                    case 'N':
                        y += int.Parse(m[1..]);
                        break;
                    case 'E':
                        x += int.Parse(m[1..]);
                        break;
                    case 'S':
                        y -= int.Parse(m[1..]);
                        break;
                    case 'W':
                        x -= int.Parse(m[1..]);
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        return;
                }
            }
            Console.WriteLine("X = " + x + " Y = " + y);
            Console.WriteLine("Total blocks = " + (Math.Abs(x) + Math.Abs(y)));
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var locs = new HashSet<(int, int)>();
                        var moves = data[0].Split(" ").Select(s => s.Trim(',')).ToList();
            var dir = 'N';
            int x = 0, y = 0;
            var found = false;
            foreach (var m in moves)
            {
                switch (m[0])
                {
                    case 'R':
                        switch (dir)
                        {
                            case 'N':
                                dir = 'E';
                                break;
                            case 'E':
                                dir = 'S';
                                break;
                            case 'S':
                                dir = 'W';
                                break;
                            case 'W':
                                dir = 'N';
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                return;
                        }

                        break;
                    case 'L':
                        switch (dir)
                        {
                            case 'N':
                                dir = 'W';
                                break;
                            case 'E':
                                dir = 'N';
                                break;
                            case 'S':
                                dir = 'E';
                                break;
                            case 'W':
                                dir = 'S';
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                return;
                        }
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        return;
                }

                var num = int.Parse((m[1..]));
                switch (dir)
                {
                    case 'N':
                        for (var i = 0; i < num; i++)
                        {
                            y += 1;
                            if (locs.Contains((x, y))) 
                            {
                                found = true;
                                break;
                            }
                            locs.Add((x, y));
                        }
                        break;
                    case 'E':
                        for (var i = 0; i < num; i++)
                        {
                            x += 1;
                            if (locs.Contains((x, y))) 
                            {
                                found = true;
                                break;
                            }
                            locs.Add((x, y));
                        }
                        break;
                    case 'S':
                        for (var i = 0; i < num; i++)
                        {
                            y -= 1;
                            if (locs.Contains((x, y))) 
                            {
                                found = true;
                                break;
                            }
                            locs.Add((x, y));
                        }
                        break;
                    case 'W':
                        for (var i = 0; i < num; i++)
                        {
                            x -= 1;
                            if (locs.Contains((x, y))) 
                            {
                                found = true;
                                break;
                            }
                            locs.Add((x, y));
                        }
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        return;
                }
                if (found) break;
            }
            Console.WriteLine("X = " + x + " Y = " + y);
            Console.WriteLine("Repeated location blocks = " + (Math.Abs(x) + Math.Abs(y)));
        }
    }
}