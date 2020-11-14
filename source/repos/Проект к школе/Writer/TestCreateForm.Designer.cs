namespace Проект_к_школе
{
    partial class TestCreateForm
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
            this.TestNameTB = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TestNameLabel = new System.Windows.Forms.Label();
            this.TestTypeLabel = new System.Windows.Forms.Label();
            this.TestTypeTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(12, 126);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(98, 26);
            this.EndButton.TabIndex = 0;
            this.EndButton.Text = "Ок";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestNameTB
            // 
            this.TestNameTB.Location = new System.Drawing.Point(12, 25);
            this.TestNameTB.Name = "TestNameTB";
            this.TestNameTB.Size = new System.Drawing.Size(164, 20);
            this.TestNameTB.TabIndex = 1;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // TestNameLabel
            // 
            this.TestNameLabel.AutoSize = true;
            this.TestNameLabel.Location = new System.Drawing.Point(12, 9);
            this.TestNameLabel.Name = "TestNameLabel";
            this.TestNameLabel.Size = new System.Drawing.Size(60, 13);
            this.TestNameLabel.TabIndex = 2;
            this.TestNameLabel.Text = "Имя теста";
            // 
            // TestTypeLabel
            // 
            this.TestTypeLabel.AutoSize = true;
            this.TestTypeLabel.Location = new System.Drawing.Point(9, 67);
            this.TestTypeLabel.Name = "TestTypeLabel";
            this.TestTypeLabel.Size = new System.Drawing.Size(57, 13);
            this.TestTypeLabel.TabIndex = 4;
            this.TestTypeLabel.Text = "Тип теста";
            // 
            // TestTypeTB
            // 
            this.TestTypeTB.Location = new System.Drawing.Point(12, 83);
            this.TestTypeTB.Name = "TestTypeTB";
            this.TestTypeTB.Size = new System.Drawing.Size(164, 20);
            this.TestTypeTB.TabIndex = 3;
            // 
            // TestCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(208, 188);
            this.Controls.Add(this.TestTypeLabel);
            this.Controls.Add(this.TestTypeTB);
            this.Controls.Add(this.TestNameLabel);
            this.Controls.Add(this.TestNameTB);
            this.Controls.Add(this.EndButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TestCreateForm";
            this.Text = "Создать тест";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestCreateForm_FormClosing);
            this.Load += new System.EventHandler(this.LessonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.TextBox TestNameTB;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label TestNameLabel;
        private System.Windows.Forms.Label TestTypeLabel;
        private System.Windows.Forms.TextBox TestTypeTB;
    }
}