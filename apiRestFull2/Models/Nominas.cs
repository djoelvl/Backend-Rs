using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Nominas
    {

        [Key]
        public int Id { get; set; }
        public string Ano { get; set; }

        public string Mes { get; set; }

        public string Departamento { get; set; }

        public int CargoId { get; set; }

        public string Nombre { get; set; }

        public  double Sueldo { get; set; }

    }


    public class NominaModel
    {

        public int Id { get; set; }
        public string Ano { get; set; }

        public string Mes { get; set; }

        public string Departamento { get; set; }

        public int CargoId { get; set; }
        public string Cargo { get; set; }

        public string Nombre { get; set; }

        public double Sueldo { get; set; }

    }

}
