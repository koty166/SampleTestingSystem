namespace Проект_к_школе
{
    partial class ImageQuestionSetupForm
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
            this.components = new System.ComponentModel.Container();
            this.AddImageQuestion = new System.Windows.Forms.Button();
            this.QuestionSetupLabel = new System.Windows.Forms.Label();
            this.QuestionSetup = new System.Windows.Forms.TextBox();
            this.ImageExample = new System.Windows.Forms.PictureBox();
            this.ImageExampleLabel = new System.Windows.Forms.Label();
            this.ImageNameSetup = new System.Windows.Forms.TextBox();
            this.ImageNameLabel = new System.Windows.Forms.Label();
            this.ImageSetupGroupBox = new System.Windows.Forms.GroupBox();
            this.ImageChooseButton = new System.Windows.Forms.Button();
            this.OrLabel = new System.Windows.Forms.Label();
            this.ImageChooseDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImageExample)).BeginInit();
            this.ImageSetupGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddImageQuestion
            // 
            this.AddImageQuestion.Location = new System.Drawing.Point(622, 404);
            this.AddImageQuestion.Name = "AddImageQuestion";
            this.AddImageQuestion.Size = new System.Drawing.Size(135, 25);
            this.AddImageQuestion.TabIndex = 36;
            this.AddImageQuestion.Text = "Добавить";
            this.AddImageQuestion.UseVisualStyleBackColor = true;
            this.AddImageQuestion.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuestionSetupLabel
            // 
            this.QuestionSetupLabel.AutoSize = true;
            this.QuestionSetupLabel.Location = new System.Drawing.Point(12, 34);
            this.QuestionSetupLabel.Name = "QuestionSetupLabel";
            this.QuestionSetupLabel.Size = new System.Drawing.Size(85, 13);
            this.QuestionSetupLabel.TabIndex = 35;
            this.QuestionSetupLabel.Text = "Текст вопроса:";
            // 
            // QuestionSetup
            // 
            this.QuestionSetup.Location = new System.Drawing.Point(106, 31);
            this.QuestionSetup.Name = "QuestionSetup";
            this.QuestionSetup.Size = new System.Drawing.Size(307, 20);
            this.QuestionSetup.TabIndex = 34;
            // 
            // ImageExample
            // 
            this.ImageExample.Location = new System.Drawing.Point(17, 92);
            this.ImageExample.Name = "ImageExample";
            this.ImageExample.Size = new System.Drawing.Size(550, 300);
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
            // ImageNameSetup
            // 
            this.ImageNameSetup.Location = new System.Drawing.Point(9, 53);
            this.ImageNameSetup.Name = "ImageNameSetup";
            this.ImageNameSetup.Size = new System.Drawing.Size(197, 20);
            this.ImageNameSetup.TabIndex = 39;
            this.ImageNameSetup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageNameSetup_KeyDown);
            this.ImageNameSetup.MouseEnter += new System.EventHandler(this.ImageNameSetup_MouseEnter);
            // 
            // ImageNameLabel
            // 
            this.ImageNameLabel.AutoSize = true;
            this.ImageNameLabel.Location = new System.Drawing.Point(6, 26);
            this.ImageNameLabel.Name = "ImageNameLabel";
            this.ImageNameLabel.Size = new System.Drawing.Size(139, 13);
            this.ImageNameLabel.TabIndex = 40;
            this.ImageNameLabel.Text = "Введи название картинки";
            // 
            // ImageSetupGroupBox
            // 
            this.ImageSetupGroupBox.Controls.Add(this.ImageChooseButton);
            this.ImageSetupGroupBox.Controls.Add(this.OrLabel);
            this.ImageSetupGroupBox.Controls.Add(this.ImageNameLabel);
            this.ImageSetupGroupBox.Controls.Add(this.ImageNameSetup);
            this.ImageSetupGroupBox.Location = new System.Drawing.Point(576, 66);
            this.ImageSetupGroupBox.Name = "ImageSetupGroupBox";
            this.ImageSetupGroupBox.Size = new System.Drawing.Size(219, 176);
            this.ImageSetupGroupBox.TabIndex = 41;
            this.ImageSetupGroupBox.TabStop = false;
            // 
            // ImageChooseButton
            // 
            this.ImageChooseButton.Location = new System.Drawing.Point(9, 132);
            this.ImageChooseButton.Name = "ImageChooseButton";
            this.ImageChooseButton.Size = new System.Drawing.Size(113, 23);
            this.ImageChooseButton.TabIndex = 42;
            this.ImageChooseButton.Text = "Выбери картинку";
            this.ImageChooseButton.UseVisualStyleBackColor = true;
            this.ImageChooseButton.Click += new System.EventHandler(this.ImageChooseButton_Click);
            // 
            // OrLabel
            // 
            this.OrLabel.AutoSize = true;
            this.OrLabel.Location = new System.Drawing.Point(6, 101);
            this.OrLabel.Name = "OrLabel";
            this.OrLabel.Size = new System.Drawing.Size(27, 13);
            this.OrLabel.TabIndex = 41;
            this.OrLabel.Text = "Или";
            // 
            // ImageChooseDialog
            // 
            this.ImageChooseDialog.FileName = "openFileDialog1";
            this.ImageChooseDialog.Filter = "PNG |*.png| Все файлы |*.*";
            this.ImageChooseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImageChooseDialog_FileOk);
            // 
            // ImageQuestionSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImageSetupGroupBox);
            this.Controls.Add(this.ImageExampleLabel);
            this.Controls.Add(this.ImageExample);
            this.Controls.Add(this.AddImageQuestion);
            this.Controls.Add(this.QuestionSetupLabel);
            this.Controls.Add(this.QuestionSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "ImageQuestionSetupForm";
            this.Text = "ImageQuestionSetupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageQuestionSetupForm_FormClosing);
            this.Load += new System.EventHandler(this.ImageQuestionSetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageExample)).EndInit();
            this.ImageSetupGroupBox.ResumeLayout(false);
            this.ImageSetupGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddImageQuestion;
        private System.Windows.Forms.Label QuestionSetupLabel;
        private System.Windows.Forms.TextBox QuestionSetup;
        private System.Windows.Forms.PictureBox ImageExample;
        private System.Windows.Forms.Label ImageExampleLabel;
        private System.Windows.Forms.TextBox ImageNameSetup;
        private System.Windows.Forms.Label ImageNameLabel;
        private System.Windows.Forms.GroupBox ImageSetupGroupBox;
        private System.Windows.Forms.Button ImageChooseButton;
        private System.Windows.Forms.Label OrLabel;
        private System.Windows.Forms.OpenFileDialog ImageChooseDialog;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}