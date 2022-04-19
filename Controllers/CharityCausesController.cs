using CharityEvents.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Controllers
{
    public class CharityCausesController : Controller
    {
        private readonly AppDbContext _context;
        //inject appdbcontext
        public CharityCausesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCharityCauses = await _context.CharityCauses.ToListAsync();
            return View();
        }
    }
}
