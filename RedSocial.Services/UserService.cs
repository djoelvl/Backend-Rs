using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RedSocial.Models;
using RedSocial.Services.Db;
using RedSocial.Services.Entities;
using RedSocial.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace RedSocial.Services
{
    public class UserService : IUserService
    {
        private readonly RsDbContext _db;
        private readonly IConfiguration _configuration;


        

        public UserService(RsDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;

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
                        }).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            //    var secretKey = _configuration.GetValue<string>("SecretKey");
            //    var key = Encoding.ASCII.GetBytes(secretKey);

            //    // Creamos los claims (pertenencias, características) del usuario
            //    var claims = new[]
            //    {
            //    new Claim(ClaimTypes.NameIdentifier, user.UserId),
            //    new Claim(ClaimTypes.Email, user.Email)
            //};

            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = claims,
            //        // Nuestro token va a durar un día
            //        Expires = DateTime.UtcNow.AddDays(1),
            //        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //    };

            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            //    return tokenHandler.WriteToken(createdToken);

            //user.Token  = GenerateToken(user.Id);

            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_super_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);


            user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                      

            return user;
        }

        //private string GenerateToken(int userId)=>
        //    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Guid.NewGuid()}|{userId}|{DateTime.UtcNow}|1"));


        

    }
}
