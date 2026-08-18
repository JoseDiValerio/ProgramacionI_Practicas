using ControlReservasAulas;

using (AppDbContext db = new AppDbContext())
{
    if (db.Database.CanConnect())
    {
        Console.WriteLine("Conexión correcta con SQL Server.");
    }
    else
    {
        Console.WriteLine("No se pudo conectar con SQL Server.");
    }
}