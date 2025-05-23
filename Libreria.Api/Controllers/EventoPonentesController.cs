using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libreria.Api.Data;
using Libreria.Modelos;

namespace Libreria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoPonentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventoPonentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventoPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoPonente>>> GetEventoPonentes()
        {
            return await _context.EventoPonentes.ToListAsync();
        }

        // GET: api/EventoPonentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoPonente>> GetEventoPonente(int id)
        {
            var eventoPonente = await _context.EventoPonentes.FindAsync(id);

            if (eventoPonente == null)
            {
                return NotFound();
            }

            return eventoPonente;
        }

        // PUT: api/EventoPonentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoPonente(int id, EventoPonente eventoPonente)
        {
            if (id != eventoPonente.EventoPonenteId)
            {
                return BadRequest();
            }

            _context.Entry(eventoPonente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoPonenteExists(id))
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

        // POST: api/EventoPonentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoPonente>> PostEventoPonente(EventoPonente eventoPonente)
        {
            _context.EventoPonentes.Add(eventoPonente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoPonente", new { id = eventoPonente.EventoPonenteId }, eventoPonente);
        }

        // DELETE: api/EventoPonentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoPonente(int id)
        {
            var eventoPonente = await _context.EventoPonentes.FindAsync(id);
            if (eventoPonente == null)
            {
                return NotFound();
            }

            _context.EventoPonentes.Remove(eventoPonente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoPonenteExists(int id)
        {
            return _context.EventoPonentes.Any(e => e.EventoPonenteId == id);
        }
    }
}
