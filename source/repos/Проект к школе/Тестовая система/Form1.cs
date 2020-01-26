using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary2;
using System.Net;
using System.Net.Sockets;
using ClassLibrary2.Security;

namespace Проект_к_школе
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String directory = @"Tests";
        bool IsTestStar = false, IsAdmin = false;
        byte CurrentQuestion = 0, CurrentExplanationIndex = 0;
        internal IPAddress IP;
        Image NextImage;

        internal Lesson[] Lesson_mass;

        internal Lesson CurrentLesson;
        internal Pupil pupil;

        void Load_in_form()
        {
            try
            {
                if (Lesson_mass.Length != 0)
                    foreach (var i in Lesson_mass)
                    {
                        list_of_lessons.Items.Add(i.Name);
                    }
                FileTools.Log("List of lesson is rewrited");
            }
            catch { }

        } 

        void LoadPicture(Object _q)
        {
            ImageQuestion q = (ImageQuestion)_q;
            try
            {
                NextImage = Image.FromFile(directory + $"//images//{q.image_name}");
                FileTools.Log("Picture load sucseed , path:" + directory + $"//images//{q.image_name}");
            }
            catch
            {
                NextImage = Image.FromFile(directory + $"//images//Error.png");
                FileTools.Log("Picture load failed , load error picture");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] File_mass_date;
            FileTools.Clear();
            File_mass_date = Directory.GetFiles(directory, "*.dat");

            if (File_mass_date.Length != 0)
            {
                Lesson_mass = new Lesson[File_mass_date.Length];

                for (int i = 0; i < File_mass_date.Length; i++)
                {
                    FileStream Stream = new FileStream(File_mass_date[i], FileMode.Open);
                    BinaryFormatter Formated = new BinaryFormatter();

                    Lesson_mass[i] = (Lesson)Formated.Deserialize(Stream);
                    Stream.Close();
                }
            }
            Load_in_form();
            FileTools.Log($"Proggram load sucseed number of lesson - {Lesson_mass.Length.ToString()}");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && !IsTestStar)
            {
                NetworSetting n = new NetworSetting();
                n.Show();
                this.Enabled = false;
                FileTools.Log("Network setting is opened");
            }
            if (e.Control && e.KeyCode == Keys.A && !IsTestStar)
                IsAdmin = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (list_of_lessons.SelectedItem != null)
            {
                
                IsTestStar = true;

                Start.Visible = false;
                list_of_lessons.Visible = false;

                Registration r = new Registration();
                r.Show();
                FileTools.Log("Registration is began");
                this.Enabled = false;

                FileTools.Log($"Test {Lesson_mass[list_of_lessons.SelectedIndex]} is started");
                CurrentLesson = Lesson_mass[list_of_lessons.SelectedIndex];     
            }
        }

        void EndLocal()
        {
            if (File.Exists(directory + "\\Save.sav")) File.Delete(directory + "\\Save.sav");
            BinaryFormatter b = new BinaryFormatter();
            FileStream s = new FileStream(directory + "\\Save.sav", FileMode.Create);
            b.Serialize(s, pupil);
            s.Close();
            FileTools.Log($"Save local end.Path: {directory + "\\Save.sav"}");
        }

        void EndTest()
        {
            TcpClient Sender = new TcpClient();
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream s = new MemoryStream();
            NetworkStream stream;
            Sender.Client.SendTimeout = 3000;
            this.Enabled = false;
            this.Text = "Ending of test...";

            EndLocal();

            for (int i = 0; i < 5; i++)
            {
                this.Text = $"Попытка подкючения {i + 1} из 5";
                try { Sender.Connect(IP, 9090); break; }
                catch { }
                Thread.Sleep(1000);
            }
            if (Sender.Connected)
            {
                byte[] Key = new byte[256];
                byte BufByte;
                int DataLenght = 0;
                this.Text = "Подключение завершено.Сброс данных...";

                stream = Sender.GetStream();
                byte[] data = new byte[1] { 1 };

                stream.Write(data, 0, data.Length);
                ////////Set Admin arg
                if (IsAdmin)
                    pupil.args[4] = "1";

                stream.Read(Key, 0, 256);

                b.Serialize(s, pupil);
                DataLenght = s.ToArray().Length * 64;

               
                for (int i = 0; i < 256; i++)
                {
                    BufByte = (byte)(63 - Key[i]);
                    Key[i] = BufByte;
                }

                data = (byte[])EncryptClass.Encrypt(pupil, Key , ref DataLenght);

                Key = BitConverter.GetBytes(data.Length);

                

                stream.Write(Key, 0, 4);
                stream.Write( data , 0 , data.Length );
                
    
                Sender.Close();
                
                this.Text = "Сброс данных завершён успешно";
                FileTools.Log("Data send is end sucseed");

                Thread.Sleep(1500);
            }
            else
            {
                this.Text = "Подключение неудачно.Сохранение локально...";
                FileTools.Log("Data send is failed");

                this.Text = "Сохранение локально завершено";
                this.Close();
                return;
            }
            
            this.Close();
            return;
        }

        void EndOfTime()
        {
            for (int i = CurrentQuestion + 1; i < CurrentLesson.QuestionList.Count; i++)
                if (CurrentLesson.QuestionList[i].GetType() == new Explanation().GetType())
                {
                    CurrentQuestion = (byte)i;
                    break;
                }

             Next_Click(Next,null);
            timer1.Enabled = false;
            MessageBox.Show("Время , отведённое на выполнение этого задания, истекло");
            this.Text = "Тестовая система";
            FileTools.Log($"Timer is end , explanation number:{CurrentExplanationIndex}");
        }

        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            String LabelOfForm;

            if (!(CurrentExplanationIndex >= 0)) return;
            Explanation ex = (Explanation)CurrentLesson.QuestionList[CurrentExplanationIndex];
            if (ex.TimerValue == 0)
            {
                this.Text = "Тестовая система";
                return;
            }
            if(((ex.TimerValue - time) % 100 > 4 && (ex.TimerValue - time) % 100 < 20) || (ex.TimerValue - time) % 10 == 0 
                || ((ex.TimerValue - time) % 10 > 4 && (ex.TimerValue - time) % 10 < 10) ) LabelOfForm = $"Осталось {ex.TimerValue - time} секунд";
            else if ((ex.TimerValue - time) % 10 == 1) LabelOfForm = $"Осталось {ex.TimerValue - time} секунда";
            else LabelOfForm = $"Осталось {ex.TimerValue - time} секунды";
            this.Text = LabelOfForm;

            if (ex.TimerValue == time)
                EndOfTime();
            time++;
        }

        enum TypeOfQuestion : byte
        {
            Question = 1,
            ImageQuestion
        }
        void AddToPupilList(byte t)
        {
            switch (t)
            {
                case 1:

                    string UserAnswer;
                    if (Answer1.Checked) UserAnswer = "1";
                    else if (Answer2.Checked) UserAnswer = "2";
                    else if (Answer3.Checked) UserAnswer = "3";
                    else if (Answer4.Checked) UserAnswer = "4";
                    else UserAnswer = "no";

                    pupil.AnswerList.Add(UserAnswer);
                    FileTools.Log($"Added to pupil list:{UserAnswer}");
                    break;
                case 2:
                    UserAnswer = (AnswerTextSetup.Text != "" ? AnswerTextSetup.Text : "no").ToLowerInvariant();
                    for (int i = 0; i < UserAnswer.Length; i++)
                        if (UserAnswer[i] == '.' || UserAnswer[i] == ' ')
                        {
                            UserAnswer = UserAnswer.Remove(i, 1);
                            i--;
                        }

                    pupil.AnswerList.Add(UserAnswer);
                    FileTools.Log($"Added to pupil list:{UserAnswer}");
                    break;
            }
        }

        public void Next2() => Next_Click(Next, null);

        private void Next_Click(object sender, EventArgs e)
        {
            FileTools.Log("Next clicked");

            bool IsTimerTick = false;
            if (CurrentQuestion != 0 && CurrentLesson.QuestionList[CurrentQuestion - 1].GetType() == new Explanation().GetType())
            {
                Explanation ex = (Explanation)CurrentLesson.QuestionList[CurrentQuestion - 1];

                IsTimerTick = ex.TimerValue != 0 && !timer1.Enabled;
            }

            if (IsTimerTick)
            {
                time = 0;
                timer1.Start();
            }

            if (CurrentQuestion > 0)
                if (CurrentLesson.QuestionList[CurrentQuestion - 1].GetType() == new Question().GetType())
                    AddToPupilList((byte)TypeOfQuestion.Question);

                else if ((CurrentLesson.QuestionList[CurrentQuestion - 1].GetType() == new ImageQuestion().GetType()))
                    AddToPupilList((byte)TypeOfQuestion.ImageQuestion);

            if (CurrentQuestion == CurrentLesson.QuestionList.Count)
            {
                IsTestStar = false;
                EndTest();
                FileTools.Log("End of test");
                return;
            }
            

            if (CurrentLesson.QuestionList[CurrentQuestion].GetType() == new Explanation().GetType())
            {
                Explanation ex = (Explanation)CurrentLesson.QuestionList[CurrentQuestion];
                CurrentExplanationIndex = CurrentQuestion;

                groupBox1.Visible = false;
                AnswerTextSetup.Visible = false;
                pictureBox.Visible = false;
                ExplanationLabel.Visible = true;
                Next.Visible = true;

                Next.Location = new Point(220, 230);

                ExplanationLabel.Text = ex.Text;

                CurrentQuestion++;
            }
            else if (CurrentLesson.QuestionList[CurrentQuestion].GetType() == new Question().GetType())
            {
                Question q = (Question)CurrentLesson.QuestionList[CurrentQuestion];

                groupBox1.Visible = true;
                ExplanationLabel.Visible = false;
                AnswerTextSetup.Visible = false;
                pictureBox.Visible = false;
                Next.Visible = true;
                Next.Location = new Point(250, 250);


                if ((string)CurrentLesson.args[3] == "1") Answer5.Visible = true;
                else Answer5.Visible = false;
                Answer1.Text = q.Answers[0];
                Answer2.Text = q.Answers[1];
                Answer3.Text = q.Answers[2];
                Answer4.Text = q.Answers[3];
                Answer5.Text = q.arg;

                QuestionLabel.Text = q.Question_s;

                Answer1.Checked = false;
                Answer2.Checked = false;
                Answer3.Checked = false;
                Answer4.Checked = false;
                Answer5.Checked = false;

                CurrentQuestion++;
            }
            else if (CurrentLesson.QuestionList[CurrentQuestion].GetType() == new ImageQuestion().GetType())
            {
                ImageQuestion q = (ImageQuestion)CurrentLesson.QuestionList[CurrentQuestion];
                groupBox1.Visible = false;
                AnswerTextSetup.Visible = true;
                ExplanationLabel.Visible = true;
                Next.Visible = true;

                Next.Location = new Point(400, 350);

                ExplanationLabel.Text = q.Question;
                AnswerTextSetup.Text = "";

                pictureBox.Visible = true;
                pictureBox.Image = NextImage;
               // pictureBox.Refresh();

                CurrentQuestion++;
            }

            if (CurrentQuestion + 1 < CurrentLesson.QuestionList.Count)
                if (CurrentLesson.QuestionList[CurrentQuestion + 1].GetType() == new ImageQuestion().GetType())
                {
                    Thread f = new Thread(new ParameterizedThreadStart(LoadPicture));
                    f.Start(CurrentLesson.QuestionList[CurrentQuestion + 1]);
                }
        }
    }
}

        

