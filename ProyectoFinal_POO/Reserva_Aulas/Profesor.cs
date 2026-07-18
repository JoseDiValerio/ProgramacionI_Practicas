namespace Reserva_Aulas
{
    public class Profesor {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Materia { get; set; }

        public Profesor(string codigo, string nombre, string materia) {
            
            Codigo = codigo;
            Nombre = nombre;
            Materia = materia;
        }
    }
}
