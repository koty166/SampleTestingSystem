using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект_к_школе
{
    [Serializable]
    class Lesson
    {
        internal Question[] mass_Question = new Question[20];
        internal ImageQuestion[] mass_ImageQuestion = new ImageQuestion[5];
#pragma warning disable CS0649 // Полю "Lesson.Name" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
        internal String Name;
#pragma warning restore CS0649 // Полю "Lesson.Name" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
#pragma warning disable CS0649 // Полю "Lesson.Score" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
        internal int Score;

        internal Object [] args = new Object [5];
        internal bool IsRandom;

#pragma warning restore CS0649 // Полю "Lesson.Score" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
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
