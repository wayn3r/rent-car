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
    public class EmployeeController : Controller
    {
        private readonly RentCarContext _context;

        public EmployeeController(RentCarContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
              return _context.Employee != null ? 
                          View(await _context.Employee.ToListAsync()) :
                          Problem("Entity set 'RentCarContext.Employee'  is null.");
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Employee == null)
            {
                return NotFound();
            }

            return View(Employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Cedula,tandalabor,porcientocomision,Fechaingreso,Estado")] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var Employee = await _context.Employee.FindAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cedula,tandalabor,porcientocomision,Fechaingreso,Estado")] Employee Employee)
        {
            if (id != Employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(Employee.Id))
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
            return View(Employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Employee == null)
            {
                return NotFound();
            }

            return View(Employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'RentCarContext.Employee'  is null.");
            }
            var Employee = await _context.Employee.FindAsync(id);
            if (Employee != null)
            {
                _context.Employee.Remove(Employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
