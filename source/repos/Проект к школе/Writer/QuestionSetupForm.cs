using System;
using System.Windows.Forms;
using ClassLibrary2;

namespace Проект_к_школе
{
    public partial class QuestionSetupForm : Form
    {
        public QuestionSetupForm()
        {
            InitializeComponent();
        }
        internal Question LocalQuestion;
        bool IsChange;
        private void AddQuestion_Click(object sender, EventArgs e)
        {
            Question q = new Question();
            FormWriter form = (FormWriter)Application.OpenForms[0];

            q.Question_s = QuestionSetup.Text;
            q.Answers[0] = AnswerSetup1.Text;
            q.Answers[1] = AnswerSetup2.Text;
            q.Answers[2] = AnswerSetup3.Text;
            q.Answers[3] = AnswerSetup4.Text;
            if (!IsChange)
            {
                form.Lesson_mass[form.ChoosenLesson].QuestionList.Add(q);
                form.AddToQuestionChoose(q);
            }
            else
            {
                form.Lesson_mass[form.ChoosenLesson].QuestionList[form.ChoosenQuestion] = q;
            }
            form.Enabled = true;
            this.Dispose();
        }

        private void QuestionSetupForm_Load(object sender, EventArgs e)
        {
            try
            {
                QuestionSetup.Text = LocalQuestion.Question_s;
                AnswerSetup1.Text = LocalQuestion.Answers[0];
                AnswerSetup2.Text = LocalQuestion.Answers[1];
                AnswerSetup3.Text = LocalQuestion.Answers[2];
                AnswerSetup4.Text = LocalQuestion.Answers[3];
                AddQuestion.Text = "Изменить";
                IsChange = true;
            }
            catch
            {

            }
        }

        private void QuestionSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Enabled = true;
            FileTools.Log("Question create is done");
        }
    }
}
