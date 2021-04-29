using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedSocial.Models;
using RedSocial.Services.Entities;
using RedSocial.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsWebApi.Controllers
{
    public class AmigoController : Controller
    {
        private readonly IAmigoService _AmigoService;

        public AmigoController(IAmigoService amigoService)
        {
            _AmigoService = amigoService;
        }

        [HttpGet("[action]/{id}")]
        public async Task <IActionResult> GetAmigo(int id)
        {
            return Ok(await _AmigoService.GetAmigoAsync(id));
        }

        [HttpPost("[action]")]
        public async Task <IActionResult> EnviarSolicitud(Solicitud solicitud)
        {
            return Ok(await _AmigoService.EnviarSolicitudAsync(solicitud));
        }

       [HttpPut("[action]")]
       public async Task <IActionResult> AceptarSolicitud (Solicitud solicitud)
        {
            return Ok(await _AmigoService.AceptarSolicitudAsync(solicitud));
        }
        
        [HttpGet("[action]")]
        public async Task <IActionResult> GetSolicitud()
        {
            return Ok(await _AmigoService.GetSolicitudAsync());
        }

        [HttpDelete("[action]")]
        public async Task <IActionResult> DeleteSolicitud(int id)
        {
            return Ok(await _AmigoService.DeleteSolicitudAsync(id));
        }

        

    }
}
