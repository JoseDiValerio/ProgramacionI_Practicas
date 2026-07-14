// PROYECTO RESERVA DE AULAS
// Jose Daniel Di Valerio
// Matricula 2025-1887
// Hola mundo

List<Aula> aulas = new List<Aula>();
List<Profesor> profesores = new List<Profesor>();
List<Reserva> reserva = new List<Reserva>();

int opcion = 0;
int contadorReserva = 1;
bool salir = false;

while (!salir) {
    try {
        
        Console.Clear();

        Console.WriteLine("===== JOSE DI VALERIO 2025-1887 =====");
        Console.WriteLine("\n===== SISTEMA DE RESERVAS DE AULAS =====");
        Console.WriteLine("\n1. Registrar aulas");
        Console.WriteLine("2. Ver aulas registradas");
        Console.WriteLine("3. Registrar profesores");
        Console.WriteLine("4. Ver profesores registrados");
        Console.WriteLine("5. Crear reserva");
        Console.WriteLine("6. Listar reservas");
        Console.WriteLine("7. Modificar horario de reserva");
        Console.WriteLine("8. Salir");
        Console.Write("\nSeleccione una opción: ");

        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6) {
            Console.Write("\nOpción inválida! Seleccione una opción del 1 al 6: ");
        }

        switch (opcion) {

            case 1:
                Aula aula = new Aula();

                Console.Write("\nID del aula: ");
                aula.Id = int.Parse(Console.ReadLine()??"");

                Console.Write("Nombre del aula: ");
                aula.Nombre = Console.ReadLine()??"";

                Console.Write("Capacidad: ");
                aula.Capacidad = Convert.ToInt32(Console.ReadLine());

                

                Console.WriteLine("Aula registrada correctamente.");
                break;

            case 2:
                Profesor profesor = new Profesor();

                Console.Write("\nID del profesor: ");
                profesor.Id = int.Parse(Console.ReadLine()??"");

                Console.Write("Nombre del profesor: ");
                profesor.Nombre = Console.ReadLine()??"";


                profesores.Add(profesor);

                Console.WriteLine("Profesor registrado correctamente.");
                break;

            case 3:
                if (aulas.Count == 0 || profesores.Count == 0) {
                    Console.WriteLine("\nDebe registrar aulas y profesores primero.");
                    break;
                }

                Console.WriteLine("\n--- CREAR RESERVA ---");

                Console.Write("ID del aula: ");
                string idAula = Console.ReadLine() ?? "";

                int idAula2;

                if (int.TryParse(idAula, out idAula2)) {
                    Console.WriteLine("ID ingresado: {idAula2}");
                } else {
                    Console.WriteLine("Debe ingresar un numero");
                }

                Aula aulaEncontrada = null;

                foreach (Aula a in aulas) {
                    if (a.Id == idAula2) {
                        aulaEncontrada = a;
                    }
                }

                if (aulaEncontrada == null) {
                    Console.WriteLine("Aula no encontrada.");
                    break;
                }

                Console.Write("ID del profesor: ");
                int idProfesor = int.Parse(Console.ReadLine()??"");

                Profesor profesorEncontrado = null;

                foreach (Profesor p in profesores) {
                    if (p.Id == idProfesor) {
                        profesorEncontrado = p;
                    }
                }

                if (profesorEncontrado == null) {
                    Console.WriteLine("Profesor no encontrado.");
                    break;
                }

                Console.Write("Día de la reserva: ");
                string dia = Console.ReadLine() ?? "";

                Console.Write("Hora inicio, ejemplo 8: ");
                int horaInicio = int.Parse(Console.ReadLine()??"");

                Console.Write("Hora fin, ejemplo 10: ");
                int horaFin = int.Parse(Console.ReadLine()??"");

                if (horaInicio >= horaFin) {
                    Console.WriteLine("La hora de inicio debe ser menor que la hora final.");
                    break;
                }

                bool disponible = true;

                foreach (Reserva r in reserva) {
                    bool mismoDia = r.Dia.ToLower() == dia.ToLower();
                    bool mismaAula = r.Aula.Id == idAula2;
                    bool mismoProfesor = r.Profesor.Id == idProfesor;

                    bool choqueHorario = horaInicio < r.HoraFin && horaFin > r.HoraInicio;

                    if (mismoDia && choqueHorario && (mismaAula || mismoProfesor)) {
                        disponible = false;
                    }
                }

                if (!disponible) {
                    Console.WriteLine("No disponible. El aula o el profesor ya tiene una reserva en ese horario.");
                } else {
                    Reserva reserva2 = new Reserva();

                    reserva2.Id = contadorReserva;
                    reserva2.Aula = aulaEncontrada;
                    reserva2.Profesor = profesorEncontrado;
                    reserva2.Dia = dia;
                    reserva2.HoraInicio = horaInicio;
                    reserva2.HoraFin = horaFin;

                    reserva.Add(reserva2);
                    contadorReserva++;

                    Console.WriteLine("Reserva creada correctamente.");
                }
                break;

            case 4:
                Console.WriteLine("\n--- LISTADO DE RESERVAS ---");

                if (reserva.Count == 0) {
                    Console.WriteLine("No hay reservas registradas.");
                } else {
                    foreach (Reserva r in reserva) {
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("ID Reserva: " + r.Id);
                        Console.WriteLine("Aula: " + r.Aula.Nombre);
                        Console.WriteLine("Profesor: " + r.Profesor.Nombre);
                        Console.WriteLine("Día: " + r.Dia);
                        Console.WriteLine("Horario: " + r.HoraInicio + ":00 - " + r.HoraFin + ":00");
                    }
                }
                break;

            case 5:
                Console.WriteLine("\n--- MODIFICAR HORARIO ---");

                Console.Write("\nIngrese ID de la reserva: ");
                int idReserva = int.Parse(Console.ReadLine()??"");

                Reserva reservaModificar = null;

                foreach (Reserva r in reserva) {
                    if (r.Id == idReserva) {
                        reservaModificar = r;
                    }
                }

                if (reservaModificar == null) {
                    Console.WriteLine("\nReserva no encontrada.");
                    break;
                }

                Console.Write("\nNuevo día: ");
                string nuevoDia = Console.ReadLine()??"";

                Console.Write("\nNueva hora inicio: ");
                int nuevaHoraInicio = int.Parse(Console.ReadLine()??"");

                Console.Write("vNueva hora fin: ");
                int nuevaHoraFin = int.Parse(Console.ReadLine()??"");

                if (nuevaHoraInicio >= nuevaHoraFin) {
                    Console.WriteLine("\nLa hora de inicio debe ser menor que la hora final.");
                    break;
                }

                bool nuevoDisponible = true;

                foreach (Reserva r in reserva) {
                    if (r.Id != reservaModificar.Id) {
                        bool mismoDia = r.Dia.ToLower() == nuevoDia.ToLower();
                        bool mismaAula = r.Aula.Id == reservaModificar.Aula.Id;
                        bool mismoProfesor = r.Profesor.Id == reservaModificar.Profesor.Id;

                        bool choqueHorario = nuevaHoraInicio < r.HoraFin && nuevaHoraFin > r.HoraInicio;

                        if (mismoDia && choqueHorario && (mismaAula || mismoProfesor)) {
                            nuevoDisponible = false;
                        }
                    }
                }

                if (!nuevoDisponible) {
                    Console.WriteLine("\nNo se puede modificar. Ya existe una reserva en ese horario.");
                } else {
                    reservaModificar.Dia = nuevoDia;
                    reservaModificar.HoraInicio = nuevaHoraInicio;
                    reservaModificar.HoraFin = nuevaHoraFin;

                    Console.WriteLine("\nHorario modificado correctamente.");
                }
                break;

            case 6:
                salir = true;
                Console.WriteLine("\nSaliendo del sistema.");
                break;

            default:
                Console.WriteLine("\nOpción inválida.");
                break;
        }
    }
    
    catch {
        Console.WriteLine("\nERROR: Entrada inválida! Intente nuevamente.");
    }

    if (!salir) {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }
}

class Aula
{
    public int Id;
    public string Nombre="";
    public int Capacidad;
}

class Profesor
{
    public int Id;
    public string Nombre="";
}

class Reserva
{
    public int Id;
    public Aula Aula;
    public Profesor Profesor;
    public string Dia="";
    public int HoraInicio;
    public int HoraFin;
}