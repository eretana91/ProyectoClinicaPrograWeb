﻿using System;
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
    public class DireccionController : ControllerBase
    {
        private readonly ClinicaMedicaV1Context _context;

        public DireccionController(ClinicaMedicaV1Context context)
        {
            _context = context;
        }

        // GET: api/Direccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDireccion()
        {
            return await _context.Direccion.ToListAsync();
        }

        // GET: api/Direccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direccion>> GetDireccion(long id)
        {
            var direccion = await _context.Direccion.FindAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }

            return direccion;
        }

        // PUT: api/Direccion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDireccion(long id, Direccion direccion)
        {
            if (id != direccion.CodigoDireccion)
            {
                return BadRequest();
            }

            _context.Entry(direccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionExists(id))
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

        // POST: api/Direccion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Direccion>> PostDireccion(Direccion direccion)
        {
            _context.Direccion.Add(direccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDireccion", new { id = direccion.CodigoDireccion }, direccion);
        }

        // DELETE: api/Direccion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Direccion>> DeleteDireccion(long id)
        {
            var direccion = await _context.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }

            _context.Direccion.Remove(direccion);
            await _context.SaveChangesAsync();

            return direccion;
        }

        private bool DireccionExists(long id)
        {
            return _context.Direccion.Any(e => e.CodigoDireccion == id);
        }
    }
}
