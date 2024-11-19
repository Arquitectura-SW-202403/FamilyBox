using Microsoft.EntityFrameworkCore;
namespace Persistencia.Data{
    using Microsoft.EntityFrameworkCore;
    using Entities;
    using DnsClient.Protocol;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;

    public class ApplicationDbContext : DbContext
{
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Instalacion> Instalaciones { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }
    public DbSet<Pago> Pagos { get; set; }
    public DbSet<ProgramaDep> ProgramasDep { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Sede> Sedes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
        try {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            databaseCreator.CreateTables();
        } catch (Exception e) {
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Evento
        modelBuilder.Entity<Evento>()
            .HasKey(e => e.EventoId);

        modelBuilder.Entity<Evento>()
            .Property(e => e.Nombre)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Evento>()
            .Property(e => e.Descripcion)
            .HasMaxLength(500);

        modelBuilder.Entity<Evento>()
            .Property(e => e.FechaInicio)
            .IsRequired();

        modelBuilder.Entity<Evento>()
            .Property(e => e.FechaFin)
            .IsRequired();

        modelBuilder.Entity<Evento>()
            .Property(e => e.capcidad)
            .IsRequired();

        modelBuilder.Entity<Evento>()
            .Property(e => e.TarifaAfiliado)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Evento>()
            .Property(e => e.TarifaNoAfiliado)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Evento>()
            .Property(e => e.Estado)
            .IsRequired();

        // Instalacion
        modelBuilder.Entity<Instalacion>()
            .HasKey(i => i.InstalacionId);

        modelBuilder.Entity<Instalacion>()
            .Property(i => i.Nombre)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Instalacion>()
            .Property(i => i.Tipo)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Instalacion>()
            .Property(i => i.Capacidad)
            .IsRequired();

        modelBuilder.Entity<Instalacion>()
            .Property(i => i.Descripcion)
            .HasMaxLength(500);

        modelBuilder.Entity<Instalacion>()
            .Property(i => i.Estado)
            .IsRequired();

        modelBuilder.Entity<Instalacion>()
            .Property(i => i.Disponibilidad)
            .IsRequired();

        // Notificacion
        modelBuilder.Entity<Notificacion>()
            .HasKey(n => n.NotificacionId);

        modelBuilder.Entity<Notificacion>()
            .Property(n => n.Titulo)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Notificacion>()
            .Property(n => n.Leido)
            .IsRequired();

        modelBuilder.Entity<Notificacion>()
            .Property(n => n.FechaEnvio)
            .HasMaxLength(100);

        // Pago
        modelBuilder.Entity<Pago>()
            .HasKey(p => p.PagoId);

        modelBuilder.Entity<Pago>()
            .Property(p => p.Monto)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Pago>()
            .Property(p => p.FechaPago)
            .HasMaxLength(100);

        modelBuilder.Entity<Pago>()
            .Property(p => p.MetodoPago)
            .IsRequired();

        modelBuilder.Entity<Pago>()
            .Property(p => p.EstadoPago)
            .IsRequired();

        // ProgramaDep
        modelBuilder.Entity<ProgramaDep>()
            .HasKey(p => p.ProgramaId);

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.Nombre)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.Descripcion)
            .HasMaxLength(500);

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.TipoActividad)
            .HasMaxLength(100);

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.Cupo)
            .IsRequired();

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.FechaInicio)
            .HasMaxLength(100);

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.FechaFin)
            .HasMaxLength(100);

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.TarifaAfiliado)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.TarifaNoAfiliado)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ProgramaDep>()
            .Property(p => p.Estado)
            .IsRequired();

        // Reserva
        modelBuilder.Entity<Reserva>()
            .HasKey(r => r.ReservaId);

        modelBuilder.Entity<Reserva>()
            .Property(r => r.FechaReserva)
            .HasMaxLength(100);

        modelBuilder.Entity<Reserva>()
            .Property(r => r.HoraInicio)
            .HasMaxLength(50);

        modelBuilder.Entity<Reserva>()
            .Property(r => r.HoraFin)
            .HasMaxLength(50);

        modelBuilder.Entity<Reserva>()
            .Property(r => r.Tarifa)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Reserva>()
            .Property(r => r.Estado)
            .IsRequired();

        modelBuilder.Entity<Reserva>()
            .Property(r => r.Creacion)
            .HasMaxLength(100);

        // Sede
        modelBuilder.Entity<Sede>()
            .HasKey(s => s.SedeId);

        modelBuilder.Entity<Sede>()
            .Property(s => s.Nombre)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Sede>()
            .Property(s => s.Direccion)
            .HasMaxLength(500);

        modelBuilder.Entity<Sede>()
            .Property(s => s.Telefono)
            .HasMaxLength(50);

        modelBuilder.Entity<Sede>()
            .Property(s => s.Email)
            .HasMaxLength(255);

        modelBuilder.Entity<Sede>()
            .Property(s => s.Horario)
            .HasMaxLength(100);

        modelBuilder.Entity<Sede>()
            .Property(s => s.Estado)
            .IsRequired();

        modelBuilder.Entity<Sede>()
            .Property(s => s.FechaCreacion)
            .HasMaxLength(100);

        // Usuario
        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.UsuarioId);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.TipoDocumento)
            .HasMaxLength(50);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Nombre)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Apellido)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Telefono)
            .HasMaxLength(50);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Password)
            .HasMaxLength(255);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.TipoUsuario)
            .IsRequired();

        modelBuilder.Entity<Usuario>()
            .Property(u => u.FechaRegistro)
            .HasMaxLength(100);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Estado)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}

}