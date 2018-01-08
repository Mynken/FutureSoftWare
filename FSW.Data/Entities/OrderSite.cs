using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FSW.Data.Entities
{   // Add Resources
    public class OrderSite
    {
        public int id { get; set; }

        [StringLength(40, ErrorMessage = "Значение {0} должно содержать не менее {2} и не больше 40 символов.", MinimumLength = 2)]
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [StringLength(40, ErrorMessage = "Значение {0} должно содержать не менее {2} и не больше 40 символов.", MinimumLength = 2)]
        [Required(ErrorMessage = "Введите фимилию")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Введите e-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Тарифный план")]
        public string TariffPlan { get; set; }

        [StringLength(700, ErrorMessage = "Значение {0} должно содержать не менее {2} и не больше 700 символов.", MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Дополнительная информация")]
        public string Notes { get; set; }
        public bool isCheked { get; set; } = false;

        public IEnumerable<SelectListItem> Tariffs;
    }
}
