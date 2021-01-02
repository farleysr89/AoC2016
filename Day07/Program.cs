using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
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
            data = data.Select(s => s.Replace("[", " [").Replace("]", "] ")).ToList();
            var count = 0;
            foreach (var s in data.Where(s => s != ""))
            {
                var found = false;
                var subs = s.Split(" ");
                foreach (var ss in subs.Where(x => x[0] == '['))
                {
                    for (var i = 1; i < ss.Length - 4; i++)
                    {
                        if (!CheckABBA(ss.Substring(i, 4))) continue;
                        found = true;
                        break;
                    }

                    if (found) break;
                }

                if (found) continue;

                foreach (var ss in subs.Where(x => x[0] != '['))
                {
                    for (var i = 0; i < ss.Length - 3; i++)
                    {
                        if (!CheckABBA(ss.Substring(i, 4))) continue;
                        found = true;
                        break;
                    }

                    if (found) break;
                }

                if (found) count++;
            }
            Console.WriteLine(count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            data = data.Select(s => s.Replace("[", " [").Replace("]", "] ")).ToList();
            var count = 0;
            foreach (var s in data.Where(s => s != ""))
            {
                var ABAs = new List<string>();
                var subs = s.Split(" ");
                foreach (var ss in subs.Where(x => x[0] == '['))
                {
                    for (var i = 1; i < ss.Length - 3; i++)
                    {
                        if (CheckABA(ss.Substring(i, 3))) ABAs.Add(GetBAB(ss.Substring(i, 3)));
                    }
                }

                var found = subs.Where(x => x[0] != '[').Any(ss => ABAs.Any(ss.Contains));

                if (found) count++;
            }
            Console.WriteLine(count);
        }

        private static bool CheckABBA(string s)
        {
            return s[0] == s[3] && s[1] == s[2] && s[0] != s[1];
        }
        private static bool CheckABA(string s)
        {
            return s[0] == s[2] && s[0] != s[1];
        }

        private static string GetBAB(string s)
        {
            return s[1] + s[0].ToString() + s[1];
        }
    }
}
