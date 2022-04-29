using CharityEvents.Data.Base;
using CharityEvents.Data.ViewModels;
using CharityEvents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Services
{
    public class BandsService : EntityBaseRepository<Band>, IBandsService
    {
        private readonly AppDbContext _context;
        //pass as a parameter to the base class the appdbcontext
        public BandsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBandAsync(NewBandVM info)
        {
            //create a new band object
            var newBand = new Band()
            {
                Name = info.Name,
                Description = info.Description,
                Logo = info.Logo,
                DonationPrice = info.DonationPrice,
                ConcertDate = info.ConcertDate,
                BandCategory = info.BandCategory,
                BandMembers = info.BandMembers,
                CharityCauseId = info.CharityCauseId
            };
            await _context.Bands.AddAsync(newBand); //add the obj to context
            await _context.SaveChangesAsync();

            //Add band-event
            foreach (var eventId in info.EventIds)
            {
                var newEventBand = new Event_Band()
                {
                    BandId = newBand.Id,
                    EventId = eventId
                };
                await _context.Events_Bands.AddAsync(newEventBand);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Band> GetBandByIdAsync(int id)
        {
            var bandDetails = await _context.Bands
                .Include(c => c.CharityCause)
                .Include(eb => eb.Events_Bands).ThenInclude(e => e.Event) //here i have the join model, so in order to include the event i need to use ThenInclude
                .FirstOrDefaultAsync(m => m.Id == id);

            return bandDetails;
        }

        public async Task<NewBandDropdownsVM> GetNewBandDropdownsValues()
        {
            var result = new NewBandDropdownsVM()
            {
                CharityCauses = await _context.CharityCauses.OrderBy(m => m.Name).ToListAsync(),
                Events = await _context.Events.OrderBy(m => m.EventName).ToListAsync()
            };
            return result;
        }

        public async Task UpdateBandAsync(NewBandVM info)
        {
            //get the band
            var dbBand = await _context.Bands.FirstOrDefaultAsync(m => m.Id == info.Id);
            if(dbBand != null)
            {
                
                dbBand.Name = info.Name;
                dbBand.Description = info.Description;
                dbBand.Logo = info.Logo;
                dbBand.DonationPrice = info.DonationPrice;
                dbBand.ConcertDate = info.ConcertDate;
                dbBand.BandCategory = info.BandCategory;
                dbBand.BandMembers = info.BandMembers;
                dbBand.CharityCauseId = info.CharityCauseId;            
                await _context.SaveChangesAsync();
            }

            //Remove existing events
            var existingEventsDb = _context.Events_Bands.Where(m => m.BandId == info.Id).ToList();
            _context.Events_Bands.RemoveRange(existingEventsDb);
            await _context.SaveChangesAsync();
            //idk why is not working


            //Add band-event
            foreach (var eventId in info.EventIds)
            {
                var newEventBand = new Event_Band()
                {
                    BandId = info.Id,
                    EventId = eventId
                };
                await _context.Events_Bands.AddAsync(newEventBand);
            }
            await _context.SaveChangesAsync();
        }
    }
}
