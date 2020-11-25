using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using LessonsResourses;

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

        /// <summary>
        /// Выполняет проверку полей на корректность.
        /// </summary>
        /// <param name="Result">Список ошибок</param>
        bool ValidatePupil(out List<string> Result)
        {
            
            Result = new List<string>();

            if ((NameSetup.Text?.Length ?? 0) > 0 && (NameSetup.Text?.Length ?? 20) < 20 && new Regex(@"[\w]+[\s]?[-]?[\w]*").Matches(NameSetup.Text ?? "").Count != 1 )
                Result.Add("Неверно указано имя.");
            if((SurnameSetup.Text?.Length ?? 0) > 0 && (SurnameSetup.Text?.Length ?? 20) < 20 && new Regex(@"[\w]+[\s]?[-]?[\w]*").Matches(SurnameSetup.Text ?? "").Count != 1)
                Result.Add("Неверно указана фамилия.");
            if ((SurnameSetup.Text?.Length ?? 20) < 20 && new Regex(@"[\w]*[\s]?[-]?[\w]*").Matches(SurnameSetup.Text ?? "").Count != 1)
                Result.Add("Неверно указано отчество.");
            if(FormSetup.Value > 0 && FormSetup.Value <= 11)
                Result.Add("Неверно указан класс.");
            if (AgeSetup.Value > 5 && AgeSetup.Value <= 18)
                Result.Add("Неверно указан возраст.");
            if(!IsMale.Checked && !IsFemale.Checked)
                Result.Add("Не указан пол.");

            if (Result.Count > 0)
                return false;
            return true;
        }
        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> Result;
            Pupil Pup;
            if (ValidatePupil(out Result))
            {
                Pup = new Pupil()
                {
                    Name = NameSetup.Text,
                    Surname = SurnameSetup.Text,
                    Patronymic = PatronymicSetup.Text,
                    Age = (byte)AgeSetup.Value,
                    Form = (byte)FormSetup.Value,
                    IsMale = IsMale.Checked
                };
                ParentForm.CurrentPup = Pup;
                ParentForm.Enabled = true;
                ParentForm.Next2();
            }

            else
            {
                if (NameSetup.Text == "2ch" || NameSetup.Text == "LibDest")
                {
                    Balls b = new Balls();
                    b.Show();
                }
                this.Dispose();

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
