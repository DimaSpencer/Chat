using System;
using System.Linq;
using Client.BL;
using Client.BL.Controller;

namespace Client.View
{
    class Program
    {
        static  ClientController controller;

        static  public int ClientID;
        static  string nameBox;
        static  string ipBox = "127.0.0.1";
        static  int portBox = 6060;
        static  string chatBox = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свой ник в чате");
            nameBox = Console.ReadLine();
            connectButton_click();

            Console.WriteLine("Введите сообщение для отправки на сервер");
            while (true)
            {
                chatBox += Console.ReadLine();
                if (chatBox == "/disconnect")
                {
                    controller.Disconnect(ClientID);
                    return;
                }
                sendMessageButton_blick(chatBox);
            }
        }
        private static void connectButton_click()
        {
            controller = new ClientController();

            string userName = nameBox;
            string IPAddress = ipBox;
            int port = portBox;

            ClientID = controller.Connect(userName, IPAddress, port);
            controller.AddCallBackMethod(ClientID, CallBackMethod);

            Console.WriteLine("Вас успешно было законекчено");
        }
        private static void sendMessageButton_blick(string message)
        {
            chatBox = "";
            controller.SendMessage(message, ClientID);
        }
        public static void CallBackMethod(string message)//метод который будет вызыватся когда модель захочет
        {
            Console.WriteLine(message);
            //controller.clients.FirstOrDefault(c => c.UserID == ClientID).messageDelegate += CallBackMethod;
        }
    }
}
