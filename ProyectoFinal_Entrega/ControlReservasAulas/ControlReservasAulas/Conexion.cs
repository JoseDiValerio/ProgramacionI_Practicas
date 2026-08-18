using Microsoft.EntityFrameworkCore;

namespace ControlReservasAulas;

public class Conexion : DbContext
{
    public DbSet<Aula> Aulas { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Reserva> Reservas {  get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-E9V3MBP\\SQLEXPRESS;Database=ControlReservasAulas;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}