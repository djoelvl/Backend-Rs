using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocial.Services.Entities
{
    public class Solicitud
    {
        public int Id { get; set; }

        public int RemitenteId { get; set; }

        public int DestinatarioId { get; set; }

        public short EstadoId { get; set; }
    }

}
