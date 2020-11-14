using System;
using System.Windows.Forms;
using LessonsResourses;
using System.Collections.Generic;

namespace Проект_к_школе
{
    public partial class TestCreateForm : Form
    {
        readonly bool IsNew;
        readonly Test TestTochange;
        readonly FormWriter FWParent;
        List<Test> ParentList;
        public TestCreateForm(FormWriter _FWParent, bool _IsNew, List<Test> _ParentList, int _TestTochangeIndex = -1)
        {
            InitializeComponent();

            IsNew = _IsNew;
            TestTochange = _TestTochangeIndex != -1 ? _ParentList[_TestTochangeIndex] : null;
            ParentList = _ParentList;
            FWParent = _FWParent;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (IsNew)
                ParentList.Add(new Test()
                {
                    Name = TestNameTB.Text,
                    Type = TestTypeTB.Text,
                });
            else
            {
                TestTochange.Name = TestNameTB.Text;
                TestTochange.Type = TestTypeTB.Text;
            }
            FWParent.Enabled = true;
            FWParent.UpdateExploer();
            this.Dispose();
        }

        private void LessonForm_Load(object sender, EventArgs e)
        {
            if (!IsNew && TestTochange != null)
            {
                EndButton.Text = "Изменить";
                TestNameTB.Text = TestTochange.Name ?? "";
                TestTypeTB.Text = TestTochange.Type ?? "";
            }
        }

        private void button1_Click(object sender, FormClosingEventArgs e)
        {

        }

        private void TestCreateForm_FormClosing(object sender, FormClosingEventArgs e) => FWParent.Enabled = true;
    }
}
