using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerRecurringEventsController : ControllerBase
    {
        private readonly ClinicaContext _context;

        public SchedulerRecurringEventsController(ClinicaContext context)
        {
            _context = context;
        }

        // GET: api/SchedulerRecurringEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchedulerRecurringEvent>>> GetSchedulerRecurringEvent()
        {
            return await _context.SchedulerRecurringEvent.ToListAsync();
        }

        // GET: api/SchedulerRecurringEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchedulerRecurringEvent>> GetSchedulerRecurringEvent(int id)
        {
            var schedulerRecurringEvent = await _context.SchedulerRecurringEvent.FindAsync(id);

            if (schedulerRecurringEvent == null)
            {
                return NotFound();
            }

            return schedulerRecurringEvent;
        }

        // PUT: api/SchedulerRecurringEvents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedulerRecurringEvent(int id, SchedulerRecurringEvent schedulerRecurringEvent)
        {
            if (id != schedulerRecurringEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(schedulerRecurringEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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
        public async Task<ActionResult<SchedulerRecurringEvent>> PostSchedulerRecurringEvent(SchedulerRecurringEvent schedulerRecurringEvent)
        {
            _context.SchedulerRecurringEvent.Add(schedulerRecurringEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedulerRecurringEvent", new { id = schedulerRecurringEvent.Id }, schedulerRecurringEvent);
        }

        // DELETE: api/SchedulerRecurringEvents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SchedulerRecurringEvent>> DeleteSchedulerRecurringEvent(int id)
        {
            var schedulerRecurringEvent = await _context.SchedulerRecurringEvent.FindAsync(id);
            if (schedulerRecurringEvent == null)
            {
                return NotFound();
            }

            _context.SchedulerRecurringEvent.Remove(schedulerRecurringEvent);
            await _context.SaveChangesAsync();

            return schedulerRecurringEvent;
        }

        private bool SchedulerRecurringEventExists(int id)
        {
            return _context.SchedulerRecurringEvent.Any(e => e.Id == id);
        }
    }
}
