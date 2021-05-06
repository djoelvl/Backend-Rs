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
    public class UserService : IUserService
    {
        private readonly RsDbContext _db;

        public UserService(RsDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUserAsync(User model)
        {
            var user = await _db.User.FirstOrDefaultAsync(f => f.UserName == model.UserName);
            if (user != null)
                throw new Exception("El usuario ya existe");


            await _db.User.AddAsync(model);
            await _db.SaveChangesAsync();

            

            return user;
        }

  


        public async Task<IEnumerable<UserModel>> GetUsuariosAsync(int id)
        {
            var query = from a in _db.User
                        where a.Id == id
                        select new UserModel
                        {
                            Id = a.Id,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            UserName = a.UserName   
                        };

            return await query.ToListAsync();


        }

        public async Task<UserModel> UpdateUserAsync(UserModel model)
        {

            var user = await _db.User.FindAsync(model.Id);

            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;

            await _db.SaveChangesAsync();
            model.Id = user.Id;
            return model;

        }

        public async Task<IEnumerable<LoginResult>> LoginResultAsync(string userName)
        {

            var query = from a in _db.User
                        where a.UserName == userName
                        select new LoginResult
                        {
                            Id = a.Id,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            UserName = a.UserName,
                            Token = Guid.NewGuid().ToString()
                        };

            if (query == null)
            {
                throw new Exception("El usuario no existe");
            }


            return await query.ToListAsync();


        }

        public async Task<IEnumerable<UserModel>> DeteleUserAsync(int id)
        {
            var usuarios = await _db.User.FindAsync(id);
            if (usuarios == null)
            {
                throw new Exception("El usuario no existe");
            }

            _db.User.Remove(usuarios);
            await _db.SaveChangesAsync();



            return await _db.User
                .Select(user => new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName
                }).ToListAsync();
        }

      

        public async Task<LoginResult> LoginAsync(string userName, string password)
        {
            var user = await(from a in _db.User
                        where a.UserName == userName && a.Password == password
                        select new LoginResult
                        {
                            Id = a.Id,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            UserName = a.UserName,
                            Token = Guid.NewGuid().ToString()
                        }).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }


            return  user;
        }
    }
}
