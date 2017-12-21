namespace UserRegistration.Services
{
    using System;
    using System.Security.Cryptography;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

    /// <summary>
    ///     Password hashing.
    /// </summary>
    public sealed class PasswordHasher
    {
        public static (string salt, string passwordHash) HashPassword(string password)
        {
            byte[] salt = GenerateSalt();

            return (Convert.ToBase64String(salt), HashPassword(salt, password));
        }
        
        private static string HashPassword(byte[] salt, string password)
        {
            byte[] passwordHash = KeyDerivation.Pbkdf2(password: password,
                                                       salt: salt,
                                                       prf: KeyDerivationPrf.HMACSHA256,
                                                       iterationCount: 10000,
                                                       numBytesRequested: 256 / 8);

            return Convert.ToBase64String(passwordHash);
        }
        
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}