using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект_к_школе
{
    [Serializable]
    class Question
    {
        internal String[] Answers = new String[4];
#pragma warning disable CS0649 // Полю "Question.Rigth_answer" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
        internal int Rigth_answer;
#pragma warning restore CS0649 // Полю "Question.Rigth_answer" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию 0.
#pragma warning disable CS0649 // Полю "Question.Question_s" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
        internal String Question_s;
#pragma warning restore CS0649 // Полю "Question.Question_s" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
#pragma warning disable CS0649 // Полю "Question.Explanation" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
        internal String Explanation;
        internal Object arg;
#pragma warning restore CS0649 // Полю "Question.Explanation" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.

    }
}
