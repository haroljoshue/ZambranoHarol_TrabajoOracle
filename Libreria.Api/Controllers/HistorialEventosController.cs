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
    public class HistorialEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialEventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialEvento>>> GetHistorialEventos()
        {
            var historiales = await _context.HistorialEventos
                .Include(h => h.Evento)
                .ToListAsync();

            return Ok(historiales);
        }

        // GET: api/HistorialEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialEvento>> GetHistorialEvento(int id)
        {
            var historial = await _context.HistorialEventos
                .Include(h => h.Evento)
                .FirstOrDefaultAsync(h => h.HistolialEventoId == id);

            if (historial == null)
            {
                return NotFound();
            }

            return Ok(historial);
        }

        // PUT: api/HistorialEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialEvento(int id, HistorialEvento historialEvento)
        {
            if (id != historialEvento.HistolialEventoId)
            {
                return BadRequest();
            }

            _context.Entry(historialEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialEventoExists(id))
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

        // POST: api/HistorialEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialEvento>> PostHistorialEvento(HistorialEvento historialEvento)
        {
            _context.HistorialEventos.Add(historialEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialEvento", new { id = historialEvento.HistolialEventoId }, historialEvento);
        }

        // DELETE: api/HistorialEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialEvento(int id)
        {
            var historialEvento = await _context.HistorialEventos.FindAsync(id);
            if (historialEvento == null)
            {
                return NotFound();
            }

            _context.HistorialEventos.Remove(historialEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialEventoExists(int id)
        {
            return _context.HistorialEventos.Any(e => e.HistolialEventoId == id);
        }
    }
}
