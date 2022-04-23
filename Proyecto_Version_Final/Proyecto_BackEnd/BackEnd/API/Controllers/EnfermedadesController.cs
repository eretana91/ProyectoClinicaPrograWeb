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
    public class EnfermedadesController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public EnfermedadesController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: api/Enfermedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfermedades>>> GetEnfermedades()
        {
            return await _context.Enfermedades.ToListAsync();
        }

        // GET: api/Enfermedades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enfermedades>> GetEnfermedades(int id)
        {
            var enfermedades = await _context.Enfermedades.FindAsync(id);

            if (enfermedades == null)
            {
                return NotFound();
            }

            return enfermedades;
        }

        // PUT: api/Enfermedades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfermedades(int id, Enfermedades enfermedades)
        {
            if (id != enfermedades.IdEnfermedad)
            {
                return BadRequest();
            }

            _context.Entry(enfermedades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermedadesExists(id))
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

        // POST: api/Enfermedades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Enfermedades>> PostEnfermedades(Enfermedades enfermedades)
        {
            _context.Enfermedades.Add(enfermedades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnfermedades", new { id = enfermedades.IdEnfermedad }, enfermedades);
        }

        // DELETE: api/Enfermedades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Enfermedades>> DeleteEnfermedades(int id)
        {
            var enfermedades = await _context.Enfermedades.FindAsync(id);
            if (enfermedades == null)
            {
                return NotFound();
            }

            _context.Enfermedades.Remove(enfermedades);
            await _context.SaveChangesAsync();

            return enfermedades;
        }

        private bool EnfermedadesExists(int id)
        {
            return _context.Enfermedades.Any(e => e.IdEnfermedad == id);
        }
    }
}
