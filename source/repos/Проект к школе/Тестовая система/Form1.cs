using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary2;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Проект_к_школе
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String directory = @"Tests";
        bool IsTestStar = false,IsRandom  = false, IsAdmin = false;
        int CurrentQuestion = 0, CurrentExplanationIndex = 0;
        internal IPAddress IP;

        List<Image> LIstImages = new List<Image>();

        Lesson[] Lesson_mass;

        Lesson CurrentLesson;
        internal Pupil pupil;

       // Color
      ///  GlobalColor, SecondaryColor, LabelColor = Color.Black
      //  , ButtonColor = Color.Black, Rigth = Color.SpringGreen
      //  , Wrong = Color.Tomato
      //  , QuestionDone = Color.SpringGreen;

        void Load_in_form()
        {
            try
            {
                if (Lesson_mass.Length != 0)
                    foreach (var i in Lesson_mass)
                    {
                        list_of_lessons.Items.Add(i.Name);
                    }
            }
            catch { }

        }
       
    
       /* void Personalize()
        {
            tabPage1.BackColor = GlobalColor;
            tabPage2.BackColor = GlobalColor;
            this.BackColor = GlobalColor;

            list_of_lessons.BackColor = SecondaryColor;
            AnswerTextSetup.BackColor = SecondaryColor;
            tabPage1.ForeColor = SecondaryColor;
            tabPage2.ForeColor = SecondaryColor;
            this.BackColor = SecondaryColor;
            treeView1.BackColor = SecondaryColor;

            
            Answer1.ForeColor = LabelColor;
            Answer2.ForeColor = LabelColor;
            Answer3.ForeColor = LabelColor;
            Answer4.ForeColor = LabelColor;
            radioButton1.ForeColor = LabelColor;
            radioButton2.ForeColor = LabelColor;
            radioButton3.ForeColor = LabelColor;
            radioButton4.ForeColor = LabelColor;
            ExplanationLabel.ForeColor = LabelColor;
            QuestionLabel.ForeColor = LabelColor;
            label7.ForeColor = LabelColor;
            DarkTheme.ForeColor = LabelColor;
            groupBox1.ForeColor = LabelColor;
            groupBox3.ForeColor = LabelColor;
            groupBox4.ForeColor = LabelColor;

            button3.ForeColor = GlobalColor;
            Next.ForeColor = GlobalColor;
            Start.ForeColor = GlobalColor;


        }
        */
        

        void LoadPicture(Object ob)
        {
            List<Image> l = new List<Image>();
            Lesson CurrentLesson = (Lesson)ob;

            foreach (var i in CurrentLesson.QuestionList)
            {

                try
                {
                    ImageQuestion q = (ImageQuestion)i;
                    l.Add(Image.FromFile(directory + $"//images//{q.image_name}"));
                }
                catch
                {
                    l.Add(Image.FromFile(directory + $"//images//Error.png"));
                }
            }

            LIstImages = l;
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
            if (e.Control && e.KeyCode == Keys.R && !IsTestStar)
                IsRandom = true;
            if (e.Control && e.KeyCode == Keys.A && !IsTestStar)
                IsAdmin = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (list_of_lessons.SelectedItem != null)
            {
                Thread f = new Thread(new ParameterizedThreadStart(LoadPicture));

                f.Start(Lesson_mass[list_of_lessons.SelectedIndex]);
                IsTestStar = true;

                Start.Visible = false;
                list_of_lessons.Visible = false;

                if (Application.OpenForms.Count == 1 && pupil == null)
                {
                    Registration r = new Registration();
                    r.Show();
                    FileTools.Log("Registration is began");
                    this.Enabled = false;

                }
                else
                    Next2();
                FileTools.Log($"Test {Lesson_mass[list_of_lessons.SelectedIndex]} is started");
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
            NetworkStream stream;
            Sender.Client.SendTimeout = 3000;
            this.Enabled = false;
            this.Text = "Ending of test...";
            for (int i = 0; i < 5; i++)
            {
                this.Text = $"Попытка подкючения {i + 1} из 5";
                try { Sender.Connect(IP, 9090); break; }
                catch { }
                Thread.Sleep(1000);
            }
            if (Sender.Connected)
            {
                this.Text = "Подключение завершено.Сброс данных...";

                stream = Sender.GetStream();
                byte[] data = new byte[1] { 1 };

                stream.Write(data, 0, data.Length);
                ////////Set Admin arg
                if (IsAdmin)
                    pupil.arg[4] = "1";

                b.Serialize(Sender.GetStream(), pupil);

                Sender.Close();

                this.Text = "Сброс данных завершён успешно";
                FileTools.Log("Data send is end sucseed");

                Thread.Sleep(1500);
            }
            else
            {
                this.Text = "Подключение неудачно.Сохранение локально...";
                EndLocal();
                this.Text = "Сохранение локально завершено";
                this.Close();
                return;
            }
            EndLocal();
            this.Close();
            return;
        }

        void EndofTime()
        {
            for (int i = CurrentQuestion + 1; i < CurrentLesson.QuestionList.Count; i++)
                if (CurrentLesson.QuestionList[i].GetType() == new Explanation().GetType())
                    CurrentQuestion = i;

            Next_Click(Next,null);
            MessageBox.Show("Время , отведённое на выполнение этого задания, истекло");
            this.Text = "Тестовая система";
            FileTools.Log($"Time of explanation end; explanation number:{CurrentExplanationIndex}");
        }
        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Explanation ex = (Explanation)CurrentLesson.QuestionList[CurrentExplanationIndex];
            if (ex.TimerValue == 0)
            {
                this.Text = "Тестовая система";
                return;
            }

            this.Text = $"Осталось {ex.TimerValue - time} секунд";
            if (ex.TimerValue == time)
                EndofTime();
            time++;
        }

        enum TypeOfQuestion : int
        {
            Question = 1,
            ImageQuestion
        }
        void AddToPupilList(TypeOfQuestion type)
        {
            switch (type)
            {
                case TypeOfQuestion.Question:

                    string UserAnswer;
                    if (Answer1.Checked) UserAnswer = "1";
                    else if (Answer2.Checked) UserAnswer = "2";
                    else if (Answer3.Checked) UserAnswer = "3";
                    else if (Answer4.Checked) UserAnswer = "4";
                    else UserAnswer = "NO";

                    pupil.AnswerList.Add(UserAnswer);
                    FileTools.Log($"Added to pupil list:{UserAnswer}");
                    break;
                case TypeOfQuestion.ImageQuestion:
                    UserAnswer = AnswerTextSetup.Text != "" ? AnswerTextSetup.Text : "NO";
                    pupil.AnswerList.Add(UserAnswer);
                    FileTools.Log($"Added to pupil list:{UserAnswer}");
                    break;
            }
        }

        public void Next2()
        {
            CurrentLesson = Lesson_mass[list_of_lessons.SelectedIndex];
            timer1.Start();
            Next_Click(Next, null);
        }
        char GetRand()
        {
            Random r = new Random();
            switch(r.Next(1, 5))
            {
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
            }
            return '6';

        }
        private void Next_Click(object sender, EventArgs e)
        {
            FileTools.Log("Next clicked");
            if (IsRandom)
            {
                for (int i = 0; i < CurrentLesson.QuestionList.Count; i++)
                    pupil.AnswerList.Add(GetRand().ToString());
                CurrentQuestion = CurrentLesson.QuestionList.Count - 1;
                IsRandom = false;
            }

            if (!timer1.Enabled) timer1.Start();

            if (CurrentQuestion > 0)
                if (CurrentLesson.QuestionList[CurrentQuestion - 1].GetType() == new Question().GetType())
                    AddToPupilList(TypeOfQuestion.Question);

                else if ((CurrentLesson.QuestionList[CurrentQuestion - 1].GetType() == new ImageQuestion().GetType()))
                    AddToPupilList(TypeOfQuestion.ImageQuestion);

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
                Next.Visible = true;

                Next.Location = new Point(200, 200);

                ExplanationLabel.Text = ex.Text;

                CurrentQuestion++;
            }
            else if (CurrentLesson.QuestionList[CurrentQuestion].GetType() == new Question().GetType())
            {
                Question q = (Question)CurrentLesson.QuestionList[CurrentQuestion];

                groupBox1.Visible = true;
                ExplanationLabel.Visible = false;
                AnswerTextSetup.Visible = false;
                Next.Visible = true;
                Next.Location = new Point(200, 200);

                Answer1.Text = q.Answers[0];
                Answer2.Text = q.Answers[1];
                Answer3.Text = q.Answers[2];
                Answer4.Text = q.Answers[3];

                QuestionLabel.Text = q.Question_s;

                Answer1.Checked = false;
                Answer2.Checked = false;
                Answer3.Checked = false;
                Answer4.Checked = false;

                CurrentQuestion++;
            }
            else if (CurrentLesson.QuestionList[CurrentQuestion].GetType() == new ImageQuestion().GetType())
            {
                ImageQuestion q = (ImageQuestion)CurrentLesson.QuestionList[CurrentQuestion];
                groupBox1.Visible = false;
                AnswerTextSetup.Visible = true;
                ExplanationLabel.Visible = false;
                Next.Visible = true;

                Next.Location = new Point(400, 350);

                ExplanationLabel.Text = q.Question;
                AnswerTextSetup.Text = "";

                CurrentQuestion++;
            }
        }
    }
}

        

