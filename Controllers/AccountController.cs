using CharityEvents.Data;
using CharityEvents.Data.Static;
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

        public IActionResult Register()
        {
            var respones = new RegisterVM();
            return View(respones);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            //check if exist in db
            var user = await _userManager.FindByEmailAsync(registerVM.EmailAdress);
            if (user != null)
            {
                TempData["Error"] = "Această adresă de email este deja folosita";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAdress,
                UserName = registerVM.EmailAdress
            };
            //add this new user to db
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Bands");
        }
    }
}
