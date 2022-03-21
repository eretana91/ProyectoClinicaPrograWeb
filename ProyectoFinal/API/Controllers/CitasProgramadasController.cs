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
    public class CitasProgramadasController : ControllerBase
    {
        private readonly ClinicaMedicaV1Context _context;

        public CitasProgramadasController(ClinicaMedicaV1Context context)
        {
            _context = context;
        }

        // GET: api/CitasProgramadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitasProgramadas>>> GetCitasProgramadas()
        {
            return await _context.CitasProgramadas.ToListAsync();
        }

        // GET: api/CitasProgramadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitasProgramadas>> GetCitasProgramadas(long id)
        {
            var citasProgramadas = await _context.CitasProgramadas.FindAsync(id);

            if (citasProgramadas == null)
            {
                return NotFound();
            }

            return citasProgramadas;
        }

        // PUT: api/CitasProgramadas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitasProgramadas(long id, CitasProgramadas citasProgramadas)
        {
            if (id != citasProgramadas.CodigoCitaProgramadas)
            {
                return BadRequest();
            }

            _context.Entry(citasProgramadas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasProgramadasExists(id))
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

        // POST: api/CitasProgramadas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CitasProgramadas>> PostCitasProgramadas(CitasProgramadas citasProgramadas)
        {
            _context.CitasProgramadas.Add(citasProgramadas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitasProgramadas", new { id = citasProgramadas.CodigoCitaProgramadas }, citasProgramadas);
        }

        // DELETE: api/CitasProgramadas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CitasProgramadas>> DeleteCitasProgramadas(long id)
        {
            var citasProgramadas = await _context.CitasProgramadas.FindAsync(id);
            if (citasProgramadas == null)
            {
                return NotFound();
            }

            _context.CitasProgramadas.Remove(citasProgramadas);
            await _context.SaveChangesAsync();

            return citasProgramadas;
        }

        private bool CitasProgramadasExists(long id)
        {
            return _context.CitasProgramadas.Any(e => e.CodigoCitaProgramadas == id);
        }
    }
}
