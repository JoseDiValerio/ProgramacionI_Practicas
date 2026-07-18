namespace Reserva_Aulas
{
    public class Reserva {
        public Aula Aula { get; set; }
        public Profesor Profesor { get; set; }
        public string Horario { get; set; }

        public Reserva(Aula aula, Profesor profesor, string horario) {
            
            Aula = aula;
            Profesor = profesor;
            Horario = horario;
        }
    }
}
