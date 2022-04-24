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
    public class EnfermedadesController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public EnfermedadesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Enfermedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Enfermedades>>> GetEnfermedades()
        {
            var res = await new BE.BS.Enfermedades(_context).GetAllAsync();
            List<models.Enfermedades> mapaAux = _mapper.Map<IEnumerable<data.Enfermedades>, IEnumerable<models.Enfermedades>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Enfermedades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Enfermedades>> GetEnfermedades(int id)
        {
            var enfermedades = await new BE.BS.Enfermedades(_context).GetOneByIdAsync(id);


            if (enfermedades == null)
            {
                return NotFound();
            }

            models.Enfermedades mapaAux = _mapper.Map<data.Enfermedades, models.Enfermedades>(enfermedades);
            return mapaAux;
        }

        // PUT: api/Enfermedades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfermedades(int id, models.Enfermedades enfermedades)
        {
            if (id != enfermedades.IdEnfermedad)
            {
                return BadRequest();
            }

            try
            {
                data.Enfermedades mapaAux = _mapper.Map<models.Enfermedades, data.Enfermedades>(enfermedades);

                new BE.BS.Enfermedades(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!EnfermedadesExists(id))
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

        // POST: api/Enfermedades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Enfermedades>> PostEnfermedades(models.Enfermedades enfermedades)
        {
            try
            {
                data.Enfermedades mapaAux = _mapper.Map<models.Enfermedades, data.Enfermedades>(enfermedades);
                new BE.BS.Enfermedades(_context).Insert(mapaAux);
            }
            catch (Exception ee)
            {

                BadRequest(ee);
            }

            return CreatedAtAction("GetEnfermedades", new { id = enfermedades.IdEnfermedad }, enfermedades);
        }

        // DELETE: api/Enfermedades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Enfermedades>> DeleteEnfermedades(int id)
        {
            var enfermedades = await new BE.BS.Enfermedades(_context).GetOneByIdAsync(id);
            if (enfermedades == null)
            {
                return NotFound();
            }
            try
            {
                new BE.BS.Enfermedades(_context).Delete(enfermedades);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Enfermedades mapaAux = _mapper.Map<data.Enfermedades, models.Enfermedades>(enfermedades);

            return mapaAux;
        }

        private bool EnfermedadesExists(int id)
        {
            return (new BE.BS.Enfermedades(_context).GetOneById(id) != null);
        }
    }
}

