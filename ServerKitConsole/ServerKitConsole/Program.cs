using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ServerKitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("KeyGenLicensing Server is starting");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine();
            LoadingBar.LoadWorking("Server Loading ", 10);
            Properties.propertiesLoad();
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("KeyGenLicensing Server is starting");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Server Loaded Sucessfully");
            Console.WriteLine("Globzone : "+MachineInfo.getCurrentTimeZone());
            Console.WriteLine("Host name is :{0}",MachineInfo.getCurrentMachineHost());
            Console.WriteLine("Running on : " + MachineInfo.getCurrentMachineIP());
            Console.WriteLine("Server port :{0}",Properties.PropInfo["ServerPort"]);
            MachineInfo.displayOSInfo();
            Console.WriteLine("Server started at " + DateTime.Now.ToString());
            Console.WriteLine();
            while (true)
            {
                try
                {
                    string key = "";
                    IPAddress ipAd = IPAddress.Parse(MachineInfo.getCurrentMachineIP());
                    TcpListener myList = new TcpListener(ipAd, int.Parse(Properties.PropInfo["ServerPort"]));
                    myList.Start();
                  
                    Console.WriteLine("Waiting for a connection.....");
                    Socket s = myList.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint+ " at "+DateTime.Now.ToString());
                    byte[] b = new byte[100];
                    int k = s.Receive(b);
                    Console.WriteLine("Recieved...");
                    for (int i = 0; i < k; i++)
                    {
                        //Console.Write(Convert.ToChar(b[i]));
                        key = key + Convert.ToChar(b[i]);
                    }
                    Console.WriteLine("Receved Key : "+key);

                    ASCIIEncoding asen = new ASCIIEncoding();
                    if(ValidateKey.isGenuineKey(key))
                    {
                        s.Send(asen.GetBytes("Key from client " + s.RemoteEndPoint+" is valid and genuine"));
                        Console.WriteLine("\n Key Accepted");
                    }
                    else
                    {
                        s.Send(asen.GetBytes("Key from client " + s.RemoteEndPoint + " is not valid"));
                        Console.WriteLine("\n Invalid Key");
                    }
                    Console.WriteLine("\nSent Acknowledgement");
                    s.Close();
                    myList.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                }
            }
            Console.ReadLine();
        }
    }
}
