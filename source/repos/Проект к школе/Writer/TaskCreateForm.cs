using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LessonsResourses;

namespace Проект_к_школе
{
    public partial class TaskCreateForm : Form
    {
        readonly FormWriter FWParent;
        readonly bool IsNew;
        readonly Task TaskToChange;
        List<Task> ParentList;
        public TaskCreateForm(FormWriter _Parent, bool _IsNew,List<Task> _ParentList, int _TaskToChangeIndex = -1)
        {
            InitializeComponent();
            FWParent = _Parent;
            IsNew = _IsNew;
            TaskToChange = _TaskToChangeIndex != -1? _ParentList[_TaskToChangeIndex]:null;
            ParentList = _ParentList;
        }       
        private void AddExplanation_Click(object sender, EventArgs e)
        {
            if(IsNew)
            {
                ParentList.Add(new Task()
                {
                    Name = TaskNameTB.Text,
                    Description = TaskDescriptionTB.Text,
                    TimeToAnswer = int.Parse(TaskTimeTB.Text)
                });
            }
            else
            {
                TaskToChange.Name = TaskNameTB.Text;
                TaskToChange.Description = TaskDescriptionTB.Text;
                TaskToChange.TimeToAnswer = int.Parse(TaskTimeTB.Text);
            }
            FWParent.Enabled = true;
            FWParent.UpdateExploer();
            Dispose();
        }

        private void ExplanationFormSetup_Load(object sender, EventArgs e)
        {
            if (!IsNew && TaskToChange != null)
            {
                TaskDescriptionTB.Text = TaskToChange.Description;
                TaskTimeTB.Text = TaskToChange.TimeToAnswer.ToString();
                TaskNameTB.Text = TaskToChange.Name;
                AddTask.Text = "Изменить";
            }
                
        }
    }
}
