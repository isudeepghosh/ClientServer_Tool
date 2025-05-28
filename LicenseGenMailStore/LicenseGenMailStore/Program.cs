using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LicenseGenMailStore
{
    //This is a program for generate license generate , mail to customer and store [for server deploy]
    class Program
    {
        public static bool Authy = false;
        public static string Key;
        static void Main(string[] args)
        {
          
            Console.Title = "KeyGenLicAdmin";
            Program.Key = UniqueKeyGen(16);
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("                         Welcome to KeyGenLic AdminTool"); Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine("--                    Choose Any One Option                    --");
           
            if (!Authy)
            {
                menuChooseUnAuthy();
            }
            else
            {
                 menuChoose();
            }


            Console.Read();
        }
        public static string UniqueKeyGen(int len)
        {
            string Key = KeyGenarator.GetRandomAlphanumericString(len);
            bool checkDuplicat = KeyGenarator.isDuplicateKey(Key);
            while (!checkDuplicat)
            {
                Key = KeyGenarator.GetRandomAlphanumericString(len);
                checkDuplicat = KeyGenarator.isDuplicateKey(Key);
            }
            return Key;
        }
        public static int menuChooseUnAuthy()
        {
            int readKey;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter 1: Authorization using TOT/Mail");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter 2: Generate the key");
            Console.WriteLine("Enter 3: Check the avalable keys");
            Console.WriteLine("Enter 4: Check the avalable count of key");
            Console.WriteLine("Enter 5: Remove perticular key");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter 6: ReSend mail for key");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter 7: Search a key information");
            Console.ResetColor();
            Console.WriteLine("Enter 8: To Exit from the menu");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            while (true)
            {
                Console.Write("Enter Any Option: ");
                readKey = Convert.ToInt32(Console.ReadLine());
                switch (readKey)
                {
                    case 1:
                        AuthoClass.authenticateMain();
                        Console.Clear();
                        menuChoose();
                        break;
                    case 8:
                        System.Environment.Exit(1);
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
               
                    case 7:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Restricted Access Kindly Authenticate");
                        Console.ResetColor();
                        break;
                    case 6:
                        return readKey;
                }
            }
          
        }
        public static int menuChoose()
        {
            int readKey; 
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         Welcome to KeyGenLic AdminTool");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("--                    Choose Any One Option                    --");
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter 1: Generate the key");
            Console.WriteLine("Enter 2: Check the avalable keys");
            Console.WriteLine("Enter 3: Check the avalable count of key");
            Console.WriteLine("Enter 4: Remove perticular key");
            Console.WriteLine("Enter 5: ReSend mail for key");
            Console.WriteLine("Enter 6: Search a key information");
            Console.WriteLine("Enter 7: To Exit from the menu");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.Write("Enter Any Option: ");
            readKey = Convert.ToInt32(Console.ReadLine());

            switch (readKey)
            {
                case 1:
                    GenerateKeyFirstTime.GenerateFirstTime();

                    break;
                case 5:
                    Console.WriteLine(5);
                    break;
            }
            return readKey;
        }
        public static void keyDisplay(string keyGen)
        {
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(keyGen);
            Console.ResetColor();
        }
    }
}
