using System.ComponentModel.DataAnnotations;

namespace API_Encuesta_Movilidad_Laboral.Entities
{
    public class Modalidad
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public List<Usuario>? usuarios { get; set; }
    }
}
