namespace RedSocial.Models
{
    public class SolicitudModel
    {

        public int Id { get; set; }
        public int RemitenteId { get; set; }
        public int DestinatarioId { get; set; }
        public string DestinatarioNombre { get; set; }
        public string EstadoDescripcion { get; set; }
        public short EstadoId { get; set; }
    }

}
