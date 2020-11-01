namespace Проект_к_школе
{
    partial class TaskCreateForm
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
            this.TaskDescriptionTB = new System.Windows.Forms.TextBox();
            this.AddTask = new System.Windows.Forms.Button();
            this.TaskDescriptionLabel = new System.Windows.Forms.Label();
            this.TaskTimeTB = new System.Windows.Forms.TextBox();
            this.TaskTimeLabel = new System.Windows.Forms.Label();
            this.TaskNameLabel = new System.Windows.Forms.Label();
            this.TaskNameTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TaskDescriptionTB
            // 
            this.TaskDescriptionTB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TaskDescriptionTB.Location = new System.Drawing.Point(12, 25);
            this.TaskDescriptionTB.Multiline = true;
            this.TaskDescriptionTB.Name = "TaskDescriptionTB";
            this.TaskDescriptionTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TaskDescriptionTB.Size = new System.Drawing.Size(550, 275);
            this.TaskDescriptionTB.TabIndex = 0;
            this.TaskDescriptionTB.WordWrap = false;
            // 
            // AddTask
            // 
            this.AddTask.Location = new System.Drawing.Point(433, 330);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(129, 27);
            this.AddTask.TabIndex = 1;
            this.AddTask.Text = "Добавить";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddExplanation_Click);
            // 
            // TaskDescriptionLabel
            // 
            this.TaskDescriptionLabel.AutoSize = true;
            this.TaskDescriptionLabel.Location = new System.Drawing.Point(9, 9);
            this.TaskDescriptionLabel.Name = "TaskDescriptionLabel";
            this.TaskDescriptionLabel.Size = new System.Drawing.Size(327, 13);
            this.TaskDescriptionLabel.TabIndex = 2;
            this.TaskDescriptionLabel.Text = "Введи текст задачи. Часто это является объяснением задачи.";
            // 
            // TaskTimeTB
            // 
            this.TaskTimeTB.Location = new System.Drawing.Point(9, 337);
            this.TaskTimeTB.Name = "TaskTimeTB";
            this.TaskTimeTB.Size = new System.Drawing.Size(115, 20);
            this.TaskTimeTB.TabIndex = 4;
            // 
            // TaskTimeLabel
            // 
            this.TaskTimeLabel.AutoSize = true;
            this.TaskTimeLabel.Location = new System.Drawing.Point(6, 314);
            this.TaskTimeLabel.Name = "TaskTimeLabel";
            this.TaskTimeLabel.Size = new System.Drawing.Size(216, 13);
            this.TaskTimeLabel.TabIndex = 6;
            this.TaskTimeLabel.Text = "Времядля отета на вопросы (В секундах)";
            // 
            // TaskNameLabel
            // 
            this.TaskNameLabel.AutoSize = true;
            this.TaskNameLabel.Location = new System.Drawing.Point(227, 314);
            this.TaskNameLabel.Name = "TaskNameLabel";
            this.TaskNameLabel.Size = new System.Drawing.Size(67, 13);
            this.TaskNameLabel.TabIndex = 8;
            this.TaskNameLabel.Text = "Имя задачи";
            // 
            // TaskNameTB
            // 
            this.TaskNameTB.Location = new System.Drawing.Point(230, 337);
            this.TaskNameTB.Name = "TaskNameTB";
            this.TaskNameTB.Size = new System.Drawing.Size(115, 20);
            this.TaskNameTB.TabIndex = 7;
            // 
            // TaksCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 377);
            this.Controls.Add(this.TaskNameLabel);
            this.Controls.Add(this.TaskNameTB);
            this.Controls.Add(this.TaskTimeLabel);
            this.Controls.Add(this.TaskTimeTB);
            this.Controls.Add(this.TaskDescriptionLabel);
            this.Controls.Add(this.AddTask);
            this.Controls.Add(this.TaskDescriptionTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TaksCreateForm";
            this.Text = "ExplanationFormSetup";
            this.Load += new System.EventHandler(this.ExplanationFormSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TaskDescriptionTB;
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.Label TaskDescriptionLabel;
        private System.Windows.Forms.TextBox TaskTimeTB;
        private System.Windows.Forms.Label TaskTimeLabel;
        private System.Windows.Forms.Label TaskNameLabel;
        private System.Windows.Forms.TextBox TaskNameTB;
    }
}