using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texi_Booking.Models;

namespace Texi_Booking.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLogin admin)
        {
            
                if (admin.Username != null && admin.Password != null)
                {
                    if (admin.Username == "admin" && admin.Password == "admin@123")
                    {
                        HttpContext.Session.SetString("Username", admin.Username);
                        return RedirectToAction("Index","Taxis");
                    }
                    ViewBag.Message = "Username or password may incorect";
                    return View();
                }
                return View();
            
            

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
       
    }
}
