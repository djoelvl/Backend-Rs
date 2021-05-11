using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoService _amigoService;

        public AmigoController(IAmigoService amigoService)
        {
            _amigoService = amigoService;
        }

        [HttpGet("[action]/{id}")]
        public async Task <IActionResult> GetAmigo(int id)
        {
            return Ok(await _amigoService.GetAmigoAsync(id));
        }

        [HttpPost("[action]")]
        public async Task <IActionResult> EnviarSolicitud([FromBody] Solicitud solicitud)
        {
            return Ok(await _amigoService.EnviarSolicitudAsync(solicitud));
        }

       [HttpPut("[action]")]
       public async Task <IActionResult> AceptarSolicitud ([FromBody] Solicitud solicitud)
        {
            return Ok(await _amigoService.AceptarSolicitudAsync(solicitud));
        }
        
        [HttpGet("[action]/{id}")]
        public async Task <IActionResult> GetSolicitud(int id)
        {
            return Ok(await _amigoService.GetSolicitudAsync(id));
        }

        [HttpDelete("[action]/{remitenteId}/{destinatarioId}")]
        public async Task <IActionResult> DeleteSolicitud(int remitenteId, int destinatarioId)
        {
            return Ok(await _amigoService.DeleteSolicitudAsync(remitenteId, destinatarioId));
        }

      

    }
}
