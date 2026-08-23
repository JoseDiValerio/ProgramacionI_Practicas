namespace ProyectoRegistroAulas.Datos.Modelos;

public class Profesor
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Materia { get; set; } = string.Empty;
}
