using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoReservasAulas.Models
{
    //internal class Reserva
    //{
    //}

    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public int AulaId { get; set; }

        public int ProfesorId { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        // Navegación
        public Aula? Aula { get; set; }

        public Profesor? Profesor { get; set; }
    }
}
