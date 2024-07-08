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
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Socios
        public async Task<IActionResult> Index(string tipo)
        {
            ViewBag.Tipos = new SelectList(new List<string> { "Estandar", "Premium" });

            var sociosQuery = _context.Socios.Include(s => s.LocalAsociado).AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
            {
                sociosQuery = sociosQuery.Where(s => s.Tipo == tipo);
            }

            return View(await sociosQuery.ToListAsync());
        }

        // GET: Socios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.LocalAsociado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Ciudad");
            return View();
        }

        // POST: Socios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo,Email,LocalId,Id,Nombre,Telefono")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Ciudad", socio.LocalId);
            return View(socio);
        }

        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(int? id)  
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.SocioRutinas)
                .ThenInclude(sr => sr.Rutina)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (socio == null)
            {
                return NotFound();
            }
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Ciudad", socio.LocalId);

            var rutinas = await _context.Rutinas.ToListAsync();
            if (rutinas == null || !rutinas.Any())
            {
                throw new Exception("No hay rutinas disponibles en la base de datos.");
            }

            ViewBag.Rutinas = new SelectList(_context.Rutinas, "Id", "Descripcion"); //Cambié TipoRutina por Descripcion

            if (ViewBag.Rutinas == null)
            {
                throw new Exception("ViewBag.Rutinas es nulo");  //Agregué esta excepción
            }

            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo,Email,LocalId,Id,Nombre,Telefono")] Socio socio, int? IdSocio)
        {
            if (id != socio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocioExists(socio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = socio.Id });
            }
            ViewBag.LocalId = new SelectList(_context.Local, "Id", "Ciudad", socio.LocalId);
            ViewBag.Rutinas = new SelectList(_context.Rutinas, "Id", "Descripcion");
            return View(socio);
        }



        // POST: Socios/AsignarRutina      Usuarios = Socios y Proyecto = Rutina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarRutina(int IdSocio, int IdRutina)
        {

            if (IdRutina != null)
            {
                var usuarioProyecto = new SocioRutina
                {
                    IdSocio = IdSocio,
                    IdRutina = IdRutina
                };
                _context.SocioRutinas.Add(usuarioProyecto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = IdSocio });
        }

        // POST: Usuarios/DesasignarProyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesasignarRutina(int IdSocio, int IdRutina)
        {
            var socioRutina = await _context.SocioRutinas
                .FirstOrDefaultAsync(sr => sr.IdSocio == IdSocio && sr.IdRutina == IdRutina);

            if (socioRutina != null)
            {
                _context.SocioRutinas.Remove(socioRutina);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = IdSocio });
        }

        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.LocalAsociado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            if (socio != null)
            {
                _context.Socios.Remove(socio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocioExists(int id)
        {
            return _context.Socios.Any(e => e.Id == id);
        }
    }
}
