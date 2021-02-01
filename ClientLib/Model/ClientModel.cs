using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.BL.Model
{
    public class ClientModel
    {
        public static int IDGenerator { get; set; } = 0;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public TcpClient TcpClient { get; set; }
        public NetworkStream NetworkStream { get; set; }

        public delegate void CallBackMethod(string message);
        public CallBackMethod callbackMethods;

        public CancellationTokenSource cancelTokenSource { get; set; }
        public CancellationToken token { get; set; }

        public ClientModel(string userName)
        {
            UserID = IDGenerator++;
            UserName = userName;
            TcpClient = new TcpClient();
        }
    }
}
