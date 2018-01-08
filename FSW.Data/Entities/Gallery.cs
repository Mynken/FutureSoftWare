using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Entities
{
    public class Gallery
    {
        public int id { get; set; }

        [StringLength(700, ErrorMessage = "Значение {0} должно содержать не менее {2} и не больше 700 символов.", MinimumLength = 2)]
        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Desciption { get; set; }

        [Required(ErrorMessage = "Введите название файла")]
        [Display(Name = "Имя файла")]
        public string FileName { get; set; }
       
    }
}
