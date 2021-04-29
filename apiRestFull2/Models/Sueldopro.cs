using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Sueldopro
    {

        [Key]
        public int id { get; set; }

        public string Cargos { get; set; }  

        public double Sueldo { get; set; }
    }

   
}
