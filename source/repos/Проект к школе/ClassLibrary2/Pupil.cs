using System;
using System.Collections.Generic;

namespace LessonsResourses
{
    /// <summary>
    /// Представляет тестируемого
    /// </summary>
    [Serializable]
    public class Pupil
    {
        /// <summary>
        /// Возраст, принимает значения от 5 до 18 лет
        /// </summary>

        public byte Age { get;set; }
        /// <summary>
        /// Класс, от 1 до 11
        /// </summary>

        public byte Form { get; set; }
        /// <summary>
        /// Имя, от 2 до 20 символов. Не допускает содержание управляющих последовательностей.
        /// </summary>

        /// <summary>
        /// Фамилия, от 2 до 20 символов. Не допускает содержание управляющих последовательностей.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество, до 20 символов. Не допускает содержание управляющих последовательностей.
        /// </summary>
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        /// <summary>
        /// Оценка за тест.
        /// </summary>
        public string MarkForTest;
        /// <summary>
        /// Половая принадлежность
        /// </summary>
        public bool IsMale;
        /// <summary>
        /// Список выполненых тестов. Для интеграции в бд.
        /// </summary>
        public List<Test> DoneTest;
        /// <summary>
        /// Инициализирует новый экцемпляр класса <see cref="Pupil"/>
        /// </summary>
        public Pupil() { DoneTest = new List<Test>(); }
    }
   
}
