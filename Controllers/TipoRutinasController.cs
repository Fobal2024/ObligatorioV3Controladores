using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obligatorio.Datos;
using Obligatorio.Models;

namespace Obligatorio.Controllers
{
    public class TipoRutinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoRutinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoRutinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoRutinas.ToListAsync());
        }

        // GET: TipoRutinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRutina = await _context.TipoRutinas
                .Include(t => t.Rutinas)
                .FirstOrDefaultAsync(m => m.IdTipoRutina == id);
            if (tipoRutina == null)
            {
                return NotFound();
            }

            return View(tipoRutina);
        }

        // GET: TipoRutinas/Create
        public IActionResult Create()
        {
            ViewBag.TipoRutinaId = new SelectList(_context.TipoRutinas, "IdTipoRutina", "Nombre");
            return View();
        }

        // POST: TipoRutinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoRutina tipoRutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRutina);
        }

        // GET: TipoRutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRutina = await _context.TipoRutinas.FindAsync(id);
            if (tipoRutina == null)
            {
                return NotFound();
            }
            return View(tipoRutina);
        }

        // POST: TipoRutinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoRutina tipoRutina)
        {
            if (id != tipoRutina.IdTipoRutina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRutinaExists(tipoRutina.IdTipoRutina))
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
            return View(tipoRutina);
        }

        // GET: TipoRutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRutina = await _context.TipoRutinas
                .FirstOrDefaultAsync(m => m.IdTipoRutina == id);
            if (tipoRutina == null)
            {
                return NotFound();
            }

            return View(tipoRutina);
        }

        // POST: TipoRutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoRutina = await _context.TipoRutinas.FindAsync(id);
            if (tipoRutina != null)
            {
                _context.TipoRutinas.Remove(tipoRutina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRutinaExists(int id)
        {
            return _context.TipoRutinas.Any(e => e.IdTipoRutina == id);
        }
    }
}
