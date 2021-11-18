using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Texi_Booking.Models;

namespace Texi_Booking.Controllers
{
    public class TaxisController : Controller
    {
        private readonly DataBaseContext _context;

        public TaxisController(DataBaseContext context)
        {
            _context = context;
        }
       
        // GET: Taxis
        public async Task<IActionResult> Index()
        {
           if( HttpContext.Session.GetString("Username")==null)
           {
                return RedirectToAction("Login", "Admin");
            }
            return View(await _context.Taxi.ToListAsync());
        }

        // GET: Taxis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return RedirectToAction("Index");
                //return NotFound();
            }

            var taxi = await _context.Taxi
                .FirstOrDefaultAsync(m => m.id == id);
            if (taxi == null)
            {
                return RedirectToAction("Index");
            }

            return View(taxi);
        }

        [HttpGet]

        // GET: Taxis/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        // POST: Taxis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public async Task<IActionResult> Create(Taxi taxi, List<IFormFile> image)
        {
            
            string fileName = null;
            if (ModelState.IsValid)
            {
                var query1 = _context.Taxi.Where(t => t.Taxinumer == taxi.Taxinumer);
                if(query1.Count()!=0)
                {
                    ViewBag.Message = "This taxi number is already exist in out database";
                    return View();
                }
                foreach (var i in image)
                {
                    if (i.Length > 0)
                    {
                        fileName = System.IO.Path.GetFileName(i.FileName);
                        using (var stream = new MemoryStream())
                        {
                            await i.CopyToAsync(stream);
                            taxi.image = stream.ToArray();

                        }
                    }
                }
                if(taxi.image == null)
                {
                    ViewBag.Message = "Upload photo";
                    return View();
                }
                if(taxi.status != 1)
                {
                    if (taxi.status != 0)
                    {
                        ViewBag.Message1 = "if available taxi than enter status 1 else 0";
                      return View();
                    }
                }
                TempPhoto photo = new TempPhoto();
                if (fileName.EndsWith(".png") || fileName.EndsWith(".jpg"))
                { 

                    _context.Taxi.Add(taxi);
                    _context.SaveChanges();
                    var query = _context.Taxi.Where(t => t.Taxinumer == taxi.Taxinumer).FirstOrDefault();
                    photo.taxiid = taxi.id.ToString();
                    photo.image = query.image;
                    _context.Photo.Add(photo);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Message1 = "Please Enter Jpg or PNG format";
            }
            return View(taxi);
        }

        // GET: Taxis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var taxi = await _context.Taxi.FindAsync(id);
            if (taxi == null)
            {
                return NotFound();
            }
            return View(taxi);
        }

        // POST: Taxis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Taxi taxi,List<IFormFile> image)
        {
            if (id != taxi.id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                string fileName = null;
                var photo = taxi.image;
                ViewBag.Message = photo;
                foreach (var i in image)
                {
                    if (i.Length > 0)
                    {
                        fileName = System.IO.Path.GetFileName(i.FileName);
                        using (var stream = new MemoryStream())
                        {
                            await i.CopyToAsync(stream);
                            taxi.image = stream.ToArray();

                        }
                    }
                }

                var query = _context.Photo.Where(p => p.taxiid == (id.ToString())).FirstOrDefault();
                if (taxi.image != null)
                {
                   
                    query.image = taxi.image;
                    _context.Photo.Update(query);
                    _context.Taxi.Update(taxi);
                        await _context.SaveChangesAsync();
                   
                    
                     return RedirectToAction(nameof(Index));
                }
                if (taxi.image == null)
                {
                    taxi.image = query.image;
                    _context.Taxi.Update(taxi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
             
                
            }
            return View();
        }

        // GET: Taxis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var taxi = await _context.Taxi
                .FirstOrDefaultAsync(m => m.id == id);
          
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // POST: Taxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxi = await _context.Taxi.FindAsync(id);
            var photo = await _context.Photo.FirstOrDefaultAsync(p => p.taxiid == (id.ToString()));
            _context.Taxi.Remove(taxi);
            _context.Photo.Remove(photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxiExists(int id)
        {
            return _context.Taxi.Any(e => e.id == id);
        }
    }
}
