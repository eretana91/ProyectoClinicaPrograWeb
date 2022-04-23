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
    public class ExpedientesController : Controller
    {
        private readonly ClinicaContext _context;

        public ExpedientesController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: Expedientes
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Expedientes.Include(e => e.CedulaNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: Expedientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientes = await _context.Expedientes
                .Include(e => e.CedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdExpediente == id);
            if (expedientes == null)
            {
                return NotFound();
            }

            return View(expedientes);
        }

        // GET: Expedientes/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula");
            return View();
        }

        // POST: Expedientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExpediente,Cedula,FechaN,Ciudad,Canton,Distrito,Diagnostico,Antecendente,MediUtilizados,AnteQuirurgicos,Fracturas,AnteFamiliares")] Expedientes expedientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expedientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", expedientes.Cedula);
            return View(expedientes);
        }

        // GET: Expedientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientes = await _context.Expedientes.FindAsync(id);
            if (expedientes == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", expedientes.Cedula);
            return View(expedientes);
        }

        // POST: Expedientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExpediente,Cedula,FechaN,Ciudad,Canton,Distrito,Diagnostico,Antecendente,MediUtilizados,AnteQuirurgicos,Fracturas,AnteFamiliares")] Expedientes expedientes)
        {
            if (id != expedientes.IdExpediente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expedientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedientesExists(expedientes.IdExpediente))
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
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", expedientes.Cedula);
            return View(expedientes);
        }

        // GET: Expedientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientes = await _context.Expedientes
                .Include(e => e.CedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdExpediente == id);
            if (expedientes == null)
            {
                return NotFound();
            }

            return View(expedientes);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expedientes = await _context.Expedientes.FindAsync(id);
            _context.Expedientes.Remove(expedientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedientesExists(int id)
        {
            return _context.Expedientes.Any(e => e.IdExpediente == id);
        }
    }
}
