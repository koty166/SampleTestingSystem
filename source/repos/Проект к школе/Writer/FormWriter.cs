using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
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
        internal int ChoosenLesson;
        internal int ChoosenQuestion;
        bool IsMergeStart;
        byte NumOfChoosenLessonForMerge = 0 , FirstLessonForMerge , SecoundLessonForMerge;

        void AddToLessonChoose() 
        {
            LessonChoose.Items.Clear();
            foreach (var i in Lesson_mass)
                LessonChoose.Items.Add(i.Name);

        }

        internal void AddToQuestionChoose(object Question)
        {
            if (Question.GetType() == new Explanation().GetType())
            {
                Explanation q = (Explanation)Question;
                QuestionChoose.Nodes.Add(new TreeNode(q.Text == "" ? "NO NAME" : q.Text));
            }

            if (Question.GetType() == new Question().GetType())
            {
                Question q = (Question)Question;
                QuestionChoose.Nodes.Add(new TreeNode(q.Question_s == "" ? "NO NAME" : q.Question_s));
            }

            if (Question.GetType() == new ImageQuestion().GetType())
            {
                ImageQuestion q = (ImageQuestion)Question;
                QuestionChoose.Nodes.Add(new TreeNode(q.Question == "" ? "NO NAME" : q.Question));
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
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
            }
            catch { MessageBox.Show("Ошибка загрузки файлов попробуйте переметить их или частично удалить"); }
            if (Lesson_mass.Count != 0)
                AddToLessonChoose();
            FileTools.Log("Test writer loaded");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] FilePaths = Directory.GetFiles($"{directory}\\", "*.dat");

            foreach (var item in FilePaths)
                File.Delete(item);

            foreach (var i in Lesson_mass)
            {
                BinaryFormatter Formatted = new BinaryFormatter();
                FileStream stream = new FileStream($"{directory}\\{i.Name}.dat", FileMode.Create);

                Formatted.Serialize(stream, i);

                stream.Close();
            }
            FileTools.Log("Tests saved sucsseed");
        }

        List<object> CopyFromArrayToList(object[] Array)
        {
            List<object> l = new List<object>();
            for (int i = 0; i < Array.Length; i++)
                l.Add(Array[i]);
            return l;
        }

        void MergeLessons(Lesson _FirstLesson , Lesson _SecoundLesson)
        {
            object[] Array1 = _FirstLesson.QuestionList.ToArray(), Array2 = _SecoundLesson.QuestionList.ToArray();
            try
            {
                foreach (var i in _SecoundLesson.QuestionList)
                    _FirstLesson.QuestionList.Add(i);
            }
            catch
            {
                MessageBox.Show("Операция копирования произведена с ошибкой, изменения будут отменены");
                 Lesson_mass[FirstLessonForMerge] = new Lesson()
                {
                    Name = _FirstLesson.Name,
                    QuestionList = CopyFromArrayToList(Array1),
                    args = _FirstLesson.args
                };
                Lesson_mass[SecoundLessonForMerge] = new Lesson()
                {
                    Name = _SecoundLesson.Name,
                    QuestionList = CopyFromArrayToList(Array2),
                    args = _SecoundLesson.args
                };
            }
        }

        internal void UpdateQuestions()
        {
            QuestionChoose.Nodes.Clear();

            foreach (var i in Lesson_mass[ChoosenLesson].QuestionList)
                AddToQuestionChoose(i);
        }

        private void LessonChoose_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LessonChoose.SelectedItem != null && LessonChoose.SelectedIndex >= 0 && LessonChoose.SelectedIndex < LessonChoose.Items.Count)
                ChoosenLesson = LessonChoose.SelectedIndex;

            UpdateQuestions();

            FileTools.Log("Lesson choose is changed");

            if (IsMergeStart)
                switch(NumOfChoosenLessonForMerge)
                {
                    case 0:
                        FirstLessonForMerge = (byte)ChoosenLesson;
                        FirstLessonLabel.Text = Lesson_mass[ChoosenLesson].Name;
                        NumOfChoosenLessonForMerge = 1;
                        break;
                    case 1:
                        SecoundLessonForMerge = (byte)ChoosenLesson;
                        DialogResult r = MessageBox.Show($"Вы уверены ,что хотите слить урок {Lesson_mass[FirstLessonForMerge].Name} " +
                            $"с {Lesson_mass[SecoundLessonForMerge].Name}(все задания из урока 2 перейдут в урок 1) , это невозможно отменить, также это удалит второй урок(Cancel не удалит урок)", "", MessageBoxButtons.YesNoCancel);

                        if (r == DialogResult.No)
                        {
                            NumOfChoosenLessonForMerge = 0;
                            IsMergeStart = false;
                            return;
                        }

                        MergeLessons(Lesson_mass[FirstLessonForMerge] , Lesson_mass[SecoundLessonForMerge]);
                       
                        NumOfChoosenLessonForMerge = 0;
                        IsMergeStart = false;

                        if(r == DialogResult.Yes)
                            Lesson_mass.RemoveAt(ChoosenLesson);

                        ChoosenLesson = 0;
                        AddToLessonChoose();
                        MessageBox.Show("Слияние завершено");

                        break;
                }
        }

        void CreateLessonForms()
        {
            Lesson CurrentLesson = Lesson_mass[ChoosenLesson];
            ChoosenQuestion = QuestionChoose.SelectedNode != null ? QuestionChoose.SelectedNode.Index : 0;
            if (CurrentLesson.QuestionList[ChoosenQuestion].GetType() == new Explanation().GetType())
            {
                ExplanationFormSetup form = new ExplanationFormSetup();
                form.LocalQuestion = (Explanation)CurrentLesson.QuestionList[ChoosenQuestion];
                form.Text = "Индекс: " + ChoosenQuestion.ToString();
                FileTools.Log("Explanation setup opened as rewrite");
                form.Show();
                this.Enabled = false;
            }
            else if (CurrentLesson.QuestionList[ChoosenQuestion].GetType() == new Question().GetType())
            {
                QuestionSetupForm form = new QuestionSetupForm();
                form.LocalQuestion = (Question)CurrentLesson.QuestionList[ChoosenQuestion];
                form.Text = "Индекс: " + ChoosenQuestion.ToString();
                FileTools.Log("Йquestion setup opened as rewrite");
                form.Show();
                this.Enabled = false;

            }
            else if (CurrentLesson.QuestionList[ChoosenQuestion].GetType() == new ImageQuestion().GetType())
            {
                ImageQuestionSetupForm form = new ImageQuestionSetupForm();
                form.LocalQuestion = (ImageQuestion)CurrentLesson.QuestionList[ChoosenQuestion];
                form.Text = "Индекс: " + ChoosenQuestion.ToString();
                FileTools.Log("Image question setup opened as rewrite");
                form.Show();
                this.Enabled = false;
            }

        }

        private void FromTxt_Click(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedItem == null) return;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.ShowDialog();
            StreamReader w = new StreamReader(openFileDialog1.FileName,Encoding.UTF8);
            Lesson CurrentLesson = Lesson_mass[LessonChoose.SelectedIndex];
            Question q;
            string s;
            int index = 0;
            try
            {
                while(true)
                {
                    s = w.ReadLine();
                    if (s == "0") break;
                    if (s == "-1")
                    {
                        index++;
                        continue;
                    }

                    q = (Question)CurrentLesson.QuestionList[index];

                    q.Question_s = s;

                    q.Answers[0] = w.ReadLine();
                    q.Answers[1] = w.ReadLine();
                    q.Answers[2] = w.ReadLine();
                    q.Answers[3] = w.ReadLine();
                    index++;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
            MessageBox.Show("Done");
        }

        private void добавитьИнструктажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите урок");
                return;
            }
            
            ExplanationFormSetup form = new ExplanationFormSetup();
            form.Text = "Индекс: " + QuestionChoose.Nodes.Count;
            FileTools.Log("Explanation setup opened");
            form.Show();
            this.Enabled = false;
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите урок");
                return;
            }
            if (MessageBox.Show("Внимание , это действие не обратимо!", "Удалить?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (QuestionChoose.SelectedNode == null)
            {
                MessageBox.Show("Выбери задание");
                return;
            }

            Lesson_mass[ChoosenLesson].QuestionList.RemoveAt(ChoosenQuestion);

            LessonChoose_SelectedIndexChanged(LessonChoose, null);
        }

        private void добавитьВопросСКартинкойToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите урок");
                return;
            }
            ImageQuestionSetupForm form = new ImageQuestionSetupForm();
            form.Text = "Индекс: " + QuestionChoose.Nodes.Count;
            FileTools.Log("Image question setup opened");
            form.Show();
            this.Enabled = false;
        }

        private void добавитьПростойВопросToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите урок");
                return;
            }
            QuestionSetupForm form = new QuestionSetupForm();
            form.Text = "Индекс: " + QuestionChoose.Nodes.Count;
            FileTools.Log("Question setup opened");
            form.Show();
            this.Enabled = false;
        }

        internal void ChangeLesson(string _Name, string[] _args , int _index)
        {
            Lesson CurrentLesson = Lesson_mass[_index];
            CurrentLesson.Name = _Name;
            CurrentLesson.args = _args;
            AddToLessonChoose();
        }

        internal void CreateLesson(string Name, string[] _args)
        {
            Lesson_mass.Add(new Lesson()
            {
                Name = Name != "" ? Name : "Тест",
                args = _args
            });

            AddToLessonChoose();
            FileTools.Log("New lesson created");
        }

        private void добавитьУрокToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                this.Enabled = false;
                LessonForm Get = new LessonForm();
                Get.Show();
            }
        }

        private void слияниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedIndex == -1)
                MessageBox.Show("Выберите сначала первый урок , а затем второй");
            else
            {
                MessageBox.Show("Выберите второй урок");
                FirstLessonForMerge = (byte)ChoosenLesson;
                NumOfChoosenLessonForMerge = 1;
            }

            IsMergeStart = true;
        }

        private void QuestionChoose_DoubleClick(object sender, EventArgs e)
        {
            FileTools.Log("Double Click");
            CreateLessonForms();
        }

        private void QuestionChoose_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                CreateLessonForms();
        }

        private void изменитьУрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1 && LessonChoose.SelectedIndex != -1)
            {
                this.Enabled = false;
                string[] args = new string[5];
                for (int i = 0; i < Lesson_mass[ChoosenLesson].args.Length; i++)
                    args[i] = (string)Lesson_mass[ChoosenLesson].args[i];

                LessonForm Get = new LessonForm(args , Lesson_mass[ChoosenLesson].Name,ChoosenLesson);
                Get.Show();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LessonChoose.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите урок");
                return;
            }
            if (MessageBox.Show("Внимание , это действие не обратимо!", "Удалить?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Lesson_mass.RemoveAt(ChoosenLesson);

            ChoosenLesson = 0;
            AddToLessonChoose();
        }
    }
}
