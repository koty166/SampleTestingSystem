using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary2;
using System.Net;
using System.Net.Sockets;

namespace Проект_к_школе
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String directory = @"Tests";

        List<Image> LIstImages = new List<Image>();

        Lesson[] Lesson_mass;
        internal Pupil pupil;

        bool IsTestStar = false;
        int CurrentQuestion = 0;
        internal IPAddress IP;

        Color
        GlobalColor, SecondaryColor, LabelColor = Color.Black
        , ButtonColor = Color.Black, Rigth = Color.SpringGreen
        , Wrong = Color.Tomato
        , QuestionDone = Color.SpringGreen;

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

        void Personalize()
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

            /* button1.BackColor = SecondaryColor;
             button3.BackColor = SecondaryColor;
             Next.BackColor = SecondaryColor;
             Start.BackColor = SecondaryColor;*/


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
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && !IsTestStar)
            {
                NetworSetting n = new NetworSetting();
                n.Show();
                this.Enabled = false;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (list_of_lessons.SelectedItem != null)
            {
                Thread f = new Thread(new ParameterizedThreadStart(LoadPicture));

                f.Start(Lesson_mass[list_of_lessons.SelectedIndex]);
                IsTestStar = true;

                Start.Visible = false;
                if (Application.OpenForms.Count == 1 && pupil == null)
                {
                    Registration r = new Registration();
                    r.Show();
                    this.Enabled = false;
                }
                else
                    Next2();
            }
        }

        void EndTest()
        {

        }
        public void Next2() { Next_Click(Next, null); }
        private void Next_Click(object sender, EventArgs e)
        {
            Lesson CurrentLesson = Lesson_mass[list_of_lessons.SelectedIndex];

            if (CurrentQuestion > CurrentLesson.QuestionList.Count)
            {
                if (CurrentLesson.QuestionList[CurrentQuestion - 1].GetType() == new Question().GetType())
                {
                    String UserAnswer;
                    if (Answer1.Checked) UserAnswer = Answer1.Text;
                    else if (Answer2.Checked) UserAnswer = Answer2.Text;
                    else if (Answer3.Checked) UserAnswer = Answer3.Text;
                    else if (Answer4.Checked) UserAnswer = Answer4.Text;
                    else UserAnswer = "NO";

                    pupil.AnswerList.Add(UserAnswer);
                }
                else if ((CurrentLesson.QuestionList[CurrentQuestion - 1].GetType() == new ImageQuestion().GetType()))
                {
                    pupil.AnswerList.Add(AnswerTextSetup.Text);
                }
                IsTestStar = false;
                EndTest();
            }
            else if (CurrentLesson.QuestionList[CurrentQuestion].GetType() == new Explanation().GetType())
            {
                Explanation ex = (Explanation)CurrentLesson.QuestionList[0];

                groupBox1.Visible = false;
                AnswerTextSetup.Visible = false;

                Next.Location = new Point(200, 200);

                ExplanationLabel.Text = ex.Text;

                CurrentQuestion++;
            }
            else if(CurrentLesson.QuestionList[CurrentQuestion].GetType() == new Question().GetType())
            {
                String UserAnswer;
                Question q = (Question)CurrentLesson.QuestionList[CurrentQuestion];

                groupBox1.Visible = true;
                ExplanationLabel.Visible = false;
                AnswerTextSetup.Visible = false;
                Next.Location = new Point(200, 200);

                Answer1.Text = q.Answers[0];
                Answer2.Text = q.Answers[1];
                Answer3.Text = q.Answers[2];
                Answer4.Text = q.Answers[3];

                QuestionLabel.Text = q.Question_s;

                if (Answer1.Checked) UserAnswer = Answer1.Text;
                else if (Answer2.Checked) UserAnswer = Answer2.Text;
                else if (Answer3.Checked) UserAnswer = Answer3.Text;
                else if (Answer4.Checked) UserAnswer = Answer4.Text;
                else UserAnswer = "NO";

                pupil.AnswerList.Add(UserAnswer);

                Answer1.Checked = false;
                Answer2.Checked = false;
                Answer3.Checked = false;
                Answer4.Checked = false;

                CurrentQuestion++;
            }
            else if(CurrentLesson.QuestionList[CurrentQuestion].GetType() == new ImageQuestion().GetType())
            {
                ImageQuestion q = (ImageQuestion)CurrentLesson.QuestionList[CurrentQuestion];
                groupBox1.Visible = false;
                AnswerTextSetup.Visible = true;
                ExplanationLabel.Visible = false;

                Next.Location = new Point(400, 350);

                pupil.AnswerList.Add(AnswerTextSetup.Text);

                ExplanationLabel.Text = q.Question;
                AnswerTextSetup.Text = null;

                CurrentQuestion++;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (IsTestStar && tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Пожалуйста завершите тест , прежде чем перейти к темам");  
            }
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && IsTestStar == false)
                this.MinimumSize = new Size(830, 500);
            if (tabControl1.SelectedIndex == 0 && IsTestStar == false)
                this.MaximumSize = new Size(650, 500);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            GlobalColor = Color.FromArgb(255, 53, 53, 53);
            SecondaryColor = Color.FromArgb(255, 81, 81, 81);
            LabelColor =  Color.FromName("White");
            ButtonColor = Color.FromName("Gray");
            Rigth = Color.FromArgb(255,58,120,58);
            Wrong = Color.FromArgb(255, 178, 36, 12);

            Personalize();
        }
    }
        
}
