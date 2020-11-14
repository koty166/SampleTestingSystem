using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Data.SqlClient;

namespace Проект_к_школе
{
    public partial class NetworSetting : Form
    {
        readonly new Form1 ParentForm;
        public NetworSetting(Form1 _ParentForm)
        {
            ParentForm = _ParentForm;
            InitializeComponent();
        }
        static IPAddress IPS;

        static IPAddress ListenIP()
        {
            UdpClient Listener = new UdpClient(9091);
            IPEndPoint Source = null;

            Listener.EnableBroadcast = true;
            Listener.JoinMulticastGroup(IPAddress.Parse("230.1.1.1"), 50);
            Listener.Client.ReceiveTimeout = 3000;
            try
            {
                Listener.Receive(ref Source);
                Listener.Close();
                return Source.Address;
            }
            catch
            {
                Listener.Close();
            }
            return null;
        }

        private void Done_Click(object sender, EventArgs e) => Close();

        private void GetIP_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                NetworkStatys.Text = $"Попытка получить IP: {i} из 10";
                NetworkStatys.Refresh();
                IPS = ListenIP();
                if (IPS != null)
                    break;
            }
            if (IPS == null)
                NetworkStatys.Text = "Не удалось получить IP , введите самостоятельно";
            else
            {
                NetworkStatys.Text = "IP получен";
                IPsetup.Text = IPS.ToString();
            }
        }

        private void CheckConnections_Click(object sender, EventArgs e)
        {
            if (TryConnect())
            {
                ParentForm.IP = IPS;
                ParentForm.Enabled = true;
                this.Dispose();
            }
        }

        bool TryConnect()
        {
            TcpClient Sender = new TcpClient();
            Sender.Client.SendTimeout = 3000;
            for (int i = 1; i <= 10; i++)
            {
                NetworkStatys.Text = $"Попытка подключения: {i} из 10";
                NetworkStatys.Refresh();
                try
                {
                    Sender.Connect(IPAddress.Parse(IPsetup.Text), 9090);
                    IPS = IPAddress.Parse(IPsetup.Text);
                    Sender.Close();
                    return true;
                }
                catch
                {
                    NetworkStatys.Text = "Подключится не удалось";
                    Sender.Close();
                    return false;
                }
            }
            return false;
        }

        private void NetworSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IPS != null)
            {
                ParentForm.Enabled = true;
                ParentForm.IP = IPsetup.Text != "" ? IPAddress.Parse(IPsetup.Text) : IPAddress.Parse("127.0.0.1");
            }
        }
    }
}
