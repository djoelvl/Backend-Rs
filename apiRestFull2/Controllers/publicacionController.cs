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
    public class publicacionController : ControllerBase
    {
        /*
        private readonly apiRestFull2Context _context;

        public publicacionController(apiRestFull2Context context)
        {
        _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<publicacion>>> getPublicacion()
        {
            return await _context.publicacion.ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<publicacion>> postPublicacion(publicacion publicacion)
        {

            await _context.publicacion.AddAsync(publicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpublicacion", new { publicacionId = publicacion.publicacionId }, publicacion);
        }

        */
    }




}
