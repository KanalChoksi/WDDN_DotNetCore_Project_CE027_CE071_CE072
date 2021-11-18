using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texi_Booking.Models;

namespace Texi_Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly DataBaseContext _context;

        public BookingController(DataBaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Book()
        {
            List<City> citylist = new List<City>();
            citylist = (from c in _context.cities select c).ToList();
            citylist.Insert(0, new City { Id = 0, Cities = "Select City" });
            ViewBag.message = citylist;

            List<Taxi> taxi = new List<Taxi>();
            taxi = (from t in _context.Taxi select t).ToList();
            taxi.Insert(0, new Taxi { id = 0, Taxiname = "Select Car" });
            ViewBag.message1 = taxi;
            return View();
            
        }
        [HttpPost]
        public IActionResult Book(BookTaxi obj)
        {
            if (ModelState.IsValid)
            {
                _context.bookTaxis.Add(obj);
                _context.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            return View(obj);
        }
    }
}
