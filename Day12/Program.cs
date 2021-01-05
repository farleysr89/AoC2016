using System;
using System.IO;
using System.Linq;

namespace Day12
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
            var data = input.Split('\n');
            int a = 0, b = 0, c = 0, d = 0, index = 0;
            while (true)
            {
                var s = data[index];
                if (s == "") break;
                var parts = s.Split(" ");
                switch (parts[0])
                {
                    case "cpy":
                        if (int.TryParse(parts[1], out var i))
                        {
                            switch (parts[2][0])
                            {
                                case 'a':
                                    a = i;
                                    break;
                                case 'b':
                                    b = i;
                                    break;
                                case 'c':
                                    c = i;
                                    break;
                                case 'd':
                                    d = i;
                                    break;
                                default:
                                    Console.WriteLine("Something Broke!");
                                    break;
                            }
                        }
                        else
                        {
                            var x = 0;
                            switch (parts[1][0])
                            {
                                case 'a':
                                    x = a;
                                    break;
                                case 'b':
                                    x = b;
                                    break;
                                case 'c':
                                    x = c;
                                    break;
                                case 'd':
                                    x = d;
                                    break;
                                default:
                                    Console.WriteLine("Something Broke!");
                                    break;
                            }
                            switch (parts[2][0])
                            {
                                case 'a':
                                    a = x;
                                    break;
                                case 'b':
                                    b = x;
                                    break;
                                case 'c':
                                    c = x;
                                    break;
                                case 'd':
                                    d = x;
                                    break;
                                default:
                                    Console.WriteLine("Something Broke!");
                                    break;
                            }
                        }

                        break;
                    case "inc":
                        switch (parts[1][0])
                        {
                            case 'a':
                                a++;
                                break;
                            case 'b':
                                b++;
                                break;
                            case 'c':
                                c++;
                                break;
                            case 'd':
                                d++;
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }
                        break;
                    case "dec":
                        switch (parts[1][0])
                        {
                            case 'a':
                                a--;
                                break;
                            case 'b':
                                b--;
                                break;
                            case 'c':
                                c--;
                                break;
                            case 'd':
                                d--;
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }
                        break;
                    case "jnz":
                        var y = int.Parse(parts[2]) - 1;
                        if (int.TryParse(parts[1], out var h))
                        {
                            if (h == 0) continue;
                            index += y;
                        }
                        else
                        {
                            switch (parts[1][0])
                            {
                                case 'a':
                                    if (a != 0) index += y;
                                    break;
                                case 'b':
                                    if (b != 0) index += y;
                                    break;
                                case 'c':
                                    if (c != 0) index += y;
                                    break;
                                case 'd':
                                    if (d != 0) index += y;
                                    break;
                                default:
                                    Console.WriteLine("Something Broke!");
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        return;
                }

                index++;
            }
            Console.WriteLine("value in a = " + a);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
