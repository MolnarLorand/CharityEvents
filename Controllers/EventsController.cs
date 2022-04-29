using CharityEvents.Data;
using CharityEvents.Data.Services;
using CharityEvents.Models;
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

        private readonly IEventsService _service;
        //inject the ieventsservice
        public EventsController(IEventsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync();
            return View(allEvents);
        }

        //Get: events/create
        public IActionResult Create() //not using async bc i do not have any data manipulation
        {
            return View();
        }


        [HttpPost] //in create i have submit that will be sent to the create action result
        public async Task<IActionResult> Create([Bind("EventName,Logo,EventPeriod,Description")] Event NewEvent)
        {
            if (!ModelState.IsValid) //check if is required or not
            {
                return View(NewEvent);
            }
            await _service.AddAsync(NewEvent);
            return RedirectToAction(nameof(Index));
        }

        // Get: details/id
        public async Task<IActionResult> Details(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);

            if (eventDetails == null)
                return View("NotFound");

            return View(eventDetails);
        }

        //Get: edit/id
        public async Task<IActionResult> Edit(int id) //not using async bc i do not have any data manipulation
        {
            var eventDetails = await _service.GetByIdAsync(id);

            if (eventDetails == null)
                return View("NotFound");

            return View(eventDetails);
        }


        [HttpPost] //in create i have submit that will be sent to the create action result
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventName,Logo,EventPeriod,Description")] Event NewEvent)//i have all i cand remove the bind
        {
            if (!ModelState.IsValid) //check if is required or not
            {
                return View(NewEvent);
            }
            await _service.UpdateAsync(id,NewEvent);
            return RedirectToAction(nameof(Index));
        }


        //Get: delete/id
        public async Task<IActionResult> Delete(int id) //not using async bc i do not have any data manipulation
        {
            var eventDetails = await _service.GetByIdAsync(id);

            if (eventDetails == null)
                return View("NotFound");

            return View(eventDetails);
        }


        [HttpPost] 
        public async Task<IActionResult> DeleteConfirmed(int id)//i have all i cand remove the bind
        {
            var eventDetails = await _service.GetByIdAsync(id);//check if the event exist or not
            if (eventDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
