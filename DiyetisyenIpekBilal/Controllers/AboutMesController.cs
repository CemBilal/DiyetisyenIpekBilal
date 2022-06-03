using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiyetisyenIpekBilal.Data;
using DiyetisyenIpekBilal.Models;

namespace DiyetisyenIpekBilal.Controllers
{
    public class AboutMesController : Controller
    {
        private readonly DytIpekBilalDBContext _context;

        public AboutMesController(DytIpekBilalDBContext context)
        {
            _context = context;
        }

        // GET: AboutMes
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.AboutMe.ToListAsync());
            
        }

        // GET: AboutMes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AboutMe == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe
                .FirstOrDefaultAsync(m => m.AboutMeID == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // GET: AboutMes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutMes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutMeID,AboutMee,Titlee,Image")] AboutMe aboutMe)
        {
            Random x = new Random();

            string resimAdi = DateTime.Now.Millisecond.ToString() + x.Next(10000000, 999999999).ToString() + ".jpg";
            aboutMe.ImagePath = "wwwroot/images/AboutMee/"+resimAdi;//database e gidecek olan dosyanin yolunu burdan gosteriyoruz 

                if (ModelState.IsValid)
            {

                if (aboutMe.Image.Length > 0)
                {
                    if (!(aboutMe.Image.ContentType == "image/gif" || aboutMe.Image.ContentType == "image/jpeg" || aboutMe.Image.ContentType == "image/jpg" || aboutMe.Image.ContentType == "image/png"))
                    {
                        return RedirectToAction("Index", "AboutMes");
                    }

                    string resimYolu = "wwwroot/images/AboutMee/" + resimAdi;
                    using var stream = new FileStream(resimYolu, FileMode.Create);
                    await aboutMe.Image.CopyToAsync(stream);
                }


                _context.Add(aboutMe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: AboutMes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AboutMe == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe.FindAsync(id);
            if (aboutMe == null)
            {
                return NotFound();
            }
            return View(aboutMe);
        }

        // POST: AboutMes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AboutMeID,AboutMee,Titlee,ImagePath")] AboutMe aboutMe)
        {
            if (id != aboutMe.AboutMeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutMe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeExists(aboutMe.AboutMeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: AboutMes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AboutMe == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe
                .FirstOrDefaultAsync(m => m.AboutMeID == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // POST: AboutMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AboutMe == null)
            {
                return Problem("Entity set 'DytIpekBilalDBContext.AboutMe'  is null.");
            }
            var aboutMe = await _context.AboutMe.FindAsync(id);

            if (aboutMe != null)
            {
                _context.AboutMe.Remove(aboutMe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutMeExists(int id)
        {
          return _context.AboutMe.Any(e => e.AboutMeID == id);
        }
    }
}
