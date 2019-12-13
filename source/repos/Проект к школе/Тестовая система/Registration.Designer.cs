namespace Проект_к_школе
{
    partial class Registration
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
            this.RegistrationText = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.FormLabel = new System.Windows.Forms.Label();
            this.Patronymic = new System.Windows.Forms.Label();
            this.Surname = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.Label();
            this.FormSetup = new System.Windows.Forms.NumericUpDown();
            this.SurnameSetup = new System.Windows.Forms.TextBox();
            this.PatronymicSetup = new System.Windows.Forms.TextBox();
            this.NameSetup = new System.Windows.Forms.TextBox();
            this.IsMale = new System.Windows.Forms.RadioButton();
            this.IsFemale = new System.Windows.Forms.RadioButton();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.AgeSetup = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.FormSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgeSetup)).BeginInit();
            this.SuspendLayout();
            // 
            // RegistrationText
            // 
            this.RegistrationText.AutoSize = true;
            this.RegistrationText.Location = new System.Drawing.Point(72, 9);
            this.RegistrationText.Name = "RegistrationText";
            this.RegistrationText.Size = new System.Drawing.Size(159, 13);
            this.RegistrationText.TabIndex = 24;
            this.RegistrationText.Text = "Пожалуйста зарегестрируйся";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(75, 275);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(125, 56);
            this.Save.TabIndex = 23;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // FormLabel
            // 
            this.FormLabel.AutoSize = true;
            this.FormLabel.Location = new System.Drawing.Point(13, 171);
            this.FormLabel.Name = "FormLabel";
            this.FormLabel.Size = new System.Drawing.Size(38, 13);
            this.FormLabel.TabIndex = 22;
            this.FormLabel.Text = "Класс";
            // 
            // Patronymic
            // 
            this.Patronymic.AutoSize = true;
            this.Patronymic.Location = new System.Drawing.Point(13, 139);
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.Size = new System.Drawing.Size(54, 13);
            this.Patronymic.TabIndex = 20;
            this.Patronymic.Text = "Отчество";
            // 
            // Surname
            // 
            this.Surname.AutoSize = true;
            this.Surname.Location = new System.Drawing.Point(13, 94);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(56, 13);
            this.Surname.TabIndex = 19;
            this.Surname.Text = "Фамилия";
            // 
            // StudentName
            // 
            this.StudentName.AutoSize = true;
            this.StudentName.Location = new System.Drawing.Point(13, 43);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(29, 13);
            this.StudentName.TabIndex = 18;
            this.StudentName.Text = "Имя";
            // 
            // FormSetup
            // 
            this.FormSetup.Location = new System.Drawing.Point(134, 164);
            this.FormSetup.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.FormSetup.Name = "FormSetup";
            this.FormSetup.Size = new System.Drawing.Size(120, 20);
            this.FormSetup.TabIndex = 5;
            // 
            // SurnameSetup
            // 
            this.SurnameSetup.Location = new System.Drawing.Point(134, 87);
            this.SurnameSetup.Name = "SurnameSetup";
            this.SurnameSetup.Size = new System.Drawing.Size(161, 20);
            this.SurnameSetup.TabIndex = 2;
            // 
            // PatronymicSetup
            // 
            this.PatronymicSetup.Location = new System.Drawing.Point(134, 132);
            this.PatronymicSetup.Name = "PatronymicSetup";
            this.PatronymicSetup.Size = new System.Drawing.Size(161, 20);
            this.PatronymicSetup.TabIndex = 3;
            // 
            // NameSetup
            // 
            this.NameSetup.Location = new System.Drawing.Point(134, 46);
            this.NameSetup.Name = "NameSetup";
            this.NameSetup.Size = new System.Drawing.Size(161, 20);
            this.NameSetup.TabIndex = 1;
            // 
            // IsMale
            // 
            this.IsMale.AutoSize = true;
            this.IsMale.Location = new System.Drawing.Point(15, 221);
            this.IsMale.Name = "IsMale";
            this.IsMale.Size = new System.Drawing.Size(63, 17);
            this.IsMale.TabIndex = 25;
            this.IsMale.TabStop = true;
            this.IsMale.Text = "Парень";
            this.IsMale.UseVisualStyleBackColor = true;
            // 
            // IsFemale
            // 
            this.IsFemale.AutoSize = true;
            this.IsFemale.Location = new System.Drawing.Point(16, 198);
            this.IsFemale.Name = "IsFemale";
            this.IsFemale.Size = new System.Drawing.Size(71, 17);
            this.IsFemale.TabIndex = 26;
            this.IsFemale.TabStop = true;
            this.IsFemale.Text = "Девушка";
            this.IsFemale.UseVisualStyleBackColor = true;
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Location = new System.Drawing.Point(12, 253);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(49, 13);
            this.AgeLabel.TabIndex = 28;
            this.AgeLabel.Text = "Возраст";
            // 
            // AgeSetup
            // 
            this.AgeSetup.Location = new System.Drawing.Point(133, 246);
            this.AgeSetup.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.AgeSetup.Name = "AgeSetup";
            this.AgeSetup.Size = new System.Drawing.Size(120, 20);
            this.AgeSetup.TabIndex = 27;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 334);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.AgeSetup);
            this.Controls.Add(this.IsFemale);
            this.Controls.Add(this.IsMale);
            this.Controls.Add(this.RegistrationText);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FormLabel);
            this.Controls.Add(this.Patronymic);
            this.Controls.Add(this.Surname);
            this.Controls.Add(this.StudentName);
            this.Controls.Add(this.FormSetup);
            this.Controls.Add(this.SurnameSetup);
            this.Controls.Add(this.PatronymicSetup);
            this.Controls.Add(this.NameSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.Text = "Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registration_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FormSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgeSetup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RegistrationText;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label FormLabel;
        private System.Windows.Forms.Label Patronymic;
        private System.Windows.Forms.Label Surname;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.NumericUpDown FormSetup;
        private System.Windows.Forms.TextBox SurnameSetup;
        private System.Windows.Forms.TextBox PatronymicSetup;
        private System.Windows.Forms.TextBox NameSetup;
        private System.Windows.Forms.RadioButton IsMale;
        private System.Windows.Forms.RadioButton IsFemale;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.NumericUpDown AgeSetup;
    }
}