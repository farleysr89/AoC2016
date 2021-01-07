using System;
using System.IO;
using System.Linq;

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

            var checkSum = "";
            var finalLength = length;
            while (finalLength % 2 == 0) finalLength /= 2;
            var partLength = length / finalLength;
            for (var i = 0; i < finalLength; i++)
            {
                checkSum += initial[(i * partLength)..(i * partLength + partLength)].Count(c => c == '1') % 2 == 0
                    ? '1'
                    : '0';
            }
            Console.WriteLine("CheckSum = " + checkSum);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var initial = input.Split('\n')[0];
            var length = 35651584;
            while (initial.Length < length)
            {
                var a = new string(initial);
                var bA = a.ToCharArray();
                Array.Reverse(bA);
                var b = new string(bA);
                b = b.Replace('0', 'a').Replace('1', '0').Replace('a', '1');
                initial = a + '0' + b;
            }

            var checkSum = "";
            var finalLength = length;
            while (finalLength % 2 == 0) finalLength /= 2;
            var partLength = length / finalLength;
            for (var i = 0; i < finalLength; i++)
            {
                checkSum += initial[(i * partLength)..(i * partLength + partLength)].Count(c => c == '1') % 2 == 0
                    ? '1'
                    : '0';
            }

            Console.WriteLine("CheckSum = " + checkSum);
        }
    }
}
