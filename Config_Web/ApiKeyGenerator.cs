using System;
using System.Security.Cryptography;

namespace Config_Web
{
    /// <summary>
    /// Gera chaves API usando RNGCryptoServiceProvider (CSPRNG).
    /// 96 bytes aleatorios em Base64 resultam em exatamente 128 caracteres.
    /// </summary>
    public static class ApiKeyGenerator
    {
        public static string Generate()
        {
            byte[] bytes = new byte[96];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }
    }
}
