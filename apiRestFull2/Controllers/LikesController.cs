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
    public class LikesController: ControllerBase
    {
        private readonly apiRestFull2Context _context;

        public LikesController(apiRestFull2Context context)
        {
            _context = context;
        }

        [HttpGet ("[action]/{publicacionId}")]

        public async Task <ActionResult<IEnumerable<ModelLike>>> GetlikeBypublicacion(int publicacionId)
        {
            return await _context.
                UserLike.
                Where(s=> s.publicacionId == publicacionId)
                .ToListAsync();

        }

        [HttpPost("[action]")]

        public async Task<ActionResult<ModelLike>> DarLike(ModelLike like)
        {

            var item = await _context.UserLike
                .FirstOrDefaultAsync(l => l.publicacionId == like.publicacionId && like.remitenteId == like.remitenteId);

            var likeAdded = 0;
            if(item == null)
            {
                await _context.UserLike.AddAsync(like);
                likeAdded = 1;
            }
            else
            {
                _context.UserLike.Remove(item);
                likeAdded = -1;
            }
              

            await _context.SaveChangesAsync();

            return Ok(likeAdded);
            
        }

        [HttpDelete("[action]/{likeId}/{rmeitenteId}")]

       public async Task<IActionResult> DeleteLike(int likeId, int remitenteId)
        {
            var query = await _context.UserLike.FindAsync(likeId, remitenteId);
            if (query == null)
            {
                return NotFound();
            }

            _context.UserLike.Remove(query);
            await _context.SaveChangesAsync();

            return NoContent();
        }
           

    }
}
