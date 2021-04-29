using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocial.Services.Entities
{
    public class Publicacion
    {   
        public int Id { get; set; }

        public string Contenido { get; set; }

        public int UserId { get; set; }

    }
}
