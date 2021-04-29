using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Solicitud
    {
        [Key]
        public int solicitudId { get; set; }

        public int remitenteId { get; set; }

        public int destinatarioId { get; set; }

        public string estado { get; set; }
    }

}
