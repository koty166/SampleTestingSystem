namespace Проект_к_школе
{
    partial class ExplanationFormSetup
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
            this.TextOfExplanation = new System.Windows.Forms.TextBox();
            this.AddExplanation = new System.Windows.Forms.Button();
            this.ExplanationTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextOfExplanation
            // 
            this.TextOfExplanation.Location = new System.Drawing.Point(18, 27);
            this.TextOfExplanation.Multiline = true;
            this.TextOfExplanation.Name = "TextOfExplanation";
            this.TextOfExplanation.Size = new System.Drawing.Size(454, 328);
            this.TextOfExplanation.TabIndex = 0;
            // 
            // AddExplanation
            // 
            this.AddExplanation.Location = new System.Drawing.Point(165, 378);
            this.AddExplanation.Name = "AddExplanation";
            this.AddExplanation.Size = new System.Drawing.Size(129, 27);
            this.AddExplanation.TabIndex = 1;
            this.AddExplanation.Text = "Добавить";
            this.AddExplanation.UseVisualStyleBackColor = true;
            this.AddExplanation.Click += new System.EventHandler(this.AddExplanation_Click);
            // 
            // ExplanationTextLabel
            // 
            this.ExplanationTextLabel.AutoSize = true;
            this.ExplanationTextLabel.Location = new System.Drawing.Point(24, 9);
            this.ExplanationTextLabel.Name = "ExplanationTextLabel";
            this.ExplanationTextLabel.Size = new System.Drawing.Size(214, 13);
            this.ExplanationTextLabel.TabIndex = 2;
            this.ExplanationTextLabel.Text = "Введи текст обяснения или инструкциии";
            // 
            // ExplanationFormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 416);
            this.Controls.Add(this.ExplanationTextLabel);
            this.Controls.Add(this.AddExplanation);
            this.Controls.Add(this.TextOfExplanation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExplanationFormSetup";
            this.Text = "ExplanationFormSetup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExplanationFormSetup_FormClosing);
            this.Load += new System.EventHandler(this.ExplanationFormSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextOfExplanation;
        private System.Windows.Forms.Button AddExplanation;
        private System.Windows.Forms.Label ExplanationTextLabel;
    }
}