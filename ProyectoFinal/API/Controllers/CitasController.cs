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
    public class CitasController : ControllerBase
    {
        private readonly ClinicaMedicaV1Context _context;

        public CitasController(ClinicaMedicaV1Context context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citas>>> GetCitas()
        {
            return await _context.Citas.ToListAsync();
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Citas>> GetCitas(long id)
        {
            var citas = await _context.Citas.FindAsync(id);

            if (citas == null)
            {
                return NotFound();
            }

            return citas;
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitas(long id, Citas citas)
        {
            if (id != citas.CodigoCitas)
            {
                return BadRequest();
            }

            _context.Entry(citas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasExists(id))
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

        // POST: api/Citas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Citas>> PostCitas(Citas citas)
        {
            _context.Citas.Add(citas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitas", new { id = citas.CodigoCitas }, citas);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Citas>> DeleteCitas(long id)
        {
            var citas = await _context.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(citas);
            await _context.SaveChangesAsync();

            return citas;
        }

        private bool CitasExists(long id)
        {
            return _context.Citas.Any(e => e.CodigoCitas == id);
        }
    }
}
