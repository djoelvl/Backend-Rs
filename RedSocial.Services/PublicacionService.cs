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
    public class PublicacionService : IPublicacionService
    {

        private readonly RsDbContext _db;

        public PublicacionService(RsDbContext db)
        {
            _db = db;
        }



        public async Task<IEnumerable<PublicacionModel>> GetPublicacionAsync()
        {
            return await _db
                .Publicacion
                .Select(p => new PublicacionModel
                {
                    Id = p.Id,
                    Contenido = p.Contenido,
                    UserId = p.UserId

                }).ToListAsync();
        }

        public async Task<IEnumerable<PublicacionModel>> GetPublicacionByUserLikeCountAsync(int id, int amigoId)
        {



            var query = from a in _db.Publicacion
                        where a.UserId == id
                        select new PublicacionModel
                        {

                            Id = a.Id,
                            Contenido = a.Contenido,
                            UserId = a.UserId,
                            CantidadLikes = _db.Like.Where(w => w.PublicacionId == a.Id).Count(),
                            Liked = _db.Like.Where(w => w.PublicacionId == a.Id && w.RemitenteId == amigoId).Any()


                        };

            return await query.ToListAsync();
        }

        public async Task<PublicacionModel> PostPublicacionAsync(PublicacionModel model)
        {
            var query = new Publicacion
            {
                Contenido = model.Contenido,
                UserId = model.UserId
            };

            await _db.Publicacion.AddAsync(query);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<PublicacionModel>> DeletePublicacionAsync(int id)
        {
            var query = await _db.Publicacion.FindAsync(id);

            _db.Publicacion.Remove(query);
            await _db.SaveChangesAsync();

            return await _db
                .Publicacion
                .Select(p => new PublicacionModel
                {
                    Id = p.Id,
                    Contenido = p.Contenido,
                    UserId = p.UserId

                }).ToListAsync();

        }

        public async Task<LikeModel> DarLikeAsync(LikeModel model)
        {
            var item = await _db.Like
                 .FirstOrDefaultAsync(l => l.PublicacionId == model.PublicacionId && l.RemitenteId == model.RemitenteId);

            var query = new Like
            {
                PublicacionId = model.PublicacionId,
                RemitenteId = model.RemitenteId
            };

            var likeAdded = 0;
            if (item == null)
            {
                await _db.Like.AddAsync(query);
                likeAdded = 1;
            }
            else
            {
                _db.Like.Remove(item);
                likeAdded = -1;
            }


            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<PublicacionModel>> GetUserpublicacionAsync(int id)
        {
            return await _db
               .Publicacion.Where(p => p.UserId == id)
               .Select(p => new PublicacionModel
               {
                   Id = p.Id,
                   Contenido = p.Contenido,
                   UserId = p.UserId

               }).ToListAsync();
        }

        
    }
}
