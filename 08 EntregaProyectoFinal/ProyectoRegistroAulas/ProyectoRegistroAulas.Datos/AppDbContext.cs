using ProyectoRegistroAulas.Datos.Modelos;
using Microsoft.EntityFrameworkCore;
using ProyectoRegistroAulas.Datos.Modelos;

namespace ProyectoRegistroAulas.Datos;

public class AppDbContext : DbContext
{
    public DbSet<Aula> Aulas { get; set; } = null!;
    public DbSet<Profesor> Profesores { get; set; } = null!;
    public DbSet<Reserva> Reservas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ControlRegistroAulas;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
