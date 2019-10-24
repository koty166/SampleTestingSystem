using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_к_школе
{
    [Serializable]
    class Lesson
    {
        internal Question[] mass_Question = new Question[20];
        internal ImageQuestion[] mass_ImageQuestion = new ImageQuestion[5];
        internal String Name;
        internal int Score;
        internal Object[] args = new Object[5];
        internal bool IsRandom;

        public Lesson()
        {
            for (int i = 0; i < 20; i++)
            {
                mass_Question[i] = new Question();
            }
            for (int i = 0; i < 5; i++)
            {
                mass_ImageQuestion[i] = new ImageQuestion();
            }  
        }

    }
}
