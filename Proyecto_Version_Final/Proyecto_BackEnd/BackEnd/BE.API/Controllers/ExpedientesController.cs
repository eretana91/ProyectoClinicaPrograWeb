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
    public class ExpedientesController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ExpedientesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Expedientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Expedientes>>> GetExpedientes()
        {
            var res = await new BE.BS.Expedientes(_context).GetAllAsync();
            List<models.Expedientes> mapaAux = _mapper.Map<IEnumerable<data.Expedientes>, IEnumerable<models.Expedientes>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Expedientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Expedientes>> GetExpedientes(int id)
        {
            var expedientes = await new BE.BS.Expedientes(_context).GetOneByIdAsync(id);

            if (expedientes == null)
            {
                return NotFound();
            }
            models.Expedientes mapaAux = _mapper.Map<data.Expedientes, models.Expedientes>(expedientes);
            return mapaAux;
        }

        // PUT: api/Expedientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpedientes(int id, models.Expedientes expedientes)
        {
            if (id != expedientes.IdExpediente)
            {
                return BadRequest();
            }
            try
            {
                data.Expedientes mapaAux = _mapper.Map<models.Expedientes, data.Expedientes>(expedientes);

                new BE.BS.Expedientes(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!ExpedientesExists(id))
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

        // POST: api/Expedientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Expedientes>> PostExpedientes(models.Expedientes expedientes)
        {
            try
            {
                data.Expedientes mapaAux = _mapper.Map<models.Expedientes, data.Expedientes>(expedientes);
                new BE.BS.Expedientes(_context).Insert(mapaAux);
            }
            catch (Exception ee)
            {

                BadRequest(ee);
            }

            return CreatedAtAction("GetExpedientes", new { id = expedientes.IdExpediente }, expedientes);
        }

        // DELETE: api/Expedientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Expedientes>> DeleteExpedientes(int id)
        {
            var expedientes = await new BE.BS.Expedientes(_context).GetOneByIdAsync(id);
            if (expedientes == null)
            {
                return NotFound();
            }
            try
            {
                new BE.BS.Expedientes(_context).Delete(expedientes);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Expedientes mapaAux = _mapper.Map<data.Expedientes, models.Expedientes>(expedientes);

            return mapaAux;
        }

        private bool ExpedientesExists(int id)
        {
            return (new BE.BS.Expedientes(_context).GetOneById(id) != null);
        }
    }
}

