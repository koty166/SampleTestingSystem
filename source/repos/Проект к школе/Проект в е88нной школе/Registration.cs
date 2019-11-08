using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (NameSetup.Text.Length <= 10 && NameSetup.Text != "" && SurnameSetup.Text.Length <= 10 && SurnameSetup.Text != "" &&
                PatronymicSetup.Text.Length <= 10 && PatronymicSetup.Text != "" && Int32.Parse(AgeSetup.Text) > 5 && Int32.Parse(AgeSetup.Text) <= 19)
                return true;
            else
                return false;
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
                this.Dispose();
            }
            else
                MessageBox.Show("Проверьте правильность введённых данных \nКолл-во символов в строке имени\\фамилии\\отчества не должно превышать 10");
        }
    }
}
