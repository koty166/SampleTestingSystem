using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    [Serializable]
    public class Pupil
    {
        public int Age;
        public int Form;
        public string Name;
        public string Surname;
        public string Patronymic;
        public string MarkForTest;
        public string[] arg  = new string [5];
        public bool IsMale;

        public List<string> AnswerList = new List<string>();

        public Pupil() { }

        public Pupil(int _Age, int _Form, string _Name, string _Surname, string _Patronymic)
        {
            this.Age = _Age;
            this.Form = _Form;
            this.Name = _Name;
            this.Surname = _Surname;
            this.Patronymic = _Patronymic;
        }
    }
   
}
