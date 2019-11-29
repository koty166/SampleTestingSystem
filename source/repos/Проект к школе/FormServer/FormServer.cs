using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ClassLibrary2;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;
using AnalysisLibrary;

namespace FormServer
{
    public partial class FormServer : Form
    {
        static List<Pupil> ListOfPupil = new List<Pupil>();
        static int NumOfSendingIPPackages = 0, IPChecking = 0 , PupilsData = 0;
        static string SendingIP;
        Thread IPsender, DataListener;

        public FormServer()
        {
            InitializeComponent();
        }

        void WriteInExel(List<Pupil> pupList , String ExcelName)
        {
            int n = 0;
            


            FileTools.Log("Choosen show on Exel");
            
            if (pupList.Count == 0) return;

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
            Microsoft.Office.Interop.Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
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

            foreach (var item in pupList)
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
                if (item.MarkForTest != null)
                {
                    WorkSheet.Cells[j * 7 + 1, item.AnswerList.Count + 6] = "Результаты анализа:";

                    WorkSheet.Cells[j * 7 + 1, item.AnswerList.Count + 9] = item.arg[0];
                    WorkSheet.Cells[j * 7 + 2, item.AnswerList.Count + 9] = item.arg[1];
                    WorkSheet.Cells[j * 7 + 3, item.AnswerList.Count + 9] = item.arg[2];
                    WorkSheet.Cells[j * 7 + 4, item.AnswerList.Count + 9] = item.arg[3];
               
                    WorkSheet.Cells[j * 7 + 5, item.AnswerList.Count + 9] = $"Уровень:{item.MarkForTest}";
                }
                j++;
            }

            DialogResult d = MessageBox.Show("Сохранить файл Exel в папку приложения?", "Сохранить", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                while (true)
                {
                    n++;
                    if (!File.Exists(Environment.CurrentDirectory + $"\\Saves\\{ExcelName}" + n.ToString() + ".xlsx"))
                        break;
                }
                if (!Directory.Exists("Saves\\")) Directory.CreateDirectory("Saves\\");

                WorkBook.SaveAs(Environment.CurrentDirectory + $"\\Saves\\{ExcelName}" + n + ".xlsx",
                  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                  Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing,
                  Type.Missing, Type.Missing);

                FileTools.Log("Saved exel successfully");
            }

            ex.Visible = true;

        }

        private void FormServer_Load(object sender, EventArgs e)
        {

        }

        private void SendingIPStart_Click(object sender, EventArgs e)
        {
            if (IsDefaulIP.Checked)
                SendingIP = IPSetup.Text;
            else
                SendingIP = Dns.GetHostEntry(Dns.GetHostName().ToString()).AddressList[1].ToString();

            IPsender = new Thread(new ParameterizedThreadStart(SendIP));
            IPsender.Start(Convert.ToInt32(NumPackagesSetup.Value.ToString()));

            IsSendingAlive.Text = "Выполняется рассылка IP...";
            SendingIPGroupbox.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!IPsender.IsAlive)
                {
                    SendingIPGroupbox.Enabled = true;
                    IsSendingAlive.Text = "Рассылка IP закончена";
                    SendingIPStatisticLabel.Text = "Отправленно IP - пакетов:" + NumOfSendingIPPackages.ToString();
                }
            }
            catch { }
            try
            {
                if (!DataListener.IsAlive)
                {
                    ListeningDataGroupBox.Enabled = true;
                    IsListenAlive.Text = "Рассылка IP закончена";
                    GetingDataStatistic.Text = "Полученно данных учеников:" + PupilsData.ToString();
                    TryConeectionStatisticLabel.Text = "Проверок IP:" + IPChecking.ToString();
                    BeginAnalysis.Enabled = true;
                    FileSetupButton.Enabled = true;
                }
            }
            catch { }

            PupilsPackgesNumber.Text = "Данных полученно:" + ListOfPupil.Count.ToString();
        }

        private void ShowOnExel_Click(object sender, EventArgs e)
        {
            try { if (DataListener.IsAlive) return; }
            catch { }
            WriteInExel(ListOfPupil,"Excel");
        }

        private void FileSetupButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.ShowDialog();
            FileSetup.Text = openFileDialog1.SafeFileName;
           
        }

        void Analysis(String FileForAnalysisPath)
        {
            FileStream f = new FileStream(FileForAnalysisPath,FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            List<Pupil> pupList;

            try
            {
              pupList = (List<Pupil>)b.Deserialize(f);
            }
            catch
            {
                pupList = new List<Pupil>
                {
                    (Pupil)b.Deserialize(f)
                };
            }

            switch(TypeOfAnalis.SelectedIndex)
            {
                case 0:
                     AnalysisClass.MotivationAnalysis(pupList);
                    break;
            }

            WriteInExel(pupList,"ModifiedExcel");

        }

        private void BeginAnalysis_Click(object sender, EventArgs e)
        {
            if (TypeOfAnalis.SelectedItem == null||FileSetup.Text == "" || FileSetup.Text == null) return;
            Analysis(openFileDialog1.FileName);
        }

        static void SendIP(object b)
        {
            UdpClient sender = new UdpClient();
            IPEndPoint ipend = new IPEndPoint(IPAddress.Parse("230.1.1.1"), 9091);

            byte[] data = Encoding.UTF8.GetBytes(SendingIP);
            sender.EnableBroadcast = true;

            for (int i = 0; i < (int)b; i++)
            {
                Thread.Sleep(1000);
                sender.Send(data, data.Length, ipend);
                FileTools.Log($"Send ip {i + 1} of {(int)b + 1}");
                NumOfSendingIPPackages++;
            }

            sender.Close();
            FileTools.Log("Sending IP end");
 
        }

        private void ListenStart_Click(object sender, EventArgs e)
        {
            DataListener = new Thread(new ParameterizedThreadStart(WaitForConnection));
            DataListener.Start(Convert.ToInt32(NumOfPupils.Value.ToString()));

            IsListenAlive.Text = "Ожидаются данные...";
            ListeningDataGroupBox.Enabled = false;
            BeginAnalysis.Enabled = false;
            FileSetupButton.Enabled = false;
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
                    IPChecking++;
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
                    PupilsData++;
                    if (dones == (int)many)
                    {
                        int n = 0;
                        FileTools.Log("Wait connection end , all pupils send data");
                        MessageBox.Show("Все данные получены");
                        while (true)
                        {
                            n++;
                            if (!File.Exists(Environment.CurrentDirectory + "\\Saves\\Save" + n.ToString() + ".sav"))
                                break;
                        }
                        if (!Directory.Exists("Saves\\")) Directory.CreateDirectory("Saves\\");

                        FileTools.Save(ListOfPupil, Environment.CurrentDirectory + "\\Saves\\Save" + n.ToString() + ".sav");
                        break;
                    }
                }
            }
        }
    }
}
