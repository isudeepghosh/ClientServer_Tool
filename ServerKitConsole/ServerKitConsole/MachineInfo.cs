using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerKitConsole
{
    class MachineInfo
    {
        public static string getCurrentMachineHost()
        {
            return Dns.GetHostName();
        }
        public static string getCurrentTimeZone()
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
           return localZone.StandardName;
        }
        public static string getCurrentMachineIP()
        {
            string myIP = Dns.GetHostByName(getCurrentMachineHost()).AddressList[0].ToString();
            return myIP;
        }
        public static void displayOSInfo()
        {
            OperatingSystem os = Environment.OSVersion;

            Console.WriteLine("OS Version: " + os.Version.ToString());

            Console.WriteLine("OS Platform: " + os.Platform.ToString());
            

            Console.WriteLine("OS Version String: " + os.VersionString.ToString());

            Console.WriteLine();
        }
    }
}
