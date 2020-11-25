using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;
using AnalysisLibrary;
using LessonsResourses;
using System.Security.Cryptography;

namespace FormServer
{
    public partial class FormServer : Form
    {
        List<Pupil> ListOfPupil = new List<Pupil>(), AnaliseList = new List<Pupil>();
        static int NumOfSendingIPPackages = 0, PupilsData = 0;
        static string SendingIP;

        Thread ListeningData, BroadCastSending;
        public FormServer()
        {
            InitializeComponent();
        }

        void WriteInExel(List<Pupil> pupList , String ExcelName)
        {
           /* int n = 0;
            string[] MarkMass;

            
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

            ex.Visible = true;*/

        }

        private void FileSetupButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.ShowDialog();
            FileSetup.Text = openFileDialog1.SafeFileName; 

        }

        /// <summary>
        /// Выполняет анализ, в зависимости от выбранного варианта
        /// </summary>
        void Analysis()
        {
            switch(TypeOfAnalis.SelectedIndex)
            {
                case 0:
                    if (AnalysisClass.MotivationAnalysis(AnaliseList) == 1)
                    {
                        MessageBox.Show("Ошибка обработки , смените дамп");
                        return;
                    }
                    break;
                case 1:
                    if (AnalysisClass.ShcoolCognitiveActivityTestAnalysis(AnaliseList) == 1)
                    {
                        MessageBox.Show("Ошибка обработки , смените дамп");
                        return;
                    }
                    break;
                case 2:
                    {
                        WriteInExel(AnaliseList, "Showed exel");
                        return;
                    }
            }
        }

        private void BeginAnalysis_Click(object sender, EventArgs e)
        {
            if (TypeOfAnalis.SelectedItem == null||FileSetup.Text == "") return;
            Analysis();
        }

        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Path = $@"/Saves/{DateTime.Today}";
            int i = 0;
            if (File.Exists(Path))
                while (true)
                {
                    i++;
                    if (!File.Exists($@"/Saves/{DateTime.Today}_{i}.sav"))
                        break;
                }

            FileStream f = new FileStream(Path, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, ListOfPupil);
            f.Close();
            

            BroadCastSending.Abort();
            ListeningData.Abort();
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
             BroadCastSending = new Thread(new ThreadStart(SendIP));
            BroadCastSending.Start();
             ListeningData = new Thread(new ParameterizedThreadStart(ReadConnection));
            ListeningData.Start(ListOfPupil);
        }

        private void AddData_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open);
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
            AnaliseList.AddRange(pupList);
        }

        /// <summary>
        /// Бродкастом рассылает свой IP
        /// </summary>
        static void SendIP()
        {
            UdpClient sender = new UdpClient();
            IPEndPoint ipend = new IPEndPoint(IPAddress.Parse("230.1.1.1"), 9091);

            byte[] data = Encoding.UTF8.GetBytes(SendingIP ?? Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
            sender.EnableBroadcast = true;
            while (true)
            {
                Thread.Sleep(1000);
                sender.Send(data, data.Length, ipend);
                NumOfSendingIPPackages++;
            }         
        }

        /// <summary>
        /// Считывает и дешфрует данные ученика
        /// </summary>
        /// <param name="_Pupils">Список для добавления</param>
        static void ReadConnection(object _Pupils)
        {
            TcpListener TCPListener = new TcpListener(IPAddress.Loopback,9090);;
            BinaryFormatter b = new BinaryFormatter();
            NetworkStream stream;
            MemoryStream Mem = new MemoryStream();
            List<Pupil> Pupils =  (List<Pupil>)_Pupils;

            int Length;
            try
            {
                while (true)
                {
                    TCPListener.Start();
                    TcpClient TCPCl = TCPListener.AcceptTcpClient();

                    stream = TCPCl.GetStream();
                    byte[] data = new byte[1];
                    stream.Read(data, 0, data.Length);

                    if (data[0] == 1)
                    {
                        RSACryptoServiceProvider RSA= new RSACryptoServiceProvider();
                        RSAParameters RSAinfo= RSA.ExportParameters(false);
                        stream.Write(BitConverter.GetBytes(RSAinfo.Modulus.Length),0,4);
                        stream.Write(BitConverter.GetBytes(RSAinfo.Exponent.Length), 0, 4);

                        stream.Write(RSAinfo.Modulus, 0, RSAinfo.Modulus.Length);
                        stream.Write(RSAinfo.Exponent, 0, RSAinfo.Exponent.Length);

                        stream.Read(data, 0, 4);
                        Length = BitConverter.ToInt32(data,0);
                        stream.Read(data,0,Length);
                        data = RSA.Decrypt(data, true);
                        Mem.Write(data, 0, data.Length);

                        lock(Pupils)
                            Pupils.Add((Pupil)b.Deserialize(Mem));

                        PupilsData++;
                    }
                }
            }
            catch(Exception ex) {  }
        }
    }
}
