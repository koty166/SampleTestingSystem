namespace FormServer
{
    partial class FormServer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PupilsPackgesNumber = new System.Windows.Forms.Label();
            this.Statistic = new System.Windows.Forms.GroupBox();
            this.GetingDataStatistic = new System.Windows.Forms.Label();
            this.SendingIPStatisticLabel = new System.Windows.Forms.Label();
            this.TryConeectionStatisticLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BeginAnalysis = new System.Windows.Forms.Button();
            this.TypeOfAnalisLabel = new System.Windows.Forms.Label();
            this.TypeOfAnalis = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.IsListenAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.IsSendingAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileSetup = new System.Windows.Forms.TextBox();
            this.FileSetupButton = new System.Windows.Forms.Button();
            this.AddData = new System.Windows.Forms.Button();
            this.AnaliseDataLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Statistic.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 228);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Statistic);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки сервера";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PupilsPackgesNumber
            // 
            this.PupilsPackgesNumber.AutoSize = true;
            this.PupilsPackgesNumber.Location = new System.Drawing.Point(6, 49);
            this.PupilsPackgesNumber.Name = "PupilsPackgesNumber";
            this.PupilsPackgesNumber.Size = new System.Drawing.Size(105, 13);
            this.PupilsPackgesNumber.TabIndex = 10;
            this.PupilsPackgesNumber.Text = "Данных полученно:";
            // 
            // Statistic
            // 
            this.Statistic.Controls.Add(this.PupilsPackgesNumber);
            this.Statistic.Controls.Add(this.GetingDataStatistic);
            this.Statistic.Controls.Add(this.SendingIPStatisticLabel);
            this.Statistic.Controls.Add(this.TryConeectionStatisticLabel);
            this.Statistic.Location = new System.Drawing.Point(8, 15);
            this.Statistic.Name = "Statistic";
            this.Statistic.Size = new System.Drawing.Size(472, 97);
            this.Statistic.TabIndex = 8;
            this.Statistic.TabStop = false;
            this.Statistic.Text = "Статистика";
            // 
            // GetingDataStatistic
            // 
            this.GetingDataStatistic.AutoSize = true;
            this.GetingDataStatistic.Location = new System.Drawing.Point(290, 16);
            this.GetingDataStatistic.Name = "GetingDataStatistic";
            this.GetingDataStatistic.Size = new System.Drawing.Size(153, 13);
            this.GetingDataStatistic.TabIndex = 2;
            this.GetingDataStatistic.Text = "Полученно данных учеников:";
            // 
            // SendingIPStatisticLabel
            // 
            this.SendingIPStatisticLabel.AutoSize = true;
            this.SendingIPStatisticLabel.Location = new System.Drawing.Point(110, 16);
            this.SendingIPStatisticLabel.Name = "SendingIPStatisticLabel";
            this.SendingIPStatisticLabel.Size = new System.Drawing.Size(140, 13);
            this.SendingIPStatisticLabel.TabIndex = 1;
            this.SendingIPStatisticLabel.Text = "Отправленно IP - пакетов:";
            // 
            // TryConeectionStatisticLabel
            // 
            this.TryConeectionStatisticLabel.AutoSize = true;
            this.TryConeectionStatisticLabel.Location = new System.Drawing.Point(6, 16);
            this.TryConeectionStatisticLabel.Name = "TryConeectionStatisticLabel";
            this.TryConeectionStatisticLabel.Size = new System.Drawing.Size(73, 13);
            this.TryConeectionStatisticLabel.TabIndex = 0;
            this.TryConeectionStatisticLabel.Text = "Проверок IP:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AnaliseDataLabel);
            this.tabPage2.Controls.Add(this.AddData);
            this.tabPage2.Controls.Add(this.FileSetupButton);
            this.tabPage2.Controls.Add(this.FileSetup);
            this.tabPage2.Controls.Add(this.BeginAnalysis);
            this.tabPage2.Controls.Add(this.TypeOfAnalisLabel);
            this.tabPage2.Controls.Add(this.TypeOfAnalis);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 202);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Анализ данных";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BeginAnalysis
            // 
            this.BeginAnalysis.Location = new System.Drawing.Point(345, 142);
            this.BeginAnalysis.Name = "BeginAnalysis";
            this.BeginAnalysis.Size = new System.Drawing.Size(122, 39);
            this.BeginAnalysis.TabIndex = 4;
            this.BeginAnalysis.Text = "Выполнить анализ";
            this.BeginAnalysis.UseVisualStyleBackColor = true;
            this.BeginAnalysis.Click += new System.EventHandler(this.BeginAnalysis_Click);
            // 
            // TypeOfAnalisLabel
            // 
            this.TypeOfAnalisLabel.AutoSize = true;
            this.TypeOfAnalisLabel.Location = new System.Drawing.Point(11, 21);
            this.TypeOfAnalisLabel.Name = "TypeOfAnalisLabel";
            this.TypeOfAnalisLabel.Size = new System.Drawing.Size(136, 13);
            this.TypeOfAnalisLabel.TabIndex = 1;
            this.TypeOfAnalisLabel.Text = "Выберите тип обработки:";
            // 
            // TypeOfAnalis
            // 
            this.TypeOfAnalis.FormattingEnabled = true;
            this.TypeOfAnalis.Items.AddRange(new object[] {
            "Бланк мотивации",
            "ШТУР",
            "Отобразить в Exel"});
            this.TypeOfAnalis.Location = new System.Drawing.Point(8, 50);
            this.TypeOfAnalis.Name = "TypeOfAnalis";
            this.TypeOfAnalis.Size = new System.Drawing.Size(142, 108);
            this.TypeOfAnalis.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IsListenAlive,
            this.IsSendingAlive});
            this.statusStrip1.Location = new System.Drawing.Point(0, 206);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // IsListenAlive
            // 
            this.IsListenAlive.Name = "IsListenAlive";
            this.IsListenAlive.Size = new System.Drawing.Size(0, 17);
            // 
            // IsSendingAlive
            // 
            this.IsSendingAlive.Name = "IsSendingAlive";
            this.IsSendingAlive.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Saved data files|*.sav";
            // 
            // FileSetup
            // 
            this.FileSetup.Location = new System.Drawing.Point(310, 30);
            this.FileSetup.Name = "FileSetup";
            this.FileSetup.ReadOnly = true;
            this.FileSetup.Size = new System.Drawing.Size(120, 20);
            this.FileSetup.TabIndex = 2;
            // 
            // FileSetupButton
            // 
            this.FileSetupButton.Location = new System.Drawing.Point(436, 30);
            this.FileSetupButton.Name = "FileSetupButton";
            this.FileSetupButton.Size = new System.Drawing.Size(31, 21);
            this.FileSetupButton.TabIndex = 3;
            this.FileSetupButton.Text = "...";
            this.FileSetupButton.UseVisualStyleBackColor = true;
            this.FileSetupButton.Click += new System.EventHandler(this.FileSetupButton_Click);
            // 
            // AddData
            // 
            this.AddData.Location = new System.Drawing.Point(197, 27);
            this.AddData.Name = "AddData";
            this.AddData.Size = new System.Drawing.Size(107, 24);
            this.AddData.TabIndex = 5;
            this.AddData.Text = "Добавить данные";
            this.AddData.UseVisualStyleBackColor = true;
            this.AddData.Click += new System.EventHandler(this.AddData_Click);
            // 
            // AnaliseDataLabel
            // 
            this.AnaliseDataLabel.AutoSize = true;
            this.AnaliseDataLabel.Location = new System.Drawing.Point(341, 116);
            this.AnaliseDataLabel.Name = "AnaliseDataLabel";
            this.AnaliseDataLabel.Size = new System.Drawing.Size(116, 13);
            this.AnaliseDataLabel.TabIndex = 7;
            this.AnaliseDataLabel.Text = "Данных для анализа:";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 228);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormServer";
            this.Text = "Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Statistic.ResumeLayout(false);
            this.Statistic.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox Statistic;
        private System.Windows.Forms.Label GetingDataStatistic;
        private System.Windows.Forms.Label SendingIPStatisticLabel;
        private System.Windows.Forms.Label TryConeectionStatisticLabel;
        private System.Windows.Forms.Label TypeOfAnalisLabel;
        private System.Windows.Forms.ListBox TypeOfAnalis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel IsListenAlive;
        private System.Windows.Forms.ToolStripStatusLabel IsSendingAlive;
        private System.Windows.Forms.Label PupilsPackgesNumber;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BeginAnalysis;
        private System.Windows.Forms.Button FileSetupButton;
        private System.Windows.Forms.TextBox FileSetup;
        private System.Windows.Forms.Label AnaliseDataLabel;
        private System.Windows.Forms.Button AddData;
    }
}

