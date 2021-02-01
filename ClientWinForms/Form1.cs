using Server;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string name;
        string ip;
        int port;
        Client client;
        bool connected = false;
        private void connectButton_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            if (connected == false)
            {
                Connect();
            }
            else
            {
                Disconnect();
            }
        }
        public void Connect()
        {
            name = nameBox.Text;
            ip = ipBox.Text;
            port = int.Parse(portBox.Text);
            client = new Client(name);

            if (client.TryConnect(ip, port))
            {
                chatBox.Items.Add($"Вы успешно подключились под ником {name}");
                connectButton.Text = "Disconnect";
                sendButton.Enabled = true;
                ipBox.Enabled = false;
                portBox.Enabled = false;
                nameBox.Enabled = false;

                connected = true;
            }
            else
            {
                MessageBox.Show("Ошибка подключения", "Error", MessageBoxButtons.OK);
                return;
            }
            ReadMessage();
        }
        public void Disconnect()
        {
            connected = false;
            connectButton.Text = "Connect";
            sendButton.Enabled = false;
            ipBox.Enabled = true;
            portBox.Enabled = true;
            nameBox.Enabled = true;

            client.Disconnect();
            MessageBox.Show("Соеденение разорвано", "Disconnect", MessageBoxButtons.OK);
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if(client.TcpClient.Connected)
                client.SendMessasge(messageBox.Text);
            messageBox.Text = "";
        }
        private void messageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (client.TcpClient.Connected)
                    client.SendMessasge(messageBox.Text);
                messageBox.Text = "";
            }
        }
        async public void ReadMessage()
        {
            await Task.Run(() =>
            {
                try
                {
                    while (client.TcpClient.Connected)
                    {
                        byte[] buffer = new byte[256];
                        client.NetworkStream.Read(buffer);
                        string message = Encoding.UTF8.GetString(buffer);
                        chatBox.Items.Add(message);

                        Task.Delay(10).Wait();
                    }
                }
                catch (Exception)
                {
                    //TODO: тут ошибка, оно прослушивает вечно без остановки, если мы останавливаем поток, выкидывается ошибка
                    MessageBox.Show("Произошло исключение и disconnect");
                    client.Disconnect();
                }
            });
        }
    }
}
