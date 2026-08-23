using ProyectoRegistroAulas.Datos;
using ProyectoRegistroAulas.Datos.Modelos;

namespace ProyectoRegistroAulas.Negocio.Servicios;

public class ServicioProfesores
{
    public List<Profesor> Listar()
    {
        using (var db = new AppDbContext())
        {
            return db.Profesores.ToList();
        }
    }

    public bool ExisteCodigo(int codigo)
    {
        using (var db = new AppDbContext())
        {
            return db.Profesores.Any(p => p.Codigo == codigo);
        }
    }

    public Profesor? BuscarPorCodigo(int codigo)
    {
        using (var db = new AppDbContext())
        {
            return db.Profesores.FirstOrDefault(p => p.Codigo == codigo);
        }
    }

    public void Agregar(Profesor profesor)
    {
        using (var db = new AppDbContext())
        {
            db.Profesores.Add(profesor);
            db.SaveChanges();
        }
    }

    public void Editar(int codigo, string nombre, string materia)
    {
        using (var db = new AppDbContext())
        {
            Profesor? profesor = db.Profesores.FirstOrDefault(p => p.Codigo == codigo);

            if (profesor != null)
            {
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    profesor.Nombre = nombre;
                }

                if (!string.IsNullOrWhiteSpace(materia))
                {
                    profesor.Materia = materia;
                }

                db.SaveChanges();
            }
        }
    }

    public void Eliminar(Profesor profesor)
    {
        using (var db = new AppDbContext())
        {
            db.Profesores.Remove(profesor);
            db.SaveChanges();
        }
    }

    public bool HayProfesores()
    {
        using (var db = new AppDbContext())
        {
            return db.Profesores.Any();
        }
    }
}
