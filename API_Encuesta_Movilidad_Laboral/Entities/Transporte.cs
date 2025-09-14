using System.ComponentModel.DataAnnotations;

namespace API_Encuesta_Movilidad_Laboral.Entities
{
    public class Transporte
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Encuesta> encuestas { get; set; }
        [Required]
        public int tipoTransporteId { get; set; }
        [Required]
        public TipoTransporte tipoTransporte { get; set; }
    }
}
