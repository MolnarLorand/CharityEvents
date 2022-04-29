using CharityEvents.Data;
using CharityEvents.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class NewBandVM
    {
        public int  Id { get; set; }

        [Required(ErrorMessage ="Câmp obligatoriu")]
        [Display(Name="Nume trupa")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Câmpul trebuie sa contina intre 3 si 50 de caractere")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Nume membrii trupa")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Câmpul trebuie sa contina intre 3 si 250 de caractere")]
        public String BandMembers { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Descriere")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Câmpul trebuie sa contina intre 3 si 250 de caractere")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Valoare Donatie")]
        public Double DonationPrice { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Logo-URL")]
        public String Logo { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Data Concert")]
        public DateTime ConcertDate { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Selectează categoria")]
        public BandCategory BandCategory { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Selectează evenimentul")]
        public List<int> EventIds { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Display(Name = "Selectează cauza caritabilă")]
        public int CharityCauseId { get; set; }

    }
}
