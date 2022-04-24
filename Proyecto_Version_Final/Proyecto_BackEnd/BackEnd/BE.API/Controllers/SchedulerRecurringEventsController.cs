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
    public class SchedulerRecurringEventsController : ControllerBase
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public SchedulerRecurringEventsController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SchedulerRecurringEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.SchedulerRecurringEvent>>> GetSchedulerRecurringEvent()
        {
            var res = new BE.BS.SchedulerRecurringEvents(_context).GetAll();
            List<models.SchedulerRecurringEvent> mapaAux = _mapper.Map<IEnumerable<data.SchedulerRecurringEvent>, IEnumerable<models.SchedulerRecurringEvent>>(res).ToList();
            return mapaAux;
        }

        // GET: api/SchedulerRecurringEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.SchedulerRecurringEvent>> GetSchedulerRecurringEvent(int id)
        {
            var schedulerRecurringEvent = new BE.BS.SchedulerRecurringEvents(_context).GetOneById(id);

            if (schedulerRecurringEvent == null)
            {
                return NotFound();
            }
            models.SchedulerRecurringEvent mapaAux = _mapper.Map<data.SchedulerRecurringEvent, models.SchedulerRecurringEvent>(schedulerRecurringEvent);

            return mapaAux;
        }

        // PUT: api/SchedulerRecurringEvents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedulerRecurringEvent(int id, models.SchedulerRecurringEvent schedulerRecurringEvent)
        {
            if (id != schedulerRecurringEvent.Id)
            {
                return BadRequest();
            }

            try
            {
                data.SchedulerRecurringEvent mapaAux = _mapper.Map<models.SchedulerRecurringEvent, data.SchedulerRecurringEvent>(schedulerRecurringEvent);

                new BE.BS.SchedulerRecurringEvents(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!SchedulerRecurringEventExists(id))
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

        // POST: api/SchedulerRecurringEvents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.SchedulerRecurringEvent>> PostSchedulerRecurringEvent(models.SchedulerRecurringEvent schedulerRecurringEvent)
        {
            try
            {
                data.SchedulerRecurringEvent mapaAux = _mapper.Map<models.SchedulerRecurringEvent, data.SchedulerRecurringEvent>(schedulerRecurringEvent);
                new BE.BS.SchedulerRecurringEvents(_context).Insert(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetSchedulerRecurringEvent", new { id = schedulerRecurringEvent.Id }, schedulerRecurringEvent);
        }

        // DELETE: api/SchedulerRecurringEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.SchedulerRecurringEvent>> DeleteSchedulerRecurringEvent(int id)
        {
            var schedulerRecurringEvent = new BE.BS.SchedulerRecurringEvents(_context).GetOneById(id);
            if (schedulerRecurringEvent == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.SchedulerRecurringEvents(_context).Delete(schedulerRecurringEvent);
            }
            catch (Exception)
            {

                BadRequest();
            }
            models.SchedulerRecurringEvent mapaAux = _mapper.Map<data.SchedulerRecurringEvent, models.SchedulerRecurringEvent>(schedulerRecurringEvent);

            return mapaAux;
        }

        private bool SchedulerRecurringEventExists(int id)
        {
            return (new BE.BS.SchedulerRecurringEvents(_context).GetOneById(id) != null);
        }
    }
}

