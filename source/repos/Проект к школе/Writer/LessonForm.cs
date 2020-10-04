using System;
using System.Windows.Forms;

namespace Проект_к_школе
{
    public partial class LessonForm : Form
    {
        public LessonForm(string[] _args = null , string _Name = "-1" , int _index = 0)
        {
            InitializeComponent();
            args = _args;
            LessonNameIn = _Name;
            index = _index;
        }
        string[] args;
        string LessonNameIn;
        int index;
        private void button1_Click(object sender, EventArgs e)
        {
            FormWriter f = (FormWriter)Application.OpenForms[0];
            string[] args = new string[] { arg0.Text, arg1.Text, arg2.Text, arg3.Text, arg4.Text };

            if (LessonNameIn == "-1")
                f.CreateLesson(LessonName.Text, args);
            else
                f.ChangeLesson(LessonName.Text,args,index);
            f.Enabled = true;
            this.Dispose();
        }

        private void LessonForm_Load(object sender, EventArgs e)
        {
            if (LessonNameIn == "-1") return;

            LessonName.Text = LessonNameIn;
            arg0.Text = args[0];
            arg1.Text = args[1];
            arg2.Text = args[2];
            arg3.Text = args[3];
            arg4.Text = args[4];
            EndButton.Text = "Изменить";
        }
    }
}
