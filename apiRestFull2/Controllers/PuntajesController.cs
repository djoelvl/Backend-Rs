using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiRestFull2.Data;
using apiRestFull2.Models;

namespace apiRestFull2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntajesController : ControllerBase
    {
        private readonly apiRestFull2Context _context;

        public PuntajesController(apiRestFull2Context context)
        {
            _context = context;
        }

        // GET: api/Puntajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puntajes>>> GetPuntajes()
        {
            return await _context.Puntaje.ToListAsync();
        }

        // GET: api/Puntajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puntajes>> GetPuntajes(int id)
        {
            var puntajes = await _context.Puntaje.FindAsync(id);

            if (puntajes == null)
            {
                return NotFound();
            }

            return puntajes;
        }

        // PUT: api/Puntajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuntajes(int id, Puntajes puntajes)
        {
            if (id != puntajes.id)
            {
                return BadRequest();
            }

            _context.Entry(puntajes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {   
                if (!PuntajesExists(id))
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

        // POST: api/Puntajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puntajes>> PostPuntajes(Puntajes puntajes)
        {
            await  _context.Puntaje.AddAsync(puntajes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuntajes", new { id = puntajes.id }, puntajes);
        }

        // DELETE: api/Puntajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuntajes(int id)
        {
            var puntajes = await _context.Puntaje.FindAsync(id);
            if (puntajes == null)
            {
                return NotFound();
            }

            _context.Puntaje.Remove(puntajes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuntajesExists(int id)
        {
            return _context.Puntaje.Any(e => e.id == id);
        }
    }
}
