using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisLibrary
{
    internal class Marker
    {
        /// <summary>
        /// Тэг вопросов, которые необходимо проверить, не допускает null.
        /// </summary>
        internal string Tag;
        /// <summary>
        /// Число провереных вопросов с искомым тэгом.
        /// </summary>
        internal int Num;
        internal Marker()
        {
            Tag = "No tag";
            Num = 0;
        }
    }
}
