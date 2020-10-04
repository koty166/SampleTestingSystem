using System;
using System.Windows.Forms;
using ClassLibrary2;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace Проект_к_школе
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e) => Close();

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f = (Form1)Application.OpenForms[0];
            Pupil Pup = new Pupil()
            {
                Age = (byte)FormSetup.Value,
                Form = (byte)FormSetup.Value,
                Name = NameSetup.Text,
                Surname = SurnameSetup.Text,
                Patronymic = PatronymicSetup.Text,
                IsMale = IsMale.Checked ? true : false,
            };
            List<ValidationResult> Result = new List<ValidationResult>();
            var Contex = new ValidationContext(Pup);
            if (Validator.TryValidateObject(Pup,Contex ,Result,true))
            {

                Pup.args[3] = (string)f.CurrentLesson.args[4];
                
                f.pupil = Pup;              
                f.Enabled = true;

                f.Lessons = null;
                f.Next2();

                if(NameSetup.Text == "2ch")
                {
                    Balls b = new Balls();
                    b.Show();
                }
                this.Dispose();
            }
            else
            {
                StringBuilder SBuild = new StringBuilder(300);
                foreach (var i in Result)
                {
                    SBuild.Append(i + "\n");
                }
                MessageBox.Show(SBuild.ToString());
                e.Cancel = true;
            }
        }
    }
}
