using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Câmp obligatoriu")]
        [Display(Name = "Adresa Email")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [DataType(DataType.Password)] //hidden text
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}
