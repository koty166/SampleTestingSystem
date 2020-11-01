using System;
using System.Collections.Generic;

namespace LessonsResourses
{
    /// <summary>
    /// Представляет задание. Оно содержит список вопросов для тестируемого.
    /// </summary>
    [Serializable]
    public class Task
    {
        /// <summary>
        /// Список вопросов для тестируемого
        /// </summary>
        public List<Question> Questions;
        /// <summary>
        /// Имя задания
        /// </summary>
        public String Name;
        /// <summary>
        /// Время для ответов на все вопросы в задинии. В секундах
        /// </summary>
        public int TimeToAnswer;
        /// <summary>
        /// Описание задания
        /// </summary>
        public String Description;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Task"/>
        /// </summary>
        public Task()
        {
            Questions = new List<Question>();
            Name = "Task";
            TimeToAnswer = 0;
            Description = "Нет описания. Если ты это видишь, обратись к старшему";
        }
    }
}
