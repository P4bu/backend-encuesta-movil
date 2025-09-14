using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_Encuesta_Movilidad_Laboral.Entities
{
    [Index(nameof(idUsuario))]
    public class Encuesta
    {
        public int id { get; set; }
        public int? km_recorrido { get; set; }
        public int? minutos_recorrido { get; set; }
        public int? dias_trabajo { get; set; }
        [Required]
        public string idUsuario { get; set; }
        [Required]
        public Usuario usuario { get; set; }
        [Required]
        public int transporteId { get; set; }
        [Required]
        public Transporte transporte { get; set; }
    }
}
