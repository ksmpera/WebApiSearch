using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{
    public class Hashhelper
    {
        public static string GetProperty(object obj)
        {
            StringBuilder builder = new StringBuilder();
            // Get type.
            Type type = obj.GetType();

            // Loop over properties.
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {                
               // Get name.
               string name = propertyInfo.Name;

               // Get value on the target instance.
               object value = propertyInfo.GetValue(obj, null);              

               if ((name != "HashCode"))
                {
                    builder.Append(name);
                    builder.Append(value);                 
                }         
              
            }
            return builder.ToString();       
        }

        public static string GetMD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input.

            string hashOfInput = GetMD5(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
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

