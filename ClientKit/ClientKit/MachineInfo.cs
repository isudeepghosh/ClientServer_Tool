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
    public class MachineInfo
    {
        public  readonly string CurrentMachineIP ;
        public  readonly string CurrentMachineHostName ;
         string GetCurrentIP()
        {
            return Dns.GetHostByName(CurrentMachineHostName).AddressList[0].ToString();
        }
         string GetCurrentHostName()
        {
            return Dns.GetHostName();
        }
        public   MachineInfo()
        {
           CurrentMachineHostName = GetCurrentHostName();
            CurrentMachineIP = GetCurrentIP();
        }
    }
}
