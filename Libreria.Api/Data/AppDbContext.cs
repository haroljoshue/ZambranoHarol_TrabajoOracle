using Microsoft.EntityFrameworkCore;
using Libreria.Modelos;

namespace Libreria.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoPonente> EventoPonentes { get; set; }
        public DbSet<HistorialEvento> HistorialEventos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Ponente> Ponentes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }

    }
}
