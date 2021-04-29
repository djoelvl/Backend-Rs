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
    public class CargosController : ControllerBase
    {
        private readonly apiRestFull2Context _context;

        public CargosController(apiRestFull2Context context)
        {
            _context = context;
        }

        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
            return await _context.Cargos.ToListAsync();
        }


        // PUT: api/Cargos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("[action]/{Cargos}")]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargosbyCargos(string cargos)
        {
            var cargo = await _context.Cargos.Where(x => x.Cargos == cargos).ToListAsync();

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        [HttpGet("[action]/{CargoId}")]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargosbyCargoId(int cargoid)
        {
            var cargo = await _context.Cargos.Where(x => x.CargoId == cargoid).ToListAsync();

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargos(int id, Cargo cargos)
        {
            if (id != cargos.CargoId)
            {
                return BadRequest();
            }

            _context.Entry(cargos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargosExists(id))
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

        // POST: api/Cargos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargos(Cargo cargos)
        {
            _context.Cargos.Add(cargos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargos", new { id = cargos.CargoId }, cargos);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargos(int id)
        {
            var cargos = await _context.Cargos.FindAsync(id);
            if (cargos == null)
            {
                return NotFound();
            }

            _context.Cargos.Remove(cargos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargosExists(int id)
        {
            return _context.Cargos.Any(e => e.CargoId == id);
        }
    }
}
