using AutoMapper;
using BE.DAL.DO.Objects;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;
using models = BE.API.DataModels;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecasController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public BibliotecasController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Bibliotecas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Biblioteca>>> GetBiblioteca()
        {
            //return null;
            //return new BE.BS.Categories(_context).GetAll().ToList();
            var res = new BE.BS.Bibliotecas(_context).GetAll();
            List<models.Biblioteca> mapaAux = _mapper.Map<IEnumerable<data.Biblioteca>, IEnumerable<models.Biblioteca>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Bibliotecas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Biblioteca>> GetBiblioteca(int id)
        {
            var biblioteca = new BE.BS.Bibliotecas(_context).GetOneById(id);

            if (biblioteca == null)
            {
                return NotFound();
            }
            models.Biblioteca mapaAux = _mapper.Map<data.Biblioteca, models.Biblioteca>(biblioteca);

            return mapaAux;
        }

        // PUT: api/Bibliotecas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiblioteca(int id, models.Biblioteca biblioteca)
        {
            if (id != biblioteca.IdVideo)
            {
                return BadRequest();
            }

            try
            {
                data.Biblioteca mapaAux = _mapper.Map<models.Biblioteca, data.Biblioteca>(biblioteca);

                new BE.BS.Bibliotecas(_context).Update(mapaAux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<Biblioteca>> PostBiblioteca(models.Biblioteca biblioteca)
        {
            try
            {
                data.Biblioteca mapaAux = _mapper.Map<models.Biblioteca, data.Biblioteca>(biblioteca);
                new BE.BS.Bibliotecas(_context).Insert(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetBiblioteca", new { id = biblioteca.IdVideo }, biblioteca);
        }

        // DELETE: api/Bibliotecas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Biblioteca>> DeleteBiblioteca(int id)
        {
            var biblioteca = new BE.BS.Bibliotecas(_context).GetOneById(id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Bibliotecas(_context).Delete(biblioteca);
            }
            catch (Exception)
            {

                BadRequest();
            }
            models.Biblioteca mapaAux = _mapper.Map<data.Biblioteca, models.Biblioteca>(biblioteca);

            return mapaAux;
        }

        private bool BibliotecaExists(int id)
        {
            return (new BE.BS.Bibliotecas(_context).GetOneById(id) != null);
        }
    }
}

