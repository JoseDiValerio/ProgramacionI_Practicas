using Microsoft.VisualBasic.FileIO;

namespace Classroom_Booking {
    public class ClassroomBooking {

        private List<Classroom> classroom = new List<Classroom>();
        private List<Teacher> teachers = new List<Teacher>();
        private List<Booking> booking = new List<Booking>();

        // Validation methods
        private string ReadName(string message) {
            
            string fact;

            do {
                Console.Write(message);

                fact = Console.ReadLine() ?? "";

                if (fact == ""){
                    Console.WriteLine("The data field cannot be left empty.");
                }

            } while (fact == "");

            return fact;
        }

        private int ReadNumber(string message) {
            
            int numero;

            Console.Write(mensaje);

            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0) {
                Console.Write("\nIngrese numero entero mayor que 0: ");
            }

            return numero;
        }

        private bool AddClassroomCode(string code) {

            foreach (Classroom classroom in classroom) {
                
                if (classroom.Code == code) {
                    return true;
                }
            }

            return false;
        }

        private bool EditClassroomCode(string code, Classroom currentClassroom) {

            foreach (Classroom classroom in classroom) {
                
                if (classroom != currentClassroom && classroom.Code == code) {
                    return true;
                }
            }

            return false;
        }

        private bool AddTeacherCode(string code) {

            foreach (Profesor profesores in profesores) {

                if (profesores.Codigo == codigo) {
                    return true;
                }
            }

            return false;
        }

        private bool EditTeacherCode(string code, Teacher currentProfessor) {

            foreach (Profesor profesores in profesores) {

                if (profesores != profesorActual && profesores.Codigo == codigo) {
                    return true;
                }
            }

            return false;
        }

        // Main functions
        public void RegisterClassroom() {
            
            Console.Clear();

            string code, name;
            int capacity;

            Console.WriteLine("===== REGISTER CLASSROOM =====");

            do {
                Console.Write("\nCode: ");
                code = Console.ReadLine() ?? "";

                if (AddClassroomCode(code)) {
                    Console.WriteLine("\nCodigo ya existe.");
                }

            } while (AddClassroomCode(code));

            name = ReadName("\nName: ");

            capacity = ReadNumber("\nCapacity (students): ");

            Classroom newClassroom = new Classroom(code, name, capacity);

            classroom.Add(newClassroom);

            Console.WriteLine("\nClassroom successfully registered.");
            Console.ReadKey();
        }

        public void EditClassroom() {

            Console.Clear();

            Console.WriteLine("===== EDIT CLASSROOM =====");

            if (classroom.Count == 0) {
                Console.WriteLine("\nNo classrooms registered.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < classroom.Count; i++) {

                Console.WriteLine("\nClassroom (" + (i + 1) + "). " + "Code: " + classroom[i].Code + " - " + classroom[i].Name + " - "
                                    + "Capacity: " + classroom[i].Capacity + " students.");
            }

            int option;

            Console.Write("\nSelect the classroom number: ");

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > classroom.Count) {
                Console.Write("\nInvalid option. Please try again: ");
            }

            Classroom classrooms = classroom[option - 1];

            string code, name;
            int capacity;

            do {
                Console.Write("\nNew code: ");
                code = Console.ReadLine() ?? "";

                if (EditClassroomCode(code, classrooms)) {
                    Console.WriteLine("Code already exists.");
                }

            } while (EditClassroomCode(code, classrooms));

            name = ReadName("Name: ");

            capacity = ReadNumber("Capacity (students): ");

            classrooms.Code = code;
            classrooms.Name = name;
            classrooms.Capacity = capacity;

            Console.WriteLine("\nClassroom successfully edited.");
            Console.ReadKey();
        }

        public void ListClassrooms() {
            
            Console.Clear();

            Console.WriteLine("===== LISTADO DE AULAS =====");

            if (aulas.Count == 0) {
                Console.WriteLine("\nNo hay aulas registradas.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < aulas.Count; i++) {

                Console.WriteLine("\nAula #" + (i + 1));
                Console.WriteLine("\nCódigo: " + aulas[i].Codigo);
                Console.WriteLine("Nombre: " + aulas[i].Nombre);
                Console.WriteLine("Capacidad (estudiantes): " + aulas[i].Capacidad);
            }

            Console.ReadKey();
        }

        public void RegisterProfessor()
        {
            Console.Clear();

            Console.WriteLine("===== REGISTRAR PROFESOR =====");

            string codigo, nombre;
            string materia;

            do {
                Console.Write("\nCodigo: ");
                codigo = Console.ReadLine() ?? "";

                if (ExisteCodigoProfesorAgregar(codigo)) {
                    Console.WriteLine("\nCodigo ya existe.");
                }

            } while (ExisteCodigoProfesorAgregar(codigo));

            nombre = LeerNombre("\nNombre: ");

            do {
                Console.Write("\nMateria: ");
                materia = Console.ReadLine() ?? "";

                if (materia == "") {
                    Console.WriteLine("Debe ingresar una materia.");
                }

            } while (materia == "");

            Profesor nuevoProfesor = new Profesor(codigo, nombre, materia);

            profesores.Add(nuevoProfesor);

            Console.WriteLine("\nProfesor registrado correctamente.");
            Console.ReadKey();
        }

        public void EditProfessor() {
            
            Console.Clear();

            Console.WriteLine("===== EDITAR PROFESOR =====");

            if (profesores.Count == 0) {
                Console.WriteLine("\nNo hay profesores registrados.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < profesores.Count; i++) {
                Console.WriteLine("\nProfesor: (" + (i + 1) + "). " + "Codigo: " + profesores[i].Codigo + " - " + "Nombre: " + profesores[i].Nombre + 
                                  " - " + "Materia: " + profesores[i].Materia);
            }

            int opcion;

            Console.Write("\nSeleccione el profesor: ");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > profesores.Count) {
                Console.Write("\nOpcion invalida. Intente nuevamente: ");
            }

            Profesor profesor = profesores[opcion - 1];

            string codigo, nombre;
            string materia;

            do {
                Console.Write("\nNuevo código: ");
                codigo = Console.ReadLine() ?? "";

                if (ExisteCodigoProfesorEditar(codigo, profesor)) {
                    Console.WriteLine("\nCodigo ya existe.");
                }

            } while (ExisteCodigoProfesorEditar(codigo, profesor));

            nombre = LeerNombre("\nNombre: ");

            do {
                Console.Write("\nNueva materia: ");
                materia = Console.ReadLine() ?? "";

                if (materia == "") {
                    Console.WriteLine("Debe ingresar una materia.");
                }

            } while (materia == "");

            profesor.Codigo = codigo;
            profesor.Nombre = nombre;
            profesor.Materia = materia;

            Console.WriteLine("\nProfesor actualizado correctamente.");
            Console.ReadKey();
        }

        public void ListProfessors() {
            
            Console.Clear();

            Console.WriteLine("===== LISTADO DE PROFESORES =====");

            if (profesores.Count == 0) {
                Console.WriteLine("\nNo hay profesores registrados.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < profesores.Count; i++) {
                
                Console.WriteLine("\nProfesor #" + (i + 1));
                Console.WriteLine("\nCódigo: " + profesores[i].Codigo);
                Console.WriteLine("Nombre: " + profesores[i].Nombre);
                Console.WriteLine("Materia: " + profesores[i].Materia);
            }

            Console.ReadKey();
        }

        public void RegisterReservation() {
            
            Console.Clear();

            Console.WriteLine("===== REGISTRAR RESERVA =====");

            if (aulas.Count == 0 && profesores.Count == 0) {
                Console.WriteLine("\nDebe registrar al menos un aula y un profesor.");
                Console.ReadKey();
                return;

            } else if (aulas.Count == 0) {
                Console.WriteLine("\nDebe registrar al menos un aula.");
                Console.ReadKey();
                return;

            } else if (profesores.Count == 0) {
                Console.WriteLine("\nDebe registrar al menos un profesor.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAULAS DISPONIBLES\n");

            for (int i = 0; i < aulas.Count; i++) {
                Console.WriteLine((i + 1) + ". " + aulas[i].Nombre + " (" + aulas[i].Codigo + ")");
            }

            int opcionAula;

            Console.Write("\nSeleccione un aula: ");

            while (!int.TryParse(Console.ReadLine(), out opcionAula) || opcionAula < 1 || opcionAula > aulas.Count) {
                Console.Write("\nSeleccione aula correcta: ");
            }

            Console.WriteLine("\nPROFESORES DISPONIBLES\n");

            for (int i = 0; i < profesores.Count; i++) {
                Console.WriteLine((i + 1) + ". " + profesores[i].Nombre + " - " + "Materia: " + profesores[i].Materia);
            }

            int opcionProfesor;

            Console.Write("\nSeleccione un profesor: ");

            while (!int.TryParse(Console.ReadLine(), out opcionProfesor) || opcionProfesor < 1 || opcionProfesor > profesores.Count) {
                Console.Write("\nSeleccione profesor correcto: ");
            }

            string horario;

            do {
                Console.Write("\nHORARIO A RESERVAR: ");
                horario = Console.ReadLine() ?? "";

                if (horario == "") {
                    Console.WriteLine("Debe ingresar el horario.");
                }

            } while (horario == "");

            Reserva nuevaReserva = new Reserva(aulas[opcionAula - 1], profesores[opcionProfesor - 1], horario);

            reservas.Add(nuevaReserva);

            Console.WriteLine("\nReserva registrada correctamente.");
            Console.ReadKey();
        }

        public void EditReservation() {
            
            Console.Clear();

            Console.WriteLine("===== EDIT RESERVATION =====");

            if (booking.Count == 0) {
                Console.WriteLine("\nThere are no recorded reservations.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nREGISTERED RESERVATIONS\n");

            for (int i = 0; i < booking.Count; i++) {
                
                Console.WriteLine((i + 1) + ". " + booking[i].Teacher.Name + " - " + booking[i].Classroom.Name + " - (" 
                                    + booking[i].Teacher.Subject + ") - " + booking[i].Schedule);
            }

            int reservationOption;

            Console.Write("\nSelect the reservation: ");

            while (!int.TryParse(Console.ReadLine(), out reservationOption) || reservationOption < 1 || reservationOption > booking.Count) {
                Console.Write("\nSelect the correct reservation: ");
            }

            Booking booking = booking[reservationOption - 1];

            Console.WriteLine("\nCLASSROOMS\n");

            for (int i = 0; i < classroom.Count; i++) {
                Console.WriteLine((i + 1) + ". " + classroom[i].Name);
            }

            int optionClassroom;

            Console.Write("\nSelect a classroom: ");

            while (!int.TryParse(Console.ReadLine(), out optionClassroom) || optionClassroom < 1 || optionClassroom > classroom.Count) {
                Console.Write("\nSelect the correct classroom: ");
            }

            Console.WriteLine("\nTEACHERS\n");

            for (int i = 0; i < teachers.Count; i++) {
                Console.WriteLine((i + 1) + ". " + teachers[i].Name);
            }

            int teacherOption;

            Console.Write("\nSelect a teacher: ");

            while (!int.TryParse(Console.ReadLine(), out teacherOption) || teacherOption < 1 || teacherOption > teachers.Count) {
                Console.Write("\nSelect the correct teacher: ");
            }

            string schedule;
            
            do {
                
                Console.Write("\nNEW SCHEDULE: ");
                schedule = Console.ReadLine() ?? "";

                if (schedule == "") {
                    Console.WriteLine("You must enter the schedule.");
                }

            } while (schedule == "");

            booking.Classroom = classroom[optionClassroom - 1];
            booking.Teacher = teachers[teacherOption - 1];
            booking.Schedule = schedule;

            Console.WriteLine("\nReservation successfully updated.");
            Console.ReadKey();
        }

        public void ListReservations() {
            
            Console.Clear();

            Console.WriteLine("===== LIST OF RESERVATIONS =====");

            if (booking.Count == 0) {
                Console.WriteLine("\nThere are no reservations.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < booking.Count; i++) {
                
                Console.WriteLine("\nBooking #" + (i + 1));
                Console.WriteLine("\nTeacher : " + booking[i].Teacher.Name);
                Console.WriteLine("Classroom     : " + booking[i].Classroom.Name);
                Console.WriteLine("Subject  : " + booking[i].Teacher.Subject);
                Console.WriteLine("Schedule  : " + booking[i].Schedule);
            }

            Console.ReadKey();
        }
    }
}
