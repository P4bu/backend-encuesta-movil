using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API_Encuesta_Movilidad_Laboral.DTO.AccountDTO
{
    public class UserRegister
    {
        [Required]
        public string Run { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }
        [Required]
        public DateTime FecNac { get; set; }
        public int? IdModalidad { get; set; }
        [Required]
        public int IdSitLaboral { get; set; }
        [Required]
        public int IdComunaRes { get; set; }
        public int? IdComunaTra { get; set; }
        [Required]
        public int IdEstado { get; set; }
    }
}
