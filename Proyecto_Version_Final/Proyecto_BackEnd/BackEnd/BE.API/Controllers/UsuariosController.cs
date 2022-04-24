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
    public class UsuariosController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Usuario>>> GetUsuario()
        {
            var res = new BE.BS.Usuarios(_context).GetAll();
            List<models.Usuario> mapaAux = _mapper.Map<IEnumerable<data.Usuario>, IEnumerable<models.Usuario>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Usuario>> GetUsuario(int id)
        {
            var usuario = new BE.BS.Usuarios(_context).GetOneById(id);

            if (usuario == null)
            {
                return NotFound();
            }
            models.Usuario mapaAux = _mapper.Map<data.Usuario, models.Usuario>(usuario);

            return mapaAux;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, models.Usuario usuario)
        {
            if (id != usuario.Cedula)
            {
                return BadRequest();
            }

            try
            {
                data.Usuario mapaAux = _mapper.Map<models.Usuario, data.Usuario>(usuario);

                new BE.BS.Usuarios(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Usuario>> PostUsuario(models.Usuario usuario)
        {
            try
            {
                data.Usuario mapaAux = _mapper.Map<models.Usuario, data.Usuario>(usuario);
                new BE.BS.Usuarios(_context).Insert(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetUsuario", new { id = usuario.Cedula }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Usuario>> DeleteUsuario(int id)
        {
            var usuario = new BE.BS.Usuarios(_context).GetOneById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Usuarios(_context).Delete(usuario);
            }
            catch (Exception)
            {

                BadRequest();
            }
            models.Usuario mapaAux = _mapper.Map<data.Usuario, models.Usuario>(usuario);

            return mapaAux;
        }

        private bool UsuarioExists(int id)
        {
            return (new BE.BS.Usuarios(_context).GetOneById(id) != null);
        }
    }
}
