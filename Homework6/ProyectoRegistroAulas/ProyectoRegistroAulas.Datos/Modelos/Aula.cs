namespace ProyectoRegistroAulas.Datos.Modelos;

public class Aula
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Capacidad { get; set; }
}
