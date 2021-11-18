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
        private readonly DataBaseContext _db;
        public AdminController(DataBaseContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            
            return View();
        }


        [HttpGet]
        public IActionResult AddDriver()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDriver(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _db.drivers.Add(driver);
                _db.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            return View(driver);
        }


        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCity(City city)
        {
            if (ModelState.IsValid)
            {
                _db.cities.Add(city);
                _db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(city);
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
                    ViewBag.Message = "Username or password may incorrect";
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
