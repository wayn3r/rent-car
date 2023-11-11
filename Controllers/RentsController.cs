using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentCar.Database;
using RentCar.Database.Entities;

namespace RentCar.Controllers
{
    public class RentsController : Controller
    {
        private readonly RentCarContext _context;

        public RentsController(RentCarContext context)
        {
            _context = context;
        }

        // GET: Rents
        public async Task<IActionResult> Index(string? cliente, string? fecha, string? vehiculo)
        {
            // ViewBag["Clientes"] = new SelectList(_context.Clients, "Id", "Cedula");
            // ViewBag["Vehiculos"] = new SelectList(_context.Cars, "Id", "Descripcion");

            ViewBag.cliente = cliente;
            ViewBag.fecha = fecha;
            ViewBag.vehiculo = vehiculo;

            var rentCarContext = _context.Rents
                .Include(r => r.cliente)
                .Include(r => r.empleado)
                .Include(r => r.vehiculo)
                .Where(rent =>
                    (cliente.IsNullOrEmpty() || rent.cliente.Nombre.Contains(cliente) || rent.cliente.Cedula.StartsWith(cliente))
                        && (fecha.IsNullOrEmpty() || rent.FechaRenta.CompareTo(DateTime.Parse(fecha)) >= 0)
                        && (vehiculo.IsNullOrEmpty() || rent.vehiculo.Descripcion.Contains(vehiculo) || rent.vehiculo.NoPlaca.StartsWith(vehiculo) || rent.vehiculo.NoChasis.StartsWith(vehiculo))
                );


            return View(await rentCarContext.ToListAsync());
        }


        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.cliente)
                .Include(r => r.empleado)
                .Include(r => r.vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clients, "Id", "Nombre");
            ViewData["EmpleadoId"] = new SelectList(_context.Employees, "Id", "Cedula");
            ViewData["VehículoId"] = new SelectList(_context.Cars, "Id", "Descripcion");
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoRenta,EmpleadoId,VehículoId,ClienteId,FechaRenta,FechaDevolución,MontoDia,CantidadDias,Comentario,Estado")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clients, "Id", "Cedula", rent.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Employees, "Id", "Cedula", rent.EmpleadoId);
            ViewData["VehículoId"] = new SelectList(_context.Cars, "Id", "Descripcion", rent.VehículoId);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clients, "Id", "Cedula", rent.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Employees, "Id", "Cedula", rent.EmpleadoId);
            ViewData["VehículoId"] = new SelectList(_context.Cars, "Id", "Descripcion", rent.VehículoId);
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoRenta,EmpleadoId,VehículoId,ClienteId,FechaRenta,FechaDevolución,MontoDia,CantidadDias,Comentario,Estado")] Rent rent)
        {
            if (id != rent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clients, "Id", "Cedula", rent.ClienteId);
            ViewData["EmpleadoId"] = new SelectList(_context.Employees, "Id", "Cedula", rent.EmpleadoId);
            ViewData["VehículoId"] = new SelectList(_context.Cars, "Id", "Descripcion", rent.VehículoId);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rents == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.cliente)
                .Include(r => r.empleado)
                .Include(r => r.vehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rents == null)
            {
                return Problem("Entity set 'RentCarContext.Rents'  is null.");
            }
            var rent = await _context.Rents.FindAsync(id);
            if (rent != null)
            {
                _context.Rents.Remove(rent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Report(string? desde, string? hasta)
        {
            ViewBag.desde = desde;
            ViewBag.hasta = hasta;

            var rentCarContext = _context.Rents
                .Include(r => r.cliente)
                .Include(r => r.empleado)
                .Include(r => r.vehiculo)
                .Where(rent =>
                         (desde.IsNullOrEmpty() || rent.FechaRenta.CompareTo(DateTime.Parse(desde)) >= 0) &&
                         (hasta.IsNullOrEmpty() || rent.FechaRenta.CompareTo(DateTime.Parse(hasta)) <= 0)
                );


            return View(await rentCarContext.ToListAsync());
        }

        private bool RentExists(int id)
        {
            return (_context.Rents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}