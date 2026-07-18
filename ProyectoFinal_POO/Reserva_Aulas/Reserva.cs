namespace Reserva_Aulas
{
    public class Reserva {
        public Aula Aula { get; set; }
        public Profesor Profesor { get; set; }
        public string Materia { get; set; }
        public string Horario { get; set; }

        public Reserva(Aula aula, Profesor profesor, string materia, string horario) {
            
            Aula = aula;
            Profesor = profesor;
            Materia = materia;
            Horario = horario;
        }
    }
}
