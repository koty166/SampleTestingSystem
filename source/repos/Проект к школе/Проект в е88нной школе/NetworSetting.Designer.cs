namespace Проект_к_школе
{
    partial class NetworSetting
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
            this.CheckConnections = new System.Windows.Forms.Button();
            this.IPsetup = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.Statys = new System.Windows.Forms.Label();
            this.NetworkStatys = new System.Windows.Forms.Label();
            this.Done = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.GetIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckConnections
            // 
            this.CheckConnections.Location = new System.Drawing.Point(22, 53);
            this.CheckConnections.Name = "CheckConnections";
            this.CheckConnections.Size = new System.Drawing.Size(140, 21);
            this.CheckConnections.TabIndex = 0;
            this.CheckConnections.Text = "Проверить соединение";
            this.CheckConnections.UseVisualStyleBackColor = true;
            this.CheckConnections.Click += new System.EventHandler(this.CheckConnections_Click);
            // 
            // IPsetup
            // 
            this.IPsetup.Location = new System.Drawing.Point(247, 54);
            this.IPsetup.Name = "IPsetup";
            this.IPsetup.Size = new System.Drawing.Size(125, 20);
            this.IPsetup.TabIndex = 1;
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(180, 60);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(20, 13);
            this.IPLabel.TabIndex = 2;
            this.IPLabel.Text = "IP:";
            // 
            // Statys
            // 
            this.Statys.AutoSize = true;
            this.Statys.Location = new System.Drawing.Point(19, 117);
            this.Statys.Name = "Statys";
            this.Statys.Size = new System.Drawing.Size(44, 13);
            this.Statys.TabIndex = 3;
            this.Statys.Text = "Статус:";
            // 
            // NetworkStatys
            // 
            this.NetworkStatys.AutoSize = true;
            this.NetworkStatys.Location = new System.Drawing.Point(94, 117);
            this.NetworkStatys.Name = "NetworkStatys";
            this.NetworkStatys.Size = new System.Drawing.Size(35, 13);
            this.NetworkStatys.TabIndex = 4;
            this.NetworkStatys.Text = "label3";
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(12, 148);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(101, 39);
            this.Done.TabIndex = 5;
            this.Done.Text = "Завершить";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(19, 19);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(173, 13);
            this.TitleLabel.TabIndex = 6;
            this.TitleLabel.Text = "Настройте интернет соединение";
            // 
            // GetIP
            // 
            this.GetIP.Location = new System.Drawing.Point(128, 154);
            this.GetIP.Name = "GetIP";
            this.GetIP.Size = new System.Drawing.Size(141, 33);
            this.GetIP.TabIndex = 7;
            this.GetIP.Text = "Начать получение IP ";
            this.GetIP.UseVisualStyleBackColor = true;
            this.GetIP.Click += new System.EventHandler(this.GetIP_Click);
            // 
            // NetworSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 199);
            this.Controls.Add(this.GetIP);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.NetworkStatys);
            this.Controls.Add(this.Statys);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.IPsetup);
            this.Controls.Add(this.CheckConnections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "NetworSetting";
            this.Text = "NetworSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetworSetting_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckConnections;
        private System.Windows.Forms.TextBox IPsetup;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label Statys;
        private System.Windows.Forms.Label NetworkStatys;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button GetIP;
    }
}