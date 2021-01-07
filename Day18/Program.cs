using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day18
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
            var row = input.Split('\n')[0];
            var rows = new List<string>
            {
                row
            };
            var i = 1;
            while (i < 40)
            {
                var newRow = "";
                for (var x = 0; x < row.Length; x++)
                {
                    if (x == 0) newRow += row[x + 1] == '^' ? '^' : '.';
                    else if (x == row.Length - 1) newRow += row[x - 1] == '^' ? '^' : '.';
                    else newRow += (row[x - 1] == '^' && row[x + 1] == '.') ||
                                   (row[x + 1] == '^' && row[x - 1] == '.') ? '^' : '.';
                }
                rows.Add(newRow);
                row = newRow;
                i++;
            }

            var count = rows.SelectMany(r => r).Count(c => c == '.');
            Console.WriteLine("There are " + count + " safe spaces.");
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var row = input.Split('\n')[0];
            var rows = new List<string>
            {
                row
            };
            var i = 1;
            while (i < 400000)
            {
                var newRow = "";
                for (var x = 0; x < row.Length; x++)
                {
                    if (x == 0) newRow += row[x + 1] == '^' ? '^' : '.';
                    else if (x == row.Length - 1) newRow += row[x - 1] == '^' ? '^' : '.';
                    else newRow += (row[x - 1] == '^' && row[x + 1] == '.') ||
                                   (row[x + 1] == '^' && row[x - 1] == '.') ? '^' : '.';
                }
                rows.Add(newRow);
                row = newRow;
                i++;
            }

            var count = rows.SelectMany(r => r).Count(c => c == '.');
            Console.WriteLine("There are " + count + " safe spaces.");
        }
    }
}
