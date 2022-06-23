using CharityEvents.Data;
using CharityEvents.Data.Services;
using CharityEvents.Data.Static;
using CharityEvents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CharityCausesController : Controller
    {
        private readonly ICharityCauseService _service;
        //inject appdbcontext
        public CharityCausesController(ICharityCauseService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCharityCauses = await _service.GetAllAsync(); //use the charity service instead of context
            return View(allCharityCauses);
        }

        //get: /details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var CharityCauseDetails = await _service.GetByIdAsync(id);
            if (CharityCauseDetails == null) //if is null
                return View("NotFound");
            return View(CharityCauseDetails);
        }

        //get /create
        public IActionResult Create()
        {
            // when the user click the adauga button i redirect him here
            //to create 1. i display this empty view ->simple get request -> after fill the data and press create button
            // 2. Send post request to controller 
            return View();
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Image, Description")] CharityCause charityCause)
        {
            if (!ModelState.IsValid)//if is not valid
                return View(charityCause);

            await _service.AddAsync(charityCause);
            return RedirectToAction(nameof(Index));
        }

        //get /update
        //1. similar to create-> first get the data and after send a post request to update
        public async Task<IActionResult> Edit(int id)
        {
            var charityCauseDetails = await _service.GetByIdAsync(id);  //check if exist
            if (charityCauseDetails == null)
                return View("NotFound");

            return View(charityCauseDetails);
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, Image, Description")] CharityCause charityCause) //id from request url
        {
            if (!ModelState.IsValid)//if is not valid
                return View(charityCause);

            if (id == charityCause.Id) //id from url == chcause.id
            {
                await _service.UpdateAsync(id, charityCause);
                return RedirectToAction(nameof(Index));
            }

            return View(charityCause);
        }

        //Get /delete.id
        public async Task<IActionResult> Delete(int id)
        {
            var charityCauseDetails = await _service.GetByIdAsync(id);  //check if exist
            if (charityCauseDetails == null)
                return View("NotFound");

            return View(charityCauseDetails);
        }

        //post
        [HttpPost] //define actionname if a want to use the same name, ex Delete 
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            var charityCauseDetails = await _service.GetByIdAsync(id);  //check if exist
            if (charityCauseDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
