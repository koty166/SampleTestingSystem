using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using ClassLibrary2;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace ConsoleServer
{
    class Program
    {
       static List<Pupil> ListOfPupil = new List<Pupil>();
        static bool done = true;
       static void Tree()
        {
            Console.WriteLine("1 - Ожидать подключения \n2 - отобразить полученные данные в Exel\n3 - Отправить IP");
            switch(Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    FileTools.Log("Choosen wait for connections");
                    int a;
                    Console.WriteLine("Введите колл-во учеников");
                    a = Convert.ToInt32(Console.ReadLine());
                    Thread f = new Thread(new ParameterizedThreadStart(WaitForConnection));
                    f.Start(a);

                    break;
                case 2:
                    String n = "1";
                    FileTools.Log("Choosen show on Exel");
                    if (!done) break;

                    ///////////////garbage collectiong.Killing exel process
                    try
                    {
                        foreach (Process item in Process.GetProcessesByName("EXCEL"))
                        {
                            item.Kill();
                        }
                    }
                    catch { }
                    /////////////////////////

                    Application ex = new  Application();
                    Workbook WorkBook;
                    Worksheet WorkSheet;

                    WorkBook = ex.Workbooks.Add();
                    WorkSheet = ex.Worksheets[1];

                   //ListOfPupil.Add(new Pupil(
                 //     15,2,"awd","awd","awd"
                 //     ));
                 //  for (int i = 0; i < 10; i++)
                 //      ListOfPupil[0].AnswerList.Add(i.ToString());
                    int j = 0;

                    foreach (var item in ListOfPupil)
                    {
                        for (int i = 0; i < item.AnswerList.Count; i++)
                        {
                            WorkSheet.Cells[j * 7 + 1, i + 6] = "№" + (i + 1);
                        }
                        WorkSheet.Cells[7 * j + 1, 1] = "Данные";
                        WorkSheet.Cells[7 * j + 1, 4] = "Результаты";

                        WorkSheet.Cells[7 * j + 2, 1] = "Имя:";
                        WorkSheet.Cells[7 * j + 3, 1] = "Фамилия:";
                        WorkSheet.Cells[7 * j + 4, 1] = "Отчество:";
                        WorkSheet.Cells[7 * j + 5, 1] = "Возраст:";
                        WorkSheet.Cells[7 * j + 6, 1] = "Класс:";

                        WorkSheet.Cells[7 * j + 2, 2] = item.Name;
                        WorkSheet.Cells[7 * j + 3, 2] = item.Surname;
                        WorkSheet.Cells[7 * j + 4, 2] = item.Patronymic;
                        WorkSheet.Cells[7 * j + 5, 2] = item.Age;
                        WorkSheet.Cells[7 * j + 6, 2] = item.Form;

                        for (int i = 0; i < item.AnswerList.Count; i++)
                        {
                            WorkSheet.Cells[j * 7 + 2, i + 6] = item.AnswerList[i];
                        }
                        j++;
                    }


                   
                    Console.WriteLine("Сохранить?(y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        while (true)
                        {
                            n = ((int.Parse(n) + 1).ToString());
                            if (!File.Exists(Environment.CurrentDirectory + "\\Saves\\Excel" + n + ".xlsx"))
                                break;
                        }
                        if (!Directory.Exists("Saves\\")) Directory.CreateDirectory("Saves\\");

                        WorkBook.SaveAs(Environment.CurrentDirectory+"\\Saves\\Excel" + n + ".xlsx",
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing);
                        Console.WriteLine("Saved sucseed");
                    }

                    ex.Visible = true;
                    
                    
                    break;
                case 3:
                    FileTools.Log("Choosen Send IP");
                    int b;
                    Console.WriteLine("Введите колл-во отправок. Интервал - 1 сек");
                    b = Convert.ToInt32(Console.ReadLine());
                    Thread f1 = new Thread(new ParameterizedThreadStart(SendIP));
                    f1.Start(b);
                    break;
                default:
                    Console.WriteLine("Неправельный ввод");
                    break;
            }
            Tree();
        }
        static void SendIP(object b)
        {
            UdpClient sender = new UdpClient();
            IPEndPoint ipend = new IPEndPoint(IPAddress.Parse("230.1.1.1"), 9091);
            byte[] data = Encoding.UTF8.GetBytes(Dns.GetHostEntry(Dns.GetHostName().ToString()).AddressList[1].ToString());
            sender.EnableBroadcast = true;
            for (int i = 0; i < (int)b; i++)
            {
                Thread.Sleep(1000);
                sender.Send(data, data.Length, ipend);
                FileTools.Log($"Send ip {i + 1} of {(int)b + 1}");
            }

            sender.Close();
            Console.WriteLine("Отправка завершена");
            FileTools.Log("Sending IP end");
        }

        static void WaitForConnection(object many)
        {
            TcpListener l = new TcpListener(9090);
            NetworkStream stream;
            int dones = 0;
            FileTools.Log("Wait connection started , pupils - " + (int)many);
            while (true)
            {
                l.Start();
                TcpClient read = l.AcceptTcpClient();

                stream = read.GetStream();
                byte[] data = new byte[1];
                stream.Read(data, 0, data.Length);

                if (data[0] == 0)
                {
                    data = new byte[1] { 2 };

                    stream.Write(data, 0, data.Length);

                    stream.Close();
                    read.Close();
                    FileTools.Log("Send OK to try-connection request");
                }
                else if (data[0] == 1)
                {
                   
                    BinaryFormatter f = new BinaryFormatter();
                    Pupil pup;

                    pup = (Pupil)f.Deserialize(stream);

                    ListOfPupil.Add(pup);

                    FileTools.Log($"Pupil {dones} data is get");
                    Console.WriteLine("Получены данные ученика");

                    dones++;
                    if (dones == (int)many)
                    {
                        Console.WriteLine("Получены все резульаты");
                        done = true;
                        FileTools.Log("Wait connection end , all pupils send data");
                        FileTools.Save(ListOfPupil);
                        return;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            FileTools.Log("Application load");
            Tree();
        }
    }
}
