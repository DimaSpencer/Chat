using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Client.BL.Model.ClientModel;

namespace Client.BL.Controller
{
    public class ClientController
    {
        private List<Model.ClientModel> _clients = new List<Model.ClientModel>();
        public int Connect(string userName, string ip, int port)
        {
            Model.ClientModel client = new Model.ClientModel(userName);
            try
            {
                client.TcpClient = new TcpClient();
                client.TcpClient.Connect(IPAddress.Parse(ip), port);
                client.NetworkStream = client.TcpClient.GetStream();
                _clients.Add(client);

                client.CancelTokenSource = new CancellationTokenSource();
                client.Token = client.CancelTokenSource.Token;
                ReceiveMessages(client);

                return client.UserID;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка подключения");
            }
        }
        public void Disconnect(int userID)
        {
            var client = _clients.FirstOrDefault(u => u.UserID == userID);
            _clients.Remove(client);
            client.CancelTokenSource.Cancel();
        }
        public void SendMessage(string message, int userID)
        {
            Model.ClientModel client = _clients.FirstOrDefault(u => u.UserID == userID);

            message = message.Trim();
            string resultMessage = $"{client.UserName}: {message}";
            byte[] buffer = Encoding.UTF8.GetBytes(resultMessage);
            client?.NetworkStream.Write(buffer);
            client.NetworkStream.Flush();
        }
        public void AddCallBackMethod(int userID, CallBackMethod method) //делегат который будет вызывать метод в WindowsForms с взодящим параметром - сообщением
        {
            _clients.FirstOrDefault(c => c.UserID == userID).CallbackMethods += method;
        }
        async private void ReceiveMessages(Model.ClientModel client)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (client.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Чтение прервано");
                        return;
                    }
                    byte[] buffer = new byte[256];
                    client.NetworkStream.Read(buffer);
                    string message = Encoding.UTF8.GetString(buffer);

                    CallingMessageForAllUsers(message);

                    Task.Delay(10).Wait();
                }
            });
        }
        private void CallingMessageForAllUsers(string message)
        {
            foreach (var client in _clients)
            {
                client?.CallbackMethods?.Invoke(message);
            }
        }
    }
}
