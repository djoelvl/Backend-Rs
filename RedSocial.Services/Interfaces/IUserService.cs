using RedSocial.Models;
using RedSocial.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Services.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<UserModel>> GetUsuariosAsync(int id);

        Task<User> CreateUserAsync(User model);

        Task<UserModel> UpdateUserAsync(UserModel model);

        Task<IEnumerable<LoginResult>> LoginResultAsync (string userName);

        Task<IEnumerable<UserModel>> DeteleUserAsync(int id);

        Task<LoginResult> LoginAsync(string userName, string password);

    }

}
