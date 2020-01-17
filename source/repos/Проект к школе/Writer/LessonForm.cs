using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_к_школе
{
    public partial class LessonForm : Form
    {
        public LessonForm(string[] _args = null , string _Name = "" , int _index = 0)
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

            if (LessonNameIn == "")
                f.CreateLesson(LessonName.Text, args);
            else
                f.ChangeLesson(LessonName.Text,args,index);
            f.Enabled = true;
            this.Dispose();
        }

        private void LessonForm_Load(object sender, EventArgs e)
        {
            if (LessonNameIn == "") return;

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
