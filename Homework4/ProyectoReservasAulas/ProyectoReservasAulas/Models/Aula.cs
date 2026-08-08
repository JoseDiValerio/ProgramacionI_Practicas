using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoReservasAulas.Models
{
    [Table("Aula")]
    public class Aula
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        // Relación con Reserva
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
