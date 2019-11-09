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
            this.ShoolForm = new System.Windows.Forms.Label();
            this.Age = new System.Windows.Forms.Label();
            this.Patronymic = new System.Windows.Forms.Label();
            this.Surname = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.Label();
            this.FormSetup = new System.Windows.Forms.NumericUpDown();
            this.SurnameSetup = new System.Windows.Forms.TextBox();
            this.PatronymicSetup = new System.Windows.Forms.TextBox();
            this.AgeSetup = new System.Windows.Forms.TextBox();
            this.NameSetup = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormSetup)).BeginInit();
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
            this.Save.Location = new System.Drawing.Point(80, 262);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(125, 56);
            this.Save.TabIndex = 23;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ShoolForm
            // 
            this.ShoolForm.AutoSize = true;
            this.ShoolForm.Location = new System.Drawing.Point(13, 229);
            this.ShoolForm.Name = "ShoolForm";
            this.ShoolForm.Size = new System.Drawing.Size(38, 13);
            this.ShoolForm.TabIndex = 22;
            this.ShoolForm.Text = "Класс";
            // 
            // Age
            // 
            this.Age.AutoSize = true;
            this.Age.Location = new System.Drawing.Point(13, 185);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(49, 13);
            this.Age.TabIndex = 21;
            this.Age.Text = "Возраст";
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
            this.FormSetup.Location = new System.Drawing.Point(134, 222);
            this.FormSetup.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.FormSetup.Name = "FormSetup";
            this.FormSetup.Size = new System.Drawing.Size(120, 20);
            this.FormSetup.TabIndex = 17;
            // 
            // SurnameSetup
            // 
            this.SurnameSetup.Location = new System.Drawing.Point(134, 87);
            this.SurnameSetup.Name = "SurnameSetup";
            this.SurnameSetup.Size = new System.Drawing.Size(161, 20);
            this.SurnameSetup.TabIndex = 16;
            // 
            // PatronymicSetup
            // 
            this.PatronymicSetup.Location = new System.Drawing.Point(134, 132);
            this.PatronymicSetup.Name = "PatronymicSetup";
            this.PatronymicSetup.Size = new System.Drawing.Size(161, 20);
            this.PatronymicSetup.TabIndex = 15;
            // 
            // AgeSetup
            // 
            this.AgeSetup.Location = new System.Drawing.Point(134, 178);
            this.AgeSetup.Name = "AgeSetup";
            this.AgeSetup.Size = new System.Drawing.Size(161, 20);
            this.AgeSetup.TabIndex = 14;
            // 
            // NameSetup
            // 
            this.NameSetup.Location = new System.Drawing.Point(134, 46);
            this.NameSetup.Name = "NameSetup";
            this.NameSetup.Size = new System.Drawing.Size(161, 20);
            this.NameSetup.TabIndex = 13;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 334);
            this.Controls.Add(this.RegistrationText);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ShoolForm);
            this.Controls.Add(this.Age);
            this.Controls.Add(this.Patronymic);
            this.Controls.Add(this.Surname);
            this.Controls.Add(this.StudentName);
            this.Controls.Add(this.FormSetup);
            this.Controls.Add(this.SurnameSetup);
            this.Controls.Add(this.PatronymicSetup);
            this.Controls.Add(this.AgeSetup);
            this.Controls.Add(this.NameSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.Text = "Registration";
            ((System.ComponentModel.ISupportInitialize)(this.FormSetup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RegistrationText;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label ShoolForm;
        private System.Windows.Forms.Label Age;
        private System.Windows.Forms.Label Patronymic;
        private System.Windows.Forms.Label Surname;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.NumericUpDown FormSetup;
        private System.Windows.Forms.TextBox SurnameSetup;
        private System.Windows.Forms.TextBox PatronymicSetup;
        private System.Windows.Forms.TextBox AgeSetup;
        private System.Windows.Forms.TextBox NameSetup;
    }
}