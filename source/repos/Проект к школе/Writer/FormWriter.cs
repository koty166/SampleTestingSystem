using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using LessonsResourses;
using NLog;
using System.Diagnostics;
using System.Reflection;

namespace Проект_к_школе
{
    public partial class FormWriter : Form
    {
        public FormWriter() =>
            InitializeComponent();
        internal List<Test> Tests = new List<Test>();

        const String directory = @"Tests";


        /// <summary>
        /// Обновляет содержание проводника.
        /// </summary>
        internal void UpdateExploer()
        {
            StringBuilder OpenedNodes = new StringBuilder(100);
            foreach (TreeNode i in Exploer.Nodes)
            {
                if (i.IsExpanded)
                {
                    OpenedNodes.Append(i.Index + ",");

                    foreach (TreeNode j in i.Nodes)
                        if (j.IsExpanded)
                            OpenedNodes.Append(j.Index + ",");
                    OpenedNodes.Append(";");

                }
            }
            String OpenedNodesStr = OpenedNodes.ToString();



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
                        CurrentNodeN.Nodes.Add("Question", k.Name);
                    CurrentNodeN.Nodes.Add("Plus", "+");
                }
                CurrentNode.Nodes.Add("Plus", "+");
            }
            Exploer.Nodes.Add("Plus", "+");



            foreach (string i in OpenedNodesStr.Split(';'))
            {
                if (i == "")
                    continue;

                string[] BNodes = i.Split(',');
                int ANode = int.Parse(BNodes[0]),BNode;

                if (ANode >= Exploer.Nodes.Count)
                    break;
                Exploer.Nodes[ANode].Expand();
                if (BNodes.Length > 1)
                    for (int j = 1; j < BNodes.Length; j++)
                    {
                        if (BNodes[j] == "")
                            continue;
                        BNode = int.Parse(BNodes[j]);
                        if (BNode >= Exploer.Nodes[ANode].Nodes.Count)
                            break;
                        
                        Exploer.Nodes[ANode].Nodes[BNode].Expand();
                    }
            }

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
            Exploer.SelectedNode.Toggle();
            if (Exploer.SelectedNode.Text == "+")
            {
                switch (Exploer.SelectedNode.Level)
                {
                    case 0:
                        new TestCreateForm(this,true,Tests).Show();
                        this.Enabled = false;
                        break;
                    case 1:
                        new TaskCreateForm(this, true,Tests[Exploer.SelectedNode.Parent.Index].Tasks).Show();
                        this.Enabled = false;
                        break;
                    case 2:

                        new QuestionCreateForm(this, true,Tests[Exploer.SelectedNode.Parent.Parent.Index].Tasks[Exploer.SelectedNode.Parent.Index].Questions).Show();
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
                        break;
                    case 1:
                        new TaskCreateForm(this, false, Tests[Exploer.SelectedNode.Parent.Index].Tasks, Exploer.SelectedNode.Index).Show();
                        break;
                    case 2:
                        new QuestionCreateForm(this, false, Tests[Exploer.SelectedNode.Parent.Parent.Index].Tasks[Exploer.SelectedNode.Parent.Index].Questions, Exploer.SelectedNode.Index).Show();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          
            switch (Exploer.SelectedNode.Level)
            {
                case 0:
                    if (MessageBox.Show("Вы действительно хотите удалить данный тест?\nДанное действие необратимо.", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Tests.RemoveAt(Exploer.SelectedNode.Index);
                    break;
                case 1:
                    if (MessageBox.Show("Вы действительно хотите удалить данную задачу?\nДанное действие необратимо.", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Tests[Exploer.SelectedNode.Parent.Index].Tasks.RemoveAt(Exploer.SelectedNode.Index);
                    break;
                case 2:
                    if (MessageBox.Show("Вы действительно хотите удалить данный вопрос?\nДанное действие необратимо.", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Tests[Exploer.SelectedNode.Parent.Parent.Index].Tasks[Exploer.SelectedNode.Parent.Index].Questions.RemoveAt(Exploer.SelectedNode.Index);
                    break;
            }
            UpdateExploer();
        }

        private void Exploer_DragDrop(object sender, DragEventArgs e)
        {
            
        }
    }
}
