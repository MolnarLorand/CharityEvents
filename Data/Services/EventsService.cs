using CharityEvents.Data.Base;
using CharityEvents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Services
{
    public class EventsService : EntityBaseRepository<Event>, IEventsService
    {

        public EventsService(AppDbContext context) : base(context)
        { }//inject context

    }
}
