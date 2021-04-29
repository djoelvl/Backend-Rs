using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestFull2.Models
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }


    public class LoginResult
    {

        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Token { get; set; }
    }


    public class PublicacionModel
    {

        public int publicacionId { get; set; }

        public string publicacionText { get; set; }

        public int userId { get; set; }
        public int CantidadLikes { get; set; }

    }

    public class AmigosModel
    {


        public int remitenteId { get; set; }

        public int destinatarioId { get; set; }

        public string friendUserName { get; set; }

        public string friendFirstName { get; set; }

        public string friendLastName { get; set; }


    }

    public class SolicitudAmistadModel
    {

        public int solicitudId { get; set; }

        public string remitenteId { get; set; }

        public int destinatarioId { get; set; }


    }

    public class UsuariosSolicitudModel
    {


        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string userName { get; set; }

        public string estado { get; set; }

        public int remitenteId { get; set; }
       



    }
}
