using System.ComponentModel.DataAnnotations;

namespace API_Encuesta_Movilidad_Laboral.DTO.HomeDTO
{
    public class EncuestaDTO
    {
        [Required]
        public int idTransporte { get; set; }
        [Required]
        public bool esCompartido { get; set; }
        [Required]
        public string idUsuario { get; set; }
        public int? km_recorrido { get; set; }
        public int? minutos_recorrido { get; set; }
        public int? dias_trabajo { get; set; }
    }
}
