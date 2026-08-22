public class Reserva
{
    public int Id { get; set; }
    
    public int AulaId { get; set; }
    public Aula Aula { get; set; } = null!;
    
    public int ProfesorId { get; set; }
    public Profesor Profesor { get; set; } = null!;

    public DateTime Fecha { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFinalizacion { get; set; }
}
