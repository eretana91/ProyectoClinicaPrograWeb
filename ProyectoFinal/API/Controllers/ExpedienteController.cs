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
    public class ExpedienteController : ControllerBase
    {
        private readonly ClinicaMedicaV1Context _context;

        public ExpedienteController(ClinicaMedicaV1Context context)
        {
            _context = context;
        }

        // GET: api/Expediente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expediente>>> GetExpediente()
        {
            return await _context.Expediente.ToListAsync();
        }

        // GET: api/Expediente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expediente>> GetExpediente(long id)
        {
            var expediente = await _context.Expediente.FindAsync(id);

            if (expediente == null)
            {
                return NotFound();
            }

            return expediente;
        }

        // PUT: api/Expediente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpediente(long id, Expediente expediente)
        {
            if (id != expediente.CodigoExpediente)
            {
                return BadRequest();
            }

            _context.Entry(expediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpedienteExists(id))
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

        // POST: api/Expediente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Expediente>> PostExpediente(Expediente expediente)
        {
            _context.Expediente.Add(expediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpediente", new { id = expediente.CodigoExpediente }, expediente);
        }

        // DELETE: api/Expediente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expediente>> DeleteExpediente(long id)
        {
            var expediente = await _context.Expediente.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }

            _context.Expediente.Remove(expediente);
            await _context.SaveChangesAsync();

            return expediente;
        }

        private bool ExpedienteExists(long id)
        {
            return _context.Expediente.Any(e => e.CodigoExpediente == id);
        }
    }
}
