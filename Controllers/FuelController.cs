using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCar.Database;
using RentCar.Database.Entities;

namespace RentCar.Controllers
{
    public class FuelController : Controller
    {
        private readonly RentCarContext _context;

        public FuelController(RentCarContext context)
        {
            _context = context;
        }

        // GET: Fuel
        public async Task<IActionResult> Index()
        {
              return _context.Fuel != null ? 
                          View(await _context.Fuel.ToListAsync()) :
                          Problem("Entity set 'RentCarContext.Fuel'  is null.");
        }

        // GET: Fuel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fuel == null)
            {
                return NotFound();
            }

            var brand = await _context.Fuel
                .FirstOrDefaultAsync(m => m.id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Fuel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fuel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,description,status")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Fuel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fuel == null)
            {
                return NotFound();
            }

            var brand = await _context.Fuel.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Fuel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,description,status")] Brand brand)
        {
            if (id != brand.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.id))
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
            return View(brand);
        }

        // GET: Fuel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fuel == null)
            {
                return NotFound();
            }

            var brand = await _context.Fuel
                .FirstOrDefaultAsync(m => m.id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Fuel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fuel == null)
            {
                return Problem("Entity set 'RentCarContext.Fuel'  is null.");
            }
            var brand = await _context.Fuel.FindAsync(id);
            if (brand != null)
            {
                _context.Fuel.Remove(brand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
          return (_context.Fuel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
