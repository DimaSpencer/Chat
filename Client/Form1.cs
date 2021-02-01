using Client.BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int UserID;
        public string UserName;
        public string IPAddress;
        public int Port;
        public ClientController ClientController;
        private bool _connected;
        private void CallBackMethod(string message) => chat.Items.Add(message);

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (_connected == false)
            {
                //TODO: тут должна быть проверка входных данных
                UserName = nameBox.Text;
                IPAddress = ipBox.Text;
                Port = int.Parse(portBox.Text);
                try
                {
                    ClientController = new ClientController();
                    UserID = ClientController.Connect(UserName, IPAddress, Port);
                    ClientController.AddCallBackMethod(UserID, CallBackMethod);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                connectButton.Text = "Disconnect";
                sendButton.Enabled = true;
                messageBox.Enabled = true;
                _connected = true;
                MessageBox.Show("Вы успешно присоеденились к чату", "Done", MessageBoxButtons.OK);
            }
            else
            {
                chat.Items.Clear();
                ClientController.Disconnect(UserID);
                connectButton.Text = "Connect";
                sendButton.Enabled = false;
                messageBox.Enabled = false;
                _connected = false;
                MessageBox.Show("Вы отключились от чата", "Done", MessageBoxButtons.OK);
            }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = messageBox.Text;
            messageBox.Text = string.Empty;

            ClientController.SendMessage(message, UserID);
        }
    }
}
