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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PupilsPackgesNumber = new System.Windows.Forms.Label();
            this.ShowOnExel = new System.Windows.Forms.Button();
            this.Statistic = new System.Windows.Forms.GroupBox();
            this.GetingDataStatistic = new System.Windows.Forms.Label();
            this.SendingIPStatisticLabel = new System.Windows.Forms.Label();
            this.TryConeectionStatisticLabel = new System.Windows.Forms.Label();
            this.SendingIPGroupbox = new System.Windows.Forms.GroupBox();
            this.LabelNumPackages = new System.Windows.Forms.Label();
            this.IPSetup = new System.Windows.Forms.TextBox();
            this.NumPackagesSetup = new System.Windows.Forms.NumericUpDown();
            this.IsDefaulIP = new System.Windows.Forms.CheckBox();
            this.SendingIPStart = new System.Windows.Forms.Button();
            this.ListeningDataGroupBox = new System.Windows.Forms.GroupBox();
            this.LabelNumPupils = new System.Windows.Forms.Label();
            this.NumOfPupils = new System.Windows.Forms.NumericUpDown();
            this.ListenStart = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FromTxt = new System.Windows.Forms.Button();
            this.BeginAnalysis = new System.Windows.Forms.Button();
            this.FileSetupButton = new System.Windows.Forms.Button();
            this.FileSetup = new System.Windows.Forms.TextBox();
            this.TypeOfAnalisLabel = new System.Windows.Forms.Label();
            this.TypeOfAnalis = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.IsListenAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.IsSendingAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Statistic.SuspendLayout();
            this.SendingIPGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPackagesSetup)).BeginInit();
            this.ListeningDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfPupils)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(538, 390);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PupilsPackgesNumber);
            this.tabPage1.Controls.Add(this.ShowOnExel);
            this.tabPage1.Controls.Add(this.Statistic);
            this.tabPage1.Controls.Add(this.SendingIPGroupbox);
            this.tabPage1.Controls.Add(this.ListeningDataGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(530, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки сервера";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PupilsPackgesNumber
            // 
            this.PupilsPackgesNumber.AutoSize = true;
            this.PupilsPackgesNumber.Location = new System.Drawing.Point(197, 273);
            this.PupilsPackgesNumber.Name = "PupilsPackgesNumber";
            this.PupilsPackgesNumber.Size = new System.Drawing.Size(105, 13);
            this.PupilsPackgesNumber.TabIndex = 10;
            this.PupilsPackgesNumber.Text = "Данных полученно:";
            // 
            // ShowOnExel
            // 
            this.ShowOnExel.Location = new System.Drawing.Point(21, 265);
            this.ShowOnExel.Name = "ShowOnExel";
            this.ShowOnExel.Size = new System.Drawing.Size(147, 36);
            this.ShowOnExel.TabIndex = 9;
            this.ShowOnExel.Text = "Отобразить в Exel";
            this.ShowOnExel.UseVisualStyleBackColor = true;
            this.ShowOnExel.Click += new System.EventHandler(this.ShowOnExel_Click);
            // 
            // Statistic
            // 
            this.Statistic.Controls.Add(this.GetingDataStatistic);
            this.Statistic.Controls.Add(this.SendingIPStatisticLabel);
            this.Statistic.Controls.Add(this.TryConeectionStatisticLabel);
            this.Statistic.Location = new System.Drawing.Point(8, 15);
            this.Statistic.Name = "Statistic";
            this.Statistic.Size = new System.Drawing.Size(472, 50);
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
            this.SendingIPStatisticLabel.Location = new System.Drawing.Point(108, 16);
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
            // SendingIPGroupbox
            // 
            this.SendingIPGroupbox.Controls.Add(this.LabelNumPackages);
            this.SendingIPGroupbox.Controls.Add(this.IPSetup);
            this.SendingIPGroupbox.Controls.Add(this.NumPackagesSetup);
            this.SendingIPGroupbox.Controls.Add(this.IsDefaulIP);
            this.SendingIPGroupbox.Controls.Add(this.SendingIPStart);
            this.SendingIPGroupbox.Location = new System.Drawing.Point(8, 71);
            this.SendingIPGroupbox.Name = "SendingIPGroupbox";
            this.SendingIPGroupbox.Size = new System.Drawing.Size(472, 77);
            this.SendingIPGroupbox.TabIndex = 7;
            this.SendingIPGroupbox.TabStop = false;
            this.SendingIPGroupbox.Text = "Отправка IP";
            // 
            // LabelNumPackages
            // 
            this.LabelNumPackages.AutoSize = true;
            this.LabelNumPackages.Location = new System.Drawing.Point(307, 12);
            this.LabelNumPackages.Name = "LabelNumPackages";
            this.LabelNumPackages.Size = new System.Drawing.Size(142, 13);
            this.LabelNumPackages.TabIndex = 4;
            this.LabelNumPackages.Text = "Колл-во отправок (1 в сек)";
            // 
            // IPSetup
            // 
            this.IPSetup.Location = new System.Drawing.Point(174, 39);
            this.IPSetup.Name = "IPSetup";
            this.IPSetup.Size = new System.Drawing.Size(114, 20);
            this.IPSetup.TabIndex = 6;
            this.IPSetup.Visible = false;
            // 
            // NumPackagesSetup
            // 
            this.NumPackagesSetup.Location = new System.Drawing.Point(310, 39);
            this.NumPackagesSetup.Name = "NumPackagesSetup";
            this.NumPackagesSetup.Size = new System.Drawing.Size(120, 20);
            this.NumPackagesSetup.TabIndex = 3;
            this.NumPackagesSetup.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // IsDefaulIP
            // 
            this.IsDefaulIP.AutoSize = true;
            this.IsDefaulIP.Location = new System.Drawing.Point(174, 11);
            this.IsDefaulIP.Name = "IsDefaulIP";
            this.IsDefaulIP.Size = new System.Drawing.Size(119, 17);
            this.IsDefaulIP.TabIndex = 5;
            this.IsDefaulIP.Text = "Ввести IP вручную";
            this.IsDefaulIP.UseVisualStyleBackColor = true;
            // 
            // SendingIPStart
            // 
            this.SendingIPStart.Location = new System.Drawing.Point(7, 28);
            this.SendingIPStart.Name = "SendingIPStart";
            this.SendingIPStart.Size = new System.Drawing.Size(161, 31);
            this.SendingIPStart.TabIndex = 4;
            this.SendingIPStart.Text = "Начать рассылку";
            this.SendingIPStart.UseVisualStyleBackColor = true;
            this.SendingIPStart.Click += new System.EventHandler(this.SendingIPStart_Click);
            // 
            // ListeningDataGroupBox
            // 
            this.ListeningDataGroupBox.Controls.Add(this.LabelNumPupils);
            this.ListeningDataGroupBox.Controls.Add(this.NumOfPupils);
            this.ListeningDataGroupBox.Controls.Add(this.ListenStart);
            this.ListeningDataGroupBox.Location = new System.Drawing.Point(6, 154);
            this.ListeningDataGroupBox.Name = "ListeningDataGroupBox";
            this.ListeningDataGroupBox.Size = new System.Drawing.Size(474, 78);
            this.ListeningDataGroupBox.TabIndex = 3;
            this.ListeningDataGroupBox.TabStop = false;
            this.ListeningDataGroupBox.Text = "Получение данных";
            // 
            // LabelNumPupils
            // 
            this.LabelNumPupils.AutoSize = true;
            this.LabelNumPupils.Location = new System.Drawing.Point(182, 22);
            this.LabelNumPupils.Name = "LabelNumPupils";
            this.LabelNumPupils.Size = new System.Drawing.Size(96, 13);
            this.LabelNumPupils.TabIndex = 2;
            this.LabelNumPupils.Text = "Колл-во учеников";
            // 
            // NumOfPupils
            // 
            this.NumOfPupils.Location = new System.Drawing.Point(295, 20);
            this.NumOfPupils.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumOfPupils.Name = "NumOfPupils";
            this.NumOfPupils.Size = new System.Drawing.Size(120, 20);
            this.NumOfPupils.TabIndex = 1;
            this.NumOfPupils.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ListenStart
            // 
            this.ListenStart.Location = new System.Drawing.Point(15, 16);
            this.ListenStart.Name = "ListenStart";
            this.ListenStart.Size = new System.Drawing.Size(161, 35);
            this.ListenStart.TabIndex = 0;
            this.ListenStart.Text = "Начать ожидание данных";
            this.ListenStart.UseVisualStyleBackColor = true;
            this.ListenStart.Click += new System.EventHandler(this.ListenStart_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FromTxt);
            this.tabPage2.Controls.Add(this.BeginAnalysis);
            this.tabPage2.Controls.Add(this.FileSetupButton);
            this.tabPage2.Controls.Add(this.FileSetup);
            this.tabPage2.Controls.Add(this.TypeOfAnalisLabel);
            this.tabPage2.Controls.Add(this.TypeOfAnalis);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(530, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Анализ данных";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FromTxt
            // 
            this.FromTxt.Location = new System.Drawing.Point(14, 194);
            this.FromTxt.Name = "FromTxt";
            this.FromTxt.Size = new System.Drawing.Size(103, 52);
            this.FromTxt.TabIndex = 5;
            this.FromTxt.Text = "из txt";
            this.FromTxt.UseVisualStyleBackColor = true;
            this.FromTxt.Click += new System.EventHandler(this.FromTxt_Click);
            // 
            // BeginAnalysis
            // 
            this.BeginAnalysis.Location = new System.Drawing.Point(260, 102);
            this.BeginAnalysis.Name = "BeginAnalysis";
            this.BeginAnalysis.Size = new System.Drawing.Size(122, 39);
            this.BeginAnalysis.TabIndex = 4;
            this.BeginAnalysis.Text = "Выполнить анализ";
            this.BeginAnalysis.UseVisualStyleBackColor = true;
            this.BeginAnalysis.Click += new System.EventHandler(this.BeginAnalysis_Click);
            // 
            // FileSetupButton
            // 
            this.FileSetupButton.Location = new System.Drawing.Point(255, 50);
            this.FileSetupButton.Name = "FileSetupButton";
            this.FileSetupButton.Size = new System.Drawing.Size(128, 30);
            this.FileSetupButton.TabIndex = 3;
            this.FileSetupButton.Text = "Выбери файл";
            this.FileSetupButton.UseVisualStyleBackColor = true;
            this.FileSetupButton.Click += new System.EventHandler(this.FileSetupButton_Click);
            // 
            // FileSetup
            // 
            this.FileSetup.Location = new System.Drawing.Point(400, 56);
            this.FileSetup.Name = "FileSetup";
            this.FileSetup.ReadOnly = true;
            this.FileSetup.Size = new System.Drawing.Size(120, 20);
            this.FileSetup.TabIndex = 2;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 368);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(538, 22);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Saved data files|*.sav";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 390);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormServer";
            this.Text = "Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
            this.Load += new System.EventHandler(this.FormServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Statistic.ResumeLayout(false);
            this.Statistic.PerformLayout();
            this.SendingIPGroupbox.ResumeLayout(false);
            this.SendingIPGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPackagesSetup)).EndInit();
            this.ListeningDataGroupBox.ResumeLayout(false);
            this.ListeningDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfPupils)).EndInit();
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
        private System.Windows.Forms.GroupBox SendingIPGroupbox;
        private System.Windows.Forms.Label LabelNumPackages;
        private System.Windows.Forms.TextBox IPSetup;
        private System.Windows.Forms.NumericUpDown NumPackagesSetup;
        private System.Windows.Forms.CheckBox IsDefaulIP;
        private System.Windows.Forms.Button SendingIPStart;
        private System.Windows.Forms.GroupBox ListeningDataGroupBox;
        private System.Windows.Forms.Label LabelNumPupils;
        private System.Windows.Forms.NumericUpDown NumOfPupils;
        private System.Windows.Forms.Button ListenStart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox Statistic;
        private System.Windows.Forms.Label GetingDataStatistic;
        private System.Windows.Forms.Label SendingIPStatisticLabel;
        private System.Windows.Forms.Label TryConeectionStatisticLabel;
        private System.Windows.Forms.Button FileSetupButton;
        private System.Windows.Forms.TextBox FileSetup;
        private System.Windows.Forms.Label TypeOfAnalisLabel;
        private System.Windows.Forms.ListBox TypeOfAnalis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel IsListenAlive;
        private System.Windows.Forms.ToolStripStatusLabel IsSendingAlive;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label PupilsPackgesNumber;
        private System.Windows.Forms.Button ShowOnExel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BeginAnalysis;
        private System.Windows.Forms.Button FromTxt;
    }
}

