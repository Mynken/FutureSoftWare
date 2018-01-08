using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Entities
{
    // add Resources
    public class Feedback
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

        [StringLength(700, ErrorMessage = "Значение {0} должно содержать не менее {2} и не больше 700 символов.", MinimumLength = 2)]
        [Required(ErrorMessage = "Введите отзыв")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Ваш отзыв")]
        public string Review { get; set; }

        public DateTime CreatedTime { get; set; }
        public bool isCheked { get; set; } = false;
    }
}

