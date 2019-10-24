using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Проект_к_школе
{
    public partial class FormWriter : Form
    {
        public FormWriter()
        {
            InitializeComponent();
        }
        List<Lesson> Lesson_mass = new List<Lesson>();
        String directory = @"Tests";
        public  String Explanation;


        void Load_in_form()
        {
            foreach (var i in Lesson_mass)
            {
                list_of_lessons.Items.Add(i.Name);
            }

        }
        void rename_list_of_questions()
        {
            for (int i = 0; i < list_of_questions.Nodes.Count; i++)
            {
                list_of_questions.Nodes[i].Text = "Задание: " + (i + 1) ;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rename_list_of_questions();
            if (Lesson_mass.Count != 0)
            { Load_in_form(); }

            String[] File_mass_date;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            else
            {
                File_mass_date = Directory.GetFiles(directory, "*.dat");
                if (File_mass_date.Length != 0)
                {
                    for (int i = 0; i < File_mass_date.Length; i++)
                    {
                        FileStream Stream = new FileStream(File_mass_date[i], FileMode.Open);
                        BinaryFormatter Formated = new BinaryFormatter();

                        Lesson_mass.Add((Lesson)Formated.Deserialize(Stream));

                        Stream.Close();
                    }
                }
            }
            Load_in_form();

            groupBox1.Visible = false;
            groupBox2.Visible = false;
            button3.Visible = false;
            textBox5.Visible = false;
            label2.Visible = false;

        }

        void save_to_mass()
        {
            int checed_radiobutton = -1;
            if (list_of_questions.SelectedNode != null && list_of_lessons.SelectedItem != null)
            {
                Lesson_mass[list_of_lessons.SelectedIndex].Score = Convert.ToInt32(textBox10.Text);

                if (list_of_questions.SelectedNode.Index < 20)
                {
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[0] = textBox1.Text;
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[1] = textBox2.Text;
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[2] = textBox3.Text;
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[3] = textBox4.Text;

                    if (radioButton1.Checked) checed_radiobutton = 0;
                    else if (radioButton2.Checked) checed_radiobutton = 1;
                    else if (radioButton3.Checked) checed_radiobutton = 2;
                    else if (radioButton4.Checked) checed_radiobutton = 3;
                    else checed_radiobutton = 0;

                    Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Rigth_answer = checed_radiobutton;

                    Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Question_s = textBox5.Text;

                    Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Explanation = Explanation;

                }
                else
                {
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].Rigth_answer = textBox8.Text;
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].Question = textBox5.Text;
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].Explanation = Explanation;
                    Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].image_name = textBox9.Text;
                }
            }

        }

        private void list_of_questions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Text = list_of_questions.SelectedNode.Index.ToString();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            Explanation = null;
            textBox6.Clear();
            textBox10.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            if (list_of_questions.SelectedNode != null && list_of_lessons.SelectedItem != null)
            {

                textBox10.Text = Lesson_mass[list_of_lessons.SelectedIndex].Score.ToString();

                if (list_of_questions.SelectedNode.Index >= 20)
                {
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    button3.Visible = true;
                    textBox5.Visible = true;
                    label2.Visible = true;
                    {
                        textBox8.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].Rigth_answer;
                        textBox5.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].Question;
                        Explanation = Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].Explanation;
                        textBox9.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_ImageQuestion[list_of_questions.SelectedNode.Index - 20].image_name;
                    }
                }
                else if (list_of_questions.SelectedNode.Index < 20)
                {
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    button3.Visible = true;
                    textBox5.Visible = true;
                    label2.Visible = true;

                    {
                        textBox1.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[0];
                        textBox2.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[1];
                        textBox3.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[2];
                        textBox4.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Answers[3];

                        switch (Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Rigth_answer)
                        {
                            case 0:
                                radioButton1.Checked = true;
                                break;
                            case 1:
                                radioButton2.Checked = true;
                                break;
                            case 2:
                                radioButton3.Checked = true;
                                break;
                            case 3:
                                radioButton4.Checked = true;
                                break;
                        }
                        textBox5.Text = Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Question_s;
                        Explanation = Lesson_mass[list_of_lessons.SelectedIndex].mass_Question[list_of_questions.SelectedNode.Index].Explanation;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            Lesson_mass.Add(new Lesson() { Name = textBox6.Text != "" ? textBox6.Text : "Тест" , Score = textBox10.Text != "" ? Convert.ToInt32(textBox10.Text) : 0 });

            list_of_lessons.Items.Clear();

            Load_in_form();

            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Lesson_mass.Count != 0) 
                foreach (var i in Lesson_mass)
                {
                    File.Delete($"{directory}\\{i.Name}.dat");

                    BinaryFormatter Formatted = new BinaryFormatter();
                    FileStream stream = new FileStream($"{directory}\\{i.Name}.dat",FileMode.Create);                       

                    Formatted.Serialize(stream, i);

                    stream.Close();
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list_of_questions.SelectedNode != null && list_of_lessons.SelectedItem != null
                && list_of_questions.SelectedNode.Index >= 20)
                    if (textBox9.Text.Contains('.') && File.Exists($"Tests\\images\\{textBox9.Text}"))
                    {
                        String s;
                        Form2 f = new Form2();

                        s = textBox9.Text;

                        f.pictureBox1.ImageLocation = $"Tests\\images\\{s}";
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Картинка не сушествует или неправельно введено имя");
                        textBox9.Text = "Error.png";
                    }
            else
                MessageBox.Show("Выберите задание и урок");
      
            save_to_mass();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormForExplanation f = new FormForExplanation();
            f.Show();
        }

    }
}
