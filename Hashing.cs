using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_JoseValle
{
    public class Hashing
    {

        public static string generateSHA256(string input) {

            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            var key = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                key.Append(bytes[i].ToString("x2"));
            }
            return key.ToString();
            
        }
    }
}
