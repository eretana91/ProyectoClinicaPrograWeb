using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.W.Models;

namespace FE.W.Controllers
{
    public class InventariosController : Controller
    {
        private readonly ClinicaContext _context;

        public InventariosController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Inventarios.Include(i => i.TipoProductoNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarios = await _context.Inventarios
                .Include(i => i.TipoProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (inventarios == null)
            {
                return NotFound();
            }

            return View(inventarios);
        }

        // GET: Inventarios/Create
        public IActionResult Create()
        {
            ViewData["TipoProducto"] = new SelectList(_context.TipoProducto, "TipoProducto1", "TipoProducto1");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,TipoProducto,NombreProducto,CodigoBarras,Precio,Cantidad,FechaExpiracion,Notas")] Inventarios inventarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoProducto"] = new SelectList(_context.TipoProducto, "TipoProducto1", "TipoProducto1", inventarios.TipoProducto);
            return View(inventarios);
        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarios = await _context.Inventarios.FindAsync(id);
            if (inventarios == null)
            {
                return NotFound();
            }
            ViewData["TipoProducto"] = new SelectList(_context.TipoProducto, "TipoProducto1", "TipoProducto1", inventarios.TipoProducto);
            return View(inventarios);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,TipoProducto,NombreProducto,CodigoBarras,Precio,Cantidad,FechaExpiracion,Notas")] Inventarios inventarios)
        {
            if (id != inventarios.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventariosExists(inventarios.IdProducto))
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
            ViewData["TipoProducto"] = new SelectList(_context.TipoProducto, "TipoProducto1", "TipoProducto1", inventarios.TipoProducto);
            return View(inventarios);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarios = await _context.Inventarios
                .Include(i => i.TipoProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (inventarios == null)
            {
                return NotFound();
            }

            return View(inventarios);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarios = await _context.Inventarios.FindAsync(id);
            _context.Inventarios.Remove(inventarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventariosExists(int id)
        {
            return _context.Inventarios.Any(e => e.IdProducto == id);
        }
    }
}
