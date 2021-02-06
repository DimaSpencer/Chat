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
        private bool _connected = false;
        private void ShowMessage(string message)
        {
            if (InvokeRequired)
                Invoke((Action<string>)ShowMessage, message);
            else
                chat.Items.Add(message);
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (_connected == false)
            {
                #region ChackInputData
                if (string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBox.Show("Поле с именем не может быть пустым", "Error", MessageBoxButtons.OK);
                    return;
                }
                if(string.IsNullOrWhiteSpace(ipBox.Text))
                {
                    MessageBox.Show("Поле c IP не должно быть пустым", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(portBox.Text))
                {
                    MessageBox.Show("Поле c портом не должно быть пустым", "Error", MessageBoxButtons.OK);
                    return;
                }
                #endregion
                UserName = nameBox.Text;
                IPAddress = ipBox.Text;
                Port = int.Parse(portBox.Text);
                try
                {
                    ClientController = new ClientController();
                    UserID = ClientController.Connect(UserName, IPAddress, Port);
                    ClientController.AddCallBackMethod(UserID, ShowMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                connectButton.Text = "Disconnect";
                nameBox.Enabled = false;
                ipBox.Enabled = false;
                portBox.Enabled = false;
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
                nameBox.Enabled = true;
                ipBox.Enabled = true;
                portBox.Enabled = true;
                sendButton.Enabled = false;
                messageBox.Enabled = false;
                _connected = false;
                MessageBox.Show("Вы отключились от чата", "Done", MessageBoxButtons.OK);
            }
        }
        private void connectButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connectButton_Click(sender, e);
            }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = messageBox.Text;
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }
            messageBox.Text = string.Empty;

            ClientController.SendMessage(message, UserID);
        }
        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click(sender, e);
            }
        }
    }
}
