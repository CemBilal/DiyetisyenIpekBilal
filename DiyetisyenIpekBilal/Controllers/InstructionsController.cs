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
    public class InstructionsController : Controller
    {
        private readonly DytIpekBilalDBContext _context;

        public InstructionsController(DytIpekBilalDBContext context)
        {
            _context = context;
        }

        // GET: Instructions
        public async Task<IActionResult> Index()
        {
            var dytIpekBilalDBContext = _context.Instructions.Include(i => i.recipe);
            return View(await dytIpekBilalDBContext.ToListAsync());
        }

        // GET: Instructions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instructions == null)
            {
                return NotFound();
            }

            var instructions = await _context.Instructions
                .Include(i => i.recipe)
                .FirstOrDefaultAsync(m => m.InstructionID == id);
            if (instructions == null)
            {
                return NotFound();
            }

            return View(instructions);
        }

        // GET: Instructions/Create
        public IActionResult Create()
        {
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "Name");
            return View();
        }

        // POST: Instructions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructionID,InstructionSen,RecipeID")] Instructions instructions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "Name", instructions.RecipeID);
            return View(instructions);
        }

        // GET: Instructions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instructions == null)
            {
                return NotFound();
            }

            var instructions = await _context.Instructions.FindAsync(id);
            if (instructions == null)
            {
                return NotFound();
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "Name", instructions.RecipeID);
            return View(instructions);
        }

        // POST: Instructions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructionID,InstructionSen,RecipeID")] Instructions instructions)
        {
            if (id != instructions.InstructionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructionsExists(instructions.InstructionID))
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
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "Name", instructions.RecipeID);
            return View(instructions);
        }

        // GET: Instructions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instructions == null)
            {
                return NotFound();
            }

            var instructions = await _context.Instructions
                .Include(i => i.recipe)
                .FirstOrDefaultAsync(m => m.InstructionID == id);
            if (instructions == null)
            {
                return NotFound();
            }

            return View(instructions);
        }

        // POST: Instructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instructions == null)
            {
                return Problem("Entity set 'DytIpekBilalDBContext.Instructions'  is null.");
            }
            var instructions = await _context.Instructions.FindAsync(id);
            if (instructions != null)
            {
                _context.Instructions.Remove(instructions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructionsExists(int id)
        {
          return _context.Instructions.Any(e => e.InstructionID == id);
        }
    }
}
