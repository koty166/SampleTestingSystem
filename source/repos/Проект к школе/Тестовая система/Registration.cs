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
                if (NameSetup.Text.Length <= 15 && NameSetup.Text != "" && SurnameSetup.Text.Length <= 15 && SurnameSetup.Text != "" &&
                    PatronymicSetup.Text.Length <= 15 && PatronymicSetup.Text != "" && Int32.Parse(AgeSetup.Text) > 5 && Int32.Parse(AgeSetup.Text) <= 19
                    && FormSetup.Value < 12 && FormSetup.Value > 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Pupil p = new Pupil(
                    Convert.ToInt32(AgeSetup.Text),
                    (int)FormSetup.Value,
                    NameSetup.Text,
                    SurnameSetup.Text,
                    PatronymicSetup.Text
                    );
                Form1 f = (Form1)Application.OpenForms[0];
                f.pupil = p;
                f.Enabled = true;
                f.Next2();
                this.Close();
            }
            else
                MessageBox.Show("Проверьте правильность введённых данных");
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f = (Form1)Application.OpenForms[0];
            f.Enabled = true;
            if (f.pupil == null)
                f.pupil = new Pupil();
            FileTools.Log("Registration is done");
            f.Next2();
        }
    }
}
