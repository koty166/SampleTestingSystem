using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using LessonsResourses;

namespace Проект_к_школе
{
    public partial class QuestionCreateForm : Form
    {
        readonly FormWriter FWParent;
        readonly bool IsNew;
        readonly Question QuestionToChange;
        const String directory = @"Tests";
        List<Question> ParentList;
        public QuestionCreateForm(FormWriter _Parent, bool _IsNew,List<Question> _ParentList, int _QuestionToChangeIndex = -1)
        {
            InitializeComponent();
            FWParent = _Parent;
            IsNew = _IsNew;
            QuestionToChange = _QuestionToChangeIndex != -1 ? _ParentList[_QuestionToChangeIndex] : null;
            ParentList = _ParentList;
        }
        String QuestionImageName;


        private void ImageChooseDialog_FileOk(object sender, CancelEventArgs e) =>
            CheckImage(ImageChooseDialog.SafeFileName);
        void CheckImage(String Path)
        {
            try
            {
                ImageExample.Image = Image.FromFile(directory + "\\Images\\" + Path);
                QuestionPicturePathTB.Text = Path;
                QuestionImageName = Path;
            }
            catch
            {
                MessageBox.Show("Недопустимая картинка");
            }
            ImageChooseDialog.Dispose();
        }
        private void ImageQuestionSetupForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(directory + "\\Images"))
                Directory.CreateDirectory(directory + "\\Images");
            if(!IsNew && QuestionToChange != null)
            {
                QuestionNameTB.Text = QuestionToChange.Name;
                QuestionAnswersTB.Text = QuestionToChange.Answer;
                QuestionQuestionTextTB.Text = QuestionToChange.QuestionText;
                QuestionPicturePathTB.Text = QuestionToChange.PicturePath ?? "";
                AddQuestionButton.Text = "Изменить";
                try
                {
                    ImageExample.Image = Image.FromFile(directory + "\\Images\\" + QuestionToChange.PicturePath ?? "");
                    CheckImage(QuestionToChange.PicturePath);
                }
                catch { }
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                ParentList.Add(new Question() 
                { 
                    Name = QuestionNameTB.Text,
                    QuestionText = QuestionQuestionTextTB.Text,
                    Answer = QuestionAnswersTB.Text,
                    PicturePath = QuestionImageName
                });
            }
            else
            {
                QuestionToChange.Name = QuestionNameTB.Text;
                QuestionToChange.QuestionText = QuestionQuestionTextTB.Text;
                QuestionToChange.Answer = QuestionAnswersTB.Text;
                QuestionToChange.PicturePath = QuestionImageName;

            }
            FWParent.Enabled = true;
            FWParent.UpdateExploer();
            Dispose();
        }

        private void QuestionPicturePathChooseButton_Click(object sender, EventArgs e) =>
            ImageChooseDialog.ShowDialog();

        private void QuestionCreateForm_FormClosing(object sender, FormClosingEventArgs e) => FWParent.Enabled = true;
    }
}
