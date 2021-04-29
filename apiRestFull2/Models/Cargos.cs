using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Cargo
    {
                [Key]
        public int CargoId { get; set; }

        public string Cargos { get; set; }
    }
}
