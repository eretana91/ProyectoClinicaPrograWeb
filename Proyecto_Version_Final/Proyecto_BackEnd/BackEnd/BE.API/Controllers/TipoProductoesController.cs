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
    public class TipoProductoesController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public TipoProductoesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/TipoProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.TipoProducto>>> GetTipoProducto()
        {
            var res = new BE.BS.TipoProductoes(_context).GetAll();
            List<models.TipoProducto> mapaAux = _mapper.Map<IEnumerable<data.TipoProducto>, IEnumerable<models.TipoProducto>>(res).ToList();
            return mapaAux;
        }

        // GET: api/TipoProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.TipoProducto>> GetTipoProducto(int id)
        {
            var tipoProducto = new BE.BS.TipoProductoes(_context).GetOneByIdAsync(id);


            if (tipoProducto == null)
            {
                return NotFound();
            }

            models.TipoProducto mapaAux = _mapper.Map<data.TipoProducto, models.TipoProducto>(tipoProducto);
            return mapaAux;
        }

        // PUT: api/TipoProductoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProducto(int id, models.TipoProducto tipoProducto)
        {
            if (id != tipoProducto.TipoProducto)
            {
                return BadRequest();
            }

            try
            {
                data.TipoProducto mapaAux = _mapper.Map<models.TipoProducto, data.TipoProducto>(tipoProducto);

                new BE.BS.TipoProductoes(_context).Update(mapaAux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<models.TipoProducto>> PostTipoProducto(models.TipoProducto tipoProducto)
        {
            try
            {
                data.TipoProducto mapaAux = _mapper.Map<models.TipoProducto, data.TipoProducto>(tipoProducto);
                new BE.BS.TipoProductoes(_context).Insert(mapaAux);
            }
            catch (Exception ee)
            {

                BadRequest(ee);
            }

            return CreatedAtAction("GetTipoProducto", new { id = tipoProducto.TipoProducto1 }, tipoProducto);
        }

        // DELETE: api/TipoProductoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.TipoProducto>> DeleteTipoProducto(int id)
        {
            var tipoProducto = new BE.BS.TipoProductoes(_context).GetOneByIdAsync(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }
            try
            {
                new BE.BS.TipoProductoes(_context).Delete(tipoProducto);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.TipoProducto mapaAux = _mapper.Map<data.TipoProducto, models.TipoProducto>(tipoProducto);

            return mapaAux;
        }

        private bool TipoProductoExists(int id)
        {
            return (new BE.BS.TipoProductoes(_context).GetOneById(id) != null);
        }
    }
}

