using ControlRegistroAulas.Datos;

namespace ControlRegistroAulas.Negocio.Servicios;

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
