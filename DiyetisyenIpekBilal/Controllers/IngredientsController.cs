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
    public class IngredientsController : Controller
    {
        private readonly DytIpekBilalDBContext _context;

        public IngredientsController(DytIpekBilalDBContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var dytIpekBilalDBContext = _context.Ingredients.Include(i => i.recipe);
            return View(await dytIpekBilalDBContext.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredients = await _context.Ingredients
                .Include(i => i.recipe)
                .FirstOrDefaultAsync(m => m.IngredientsID == id);
            if (ingredients == null)
            {
                return NotFound();
            }

            return View(ingredients);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientsID,IngredientsName,RecipeID")] Ingredients ingredients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID", ingredients.RecipeID);
            return View(ingredients);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredients = await _context.Ingredients.FindAsync(id);
            if (ingredients == null)
            {
                return NotFound();
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID", ingredients.RecipeID);
            return View(ingredients);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientsID,IngredientsName,RecipeID")] Ingredients ingredients)
        {
            if (id != ingredients.IngredientsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientsExists(ingredients.IngredientsID))
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
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID", ingredients.RecipeID);
            return View(ingredients);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredients = await _context.Ingredients
                .Include(i => i.recipe)
                .FirstOrDefaultAsync(m => m.IngredientsID == id);
            if (ingredients == null)
            {
                return NotFound();
            }

            return View(ingredients);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingredients == null)
            {
                return Problem("Entity set 'DytIpekBilalDBContext.Ingredients'  is null.");
            }
            var ingredients = await _context.Ingredients.FindAsync(id);
            if (ingredients != null)
            {
                _context.Ingredients.Remove(ingredients);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientsExists(int id)
        {
          return _context.Ingredients.Any(e => e.IngredientsID == id);
        }
    }
}
