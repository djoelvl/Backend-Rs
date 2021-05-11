using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedSocial.Services.Interfaces;
using RedSocial.Models;
using System.Collections.Generic;
using System;
using RsWebApi;

namespace RsWebApi.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        private readonly IPublicacionService _publicacionService;

        
        public PublicacionController(IPublicacionService publicacionService)
        {
            _publicacionService = publicacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublicacion()
        {
            return Ok(await _publicacionService.GetPublicacionAsync());
        }



        [HttpGet("[action]/{id}/{amigoId}")]
        public async Task<IActionResult> GetPublicacionByUserLikeCount(int id, int amigoId)
        {

            


            return Ok(await _publicacionService.GetPublicacionByUserLikeCountAsync(id, amigoId));
        }

        [HttpGet("[action]/{id}/{amigoId}")]
        public async Task<IActionResult> GetPublicacionByUserLike(int id, int amigoId)
        {
            return Ok(await _publicacionService.GetPublicacionByUserLikeCountAsync(id, amigoId));
        }

        [HttpPost]
        public async Task<IActionResult> PostPublicacion(PublicacionModel model)
        {
            return Ok(await _publicacionService.PostPublicacionAsync(model));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePublicacion(int id)
        {
            return Ok(await _publicacionService.DeletePublicacionAsync(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DarLike([FromBody] LikeModel model)
        {
            return Ok(await _publicacionService.DarLikeAsync(model));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserPublicacion(int id)
        {
            return Ok(await _publicacionService.GetUserpublicacionAsync(id));
        }

       
    }
}