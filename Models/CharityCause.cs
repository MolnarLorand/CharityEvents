using CharityEvents.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class CharityCause:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nume Cauza Caritabila")]
        [Required(ErrorMessage = "Câmp obligatoriu")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Câmpul trebuie sa contina intre 3 si 50 de caractere")]
        public String Name { get; set; }

        [Display(Name = "Imagine")]
        [Required(ErrorMessage = "Câmp obligatoriu")]

        public String Image { get; set; }

        [Display(Name = "Descriere")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Câmpul trebuie sa contina intre 3 si 150 de caractere")]
        [Required(ErrorMessage = "Câmp obligatoriu")]

        public String Description { get; set; }

        //Relationship
        public List<Band> Bands { get; set; }
    }
}
