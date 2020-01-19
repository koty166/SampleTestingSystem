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
            this.LessonChooseLabel = new System.Windows.Forms.Label();
            this.FromTxt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.работаСУрокамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слияниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьУрокToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьУрокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСЗаданиямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПростойВопросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПростойВопросToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВопросСКартинкойToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ChooseQuestionLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.FirstLessonLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionChoose
            // 
            this.QuestionChoose.Location = new System.Drawing.Point(12, 41);
            this.QuestionChoose.Name = "QuestionChoose";
            this.QuestionChoose.Scrollable = false;
            this.QuestionChoose.ShowRootLines = false;
            this.QuestionChoose.Size = new System.Drawing.Size(268, 433);
            this.QuestionChoose.TabIndex = 11;
            this.QuestionChoose.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.QuestionChoose_AfterSelect);
            // 
            // LessonChoose
            // 
            this.LessonChoose.FormattingEnabled = true;
            this.LessonChoose.Location = new System.Drawing.Point(286, 41);
            this.LessonChoose.Name = "LessonChoose";
            this.LessonChoose.Size = new System.Drawing.Size(232, 147);
            this.LessonChoose.TabIndex = 12;
            this.LessonChoose.SelectedIndexChanged += new System.EventHandler(this.LessonChoose_SelectedIndexChanged);
            // 
            // LessonChooseLabel
            // 
            this.LessonChooseLabel.AutoSize = true;
            this.LessonChooseLabel.Location = new System.Drawing.Point(286, 25);
            this.LessonChooseLabel.Name = "LessonChooseLabel";
            this.LessonChooseLabel.Size = new System.Drawing.Size(101, 13);
            this.LessonChooseLabel.TabIndex = 17;
            this.LessonChooseLabel.Text = "Выбери урок ниже";
            // 
            // FromTxt
            // 
            this.FromTxt.Location = new System.Drawing.Point(286, 461);
            this.FromTxt.Name = "FromTxt";
            this.FromTxt.Size = new System.Drawing.Size(77, 31);
            this.FromTxt.TabIndex = 21;
            this.FromTxt.Text = "FromTxt";
            this.FromTxt.UseVisualStyleBackColor = true;
            this.FromTxt.Visible = false;
            this.FromTxt.Click += new System.EventHandler(this.FromTxt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.работаСУрокамиToolStripMenuItem,
            this.работаСЗаданиямиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // работаСУрокамиToolStripMenuItem
            // 
            this.работаСУрокамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.слияниеToolStripMenuItem,
            this.toolStripSeparator2,
            this.добавитьУрокToolStripMenuItem1,
            this.изменитьУрокToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.работаСУрокамиToolStripMenuItem.Name = "работаСУрокамиToolStripMenuItem";
            this.работаСУрокамиToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.работаСУрокамиToolStripMenuItem.Text = "Работа с уроками";
            // 
            // слияниеToolStripMenuItem
            // 
            this.слияниеToolStripMenuItem.Name = "слияниеToolStripMenuItem";
            this.слияниеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.слияниеToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.слияниеToolStripMenuItem.Text = "Слить";
            this.слияниеToolStripMenuItem.Click += new System.EventHandler(this.слияниеToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // добавитьУрокToolStripMenuItem1
            // 
            this.добавитьУрокToolStripMenuItem1.Name = "добавитьУрокToolStripMenuItem1";
            this.добавитьУрокToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.добавитьУрокToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.добавитьУрокToolStripMenuItem1.Text = "Добавить урок";
            this.добавитьУрокToolStripMenuItem1.Click += new System.EventHandler(this.добавитьУрокToolStripMenuItem1_Click);
            // 
            // изменитьУрокToolStripMenuItem
            // 
            this.изменитьУрокToolStripMenuItem.Name = "изменитьУрокToolStripMenuItem";
            this.изменитьУрокToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.изменитьУрокToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.изменитьУрокToolStripMenuItem.Text = "Изменить урок";
            this.изменитьУрокToolStripMenuItem.Click += new System.EventHandler(this.изменитьУрокToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // работаСЗаданиямиToolStripMenuItem
            // 
            this.работаСЗаданиямиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПростойВопросToolStripMenuItem,
            this.добавитьПростойВопросToolStripMenuItem1,
            this.добавитьВопросСКартинкойToolStripMenuItem1,
            this.toolStripSeparator1,
            this.удалитьToolStripMenuItem1});
            this.работаСЗаданиямиToolStripMenuItem.Name = "работаСЗаданиямиToolStripMenuItem";
            this.работаСЗаданиямиToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.работаСЗаданиямиToolStripMenuItem.Text = "Работа с заданиями";
            // 
            // добавитьПростойВопросToolStripMenuItem
            // 
            this.добавитьПростойВопросToolStripMenuItem.Name = "добавитьПростойВопросToolStripMenuItem";
            this.добавитьПростойВопросToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.добавитьПростойВопросToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.добавитьПростойВопросToolStripMenuItem.Text = "Добавить инструктаж";
            this.добавитьПростойВопросToolStripMenuItem.Click += new System.EventHandler(this.добавитьИнструктажToolStripMenuItem_Click);
            // 
            // добавитьПростойВопросToolStripMenuItem1
            // 
            this.добавитьПростойВопросToolStripMenuItem1.Name = "добавитьПростойВопросToolStripMenuItem1";
            this.добавитьПростойВопросToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.добавитьПростойВопросToolStripMenuItem1.Size = new System.Drawing.Size(279, 22);
            this.добавитьПростойВопросToolStripMenuItem1.Text = "Добавить простой вопрос";
            this.добавитьПростойВопросToolStripMenuItem1.Click += new System.EventHandler(this.добавитьПростойВопросToolStripMenuItem1_Click);
            // 
            // добавитьВопросСКартинкойToolStripMenuItem1
            // 
            this.добавитьВопросСКартинкойToolStripMenuItem1.Name = "добавитьВопросСКартинкойToolStripMenuItem1";
            this.добавитьВопросСКартинкойToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.добавитьВопросСКартинкойToolStripMenuItem1.Size = new System.Drawing.Size(279, 22);
            this.добавитьВопросСКартинкойToolStripMenuItem1.Text = "Добавить вопрос с картинкой";
            this.добавитьВопросСКартинкойToolStripMenuItem1.Click += new System.EventHandler(this.добавитьВопросСКартинкойToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(276, 6);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(279, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // ChooseQuestionLabel
            // 
            this.ChooseQuestionLabel.AutoSize = true;
            this.ChooseQuestionLabel.Location = new System.Drawing.Point(12, 25);
            this.ChooseQuestionLabel.Name = "ChooseQuestionLabel";
            this.ChooseQuestionLabel.Size = new System.Drawing.Size(120, 13);
            this.ChooseQuestionLabel.TabIndex = 31;
            this.ChooseQuestionLabel.Text = "Выбери задание ниже";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstLessonLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(536, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FirstLessonLabel
            // 
            this.FirstLessonLabel.Name = "FirstLessonLabel";
            this.FirstLessonLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // FormWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 499);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ChooseQuestionLabel);
            this.Controls.Add(this.FromTxt);
            this.Controls.Add(this.LessonChooseLabel);
            this.Controls.Add(this.LessonChoose);
            this.Controls.Add(this.QuestionChoose);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormWriter";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView QuestionChoose;
        private System.Windows.Forms.ListBox LessonChoose;
        private System.Windows.Forms.Label LessonChooseLabel;
        private System.Windows.Forms.Button FromTxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem работаСУрокамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слияниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСЗаданиямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПростойВопросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВопросСКартинкойToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem добавитьУрокToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьПростойВопросToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem изменитьУрокToolStripMenuItem;
        private System.Windows.Forms.Label ChooseQuestionLabel;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel FirstLessonLabel;
    }
}

