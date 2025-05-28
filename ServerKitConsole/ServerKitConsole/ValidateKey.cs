using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerKitConsole
{
    class ValidateKey
    {
        public static bool isGenuineKey(string key)
        {
            //it will return true if key is not there,ready to go
            //it will return false if key is there
            string line;
            bool isDuplicateKey = false;
            using (FileStream fileStream = new FileStream(@"D:\Myfile.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {

                        if (line.Contains(key))
                        {
                            isDuplicateKey = true;
                            break;
                        }
                    }
                }
            }
            return isDuplicateKey;
        }
    }
}
