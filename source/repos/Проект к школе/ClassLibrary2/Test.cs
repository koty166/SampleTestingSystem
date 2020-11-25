﻿using System;
using System.Collections.Generic;

namespace LessonsResourses
{
    /// <summary>
    /// Предстваляет тест.
    /// </summary>
    [Serializable]
    public class Test
    {
        /// <summary>
        /// Список задач.
        /// </summary>
        public List<Task> Tasks;
        /// <summary>
        /// Имя теста
        /// </summary>
        public string Name;
        /// <summary>
        /// Тип теста
        /// </summary>
        public string Type;
        /// <summary>
        /// Оценка за тест.
        /// </summary>
        public string MarkForTest;
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Test"/>
        /// </summary>
        public Test()
        {
            Tasks = new List<Task>();
            Name = "Test";
            Type = "NoType";
        }
    }
}
