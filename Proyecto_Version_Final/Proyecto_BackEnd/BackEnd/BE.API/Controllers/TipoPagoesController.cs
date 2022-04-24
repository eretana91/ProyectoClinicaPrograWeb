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
    public class TipoPagoesController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public TipoPagoesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TipoPagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.TipoPago>>> GetTipoPago()
        {
            var res = new BE.BS.TipoPagoes(_context).GetAllAsync();
            List<models.TipoPago> mapaAux = _mapper.Map<IEnumerable<data.TipoPago>, IEnumerable<models.TipoPago>>(res).ToList();
            return mapaAux;
        }

        // GET: api/TipoPagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.TipoPago>> GetTipoPago(int id)
        {
            var tipoPago = new BE.BS.TipoPagoes(_context).GetOneByIdAsync(id);


            if (tipoPago == null)
            {
                return NotFound();
            }

            models.TipoPago mapaAux = _mapper.Map<data.TipoPago, models.TipoPago>(tipoPago);
            return mapaAux;
        }

        // PUT: api/TipoPagoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPago(int id, models.TipoPago tipoPago)
        {
            if (id != tipoPago.TipoPago)
            {
                return BadRequest();
            }

            try
            {
                data.TipoPago mapaAux = _mapper.Map<models.TipoPago, data.TipoPago>(tipoPago);

                new BE.BS.TipoPagoes(_context).Update(mapaAux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<models.TipoPago>> PostTipoPago(TipoPago tipoPago)
        {
            try
            {
                data.TipoPago mapaAux = _mapper.Map<models.TipoPago, data.TipoPago>(tipoPago);
                new BE.BS.TipoPagoes(_context).Insert(mapaAux);
            }
            catch (Exception ee)
            {

                BadRequest(ee);
            }

            return CreatedAtAction("GetTipoPago", new { id = tipoPago.TipoPago1 }, tipoPago);
        }

        // DELETE: api/TipoPagoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.TipoPago>> DeleteTipoPago(int id)
        {
            var tipoPago = await new BE.BS.TipoPagoes(_context).GetOneByIdAsync(id);
            if (tipoPago == null)
            {
                return NotFound();
            }
            try
            {
                new BE.BS.TipoPagoes(_context).Delete(tipoPago);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.TipoPago mapaAux = _mapper.Map<data.TipoPago, models.TipoPago>(tipoPago);

            return mapaAux;
        }

        private bool TipoPagoExists(int id)
        {
            return (new BE.BS.TipoPagoes(_context).GetOneById(id) != null);
        }
    }
}

