using RedSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Services.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<UserModel>> GetUsuariosAsync(Pagination pagination);

        Task<UserModel> CreateUserAsync(UserModel model);

        Task<UserModel> UpdateUserAsync(UserModel model);

        Task<IEnumerable<LoginResult>> LoginResultAsync (string userName);

        Task<IEnumerable<UserModel>> DeteleUserAsync(int id);
    }

}
