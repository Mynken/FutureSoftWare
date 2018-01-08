using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Entities
{
    public class AskQuestion
    {
        public int id { get; set; }

        [StringLength(40, ErrorMessage = "Значение {0} должно содержать не менее {2} и не больше 40 символов.", MinimumLength = 2)]
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Введите e-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(700, ErrorMessage = "Значение {0} должно содержать не менее {2} и не больше 700 символов.", MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Введите Ваш вопрос")]
        [Display(Name = "Сообщение")]
        public string TextMessage { get; set; }
        public bool isCheked { get; set; } = false;
    }
}
