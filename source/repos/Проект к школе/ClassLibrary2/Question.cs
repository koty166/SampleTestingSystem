using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    [Serializable]
    public class Question
    {
        public String[] Answers = new String[4];
        public String Question_s;
        public Object arg;

    }
}
