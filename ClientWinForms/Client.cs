using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        public string UserName { get; set; }
        public TcpClient TcpClient { get; set; }
        public NetworkStream NetworkStream { get; set; }
        public string Chat { get; set; }

        public Client(string userName)
        {
            UserName = userName;
            TcpClient = new TcpClient();
        }
        public bool TryConnect(string ip, int port)
        {
            try
            {
                TcpClient.Connect(IPAddress.Parse(ip), port);
                NetworkStream = TcpClient.GetStream();
                return TcpClient.Connected;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Disconnect()
        {
            TcpClient.Close();
        }
        public void SendMessasge(string message)
        {
            if (TcpClient.Connected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes($"{UserName}: " + message);

                NetworkStream.Write(buffer, 0, buffer.Length);
                NetworkStream.Flush();
            }
        }
        async public void ReadMessage()
        {
            await Task.Factory.StartNew(() => 
            {
                while (true)
                {
                    if (TcpClient.Connected)
                    {
                        byte[] buffer = new byte[256];
                        NetworkStream.Read(buffer);
                        Chat += Encoding.UTF8.GetString(buffer) + "\n";

                        Task.Delay(10).Wait();
                    }
                }
            });
        }
    }
}
