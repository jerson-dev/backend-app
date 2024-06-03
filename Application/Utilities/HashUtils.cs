using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class HashUtils
    {
        private static readonly int KeySize = 256;
        private static readonly int BlockSize = 128;
        private static readonly string Clave = "Luciana_clave_nimbus_Socrates";
        private static readonly string Vector = "n3CPd7Oe8f2a5IETgO2HJQ==";
        // aquí
        public static string GetHashFirst(string Contrasenia)
        {
            byte[] keyBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Clave));
            byte[] ivBytes = Convert.FromBase64String(Vector);

            Array.Resize(ref keyBytes, KeySize / 8);
            Array.Resize(ref ivBytes, BlockSize / 8);

            using (Aes rijAlg = Aes.Create())
            {
                rijAlg.Key = keyBytes;
                rijAlg.IV = ivBytes;

                // Cifrar la contraseña
                byte[] encryptedBytes;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, rijAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = Encoding.UTF8.GetBytes(Contrasenia);
                        csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                        csEncrypt.FlushFinalBlock();
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string GenerateRandomToken(int lengthToken)
        {
            int passLength = lengthToken;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, passLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
