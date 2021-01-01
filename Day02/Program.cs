using System;
using System.IO;
using System.Linq;

namespace Day02
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
            const int begin = 5;
            var code = "";
            var current = begin;
            foreach (var s in data.Where(s => s != ""))
            {
                foreach (var c in s)
                {
                    switch (c)
                    {
                        case 'U':
                            if (current < 4) break;
                            current -= 3;
                            break;
                        case 'R':
                            if (current == 3 || current == 6 || current == 9) break;
                            current += 1;
                            break;
                        case 'L':
                            if (current == 1 || current == 4 || current == 7) break;
                            current -= 1;
                            break;
                        case 'D':
                            if (current > 6) break;
                            current += 3;
                            break;
                    }
                }
                code += current.ToString();
            }

            Console.WriteLine($"Door Code is {code}");
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            const char begin = '5';
            var code = "";
            var current = begin;
            foreach (var s in data.Where(s => s != ""))
            {
                foreach (var c in s)
                {
                    switch (c)
                    {
                        case 'U':
                            switch (current)
                            {
                                case '3':
                                    current = '1';
                                    break;
                                case '6':
                                    current = '2';
                                    break;
                                case '7':
                                    current = '3';
                                    break;
                                case '8':
                                    current = '4';
                                    break;
                                case 'A':
                                    current = '6';
                                    break;
                                case 'B':
                                    current = '7';
                                    break;
                                case 'C':
                                    current = '8';
                                    break;
                                case 'D':
                                    current = 'B';
                                    break;
                            }

                            break;
                        case 'R':
                            switch (current)
                            {
                                case '2':
                                    current = '3';
                                    break;
                                case '3':
                                    current = '4';
                                    break;
                                case '5':
                                    current = '6';
                                    break;
                                case '6':
                                    current = '7';
                                    break;
                                case '7':
                                    current = '8';
                                    break;
                                case '8':
                                    current = '9';
                                    break;
                                case 'A':
                                    current = 'B';
                                    break;
                                case 'B':
                                    current = 'C';
                                    break;
                            }

                            break;
                        case 'L':
                            switch (current)
                            {
                                case '3':
                                    current = '2';
                                    break;
                                case '4':
                                    current = '3';
                                    break;
                                case '6':
                                    current = '5';
                                    break;
                                case '7':
                                    current = '6';
                                    break;
                                case '8':
                                    current = '7';
                                    break;
                                case '9':
                                    current = '8';
                                    break;
                                case 'B':
                                    current = 'A';
                                    break;
                                case 'C':
                                    current = 'B';
                                    break;
                            }

                            break;
                        case 'D':
                            switch (current)
                            {
                                case '1':
                                    current = '3';
                                    break;
                                case '2':
                                    current = '6';
                                    break;
                                case '3':
                                    current = '7';
                                    break;
                                case '4':
                                    current = '8';
                                    break;
                                case '6':
                                    current = 'A';
                                    break;
                                case '7':
                                    current = 'B';
                                    break;
                                case '8':
                                    current = 'C';
                                    break;
                                case 'B':
                                    current = 'D';
                                    break;
                            }

                            break;
                    }
                }
                code += current;
            }

            Console.WriteLine($"Door Code is {code}");
        }
    }
}