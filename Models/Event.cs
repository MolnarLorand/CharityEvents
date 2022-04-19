using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nume Eveniment")]
        public String EventName { get; set; }

        [Display(Name = "Logo")]
        public String Logo { get; set; }

        [Display(Name = "Perioada desfasurare")]
        public DateTime EventPeriod { get; set; }

        [Display(Name = "Descriere")]
        public String Description { get; set; }

        //Rel
        public List<Event_Band> Events_Bands { get; set; }
    }
}
