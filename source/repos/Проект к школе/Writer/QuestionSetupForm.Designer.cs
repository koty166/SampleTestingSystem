namespace Проект_к_школе
{
    public  partial class QuestionSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuestionSetupLabel = new System.Windows.Forms.Label();
            this.QuestionSetup = new System.Windows.Forms.TextBox();
            this.AddQuestion = new System.Windows.Forms.Button();
            this.Answer4Label = new System.Windows.Forms.Label();
            this.Answer3Label = new System.Windows.Forms.Label();
            this.Answer2Label = new System.Windows.Forms.Label();
            this.Answer1Label = new System.Windows.Forms.Label();
            this.AnswerSetup4 = new System.Windows.Forms.TextBox();
            this.AnswerSetup3 = new System.Windows.Forms.TextBox();
            this.AnswerSetup2 = new System.Windows.Forms.TextBox();
            this.AnswerSetup1 = new System.Windows.Forms.TextBox();
            this.Answer5Label = new System.Windows.Forms.Label();
            this.AnswerSetup5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // QuestionSetupLabel
            // 
            this.QuestionSetupLabel.AutoSize = true;
            this.QuestionSetupLabel.Location = new System.Drawing.Point(12, 11);
            this.QuestionSetupLabel.Name = "QuestionSetupLabel";
            this.QuestionSetupLabel.Size = new System.Drawing.Size(85, 13);
            this.QuestionSetupLabel.TabIndex = 20;
            this.QuestionSetupLabel.Text = "Текст вопроса:";
            // 
            // QuestionSetup
            // 
            this.QuestionSetup.Location = new System.Drawing.Point(104, 11);
            this.QuestionSetup.Name = "QuestionSetup";
            this.QuestionSetup.Size = new System.Drawing.Size(267, 20);
            this.QuestionSetup.TabIndex = 19;
            // 
            // AddQuestion
            // 
            this.AddQuestion.Location = new System.Drawing.Point(236, 138);
            this.AddQuestion.Name = "AddQuestion";
            this.AddQuestion.Size = new System.Drawing.Size(135, 25);
            this.AddQuestion.TabIndex = 22;
            this.AddQuestion.Text = "Добавить";
            this.AddQuestion.UseVisualStyleBackColor = true;
            this.AddQuestion.Click += new System.EventHandler(this.AddQuestion_Click);
            // 
            // Answer4Label
            // 
            this.Answer4Label.AutoSize = true;
            this.Answer4Label.Location = new System.Drawing.Point(193, 94);
            this.Answer4Label.Name = "Answer4Label";
            this.Answer4Label.Size = new System.Drawing.Size(86, 13);
            this.Answer4Label.TabIndex = 30;
            this.Answer4Label.Text = "Текст ответа 4:";
            // 
            // Answer3Label
            // 
            this.Answer3Label.AutoSize = true;
            this.Answer3Label.Location = new System.Drawing.Point(193, 46);
            this.Answer3Label.Name = "Answer3Label";
            this.Answer3Label.Size = new System.Drawing.Size(86, 13);
            this.Answer3Label.TabIndex = 31;
            this.Answer3Label.Text = "Текст ответа 3:";
            // 
            // Answer2Label
            // 
            this.Answer2Label.AutoSize = true;
            this.Answer2Label.Location = new System.Drawing.Point(12, 98);
            this.Answer2Label.Name = "Answer2Label";
            this.Answer2Label.Size = new System.Drawing.Size(86, 13);
            this.Answer2Label.TabIndex = 32;
            this.Answer2Label.Text = "Текст ответа 2:";
            // 
            // Answer1Label
            // 
            this.Answer1Label.AutoSize = true;
            this.Answer1Label.Location = new System.Drawing.Point(12, 48);
            this.Answer1Label.Name = "Answer1Label";
            this.Answer1Label.Size = new System.Drawing.Size(86, 13);
            this.Answer1Label.TabIndex = 33;
            this.Answer1Label.Text = "Текст ответа 1:";
            // 
            // AnswerSetup4
            // 
            this.AnswerSetup4.Location = new System.Drawing.Point(288, 91);
            this.AnswerSetup4.Name = "AnswerSetup4";
            this.AnswerSetup4.Size = new System.Drawing.Size(83, 20);
            this.AnswerSetup4.TabIndex = 29;
            // 
            // AnswerSetup3
            // 
            this.AnswerSetup3.Location = new System.Drawing.Point(288, 43);
            this.AnswerSetup3.Name = "AnswerSetup3";
            this.AnswerSetup3.Size = new System.Drawing.Size(83, 20);
            this.AnswerSetup3.TabIndex = 28;
            // 
            // AnswerSetup2
            // 
            this.AnswerSetup2.Location = new System.Drawing.Point(104, 91);
            this.AnswerSetup2.Name = "AnswerSetup2";
            this.AnswerSetup2.Size = new System.Drawing.Size(83, 20);
            this.AnswerSetup2.TabIndex = 27;
            // 
            // AnswerSetup1
            // 
            this.AnswerSetup1.Location = new System.Drawing.Point(104, 45);
            this.AnswerSetup1.Name = "AnswerSetup1";
            this.AnswerSetup1.Size = new System.Drawing.Size(83, 20);
            this.AnswerSetup1.TabIndex = 26;
            // 
            // Answer5Label
            // 
            this.Answer5Label.AutoSize = true;
            this.Answer5Label.Location = new System.Drawing.Point(9, 141);
            this.Answer5Label.Name = "Answer5Label";
            this.Answer5Label.Size = new System.Drawing.Size(86, 13);
            this.Answer5Label.TabIndex = 35;
            this.Answer5Label.Text = "Текст ответа 5:";
            this.Answer5Label.Visible = false;
            // 
            // AnswerSetup5
            // 
            this.AnswerSetup5.Location = new System.Drawing.Point(104, 138);
            this.AnswerSetup5.Name = "AnswerSetup5";
            this.AnswerSetup5.Size = new System.Drawing.Size(83, 20);
            this.AnswerSetup5.TabIndex = 34;
            this.AnswerSetup5.Visible = false;
            // 
            // QuestionSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 175);
            this.Controls.Add(this.Answer5Label);
            this.Controls.Add(this.AnswerSetup5);
            this.Controls.Add(this.Answer4Label);
            this.Controls.Add(this.Answer3Label);
            this.Controls.Add(this.Answer2Label);
            this.Controls.Add(this.Answer1Label);
            this.Controls.Add(this.AnswerSetup4);
            this.Controls.Add(this.AnswerSetup3);
            this.Controls.Add(this.AnswerSetup2);
            this.Controls.Add(this.AnswerSetup1);
            this.Controls.Add(this.AddQuestion);
            this.Controls.Add(this.QuestionSetupLabel);
            this.Controls.Add(this.QuestionSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "QuestionSetupForm";
            this.Text = "QuestionSetupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionSetupForm_FormClosing);
            this.Load += new System.EventHandler(this.QuestionSetupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label QuestionSetupLabel;
        private System.Windows.Forms.TextBox QuestionSetup;
        private System.Windows.Forms.Button AddQuestion;
        private System.Windows.Forms.Label Answer4Label;
        private System.Windows.Forms.Label Answer3Label;
        private System.Windows.Forms.Label Answer2Label;
        private System.Windows.Forms.Label Answer1Label;
        private System.Windows.Forms.TextBox AnswerSetup4;
        private System.Windows.Forms.TextBox AnswerSetup3;
        private System.Windows.Forms.TextBox AnswerSetup2;
        private System.Windows.Forms.TextBox AnswerSetup1;
        private System.Windows.Forms.Label Answer5Label;
        private System.Windows.Forms.TextBox AnswerSetup5;
    }
}