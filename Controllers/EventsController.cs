using CharityEvents.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Controllers
{
    public class EventsController : Controller
    {

        private readonly AppDbContext _context;
        //inject appdbcontext
        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allEvents = await _context.Events.ToListAsync();
            return View(allEvents);
        }
    }
}
