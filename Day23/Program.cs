using System;
using System.IO;
using System.Linq;

namespace Day23
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
            int a = 7, b = 0, c = 0, d = 0, index = 0;
            while (true)
            {
                if (index >= data.Length) break;
                var s = data[index];
                if (s == "") break;
                var parts = s.Split(" ");
                var x = 0;
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
                        var y = 0;
                        if (int.TryParse(parts[2], out var j))
                        {
                            y = j;
                        }
                        else
                        {
                            switch (parts[2][0])
                            {
                                case 'a':
                                    y = a;
                                    break;
                                case 'b':
                                    y = b;
                                    break;
                                case 'c':
                                    y = c;
                                    break;
                                case 'd':
                                    y = d;
                                    break;
                                default:
                                    Console.WriteLine("Something Broke!");
                                    break;
                            }
                        }

                        y--;
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
                    case "tgl":
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

                        if (data[index + x] == "") break;
                        var modInst = data[index + x].Split(" ");
                        string newCommand;
                        string newInstruction;
                        if (modInst.Length == 2)
                        {
                            newCommand = modInst[0] == "inc" ? "dec" : "inc";
                            newInstruction = newCommand + " " + modInst[1];
                        }
                        else
                        {
                            newCommand = modInst[0] == "jnz" ? "cpy" : "jnz";
                            newInstruction = newCommand + " " + modInst[1] + " " + modInst[2];
                        }

                        data[index + x] = newInstruction;
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
