﻿namespace Проект_к_школе
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Start = new System.Windows.Forms.Button();
            this.ExplanationLabel = new System.Windows.Forms.Label();
            this.list_of_lessons = new System.Windows.Forms.ListBox();
            this.Next = new System.Windows.Forms.Button();
            this.AnswerTextSetup = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.Answer4 = new System.Windows.Forms.RadioButton();
            this.Answer3 = new System.Windows.Forms.RadioButton();
            this.Answer2 = new System.Windows.Forms.RadioButton();
            this.Answer1 = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(420, 178);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(85, 21);
            this.Start.TabIndex = 29;
            this.Start.Text = "Начать";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // ExplanationLabel
            // 
            this.ExplanationLabel.AutoEllipsis = true;
            this.ExplanationLabel.AutoSize = true;
            this.ExplanationLabel.Location = new System.Drawing.Point(22, 26);
            this.ExplanationLabel.Name = "ExplanationLabel";
            this.ExplanationLabel.Size = new System.Drawing.Size(201, 13);
            this.ExplanationLabel.TabIndex = 27;
            this.ExplanationLabel.Text = "Выбери урок , который хочешь пройти";
            // 
            // list_of_lessons
            // 
            this.list_of_lessons.FormattingEnabled = true;
            this.list_of_lessons.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.list_of_lessons.Location = new System.Drawing.Point(104, 161);
            this.list_of_lessons.Name = "list_of_lessons";
            this.list_of_lessons.Size = new System.Drawing.Size(294, 56);
            this.list_of_lessons.TabIndex = 25;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(204, 223);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(86, 20);
            this.Next.TabIndex = 24;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Visible = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // AnswerTextSetup
            // 
            this.AnswerTextSetup.Location = new System.Drawing.Point(25, 350);
            this.AnswerTextSetup.Name = "AnswerTextSetup";
            this.AnswerTextSetup.Size = new System.Drawing.Size(350, 20);
            this.AnswerTextSetup.TabIndex = 23;
            this.AnswerTextSetup.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QuestionLabel);
            this.groupBox1.Controls.Add(this.Answer4);
            this.groupBox1.Controls.Add(this.Answer3);
            this.groupBox1.Controls.Add(this.Answer2);
            this.groupBox1.Controls.Add(this.Answer1);
            this.groupBox1.Location = new System.Drawing.Point(98, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 102);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionLabel.Location = new System.Drawing.Point(18, 16);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(45, 16);
            this.QuestionLabel.TabIndex = 4;
            this.QuestionLabel.Text = "label2";
            // 
            // Answer4
            // 
            this.Answer4.AutoSize = true;
            this.Answer4.Location = new System.Drawing.Point(206, 68);
            this.Answer4.Name = "Answer4";
            this.Answer4.Size = new System.Drawing.Size(85, 17);
            this.Answer4.TabIndex = 3;
            this.Answer4.TabStop = true;
            this.Answer4.Tag = "";
            this.Answer4.Text = "radioButton4";
            this.Answer4.UseVisualStyleBackColor = true;
            // 
            // Answer3
            // 
            this.Answer3.AutoSize = true;
            this.Answer3.Location = new System.Drawing.Point(206, 45);
            this.Answer3.Name = "Answer3";
            this.Answer3.Size = new System.Drawing.Size(85, 17);
            this.Answer3.TabIndex = 2;
            this.Answer3.TabStop = true;
            this.Answer3.Tag = "";
            this.Answer3.Text = "radioButton3";
            this.Answer3.UseVisualStyleBackColor = true;
            // 
            // Answer2
            // 
            this.Answer2.AutoSize = true;
            this.Answer2.Location = new System.Drawing.Point(21, 68);
            this.Answer2.Name = "Answer2";
            this.Answer2.Size = new System.Drawing.Size(85, 17);
            this.Answer2.TabIndex = 1;
            this.Answer2.TabStop = true;
            this.Answer2.Tag = "";
            this.Answer2.Text = "radioButton2";
            this.Answer2.UseVisualStyleBackColor = true;
            // 
            // Answer1
            // 
            this.Answer1.AutoSize = true;
            this.Answer1.Location = new System.Drawing.Point(21, 45);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(85, 17);
            this.Answer1.TabIndex = 0;
            this.Answer1.TabStop = true;
            this.Answer1.Tag = "";
            this.Answer1.Text = "radioButton1";
            this.Answer1.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(25, 43);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(550, 300);
            this.pictureBox.TabIndex = 28;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 418);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ExplanationLabel);
            this.Controls.Add(this.list_of_lessons);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.AnswerTextSetup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестовая система";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label ExplanationLabel;
        private System.Windows.Forms.ListBox list_of_lessons;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.TextBox AnswerTextSetup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.RadioButton Answer4;
        private System.Windows.Forms.RadioButton Answer3;
        private System.Windows.Forms.RadioButton Answer2;
        private System.Windows.Forms.RadioButton Answer1;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

