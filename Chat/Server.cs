using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class Server
    {
        static void Main(string[] args)
        {
            ServerLogic server = new ServerLogic();
            server.Start();
            if (Console.ReadLine().ToLower() == "stop")
            {
                server.Stop();
            }
        }
    }
}
