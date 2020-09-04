using System;

namespace ClassLibrary2
{
    [Serializable]
    public class Question
    {
        public String[] Answers = new String[4];
        public String QuestionStr;
        public String image_name;
        public bool IsImage;
        public object arg;
    }
}
