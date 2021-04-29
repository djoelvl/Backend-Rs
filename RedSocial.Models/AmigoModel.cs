namespace RedSocial.Models
{
    public class AmigoModel
    {

        public int Id { get; set; }
        public int RemitenteId { get; set; }

        public int DestinatarioId { get; set; } 

        public string DestinatarioNombre { get; set; }


    }
}
