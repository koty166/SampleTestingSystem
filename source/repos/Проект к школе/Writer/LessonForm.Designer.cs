namespace Проект_к_школе
{
    partial class LessonForm
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
            this.EndButton = new System.Windows.Forms.Button();
            this.LessonName = new System.Windows.Forms.TextBox();
            this.Args = new System.Windows.Forms.Label();
            this.arg3 = new System.Windows.Forms.TextBox();
            this.arg4 = new System.Windows.Forms.TextBox();
            this.arg1 = new System.Windows.Forms.TextBox();
            this.arg2 = new System.Windows.Forms.TextBox();
            this.arg0 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(12, 38);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(98, 26);
            this.EndButton.TabIndex = 0;
            this.EndButton.Text = "Ок";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LessonName
            // 
            this.LessonName.Location = new System.Drawing.Point(12, 12);
            this.LessonName.Name = "LessonName";
            this.LessonName.Size = new System.Drawing.Size(164, 20);
            this.LessonName.TabIndex = 1;
            // 
            // Args
            // 
            this.Args.AutoSize = true;
            this.Args.Location = new System.Drawing.Point(9, 85);
            this.Args.Name = "Args";
            this.Args.Size = new System.Drawing.Size(63, 13);
            this.Args.TabIndex = 35;
            this.Args.Text = "Аргументы";
            // 
            // arg3
            // 
            this.arg3.Location = new System.Drawing.Point(27, 130);
            this.arg3.Name = "arg3";
            this.arg3.Size = new System.Drawing.Size(45, 20);
            this.arg3.TabIndex = 34;
            this.toolTip1.SetToolTip(this.arg3, "Аргумент 4");
            // 
            // arg4
            // 
            this.arg4.Location = new System.Drawing.Point(78, 130);
            this.arg4.Name = "arg4";
            this.arg4.Size = new System.Drawing.Size(45, 20);
            this.arg4.TabIndex = 33;
            this.toolTip1.SetToolTip(this.arg4, "Аргумент 5");
            // 
            // arg1
            // 
            this.arg1.Location = new System.Drawing.Point(27, 104);
            this.arg1.Name = "arg1";
            this.arg1.Size = new System.Drawing.Size(45, 20);
            this.arg1.TabIndex = 32;
            this.toolTip1.SetToolTip(this.arg1, "Аргумент 2");
            // 
            // arg2
            // 
            this.arg2.Location = new System.Drawing.Point(78, 104);
            this.arg2.Name = "arg2";
            this.arg2.Size = new System.Drawing.Size(45, 20);
            this.arg2.TabIndex = 31;
            this.toolTip1.SetToolTip(this.arg2, "Аргумент 3");
            // 
            // arg0
            // 
            this.arg0.Location = new System.Drawing.Point(78, 78);
            this.arg0.Name = "arg0";
            this.arg0.Size = new System.Drawing.Size(45, 20);
            this.arg0.TabIndex = 30;
            this.toolTip1.SetToolTip(this.arg0, "Аргумент 1");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // LessonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(186, 157);
            this.Controls.Add(this.Args);
            this.Controls.Add(this.arg3);
            this.Controls.Add(this.arg4);
            this.Controls.Add(this.arg1);
            this.Controls.Add(this.arg2);
            this.Controls.Add(this.arg0);
            this.Controls.Add(this.LessonName);
            this.Controls.Add(this.EndButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LessonForm";
            this.Text = "Введите имя урока";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.button1_Click);
            this.Load += new System.EventHandler(this.LessonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.TextBox LessonName;
        private System.Windows.Forms.Label Args;
        private System.Windows.Forms.TextBox arg3;
        private System.Windows.Forms.TextBox arg4;
        private System.Windows.Forms.TextBox arg1;
        private System.Windows.Forms.TextBox arg2;
        private System.Windows.Forms.TextBox arg0;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}