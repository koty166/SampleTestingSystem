using System;
using System.Windows.Forms;
using ClassLibrary2;

namespace Проект_к_школе
{
    public partial class ExplanationFormSetup : Form
    {
        public ExplanationFormSetup()
        {
            InitializeComponent();
        }
        internal Explanation LocalQuestion;
        bool IsChange;
        private void AddExplanation_Click(object sender, EventArgs e)
        {
            Explanation ex = new Explanation();
            FormWriter form = (FormWriter)Application.OpenForms[0];

            ex.Text = TextOfExplanation.Text;
            if (!IsChange)
            {
                form.Lesson_mass[form.ChosenLesson].QuestionList.Add(ex);
                form.AddToQuestionChoose(ex);
            }
            else
            {
                form.Lesson_mass[form.ChosenLesson].QuestionList[form.ChoosenQuestion] = ex;
            }
            form.Enabled = true;
            this.Dispose();
        }

        private void ExplanationFormSetup_Load(object sender, EventArgs e)
        {
            try
            {
                TextOfExplanation.Text = LocalQuestion.Text;
                AddExplanation.Text = "Изменить";
                IsChange = true;
            }
            catch
            {

            }
        }

        private void ExplanationFormSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Enabled = true;
        }
    }
}
