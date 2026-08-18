using Microsoft.EntityFrameworkCore;

namespace ControlReservasAulas;

public class AppDbContext : DbContext
{
    public DbSet<Aula> Aulas { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Reserva> Reservas {  get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=ControlReservasAulas;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}