using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class publicacion
    {   
        [Key]
        public int publicacionId { get; set; }

        public string publicacionText { get; set; }

        public int userId { get; set; }

    }
}
