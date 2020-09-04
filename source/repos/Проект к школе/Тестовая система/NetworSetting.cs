using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using ClassLibrary2;
using System.IO;
using Tools;

namespace Проект_к_школе
{
    public partial class NetworSetting : Form
    {
        public NetworSetting()
        {
            InitializeComponent();
        }
        static IPAddress IPS;

        static bool ListenIP()
        {
            UdpClient listener = new UdpClient(9091);
            IPEndPoint ipend = null;
            byte[] data;

            listener.EnableBroadcast = true;
            listener.JoinMulticastGroup(IPAddress.Parse("230.1.1.1"), 50);
            listener.Client.ReceiveTimeout = 3000;
            try
            {
                data = listener.Receive(ref ipend);
            }
            catch
            {
                listener.Close();
                return false;
            }

            IPS = IPAddress.Parse(Encoding.UTF8.GetString(data));
            listener.Close();

            if (IPS != null)
                return true;

            return false;
        }

        private void Done_Click(object sender, EventArgs e) => Close();

        private void GetIP_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                NetworkStatys.Text = $"Попытка получить IP: {i} из 10";
                FileTools.Log($"Try to get IP: {i} of 10");
                NetworkStatys.Refresh();
                if (ListenIP())
                    break;
            }
            if (IPS == null)
            {
                NetworkStatys.Text = "Не удалось получить IP , введите самостоятельно";
                FileTools.Log("IP wasn`t get");
            }
            else
            {
                NetworkStatys.Text = "IP получен";
                IPsetup.Text = IPS.ToString();
                FileTools.Log("IP was get");
            }
        }

        private void CheckConnections_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Application.OpenForms[0];
            if (TryConnect())
                f.IP = IPS;
        }

        bool TryConnect()
        {
            FileTools.Log("Connection-try start");

            TcpClient Sender = new TcpClient();
            NetworkStream stream;
            bool connected = false;
            Sender.Client.SendTimeout = 3000;
            for (int i = 1; i <= 10; i++)
            {
                NetworkStatys.Text = $"Попытка подключения: {i} из 10";
                FileTools.Log($"Connection try: {i} of 10");
                NetworkStatys.Refresh();
                try
                {
                    Sender.Connect(IPAddress.Parse(IPsetup.Text), 9090);
                    connected = true;
                    break;
                }
                catch { }
            }
            if (connected)
            {
                stream = Sender.GetStream();
                byte[] data = new byte[1] { 0 };

                stream.Write(data,0,data.Length);

                data = new byte[1];
                int bytes = stream.Read(data,0,data.Length);

                if (data[0] == 2)
                    NetworkStatys.Text = "Соединение установлено";

                stream.Close();

                IPS = IPAddress.Parse(IPsetup.Text);
                FileTools.Log($"Connected sucsseed by address: {IPS}");

                return true;
            }
            NetworkStatys.Text = "Подключится не удалось";
            FileTools.Log("Connection failed");

            Sender.Close();
            return false;
        }

        private void NetworSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f = (Form1)Application.OpenForms[0];
            f.Enabled = true;
            f.IP = IPsetup.Text != "" ? IPAddress.Parse(IPsetup.Text) : IPAddress.Parse("127.0.0.1");
            FileTools.Log("Network setting is closed");
        }
    }
}
