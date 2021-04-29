using Microsoft.EntityFrameworkCore;
using RedSocial.Models;
using RedSocial.Services.Db;
using RedSocial.Services.Entities;
using RedSocial.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Services
{
   
        public class AmigoService : IAmigoService
        {
          

        private readonly RsDbContext _db;

        public AmigoService(RsDbContext db)
        {
            _db = db;
        }

       

        public async Task<IEnumerable<UsuariosSolicitudModel>> GetAmigoAsync(int id)
            {
            var query = from a in _db.User
                        join b in _db.Solicitud on a.Id equals b.DestinatarioId into ab
                        from c in ab.DefaultIfEmpty()
                        where a.Id != id

                        select
                        new UsuariosSolicitudModel
                        {
                            Id = a.Id,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            UserName = a.UserName,
                            Estado = "Enviada"                         
                        }
                                            ;

            return await query.ToListAsync();
        }

        public async Task<Solicitud> EnviarSolicitudAsync(Solicitud solicitud)
        {
            var item = await _db.Solicitud
                .FirstOrDefaultAsync(l => l.RemitenteId == solicitud.RemitenteId 
                && l.DestinatarioId == solicitud.DestinatarioId);

            var amistad = new Solicitud
            {
                RemitenteId = solicitud.RemitenteId,
                DestinatarioId = solicitud.DestinatarioId,
                EstadoId = solicitud.EstadoId
            };

            if (item == null)
            {
                
                await _db.Solicitud.AddAsync(amistad);

            }
            else
            {
                throw new Exception("Ya le envío una solicitud");
            }

            solicitud.Id = amistad.Id;
            await _db.SaveChangesAsync();
            

            return solicitud;
            

        }

        public async Task <Solicitud> AceptarSolicitudAsync(Solicitud solicitud)
        {
            //[HttpPut("[action]/{remitenteId}/{destinatarioId}")]
            //public async Task<IActionResult> DeleteSolicitud( int remitenteId, int destinatarioId, Solicitud solicitud)
            //{
            var query =
                await _db.Solicitud.FirstOrDefaultAsync
                (s => (s.RemitenteId == solicitud.RemitenteId && s.DestinatarioId == solicitud.DestinatarioId)
         );


            if (query == null)
            {
                throw new Exception("Ya le envío una solicitud");
            }

            query.EstadoId = solicitud.EstadoId;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (solicitud == null)
            {
                throw new Exception("Ya le envío una solicitud");
            }

            return query;
        }

        public async Task<IEnumerable<Solicitud>> GetSolicitudAsync()
        {
            return await _db.Solicitud.Select(s=>
            new Solicitud { 
                Id = s.Id,
                DestinatarioId = s.DestinatarioId,
                RemitenteId = s.RemitenteId,
                EstadoId = s.EstadoId
            }).ToListAsync();
        }

        public async Task<IEnumerable<Solicitud>> DeleteSolicitudAsync(int id)
        {
            var query = await _db.Solicitud.FindAsync(id);

             _db.Remove(query);
            await _db.SaveChangesAsync();

            return await _db
                .Solicitud
                .Select(p => new Solicitud
                {
                    Id = p.Id,
                    DestinatarioId = p.DestinatarioId,
                    RemitenteId = p.RemitenteId,
                    EstadoId = p.EstadoId

                }).ToListAsync();
        }
    }

    


    }
    

