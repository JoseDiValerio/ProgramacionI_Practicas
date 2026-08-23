using ProyectoRegistroAulas.Datos;

namespace ProyectoRegistroAulas.Negocio.Servicios;

public class ServicioBaseDatos
{
    public void CrearBaseDeDatos()
    {
        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();
        }
    }
}
