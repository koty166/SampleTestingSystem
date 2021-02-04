using System;
using System.Collections.Generic;
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
using ClassLibrary2.Security;

namespace FormServer
{
    public partial class FormServer : Form
    {
        static List<Pupil> ListOfPupil = new List<Pupil>();
        static int NumOfSendingIPPackages = 0, IPChecking = 0 , PupilsData = 0;
        static string SendingIP;
        static byte[] Key = new byte[256];
        Thread IPsender = null, DataListener = null;

        public FormServer()
        {
            InitializeComponent();
        }

        void WriteInExel(List<Pupil> pupList , String ExcelName)
        {
            int n = 0;
            string[] MarkMass;

            FileTools.Log("Choosen show on Exel");
            
            if (pupList.Count == 0) return;

            ///////////////garbage collecting.Killing exel proceses
            try
            {
                foreach (Process item in Process.GetProcessesByName("EXCEL"))
                    item.Kill();
            }
            catch { }
            /////////////////////////
            Microsoft.Office.Interop.Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
            Workbook WorkBook;
            Worksheet WorkSheet;

            WorkBook = ex.Workbooks.Add();
            WorkSheet = ex.Worksheets[1];
            if (ex.Worksheets.Count == 1)
                ex.Worksheets.Add(After: ex.Worksheets[1]);

            int j = 0, k = pupList[0].args[0] != null ? int.Parse(pupList[0].args[0]) : 7;
            try
            {
                foreach (var item in pupList)
                {
                    for (int i = 0; i < item.AnswerList.Count; i++)
                    {
                        WorkSheet.Cells[k * j + 1, i + 6] = "№" + (i + 1);
                    }
                    WorkSheet.Cells[k * j + 1, 1] = "Данные";
                    WorkSheet.Cells[k * j + 1, 4] = "Результаты";

                    WorkSheet.Cells[k * j + 2, 1] = "Имя:";
                    WorkSheet.Cells[k * j + 3, 1] = "Фамилия:";
                    WorkSheet.Cells[k * j + 4, 1] = "Отчество:";
                    WorkSheet.Cells[k * j + 5, 1] = "Возраст:";
                    WorkSheet.Cells[k * j + 6, 1] = "Класс:";

                    WorkSheet.Cells[k * j + 2, 2] = item.Name;
                    WorkSheet.Cells[k * j + 3, 2] = item.Surname;
                    WorkSheet.Cells[k * j + 4, 2] = item.Patronymic;
                    WorkSheet.Cells[k * j + 5, 2] = item.Age;
                    WorkSheet.Cells[k * j + 6, 2] = item.Form;

                    for (int i = 0; i < item.AnswerList.Count; i++)
                    {
                        WorkSheet.Cells[k * j + 2, i + 6] = item.AnswerList[i];
                    }
                    if (item.MarkForTest != null)
                    {
                        MarkMass = item.MarkForTest.Split(';');

                        WorkSheet.Cells[j * k + 1, item.AnswerList.Count + 6] = "Результаты анализа:";

                        int m = 1;
                        foreach (var i in MarkMass)
                        {
                            WorkSheet.Cells[j * k + m, item.AnswerList.Count + 9] = i;
                            m++;
                        }
                    }
                    j++;

                }

                if (pupList[0].MarkForTest != null)
                {
                    WorkSheet = ex.Worksheets[2];
                    j = 2;

                    WorkSheet.Cells[1, 1] = "ФИО:";

                    string[] Title = pupList[0].args[3].Split(';');

                    for (int i = 0; i < Title.Length; i++)
                    {
                        WorkSheet.Cells[1, i + 2] = Title[i];
                    }
                    //////////////////
                    foreach (var item in pupList)
                    {
                        MarkMass = item.args[2].Split(';');
                        WorkSheet.Cells[j, 1] = $"{item.Surname} {item.Name} {item.Patronymic}";

                        for (int i = 0; i < MarkMass.Length; i++)
                            WorkSheet.Cells[j, i + 2] = MarkMass[i];

                        j++;
                    }
                }
            }
            catch(Exception exep) { FileTools.Log(exep.Message); }
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

        private void SendingIPStart_Click(object sender, EventArgs e)
        {
            if (IsDefaulIP.Checked)
                SendingIP = IPSetup.Text;
            else
                SendingIP = Dns.GetHostEntry(Dns.GetHostName().ToString()).AddressList[1].ToString();

            IPSetup.Text = SendingIP.ToString();

            IPsender = new Thread(new ParameterizedThreadStart(SendIP));
            IPsender.Start(Convert.ToInt32(NumPackagesSetup.Value.ToString()));
            FileTools.Log("Sending IP started");
            IsSendingAlive.Text = "Выполняется рассылка IP...";
            SendingIPGroupbox.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (IPsender != null && !IPsender.IsAlive)
                {
                    SendingIPGroupbox.Enabled = true;
                    IsSendingAlive.Text = "Рассылка IP закончена";
                    SendingIPStatisticLabel.Text = "Отправленно IP - пакетов:" + NumOfSendingIPPackages.ToString();
                }
            }
            catch { }
            try
            {
                if (DataListener != null && !DataListener.IsAlive)
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
            FileTools.Log("File choosen:" + openFileDialog1.FileName);

        }

        void Analysis(String FileForAnalysisPath)
        {
            FileStream f = new FileStream(FileForAnalysisPath,FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            List<Pupil> pupList = null;
            
            try
            {
              pupList = (List<Pupil>)b.Deserialize(f);
            }
            catch
            {
                f.Seek(0, SeekOrigin.Begin);
                pupList = new List<Pupil>();
                pupList.Add((Pupil)b.Deserialize(f));    
            }

            f.Close();

            switch(TypeOfAnalis.SelectedIndex)
            {
                case 0:
                    if (AnalysisClass.MotivationAnalysis(pupList) == 1)
                    {
                        MessageBox.Show("Ошибка обработки , смените дамп");
                        return;
                    }
                    break;
                case 1:
                    if (AnalysisClass.ShcoolCognitiveActivityTestAnalysis(pupList) == 1)
                    {
                        MessageBox.Show("Ошибка обработки , смените дамп");
                        return;
                    }
                    break;
                case 2:
                    {
                        WriteInExel(pupList,"Showed exel");
                        return;
                    }
            }

            WriteInExel(pupList,"ModifiedExcel");

        }

        private void BeginAnalysis_Click(object sender, EventArgs e)
        {
            if (TypeOfAnalis.SelectedItem == null||FileSetup.Text == "" || FileSetup.Text == null) return;
            Analysis(openFileDialog1.FileName);
        }

        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IPsender != null && IPsender.IsAlive)
                IPsender.Abort();
            if ( DataListener != null && DataListener.IsAlive)
            {
                ////Sending TCP connection need to rigth end of waiting connections
                TcpClient t = new TcpClient();
                t.Connect("localhost", 9090);
                t.Close();
                /////////////////
                DataListener.Abort();
            }
            if (ListOfPupil.Count > 0)
                FileTools.Save(ListOfPupil);
            FileTools.Log("Form server is close");
        }

        private void FromTxt_Click(object sender, EventArgs e)
        {
           
            Pupil p = null;
            for (int i = 0; i < 2; i++)
            {
                StreamReader r = new StreamReader(Environment.CurrentDirectory + "\\read.txt");
                p = new Pupil();
                string[] mas = r.ReadLine().Split(' ');
                p.Name = mas[0];
                p.Surname = mas[1];
                p.Patronymic = mas[2];
                p.Age = byte.Parse(mas[3]);
                p.Form = byte.Parse(mas[4]);
                p.IsMale = bool.Parse(mas[5]);//////Need to write - "true"
                while (true)
                {
                    string s = r.ReadLine();
                    if (s == "0") break;
                    p.AnswerList.Add(s);
                }
                r.Close();
                ListOfPupil.Add(p);
            }
            
            MessageBox.Show("Done");
        }

        private void FormServer_Load(object sender, EventArgs e) => FileTools.Clear();

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

            FileTools.Log("Listen data is start");
        }

        static int IntFromBytes(byte[] Bytes)
        {
            int Out = 1;
            foreach (var i in Bytes)
                Out *= (int)i;
            return Out;
        }

        static void WaitForConnection(object many)
        {
            TcpListener l = new TcpListener(9090);
            Random r = new Random();
            BinaryFormatter b = new BinaryFormatter();
            NetworkStream stream;
            List<Pupil> BufList = new List<Pupil>();
            int dones = 0;
            FileTools.Log("Wait connection started , pupils - " + (int)many);

            try
            {
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
                        Pupil pup;
                        int NumOfBytes;
                        byte BufByte;

                       for (int i = 0; i < 256; i++)
                            Key[i] = (byte)r.Next(0, 64);

                        stream.Write(Key,0,256);

                        data = new byte[4];
                        stream.Read(data,0,data.Length);
                        NumOfBytes = BitConverter.ToInt32(data,0);

                       
                         
                        for (int i = 0; i < 256; i++)
                        {
                            BufByte = (byte)(63 - Key[i]);
                            Key[i] = BufByte;
                        }

                        foreach (var item in Key)
                        {
                            FileTools.Log(item.ToString());
                        }
                        FileTools.Log("  ");


                        data = new byte[NumOfBytes];
                        stream.Read(data,0,NumOfBytes);

                        pup = (Pupil)DecryptClass.Decrypt(data,Key);
                        

                        BufList.Add(pup);

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
                            ListOfPupil = BufList;
                            FileTools.Save(BufList, Environment.CurrentDirectory + "\\Saves\\Save" + n.ToString() + ".sav");
                            break;
                        }

                    }
                }
            }
            catch(Exception ex) { FileTools.Log(ex.Message); }
        }
    }
}
