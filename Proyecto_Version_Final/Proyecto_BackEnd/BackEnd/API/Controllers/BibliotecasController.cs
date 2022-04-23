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
    public class BibliotecasController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public BibliotecasController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: api/Bibliotecas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biblioteca>>> GetBiblioteca()
        {
            return await _context.Biblioteca.ToListAsync();
        }

        // GET: api/Bibliotecas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biblioteca>> GetBiblioteca(int id)
        {
            var biblioteca = await _context.Biblioteca.FindAsync(id);

            if (biblioteca == null)
            {
                return NotFound();
            }

            return biblioteca;
        }

        // PUT: api/Bibliotecas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiblioteca(int id, Biblioteca biblioteca)
        {
            if (id != biblioteca.IdVideo)
            {
                return BadRequest();
            }

            _context.Entry(biblioteca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliotecaExists(id))
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

        // POST: api/Bibliotecas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Biblioteca>> PostBiblioteca(Biblioteca biblioteca)
        {
            _context.Biblioteca.Add(biblioteca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiblioteca", new { id = biblioteca.IdVideo }, biblioteca);
        }

        // DELETE: api/Bibliotecas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Biblioteca>> DeleteBiblioteca(int id)
        {
            var biblioteca = await _context.Biblioteca.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            _context.Biblioteca.Remove(biblioteca);
            await _context.SaveChangesAsync();

            return biblioteca;
        }

        private bool BibliotecaExists(int id)
        {
            return _context.Biblioteca.Any(e => e.IdVideo == id);
        }
    }
}
