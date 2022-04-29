using CharityEvents.Data;
using CharityEvents.Data.Services;
using CharityEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Controllers
{
    public class BandsController : Controller
    {
        private readonly IBandsService _service;
        //inject appdbcontext
        public BandsController(IBandsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allBands = await _service.GetAllAsync();
            return View(allBands);
        }

        //get /details/id
        public async Task<IActionResult> Details(int id)
        {
            var bandDetail = await _service.GetBandByIdAsync(id);
            return View(bandDetail);
        }

        //get /create
        public async Task<IActionResult> Create()
        {
            var bandDropdownsData = await _service.GetNewBandDropdownsValues();

            //2 select list to bind with the select in the view
            ViewBag.CharityCauses = new SelectList(bandDropdownsData.CharityCauses, "Id", "Name");
            ViewBag.Events = new SelectList(bandDropdownsData.Events, "Id", "EventName");

            return View();
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Create(NewBandVM band)
        {
            //validate the model
            if (!ModelState.IsValid)
            {
                var bandDropdownsData = await _service.GetNewBandDropdownsValues();
                ViewBag.CharityCauses = new SelectList(bandDropdownsData.CharityCauses, "Id", "Name");
                ViewBag.Events = new SelectList(bandDropdownsData.Events, "Id", "EventName");
                return View(band);
            }
            await _service.AddNewBandAsync(band);
            return RedirectToAction(nameof(Index));
        }


        //get /edit/id   -> the get the data
        public async Task<IActionResult> Edit(int id)
        {
            var bandDetails = await _service.GetBandByIdAsync(id);
            if (bandDetails == null)
                return View("NotFound");

            var respones = new NewBandVM()
            {
                Id = bandDetails.Id,
                Name = bandDetails.Name,
                Description = bandDetails.Description,
                DonationPrice = bandDetails.DonationPrice,
                Logo = bandDetails.Logo,
                BandCategory = bandDetails.BandCategory,
                BandMembers = bandDetails.BandMembers,
                ConcertDate = bandDetails.ConcertDate,
                CharityCauseId = bandDetails.CharityCauseId,
                EventIds = bandDetails.Events_Bands.Select(m => m.EventId).ToList()
            };

            var bandDropdownsData = await _service.GetNewBandDropdownsValues();

            //2 select list to bind with the select in the view
            ViewBag.CharityCauses = new SelectList(bandDropdownsData.CharityCauses, "Id", "Name");
            ViewBag.Events = new SelectList(bandDropdownsData.Events, "Id", "EventName");

            return View(respones);
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBandVM band)
        {
            if (id != band.Id)
                return View("NotFound");

            //validate the model
            if (!ModelState.IsValid)
            {
                var bandDropdownsData = await _service.GetNewBandDropdownsValues();
                ViewBag.CharityCauses = new SelectList(bandDropdownsData.CharityCauses, "Id", "Name");
                ViewBag.Events = new SelectList(bandDropdownsData.Events, "Id", "EventName");
                return View(band);
            }
            await _service.UpdateBandAsync(band);
            return RedirectToAction(nameof(Index));
        }

    }
}
