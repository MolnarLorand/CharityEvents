using CharityEvents.Data;
using CharityEvents.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class Band:IEntityBase
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String BandMembers { get; set; }

        public String Description { get; set; }

        public Double DonationPrice { get; set; }

        public String Logo { get; set; }

        public DateTime ConcertDate { get; set; }

        public BandCategory BandCategory { get; set; }

        //Rel
        public List<Event_Band> Events_Bands { get; set; }


        //rel with causes
        public int CharityCauseId { get; set; }
        [ForeignKey("CharityCauseId")]

        public CharityCause CharityCause { get; set; }
    }
}
