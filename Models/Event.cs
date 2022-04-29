using CharityEvents.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class Event:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nume Eveniment")]
        [Required(ErrorMessage ="Câmp obligatoriu")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Câmpul trebuie sa contina intre 3 si 50 de caractere")]
        public String EventName { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Câmp obligatoriu")]
        public String Logo { get; set; }

        [Display(Name = "Perioada desfasurare")]
        [Required(ErrorMessage = "Câmp obligatoriu")]
        public DateTime EventPeriod { get; set; }

        [Display(Name = "Descriere")]
        [Required(ErrorMessage = "Câmp obligatoriu")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Câmpul trebuie sa contina intre 3 si 150 de caractere")]

        public String Description { get; set; }

        //Rel
        public List<Event_Band> Events_Bands { get; set; }
    }
}
