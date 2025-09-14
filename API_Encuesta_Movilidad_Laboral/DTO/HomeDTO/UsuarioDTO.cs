using System.ComponentModel.DataAnnotations;

namespace API_Encuesta_Movilidad_Laboral.DTO.HomeDTO
{
    public class UsuarioDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
