using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class Event_Band
    {
        public int BandId { get; set; }

        public Band Band { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; } 
    }
}
