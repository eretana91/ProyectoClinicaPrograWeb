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
    public class InventariosController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public InventariosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Inventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Inventarios>>> GetInventarios()
        {
            var res = await new BE.BS.Inventarios(_context).GetAllAsync();
            List<models.Inventarios> mapaAux = _mapper.Map<IEnumerable<data.Inventarios>, IEnumerable<models.Inventarios>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Inventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Inventarios>> GetInventarios(int id)
        {
            var inventarios = await new BE.BS.Inventarios(_context).GetOneByIdAsync(id);

            if (inventarios == null)
            {
                return NotFound();
            }
            models.Inventarios mapaAux = _mapper.Map<data.Inventarios, models.Inventarios>(inventarios);
            return mapaAux;
        }

        // PUT: api/Inventarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventarios(int id, models.Inventarios inventarios)
        {
            if (id != inventarios.IdProducto)
            {
                return BadRequest();
            }
            try
            {
                data.Inventarios mapaAux = _mapper.Map<models.Inventarios, data.Inventarios>(inventarios);

                new BE.BS.Inventarios(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!InventariosExists(id))
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

        // POST: api/Inventarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Inventarios>> PostInventarios(models.Inventarios inventarios)
        {
            try
            {
                data.Inventarios mapaAux = _mapper.Map<models.Inventarios, data.Inventarios>(inventarios);
                new BE.BS.Inventarios(_context).Insert(mapaAux);
            }
            catch (Exception ee)
            {

                BadRequest(ee);
            }

            return CreatedAtAction("GetInventarios", new { id = inventarios.IdProducto }, inventarios);
        }

        // DELETE: api/Inventarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Inventarios>> DeleteInventarios(int id)
        {
            var inventarios = await new BE.BS.Inventarios(_context).GetOneByIdAsync(id);
            if (inventarios == null)
            {
                return NotFound();
            }
            try
            {
                new BE.BS.Inventarios(_context).Delete(inventarios);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Inventarios mapaAux = _mapper.Map<data.Inventarios, models.Inventarios>(inventarios);

            return mapaAux;
        }

        private bool InventariosExists(int id)
        {
            return (new BE.BS.Inventarios(_context).GetOneById(id) != null);
        }
    }
}

