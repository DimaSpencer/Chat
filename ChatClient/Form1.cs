using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public User User { get; set; }
        private void button1_Click(object sender, EventArgs e)//connectButtom
        {
            User = new User(name.Text);

            string ip = ipBox.Text;
            if (int.TryParse(portBox.Text, out int port))
            {
                User.Connect(ip, port);
                GetMessages();
                MessageBox.Show("Вы вошли на сервер");
            }
            else
                throw new ArgumentException("Невалидные данные авторизации на сервер");
        }
        async public void GetMessages()
        {
            await Task.Run(() =>
            {
                byte[] buffer = new byte[256];
                User.NetworkStream.Read(buffer);

                listBox1.Text += Encoding.UTF8.GetString(buffer) + "\n";
                System.Threading.Thread.Sleep(400);
            });  
        }
        private void sendMessage_Click(object sender, EventArgs e)
        {
            User.SendMessasge(messageBox.Text);
            messageBox.Text = "";
        }
        private void FormClosing(object sender, EventArgs e)
        {
            User.NetworkStream.Close();
        }
    }
}
