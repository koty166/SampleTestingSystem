namespace Проект_к_школе
{
    partial class FormWriter
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuestionChoose = new System.Windows.Forms.TreeView();
            this.LessonChoose = new System.Windows.Forms.ListBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.CreateNewLesson = new System.Windows.Forms.Button();
            this.NewLessonNameLabel = new System.Windows.Forms.Label();
            this.LessonChooseLabel = new System.Windows.Forms.Label();
            this.AddQuestion = new System.Windows.Forms.Button();
            this.AddInstraction = new System.Windows.Forms.Button();
            this.AddImageQuestion = new System.Windows.Forms.Button();
            this.FromTxt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // QuestionChoose
            // 
            this.QuestionChoose.Location = new System.Drawing.Point(12, 12);
            this.QuestionChoose.Name = "QuestionChoose";
            this.QuestionChoose.Size = new System.Drawing.Size(166, 422);
            this.QuestionChoose.TabIndex = 11;
            this.QuestionChoose.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.QuestionChoose_AfterSelect);
            // 
            // LessonChoose
            // 
            this.LessonChoose.FormattingEnabled = true;
            this.LessonChoose.Location = new System.Drawing.Point(187, 40);
            this.LessonChoose.Name = "LessonChoose";
            this.LessonChoose.Size = new System.Drawing.Size(232, 95);
            this.LessonChoose.TabIndex = 12;
            this.LessonChoose.SelectedIndexChanged += new System.EventHandler(this.LessonChoose_SelectedIndexChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(252, 189);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(154, 20);
            this.textBox6.TabIndex = 14;
            // 
            // CreateNewLesson
            // 
            this.CreateNewLesson.Location = new System.Drawing.Point(187, 141);
            this.CreateNewLesson.Name = "CreateNewLesson";
            this.CreateNewLesson.Size = new System.Drawing.Size(184, 32);
            this.CreateNewLesson.TabIndex = 15;
            this.CreateNewLesson.Text = "Создать новый урок";
            this.CreateNewLesson.UseVisualStyleBackColor = true;
            this.CreateNewLesson.Click += new System.EventHandler(this.CreateNewLesson_Click);
            // 
            // NewLessonNameLabel
            // 
            this.NewLessonNameLabel.AutoSize = true;
            this.NewLessonNameLabel.Location = new System.Drawing.Point(184, 189);
            this.NewLessonNameLabel.Name = "NewLessonNameLabel";
            this.NewLessonNameLabel.Size = new System.Drawing.Size(29, 13);
            this.NewLessonNameLabel.TabIndex = 16;
            this.NewLessonNameLabel.Text = "Имя";
            // 
            // LessonChooseLabel
            // 
            this.LessonChooseLabel.AutoSize = true;
            this.LessonChooseLabel.Location = new System.Drawing.Point(184, 12);
            this.LessonChooseLabel.Name = "LessonChooseLabel";
            this.LessonChooseLabel.Size = new System.Drawing.Size(101, 13);
            this.LessonChooseLabel.TabIndex = 17;
            this.LessonChooseLabel.Text = "Выбери урок ниже";
            // 
            // AddQuestion
            // 
            this.AddQuestion.Location = new System.Drawing.Point(187, 345);
            this.AddQuestion.Name = "AddQuestion";
            this.AddQuestion.Size = new System.Drawing.Size(122, 35);
            this.AddQuestion.TabIndex = 18;
            this.AddQuestion.Text = "Добавить простой вопрос";
            this.AddQuestion.UseVisualStyleBackColor = true;
            this.AddQuestion.Click += new System.EventHandler(this.AddQuestion_Click);
            // 
            // AddInstraction
            // 
            this.AddInstraction.Location = new System.Drawing.Point(187, 295);
            this.AddInstraction.Name = "AddInstraction";
            this.AddInstraction.Size = new System.Drawing.Size(122, 35);
            this.AddInstraction.TabIndex = 19;
            this.AddInstraction.Text = "Добавить пример или инструктаж";
            this.AddInstraction.UseVisualStyleBackColor = true;
            this.AddInstraction.Click += new System.EventHandler(this.AddInstraction_Click);
            // 
            // AddImageQuestion
            // 
            this.AddImageQuestion.Location = new System.Drawing.Point(187, 396);
            this.AddImageQuestion.Name = "AddImageQuestion";
            this.AddImageQuestion.Size = new System.Drawing.Size(122, 35);
            this.AddImageQuestion.TabIndex = 20;
            this.AddImageQuestion.Text = "Добавить вопрос с картинкой";
            this.AddImageQuestion.UseVisualStyleBackColor = true;
            this.AddImageQuestion.Click += new System.EventHandler(this.AddImageQiestion_Click);
            // 
            // FromTxt
            // 
            this.FromTxt.Location = new System.Drawing.Point(207, 244);
            this.FromTxt.Name = "FromTxt";
            this.FromTxt.Size = new System.Drawing.Size(77, 31);
            this.FromTxt.TabIndex = 21;
            this.FromTxt.Text = "FromTxt";
            this.FromTxt.UseVisualStyleBackColor = true;
            this.FromTxt.Click += new System.EventHandler(this.FromTxt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 447);
            this.Controls.Add(this.FromTxt);
            this.Controls.Add(this.AddImageQuestion);
            this.Controls.Add(this.AddInstraction);
            this.Controls.Add(this.AddQuestion);
            this.Controls.Add(this.LessonChooseLabel);
            this.Controls.Add(this.NewLessonNameLabel);
            this.Controls.Add(this.CreateNewLesson);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.LessonChoose);
            this.Controls.Add(this.QuestionChoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormWriter";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView QuestionChoose;
        private System.Windows.Forms.ListBox LessonChoose;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button CreateNewLesson;
        private System.Windows.Forms.Label NewLessonNameLabel;
        private System.Windows.Forms.Label LessonChooseLabel;
        private System.Windows.Forms.Button AddQuestion;
        private System.Windows.Forms.Button AddInstraction;
        private System.Windows.Forms.Button AddImageQuestion;
        private System.Windows.Forms.Button FromTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

