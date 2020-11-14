namespace Проект_к_школе
{
    partial class QuestionCreateForm
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
            this.AddQuestionButton = new System.Windows.Forms.Button();
            this.QuestionQuestionTextLabel = new System.Windows.Forms.Label();
            this.QuestionQuestionTextTB = new System.Windows.Forms.TextBox();
            this.ImageExample = new System.Windows.Forms.PictureBox();
            this.ImageExampleLabel = new System.Windows.Forms.Label();
            this.ImageChooseDialog = new System.Windows.Forms.OpenFileDialog();
            this.QuestionAnswersLabel = new System.Windows.Forms.Label();
            this.QuestionAnswersTB = new System.Windows.Forms.TextBox();
            this.QuestionPicturePathChooseButton = new System.Windows.Forms.Button();
            this.QuestionPicturePathLabel = new System.Windows.Forms.Label();
            this.QuestionPicturePathTB = new System.Windows.Forms.TextBox();
            this.QuestionNameLabel = new System.Windows.Forms.Label();
            this.QuestionNameTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageExample)).BeginInit();
            this.SuspendLayout();
            // 
            // AddQuestionButton
            // 
            this.AddQuestionButton.Location = new System.Drawing.Point(320, 413);
            this.AddQuestionButton.Name = "AddQuestionButton";
            this.AddQuestionButton.Size = new System.Drawing.Size(135, 25);
            this.AddQuestionButton.TabIndex = 36;
            this.AddQuestionButton.Text = "Добавить";
            this.AddQuestionButton.UseVisualStyleBackColor = true;
            this.AddQuestionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuestionQuestionTextLabel
            // 
            this.QuestionQuestionTextLabel.AutoSize = true;
            this.QuestionQuestionTextLabel.Location = new System.Drawing.Point(15, 46);
            this.QuestionQuestionTextLabel.Name = "QuestionQuestionTextLabel";
            this.QuestionQuestionTextLabel.Size = new System.Drawing.Size(85, 13);
            this.QuestionQuestionTextLabel.TabIndex = 35;
            this.QuestionQuestionTextLabel.Text = "Текст вопроса:";
            // 
            // QuestionQuestionTextTB
            // 
            this.QuestionQuestionTextTB.Location = new System.Drawing.Point(109, 43);
            this.QuestionQuestionTextTB.Name = "QuestionQuestionTextTB";
            this.QuestionQuestionTextTB.Size = new System.Drawing.Size(307, 20);
            this.QuestionQuestionTextTB.TabIndex = 34;
            // 
            // ImageExample
            // 
            this.ImageExample.Location = new System.Drawing.Point(17, 92);
            this.ImageExample.Name = "ImageExample";
            this.ImageExample.Size = new System.Drawing.Size(369, 193);
            this.ImageExample.TabIndex = 37;
            this.ImageExample.TabStop = false;
            // 
            // ImageExampleLabel
            // 
            this.ImageExampleLabel.AutoSize = true;
            this.ImageExampleLabel.Location = new System.Drawing.Point(14, 66);
            this.ImageExampleLabel.Name = "ImageExampleLabel";
            this.ImageExampleLabel.Size = new System.Drawing.Size(190, 13);
            this.ImageExampleLabel.TabIndex = 38;
            this.ImageExampleLabel.Text = "Так будет выглядеть твоя картинка";
            // 
            // ImageChooseDialog
            // 
            this.ImageChooseDialog.FileName = "openFileDialog1";
            this.ImageChooseDialog.Filter = "PNG |*.png| Все файлы |*.*";
            this.ImageChooseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImageChooseDialog_FileOk);
            // 
            // QuestionAnswersLabel
            // 
            this.QuestionAnswersLabel.AutoSize = true;
            this.QuestionAnswersLabel.Location = new System.Drawing.Point(12, 356);
            this.QuestionAnswersLabel.Name = "QuestionAnswersLabel";
            this.QuestionAnswersLabel.Size = new System.Drawing.Size(452, 13);
            this.QuestionAnswersLabel.TabIndex = 44;
            this.QuestionAnswersLabel.Text = "Ответы на вопрос через пробел. Если выбор ответа не предпологается оставь пустым";
            // 
            // QuestionAnswersTB
            // 
            this.QuestionAnswersTB.Location = new System.Drawing.Point(15, 387);
            this.QuestionAnswersTB.Name = "QuestionAnswersTB";
            this.QuestionAnswersTB.Size = new System.Drawing.Size(440, 20);
            this.QuestionAnswersTB.TabIndex = 43;
            // 
            // QuestionPicturePathChooseButton
            // 
            this.QuestionPicturePathChooseButton.Location = new System.Drawing.Point(220, 313);
            this.QuestionPicturePathChooseButton.Name = "QuestionPicturePathChooseButton";
            this.QuestionPicturePathChooseButton.Size = new System.Drawing.Size(113, 23);
            this.QuestionPicturePathChooseButton.TabIndex = 48;
            this.QuestionPicturePathChooseButton.Text = "Выбери картинку";
            this.QuestionPicturePathChooseButton.UseVisualStyleBackColor = true;
            this.QuestionPicturePathChooseButton.Click += new System.EventHandler(this.QuestionPicturePathChooseButton_Click);
            // 
            // QuestionPicturePathLabel
            // 
            this.QuestionPicturePathLabel.AutoSize = true;
            this.QuestionPicturePathLabel.Location = new System.Drawing.Point(14, 288);
            this.QuestionPicturePathLabel.Name = "QuestionPicturePathLabel";
            this.QuestionPicturePathLabel.Size = new System.Drawing.Size(90, 13);
            this.QuestionPicturePathLabel.TabIndex = 46;
            this.QuestionPicturePathLabel.Text = "Путь к картинке";
            // 
            // QuestionPicturePathTB
            // 
            this.QuestionPicturePathTB.Location = new System.Drawing.Point(17, 315);
            this.QuestionPicturePathTB.Name = "QuestionPicturePathTB";
            this.QuestionPicturePathTB.ReadOnly = true;
            this.QuestionPicturePathTB.Size = new System.Drawing.Size(197, 20);
            this.QuestionPicturePathTB.TabIndex = 45;
            // 
            // QuestionNameLabel
            // 
            this.QuestionNameLabel.AutoSize = true;
            this.QuestionNameLabel.Location = new System.Drawing.Point(15, 20);
            this.QuestionNameLabel.Name = "QuestionNameLabel";
            this.QuestionNameLabel.Size = new System.Drawing.Size(74, 13);
            this.QuestionNameLabel.TabIndex = 50;
            this.QuestionNameLabel.Text = "Имя вопроса";
            // 
            // QuestionNameTB
            // 
            this.QuestionNameTB.Location = new System.Drawing.Point(109, 17);
            this.QuestionNameTB.Name = "QuestionNameTB";
            this.QuestionNameTB.Size = new System.Drawing.Size(117, 20);
            this.QuestionNameTB.TabIndex = 49;
            // 
            // QuestionCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 459);
            this.Controls.Add(this.QuestionNameLabel);
            this.Controls.Add(this.QuestionNameTB);
            this.Controls.Add(this.QuestionPicturePathChooseButton);
            this.Controls.Add(this.QuestionPicturePathLabel);
            this.Controls.Add(this.QuestionPicturePathTB);
            this.Controls.Add(this.QuestionAnswersLabel);
            this.Controls.Add(this.QuestionAnswersTB);
            this.Controls.Add(this.ImageExampleLabel);
            this.Controls.Add(this.ImageExample);
            this.Controls.Add(this.AddQuestionButton);
            this.Controls.Add(this.QuestionQuestionTextLabel);
            this.Controls.Add(this.QuestionQuestionTextTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "QuestionCreateForm";
            this.Text = "ImageQuestionSetupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionCreateForm_FormClosing);
            this.Load += new System.EventHandler(this.ImageQuestionSetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageExample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddQuestionButton;
        private System.Windows.Forms.Label QuestionQuestionTextLabel;
        private System.Windows.Forms.TextBox QuestionQuestionTextTB;
        private System.Windows.Forms.PictureBox ImageExample;
        private System.Windows.Forms.Label ImageExampleLabel;
        private System.Windows.Forms.OpenFileDialog ImageChooseDialog;
        private System.Windows.Forms.Label QuestionAnswersLabel;
        private System.Windows.Forms.TextBox QuestionAnswersTB;
        private System.Windows.Forms.Button QuestionPicturePathChooseButton;
        private System.Windows.Forms.Label QuestionPicturePathLabel;
        private System.Windows.Forms.TextBox QuestionPicturePathTB;
        protected internal System.Windows.Forms.Label QuestionNameLabel;
        protected internal System.Windows.Forms.TextBox QuestionNameTB;
    }
}