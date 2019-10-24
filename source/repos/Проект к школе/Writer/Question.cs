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
        internal int Rigth_answer;
        internal String Question_s;
        internal String Explanation;
        internal Object arg;
    }
}
