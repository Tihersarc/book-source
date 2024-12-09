﻿using System.Security.Cryptography;
using System.Text;

namespace BookSource.Tools
{
    public static class PasswordHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                Console.WriteLine("Computed Hash: " + Convert.ToBase64String(computedHash));
                Console.WriteLine("Stored Hash: " + Convert.ToBase64String(storedHash));
                return computedHash.SequenceEqual(storedHash);
            }
        }
    }
}
