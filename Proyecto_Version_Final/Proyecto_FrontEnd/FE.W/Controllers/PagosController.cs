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
    public class PagosController : Controller
    {
        private readonly ClinicaContext _context;

        public PagosController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Pagos.Include(p => p.CedulaNavigation).Include(p => p.TipoPagoNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos
                .Include(p => p.CedulaNavigation)
                .Include(p => p.TipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // GET: Pagos/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula");
            ViewData["TipoPago"] = new SelectList(_context.TipoPago, "TipoPago1", "TipoPago1");
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPago,TipoPago,Monto,Banco,Cedula,FechaPago,Notas")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", pagos.Cedula);
            ViewData["TipoPago"] = new SelectList(_context.TipoPago, "TipoPago1", "TipoPago1", pagos.TipoPago);
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", pagos.Cedula);
            ViewData["TipoPago"] = new SelectList(_context.TipoPago, "TipoPago1", "TipoPago1", pagos.TipoPago);
            return View(pagos);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPago,TipoPago,Monto,Banco,Cedula,FechaPago,Notas")] Pagos pagos)
        {
            if (id != pagos.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagosExists(pagos.IdPago))
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
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", pagos.Cedula);
            ViewData["TipoPago"] = new SelectList(_context.TipoPago, "TipoPago1", "TipoPago1", pagos.TipoPago);
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _context.Pagos
                .Include(p => p.CedulaNavigation)
                .Include(p => p.TipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagos = await _context.Pagos.FindAsync(id);
            _context.Pagos.Remove(pagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagosExists(int id)
        {
            return _context.Pagos.Any(e => e.IdPago == id);
        }
    }
}
