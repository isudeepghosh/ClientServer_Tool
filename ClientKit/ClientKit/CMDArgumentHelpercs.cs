using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientKit
{
    class CMDArgumentHelpercs
    {
       public CMDArgumentHelpercs(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Arguments Passed by the Programmer:");

                // To print the command line  
                // arguments using foreach loop 
                foreach (Object obj in args)
                {
                    Console.WriteLine(obj);
                }
            }

            else
            {
                Console.WriteLine("No command line arguments found.");
                Console.WriteLine("It will take local machine ip as serverIP and default port 8001");
                Console.WriteLine();
                Console.WriteLine("Host is: " + new MachineInfo().CurrentMachineHostName);
                Program.ServerIP= new MachineInfo().CurrentMachineIP;
                Program.CurrentMachineIP = Program.ServerIP;
                Console.WriteLine("Server IP is : " + Program.CurrentMachineIP);
                Console.WriteLine("Server PORT is: " + Program.DefaultMachinePort);
                Program.ServerPort = Program.DefaultMachinePort;

            }
        }

    }
}
