using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedSocial.Services.Interfaces;
using RedSocial.Models;
using System.Collections.Generic;

namespace RsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        private readonly IPublicacionService _publicacionService;

        public PublicacionController(IPublicacionService publicacionService)
        {
            _publicacionService = publicacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublicacion()
        {
            return Ok(await _publicacionService.GetPublicacionAsync());
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPublicacionLike(int id)
        {
            return Ok(await _publicacionService.GetPublicacionLikeCountAsync(id));
        }

        [HttpPost]
        public async Task <IActionResult> PostPublicacion(PublicacionModel model)
        {
            return Ok(await _publicacionService.PostPublicacionAsync(model));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePublicacion(int id)
        {
            return Ok(await _publicacionService.DeletePublicacionAsync(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DarLike(LikeModel model)
        {
            return Ok(await _publicacionService.DarLikeAsync(model));
        }


        // GET: api/publicacions
        //    [HttpGet("[action]/{userId}")]
        //    public async Task<ActionResult<IEnumerable<PublicacionModel>>> GetpublicacionbyId(int userId)
        //    {

        //        var query = from a in _context.publicacion
        //                    join b in _context.UserLike on a.publicacionId equals b.publicacionId
        //                    into pub
        //                    from b in pub.DefaultIfEmpty()
        //                    where a.userId == userId
        //                    group new { a.publicacionId, a.publicacionText } by new { a.publicacionId, a.publicacionText } into g
        //                    select new PublicacionModel
        //                    {

        //                        publicacionId = g.Key.publicacionId,
        //                        publicacionText = g.Key.publicacionText,
        //                        CantidadLikes = g.Count()
        //                    };
        //        var query = from a in _context.publicacion
        //                    where a.userId == userId
        //                    select new PublicacionModel
        //                    {

        //                        publicacionId = a.publicacionId,
        //                        publicacionText = a.publicacionText,
        //                        CantidadLikes = _context.UserLike.Where(w => w.publicacionId == a.publicacionId).Count()
        //                    };



        //        return await query.ToListAsync();
        //    }



        //    GET: api/publicacions/5
        //[HttpGet("{id}")]
        //    public async Task<ActionResult<publicacion>> Getpublicacion(int id)
        //    {
        //        var publicacion = await _context.publicacion.FindAsync(id);

        //        if (publicacion == null)

        //        {
        //            return NotFound();
        //        }

        //        return publicacion;
        //    }

        //    PUT: api/publicacions/5
        //     To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> Putpublicacion(int id, publicacion publicacion)
        //    {
        //        if (id != publicacion.publicacionId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(publicacion).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!publicacionExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    POST: api/publicacions
        //    To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<publicacion>> Postpublicacion(publicacion publicacion)
        //    {
        //        _context.publicacion.Add(publicacion);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("Getpublicacion", new { id = publicacion.publicacionId }, publicacion);
        //    }

        //    DELETE: api/publicacions/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> Deletepublicacion(int id)
        //    {
        //        var publicacion = await _context.publicacion.FindAsync(id);
        //        if (publicacion == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.publicacion.Remove(publicacion);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool publicacionExists(int id)
        //    {
        //        return _context.publicacion.Any(e => e.publicacionId == id);
        //    }
        //}
    }
}
