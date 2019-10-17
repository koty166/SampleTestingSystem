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

namespace Thems_Writer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String path = @"C:\Users\я\source\repos\Проект к школе\Проект в е88нной школе\bin\Debug\Tests\";
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(path + "thems.mythems"))
            {
                FileStream s = new FileStream(path + "thems.mythems" , FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();

                ListThems=(List<thems>)f.Deserialize(s);

                s.Close();
            }
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
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(path + "thems.mythems"))
                File.Delete(path + "thems.mythems");
            FileStream s = new FileStream(path + "thems.mythems", FileMode.Create);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(s, ListThems);
                
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
            }
            catch { }
        }
    }
    [Serializable]
    class thems
    {
        internal Color GlobalColor;
        internal Color SecoundaryColor;
        internal Color LabelColor;
        internal Color ButtonColor;
    }
}
