namespace Reserva_Aulas
{
    public class ReservaAulas
    {

        private List<Aula> aulas = new List<Aula>();
        private List<Profesor> profesores = new List<Profesor>();
        private List<Reserva> reservas = new List<Reserva>();

        private string LeerNombre(string mensaje) {
            string dato;

            do {
                Console.Write(mensaje);

                dato = Console.ReadLine() ?? "";

                if (dato == ""){
                    Console.WriteLine("El dato no puede quedar vacío.");
                }

            } while (dato == "");

            return dato;
        }

        public void RegistrarAula() {
            
            Console.Clear();

            string codigo, nombre;
            int capacidad;

            Console.WriteLine("===== REGISTRAR AULA =====");

            do {
                Console.Write("\nCódigo: ");
                codigo = Console.ReadLine() ?? "";

                if (codigo == "") {
                    Console.WriteLine("Debe ingresar un código.");
                }

                foreach (Aula aula in aulas) {
                    
                    if (aula.Codigo == codigo) {
                        
                        Console.WriteLine("Ese código ya existe.");
                        return;
                    }
                }

            } while (codigo == "");

            nombre = LeerNombre("Nombre: ");

            do {
                Console.Write("Capacidad (estudiantes): ");

                while (!int.TryParse(Console.ReadLine(), out capacidad)) {
                    Console.Write("Debe ingresar un número: ");
                }

                if (capacidad <= 0) {
                    Console.WriteLine("La capacidad debe ser mayor que cero.");
                }

            } while (capacidad <= 0);

            Aula nuevaAula = new Aula(codigo, nombre, capacidad);

            aulas.Add(nuevaAula);

            Console.WriteLine("\nAula registrada correctamente.");
        }

        public void EditarAula() {

            Console.Clear();

            Console.WriteLine("===== EDITAR AULA =====");

            if (aulas.Count == 0) {
                Console.WriteLine("\nNo hay aulas registradas.");
                return;
            }

            for (int i = 0; i < aulas.Count; i++) {

                Console.WriteLine("\nAula (" + (i + 1) + "). " + "Codigo: " + aulas[i].Codigo + " - " + aulas[i].Nombre + " - "
                                    + "Capacidad: " + aulas[i].Capacidad + " estudiantes.");
            }

            int opcion;

            Console.Write("\nSeleccione el número del aula: ");

            while (!int.TryParse(Console.ReadLine(), out opcion)) {
                Console.Write("Debe ingresar un número: ");
            }

            if (opcion < 1 || opcion > aulas.Count) {
                Console.WriteLine("Opción inválida.");
                return;
            }

            Aula aula = aulas[opcion - 1];

            string codigo, nombre;
            int capacidad;

            do {
                Console.Write("\nNuevo código: ");
                codigo = Console.ReadLine() ?? "";

                if (codigo == "") {
                    Console.WriteLine("Debe ingresar un código.");
                }

            } while (codigo == "");
            
            nombre = LeerNombre("Nombre: ");

            do {
                Console.Write("Nueva capacidad: ");

                while (!int.TryParse(Console.ReadLine(), out capacidad)) {
                    Console.Write("Debe ingresar un número: ");
                }

                if (capacidad <= 0) {
                    Console.WriteLine("La capacidad debe ser mayor que cero.");
                }

            } while (capacidad <= 0);

            aula.Codigo = codigo;
            aula.Nombre = nombre;
            aula.Capacidad = capacidad;

            Console.WriteLine("\nAula editada correctamente.");
        }

        public void ListarAulas() {
            
            Console.Clear();

            Console.WriteLine("===== LISTADO DE AULAS =====");

            if (aulas.Count == 0) {
                Console.WriteLine("\nNo hay aulas registradas.");
                return;
            }

            for (int i = 0; i < aulas.Count; i++) {

                Console.WriteLine("\nAula #" + (i + 1));
                Console.WriteLine("\nCódigo: " + aulas[i].Codigo);
                Console.WriteLine("Nombre: " + aulas[i].Nombre);
                Console.WriteLine("Capacidad (estudiantes): " + aulas[i].Capacidad);
            }
        }

        public void RegistrarProfesor()
        {
            Console.Clear();

            Console.WriteLine("===== REGISTRAR PROFESOR =====");

            string codigo, nombre;
            string materia;

            do {
                Console.Write("\nCódigo: ");
                codigo = Console.ReadLine() ?? "";

                if (codigo == "") {
                    Console.WriteLine("Debe ingresar un código.");
                }

            } while (codigo == "");

            nombre = LeerNombre("Nombre: ");

            do {
                Console.Write("Materia: ");
                materia = Console.ReadLine() ?? "";

                if (materia == "") {
                    Console.WriteLine("Debe ingresar una asignatura.");
                }

            } while (materia == "");

            Profesor nuevoProfesor = new Profesor(codigo, nombre, materia);

            profesores.Add(nuevoProfesor);

            Console.WriteLine("\nProfesor registrado correctamente.");
        }

        public void EditarProfesor() {
            
            Console.Clear();

            Console.WriteLine("===== EDITAR PROFESOR =====");

            if (profesores.Count == 0) {
                Console.WriteLine("\nNo hay profesores registrados.");
                return;
            }

            for (int i = 0; i < profesores.Count; i++) {
                Console.WriteLine("\nProfesor: (" + (i + 1) + "). " + "Codigo: " + profesores[i].Codigo + " - " + "Nombre: " + profesores[i].Nombre + 
                                  " - " + "Materia: " + profesores[i].Materia);
            }

            int opcion;

            Console.Write("\nSeleccione el profesor: ");

            while (!int.TryParse(Console.ReadLine(), out opcion)) {
                Console.Write("Debe ingresar un número: ");
            }

            if (opcion < 1 || opcion > profesores.Count) {
                Console.WriteLine("Opción inválida.");
                return;
            }

            Profesor profesor = profesores[opcion - 1];

            string codigo, nombre;
            string materia;

            do {
                Console.Write("\nNuevo código: ");
                codigo = Console.ReadLine() ?? "";

                if (codigo == "") {
                    Console.WriteLine("Debe ingresar un código.");
                }

            } while (codigo == "");

            nombre = LeerNombre("Nombre: ");

            do {
                Console.Write("Nueva materia: ");
                materia = Console.ReadLine() ?? "";

                if (materia == "") {
                    Console.WriteLine("Debe ingresar una asignatura.");
                }

            } while (materia == "");

            profesor.Codigo = codigo;
            profesor.Nombre = nombre;
            profesor.Materia = materia;

            Console.WriteLine("\nProfesor actualizado correctamente.");
        }

        public void ListarProfesores() {
            
            Console.Clear();

            Console.WriteLine("===== LISTADO DE PROFESORES =====");

            if (profesores.Count == 0) {
                Console.WriteLine("\nNo hay profesores registrados.");
                return;
            }

            for (int i = 0; i < profesores.Count; i++) {
                
                Console.WriteLine("\nProfesor #" + (i + 1));
                Console.WriteLine("\nCódigo: " + profesores[i].Codigo);
                Console.WriteLine("Nombre: " + profesores[i].Nombre);
                Console.WriteLine("Asignatura: " + profesores[i].Materia);
            }
        }

        public void RegistrarReserva() {
            
            Console.Clear();

            Console.WriteLine("===== REGISTRAR RESERVA =====");

            if (aulas.Count == 0) {
                Console.WriteLine("Debe registrar al menos un aula.");
                return;
            }

            if (profesores.Count == 0) {
                Console.WriteLine("Debe registrar al menos un profesor.");
                return;
            }

            Console.WriteLine("\nAULAS DISPONIBLES");

            for (int i = 0; i < aulas.Count; i++) {
                Console.WriteLine((i + 1) + ". " + aulas[i].Nombre);
            }

            int opcionAula;

            Console.Write("\nSeleccione un aula: ");

            while (!int.TryParse(Console.ReadLine(), out opcionAula)) {
                Console.Write("Debe ingresar un número: ");
            }

            if (opcionAula < 1 || opcionAula > aulas.Count) {
                Console.WriteLine("Opción inválida.");
                return;
            }

            Console.WriteLine();

            Console.WriteLine("PROFESORES");

            for (int i = 0; i < profesores.Count; i++) {
                Console.WriteLine((i + 1) + ". " + profesores[i].Nombre);
            }

            int opcionProfesor;

            Console.Write("\nSeleccione un profesor: ");

            while (!int.TryParse(Console.ReadLine(), out opcionProfesor)) {
                Console.Write("Debe ingresar un número: ");
            }

            if (opcionProfesor < 1 || opcionProfesor > profesores.Count) {
                Console.WriteLine("Opción inválida.");
                return;
            }

            string materia;

            do {
                Console.Write("Materia: ");
                materia = Console.ReadLine() ?? "";

                if (materia == "") {
                    Console.WriteLine("Debe ingresar la materia.");
                }

            } while (materia == "");

            string horario;

            do {
                Console.Write("Horario: ");
                horario = Console.ReadLine() ?? "";

                if (horario == "") {
                    Console.WriteLine("Debe ingresar el horario.");
                }

            } while (horario == "");

            Reserva nuevaReserva = new Reserva(aulas[opcionAula - 1], profesores[opcionProfesor - 1], materia, horario);

            reservas.Add(nuevaReserva);

            Console.WriteLine("\nReserva registrada correctamente.");
        }

        public void EditarReserva() {
            
            Console.Clear();

            Console.WriteLine("===== EDITAR RESERVA =====");

            if (reservas.Count == 0) {
                Console.WriteLine("No existen reservas registradas.");
                return;
            }

            for (int i = 0; i < reservas.Count; i++) {
                
                Console.WriteLine((i + 1) + ". " + reservas[i].Profesor.Nombre + " - " + reservas[i].Aula.Nombre + " - " + reservas[i].Horario);
            }

            int opcionReserva;

            Console.Write("\nSeleccione la reserva: ");

            while (!int.TryParse(Console.ReadLine(), out opcionReserva)) {
                Console.Write("Debe ingresar un número: ");
            }

            if (opcionReserva < 1 || opcionReserva > reservas.Count) {
                Console.WriteLine("Opción inválida.");
                return;
            }

            Reserva reserva = reservas[opcionReserva - 1];

            Console.WriteLine("\nAULAS");

            for (int i = 0; i < aulas.Count; i++) {
                Console.WriteLine((i + 1) + ". " + aulas[i].Nombre);
            }

            int opcionAula;

            Console.Write("Seleccione un aula: ");

            while (!int.TryParse(Console.ReadLine(), out opcionAula)) {
                Console.Write("Debe ingresar un número: ");
            }

            if (opcionAula < 1 || opcionAula > aulas.Count) {
                Console.WriteLine("Opción inválida.");
                return;
            }

            Console.WriteLine("\nPROFESORES");

            for (int i = 0; i < profesores.Count; i++) {
                Console.WriteLine((i + 1) + ". " + profesores[i].Nombre);
            }

            int opcionProfesor;

            Console.Write("Seleccione un profesor: ");

            while (!int.TryParse(Console.ReadLine(), out opcionProfesor)) {
                Console.Write("Debe ingresar un número: ");
            }

            if (opcionProfesor < 1 || opcionProfesor > profesores.Count) {
                Console.WriteLine("Opción inválida.");
                return;
            }

            string materia;
            do {
                
                Console.Write("Nueva materia: ");
                materia = Console.ReadLine() ?? "";

                if (materia == "") {
                    Console.WriteLine("Debe ingresar la materia.");
                }

            } while (materia == "");


            string horario;
            do {
                
                Console.Write("Nuevo horario: ");
                horario = Console.ReadLine() ?? "";

                if (horario == "") {
                    Console.WriteLine("Debe ingresar el horario.");
                }

            } while (horario == "");

            reserva.Aula = aulas[opcionAula - 1];
            reserva.Profesor = profesores[opcionProfesor - 1];
            reserva.Materia = materia;
            reserva.Horario = horario;

            Console.WriteLine("\nReserva actualizada correctamente.");
        }

        public void ListarReservas() {
            
            Console.Clear();

            Console.WriteLine("===== LISTADO DE RESERVAS =====");

            if (reservas.Count == 0) {
                Console.WriteLine("No existen reservas.");
                return;
            }

            for (int i = 0; i < reservas.Count; i++) {
                
                Console.WriteLine("Reserva #" + (i + 1));
                Console.WriteLine("Profesor : " + reservas[i].Profesor.Nombre);
                Console.WriteLine("Aula     : " + reservas[i].Aula.Nombre);
                Console.WriteLine("Materia  : " + reservas[i].Materia);
                Console.WriteLine("Horario  : " + reservas[i].Horario);
            }
        }

    }
}
