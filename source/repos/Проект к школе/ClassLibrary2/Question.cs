using System;

namespace LessonsResourses
{
    /// <summary>
    /// Предстовляет вопрос. 
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
        /// Иницирует новый экземпляр класса <see cref="Question"/>
        /// </summary>
        public Question()
        {
            QuestionText = "Нет вопроса, если ты это видишь, сообщи старшему";
            Answer = null;
            PicturePath = null;
            Name = "Вопрос";
        }

    }
}
