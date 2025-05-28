using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerKitConsole
{
    class Properties
    {
        private static string line;
        public static IDictionary<string, string> PropInfo = new Dictionary<string, string>();
        public static void generateDefaultPropFile()
        {
            using (FileStream stream = new FileStream(@"Prop.txt", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (TextWriter tw = new StreamWriter(stream))
                {
                   
                    tw.WriteLine("ServerPort=8001");
                    tw.WriteLine(@"TSPath=D:\Myfile.txt");
                    tw.Close();
                    Console.WriteLine("Writting is done");
                }
            }
        }
        public static void propertiesLoad()
        {
            try
            {

                using (FileStream fileStream = new FileStream(@"Prop.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        while ((line = streamReader.ReadLine()) != null)
                        {

                            string[] values = line.Split('=');
                            for (int i = 0; i < values.Length; i++)
                            {
                                values[i] = values[i].Trim();
                            }
                            PropInfo.Add(values[0], values[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Could not find file
                if (ex.Message.Contains("Could not find file"))
                {
                    Console.Clear();

                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("KeyGenLicensing Server is starting");
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Server could not started");
                    Console.WriteLine("Globzone: " + MachineInfo.getCurrentTimeZone());
                    Console.WriteLine("Host name is {0}", MachineInfo.getCurrentMachineHost());
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Properties file not found");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Placed the Properties file when server kit is present");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("To Generate Default Properties File Type <GenProp> and Hit Enter");
                    if(Console.ReadLine()=="GenProp")
                    {
                        generateDefaultPropFile();
                    }
                    else
                    {
                        Console.WriteLine("Hit Enter to exit");
                        Console.ReadLine();

                        System.Environment.Exit(1);
                    }
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("KeyGenLicensing Server is starting");
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Server could not started");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.ReadLine();
                    System.Environment.Exit(1);
                }
               
            }
        }
    }
}