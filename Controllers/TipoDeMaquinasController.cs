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
    public class TipoDeMaquinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDeMaquinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeMaquinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeMaquina.ToListAsync());
        }

        // GET: TipoDeMaquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeMaquina = await _context.TipoDeMaquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeMaquina == null)
            {
                return NotFound();
            }

            return View(tipoDeMaquina);
        }

        // GET: TipoDeMaquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeMaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Id")] TipoDeMaquina tipoDeMaquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeMaquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeMaquina);
        }

        // GET: TipoDeMaquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeMaquina = await _context.TipoDeMaquina.FindAsync(id);
            if (tipoDeMaquina == null)
            {
                return NotFound();
            }
            return View(tipoDeMaquina);
        }

        // POST: TipoDeMaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Id")] TipoDeMaquina tipoDeMaquina)
        {
            if (id != tipoDeMaquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeMaquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeMaquinaExists(tipoDeMaquina.Id))
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
            return View(tipoDeMaquina);
        }

        // GET: TipoDeMaquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeMaquina = await _context.TipoDeMaquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeMaquina == null)
            {
                return NotFound();
            }

            return View(tipoDeMaquina);
        }

        // POST: TipoDeMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeMaquina = await _context.TipoDeMaquina.FindAsync(id);
            if (tipoDeMaquina != null)
            {
                _context.TipoDeMaquina.Remove(tipoDeMaquina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeMaquinaExists(int id)
        {
            return _context.TipoDeMaquina.Any(e => e.Id == id);
        }
    }
}
