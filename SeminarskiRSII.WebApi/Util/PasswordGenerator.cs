using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Util
{
    public class PasswordGenerator
    {
        public static string GenerateSalt()
        {
            byte[] arr = new byte[16];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

            crypto.GetBytes(arr);

            return Convert.ToBase64String(arr);
        }

        public static string GenerateHash(string lozinka, string salt)
        {
            byte[] arrLozinka = Encoding.Unicode.GetBytes(lozinka);
            byte[] arrSalt = Convert.FromBase64String(salt);

            byte[] arr = new byte[arrLozinka.Length + arrSalt.Length];

            System.Buffer.BlockCopy(arrLozinka, 0, arr, 0, arrLozinka.Length);
            System.Buffer.BlockCopy(arrSalt, 0, arr, arrLozinka.Length, arrSalt.Length);

            HashAlgorithm alg = HashAlgorithm.Create("SHA1");

            return Convert.ToBase64String(alg.ComputeHash(arr));
        }
    }
}
