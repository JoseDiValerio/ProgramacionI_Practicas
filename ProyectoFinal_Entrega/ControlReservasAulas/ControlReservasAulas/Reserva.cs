namespace ControlReservasAulas;
public class Reserva
{
    public int Id { get; set; }
    public int AulaId { get; set; }
    public int ProfesorId { get; set; }
    public DateTime Fecha {  get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin {  get; set; }
    public Aula? Aula { get; set; }
    public Profesor? Profesor { get; set; }
}