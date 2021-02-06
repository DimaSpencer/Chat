using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{

    //1.Сделать так чтобы пользователь не смог отправлять пустые сообщения
    //2.Сделать кастомный клас ConnectedUsers в котором будет свой CancellationTokenSource TcpClient UserName и в случай чего можна было бы через этот токен остановить асинхронный метод юзера на чтение информации
    class ServerLogic
    {
        public string IP { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 6060;
        public TcpListener ServerSocket { get; set; }
        public List<TcpClient> ConnectedUsers { get; set; }

        public ServerLogic()
        {
            ServerSocket = new TcpListener(IPAddress.Parse(IP), Port);
            ConnectedUsers = new List<TcpClient>();

            ServerSocket.Start();
            Console.WriteLine("Сервер запущен");
        }
        public void Start()
        {
            while (true)
            {
                TcpClient tcpClient = ServerSocket.AcceptTcpClient();//тут должны получить от пользователя имя при его подключении
                Console.WriteLine("Новый пользователь подключился");
                ConnectedUsers.Add(tcpClient);
                ListenClient(tcpClient);
            }
        }
        public void Stop()
        {
            foreach (var client in ConnectedUsers)
            {
                client.Close();
            }
            ConnectedUsers.Clear();
            ServerSocket.Stop();
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
                            ConnectedUsers.Remove(tcpClient);
                            Console.WriteLine("Соеденение с пользователем разорвано");
                        }
                        Thread.Sleep(400);
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
                foreach (var user in ConnectedUsers)
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
