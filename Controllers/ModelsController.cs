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
    public class ModelsController : Controller
    {
        private readonly RentCarContext _context;

        public ModelsController(RentCarContext context)
        {
            _context = context;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            var rentCarContext = _context.models.Include(m => m.brand);
            return View(await rentCarContext.ToListAsync());
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.models == null)
            {
                return NotFound();
            }

            var model = await _context.models
                .Include(m => m.brand)
                .FirstOrDefaultAsync(m => m.id == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            ViewData["brandId"] = new SelectList(_context.brands, "id", "description");
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,description,status,brandId")] Model model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["brandId"] = new SelectList(_context.brands, "id", "description", model.brandId);
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.models == null)
            {
                return NotFound();
            }

            var model = await _context.models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["brandId"] = new SelectList(_context.brands, "id", "description", model.brandId);
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,description,status,brandId")] Model model)
        {
            if (id != model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.id))
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
            ViewData["brandId"] = new SelectList(_context.brands, "id", "description", model.brandId);
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.models == null)
            {
                return NotFound();
            }

            var model = await _context.models
                .Include(m => m.brand)
                .FirstOrDefaultAsync(m => m.id == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.models == null)
            {
                return Problem("Entity set 'RentCarContext.models'  is null.");
            }
            var model = await _context.models.FindAsync(id);
            if (model != null)
            {
                _context.models.Remove(model);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
          return (_context.models?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
