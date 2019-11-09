using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener l = new TcpListener(9095);
            NetworkStream stream;
            Console.WriteLine("Begin listen");
            l.Start();
            TcpClient read = l.AcceptTcpClient();


            stream = read.GetStream();
            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            if (Encoding.ASCII.GetString(data, 0, bytes) == "Try connect")
                Console.WriteLine( "Соединение установлено");

            data = Encoding.ASCII.GetBytes("OK");

            stream.Write(data, 0, data.Length);
           
           
           
            Console.WriteLine("Sent OK");
            stream.Close();
            read.Close();
            Console.ReadLine();
        }
    }
}
