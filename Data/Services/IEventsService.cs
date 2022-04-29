using CharityEvents.Data.Base;
using CharityEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Services
{
    public interface IEventsService:IEntityBaseRepository<Event>
    {
        //define method signature
        //interface is only the contract
/*        Task <IEnumerable<Event>> GetAllAsync();

        Task<Event> GetEventByIdAsync(int id);

        Task AddEventAsync(Event NewEvent);

        Task<Event> UpdateEventAsync(int id, Event newEvent);//id bc i check if id exist in db

        Task DeleteEventAsync(int id);*/
//i use ientitybaserepository instead of repeating the code
    }
}
