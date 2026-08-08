using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoReservasAulas.Models
{
    //internal class Class2
    //{
    //}

    public class Profesor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        // Relación con Reserva
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
