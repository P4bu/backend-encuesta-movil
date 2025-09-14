using System.ComponentModel.DataAnnotations;

namespace API_Encuesta_Movilidad_Laboral.DTO.AccountDTO
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }
    }
}
