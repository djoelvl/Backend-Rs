using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Mayorpago
    {
        [Key]
        public int id { get; set; }
        public string Mes { get; set; }
        public double Pago { get; set; }
    }
}
