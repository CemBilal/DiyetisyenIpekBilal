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
    public class AchievementsController : Controller
    {
        private readonly DytIpekBilalDBContext _context;

        public AchievementsController(DytIpekBilalDBContext context)
        {
            _context = context;
        }

        // GET: Achievements
        public async Task<IActionResult> Index()
        {
              return View(await _context.Achievement.ToListAsync());
        }

        // GET: Achievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Achievement == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement
                .FirstOrDefaultAsync(m => m.AchievementID == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // GET: Achievements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AchievementID,Name,Image")] Achievement achievement)
        {
            Random x = new Random();

            string resimAdi = DateTime.Now.Millisecond.ToString() + x.Next(10000000, 999999999).ToString() + ".jpg";
            achievement.ImagePath = "wwwroot/images/Achievements/" + resimAdi;//database e gidecek olan dosyanin yolunu burdan gosteriyoruz 

            if (ModelState.IsValid)
            {


                if (achievement.Image.Length > 0)
                {
                    if (!(achievement.Image.ContentType == "image/gif" || achievement.Image.ContentType == "image/jpeg" || achievement.Image.ContentType == "image/jpg" || achievement.Image.ContentType == "image/png"))
                    {
                        return RedirectToAction("Index", "Achievements");
                    }

                    string resimYolu = "wwwroot/images/Achievements/" + resimAdi;
                    using var stream = new FileStream(resimYolu, FileMode.Create);
                    await achievement.Image.CopyToAsync(stream);
                }



                _context.Add(achievement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(achievement);
        }

        // GET: Achievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Achievement == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }
            return View(achievement);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AchievementID,Name,ImagePath")] Achievement achievement)
        {
            if (id != achievement.AchievementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementExists(achievement.AchievementID))
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
            return View(achievement);
        }

        // GET: Achievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Achievement == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement
                .FirstOrDefaultAsync(m => m.AchievementID == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Achievement == null)
            {
                return Problem("Entity set 'DytIpekBilalDBContext.Achievement'  is null.");
            }
            var achievement = await _context.Achievement.FindAsync(id);
            if (achievement != null)
            {
                _context.Achievement.Remove(achievement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementExists(int id)
        {
          return _context.Achievement.Any(e => e.AchievementID == id);
        }
    }
}
