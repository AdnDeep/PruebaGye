using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Web.Services
{
    public static class StringManipulation
    {
        public static string GenerateRandom()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            
            return finalString;
        }
    }
}
