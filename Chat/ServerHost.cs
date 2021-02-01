using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerHost
    {
        public TcpListener ServerSocket { get; set; }
        public List<TcpClient> Users { get; set; }

        public ServerHost()
        {
            ServerSocket = new TcpListener(IPAddress.Any, 6060);
            Users = new List<TcpClient>();

            ServerSocket.Start();
            Console.WriteLine("Сервер запущен");
        }
        public void Start()
        {
            while (true)
            {
                TcpClient tcpClient = ServerSocket.AcceptTcpClient();//тут должны получить от пользователя имя при его подключении
                Console.WriteLine("Новый пользователь подключился");
                Users.Add(tcpClient);
                ListenClient(tcpClient);
            }
        }
        async private void ListenClient(TcpClient tcpClient)
        {
            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        NetworkStream stream = tcpClient.GetStream();
                        byte[] buffer = new byte[256];
                        stream.Read(buffer);
                        buffer = buffer.Where(b => b != 0).ToArray();
                        string message = Encoding.UTF8.GetString(buffer);

                        if (!string.IsNullOrWhiteSpace(message))
                        {
                            SendMessage(message);
                        }
                        else
                        {
                            tcpClient.Close();
                            Users.Remove(tcpClient);
                            Console.WriteLine("Соеденение с пользователем разорвано");
                        }
                        System.Threading.Thread.Sleep(400);

                    }
                }
                catch (Exception)
                {
                    tcpClient.Close();
                    Console.WriteLine("Соеденение с пользователем разорвано");
                }
            });
        }
        async private void SendMessage(string message)//метод который разсылает всем пользователям сообщение присланое из вне
        {
            await Task.Run(() =>
            {
                Console.WriteLine("В чат отправлено сообщение " + message);
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                foreach (var user in Users)
                {
                    if (user.Connected)
                    {
                        var stream = user.GetStream();
                        stream.Write(buffer);
                    }
                }
            });
        }
    }
}
