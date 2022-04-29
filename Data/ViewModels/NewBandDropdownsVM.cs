using CharityEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.ViewModels
{
    public class NewBandDropdownsVM
    {
        public NewBandDropdownsVM() //make this ctor bc i don't need a new instance of events or charity
        {
            CharityCauses = new List<CharityCause>();
            Events = new List<Event>();
        }

        public List<CharityCause> CharityCauses { get; set; }
       
        public List<Event> Events { get; set; }
    }
}
