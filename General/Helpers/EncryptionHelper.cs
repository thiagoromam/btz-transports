using System;
using System.Security.Cryptography;

namespace General.Helpers
{
    public static class EncryptionHelper
    {
        public static byte[] Encrypt(string text, out byte[] salt)
        {
            var random = new Random();
            var saltLength = random.Next(24, 32);

            using (var hash = new Rfc2898DeriveBytes(text, saltLength, 10000))
            {
                salt = hash.Salt;
                return hash.GetBytes(32);
            }
        }
        public static byte[] Encrypt(string text, byte[] salt)
        {
            using (var hash = new Rfc2898DeriveBytes(text, salt, 10000))
                return hash.GetBytes(32);
        }
    }
}
