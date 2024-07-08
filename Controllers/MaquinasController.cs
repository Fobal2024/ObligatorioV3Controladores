using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio.Datos;
using Obligatorio.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Obligatorio.ViewModels;
using Microsoft.Data.SqlClient;


namespace Obligatorio.Controllers
{
    public class MaquinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaquinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index(int? localId, string sortOrder)
        {
            ViewBag.Locales = new SelectList(await _context.Local.ToListAsync(), "Id", "Nombre");

            // Variables para mantener el estado de la ordenación actual
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            var maquinasQuery = _context.Maquina
                .Include(m => m.TipoDeMaquina)
                .Include(m => m.Local)
                .AsQueryable();

            if (localId.HasValue)
            {
                maquinasQuery = maquinasQuery.Where(m => m.LocalId == localId.Value);
            }

            switch (sortOrder)
            {
                case "date_desc":
                    maquinasQuery = maquinasQuery.OrderByDescending(m => m.FechaCompra);
                    break;
                default:
                    maquinasQuery = maquinasQuery.OrderBy(m => m.FechaCompra);
                    break;
            }

            var viewModel = new MaquinasIndexViewModel
            {
                LocalId = localId,
                Maquinas = await maquinasQuery.ToListAsync()
            };

            return View(viewModel);
        }


        // GET: Maquinas/Filtrar
        public async Task<IActionResult> Filtrar(int? localId)
        {
            // Obtener la lista de locales para el dropdown
            ViewBag.Locales = new SelectList(_context.Local, "Id", "Nombre");

            // Consulta para obtener las máquinas y agrupar por tipo
            var query = _context.Maquina.AsQueryable();

            if (localId.HasValue)
            {
                query = query.Where(m => m.LocalId == localId.Value);
            }

            var maquinasFiltradas = await query
                .GroupBy(m => m.TipoDeMaquina.Nombre)
                .Select(g => new MaquinasFiltradasViewModel
                {
                    Tipo = g.Key,
                    Cantidad = g.Count(),
                    LocalId = localId,
                    Maquinas = g.ToList()
                })
                .ToListAsync();

            return View(maquinasFiltradas);
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .Include(m => m.Local)
                .Include(m => m.TipoDeMaquina)
                .FirstOrDefaultAsync(m => m.IdMaquina == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            ViewBag.LocalId = new SelectList(_context.Local, "Id", "Ciudad");
            ViewData["TipoDeMaquinaId"] = new SelectList(_context.TipoDeMaquina, "Id", "Nombre"); 
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaquina,FechaCompra,PrecioCompra,VidaUtil,Disponible,TipoDeMaquinaId,LocalId")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Ciudad", maquina.LocalId);
            ViewData["TipoDeMaquinaId"] = new SelectList(_context.TipoDeMaquina, "Id", "Nombre", maquina.TipoDeMaquinaId);
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Ciudad", maquina.LocalId);
            ViewData["TipoDeMaquinaId"] = new SelectList(_context.TipoDeMaquina, "Id", "Id", maquina.TipoDeMaquinaId);
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaquina,FechaCompra,PrecioCompra,VidaUtil,Disponible,TipoDeMaquinaId,LocalId")] Maquina maquina)
        {
            if (id != maquina.IdMaquina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.IdMaquina))
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
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Ciudad", maquina.LocalId);
            ViewData["TipoDeMaquinaId"] = new SelectList(_context.TipoDeMaquina, "Id", "Id", maquina.TipoDeMaquinaId);
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .Include(m => m.Local)
                .Include(m => m.TipoDeMaquina)
                .FirstOrDefaultAsync(m => m.IdMaquina == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina != null)
            {
                _context.Maquina.Remove(maquina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
            return _context.Maquina.Any(e => e.IdMaquina == id);
        }
    }
}

