using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoReservasAulas.Models
{
    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Materia { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        // Relación con Reserva
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
