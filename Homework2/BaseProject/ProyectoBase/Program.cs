// PROYECTO RESERVA DE AULAS
// Jose Daniel Di Valerio 2025-1887

class Aula
{
    public int Id;
    public string Nombre;
    public int Capacidad;
}

class Profesor
{
    public int Id;
    public string Nombre;
}

class Reserva
{
    public int Id;
    public Aula Aula;
    public Profesor Profesor;
    public string Dia;
    public int HoraInicio;
    public int HoraFin;
}

List<Aula> aulas = new List<Aula>();
List<Profesor> profesores = new List<Profesor>();
List<Reserva> reservas = new List<Reserva>();

int opcion = 0;
int contadorReserva = 1;
bool salir = false;

while (!salir) {
    try {
        
        Console.Clear();

        Console.WriteLine("===== JOSE DI VALERIO 2025-1887 =====");
        Console.WriteLine("\n===== SISTEMA DE RESERVAS DE AULAS =====");
        Console.WriteLine("\n1. Registrar aula");
        Console.WriteLine("2. Registrar profesor");
        Console.WriteLine("3. Crear reserva");
        Console.WriteLine("4. Listar reservas");
        Console.WriteLine("5. Modificar horario de reserva");
        Console.WriteLine("6. Salir");
        Console.Write("\nSeleccione una opción: ");

        opcion = int.Parse(Console.ReadLine());

        switch (opcion) {

            case 1:
                Aula aula = new Aula();

                Console.Write("\nID del aula: ");
                aula.Id = int.Parse(Console.ReadLine());

                Console.Write("Nombre del aula: ");
                aula.Nombre = Console.ReadLine();

                Console.Write("Capacidad: ");
                aula.Capacidad = int.Parse(Console.ReadLine());

                aulas.Add(aula);

                Console.WriteLine("Aula registrada correctamente.");
                break;

            case 2:
                Profesor profesor = new Profesor();

                Console.Write("\nID del profesor: ");
                profesor.Id = int.Parse(Console.ReadLine());

                Console.Write("Nombre del profesor: ");
                profesor.Nombre = Console.ReadLine();

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
                int idAula = int.Parse(Console.ReadLine());

                Aula aulaEncontrada = null;

                foreach (Aula a in aulas) {
                    if (a.Id == idAula) {
                        aulaEncontrada = a;
                    }
                }

                if (aulaEncontrada == null) {
                    Console.WriteLine("Aula no encontrada.");
                    break;
                }

                Console.Write("ID del profesor: ");
                int idProfesor = int.Parse(Console.ReadLine());

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
                string dia = Console.ReadLine();

                Console.Write("Hora inicio, ejemplo 8: ");
                int horaInicio = int.Parse(Console.ReadLine());

                Console.Write("Hora fin, ejemplo 10: ");
                int horaFin = int.Parse(Console.ReadLine());

                if (horaInicio >= horaFin) {
                    Console.WriteLine("La hora de inicio debe ser menor que la hora final.");
                    break;
                }

                bool disponible = true;

                foreach (Reserva r in reservas) {
                    bool mismoDia = r.Dia.ToLower() == dia.ToLower();
                    bool mismaAula = r.Aula.Id == idAula;
                    bool mismoProfesor = r.Profesor.Id == idProfesor;

                    bool choqueHorario = horaInicio < r.HoraFin && horaFin > r.HoraInicio;

                    if (mismoDia && choqueHorario && (mismaAula || mismoProfesor)) {
                        disponible = false;
                    }
                }

                if (!disponible) {
                    Console.WriteLine("No disponible. El aula o el profesor ya tiene una reserva en ese horario.");
                } else {
                    Reserva reserva = new Reserva();

                    reserva.Id = contadorReserva;
                    reserva.Aula = aulaEncontrada;
                    reserva.Profesor = profesorEncontrado;
                    reserva.Dia = dia;
                    reserva.HoraInicio = horaInicio;
                    reserva.HoraFin = horaFin;

                    reservas.Add(reserva);
                    contadorReserva++;

                    Console.WriteLine("Reserva creada correctamente.");
                }
                break;

            case 4:
                Console.WriteLine("\n--- LISTADO DE RESERVAS ---");

                if (reservas.Count == 0) {
                    Console.WriteLine("No hay reservas registradas.");
                } else {
                    foreach (Reserva r in reservas) {
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

                Console.Write("Ingrese ID de la reserva: ");
                int idReserva = int.Parse(Console.ReadLine());

                Reserva reservaModificar = null;

                foreach (Reserva r in reservas) {
                    if (r.Id == idReserva) {
                        reservaModificar = r;
                    }
                }

                if (reservaModificar == null) {
                    Console.WriteLine("Reserva no encontrada.");
                    break;
                }

                Console.Write("Nuevo día: ");
                string nuevoDia = Console.ReadLine();

                Console.Write("Nueva hora inicio: ");
                int nuevaHoraInicio = int.Parse(Console.ReadLine());

                Console.Write("Nueva hora fin: ");
                int nuevaHoraFin = int.Parse(Console.ReadLine());

                if (nuevaHoraInicio >= nuevaHoraFin) {
                    Console.WriteLine("La hora de inicio debe ser menor que la hora final.");
                    break;
                }

                bool nuevoDisponible = true;

                foreach (Reserva r in reservas) {
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
                    Console.WriteLine("No se puede modificar. Ya existe una reserva en ese horario.");
                } else {
                    reservaModificar.Dia = nuevoDia;
                    reservaModificar.HoraInicio = nuevaHoraInicio;
                    reservaModificar.HoraFin = nuevaHoraFin;

                    Console.WriteLine("Horario modificado correctamente.");
                }
                break;

            case 6:
                salir = true;
                Console.WriteLine("Saliendo del sistema...");
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
    
    catch {
        Console.WriteLine("ERROR: Entrada inválida. Intente nuevamente.");
    }

    if (!salir) {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }
}