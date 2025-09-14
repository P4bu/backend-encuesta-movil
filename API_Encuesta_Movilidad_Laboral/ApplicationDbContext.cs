using API_Encuesta_Movilidad_Laboral.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_Encuesta_Movilidad_Laboral
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<TipoTransporte> TiposTransportes { get; set; }
        public DbSet<ComunaRes> ComunasRes { get; set; }
        public DbSet<ComunaTra> ComunasTrab { get; set; }
        public DbSet<SitLaboral> SitLaborales { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
    }
}
