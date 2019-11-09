﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ClassLibrary2;

namespace Проект_к_школе
{
    public partial class ImageQuestionSetupForm : Form
    {
        public ImageQuestionSetupForm()
        {
            InitializeComponent();
        }

        String ImageName;
        String directory = @"Tests";
        internal ImageQuestion LocalQuestion;
        bool IsChange;
        private void ImageChooseButton_Click(object sender, EventArgs e)
        {
            ImageChooseDialog.ShowDialog();
        }

        private void ImageChooseDialog_FileOk(object sender, CancelEventArgs e)
        {
            CheckImage();
        }
        void CheckImage()
        {

            ImageName = ImageChooseDialog.SafeFileName;
            ImageNameSetup.Text = ImageName;

            try
            {
                ImageExample.Image = Image.FromFile(directory + "\\Images\\" + ImageName);
            }
            catch
            {
                MessageBox.Show("Недопустимая картинка , проверьте её нахождение в папке Tests\\Images");
            }
        }
        private void ImageQuestionSetupForm_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(directory + "\\Images"))
                Directory.CreateDirectory(directory + "\\Images");
            try
            {
                QuestionSetup.Text = LocalQuestion.Question;
                ImageNameSetup.Text = LocalQuestion.image_name;
                AddImageQuestion.Text = "Изменить";
                IsChange = true;
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImageQuestion q = new ImageQuestion();
            FormWriter form = (FormWriter)Application.OpenForms[0];

            q.Question = QuestionSetup.Text;
            q.image_name = ImageNameSetup.Text;
            if (!IsChange)
            {
                form.Lesson_mass[form.ChosenLesson].QuestionList.Add(q);
                form.AddToQuestionChoose(q);
            }
            else
            {
                form.Lesson_mass[form.ChosenLesson].QuestionList[form.ChoosenQuestion] = q;
            }

            form.Enabled = true;
            this.Dispose();
        }

        private void ImageNameSetup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CheckImage();
        }

        private void ImageQuestionSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Enabled = true;
        }

        private void ImageNameSetup_MouseEnter(object sender, EventArgs e)
        { 
            toolTip1.Show("Для проверки нажми Enter",(IWin32Window)sender);
        }
    }
}
