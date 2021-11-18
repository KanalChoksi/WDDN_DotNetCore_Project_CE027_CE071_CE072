using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texi_Booking.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public CustomerController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CustomerRegistration()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CustomerRegistration(Texi_Booking.Models.CustomerRegistration model)
        {
            if (ModelState.IsValid)
            {
                
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

              
                var result = await userManager.CreateAsync(user, model.Password);

                
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

              
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

            [HttpGet]
        public IActionResult CustomerLogin()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CustomerLogin(Texi_Booking.Models.CustomerLogin model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}
