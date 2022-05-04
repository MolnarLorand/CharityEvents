using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Câmpul nume este obligatoriu")]
        [Display(Name = "Nume")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Câmpul email este obligatoriu")]
        [Display(Name = "Adresa Email")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Câmpul parolă este obligatoriu")]
        [DataType(DataType.Password)] //hidden text
        [Display(Name = "Parolă")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Câmpul confirmare parolă este obligatoriu")]
        [DataType(DataType.Password)] //hidden text
        [Display(Name = "Confirmare Parolă")]
        [Compare("Password",ErrorMessage ="Parola nu coincie")]
        public string ConfirmPassword { get; set; }
    }
}
