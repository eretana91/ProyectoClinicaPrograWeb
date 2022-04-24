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
    public class PagosController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public PagosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Pagos>>> GetPagos()
        {
            var res = await new BE.BS.Pagos(_context).GetAllAsync();
            List<models.Pagos> mapaAux = _mapper.Map<IEnumerable<data.Pagos>, IEnumerable<models.Pagos>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Pagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Pagos>> GetPagos(int id)
        {
            var pagos = await new BE.BS.Pagos(_context).GetOneByIdAsync(id);

            if (pagos == null)
            {
                return NotFound();
            }
            models.Pagos mapaAux = _mapper.Map<data.Pagos, models.Pagos>(pagos);
            return mapaAux;
        }

        // PUT: api/Pagos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagos(int id, models.Pagos pagos)
        {
            if (id != pagos.IdPago)
            {
                return BadRequest();
            }
            try
            {
                data.Pagos mapaAux = _mapper.Map<models.Pagos, data.Pagos>(pagos);

                new BE.BS.Pagos(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!PagosExists(id))
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

        // POST: api/Pagos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Pagos>> PostPagos(models.Pagos pagos)
        {
            try
            {
                data.Pagos mapaAux = _mapper.Map<models.Pagos, data.Pagos>(pagos);
                new BE.BS.Pagos(_context).Insert(mapaAux);
            }
            catch (Exception ee)
            {

                BadRequest(ee);
            }

            return CreatedAtAction("GetPagos", new { id = pagos.IdPago }, pagos);
        }

        // DELETE: api/Pagos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Pagos>> DeletePagos(int id)
        {
            var pagos = await new BE.BS.Pagos(_context).GetOneByIdAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }
            try
            {
                new BE.BS.Pagos(_context).Delete(pagos);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Pagos mapaAux = _mapper.Map<data.Pagos, models.Pagos>(pagos);

            return mapaAux;
        }

        private bool PagosExists(int id)
        {
            return (new BE.BS.Pagos(_context).GetOneById(id) != null);
        }
    }
}

