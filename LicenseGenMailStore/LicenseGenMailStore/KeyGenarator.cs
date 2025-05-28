using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LicenseGenMailStore
{
    class KeyGenarator
    {
        public static string GetRandomAlphanumericString(int length)
        {
            string key = string.Empty;
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
           key=GetRandomString(length, alphanumericCharacters);
         
            return key;
        }
        public static bool isDuplicateKey(string key)
        {
            //it will return true if key is not there,ready to go
            //it will return false if key is there
            string line;
            bool isDuplicateKey=true;
                using (FileStream fileStream = new FileStream(@"D:\Myfile.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                    while ((line = streamReader.ReadLine()) != null)
                    {

                        if (line.Contains(key))
                        {
                            isDuplicateKey = false;
                            break;
                        }
                    }
                    }
            }
            return isDuplicateKey;
        }
        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
    }
}
