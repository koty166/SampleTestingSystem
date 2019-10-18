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

namespace Проект_к_школе
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String directory = @"Tests";

        QuestionDone [] MassQuestions;
        List<String> lines = new List<string>();
        List<Image> LIstImages = new List<Image>();

        int WrongAnswerNum = 0;

        Lesson[] Lesson_mass;

        bool IsTestStar = false;

        Color GlobalColor, SecondaryColor, LabelColor = Color.Black, ButtonColor = Color.Black;

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

        void rename_list_of_questions()
        {
            for (int i = 0; i < list_of_questions.Nodes.Count; i++)
            {
                list_of_questions.Nodes[i].Text = "Задание: " + (i + 1);
            }
        }

        void Personalize()
        {
            tabPage1.BackColor = GlobalColor;
            tabPage2.BackColor = GlobalColor;
            this.BackColor = GlobalColor;

            list_of_questions.BackColor = SecondaryColor;
            list_of_lessons.BackColor = SecondaryColor;
            textBox2.BackColor = SecondaryColor;
            textBox1.BackColor = SecondaryColor;
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
            label1.ForeColor = LabelColor;
            label2.ForeColor = LabelColor;
            label7.ForeColor = LabelColor;
            DarkTheme.ForeColor = LabelColor;
            groupBox1.ForeColor = LabelColor;
            groupBox3.ForeColor = LabelColor;
            groupBox4.ForeColor = LabelColor;

            button1.ForeColor = GlobalColor;
            button3.ForeColor = GlobalColor;
            Next.ForeColor = GlobalColor;
            Start.ForeColor = GlobalColor;


        }

        void LoadPicture(Object ob)
        {
            List<Image> l = new List<Image>();
            Lesson CurrentLesson = (Lesson)ob;

            foreach (var i in CurrentLesson.mass_ImageQuestion)
            {
                try
                {
                    l.Add(Image.FromFile(directory + $"//images//{i.image_name}"));
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


            rename_list_of_questions();

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

        Image drow_Diagramm()
        {
            Image im = pictureBox.Image;

            pictureBox.Refresh();
            pictureBox.Size = new Size(300, 300);

            Bitmap bit = new Bitmap(im);
            Graphics g = Graphics.FromImage(bit);
            SolidBrush b = new SolidBrush(Color.Tomato);
            g.Clear(GlobalColor);
            

            Rectangle rect = new Rectangle()
            {
                Size = pictureBox.Size,
                X = pictureBox.Location.X - 20,
                Y = pictureBox.Location.Y - 20
            };

            float end = (((float)WrongAnswerNum / 25) * 360);
            g.FillPie(b,rect , 0, end );

            b.Color = Color.SpringGreen;

            g.FillPie(b, rect, end , 360 - end);

            return bit;
        }

        QuestionDone [] RandomizeListQouestion(QuestionDone [] InMass)
        {
            int StartIndex, EndIndex;
            QuestionDone buff;
            Random r = new Random();

            for (int i = 0; i < 25; i++)
            {
                StartIndex = r.Next(0,25);
                EndIndex = r.Next(0, 25);

                buff = InMass[EndIndex];
                InMass[EndIndex] = InMass[StartIndex];
                InMass[StartIndex] = buff;
            }
            return InMass;
        }

        QuestionDone[] AddToMass(Lesson InL)
        {
            QuestionDone[] ret = new QuestionDone[25];
            for (int i = 0; i < 25; i++)
            {
                if (i < 20)
                    ret[i] = new QuestionDone()
                    {
                        Answer = "",
                        IsDone = false,
                        IsRigth = false,
                        Explanation = InL.mass_Question[i].Explanation,
                        IsImageQuestion = false,
                        Index = i
                    };
                else
                    ret[i] = new QuestionDone()
                    {
                        Answer = "",
                        IsDone = false,
                        IsRigth = false,
                        Explanation = InL.mass_ImageQuestion[i - 20].Explanation,
                        IsImageQuestion = true,
                        Index = i
                    };
            }
            return ret;
        }

        private void list_of_questions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Next.Visible = true;
            textBox1.Text = null;
            int Selected_index = list_of_questions.SelectedNode.Index;



            if (!MassQuestions[Selected_index].IsImageQuestion)
            {
                groupBox1.Visible = true;
                textBox1.Visible = false;
                pictureBox.Visible = false;
                label1.Visible = false;

                Next.Location = new Point(280, 220);

                Answer1.Text = "Ответ 1:" + Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[MassQuestions[Selected_index].Index].Answers[0];
                Answer2.Text = "Ответ 2:" + Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[MassQuestions[Selected_index].Index].Answers[1];
                Answer3.Text = "Ответ 3:" + Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[MassQuestions[Selected_index].Index].Answers[2];
                Answer4.Text = "Ответ 4:" + Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[MassQuestions[Selected_index].Index].Answers[3];
                label2.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[MassQuestions[Selected_index].Index].Question_s;
            }
            else
            {
                Next.Location = new Point(500, 350);

                groupBox1.Visible = false;

                textBox1.Visible = true;
                pictureBox.Visible = true;
                label1.Visible = true;

                label1.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[MassQuestions[Selected_index].Index - 20].Question;

                pictureBox.Image = LIstImages[MassQuestions[Selected_index].Index - 20];
            }

            Next.Text = Selected_index == 24 ? "Закончить" : "Далее";

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (list_of_lessons.SelectedItem != null)
            {
                Thread f = new Thread(new ParameterizedThreadStart(LoadPicture));

                f.Start(Lesson_mass[list_of_lessons.SelectedIndex]);

                IsTestStar = true;

                this.MinimumSize = new Size(830, 500);

                groupBox1.Visible = true;
                list_of_questions.Visible = true;
                label1.Visible = false;
                Start.Visible = false;
                list_of_lessons.Visible = false;

                MassQuestions = RandomizeListQouestion( AddToMass ( Lesson_mass[list_of_lessons.SelectedIndex] ) );

                list_of_questions.SelectedNode = list_of_questions.Nodes[0];
            }

        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (list_of_questions.SelectedNode != null)
            {

                if (list_of_questions.SelectedNode.Index < 20)
                {
                    int selected_answer = 0;
                    string answer;

                    if (Answer1.Checked) { selected_answer = 0; answer = Answer1.Text.Remove(0, 8); }
                    else if (Answer2.Checked) { selected_answer = 1; answer = Answer2.Text.Remove(0,8); }
                    else if (Answer3.Checked) { selected_answer = 2; answer = Answer3.Text.Remove(0, 8); }
                    else if (Answer4.Checked) { selected_answer = 3; answer = Answer4.Text.Remove(0, 8); }
                    else { Answer1.Checked = true; answer = Answer1.Text.Remove(0, 8); }


                    MassQuestions[list_of_questions.SelectedNode.Index].IsDone = true;
                    MassQuestions[list_of_questions.SelectedNode.Index].Answer = answer;

                    if (selected_answer == Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Rigth_answer)
                    {
                        MassQuestions[list_of_questions.SelectedNode.Index].IsRigth = true;
                        list_of_questions.SelectedNode.BackColor = Color.Green;
                    }
                    else
                    {
                        MassQuestions[list_of_questions.SelectedNode.Index].IsRigth = false;
                        list_of_questions.SelectedNode.BackColor = Color.Red;
                    }
                }
                else
                {
                    textBox1.Clear();

                    MassQuestions[list_of_questions.SelectedNode.Index].IsDone = true;
                    MassQuestions[list_of_questions.SelectedNode.Index].Answer = textBox1.Text;

                    if (textBox1.Text == Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].Rigth_answer)
                    {
                        MassQuestions[list_of_questions.SelectedNode.Index].IsRigth = true;
                        list_of_questions.SelectedNode.BackColor = Color.Green;
                    }

                    else
                    {
                        MassQuestions[list_of_questions.SelectedNode.Index].IsRigth = false;
                        list_of_questions.SelectedNode.BackColor = Color.Red;
                    }
                }

                if (list_of_questions.SelectedNode.Index == 24)
                {
                    foreach (var i in MassQuestions)
                    {
                        if (!i.IsDone)
                        {
                            MessageBox.Show("Пожалуйста, заполните все ответы");
                            return;
                        }
                    }    

                    textBox2.Visible = true;
                    textBox1.Visible = false;
                    Next.Visible = false;
                    button1.Visible = true;
                    list_of_questions.Visible = false;
                    groupBox1.Visible = false;
                    pictureBox.Visible = true;

                    {

                        foreach (var i in MassQuestions)
                        {
                            if (!i.IsRigth)
                            {
                                lines.Add($"Задача №{i.Index + 1} решена неверно, ваш ответ {i.Answer}");
                                WrongAnswerNum++;
                            }
                            else
                                lines.Add($"Задача №{i.Index + 1} решена верно");
                            
                        }
                        
                        String[] s = new string[lines.Count];
                        for (int i = 0; i < lines.Count; i++)
                        {
                            s[i] = lines[i];
                        }
                        textBox2.Lines = s;
                    }

                       

                    if (WrongAnswerNum == 0) button1.Text = "Начать другой тест";
                    else button1.Text = "Объяснение";

                    this.MaximumSize = new Size(650, 500);

                    pictureBox.Image = drow_Diagramm();

                    Color c = list_of_questions.BackColor;
                    for (int i = 0; i < 25; i++)
                    {
                        list_of_questions.Nodes[i].BackColor = c;
                    }

                }
                else
                    list_of_questions.SelectedNode = list_of_questions.Nodes[list_of_questions.SelectedNode.Index + 1];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Visible = false;
            pictureBox.Visible = false;

            pictureBox.Size = new Size(500, 300);

            if (WrongAnswerNum > 0)
            {
                foreach (var i in MassQuestions)
                    if (!i.IsRigth)
                    {
                        button1.Text = "Далее";
                        label1.Text = i.Explanation;
                        i.IsRigth = true;
                        WrongAnswerNum--;
                        return;
                    }
            }
            else
            {
                label1.Text = "Выбери урок , который хочешь пройти";

                list_of_lessons.Visible = true;
                Start.Visible = true;
                label1.Visible = true;

                button1.Visible = false;
                textBox2.Visible = false;
                IsTestStar = false;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (IsTestStar && tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Пожалуйста завершите тест , прежде чем перейти к темам");
                if (textBox2.Visible)
                    pictureBox.Image = drow_Diagramm();
                
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
            GlobalColor = Color.FromArgb(255, 32, 32, 32);
            SecondaryColor = Color.FromName("White");
            LabelColor = Color.FromArgb(255, 96, 96, 96);
            ButtonColor = Color.FromArgb(255, 74, 38, 71);

            Personalize();
        }
    }
    class QuestionDone
    {
        internal String Answer;
        internal bool IsDone;
        internal bool IsRigth;
        internal String Explanation;
        internal bool IsImageQuestion;
        internal int Index;
    }
        
}
