using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace ClientKit
{
    class Program
    {
        public static  string ServerIP = string.Empty;
        public static int ServerPort;
        public  static string CurrentMachineIP;
        public static int DefaultMachinePort=8001;
        public static bool tryAgain = true;
        public static int count = 0;
        internal static void ClientConnect(string ServerIP, int ServerPort)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
               
                while (tryAgain)
                {
                    try
                    {
                        if (count <= 0)
                        {
                            Console.WriteLine("Connecting .......");
                        }
                        else
                        {
                            Console.WriteLine("Connecting {0}th attempts.....", count);
                        }
                        ++count;
                        tcpclnt.Connect(ServerIP, ServerPort);
                        Task.Delay(2000).Wait();
                        tryAgain = false;
                    }
                    catch (Exception e)
                    {
                        if (e.Message.Contains("target machine actively refused it"))
                            tryAgain = true;
                        else
                            tryAgain = false;
                        if (count > 5)
                        {
                            Console.WriteLine("Error : {0}",e.Message);
                            Console.WriteLine("Error..... " + e.StackTrace);
                        }
                    }
                    finally
                    {
                        if (count > 5)
                        {
                            tryAgain = false;
                            Console.WriteLine("Connection could be made because the target machine actively refused it");
                            Console.ReadLine();
                            System.Environment.Exit(1);
                        }
                    }
                }
                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");
                String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");
                stm.Write(ba, 0, ba.Length);
                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));
                tcpclnt.Close();
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Message: {0}",e.Message);
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("SD Client Kit Executing");
            new CMDArgumentHelpercs(args);
            Program.ClientConnect(ServerIP,ServerPort);
            Console.ReadLine();
        }
    }
}
