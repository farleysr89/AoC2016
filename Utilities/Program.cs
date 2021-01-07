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
    }
}
