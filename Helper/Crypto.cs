using System;
using System.Security.Cryptography;
using System.Text;

namespace AppSenAgriculture.Helper
{
    public class Crypto
    {
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();

            foreach (byte b in data)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string text, string motDePasseUtilisateur)
        {
            string hashOfInput = GetMd5Hash(md5Hash, text);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (comparer.Compare(hashOfInput, motDePasseUtilisateur) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}