using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Range(5, 18, ErrorMessage = "Указан неправельный возраст")]
        public byte Age { get;set; }
        /// <summary>
        /// Класс, от 1 до 11
        /// </summary>
        [Required]
        [Range(1,11,ErrorMessage = "Указан неверный номер класса")]
        public byte Form { get; set; }
        /// <summary>
        /// Имя, от 2 до 20 символов. Не допускает содержание управляющих последовательностей.
        /// </summary>
        [Required(ErrorMessage ="Не указано имя")]
        [StringLength(20,MinimumLength = 2,ErrorMessage = "Имя должно содержать от 2 до 20 букв")]
        [RegularExpression(@"[\w]+[\s]?[-]?[\w]*$",ErrorMessage = "Недопустимы управляющие последовательности в имени, тройные имена")]
        /// <summary>
        /// Фамилия, от 2 до 20 символов. Не допускает содержание управляющих последовательностей.
        /// </summary>
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия должно содержать от 2 до 20 букв")]
        [RegularExpression(@"[\w]+[\s]?[-]?[\w]*$", ErrorMessage = "Недопустимы управляющие последовательности в фамилии, тройные фамилии")]
        /// <summary>
        /// Отчество, до 20 символов. Не допускает содержание управляющих последовательностей.
        /// </summary>
        public string Surname { get; set; }
        [Required(AllowEmptyStrings = true)]
        [StringLength(20, ErrorMessage = "Отчество должно содержать до 20 букв")]
        [RegularExpression(@"[\w]*[\s]?[-]?[\w]*$", ErrorMessage = "Недопустимы управляющие последовательности в отчестве")]
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
