namespace Reserva_Aulas
{
    public class Aula {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        // Constructor
        public Aula(string codigo, string nombre, int capacidad) {
            
            Codigo = codigo;
            Nombre = nombre;
            Capacidad = capacidad;
        }

    }
}