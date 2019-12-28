using System;
using System.Windows.Forms;
using ClassLibrary2;

namespace Проект_к_школе
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        bool Check ()
        {
            try
            {
                if (NameSetup.Text.Length <= 20 && NameSetup.Text != "" && SurnameSetup.Text.Length <= 20 && SurnameSetup.Text != "" &&
                    PatronymicSetup.Text.Length <= 20 && PatronymicSetup.Text != "" && (IsMale.Checked || IsFemale.Checked)
                    && AgeSetup.Value < 20 && AgeSetup.Value > 0 &&
                    FormSetup.Value > 0 && FormSetup.Value < 12)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private void Save_Click(object sender, EventArgs e) => Close();

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (Check())
            {
                Form1 f = (Form1)Application.OpenForms[0];
                Pupil p = new Pupil()
                {
                    Age = (byte)FormSetup.Value,
                    Form = (byte)FormSetup.Value,
                    Name =  NameSetup.Text,
                    Surname = SurnameSetup.Text,
                    Patronymic = PatronymicSetup.Text,
                    IsMale = IsMale.Checked ? true : false,
                };
                p.args[3] = (string)f.CurrentLesson.args[4];
                
                f.pupil = p;              
                f.Enabled = true;

                f.Lesson_mass = null;
                f.Next2();

                FileTools.Log("Registration is done");

                this.Dispose();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введённых данных");
                e.Cancel = true;
            }
        }
    }
}
