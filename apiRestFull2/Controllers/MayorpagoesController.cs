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
    public class MayorpagoesController : ControllerBase
    {
        private readonly apiRestFull2Context _context;

        public MayorpagoesController(apiRestFull2Context context)
        {
            _context = context;
        }

        // GET: api/Mayorpagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mayorpago>>> GetMayorpago()
        {
            return await _context.Mayorpago.ToListAsync();
        }

        // GET: api/Mayorpagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mayorpago>> GetMayorpago(int id)
        {
            var mayorpago = await _context.Mayorpago.FindAsync(id);

            if (mayorpago == null)
            {
                return NotFound();
            }

            return mayorpago;
        }



        // PUT: api/Mayorpagoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMayorpago(int id, Mayorpago mayorpago)
        {
            if (id != mayorpago.id)
            {
                return BadRequest();
            }

            _context.Entry(mayorpago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MayorpagoExists(id))
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

        // POST: api/Mayorpagoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mayorpago>> PostMayorpago(Mayorpago mayorpago)
        {
            _context.Mayorpago.Add(mayorpago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMayorpago", new { id = mayorpago.id }, mayorpago);
        }

        // DELETE: api/Mayorpagoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMayorpago(int id)
        {
            var mayorpago = await _context.Mayorpago.FindAsync(id);
            if (mayorpago == null)
            {
                return NotFound();
            }

            _context.Mayorpago.Remove(mayorpago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MayorpagoExists(int id)
        {
            return _context.Mayorpago.Any(e => e.id == id);
        }
    }
}
