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
    public class TipoProductoesController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public TipoProductoesController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: api/TipoProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTipoProducto()
        {
            return await _context.TipoProducto.ToListAsync();
        }

        // GET: api/TipoProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProducto>> GetTipoProducto(int id)
        {
            var tipoProducto = await _context.TipoProducto.FindAsync(id);

            if (tipoProducto == null)
            {
                return NotFound();
            }

            return tipoProducto;
        }

        // PUT: api/TipoProductoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProducto(int id, TipoProducto tipoProducto)
        {
            if (id != tipoProducto.TipoProducto1)
            {
                return BadRequest();
            }

            _context.Entry(tipoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProductoExists(id))
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

        // POST: api/TipoProductoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostTipoProducto(TipoProducto tipoProducto)
        {
            _context.TipoProducto.Add(tipoProducto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoProductoExists(tipoProducto.TipoProducto1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoProducto", new { id = tipoProducto.TipoProducto1 }, tipoProducto);
        }

        // DELETE: api/TipoProductoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoProducto>> DeleteTipoProducto(int id)
        {
            var tipoProducto = await _context.TipoProducto.FindAsync(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            _context.TipoProducto.Remove(tipoProducto);
            await _context.SaveChangesAsync();

            return tipoProducto;
        }

        private bool TipoProductoExists(int id)
        {
            return _context.TipoProducto.Any(e => e.TipoProducto1 == id);
        }
    }
}
