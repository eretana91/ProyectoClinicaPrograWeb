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
    public class DoctorController : ControllerBase
    {
        private readonly ClinicaMedicaV1Context _context;

        public DoctorController(ClinicaMedicaV1Context context)
        {
            _context = context;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            return await _context.Doctor.ToListAsync();
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(long id)
        {
            var doctor = await _context.Doctor.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: api/Doctor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(long id, Doctor doctor)
        {
            if (id != doctor.CodigoDoctor)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.CodigoDoctor }, doctor);
        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(long id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        private bool DoctorExists(long id)
        {
            return _context.Doctor.Any(e => e.CodigoDoctor == id);
        }
    }
}
