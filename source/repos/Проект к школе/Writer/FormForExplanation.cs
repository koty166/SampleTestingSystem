using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_к_школе
{
    public partial class FormForExplanation : Form
    {
        public FormForExplanation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormWriter f = (FormWriter)Application.OpenForms[0];
            f.Explanation = textBox1.Text;
            this.Dispose();
        }

        private void FormForExplanation_Load(object sender, EventArgs e)
        {
            FormWriter f = (FormWriter)Application.OpenForms[0];
            textBox1.Text = f.Explanation;
        }
    }
}
