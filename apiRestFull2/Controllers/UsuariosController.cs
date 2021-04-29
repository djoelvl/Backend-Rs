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
    public class UsuariosController : ControllerBase
    {
        private readonly apiRestFull2Context _context;

        public UsuariosController(apiRestFull2Context context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("[action]/{UserName}")]
        public async Task<ActionResult<Usuario>> GetuserByUserName(string username)
        {
            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName == username);

            if (usuarios == null)
            {
                return NotFound();
            }
            return usuarios;
        }



        [HttpGet("[action]/{UserName}")]
        public async Task<ActionResult<IEnumerable<LoginResult>>> loginResult(string username)
        {

            var query = from a in _context.Usuarios
                        where a.UserName == username
                        select new LoginResult
                        {
                            Id = a.Id,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            UserName = a.UserName,
                            Token = Guid.NewGuid().ToString()
                        };



            return await query.ToListAsync();


        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarios(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        [HttpGet("[action]/{UserName}/{Password}")]
        public async Task<ActionResult<Usuario>> login(string username, string password)
        {

            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);

            if (usuarios == null)
            {
                return NotFound();
            }



            return usuarios;
        }


        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuario usuarios)
        {
            if (id != usuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public async Task<ActionResult<LoginResult>> Register(Usuario usuarios)
        {

            var user = await _context.Usuarios.FirstOrDefaultAsync(f => f.UserName == usuarios.UserName);
            if (user != null)
                throw new Exception("El usuario ya existe");


            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios", new { id = usuarios.Id });


        }

   


        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("[action]/{remitenteId}/{destinatarioId}")]
        public async Task<IActionResult> DeleteSolicitud( int remitenteId, int destinatarioId, Solicitud solicitud)
        {
            var query = 
                await _context.solicitudamistad.FirstOrDefaultAsync
                (s => (s.remitenteId == remitenteId && s.destinatarioId==destinatarioId)
         );
            //if (solicitud == null)
            //{
            //    return NotFound();
            //}

            //_context.solicitudamistad.Remove(query);
            //await _context.SaveChangesAsync();

            //return NoContent();


            if (query == null)
            {
                return NotFound();
            }

            query.estado = solicitud.estado;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UsuariosExists(remitenteId))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("[action]/{Id}/{amigoId}")]
        public async Task<ActionResult<IEnumerable<AmigosModel>>> GetUserFriend(int id, int amigoId)
            {

            //var query = from a in _context.Usuarios
            //            join b in _context.Amigos on a.Id equals amigoId

            //            select new AmigosModel
            //            {
            //               remitenteId = a.Id,
            //               destinatarioId = b.destinatarioId,
            //               friendFirstName = a.FirstName,
            //               friendLastName = a.LastName,
            //               friendUserName = a.UserName
            //            };


            var query = from a in _context.Usuarios
                        where a.Id == amigoId
                        select new AmigosModel
                        {
                            remitenteId = id,
                            destinatarioId = a.Id,
                            friendFirstName = a.FirstName,
                            friendLastName = a.LastName,
                            friendUserName = a.UserName
                            
                        };


            return await query.ToListAsync();


        }



        [HttpPost("[action]")]
        public async Task<ActionResult<IEnumerable<SolicitudAmistadModel>>> solicitudFriend(Solicitud solicitud)
        {
            
            var item = await _context.solicitudamistad
                .FirstOrDefaultAsync(l => l.remitenteId == solicitud.remitenteId && l.destinatarioId == solicitud.destinatarioId);

            if(item == null)
            {
                await _context.solicitudamistad.AddAsync(solicitud);
              
            }
            else
            {
                    throw new Exception("Ya le envío una solicitud");
            }
              

            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpPost("[action]")]
        public async Task<ActionResult<IEnumerable<Amigo>>>aceptarAmigo(Amigo amigo)
        {

            var item = await _context.amigo
                .FirstOrDefaultAsync(l => l.remitenteId == amigo.remitenteId && l.destinatarioId == amigo.destinatarioId);

            if (item == null)
            {
                await _context.amigo.AddAsync(amigo);

            }
            else
            {
                throw new Exception("Ya era su amigo");
            }


            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpGet("[action]/{remitenteId}/{destinatarioId}")]
        public async Task<ActionResult<IEnumerable<Solicitud>>> solicitudVer(int remitenteId, int destinatarioId)
        {

            var usuarios = await _context.solicitudamistad.
                Where(s=>s.remitenteId == remitenteId && s.destinatarioId == destinatarioId).
                ToListAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;

      

        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<UsuariosSolicitudModel>>> getUserSolicitudamistad(int id)
        {
            var query = from a in _context.Usuarios
                        join b in _context.solicitudamistad on a.Id equals b.remitenteId into ab
                        from c in ab.DefaultIfEmpty()
                        where (a.Id != id && c.estado != "aceptada" && c.destinatarioId == id)

                        select
                        new UsuariosSolicitudModel
                        {
                            id = a.Id,
                            firstName = a.FirstName,
                            lastName = a.LastName,
                            userName = a.UserName,
                            estado = c.estado

                        }
                       ;

            return await query.ToListAsync();



        }



        ////[HttpGet("[action]")]
        //public async Task<ActionResult<IEnumerable>>

        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetNotUser(int id)
        {

                return await _context.Usuarios.Where(s=>s.Id != id).ToListAsync();

        }
        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult<IEnumerable<UsuariosSolicitudModel>>> GetUserNoFriend(int id)
        {


            var query = from a in _context.Usuarios
                        join b in _context.solicitudamistad on a.Id equals b.destinatarioId into ab
                        from c in ab.DefaultIfEmpty()
                        where a.Id != id
                       
                        select
                        new UsuariosSolicitudModel
                        {
                            id = a.Id,
                            firstName = a.FirstName,
                            lastName = a.LastName,
                            userName = a.UserName,
                            estado = c.estado
                            
                        }
                        ;

            return await query.ToListAsync();

            //return await _context.Usuarios.Where(s => s.Id != id && _context.solicitudamistad.Where(s => s.remitenteId == id && s.destinatarioId == destinatarioId).Count() > 0).ToListAsync();

        }
                     


        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
