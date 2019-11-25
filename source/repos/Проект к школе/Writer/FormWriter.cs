using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary2;

namespace Проект_к_школе
{
    public partial class FormWriter : Form
    {
        public FormWriter()
        {
            InitializeComponent();
        }
        internal List<Lesson> Lesson_mass = new List<Lesson>();
        String directory = @"Tests";
        internal int ChosenLesson;
        internal int ChoosenQuestion;


        void AddToLessonChoose()
        {
            foreach (var i in Lesson_mass)
            {
                LessonChoose.Items.Add(i.Name);
            }

        }
       internal void AddToQuestionChoose(object Question)
        {
            QuestionChoose.Nodes.Add(new TreeNode(Question.ToString()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] FileNames;

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            else
            {
                FileNames = Directory.GetFiles(directory, "*.dat");
                if (FileNames.Length != 0)
                    for (int i = 0; i < FileNames.Length; i++)
                    {
                        FileStream Stream = new FileStream(FileNames[i], FileMode.Open);
                        BinaryFormatter Formated = new BinaryFormatter();

                        Lesson_mass.Add((Lesson)Formated.Deserialize(Stream));

                        Stream.Close();
                    }
            }
            if (Lesson_mass.Count != 0)
                AddToLessonChoose();
            FileTools.Log("Test writer loaded");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Lesson_mass.Count != 0) 
                foreach (var i in Lesson_mass)
                {
                    File.Delete($"{directory}\\{i.Name}.dat");

                    BinaryFormatter Formatted = new BinaryFormatter();
                    FileStream stream = new FileStream($"{directory}\\{i.Name}.dat",FileMode.Create);                       

                    Formatted.Serialize(stream, i);

                    stream.Close();
                }
            FileTools.Log("Tests saved sucsseed");
        }

        private void CreateNewLesson_Click(object sender, EventArgs e)
        {
            Lesson_mass.Add(new Lesson()
            {
                Name = textBox6.Text != "" ? textBox6.Text : "Тест"
            });

            LessonChoose.Items.Clear();

            AddToLessonChoose();
            FileTools.Log("New lesson created");
        }

        private void AddQuestion_Click(object sender, EventArgs e)
        {
            QuestionSetupForm form = new QuestionSetupForm();
            form.Text = "Индекс: " + QuestionChoose.Nodes.Count;
            FileTools.Log("Question setup opened");
            form.Show();
            this.Enabled = false;
        }

        private void LessonChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedItem != null)
                ChosenLesson = LessonChoose.SelectedIndex;
            QuestionChoose.Nodes.Clear();
            foreach (var i in Lesson_mass[LessonChoose.SelectedIndex].QuestionList)
            {
                AddToQuestionChoose(i);
            }
            FileTools.Log("List of question rewrited");
        }

        private void AddImageQiestion_Click(object sender, EventArgs e)
        {
            ImageQuestionSetupForm form = new ImageQuestionSetupForm();
            form.Text = "Индекс: " + QuestionChoose.Nodes.Count;
            FileTools.Log("Image question setup opened");
            form.Show();
            this.Enabled = false;
        }

        private void AddInstraction_Click(object sender, EventArgs e)
        {
            ExplanationFormSetup form = new ExplanationFormSetup();
            form.Text = "Индекс: " + QuestionChoose.Nodes.Count;
            FileTools.Log("Explanation setup opened");
            form.Show();
            this.Enabled = false;
        }

        private void QuestionChoose_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Lesson CurrentLesson = Lesson_mass[ChosenLesson];
            ChoosenQuestion = QuestionChoose.SelectedNode.Index;
            if (CurrentLesson.QuestionList[QuestionChoose.SelectedNode.Index].GetType() == new Explanation().GetType())
            {
                ExplanationFormSetup form = new ExplanationFormSetup();
                form.LocalQuestion = (Explanation)CurrentLesson.QuestionList[QuestionChoose.SelectedNode.Index];
                form.Text = "Индекс: " + QuestionChoose.SelectedNode.Index.ToString();
                FileTools.Log("Explanation setup opened as rewrite");
                form.Show();
                this.Enabled = false;
            }
            else if (CurrentLesson.QuestionList[QuestionChoose.SelectedNode.Index].GetType() == new Question().GetType())
            {
                QuestionSetupForm form = new QuestionSetupForm();
                form.LocalQuestion = (Question)CurrentLesson.QuestionList[QuestionChoose.SelectedNode.Index];
                form.Text = "Индекс: " + QuestionChoose.SelectedNode.Index.ToString();
                FileTools.Log("Йquestion setup opened as rewrite");
                form.Show();
                this.Enabled = false;

            }
            else if (CurrentLesson.QuestionList[QuestionChoose.SelectedNode.Index].GetType() == new ImageQuestion().GetType())
            {
                ImageQuestionSetupForm form = new ImageQuestionSetupForm();
                form.LocalQuestion = (ImageQuestion)CurrentLesson.QuestionList[QuestionChoose.SelectedNode.Index];
                form.Text = "Индекс: " + QuestionChoose.SelectedNode.Index.ToString();
                FileTools.Log("Image question setup opened as rewrite");
                form.Show();
                this.Enabled = false;
            }
            
        }
    }
}
