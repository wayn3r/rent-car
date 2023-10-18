using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCar.Database;
using RentCar.Database.Entities;

namespace RentCar.Controllers
{
    [Authorize]
    public class FuelsController : Controller
    {
        private readonly RentCarContext _context;

        public FuelsController(RentCarContext context)
        {
            _context = context;
        }

        // GET: Fuels
        public async Task<IActionResult> Index()
        {
            return _context.Fuels != null ?
                        View(await _context.Fuels.ToListAsync()) :
                        Problem("Entity set 'RentCarContext.Fuels'  is null.");
        }

        // GET: Fuels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fuels == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuels
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuel == null)
            {
                return NotFound();
            }

            return View(fuel);
        }

        // GET: Fuels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fuels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,description,status")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuel);
        }

        // GET: Fuels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fuels == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuels.FindAsync(id);
            if (fuel == null)
            {
                return NotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,description,status")] Fuel fuel)
        {
            if (id != fuel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelExists(fuel.id))
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
            return View(fuel);
        }

        // GET: Fuels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fuels == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuels
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuel == null)
            {
                return NotFound();
            }

            return View(fuel);
        }

        // POST: Fuels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fuels == null)
            {
                return Problem("Entity set 'RentCarContext.Fuels'  is null.");
            }
            var fuel = await _context.Fuels.FindAsync(id);
            if (fuel != null)
            {
                _context.Fuels.Remove(fuel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelExists(int id)
        {
            return (_context.Fuels?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
