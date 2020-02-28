using System;
using System.Collections.Generic;

namespace ClassLibrary2
{
    [Serializable]
    public class Lesson
    {
        public List<object> QuestionList = new List<object>();
        public String Name;

        public object [] args = new object [5];
    }
}
