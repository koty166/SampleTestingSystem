using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

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

            listener.JoinMulticastGroup(IPAddress.Parse("230.1.1.1"), 50);
            listener.EnableBroadcast = true;
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

        private void Done_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Application.OpenForms[0];
            f.Enabled = true;
            this.Dispose();
        }

        private void GetIP_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                NetworkStatys.Text = $"Попытка получить IP: {i} из 5";
                NetworkStatys.Refresh();
                if (ListenIP())
                    break;
            }
            if (IPS == null)
                NetworkStatys.Text = "Не удалось получить IP , введите самостоятельно";
            else
                IPsetup.Text = IPS.ToString();
        }

        private void CheckConnections_Click(object sender, EventArgs e)
        {
            
            if(TryConnect())
            {
                Form1 f = (Form1)Application.OpenForms[0];
                f.IP = IPS;
            }
        }
        bool TryConnect()
        {
            TcpClient Sender = new TcpClient();
            NetworkStream stream;
            bool connected = false;
            Sender.Client.SendTimeout = 3000;
            for (int i = 1; i <= 10; i++)
            {
                NetworkStatys.Text = $"Попытка подключения: {i} из 10";
                NetworkStatys.Refresh();
                try
                {
                    if (IPS == null)
                        Sender.Connect(IPAddress.Parse(IPsetup.Text), 9095);
                    else
                        Sender.Connect(IPS, 9095);
                    connected = true;
                    IPS = IPAddress.Parse(IPsetup.Text);
                    break;
                }
                catch { }
            }
            if (connected)
            {
                stream = Sender.GetStream();
                byte[] data = Encoding.ASCII.GetBytes("Try connect");

                stream.Write(data,0,data.Length);

                data = new byte[256];
                int bytes = stream.Read(data,0,data.Length);

                string text = Encoding.ASCII.GetString(data, 0, bytes);

                if (text == "OK")
                    NetworkStatys.Text = "Соединение установлено";

                stream.Close();
                return true;
            }
            NetworkStatys.Text = "Подключится не удалось";
           
            Sender.Close();
            return false;
        }
    }
}
