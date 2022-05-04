using CharityEvents.Data;
using CharityEvents.Data.ViewModels;
using CharityEvents.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Controllers
{
    public class AccountController : Controller
    {

        //inject usermanager singinmanager appdbcontext
        private readonly UserManager<ApplicationUser> _userManager;//custom-identity user file --> use to work with user related data
        private readonly SignInManager<ApplicationUser> _signInManager; // check if user is signed etc
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var respones = new LoginVM();
            return View(respones);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM) //use to handle a  request from a form => http post 
        {
            if (!ModelState.IsValid) return View(loginVM);

            //check if user exist in db
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);
            if (user != null)
            {
                //check for pw
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)//if is valid
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //display error
                TempData["Error"] = "Credențiale greșite, vă rog încercați din nou";
                return View(loginVM);
            }
            //display error
            TempData["Error"] = "Credențiale greșite, vă rog încercați din nou";
            return View(loginVM);
        }
    }
}
