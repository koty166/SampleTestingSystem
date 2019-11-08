using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект_к_школе
{
    [Serializable]
    public class Lesson
    {
        public List<object> QuestionList = new List<object>();
        public String Name;

        public object [] args = new object [5];
    }
}
