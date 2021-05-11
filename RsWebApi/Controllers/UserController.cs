
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedSocial.Services.Interfaces;
using RedSocial.Models;
using RedSocial.Services.Entities;


namespace RsWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUsuarios(int id)
        {
            return Ok(await _userService.GetUsuariosAsync(id));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(User model)
        {
            return Ok(await _userService.CreateUserAsync(model));
        }


        [HttpPut]
        public async Task<IActionResult> PutUser(UserModel model)
        {
            return Ok(await _userService.UpdateUserAsync(model));
        }

        [HttpGet("[action]/{userName}")]
        public async Task<IActionResult> GetLoginResult(string userName)
        {
            return Ok(await _userService.LoginResultAsync(userName));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetLogin(User model)
        {

            return Ok(await _userService.LoginAsync(model.UserName, model.Password));
        }

        [HttpDelete]
        public async Task <IActionResult> DeleteUser(int id)
        {
            return Ok(await _userService.DeteleUserAsync(id));
        }

      
    }
}
