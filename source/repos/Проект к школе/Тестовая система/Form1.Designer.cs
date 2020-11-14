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
            this.AnswerTextSetup = new System.Windows.Forms.TextBox();
            this.QuestionPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPB)).BeginInit();
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
            // AnswerTextSetup
            // 
            this.AnswerTextSetup.Location = new System.Drawing.Point(25, 350);
            this.AnswerTextSetup.Name = "AnswerTextSetup";
            this.AnswerTextSetup.Size = new System.Drawing.Size(350, 20);
            this.AnswerTextSetup.TabIndex = 23;
            this.AnswerTextSetup.Visible = false;
            // 
            // QuestionPB
            // 
            this.QuestionPB.BackColor = System.Drawing.Color.Transparent;
            this.QuestionPB.Location = new System.Drawing.Point(25, 43);
            this.QuestionPB.Name = "QuestionPB";
            this.QuestionPB.Size = new System.Drawing.Size(550, 300);
            this.QuestionPB.TabIndex = 28;
            this.QuestionPB.TabStop = false;
            this.QuestionPB.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(597, 418);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.TestsLB);
            this.Controls.Add(this.AnswerTextSetup);
            this.Controls.Add(this.QuestionPB);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестовая система";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.ListBox TestsLB;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.TextBox AnswerTextSetup;
        private System.Windows.Forms.PictureBox QuestionPB;
    }
}

