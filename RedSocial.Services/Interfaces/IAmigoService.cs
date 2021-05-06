using RedSocial.Models;
using RedSocial.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Services.Interfaces
{
    public interface IAmigoService
    {
        Task<IEnumerable<UsuariosSolicitudModel>> GetAmigoAsync(int id);

        Task<Solicitud> EnviarSolicitudAsync(Solicitud solicitud);

        Task<Solicitud> AceptarSolicitudAsync(Solicitud solicitud);

        Task<IEnumerable<UsuariosSolicitudModel>> GetSolicitudAsync(int id);

        Task<IEnumerable<Solicitud>> DeleteSolicitudAsync(int remitenteId, int destinatarioId);
    }
}
