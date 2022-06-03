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
    public class UserrsController : Controller
    {
        private readonly DytIpekBilalDBContext _context;

        public UserrsController(DytIpekBilalDBContext context)
        {
            _context = context;
        }

        // GET: Userrs
        public async Task<IActionResult> Index()
        {
            var dytIpekBilalDBContext = _context.Userrs.Include(u => u.Rolee);
            return View(await dytIpekBilalDBContext.ToListAsync());
        }

        // GET: Userrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Userrs == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs
                .Include(u => u.Rolee)
                .FirstOrDefaultAsync(m => m.UserrID == id);
            if (userr == null)
            {
                return NotFound();
            }

            return View(userr);
        }

        // GET: Userrs/Create
        public IActionResult Create()
        {
            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName");
            return View();
        }

        // POST: Userrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserrID,Name,Surname,Emaill,Password,PhoneNumber,Image,RoleeID")] Userr userr)
        {
            Random x = new Random();

            string resimAdi = DateTime.Now.Millisecond.ToString() + x.Next(10000000, 999999999).ToString() + ".jpg";
            userr.ImagePath = "wwwroot/images/Userr/" + resimAdi;//database e gidecek olan dosyanin yolunu burdan gosteriyoruz 
            if (ModelState.IsValid)
            {

                if (userr.Image.Length > 0)
                {
                    if (!(userr.Image.ContentType == "image/gif" || userr.Image.ContentType == "image/jpeg" || userr.Image.ContentType == "image/jpg" || userr.Image.ContentType == "image/png"))
                    {
                        return RedirectToAction("Index", "Userrs");
                    }

                    string resimYolu = "wwwroot/images/Userr/" + resimAdi;
                    using var stream = new FileStream(resimYolu, FileMode.Create);
                    await userr.Image.CopyToAsync(stream);
                }



                _context.Add(userr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                _context.Add(userr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName", userr.RoleeID);
            return View(userr);
        }

        // GET: Userrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userrs == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs.FindAsync(id);
            if (userr == null)
            {
                return NotFound();
            }
            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName", userr.RoleeID);
            return View(userr);
        }

        // POST: Userrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserrID,Name,Surname,Emaill,Password,PhoneNumber,ImagePath,RoleeID")] Userr userr)
        {
            if (id != userr.UserrID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserrExists(userr.UserrID))
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
            ViewData["RoleeID"] = new SelectList(_context.Rolees, "RoleeID", "RoleeName", userr.RoleeID);
            return View(userr);
        }

        // GET: Userrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userrs == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs
                .Include(u => u.Rolee)
                .FirstOrDefaultAsync(m => m.UserrID == id);
            if (userr == null)
            {
                return NotFound();
            }

            return View(userr);
        }

        // POST: Userrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userrs == null)
            {
                return Problem("Entity set 'DytIpekBilalDBContext.Userrs'  is null.");
            }
            var userr = await _context.Userrs.FindAsync(id);
            if (userr != null)
            {
                _context.Userrs.Remove(userr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserrExists(int id)
        {
          return (_context.Userrs?.Any(e => e.UserrID == id)).GetValueOrDefault();
        }
    }
}
