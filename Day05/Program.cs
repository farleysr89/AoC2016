using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Day05
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
            var key = File.ReadAllText("Input.txt");
            var password = "";
            var i = 0;
            using (var md5 = MD5.Create())
            {
                while (password.Length != 8)
                {
                    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(key + i.ToString()));
                    var hex = BitConverter.ToString(hash).Replace("-", "");
                    if (hex.Substring(0, 5) == "00000") password += char.ToLower(hex[5]);
                    i++;
                }
            }


            Console.WriteLine("Password = " + password);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
