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
    public class EventsController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public EventsController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Events>>> GetEvents()
        {
            var res = new BE.BS.Events(_context).GetAll();
            List<models.Events> mapaAux = _mapper.Map<IEnumerable<data.Events>, IEnumerable<models.Events>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Events>> GetEvents(int id)
        {
            var events = new BE.BS.Events(_context).GetOneById(id);

            if (events == null)
            {
                return NotFound();
            }
            models.Events mapaAux = _mapper.Map<data.Events, models.Events>(events);

            return mapaAux;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvents(int id, models.Events events)
        {
            if (id != events.EventId)
            {
                return BadRequest();
            }

            try
            {
                data.Events mapaAux = _mapper.Map<models.Events, data.Events>(events);

                new BE.BS.Events(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!EventsExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Events>> PostEvents(models.Events events)
        {
            try
            {
                data.Events mapaAux = _mapper.Map<models.Events, data.Events>(events);
                new BE.BS.Events(_context).Insert(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetEvents", new { id = events.EventId }, events);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Events>> DeleteEvents(int id)
        {
            var events = new BE.BS.Events(_context).GetOneById(id);
            if (events == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.Events(_context).Delete(events);
            }
            catch (Exception)
            {

                BadRequest();
            }
            models.Events mapaAux = _mapper.Map<data.Events, models.Events>(events);

            return mapaAux;
        }

        private bool EventsExists(int id)
        {
            return (new BE.BS.Events(_context).GetOneById(id) != null);
        }
    }
}

