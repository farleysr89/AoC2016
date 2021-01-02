using System;
using System.IO;
using System.Linq;

namespace Day08
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
            const int height = 6;
            const int width = 50;
            var pixels = new bool[height, width];
            foreach (var parts in from s in data where s != "" select s.Split(" "))
            {
                switch (parts[0])
                {
                    case "rect":
                        {
                            var y = int.Parse(parts[1].Split("x")[0].ToString());
                            var x = int.Parse(parts[1].Split("x")[1].ToString());
                            for (var i = 0; i < x; i++)
                            {
                                for (var j = 0; j < y; j++)
                                {
                                    pixels[i, j] = true;
                                }
                            }

                            break;
                        }
                    case "rotate":
                        int count;
                        var ss = "";
                        switch (parts[1])
                        {
                            case "row":
                                var row = int.Parse(parts[2].Split("=")[1]);
                                count = int.Parse(parts[4]);
                                for (var i = 0; i < width; i++)
                                {
                                    ss += pixels[row, i] ? "1" : "0";
                                }

                                ss = Shift(ss, count);
                                for (var i = 0; i < width; i++)
                                {
                                    pixels[row, i] = ss[i] == '1';
                                }
                                break;
                            case "column":
                                var col = int.Parse(parts[2].Split("=")[1]);
                                count = int.Parse(parts[4]);
                                for (var i = 0; i < height; i++)
                                {
                                    ss += pixels[i, col] ? "1" : "0";
                                }

                                ss = Shift(ss, count);
                                for (var i = 0; i < height; i++)
                                {
                                    pixels[i, col] = ss[i] == '1';
                                }
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }

            var pixelCount = pixels.Cast<bool>().Count(b => b);
            Console.WriteLine("Total pixels = " + pixelCount);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }

        private static string Shift(string s, int count)
        {
            for (var i = 0; i < count; i++)
            {
                s = s[^1] + s[0..^1];
            }

            return s;
        }
    }
}
