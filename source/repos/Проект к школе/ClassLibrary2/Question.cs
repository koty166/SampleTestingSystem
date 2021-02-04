using System;

namespace LessonsResourses
{
    /// <summary>
    /// Представляет вопрос. 
    /// </summary>
    [Serializable]
    public class Question
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string QuestionText;
        /// <summary>
        /// Имя вопроса
        /// </summary>
        public string Name;
        /// <summary>
        /// Ответ на вопрос, до опроса содержит варианты ответов через пробел или null, если вопрос не предпологает варианты ответа.
        /// После опроса содержит ответ.
        /// </summary>
        public string Answer;
        /// <summary>
        /// Имя и расширение картинки или null, если картинка не предпологается.
        /// </summary>
        public string PicturePath;
        /// <summary>
        /// Оценка за задание. Допускает null.
        /// </summary>
        public string Mark;
        /// <summary>
        /// Время, потраченное на вопрос [c].
        /// </summary>
        public int TimeForQuestion;
        /// <summary>
        /// Тэг вопроса, допускает null.
        /// </summary>
        public string Tag;

        /// <summary>
        /// Иницирует новый экземпляр класса <see cref="Question"/>
        /// </summary>
        public Question()
        {
            QuestionText = "Нет вопроса, если ты это видишь, сообщи старшему";
            Answer = null;
            PicturePath = null;
            Mark = null;
            Tag = null;
            Name = "Вопрос";
        }

    }
}
