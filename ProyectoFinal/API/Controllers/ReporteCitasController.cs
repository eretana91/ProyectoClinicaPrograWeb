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
    public class ReporteCitasController : ControllerBase
    {
        private readonly ClinicaMedicaV1Context _context;

        public ReporteCitasController(ClinicaMedicaV1Context context)
        {
            _context = context;
        }

        // GET: api/ReporteCitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteCitas>>> GetReporteCitas()
        {
            return await _context.ReporteCitas.ToListAsync();
        }

        // GET: api/ReporteCitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteCitas>> GetReporteCitas(long id)
        {
            var reporteCitas = await _context.ReporteCitas.FindAsync(id);

            if (reporteCitas == null)
            {
                return NotFound();
            }

            return reporteCitas;
        }

        // PUT: api/ReporteCitas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporteCitas(long id, ReporteCitas reporteCitas)
        {
            if (id != reporteCitas.CodigoreporteCitas)
            {
                return BadRequest();
            }

            _context.Entry(reporteCitas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporteCitasExists(id))
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

        // POST: api/ReporteCitas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReporteCitas>> PostReporteCitas(ReporteCitas reporteCitas)
        {
            _context.ReporteCitas.Add(reporteCitas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReporteCitas", new { id = reporteCitas.CodigoreporteCitas }, reporteCitas);
        }

        // DELETE: api/ReporteCitas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReporteCitas>> DeleteReporteCitas(long id)
        {
            var reporteCitas = await _context.ReporteCitas.FindAsync(id);
            if (reporteCitas == null)
            {
                return NotFound();
            }

            _context.ReporteCitas.Remove(reporteCitas);
            await _context.SaveChangesAsync();

            return reporteCitas;
        }

        private bool ReporteCitasExists(long id)
        {
            return _context.ReporteCitas.Any(e => e.CodigoreporteCitas == id);
        }
    }
}
