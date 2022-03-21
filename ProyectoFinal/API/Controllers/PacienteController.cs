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
    public class PacienteController : ControllerBase
    {
        private readonly ClinicaMedicaV1Context _context;

        public PacienteController(ClinicaMedicaV1Context context)
        {
            _context = context;
        }

        // GET: api/Paciente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()
        {
            return await _context.Paciente.ToListAsync();
        }

        // GET: api/Paciente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(long id)
        {
            var paciente = await _context.Paciente.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        // PUT: api/Paciente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(long id, Paciente paciente)
        {
            if (id != paciente.CodigoPaciente)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Paciente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaciente", new { id = paciente.CodigoPaciente }, paciente);
        }

        // DELETE: api/Paciente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paciente>> DeletePaciente(long id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }

        private bool PacienteExists(long id)
        {
            return _context.Paciente.Any(e => e.CodigoPaciente == id);
        }
    }
}
