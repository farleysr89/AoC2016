using System;
using System.IO;
using System.Linq;
using System.Text;
using static Utilities.Utils;

namespace Day21
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
            var pass = new StringBuilder("abcdefgh");
            foreach (var s in data.Where(s => s != ""))
            {
                var parts = s.Split(" ");
                var oldPass = pass.ToString();
                int x, y;
                char a;
                switch (parts[0])
                {
                    case "swap":
                        char b;
                        switch (parts[1])
                        {
                            case "position":
                                x = int.Parse(parts[2]);
                                y = int.Parse(parts[5]);
                                a = pass[x];
                                b = pass[y];
                                pass[x] = b;
                                pass[y] = a;
                                break;
                            case "letter":
                                a = parts[2][0];
                                b = parts[5][0];
                                x = pass.ToString().IndexOf(a);
                                y = pass.ToString().IndexOf(b);
                                pass[x] = b;
                                pass[y] = a;
                                break;
                            default:
                                Console.WriteLine("Something broke!");
                                break;
                        }
                        break;
                    case "rotate":
                        switch (parts[1])
                        {
                            case "left":
                                pass = new StringBuilder(ShiftLeft(pass.ToString(), int.Parse(parts[2])));
                                break;
                            case "right":
                                pass = new StringBuilder(ShiftRight(pass.ToString(), int.Parse(parts[2])));
                                break;
                            case "based":
                                a = parts[6][0];
                                x = pass.ToString().IndexOf(a);
                                pass = new StringBuilder(ShiftRight(pass.ToString(), x > 3 ? 2 + x : 1 + x));
                                break;
                            default:
                                Console.WriteLine("Something broke!");
                                break;
                        }

                        break;
                    case "reverse":
                        x = int.Parse(parts[2]);
                        y = int.Parse(parts[4]);
                        pass = new StringBuilder(pass.ToString(0, x) + Reverse(pass.ToString(x, y - x + 1)) + pass.ToString(y + 1, pass.Length - y - 1));
                        break;
                    case "move":
                        x = int.Parse(parts[2]);
                        y = int.Parse(parts[5]);
                        a = pass[x];
                        pass = new StringBuilder(pass.ToString(0, x) + pass.ToString(x + 1, pass.Length - (x + 1)));
                        pass = y == pass.Length ? pass.Append(a) : y == 0 ? new StringBuilder(a + pass.ToString()) : new StringBuilder(pass.ToString(0, y) + a + pass.ToString(y, pass.Length - y));
                        break;
                    default:
                        Console.WriteLine("Something broke!");
                        break;
                }
            }
            Console.WriteLine("Scrambled password is " + pass);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
