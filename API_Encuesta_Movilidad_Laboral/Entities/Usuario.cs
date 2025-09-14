using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Encuesta_Movilidad_Laboral.Entities
{
    [Index(nameof(rut))]
    [Index(nameof(Email))]
    public class Usuario : IdentityUser
    {
        [Required]
        public string rut { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellidos { get; set; }
        public bool? marca_recup { get; set; }
        [Required]
        public DateTime fecha_nac { get; set; }
        public bool? esCompartido { get; set; }
        public int? modalidadId { get; set; }
        public Modalidad? modalidad { get; set; }
        [Required]
        public int estadoId { get; set; }
        [Required]
        public Estado estado { get; set; }
        public int? comunaTraId { get; set; }
        public ComunaTra? comunaTra { get; set; }
        [Required]
        public int comunaResId { get; set; }
        [Required]
        public ComunaRes comunaRes { get; set; }
        [Required]
        public int sitLaboralId { get; set; }
        [Required]
        public SitLaboral sitLaboral { get; set; }
        public int? encuestaId { get; set; }
        public Encuesta? encuesta { get; set; }

    }
}
