namespace Проект_к_школе
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.TestsLB = new System.Windows.Forms.ListBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.AnswerTextTB = new System.Windows.Forms.TextBox();
            this.QuestionStr = new System.Windows.Forms.Label();
            this.Picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Transparent;
            this.StartButton.Location = new System.Drawing.Point(228, 205);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(85, 21);
            this.StartButton.TabIndex = 29;
            this.StartButton.Text = "Начать";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.BackColor = System.Drawing.Color.Transparent;
            this.QuestionLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.QuestionLabel.Location = new System.Drawing.Point(25, 26);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(0, 13);
            this.QuestionLabel.TabIndex = 27;
            // 
            // TestsLB
            // 
            this.TestsLB.FormattingEnabled = true;
            this.TestsLB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TestsLB.Location = new System.Drawing.Point(137, 134);
            this.TestsLB.Name = "TestsLB";
            this.TestsLB.Size = new System.Drawing.Size(294, 56);
            this.TestsLB.TabIndex = 25;
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.Transparent;
            this.NextButton.Location = new System.Drawing.Point(250, 250);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(86, 20);
            this.NextButton.TabIndex = 24;
            this.NextButton.Text = "Далее";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.Next_Click);
            // 
            // AnswerTextTB
            // 
            this.AnswerTextTB.Location = new System.Drawing.Point(25, 357);
            this.AnswerTextTB.Name = "AnswerTextTB";
            this.AnswerTextTB.Size = new System.Drawing.Size(350, 20);
            this.AnswerTextTB.TabIndex = 23;
            this.AnswerTextTB.Visible = false;
            // 
            // QuestionStr
            // 
            this.QuestionStr.AutoSize = true;
            this.QuestionStr.BackColor = System.Drawing.Color.Transparent;
            this.QuestionStr.Location = new System.Drawing.Point(31, 26);
            this.QuestionStr.Name = "QuestionStr";
            this.QuestionStr.Size = new System.Drawing.Size(35, 13);
            this.QuestionStr.TabIndex = 30;
            this.QuestionStr.Text = "label1";
            this.QuestionStr.Visible = false;
            // 
            // Picture
            // 
            this.Picture.Location = new System.Drawing.Point(25, 45);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(600, 300);
            this.Picture.TabIndex = 31;
            this.Picture.TabStop = false;
            this.Picture.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(664, 418);
            this.Controls.Add(this.QuestionStr);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.TestsLB);
            this.Controls.Add(this.AnswerTextTB);
            this.Controls.Add(this.Picture);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестовая система";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.ListBox TestsLB;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.TextBox AnswerTextTB;
        private System.Windows.Forms.Label QuestionStr;
        private System.Windows.Forms.PictureBox Picture;
    }
}

