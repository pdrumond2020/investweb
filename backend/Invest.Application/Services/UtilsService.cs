using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Invest.Application.Services
{
    public static class UtilsService
    {
        public static string EncryptPassword(string password)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new();
            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        internal static string GenerateCode(int length)
        {
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal static string GenerateURL(string code, string document, string host)
        {
            if (!host.Contains("http"))
                host = "https://" + host;

            return string.Concat(host, "/api/users/activate/", document, "/", code);
        }

        public static bool IsAdmin(string profile)
        {
            return profile == "1";
        }
    }
}