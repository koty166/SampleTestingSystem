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
        int Age;
        int Form;
        string Name;
        string Surname;
        string Patronymic;//Отчетсво

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
