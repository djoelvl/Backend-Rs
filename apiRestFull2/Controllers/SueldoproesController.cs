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
    public class SueldoproesController : ControllerBase
    {
        private readonly apiRestFull2Context _context;

        public SueldoproesController(apiRestFull2Context context)
        {
            _context = context;
        }

        // GET: api/Sueldoproes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sueldopro>>> GetSueldos()
        {
            return await _context.Sueldopro.ToListAsync();
        }

        // GET: api/Sueldoproes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sueldopro>> GetSueldopro(int id)
        {
            var sueldopro = await _context.Sueldopro.FindAsync(id);

            if (sueldopro == null)
            {
                return NotFound();
            }

            return sueldopro;
        }

        // PUT: api/Sueldoproes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSueldopro(int id, Sueldopro sueldopro)
        {
            if (id != sueldopro.id)
            {
                return BadRequest();
            }

            _context.Entry(sueldopro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SueldoproExists(id))
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

        // POST: api/Sueldoproes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sueldopro>> PostSueldopro(Sueldopro sueldopro)
        {
            _context.Sueldopro.Add(sueldopro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSueldopro", new { id = sueldopro.id }, sueldopro);
        }

        // DELETE: api/Sueldoproes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSueldopro(int id)
        {
            var sueldopro = await _context.Sueldopro.FindAsync(id);
            if (sueldopro == null)
            {
                return NotFound();
            }

            _context.Sueldopro.Remove(sueldopro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SueldoproExists(int id)
        {
            return _context.Sueldopro.Any(e => e.id == id);
        }
    }
}
