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

        public class TipoUsuariosController : Controller
        {
            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public TipoUsuariosController(NDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            // GET: api/TipoUsuarios
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.TipoUsuario>>> GetTipoUsuario()
            {
                var res = await new BE.BS.TipoUsuarios(_context).GetAllAsync();
                List<models.TipoUsuario> mapaAux = _mapper.Map<IEnumerable<data.TipoUsuario>, IEnumerable<models.TipoUsuario>>(res).ToList();
                return mapaAux;
            }

            // GET: api/TipoUsuarios/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.TipoUsuario>> GetTipoUsuario(int id)
            {
                var tipoUsuario = await new BE.BS.TipoUsuarios(_context).GetOneByIdAsync(id);


                if (tipoUsuario == null)
                {
                    return NotFound();
                }

                models.TipoUsuario mapaAux = _mapper.Map<data.TipoUsuario, models.TipoUsuario>(tipoUsuario);
                return mapaAux;
            }

            // PUT: api/TipoUsuarios/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTipoUsuario(int id, models.TipoUsuario tipoUsuario)
            {
                if (id != tipoUsuario.IdTipoUsuario)
                {
                    return BadRequest();
                }

                try
                {
                    data.TipoUsuario mapaAux = _mapper.Map<models.TipoUsuario, data.TipoUsuario>(tipoUsuario);

                    new BE.BS.TipoUsuarios(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!TipoUsuarioExists(id))
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

            // POST: api/TipoUsuarios
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<TipoUsuario>> PostTipoUsuario(models.TipoUsuario tipoUsuario)
            {
                try
                {
                    data.TipoUsuario mapaAux = _mapper.Map<models.TipoUsuario, data.TipoUsuario>(tipoUsuario);
                    new BE.BS.TipoUsuarios(_context).Insert(mapaAux);
                }
                catch (Exception ee)
                {

                    BadRequest(ee);
                }

                return CreatedAtAction("GetTipoUsuarios", new { id = tipoUsuario.IdTipoUsuario }, tipoUsuario);
            }

            // DELETE: api/TipoUsuarios/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.TipoUsuario>> DeleteTipoUsuario(int id)
            {
                var tipoUsuario = await new BE.BS.TipoUsuarios(_context).GetOneByIdAsync(id);
                if (tipoUsuario == null)
                {
                    return NotFound();
                }
                try
                {
                    new BE.BS.TipoUsuarios(_context).Delete(tipoUsuario);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.TipoUsuario mapaAux = _mapper.Map<data.TipoUsuario, models.TipoUsuario>(tipoUsuario);

                return mapaAux;
            }

            private bool TipoUsuarioExists(int id)
            {
                return (new BE.BS.TipoUsuarios(_context).GetOneById(id) != null);
            }
        }
    }

