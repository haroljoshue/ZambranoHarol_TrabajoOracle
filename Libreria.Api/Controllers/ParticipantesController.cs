﻿using System;
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
    public class ParticipantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Participantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participante>>> GetParticipantes()
        {
            var participantes = await _context.Participantes
                .Include(p => p.Inscripciones)
                .Include(p => p.Asistencias)
                .ToListAsync();

            return Ok(participantes);
        }

        // GET: api/Participantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participante>> GetParticipante(int id)
        {
            var participante = await _context.Participantes
                .Include(p => p.Inscripciones)
                .Include(p => p.Asistencias)
                .FirstOrDefaultAsync(p => p.ParticipanteId == id);

            if (participante == null)
            {
                return NotFound();
            }

            return Ok(participante);
        }

        // PUT: api/Participantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipante(int id, Participante participante)
        {
            if (id != participante.ParticipanteId)
            {
                return BadRequest();
            }

            _context.Entry(participante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteExists(id))
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

        // POST: api/Participantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participante>> PostParticipante(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipante", new { id = participante.ParticipanteId }, participante);
        }

        // DELETE: api/Participantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipanteExists(int id)
        {
            return _context.Participantes.Any(e => e.ParticipanteId == id);
        }
    }
}
