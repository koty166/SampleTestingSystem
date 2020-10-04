namespace Проект_к_школе
{
    partial class Balls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Balls));
            this.Field = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field.Image = ((System.Drawing.Image)(resources.GetObject("Field.Image")));
            this.Field.Location = new System.Drawing.Point(0, 0);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(800, 450);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            this.Field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Field_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Balls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Field);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "Balls";
            this.Text = "Balls";
            this.Resize += new System.EventHandler(this.Balls_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Field;
        private System.Windows.Forms.Timer timer1;
    }
}