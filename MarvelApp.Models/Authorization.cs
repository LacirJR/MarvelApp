using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApp.Models
{
    public static class Authorization
    {
        private static int ts => int.Parse(Environment.GetEnvironmentVariable("Marvel_ts"));
        private static string? PublicKey => Environment.GetEnvironmentVariable("Marvel_PublicKey");
        private static string? PrivateKey => Environment.GetEnvironmentVariable("Marvel_PrivateKey");
        private static string? Hash => GetHash();

        private static string GetHash()
        {
            var hashKey = $"{ts}{PrivateKey}{PublicKey}";
            using var provider = System.Security.Cryptography.MD5.Create();
            StringBuilder builder = new StringBuilder();

            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(hashKey)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();

        }

        private static string BuildStringParam() => $"?ts={ts}&apikey={PublicKey}&hash={Hash}";

        public static string StringParams => BuildStringParam();


    }
}
