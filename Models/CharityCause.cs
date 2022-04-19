using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Models
{
    public class CharityCause
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public String Image { get; set; }

        public String Description { get; set; }

        //Rel
        public List<Band> Bands { get; set; }
    }
}
