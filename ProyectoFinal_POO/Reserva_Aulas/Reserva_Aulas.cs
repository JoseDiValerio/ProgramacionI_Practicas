namespace Reserva_Aulas {
    public class ReservaAulas {

        private List<Aula> aulas = new List<Aula>();
        private List<Profesor> profesores = new List<Profesor>();
        private List<Reserva> reservas = new List<Reserva>();

        // Metodos de validacion
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

        private int LeerNumero(string mensaje) {
            
            int numero;

            Console.Write(mensaje);

            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0) {
                Console.Write("\nIngrese numero entero mayor que 0: ");
            }

            return numero;
        }

        private bool ExisteCodigoAulaAgregar(string codigo) {

            foreach (Aula aulas in aulas) {
                
                if (aulas.Codigo == codigo) {
                    return true;
                }
            }

            return false;
        }

        private bool ExisteCodigoAulaEditar(string codigo, Aula aulaActual) {

            foreach (Aula aula in aulas) {
                
                if (aula != aulaActual && aula.Codigo == codigo) {
                    return true;
                }
            }

            return false;
        }

        private bool ExisteCodigoProfesorAgregar(string codigo) {

            foreach (Profesor profesores in profesores) {

                if (profesores.Codigo == codigo) {
                    return true;
                }
            }

            return false;
        }

        private bool ExisteCodigoProfesorEditar(string codigo, Profesor profesorActual) {

            foreach (Profesor profesores in profesores) {

                if (profesores != profesorActual && profesores.Codigo == codigo) {
                    return true;
                }
            }

            return false;
        }

        // Funciones principales
        public void RegistrarAula() {
            
            Console.Clear();

            string codigo, nombre;
            int capacidad;

            Console.WriteLine("===== REGISTRAR AULA =====");

            do {
                Console.Write("\nCodigo: ");
                codigo = Console.ReadLine() ?? "";

                if (ExisteCodigoAulaAgregar(codigo)) {
                    Console.WriteLine("\nCodigo ya existe.");
                }

            } while (ExisteCodigoAulaAgregar(codigo));

            nombre = LeerNombre("\nNombre: ");

            capacidad = LeerNumero("\nCapacidad (estudiantes): ");

            Aula nuevaAula = new Aula(codigo, nombre, capacidad);

            aulas.Add(nuevaAula);

            Console.WriteLine("\nAula registrada correctamente.");
            Console.ReadKey();
        }

        public void EditarAula() {

            Console.Clear();

            Console.WriteLine("===== EDITAR AULA =====");

            if (aulas.Count == 0) {
                Console.WriteLine("\nNo hay aulas registradas.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < aulas.Count; i++) {

                Console.WriteLine("\nAula (" + (i + 1) + "). " + "Codigo: " + aulas[i].Codigo + " - " + aulas[i].Nombre + " - "
                                    + "Capacidad: " + aulas[i].Capacidad + " estudiantes.");
            }

            int opcion;

            Console.Write("\nSeleccione el número del aula: ");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > aulas.Count) {
                Console.Write("\nOpcion invalida. Intente nuevamente: ");
            }

            Aula aula = aulas[opcion - 1];

            string codigo, nombre;
            int capacidad;

            do {
                Console.Write("\nNuevo código: ");
                codigo = Console.ReadLine() ?? "";

                if (ExisteCodigoAulaEditar(codigo, aula)) {
                    Console.WriteLine("Codigo ya existe.");
                }

            } while (ExisteCodigoAulaEditar(codigo, aula));

            nombre = LeerNombre("Nombre: ");

            capacidad = LeerNumero("Capacidad (estudiantes): ");

            aula.Codigo = codigo;
            aula.Nombre = nombre;
            aula.Capacidad = capacidad;

            Console.WriteLine("\nAula editada correctamente.");
            Console.ReadKey();
        }

        public void ListarAulas() {
            
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

        public void RegistrarProfesor()
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

        public void EditarProfesor() {
            
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

        public void ListarProfesores() {
            
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

        public void RegistrarReserva() {
            
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

        public void EditarReserva() {
            
            Console.Clear();

            Console.WriteLine("===== EDITAR RESERVA =====");

            if (reservas.Count == 0) {
                Console.WriteLine("\nNo existen reservas registradas.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nRESERVAS REGISTRADAS\n");

            for (int i = 0; i < reservas.Count; i++) {
                
                Console.WriteLine((i + 1) + ". " + reservas[i].Profesor.Nombre + " - " + reservas[i].Aula.Nombre + " - (" 
                                    + reservas[i].Profesor.Materia + ") - " + reservas[i].Horario);
            }

            int opcionReserva;

            Console.Write("\nSeleccione la reserva: ");

            while (!int.TryParse(Console.ReadLine(), out opcionReserva) || opcionReserva < 1 || opcionReserva > reservas.Count) {
                Console.Write("\nSeleccione reserva correcta: ");
            }

            Reserva reserva = reservas[opcionReserva - 1];

            Console.WriteLine("\nAULAS\n");

            for (int i = 0; i < aulas.Count; i++) {
                Console.WriteLine((i + 1) + ". " + aulas[i].Nombre);
            }

            int opcionAula;

            Console.Write("\nSeleccione un aula: ");

            while (!int.TryParse(Console.ReadLine(), out opcionAula) || opcionAula < 1 || opcionAula > aulas.Count) {
                Console.Write("\nSeleccione aula correcta: ");
            }

            Console.WriteLine("\nPROFESORES\n");

            for (int i = 0; i < profesores.Count; i++) {
                Console.WriteLine((i + 1) + ". " + profesores[i].Nombre);
            }

            int opcionProfesor;

            Console.Write("\nSeleccione un profesor: ");

            while (!int.TryParse(Console.ReadLine(), out opcionProfesor) || opcionProfesor < 1 || opcionProfesor > profesores.Count) {
                Console.Write("\nSeleccione profesor correcto: ");
            }

            string horario;
            
            do {
                
                Console.Write("\nNUEVO HORARIO: ");
                horario = Console.ReadLine() ?? "";

                if (horario == "") {
                    Console.WriteLine("Debe ingresar el horario.");
                }

            } while (horario == "");

            reserva.Aula = aulas[opcionAula - 1];
            reserva.Profesor = profesores[opcionProfesor - 1];
            reserva.Horario = horario;

            Console.WriteLine("\nReserva actualizada correctamente.");
            Console.ReadKey();
        }

        public void ListarReservas() {
            
            Console.Clear();

            Console.WriteLine("===== LISTADO DE RESERVAS =====");

            if (reservas.Count == 0) {
                Console.WriteLine("\nNo existen reservas.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < reservas.Count; i++) {
                
                Console.WriteLine("\nReserva #" + (i + 1));
                Console.WriteLine("\nProfesor : " + reservas[i].Profesor.Nombre);
                Console.WriteLine("Aula     : " + reservas[i].Aula.Nombre);
                Console.WriteLine("Materia  : " + reservas[i].Profesor.Materia);
                Console.WriteLine("Horario  : " + reservas[i].Horario);
            }

            Console.ReadKey();
        }
    }
}
