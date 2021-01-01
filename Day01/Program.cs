using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        private static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        static void SolvePart1()
        {
            string input = File.ReadAllText("Input.txt");
            List<string> data = input.Split('\n').ToList();
            Console.WriteLine(data);
        }

        static void SolvePart2()
        {
            string input = File.ReadAllText("Input.txt");
            List<string> data = input.Split('\n').ToList();
            Console.WriteLine(data);
        }
    }
}
