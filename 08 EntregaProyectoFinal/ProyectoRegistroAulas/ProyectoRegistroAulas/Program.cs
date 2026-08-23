using ProyectoRegistroAulas.Datos.Modelos;
using ProyectoRegistroAulas.Negocio.Servicios;

ServicioAulas servicioAulas = new ServicioAulas();
ServicioProfesores servicioProfesores = new ServicioProfesores();
ServicioReservas servicioReservas = new ServicioReservas();
ServicioBaseDatos servicioBaseDatos = new ServicioBaseDatos();

servicioBaseDatos.CrearBaseDeDatos();

bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("\n========================================");
    Console.WriteLine("       SISTEMA DE CONTROL DE AULAS      ");
    Console.WriteLine("========================================");
    Console.WriteLine("\t1. Gestionar Aulas");
    Console.WriteLine("\t2. Gestionar Profesores");
    Console.WriteLine("\t3. Gestionar Reservas");
    Console.WriteLine("\t4. Salir");
    Console.WriteLine("========================================");
    Console.Write("\nSeleccione una opción: ");

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            MenuAulas();
            break;

        case "2":
            MenuProfesores();
            break;

        case "3":
            MenuReservas();
            break;

        case "4":
            salir = true;
            Console.WriteLine("\n¡Saliendo del sistema!\n");
            break;

        default:
            Console.Write("\nOpción no válida. Intente de nuevo.");
            Console.ReadKey();
            break;
    }
}

// ================================================================
// GESTIÓN DE AULAS
// ================================================================

void MenuAulas()
{
    bool regresar = false;

    while (!regresar)
    {
        Console.Clear();
        Console.WriteLine("\n========================================");
        Console.WriteLine("          MENÚ GESTIONAR AULAS          ");
        Console.WriteLine("========================================");
        Console.WriteLine("\t1. Registrar Aula");
        Console.WriteLine("\t2. Editar Aula");
        Console.WriteLine("\t3. Listar Aulas");
        Console.WriteLine("\t4. Eliminar Aula");
        Console.WriteLine("\t5. Regresar");
        Console.WriteLine("========================================");
        Console.Write("\nSeleccione una opción: ");

        string opcion = Console.ReadLine() ?? "";

        switch (opcion)
        {
            case "1":
                RegistrarAula();
                break;

            case "2":
                EditarAula();
                break;

            case "3":
                Console.Clear();
                ListarAulas();
                Console.WriteLine("\nPresione cualquier tecla para regresar...");
                Console.ReadKey();
                break;

            case "4":
                EliminarAula();
                break;

            case "5":
                regresar = true;
                break;

            default:
                Console.Write("\nOpción no válida.");
                Console.ReadKey();
                break;
        }
    }
}

void RegistrarAula()
{
    Console.Clear();
    Console.WriteLine("\t    -- REGISTRAR NUEVA AULA --");
    ListarAulas();
    Console.WriteLine("--------------------------------------------------");

    int codigo = 0;

    while (true)
    {
        Console.Write("\nIngrese el código del aula (0 para cancelar): ");

        if (int.TryParse(Console.ReadLine(), out codigo))
        {
            if (codigo == 0)
            {
                Console.Write("\n❌ Registro cancelado.");
                Console.ReadKey();
                return;
            }

            if (codigo > 0)
            {
                if (servicioAulas.ExisteCodigo(codigo))
                {
                    Console.WriteLine("\n❌ Error! Ya existe un aula con ese código, intente con otro.");
                    continue;
                }

                break;
            }
        }

        Console.WriteLine("\n❌ Error! No ingresó ningún código, intente nuevamente.");
    }

    Console.WriteLine("\n--- DATOS PARA NUEVA AULA ---");

    string nombre = "";

    while (true)
    {
        Console.Write("\nIngrese el nombre del aula: ");
        nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("\n❌ Error: El nombre no puede estar vacío.");
            Console.ReadKey();
            continue;
        }

        if (servicioAulas.ExisteNombre(nombre))
        {
            Console.WriteLine("\n❌ Error: Ya existe un aula registrada con ese mismo nombre.");
            Console.ReadKey();
            continue;
        }

        break;
    }

    int capacidad = 0;

    while (true)
    {
        Console.Write("\nIngrese la capacidad del aula: ");

        if (int.TryParse(Console.ReadLine(), out capacidad) && capacidad > 0)
        {
            break;
        }

        Console.WriteLine("\n❌ Error: La capacidad debe ser un número entero mayor a cero.");
    }

    Aula nuevaAula = new Aula
    {
        Codigo = codigo,
        Nombre = nombre,
        Capacidad = capacidad
    };

    servicioAulas.Agregar(nuevaAula);

    Console.WriteLine("\n✅ ¡Aula registrada exitosamente!");
    Console.ReadKey();
}

void ListarAulas()
{
    Console.WriteLine("\n---------- LISTADO DE AULAS REGISTRADAS ----------");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("{0,-10} {1,-20} {2,-10}", "CÓDIGO", "NOMBRE", "CAPACIDAD");
    Console.WriteLine("--------------------------------------------------");

    var lista = servicioAulas.Listar();

    if (lista.Count == 0)
    {
        Console.Write("⚠️ No hay aulas registradas en el sistema.");
        Console.WriteLine("\n--------------------------------------------------");
        return;
    }

    foreach (var aula in lista)
    {
        Console.WriteLine("{0,-10} {1,-20} {2,-10}",
            aula.Codigo,
            aula.Nombre,
            aula.Capacidad);
    }
}

void EditarAula()
{
    Console.Clear();
    Console.WriteLine("\t      --- EDITAR AULA ---");
    ListarAulas();

    if (!servicioAulas.HayAulas())
    {
        Console.ReadKey();
        return;
    }

    Aula? aula = null;

    while (true)
    {
        Console.Write("\nIngrese el código del aula que desea modificar (o 0 para cancelar): ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("\n❌ Error! Ingrese un formato numérico válido.");
            continue;
        }

        if (codigo == 0)
        {
            Console.Write("\n❌ Editar cancelado.");
            Console.ReadKey();
            return;
        }

        aula = servicioAulas.BuscarPorCodigo(codigo);

        if (aula != null)
        {
            break;
        }

        Console.WriteLine("\n❌ Error! El código especificado no existe en el sistema.");
    }

    Console.WriteLine("\n--------------------------------------------------");
    Console.WriteLine($"Modificando Aula Código {aula.Codigo}: {aula.Nombre} (Capacidad: {aula.Capacidad})");
    Console.WriteLine("--------------------------------------------------");

    string nuevoNombre = "";

    while (true)
    {
        Console.Write("\nIngrese el nuevo nombre (Deje vacío para mantener el actual): ");
        nuevoNombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nuevoNombre))
        {
            break;
        }

        if (servicioAulas.ExisteNombre(nuevoNombre, aula.Codigo))
        {
            Console.Write("\n❌ Error! Existe otra aula con el mismo nombre.\n");
            continue;
        }

        break;
    }

    int nuevaCapacidad = 0;

    while (true)
    {
        Console.Write("\nIngrese la nueva capacidad (Deje vacío para mantener la actual): ");
        string entradaCapacidad = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(entradaCapacidad))
        {
            nuevaCapacidad = aula.Capacidad;
            break;
        }

        if (int.TryParse(entradaCapacidad, out nuevaCapacidad) && nuevaCapacidad > 0)
        {
            break;
        }

        Console.WriteLine("\n❌ Error! La capacidad debe ser un número entero mayor a cero.");
    }

    servicioAulas.Editar(aula.Codigo, nuevoNombre, nuevaCapacidad);

    Console.WriteLine("\n✅ ¡Aula modificada correctamente!");
    Console.ReadKey();
}

void EliminarAula()
{
    if (!servicioAulas.HayAulas())
    {
        Console.Clear();
        Console.WriteLine("\t\t-- ELIMINAR AULA --");
        ListarAulas();
        Console.ReadKey();
        return;
    }

    Aula? aula = null;

    while (aula == null)
    {
        Console.Clear();
        Console.WriteLine("\t\t-- ELIMINAR AULA --");
        ListarAulas();
        Console.WriteLine("--------------------------------------------------");
        Console.Write("\nIngrese el código del aula que desea eliminar (0 para cancelar): ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.Write("\n❌ Error: Ingrese un código válido, intente nuevamente.");
            Console.ReadKey();
            continue;
        }

        if (codigo == 0)
        {
            return;
        }

        aula = servicioAulas.BuscarPorCodigo(codigo);

        if (aula == null)
        {
            Console.Write("\n❌ Error! El código no existe, intente nuevamente.");
            Console.ReadKey();
        }
    }

    string confirmacion = "";

    do
    {
        Console.WriteLine("\n--- CONFIRMAR ELIMINACIÓN ---");
        Console.WriteLine($"\nAula seleccionada: {aula.Nombre} (Código: {aula.Codigo})");
        Console.WriteLine("--------------------------------------------------");
        Console.Write("\n¿Está seguro? (S = Sí / N = No): ");

        confirmacion = Console.ReadLine() ?? "";
        confirmacion = confirmacion.ToUpper();

        if (confirmacion == "S")
        {
            servicioAulas.Eliminar(aula);
            Console.WriteLine("\n✅ ¡Aula eliminada exitosamente!");
        }
        else if (confirmacion == "N")
        {
            Console.WriteLine("\n❌ Operación cancelada.");
        }
        else
        {
            Console.Write("\n❌ Error: Opción no válida, intente nuevamente.");
            Console.ReadKey();
            Console.WriteLine("--------------------------------------------------");
        }

    } while (confirmacion != "S" && confirmacion != "N");

    Console.ReadKey();
}

// ================================================================
// GESTIÓN DE PROFESORES
// ================================================================

void MenuProfesores()
{
    bool regresar = false;

    while (!regresar)
    {
        Console.Clear();
        Console.WriteLine("\n========================================");
        Console.WriteLine("        MENÚ GESTIONAR PROFESORES       ");
        Console.WriteLine("========================================");
        Console.WriteLine("\t1. Registrar Profesor");
        Console.WriteLine("\t2. Editar Profesor");
        Console.WriteLine("\t3. Listar Profesores");
        Console.WriteLine("\t4. Eliminar Profesor");
        Console.WriteLine("\t5. Regresar");
        Console.WriteLine("========================================");
        Console.Write("\nSeleccione una opción: ");

        string opcion = Console.ReadLine() ?? "";

        switch (opcion)
        {
            case "1":
                RegistrarProfesor();
                break;

            case "2":
                EditarProfesor();
                break;

            case "3":
                Console.Clear();
                ListarProfesores();
                Console.WriteLine("\nPresione cualquier tecla para regresar...");
                Console.ReadKey();
                break;

            case "4":
                EliminarProfesor();
                break;

            case "5":
                regresar = true;
                break;

            default:
                Console.Write("\nOpción no válida.");
                Console.ReadKey();
                break;
        }
    }
}

void RegistrarProfesor()
{
    Console.Clear();
    Console.WriteLine("\t--- REGISTRAR NUEVO PROFESOR ---");
    ListarProfesores();
    Console.WriteLine("--------------------------------------------------");

    int codigo = 0;

    while (true)
    {
        Console.Write("\nIngrese el código del profesor (0 para cancelar): ");

        if (int.TryParse(Console.ReadLine(), out codigo))
        {
            if (codigo == 0)
            {
                Console.WriteLine("\n❌ Registro cancelado.");
                Console.ReadKey();
                return;
            }

            if (codigo > 0)
            {
                if (servicioProfesores.ExisteCodigo(codigo))
                {
                    Console.WriteLine("\n❌ Error! Ya existe un profesor con ese código, intente con otro.");
                    continue;
                }

                break;
            }
        }

        Console.WriteLine("\n❌ Error! No ingresó ningún código, intente nuevamente.");
    }

    Console.WriteLine("\n--- DATOS PARA NUEVO PROFESOR ---");

    string nombre = "";

    while (true)
    {
        Console.Write("\nIngrese el nombre del profesor: ");
        nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.Write("\n❌ Error: El nombre no puede estar vacío.");
            Console.ReadKey();
            continue;
        }

        break;
    }

    string materia = "";

    while (true)
    {
        Console.Write("\nIngrese la materia que imparte: ");
        materia = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(materia))
        {
            Console.Write("\n❌ Error: La materia no puede estar vacía.");
            Console.ReadKey();
            continue;
        }

        break;
    }

    Profesor nuevoProfesor = new Profesor
    {
        Codigo = codigo,
        Nombre = nombre,
        Materia = materia
    };

    servicioProfesores.Agregar(nuevoProfesor);

    Console.WriteLine("\n✅ ¡Profesor registrado exitosamente!");
    Console.ReadKey();
}

void ListarProfesores()
{
    Console.WriteLine("\n------- LISTADO DE PROFESORES REGISTRADOS --------");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("{0,-10} {1,-20} {2,-20}", "CÓDIGO", "NOMBRE", "MATERIA");
    Console.WriteLine("--------------------------------------------------");

    var lista = servicioProfesores.Listar();

    if (lista.Count == 0)
    {
        Console.WriteLine("⚠️ No hay profesores registrados en el sistema.");
        return;
    }

    foreach (var prof in lista)
    {
        Console.WriteLine("{0,-10} {1,-20} {2,-20}",
            prof.Codigo,
            prof.Nombre,
            prof.Materia);
    }
}

void EditarProfesor()
{
    Console.Clear();
    Console.WriteLine("\t      --- EDITAR PROFESOR ---");
    ListarProfesores();

    if (!servicioProfesores.HayProfesores())
    {
        Console.ReadKey();
        return;
    }

    Profesor? profesor = null;

    while (true)
    {
        Console.Write("\nIngrese el código del profesor que desea modificar (o 0 para cancelar): ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("\n❌ Error! Ingrese un formato numérico válido.");
            continue;
        }

        if (codigo == 0)
        {
            Console.Write("\n❌ Editar cancelado.");
            Console.ReadKey();
            return;
        }

        profesor = servicioProfesores.BuscarPorCodigo(codigo);

        if (profesor != null)
        {
            break;
        }

        Console.WriteLine("\n❌ Error! El código especificado no existe en el sistema.");
    }

    Console.WriteLine("\n--------------------------------------------------");
    Console.WriteLine($"Modificando Profesor Código {profesor.Codigo}: {profesor.Nombre} (Materia: {profesor.Materia})");
    Console.WriteLine("--------------------------------------------------");

    Console.Write("\nIngrese el nuevo nombre (Deje vacío para mantener el actual): ");
    string nuevoNombre = Console.ReadLine() ?? "";

    Console.Write("\nIngrese la nueva materia que imparte (Deje vacío para mantener la actual): ");
    string nuevaMateria = Console.ReadLine() ?? "";

    servicioProfesores.Editar(profesor.Codigo, nuevoNombre, nuevaMateria);

    Console.WriteLine("\n✅ ¡Profesor modificado correctamente!");
    Console.ReadKey();
}

void EliminarProfesor()
{
    if (!servicioProfesores.HayProfesores())
    {
        Console.Clear();
        Console.WriteLine("\t  --- ELIMINAR PROFESOR ---");
        ListarProfesores();
        Console.ReadKey();
        return;
    }

    Profesor? profesor = null;

    while (profesor == null)
    {
        Console.Clear();
        Console.WriteLine("\t    --- ELIMINAR PROFESOR ---");
        ListarProfesores();
        Console.WriteLine("--------------------------------------------------");
        Console.Write("\nIngrese el código del profesor que desea eliminar (0 para cancelar): ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.Write("\n❌ Error: Ingrese un código válido, intente nuevamente.");
            Console.ReadKey();
            continue;
        }

        if (codigo == 0)
        {
            return;
        }

        profesor = servicioProfesores.BuscarPorCodigo(codigo);

        if (profesor == null)
        {
            Console.Write("\n❌ Error! El código no existe, intente nuevamente.");
            Console.ReadKey();
        }
    }

    string confirmacion = "";

    do
    {
        Console.WriteLine("\n--- CONFIRMAR ELIMINACIÓN ---");
        Console.WriteLine($"\nProfesor seleccionado: {profesor.Nombre} (Código: {profesor.Codigo})");
        Console.WriteLine("--------------------------------------------------");
        Console.Write("\n¿Está seguro? (S = Sí / N = No): ");

        confirmacion = Console.ReadLine() ?? "";
        confirmacion = confirmacion.ToUpper();

        if (confirmacion == "S")
        {
            servicioProfesores.Eliminar(profesor);
            Console.WriteLine("\n✅ ¡Profesor eliminado exitosamente!");
        }
        else if (confirmacion == "N")
        {
            Console.WriteLine("\n❌ Operación cancelada.");
        }
        else
        {
            Console.Write("\n❌ Error: Opción no válida, intente nuevamente.");
            Console.ReadKey();
            Console.WriteLine("--------------------------------------------------");
        }

    } while (confirmacion != "S" && confirmacion != "N");

    Console.ReadKey();
}

// ================================================================
// GESTIÓN DE RESERVAS
// ================================================================

void MenuReservas()
{
    bool regresar = false;

    while (!regresar)
    {
        Console.Clear();
        Console.WriteLine("\n========================================");
        Console.WriteLine("         MENÚ GESTIONAR RESERVAS        ");
        Console.WriteLine("========================================");
        Console.WriteLine("\t1. Guardar Reservación");
        Console.WriteLine("\t2. Editar Reservación");
        Console.WriteLine("\t3. Listar Reservaciones");
        Console.WriteLine("\t4. Eliminar Reservación");
        Console.WriteLine("\t5. Regresar");
        Console.WriteLine("========================================");
        Console.Write("\nSeleccione una opción: ");

        string opcion = Console.ReadLine() ?? "";

        switch (opcion)
        {
            case "1":
                GuardarReservacion();
                break;

            case "2":
                EditarReservacion();
                break;

            case "3":
                Console.Clear();
                ListarReservaciones();
                Console.WriteLine("\nPresione cualquier tecla para regresar.");
                Console.ReadKey();
                break;

            case "4":
                Console.Clear();
                EliminarReservacion();
                break;

            case "5":
                regresar = true;
                break;

            default:
                Console.Write("\nOpción no válida.");
                Console.ReadKey();
                break;
        }
    }
}

void GuardarReservacion()
{
    Console.Clear();
    Console.WriteLine("--- REGISTRAR NUEVA RESERVACIÓN ---");
    Console.WriteLine("\t\t\n-- AULAS DISPONIBLES --");
    ListarAulas();
    Console.WriteLine("\t\t\n-- PROFESORES DISPONIBLES --");
    ListarProfesores();
    Console.WriteLine("--------------------------------------------------\n");

    if (!servicioAulas.HayAulas() || !servicioProfesores.HayProfesores())
    {
        Console.WriteLine("\n❌ Debe existir al menos un aula y un profesor para registrar una reserva.");
        Console.ReadKey();
        return;
    }

    int codigoAula = 0;

    while (true)
    {
        Console.Write("\nIngrese el código del aula a reservar (0 para cancelar): ");

        if (int.TryParse(Console.ReadLine(), out codigoAula))
        {
            if (codigoAula == 0)
            {
                Console.Write("\n❌ Registro cancelado.");
                Console.ReadKey();
                return;
            }

            if (codigoAula > 0)
            {
                if (servicioReservas.BuscarAulaPorCodigo(codigoAula) == null)
                {
                    Console.WriteLine("\n❌ Error! El código de aula ingresado no existe, intente con otro.");
                    continue;
                }

                break;
            }
        }

        Console.WriteLine("\n❌ Error! No ingresó ningún código de aula válido, intente nuevamente.");
    }

    int codigoProfesor = 0;

    while (true)
    {
        Console.Write("\nIngrese el código del profesor (0 para cancelar): ");

        if (int.TryParse(Console.ReadLine(), out codigoProfesor))
        {
            if (codigoProfesor == 0)
            {
                Console.Write("\n❌ Registro cancelado.");
                Console.ReadKey();
                return;
            }

            if (codigoProfesor > 0)
            {
                if (servicioReservas.BuscarProfesorPorCodigo(codigoProfesor) == null)
                {
                    Console.WriteLine("\n❌ Error! El código de profesor ingresado no existe, intente con otro.");
                    continue;
                }

                break;
            }
        }

        Console.WriteLine("\n❌ Error! No ingresó ningún código de profesor válido, intente nuevamente.");
    }

    Console.WriteLine("\n--- DATOS PARA NUEVA RESERVACIÓN ---");

    DateTime fecha;

    while (true)
    {
        Console.Write("Ingrese la fecha de la reserva (AAAA-MM-DD): ");

        if (DateTime.TryParse(Console.ReadLine(), out fecha))
        {
            break;
        }

        Console.WriteLine("\n❌ Error! Formato de fecha no válido, intente nuevamente.");
    }

    TimeSpan horaInicio = TimeSpan.Zero;
    TimeSpan horaFinalizacion = TimeSpan.Zero;

    while (true)
    {
        Console.WriteLine("\n--- SELECCIONE EL HORARIO DE LA RESERVA ---");
        Console.WriteLine("\n1. 08:00 AM - 10:00 AM");
        Console.WriteLine("2. 10:30 AM - 12:00 PM");
        Console.WriteLine("3. 01:00 PM - 03:00 PM");
        Console.WriteLine("4. 03:30 PM - 05:00 PM");
        Console.WriteLine("5. 05:30 PM - 07:30 PM");
        Console.Write("\nSeleccione una opción de horario (1-5): ");

        string opcionHora = Console.ReadLine() ?? "";

        if (opcionHora == "1")
        {
            horaInicio = new TimeSpan(8, 0, 0);
            horaFinalizacion = new TimeSpan(10, 0, 0);
            break;
        }
        else if (opcionHora == "2")
        {
            horaInicio = new TimeSpan(10, 30, 0);
            horaFinalizacion = new TimeSpan(12, 0, 0);
            break;
        }
        else if (opcionHora == "3")
        {
            horaInicio = new TimeSpan(13, 0, 0);
            horaFinalizacion = new TimeSpan(15, 0, 0);
            break;
        }
        else if (opcionHora == "4")
        {
            horaInicio = new TimeSpan(15, 30, 0);
            horaFinalizacion = new TimeSpan(17, 0, 0);
            break;
        }
        else if (opcionHora == "5")
        {
            horaInicio = new TimeSpan(17, 30, 0);
            horaFinalizacion = new TimeSpan(19, 30, 0);
            break;
        }
        else
        {
            Console.WriteLine("\n❌ Error: Opción de horario no válida. Intente de nuevo.");
        }
    }

    Aula? aula = servicioReservas.BuscarAulaPorCodigo(codigoAula);
    Profesor? profesor = servicioReservas.BuscarProfesorPorCodigo(codigoProfesor);

    if (aula == null || profesor == null)
    {
        Console.WriteLine("\n❌ No se encontraron los datos seleccionados.");
        Console.ReadKey();
        return;
    }

    bool aulaOcupada = servicioReservas.AulaOcupada(
        aula.Id,
        fecha,
        horaInicio,
        horaFinalizacion);

    if (aulaOcupada)
    {
        Console.WriteLine("\n❌ Error! El aula ya se encuentra reservada en esa fecha y rango de horario.");
        Console.ReadKey();
        return;
    }

    Reserva nuevaReserva = new Reserva
    {
        AulaId = aula.Id,
        ProfesorId = profesor.Id,
        Fecha = fecha,
        HoraInicio = horaInicio,
        HoraFinalizacion = horaFinalizacion
    };

    servicioReservas.Agregar(nuevaReserva);

    Console.WriteLine("\n✅ ¡Reservación registrada exitosamente!");
    Console.ReadKey();
}

void ListarReservaciones()
{
    Console.WriteLine("------------------------- LISTADO DE RESERVACIONES REGISTRADAS -------------------------");
    Console.WriteLine("----------------------------------------------------------------------------------------");
    Console.WriteLine("{0,-6} {1,-20} {2,-20} {3,-12} {4,-15} {5,-15}",
        "ID", "AULA", "PROFESOR", "FECHA", "HORA INICIO", "HORA FIN");
    Console.WriteLine("----------------------------------------------------------------------------------------");

    var lista = servicioReservas.Listar();

    if (lista.Count == 0)
    {
        Console.Write("⚠️ No hay reservaciones registradas en el sistema.");
        return;
    }

    foreach (var reserva in lista)
    {
        string fechaCorta = reserva.Fecha.ToString("yyyy-MM-dd");
        string inicio = reserva.HoraInicio.ToString(@"hh\:mm");
        string fin = reserva.HoraFinalizacion.ToString(@"hh\:mm");

        Console.WriteLine("{0,-6} {1,-20} {2,-20} {3,-12} {4,-15} {5,-15}",
            reserva.Id,
            reserva.Aula.Nombre,
            reserva.Profesor.Nombre,
            fechaCorta,
            inicio,
            fin);
    }
}

void EditarReservacion()
{
    Console.Clear();
    Console.WriteLine("\t\t\t\t--- EDITAR RESERVACIÓN ---\n");
    ListarReservaciones();
    Console.WriteLine("----------------------------------------------------------------------------------------");

    if (!servicioReservas.HayReservas())
    {
        Console.ReadKey();
        return;
    }

    Reserva? reserva = null;

    while (true)
    {
        Console.Write("\nIngrese el ID de la reservación que desea modificar (0 para cancelar): ");

        if (!int.TryParse(Console.ReadLine(), out int idReserva))
        {
            Console.WriteLine("\n❌ Error! Ingrese un número de ID válido.");
            continue;
        }

        if (idReserva == 0)
        {
            Console.Write("\n❌ Editar cancelado.");
            Console.ReadKey();
            return;
        }

        reserva = servicioReservas.BuscarPorId(idReserva);

        if (reserva != null)
        {
            break;
        }

        Console.WriteLine("\n❌ Error! El ID de reservación especificado no existe.");
    }

    Console.Clear();
    Console.WriteLine("\t\n[AULAS DISPONIBLES]");
    ListarAulas();
    Console.WriteLine("\t\n[PROFESORES DISPONIBLES]");
    ListarProfesores();
    Console.WriteLine("--------------------------------------------------\n");
    Console.WriteLine($"\nModificando Reserva ID {reserva.Id}: {reserva.Aula.Nombre} | Prof. {reserva.Profesor.Nombre}");

    int nuevoIdAula = reserva.AulaId;

    while (true)
    {
        Console.Write("\nIngrese el nuevo código de aula (Vacío mantiene el actual): ");
        string entradaAula = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(entradaAula))
        {
            break;
        }

        if (int.TryParse(entradaAula, out int nuevoCodigoAula) && nuevoCodigoAula > 0)
        {
            var aulaEncontrada = servicioReservas.BuscarAulaPorCodigo(nuevoCodigoAula);

            if (aulaEncontrada != null)
            {
                nuevoIdAula = aulaEncontrada.Id;
                break;
            }

            Console.WriteLine("❌ Error! El código de aula ingresado no existe.");
            continue;
        }

        Console.WriteLine("❌ Error! El código debe ser un número mayor a cero.");
    }

    int nuevoIdProfesor = reserva.ProfesorId;

    while (true)
    {
        Console.Write("\nIngrese el nuevo código de profesor (Vacío mantiene el actual): ");
        string entradaProf = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(entradaProf))
        {
            break;
        }

        if (int.TryParse(entradaProf, out int nuevoCodigoProf) && nuevoCodigoProf > 0)
        {
            var profEncontrado = servicioReservas.BuscarProfesorPorCodigo(nuevoCodigoProf);

            if (profEncontrado != null)
            {
                nuevoIdProfesor = profEncontrado.Id;
                break;
            }

            Console.WriteLine("❌ Error! El código de profesor ingresado no existe.");
            continue;
        }

        Console.WriteLine("❌ Error! El código debe ser un número mayor a cero.");
    }

    DateTime nuevaFecha = reserva.Fecha;

    while (true)
    {
        Console.Write("\nIngrese la nueva fecha (AAAA-MM-DD - Vacío mantiene la actual): ");
        string entradaFecha = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(entradaFecha))
        {
            break;
        }

        if (DateTime.TryParse(entradaFecha, out nuevaFecha))
        {
            break;
        }

        Console.WriteLine("❌ Error! Formato de fecha no válido.");
    }

    TimeSpan nuevaHoraInicio = reserva.HoraInicio;
    TimeSpan nuevaHoraFin = reserva.HoraFinalizacion;

    while (true)
    {
        Console.WriteLine("\n--- SELECCIONE EL NUEVO HORARIO (Enter para mantener el actual) ---");
        Console.WriteLine("\n1. 08:00 AM - 10:00 AM");
        Console.WriteLine("2. 10:30 AM - 12:00 PM");
        Console.WriteLine("3. 01:00 PM - 03:00 PM");
        Console.WriteLine("4. 03:30 PM - 05:00 PM");
        Console.WriteLine("5. 05:30 PM - 07:30 PM");
        Console.Write("\nSeleccione una opción (1-5): ");

        string opcionHora = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(opcionHora))
        {
            break;
        }

        if (opcionHora == "1")
        {
            nuevaHoraInicio = new TimeSpan(8, 0, 0);
            nuevaHoraFin = new TimeSpan(10, 0, 0);
            break;
        }
        else if (opcionHora == "2")
        {
            nuevaHoraInicio = new TimeSpan(10, 30, 0);
            nuevaHoraFin = new TimeSpan(12, 0, 0);
            break;
        }
        else if (opcionHora == "3")
        {
            nuevaHoraInicio = new TimeSpan(13, 0, 0);
            nuevaHoraFin = new TimeSpan(15, 0, 0);
            break;
        }
        else if (opcionHora == "4")
        {
            nuevaHoraInicio = new TimeSpan(15, 30, 0);
            nuevaHoraFin = new TimeSpan(17, 0, 0);
            break;
        }
        else if (opcionHora == "5")
        {
            nuevaHoraInicio = new TimeSpan(17, 30, 0);
            nuevaHoraFin = new TimeSpan(19, 30, 0);
            break;
        }
        else
        {
            Console.WriteLine("\n❌ Error! Opción de horario no válida.");
        }
    }

    bool aulaOcupada = servicioReservas.AulaOcupada(
        nuevoIdAula,
        nuevaFecha,
        nuevaHoraInicio,
        nuevaHoraFin,
        reserva.Id);

    if (aulaOcupada)
    {
        Console.WriteLine("\n❌ Error! El aula ya se encuentra reservada en esa fecha y horario.");
        Console.ReadKey();
        return;
    }

    servicioReservas.Editar(
        reserva.Id,
        nuevoIdAula,
        nuevoIdProfesor,
        nuevaFecha,
        nuevaHoraInicio,
        nuevaHoraFin);

    Console.WriteLine("\n✅ ¡Reservación modificada correctamente!");
    Console.ReadKey();
}

void EliminarReservacion()
{
    if (!servicioReservas.HayReservas())
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t-- ELIMINAR RESERVACIÓN --\n");
        ListarReservaciones();
        Console.ReadKey();
        return;
    }

    Reserva? reserva = null;

    while (reserva == null)
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t--- ELIMINAR RESERVACIÓN ---\n");
        ListarReservaciones();
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.Write("\nIngrese el ID de la reservación que desea eliminar (0 para cancelar): ");

        if (!int.TryParse(Console.ReadLine(), out int idReserva))
        {
            Console.Write("\n❌ Error! Ingrese un ID válido, intente nuevamente.");
            Console.ReadKey();
            continue;
        }

        if (idReserva == 0)
        {
            return;
        }

        reserva = servicioReservas.BuscarPorId(idReserva);

        if (reserva == null)
        {
            Console.Write("\n❌ Error! El ID no existe, intente nuevamente.");
            Console.ReadKey();
        }
    }

    string confirmacion = "";

    do
    {
        Console.WriteLine("\n--- CONFIRMAR ELIMINACIÓN ---");
        Console.WriteLine($"\nReserva seleccionada -> ID: {reserva.Id} | Aula: {reserva.Aula.Nombre} | Prof: {reserva.Profesor.Nombre} | Fecha: {reserva.Fecha:yyyy-MM-dd}");
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.Write("\n¿Está seguro? (S = Sí / N = No): ");

        confirmacion = Console.ReadLine() ?? "";
        confirmacion = confirmacion.ToUpper();

        if (confirmacion == "S")
        {
            servicioReservas.Eliminar(reserva);
            Console.WriteLine("\n✅ ¡Reservación eliminada exitosamente!");
        }
        else if (confirmacion == "N")
        {
            Console.WriteLine("\n❌ Operación cancelada.");
        }
        else
        {
            Console.Write("\n❌ Error! Opción no válida, intente nuevamente.");
            Console.ReadKey();
            Console.Clear();
            ListarReservaciones();
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

    } while (confirmacion != "S" && confirmacion != "N");

    Console.ReadKey();
}
