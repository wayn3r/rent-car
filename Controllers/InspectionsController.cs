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
    public class InspectionsController : Controller
    {
        private readonly RentCarContext _context;

        public InspectionsController(RentCarContext context)
        {
            _context = context;
        }

        // GET: Inspections
        public async Task<IActionResult> Index()
        {
              return _context.Inspections != null ? 
                          View(await _context.Inspections.ToListAsync()) :
                          Problem("Entity set 'RentCarContext.Inspections'  is null.");
        }

        // GET: Inspections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inspections == null)
            {
                return NotFound();
            }

            var inspections = await _context.Inspections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspections == null)
            {
                return NotFound();
            }

            return View(inspections);
        }

        // GET: Inspections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inspections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Kilometraje,Estado,Tipo,Precio,Resultado,Observaciones")] Inspections inspections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspections);
        }

        // GET: Inspections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inspections == null)
            {
                return NotFound();
            }

            var inspections = await _context.Inspections.FindAsync(id);
            if (inspections == null)
            {
                return NotFound();
            }
            return View(inspections);
        }

        // POST: Inspections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Kilometraje,Estado,Tipo,Precio,Resultado,Observaciones")] Inspections inspections)
        {
            if (id != inspections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionsExists(inspections.Id))
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
            return View(inspections);
        }

        // GET: Inspections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inspections == null)
            {
                return NotFound();
            }

            var inspections = await _context.Inspections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspections == null)
            {
                return NotFound();
            }

            return View(inspections);
        }

        // POST: Inspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inspections == null)
            {
                return Problem("Entity set 'RentCarContext.Inspections'  is null.");
            }
            var inspections = await _context.Inspections.FindAsync(id);
            if (inspections != null)
            {
                _context.Inspections.Remove(inspections);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionsExists(int id)
        {
          return (_context.Inspections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
