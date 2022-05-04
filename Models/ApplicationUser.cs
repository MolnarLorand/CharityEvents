using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class ApplicationUser:IdentityUser
    {
        //additional prop to identityuser-> add col in db
        [Display(Name = "Nume Complet")]
        public string FullName { get; set; }
    }
}
