using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ARQ_App.SecurityTools
{
    /// <summary>
    /// Implementa metodos para hashear y verificar una serie de caracteres
    /// </summary>
    public static class PassHasher 
    {
        private const int Salt = 16;
        private const int Key = 32;
        private const int It = 10000; 

   
        public static string Hash(string pass)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                password: pass,
                saltSize: Salt,
                iterations: It,
                HashAlgorithmName.SHA256);
            var key = Convert.ToBase64String(algorithm.GetBytes(Key));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{It}.{salt}.{key}";
        }

        /// <summary>
        /// Compara una serie de caracteres sin cifrar y un hash.
        /// Verifica que al aplicar un hash el resultado sea el mismo
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static (bool Verifi, bool Up) Review(string hash, string pass)
        {
            var split = hash.Split('.', 3);

            if(split.Length != 3)
            {
                throw new FormatException("El formato de cifrado es invalido ingrese un hash con el formato {iteraciones}.{salt}.{key}");
            }

            var it = Convert.ToInt32(split[0]);
            var salt = Convert.FromBase64String(split[1]);
            var key = Convert.FromBase64String(split[2]);

            var needUp = it != It;

            using var alg = new Rfc2898DeriveBytes(
                password: pass,
                salt: salt,
                iterations: it,
                HashAlgorithmName.SHA256);
            var ktc = alg.GetBytes(Key);

            var verified = ktc.SequenceEqual(key);

            return (verified, needUp);
        }


    }
}
