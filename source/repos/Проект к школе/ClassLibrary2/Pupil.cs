using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary2
{
    [Serializable]
    public class Pupil
    {
        [Required]
        [Range(1,18,ErrorMessage = "Указан неправельный возраст")]
        public byte Age;
        [Required]
        [Range(1,11,ErrorMessage = "Указан неверный номер класса")]
        public byte Form;
        [Required(AllowEmptyStrings = false)]
        [StringLength(20,MinimumLength = 2,ErrorMessage = "Имя должно содержать от 2 до 20 букв")]
        public string Name;
        [Required(AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия должно содержать от 2 до 20 букв")]
        public string Surname;
        [Required(AllowEmptyStrings = true)]
        [StringLength(20, ErrorMessage = "Отчество должно содержать от 2 до 20 букв")]
        public string Patronymic;
        public string MarkForTest;
        public string[] args = new string[5];
        public bool IsMale;

        public List<string> AnswerList = new List<string>();

        public Pupil() {  }

        public Pupil(byte _Age, byte _Form, string _Name, string _Surname, string _Patronymic)
        {
            this.Age = _Age;
            this.Form = _Form;
            this.Name = _Name;
            this.Surname = _Surname;
            this.Patronymic = _Patronymic;
        }
    }
   
}
