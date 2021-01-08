using System;
using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public static class Utils
    {
        public static string GetHash(string s)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(s));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
        public static string ShiftRight(string s, int count)
        {
            for (var i = 0; i < count; i++)
            {
                s = s[^1] + s[0..^1];
            }

            return s;
        }
        public static string ShiftLeft(string s, int count)
        {
            for (var i = 0; i < count; i++)
            {
                s = s[1..] + s[0];
            }

            return s;
        }

        public static string Reverse(string s)
        {
            var cA = s.ToCharArray();
            Array.Reverse(cA);
            return new string(cA);
        }
    }
}
