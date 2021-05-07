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
                            Estado = _db.Solicitud.Where(s => (s.RemitenteId == a.Id && s.DestinatarioId == id) ||
                            (s.RemitenteId == id && s.DestinatarioId == a.Id)).Select(s=>s.Estado).FirstOrDefault()
                           
                            
                        }
                                            ;

            return await query.Distinct().ToListAsync();
        }

      

        public async Task<Solicitud> EnviarSolicitudAsync(Solicitud solicitud)
        {
            var item = await _db.Solicitud
                .FirstOrDefaultAsync(l => l.RemitenteId == solicitud.RemitenteId 
                && l.DestinatarioId == solicitud.DestinatarioId || l.RemitenteId == solicitud.DestinatarioId
                && l.DestinatarioId == solicitud.RemitenteId);

            var amistad = new Solicitud
            {
                RemitenteId = solicitud.RemitenteId,
                DestinatarioId = solicitud.DestinatarioId,
                Estado = solicitud.Estado
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
            
            var query =
                await _db.Solicitud.FirstOrDefaultAsync
                (s => (s.RemitenteId == solicitud.RemitenteId && s.DestinatarioId == solicitud.DestinatarioId)
         );


            if (query == null)
            {
                throw new Exception("Ya le envío una solicitud");
            }

            query.Estado = solicitud.Estado;

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

        public async Task<IEnumerable<UsuariosSolicitudModel>> GetSolicitudAsync(int id)
        {
           

            var query = from a in _db.User
                        join b in _db.Solicitud on a.Id equals b.RemitenteId into ab
                        from c in ab.DefaultIfEmpty()
                        where c.DestinatarioId == id && c.Estado == "enviada"

                        select
                        new UsuariosSolicitudModel
                        {
                            Id = a.Id,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            UserName = a.UserName
                        };

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Solicitud>> DeleteSolicitudAsync(int remitenteId, int destinatarioId)
        {
            var query = await _db.Solicitud.FirstOrDefaultAsync(s=>(s.RemitenteId == remitenteId && s.DestinatarioId == destinatarioId));

             _db.Remove(query);
            await _db.SaveChangesAsync();

            return await _db
                .Solicitud
                .Select(p => new Solicitud
                {
                    Id = p.Id,
                    DestinatarioId = p.DestinatarioId,
                    RemitenteId = p.RemitenteId,
                    Estado = p.Estado

                }).ToListAsync();
        }
    }

    


    }
    

