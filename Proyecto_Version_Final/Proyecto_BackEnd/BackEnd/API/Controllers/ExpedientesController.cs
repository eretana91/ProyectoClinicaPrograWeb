using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedientesController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public ExpedientesController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: api/Expedientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expedientes>>> GetExpedientes()
        {
            return await _context.Expedientes.ToListAsync();
        }

        // GET: api/Expedientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expedientes>> GetExpedientes(int id)
        {
            var expedientes = await _context.Expedientes.FindAsync(id);

            if (expedientes == null)
            {
                return NotFound();
            }

            return expedientes;
        }

        // PUT: api/Expedientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpedientes(int id, Expedientes expedientes)
        {
            if (id != expedientes.IdExpediente)
            {
                return BadRequest();
            }

            _context.Entry(expedientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpedientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Expedientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Expedientes>> PostExpedientes(Expedientes expedientes)
        {
            _context.Expedientes.Add(expedientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpedientes", new { id = expedientes.IdExpediente }, expedientes);
        }

        // DELETE: api/Expedientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expedientes>> DeleteExpedientes(int id)
        {
            var expedientes = await _context.Expedientes.FindAsync(id);
            if (expedientes == null)
            {
                return NotFound();
            }

            _context.Expedientes.Remove(expedientes);
            await _context.SaveChangesAsync();

            return expedientes;
        }

        private bool ExpedientesExists(int id)
        {
            return _context.Expedientes.Any(e => e.IdExpediente == id);
        }
    }
}
