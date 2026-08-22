using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Aula> Aulas { get; set; } = null!;
    public DbSet<Profesor> Profesores { get; set; } = null!;
    public DbSet<Reserva> Reservas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-E9V3MBP\SQLEXPRESS;Database=GestionAulasApp;Trusted_Connection=True;
                                    TrustServerCertificate=True;");
    }
}
