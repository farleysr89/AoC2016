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
            var key = File.ReadAllText("Input.txt");
            var password = new char[8];
            var i = 0;
            using (var md5 = MD5.Create())
            {
                while (password.Any(c => c == '\0'))
                {
                    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(key + i.ToString()));
                    var hex = BitConverter.ToString(hash).Replace("-", "");
                    if (hex.Substring(0, 5) == "00000" && char.IsDigit(hex[5]))
                    {
                        var pos = int.Parse(hex[5].ToString());
                        if (pos < 8 && password[pos] == '\0')
                        {
                            password[pos] = hex[6];
                        }
                    }

                    i++;
                }
            }

            var s = password.Aggregate("", (current, c) => current + char.ToLower(c));

            Console.WriteLine("Password = " + s);
        }
    }
}
