using Server;

namespace Chat
{
    class Server
    {
        static void Main(string[] args)
        {
            ServerLogic server = new ServerLogic();
            server.Start();
        }
    }
}
