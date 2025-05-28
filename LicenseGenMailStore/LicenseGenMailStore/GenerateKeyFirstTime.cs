using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseGenMailStore
{
    class GenerateKeyFirstTime
    {

        public static void GenerateFirstTime()
        {
            string mail,name,productName;
            string dataToStore;
            Console.WriteLine("-------------------------------------------------------------------");
            Console.Write("Enter your mail id: ");
            mail = Console.ReadLine();
            Console.Write("Enter your Name: ");
            name = Console.ReadLine();
            Console.Write("Enter your Product Name: ");
            productName = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------------------------");
            dataToStore =Program.Key + " | " +mail+" | "+name+" | "+productName+ " | "+"4";
            Console.WriteLine("Key Is Generated for count 4");
            using (FileStream stream = new FileStream(@"D:\Myfile.txt", FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                using (TextWriter tw = new StreamWriter(stream))
                {
                    tw.WriteLine(dataToStore);
                    tw.Close();
                    Console.WriteLine("Data Stored into TrustedDataCenter");
                }
            }
           Console.Write("Hi {0}, Your key for the product {1} is : ", name, productName);
            Console.WriteLine();
            Program.keyDisplay(Program.Key);
            Console.WriteLine();
            Console.WriteLine("NOTE: You will receve a mail containg key");
            MailTheKey.Email(Program.Key, mail);
        }
    }
}