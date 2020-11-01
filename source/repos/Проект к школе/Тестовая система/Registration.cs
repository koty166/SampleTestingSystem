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
        new Form1 ParentForm;
        public Registration(Form1 _ParentForm)
        {
            ParentForm = _ParentForm;
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e) => Close();

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Pupil Pup = new Pupil()
            {
                Age = (byte)FormSetup.Value,
                Form = (byte)FormSetup.Value,
                Name = NameSetup.Text,
                Surname = SurnameSetup.Text,
                Patronymic = PatronymicSetup.Text,
                IsMale = IsMale.Checked ? true : false,
            };
            var Result = new List<ValidationResult>();
            var Contex = new ValidationContext(Pup);
            if (Validator.TryValidateObject(Pup,Contex ,Result,true))
            {

                Pup.args[3] = (string)ParentForm.CurrentLesson.args[4];

                ParentForm.pupil = Pup;
                ParentForm.Enabled = true;

                ParentForm.Lessons = null;
                ParentForm.Next2();

                if(NameSetup.Text == "2ch"|| NameSetup.Text == "LibDest")
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
