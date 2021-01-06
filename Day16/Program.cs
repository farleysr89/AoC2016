﻿using System;
using System.Linq;
using File = System.IO.File;

namespace Day16
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
            var initial = input.Split('\n')[0];
            var length = 272;
            while (initial.Length < length)
            {
                var a = new string(initial);
                var bA = a.ToCharArray();
                Array.Reverse(bA);
                var b = new string(bA);
                b = b.Replace('0', 'a').Replace('1', '0').Replace('a', '1');
                initial = a + '0' + b;
            }

            string checkSum;
            while (true)
            {
                checkSum = "";
                for (var i = 0; i < Math.Min(length, initial.Length); i += 2)
                {
                    checkSum += initial[i] == initial[i + 1] ? "1" : "0";
                }

                if (checkSum.Length % 2 == 1) break;
                initial = checkSum;
            }

            Console.WriteLine("CheckSum = " + checkSum);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
