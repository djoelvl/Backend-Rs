namespace RedSocial.Models
{
    public class PublicacionModel
    {

        public int Id { get; set; }
        public string Contenido { get; set; }
        public int UserId { get; set; }
        public int CantidadLikes { get; set; }
        public bool Liked { get; set; }

    }
}
