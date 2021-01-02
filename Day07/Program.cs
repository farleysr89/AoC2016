using System;
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
            var count = 0;
            foreach (var s in data.Where(s => s != ""))
            {
                bool found = false;
                for (var i = 0; i < s.Length - 3; i++)
                {
                    if (!Check(s.Substring(i, 4))) continue;
                    if (s.Substring(0, i).LastIndexOf("[", StringComparison.Ordinal) > s.Substring(0, i).LastIndexOf("]", StringComparison.Ordinal))
                    {
                        found = false;
                        break;
                    }

                    found = true;
                }

                if (found) count++;
            }
            Console.WriteLine(count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }

        private static bool Check(string s)
        {
            return s[0] == s[3] && s[1] == s[2] && s[0] != s[1];
        }
    }
}
