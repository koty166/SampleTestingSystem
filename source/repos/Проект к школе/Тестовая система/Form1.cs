using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LessonsResourses;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Security.Cryptography;
using NLog;

namespace Проект_к_школе
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const String Directory = "Tests";
        bool IsTestStart = false;
        int CurrentQuestion = -1, CurrentTask = 0;

        internal IPAddress IP;
        internal Pupil CurrentPup;
        
        
        Image NextImage;
        Test CurrentTest;
        List<Test> Tests = new List<Test>();
        List<CheckBox> Answers = new List<CheckBox>();

        //Done
        private void Form1_Load(object sender, EventArgs e)
        {
            BinaryFormatter Formated = new BinaryFormatter();
            FileStream Stream;
            String[] TestsStr = System.IO.Directory.GetFiles(Directory, "*.dat", SearchOption.AllDirectories);

            if (TestsStr.Length == 0)
            { 
                MessageBox.Show("Не найдены фалы уроков, проверьте их наличие в соответствующей директории", "Ошибка чтения", MessageBoxButtons.OK);
                Application.Exit();
                return;
            }

            foreach (var i in TestsStr)
            {
                Stream = new FileStream(i, FileMode.Open);
                Tests.Add((Test)Formated.Deserialize(Stream));
                Stream.Close();
            }
            foreach (var i in Tests)
                TestsLB.Items.Add(i.Name);
        }

        //Done
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && !IsTestStart)
            {
                NetworSetting n = new NetworSetting(this);
                n.Show();
                this.Enabled = false;
            }
        }

        //Done
        private void Start_Click(object sender, EventArgs e)
        {
            if (TestsLB.SelectedItem != null)
            {
                CurrentTest = Tests[TestsLB.SelectedIndex];
                IsTestStart = true;
                StartButton.Visible = false;
                TestsLB.Visible = false;

                Registration r = new Registration(this);
                r.Show();
                this.Enabled = false;  
            }
            else
                MessageBox.Show("Пожалуйста, выберите урок");
            //TODO: добавить проверку корректности структуры урока
        }

        /// <summary>
        /// Сохраняет пользователя локально
        /// </summary>
        /// <param name="_PupilData"></param>
        void EndLocal(byte[] _PupilData)
        {
            if (File.Exists(Directory + "\\Save.sav")) File.Delete(Directory + "\\Save.sav");

            FileStream s = new FileStream(Directory + "\\Save.sav", FileMode.Create);

            s.Write(_PupilData, 0, _PupilData.Length);
            s.Close();
        }

        /// <summary>
        /// Завершает тест, выполняет отправку данных на сервер и сохранение локально
        /// </summary>
        void EndTest()
        {
            byte[] PupilData;
            TcpClient Sender = new TcpClient();
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream s = new MemoryStream();
            NetworkStream stream;

            Sender.Client.SendTimeout = 3000;
            this.Enabled = false;
            this.Text = "Завершение теста...";

            b.Serialize(s, CurrentPup);
            PupilData = s.ToArray();
            s.Dispose();

            EndLocal(PupilData);

            for (int i = 1; i <= 5; i++)
            {
                this.Text = $"Попытка подкючения {i} из 5";
                try { Sender.Connect(IP, 9090); break; }
                catch { }
                Thread.Sleep(1000);
            }
            if (Sender.Connected)
            {
                byte[] RSAModulus=null, RSAExponent=null;
                int RSAModulusLenght, RSAExponentLenght;
                this.Text = "Подключение завершено. Отправка данных...";

                stream = Sender.GetStream();
                byte[] data = new byte[] { 1 };

                stream.Write(data, 0, 1);

                stream.Read(data,0,8);
                RSAModulusLenght = BitConverter.ToInt32(data,0);
                RSAExponentLenght = BitConverter.ToInt32(data, 4);

                stream.Read(RSAModulus,0, RSAModulusLenght);
                stream.Read(RSAExponent, 0, RSAExponentLenght);

                data = Encrypt(PupilData, RSAModulus,RSAExponent);

                stream.Write(BitConverter.GetBytes(data.Length), 0, 4);
                stream.Write(data, 0, data.Length);

                Sender.Close();
                
                this.Text = "передача данных завершёна успешно";
              

                Thread.Sleep(1500);
            }
            else
            {
                this.Text = "Подключение неудачно. Сохранение локально...";
                Thread.Sleep(1000);
                this.Text = "Сохранение локально завершено";
                this.Close();
                return;
            }
           
            this.Close();
        }

        void EndOfTime()
        {
        }

        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Начинает тест, выводит описание первой задачи. Инициализирует счётчики
        /// </summary>
        internal void Next2()
        {
            CurrentPup.DoneTest.Add(CurrentTest);
            QuestionStr.Text = CurrentPup.DoneTest[CurrentPup.DoneTest.Count - 1].Tasks[0].Description;

            CurrentTask = 0;
            CurrentQuestion = -1;

            QuestionStr.Visible = true;
            TestsLB.Visible = false;
            StartButton.Visible = false;

        }

        private void Next_Click(object sender, EventArgs e)
        {
            int CurTest = CurrentPup.DoneTest.Count - 1;
            string QuestionAnswer = CurrentPup.DoneTest[CurTest]?.Tasks[CurrentTask]?.Questions[0]?.Answer ?? "";

            if (CurrentQuestion != -1)
            {              
                 QuestionAnswer = CurrentPup.DoneTest[CurTest]?.Tasks[CurrentTask]?.Questions[CurrentQuestion]?.Answer ?? "";

                if (Answers.Count > 0)
                    foreach (CheckBox i in Answers)
                    {
                        if (i.Checked)
                            CurrentPup.DoneTest[CurTest].Tasks[CurrentTask].Questions[CurrentQuestion].Answer += i.Text + " ";
                    }
                if (AnswerTextTB.Text != "")
                    CurrentPup.DoneTest[CurTest].Tasks[CurrentTask].Questions[CurrentQuestion].Answer = AnswerTextTB.Text.ToLower().Trim();
                Answers.Clear();
                AnswerTextTB.Text = "";
            }


            if (CurrentQuestion == CurrentPup.DoneTest[CurTest].Tasks[CurrentTask].Questions.Count - 1 && CurrentTask == CurrentPup.DoneTest[CurTest].Tasks.Count - 1)
                EndTest();
            else if(CurrentQuestion == CurrentPup.DoneTest[CurTest].Tasks[CurrentTask].Questions.Count - 1)
            {
                CurrentTask++;
                QuestionStr.Text = CurrentPup.DoneTest[CurTest].Tasks[CurrentTask].Description;
                CurrentQuestion = -1;
                return;
            }
            else
                CurrentQuestion++;

            if (QuestionAnswer == "")
            {
                QuestionStr.Text = CurrentPup.DoneTest[CurTest].Tasks[CurrentTask].Questions[CurrentQuestion].QuestionText;

                AnswerTextTB.Visible = true;
                QuestionStr.Visible = true;
            }
            else
            {
                QuestionStr.Text = CurrentPup.DoneTest[CurTest].Tasks[CurrentTask].Questions[CurrentQuestion].QuestionText;

                AnswerTextTB.Visible = false;
                QuestionStr.Visible = true;

                int LastX = 45, LastY = 60, Num = 0;
                foreach (string i in QuestionAnswer.Split(' '))
                {
                    Answers.Add(new CheckBox()
                    {
                        Text = i,
                        Checked = false,
                        Parent = this,
                        Location = new Point(LastX, LastY)
                    });
                    Num++;
                    LastX += Num % 4 != 0 ? 0 : 200;
                    LastY += 40;
                }
            }

           
        }

        /// <summary>
        /// Шифрует данные при помощи открытого ключа
        /// </summary>
        /// <param name="Data">Данные для шифрования</param>
        /// <param name="RSAModulus">Модуль</param>
        /// <param name="RSAExponent">Экспонента</param>
        /// <returns>Зашифрованные данные</returns>
        static byte[] Encrypt(byte[] Data, byte[] RSAModulus,byte[] RSAExponent)
        {
            try
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(new RSAParameters() { Exponent = RSAExponent, Modulus = RSAModulus });
                    return RSA.Encrypt(Data, true);
                }
            }
            catch { /*лигоровать*/ return null; }
        }
    }
}

        

