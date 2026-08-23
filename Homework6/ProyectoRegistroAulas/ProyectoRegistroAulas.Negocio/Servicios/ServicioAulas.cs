using ProyectoRegistroAulas.Datos;
using ProyectoRegistroAulas.Datos.Modelos;

namespace ProyectoRegistroAulas.Negocio.Servicios;

public class ServicioAulas
{
    public List<Aula> Listar()
    {
        using (var db = new AppDbContext())
        {
            return db.Aulas.ToList();
        }
    }

    public bool ExisteCodigo(int codigo)
    {
        using (var db = new AppDbContext())
        {
            return db.Aulas.Any(a => a.Codigo == codigo);
        }
    }

    public bool ExisteNombre(string nombre, int codigoExcluir = 0)
    {
        using (var db = new AppDbContext())
        {
            return db.Aulas.Any(a =>
                a.Nombre.ToLower() == nombre.ToLower() &&
                a.Codigo != codigoExcluir);
        }
    }

    public Aula? BuscarPorCodigo(int codigo)
    {
        using (var db = new AppDbContext())
        {
            return db.Aulas.FirstOrDefault(a => a.Codigo == codigo);
        }
    }

    public void Agregar(Aula aula)
    {
        using (var db = new AppDbContext())
        {
            db.Aulas.Add(aula);
            db.SaveChanges();
        }
    }

    public void Editar(int codigo, string nombre, int capacidad)
    {
        using (var db = new AppDbContext())
        {
            Aula? aula = db.Aulas.FirstOrDefault(a => a.Codigo == codigo);

            if (aula != null)
            {
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    aula.Nombre = nombre;
                }

                if (capacidad > 0)
                {
                    aula.Capacidad = capacidad;
                }

                db.SaveChanges();
            }
        }
    }

    public void Eliminar(Aula aula)
    {
        using (var db = new AppDbContext())
        {
            db.Aulas.Remove(aula);
            db.SaveChanges();
        }
    }

    public bool HayAulas()
    {
        using (var db = new AppDbContext())
        {
            return db.Aulas.Any();
        }
    }
}
