using System;
using System.IO;
using System.Linq;

namespace Day09
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
            var s = data[0];
            var ss = "";
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    var ii = s[i..].IndexOf(')');
                    var sss = s.Substring(i + 1, ii - 1);
                    var dims = sss.Split(("x"));
                    var letterCount = int.Parse(dims[0]);
                    var multiCount = int.Parse(dims[1]);
                    var stringToMulti = s[(i + ii + 1)..(i + ii + letterCount + 1)];
                    ss += MultiplyString(stringToMulti, multiCount);
                    i += ii + letterCount;
                }
                else
                {
                    ss += s[i];
                }
            }
            Console.WriteLine("Decrypted Length = " + ss.Length);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var s = data[0];
            long count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    var ii = s[i..].IndexOf(')');
                    var sss = s.Substring(i + 1, ii - 1);
                    var dims = sss.Split(("x"));
                    var letterCount = int.Parse(dims[0]);
                    var multiCount = int.Parse(dims[1]);
                    var stringToMulti = s[(i + ii + 1)..(i + ii + letterCount + 1)];
                    var multi = MultiplyString(stringToMulti, multiCount);
                    if (multi.Contains("("))
                        count += ProcessString(multi);
                    else count += multi.Length;
                    i += ii + letterCount;
                }
                else
                {
                    count++;
                }
            }
            Console.WriteLine("Decrypted Length = " + count);
        }

        private static string MultiplyString(string s, int count)
        {
            var ss = "";
            for (var i = 0; i < count; i++)
            {
                ss += s;
            }

            return ss;
        }

        private static long ProcessString(string s)
        {
            long count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    var ii = s[i..].IndexOf(')');
                    var sss = s.Substring(i + 1, ii - 1);
                    var dims = sss.Split(("x"));
                    var letterCount = int.Parse(dims[0]);
                    var multiCount = int.Parse(dims[1]);
                    var stringToMulti = s[(i + ii + 1)..(i + ii + letterCount + 1)];
                    var multi = MultiplyString(stringToMulti, multiCount);
                    if (multi.Contains("("))
                        count += ProcessString(multi);
                    else count += multi.Length;
                    i += ii + letterCount;
                }
                else
                {
                    count++;
                }
            }

            return count;
        }
    }
}
