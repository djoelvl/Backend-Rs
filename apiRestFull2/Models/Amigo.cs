using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Amigo
    {
        [Key]
        public int amigosId { get; set; }

        public int remitenteId { get; set; }

        public int destinatarioId { get; set; }
    }
}
