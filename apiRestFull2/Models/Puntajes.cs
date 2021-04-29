using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Puntajes
    {
        [Key]
        public int id { get; set; }

        public string Nombre { get; set; }

        public int Puntaje { get; set; }

    }


    public class PuntajeModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public int Puntaje { get; set; }

    }
}
