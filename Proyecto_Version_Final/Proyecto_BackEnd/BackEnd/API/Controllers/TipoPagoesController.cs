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
    public class TipoPagoesController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public TipoPagoesController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: api/TipoPagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPago>>> GetTipoPago()
        {
            return await _context.TipoPago.ToListAsync();
        }

        // GET: api/TipoPagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPago>> GetTipoPago(int id)
        {
            var tipoPago = await _context.TipoPago.FindAsync(id);

            if (tipoPago == null)
            {
                return NotFound();
            }

            return tipoPago;
        }

        // PUT: api/TipoPagoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPago(int id, TipoPago tipoPago)
        {
            if (id != tipoPago.TipoPago1)
            {
                return BadRequest();
            }

            _context.Entry(tipoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPagoExists(id))
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

        // POST: api/TipoPagoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoPago>> PostTipoPago(TipoPago tipoPago)
        {
            _context.TipoPago.Add(tipoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPago", new { id = tipoPago.TipoPago1 }, tipoPago);
        }

        // DELETE: api/TipoPagoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoPago>> DeleteTipoPago(int id)
        {
            var tipoPago = await _context.TipoPago.FindAsync(id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            _context.TipoPago.Remove(tipoPago);
            await _context.SaveChangesAsync();

            return tipoPago;
        }

        private bool TipoPagoExists(int id)
        {
            return _context.TipoPago.Any(e => e.TipoPago1 == id);
        }
    }
}
