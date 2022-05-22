using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Helpers
{
    internal static class Tools
    {
        public static string GenerateRandomString(int size = 8)
        {
            Random res = new Random();

            // String of alphabets
            String str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ)01234567890";

            // Initializing the empty string
            String ran = "";

            for (int i = 0; i < size; i++)
            {
                // Selecting a index randomly
                int x = res.Next(str.Count()-1);

                // Appending the character at the
                // index to the random string.
                ran = ran + str[x];
            }
            return ran;
        }

        public static string GenerateKey => GenerateRandomString(32);
        public static string GenerateRecoveryCode => GenerateRandomString(6);
    }
}