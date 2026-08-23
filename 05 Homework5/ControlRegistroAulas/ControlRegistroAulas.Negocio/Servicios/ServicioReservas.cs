using ControlRegistroAulas.Datos;
using ControlRegistroAulas.Datos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ControlRegistroAulas.Negocio.Servicios;

public class ServicioReservas
{
    public List<Reserva> Listar()
    {
        using (var db = new AppDbContext())
        {
            return db.Reservas
                .Include(r => r.Aula)
                .Include(r => r.Profesor)
                .ToList();
        }
    }

    public Reserva? BuscarPorId(int id)
    {
        using (var db = new AppDbContext())
        {
            return db.Reservas
                .Include(r => r.Aula)
                .Include(r => r.Profesor)
                .FirstOrDefault(r => r.Id == id);
        }
    }

    public Aula? BuscarAulaPorCodigo(int codigo)
    {
        using (var db = new AppDbContext())
        {
            return db.Aulas.FirstOrDefault(a => a.Codigo == codigo);
        }
    }

    public Profesor? BuscarProfesorPorCodigo(int codigo)
    {
        using (var db = new AppDbContext())
        {
            return db.Profesores.FirstOrDefault(p => p.Codigo == codigo);
        }
    }

    public bool AulaOcupada(int aulaId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinalizacion, int idReservaExcluir = 0)
    {
        using (var db = new AppDbContext())
        {
            return db.Reservas.Any(r =>
                r.Id != idReservaExcluir &&
                r.AulaId == aulaId &&
                r.Fecha.Date == fecha.Date &&
                ((horaInicio >= r.HoraInicio && horaInicio < r.HoraFinalizacion) ||
                 (horaFinalizacion > r.HoraInicio && horaFinalizacion <= r.HoraFinalizacion) ||
                 (horaInicio <= r.HoraInicio && horaFinalizacion >= r.HoraFinalizacion))
            );
        }
    }

    public void Agregar(Reserva reserva)
    {
        using (var db = new AppDbContext())
        {
            db.Reservas.Add(reserva);
            db.SaveChanges();
        }
    }

    public void Editar(int id, int aulaId, int profesorId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFinalizacion)
    {
        using (var db = new AppDbContext())
        {
            Reserva? reserva = db.Reservas.FirstOrDefault(r => r.Id == id);

            if (reserva != null)
            {
                reserva.AulaId = aulaId;
                reserva.ProfesorId = profesorId;
                reserva.Fecha = fecha;
                reserva.HoraInicio = horaInicio;
                reserva.HoraFinalizacion = horaFinalizacion;

                db.SaveChanges();
            }
        }
    }

    public void Eliminar(Reserva reserva)
    {
        using (var db = new AppDbContext())
        {
            db.Reservas.Remove(reserva);
            db.SaveChanges();
        }
    }

    public bool HayReservas()
    {
        using (var db = new AppDbContext())
        {
            return db.Reservas.Any();
        }
    }
}
