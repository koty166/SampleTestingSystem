using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using LessonsResourses;
using NLog;
using System.Diagnostics;

namespace Проект_к_школе
{
    public partial class FormWriter : Form
    {
        public FormWriter() =>
            InitializeComponent();
        internal enum ExploerType : byte
        {
            Tests = 0,
            Tasks,
            Questions
        }
        internal List<Test> Tests = new List<Test>();
        internal int CurrentTest = 0, CurrentTask = 0, CurrentQuestion = 0;
        internal ExploerType CurrentType = ExploerType.Tests;

        String directory = @"Tests";


        /// <summary>
        /// Обновляет содержание проводника.
        /// </summary>
       internal void UpdateExploer()
        {
            Exploer.Nodes.Clear();
            TreeNode CurrentNode, CurrentNodeN;
            foreach (var i in Tests)
            {
                CurrentNode = new TreeNode(i.Name);
                Exploer.Nodes.Add(CurrentNode);
                foreach (var j in i.Tasks)
                {
                    CurrentNodeN = new TreeNode(j.Name);
                    CurrentNode.Nodes.Add(CurrentNodeN);
                    foreach (var k in j.Questions)
                        CurrentNodeN.Nodes.Add("Question",k.Name);
                    CurrentNodeN.Nodes.Add("Plus", "+");
                }
                CurrentNode.Nodes.Add("Plus", "+");
            }
            Exploer.Nodes.Add("Plus", "+");
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            else
            {
                FileStream Stream;
                BinaryFormatter Formated = new BinaryFormatter(); ;
                String[] FileNames;

                FileNames = Directory.GetFiles(directory + "\\", "*.dat");
                if (FileNames.Length != 0)
                {
                    foreach (var i in FileNames)
                    {
                        Stream = new FileStream(i, FileMode.Open);
                        Tests.Add((Test)Formated.Deserialize(Stream));

                        Stream.Close();
                    }
                    
                }
            }
            UpdateExploer();
        }

        private void Exploer_DoubleClick(object sender, EventArgs e)
        {
            if (Exploer.SelectedNode.Text == "+")
            {
                switch (Exploer.SelectedNode.Level)
                {
                    case 0:
                        new TestCreateForm(this,true,Tests).Show();
                        this.Enabled = false;
                        CurrentType++;
                        break;
                    case 1:
                        CurrentTask = Exploer.SelectedNode.Index-1;
                        new TaskCreateForm(this, true,Tests[Exploer.SelectedNode.Index].Tasks).Show();
                        this.Enabled = false;
                        CurrentType++;
                        break;
                    case 2:

                        new QuestionCreateForm(this, true,Tests[Exploer.SelectedNode.Parent.Index].Tasks[Exploer.SelectedNode.Index].Questions).Show();
                        this.Enabled = false;
                        break;
                }
            }
            else
            {
                switch (Exploer.SelectedNode.Level)
                {
                    case 0:
                        new TestCreateForm(this, false, Tests, Exploer.SelectedNode.Index).Show();
                        this.Enabled = false;
                        CurrentType++;
                        break;
                    case 1:
                        CurrentTask = Exploer.SelectedNode.Index - 1;
                        new TaskCreateForm(this, false, Tests[Exploer.SelectedNode.Index].Tasks, Exploer.SelectedNode.Index).Show();
                        this.Enabled = false;
                        CurrentType++;
                        break;
                    case 2:

                        new QuestionCreateForm(this, false, Tests[Exploer.SelectedNode.Parent.Index].Tasks[Exploer.SelectedNode.Index].Questions, Exploer.SelectedNode.Index).Show();
                        this.Enabled = false;
                        break;
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] Files = Directory.GetFiles(directory + "\\", "*.dat");
            BinaryFormatter Formatted = new BinaryFormatter();

            foreach (var item in Files)//TODO:Добавить на проверку наличия в списке задач, если нет, то не удалять
                File.Delete(item);

            foreach (var i in Tests)
            {
                FileStream stream = new FileStream($"{directory}\\{i.Name}.dat", FileMode.Create);

                Formatted.Serialize(stream, i);

                stream.Close();
            }
        }
    }
}
