using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    public static class Tools
    {
        public static string MD5Uret(string input)
        {//veri tabanımızdaki şifreleri korumak için yapıyoruz. şifreler veritabanımızda net bir şekilde görünmesin diye yapıyoruz.

            // Step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static string TurkceKarakterTemizle(string s)
        {
            s = s.Replace('ı', 'i');
            s = s.Replace('İ', 'I');
            s = s.Replace(' ', '_');
            s = s.Replace('ü', 'u');
            s = s.Replace('Ü', 'U');
            s = s.Replace(' ', '_');
            s = s.Replace('ç', 'c');
            s = s.Replace('Ç', 'C');
            s = s.Replace('ş', 's');
            s = s.Replace('Ş', 's');
            s = s.Replace('ğ', 'g');
            s = s.Replace('Ğ', 'G');

            return s;
        }

        public static string RandomString(int uzunluk)
        {


            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < uzunluk; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);

                str_build.Append(letter);
            }
            return str_build.ToString();
        }

    }
}
