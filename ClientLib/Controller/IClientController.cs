using System;
using System.Collections.Generic;
using System.Text;

namespace Client.BL.Controller
{
    interface IClientController
    {
        int Connect(string userName, string ip, int port);
        void Disconnect(int userID);
        void SendMessage(string message, int userID);
    }
}
