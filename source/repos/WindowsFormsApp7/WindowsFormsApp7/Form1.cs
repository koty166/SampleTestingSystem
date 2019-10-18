using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String path = @"thems\";
        List<thems> ListThems = new List<thems>();

        private void GlobalColorSetup_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            GlobalColorExample.BackColor = colorDialog1.Color;
        }

        private void SecondaryColorSetup_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            SecondaryColorExample.BackColor = colorDialog1.Color;
        }

        private void LabelColorSetup_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            LabelColorExample.ForeColor = colorDialog1.Color;
            ButtonColorExample.ForeColor = colorDialog1.Color;
        }

        private void ButtonColorSetup_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ButtonColorExample.BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.BackColor = GlobalColorExample.BackColor;
            groupBox2.BackColor = GlobalColorExample.BackColor;
            this.BackColor = GlobalColorExample.BackColor;

            treeView1.BackColor = SecondaryColorExample.BackColor;

            button1.BackColor = ButtonColorExample.BackColor;
            button2.BackColor = ButtonColorExample.BackColor;
            GlobalColorSetup.BackColor = ButtonColorExample.BackColor;
            SecondaryColorSetup.BackColor = ButtonColorExample.BackColor;
            LabelColorSetup.BackColor = ButtonColorExample.BackColor;
            ButtonColorExample.BackColor = ButtonColorExample.BackColor;
            ButtonColorExample.BackColor = ButtonColorExample.BackColor;
            button3.BackColor = ButtonColorExample.BackColor;
            button4.BackColor = ButtonColorExample.BackColor;
            ButtonColorSetup.BackColor = ButtonColorExample.BackColor;

            label1.ForeColor = LabelColorExample.ForeColor;
            label2.ForeColor = LabelColorExample.ForeColor;
            LabelColorSetup.ForeColor = LabelColorExample.ForeColor;
            this.ForeColor = LabelColorExample.ForeColor;
            groupBox1.ForeColor = LabelColorExample.ForeColor;
            groupBox2.ForeColor = LabelColorExample.ForeColor;
            treeView1.ForeColor = LabelColorExample.ForeColor;
            button1.ForeColor = LabelColorExample.ForeColor;
            button2.ForeColor = LabelColorExample.ForeColor;
            button3.ForeColor = LabelColorExample.ForeColor;
            ButtonColorExample.ForeColor = LabelColorExample.ForeColor;
            ButtonColorSetup.ForeColor = LabelColorExample.ForeColor;
            SecondaryColorSetup.ForeColor = LabelColorExample.ForeColor;
            GlobalColorSetup.ForeColor = LabelColorExample.ForeColor;
            button4.ForeColor = LabelColorExample.ForeColor;

            pictureBox.Image = drow_Diagramm();
            pictureBox.Refresh();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(path + "thems.mythems"))
            {
                FileStream s = new FileStream(path + "thems.mythems", FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();

                ListThems = (List<thems>)f.Deserialize(s);

                s.Close();
            }
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var i in ListThems)
            {
                listBox1.Items.Add(i);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ListThems[listBox1.SelectedIndex].GlobalColor = GlobalColorExample.BackColor;
                ListThems[listBox1.SelectedIndex].SecoundaryColor = SecondaryColorExample.BackColor;
                ListThems[listBox1.SelectedIndex].LabelColor = LabelColorExample.ForeColor;
                ListThems[listBox1.SelectedIndex].ButtonColor = ButtonColorExample.BackColor;
                ListThems[listBox1.SelectedIndex].RigthAnswerColor = RigthAnswerExample.BackColor;
                ListThems[listBox1.SelectedIndex].WrongAnswerColor = WrongAnswerExample.BackColor;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(path + "thems.mythems"))
                File.Delete(path + "thems.mythems");

            FileStream s = new FileStream(path + "thems.mythems", FileMode.Create);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(s, ListThems);

            s.Close();

        }

        Image drow_Diagramm()
        {
            int wrong = 5;
            Image im = pictureBox.Image;

            pictureBox.Refresh();
            pictureBox.Size = new Size(300, 300);

            Bitmap bit = new Bitmap(im);
            Graphics g = Graphics.FromImage(bit);
            SolidBrush b = new SolidBrush(Color.Tomato);
            g.Clear(GlobalColorExample.BackColor);


            Rectangle rect = new Rectangle()
            {
                Size = pictureBox.Size,
                X = pictureBox.Location.X - 20,
                Y = pictureBox.Location.Y - 20
            };

            float end = (((float)wrong / 25) * 360);
            g.FillPie(b, rect, 0, end);

            b.Color = Color.SpringGreen;

            g.FillPie(b, rect, end, 360 - end);

            return bit;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thems s = new thems();
            ListThems.Add(s);
            listBox1.Items.Add(s);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GlobalColorExample.BackColor = ListThems[listBox1.SelectedIndex].GlobalColor;
                SecondaryColorExample.BackColor = ListThems[listBox1.SelectedIndex].SecoundaryColor;
                LabelColorExample.ForeColor = ListThems[listBox1.SelectedIndex].LabelColor;
                ButtonColorExample.ForeColor = ListThems[listBox1.SelectedIndex].LabelColor;
                ButtonColorExample.BackColor = ListThems[listBox1.SelectedIndex].ButtonColor;
                RigthAnswerExample.BackColor = ListThems[listBox1.SelectedIndex].RigthAnswerColor;
                WrongAnswerExample.BackColor = ListThems[listBox1.SelectedIndex].WrongAnswerColor;
            }
            catch { }
        }

        private void RigthAnswerSetup_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            RigthAnswerExample.BackColor = colorDialog1.Color;
        }

        private void WrongAnswerSetup_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            WrongAnswerExample.BackColor = colorDialog1.Color;
        }
    }
    [Serializable]
    class thems
    {
        internal Color GlobalColor;
        internal Color LabelColor;
        internal Color SecoundaryColor;
        internal Color ButtonColor;
        internal Color RigthAnswerColor;
        internal Color WrongAnswerColor;
    }
}
