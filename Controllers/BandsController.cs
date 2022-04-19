using CharityEvents.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Controllers
{
    public class BandsController : Controller
    {
        private readonly AppDbContext _context;
        //inject appdbcontext
        public BandsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allBands = await _context.Bands.ToListAsync();
            return View();
        }
    }
}
