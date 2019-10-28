﻿namespace MODULE_UPDATE_INFO.Classes
{
    using DTODLL;
    using System.Security.Cryptography;
    using System.Text;

    public static class Hash
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // It formats the string as two uppercase hexadecimal characters.
                }
                return builder.ToString();
            }
        }

       
    }
}
