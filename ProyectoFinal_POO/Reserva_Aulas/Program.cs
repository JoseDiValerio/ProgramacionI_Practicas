// Proyecto Final - Reserva de Aulas
// Jose Daniel Di Valerio 2025-1887
using Reserva_Aulas;

ReservaAulas sistema = new ReservaAulas();

int opcion;

do {
    Console.Clear();

    Console.WriteLine("========================================");
    Console.WriteLine("      SISTEMA DE RESERVAS DE AULAS");
    Console.WriteLine("========================================");
    Console.WriteLine("\n\t1. Gestionar Aulas");
    Console.WriteLine("\t2. Gestionar Profesores");
    Console.WriteLine("\t3. Gestionar Reservas");
    Console.WriteLine("\t4. Salir");
    Console.WriteLine("\n========================================");
    Console.Write("\nSeleccione una opción: ");

    while (!int.TryParse(Console.ReadLine(), out opcion)) {
        Console.Write("Opción inválida. Intente nuevamente: ");
    }

    switch (opcion)
    {
        case 1:
            MenuAulas(sistema);
            break;

        case 2:
            MenuProfesores(sistema);
            break;

        case 3:
            MenuReservas(sistema);
            break;

        case 4:
            Console.WriteLine("\nGracias por utilizar el sistema.");
            break;

        default:
            Console.WriteLine("\nOpción incorrecta.");
            Console.ReadKey();
            break;
    }

} while (opcion != 4);

static void MenuAulas(ReservaAulas sistema) {
    
    int opcion;

    do {
        Console.Clear();

        Console.WriteLine("======== GESTIÓN DE AULAS ========");
        Console.WriteLine("\n\t1. Registrar Aula");
        Console.WriteLine("\t2. Editar Aula");
        Console.WriteLine("\t3. Listar Aulas");
        Console.WriteLine("\t4. Volver");

        Console.Write("\nSeleccione una opción: ");

        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.Write("Opción inválida. Intente nuevamente: ");
        }

        switch (opcion)
        {
            case 1:
                sistema.RegistrarAula();
                break;

            case 2:
                sistema.EditarAula();
                break;

            case 3:
                sistema.ListarAulas();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("Opción incorrecta.");
                break;
        }

        if (opcion != 4)
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

    } while (opcion != 4);
}

static void MenuProfesores(ReservaAulas sistema) {
    
    int opcion;

    do {
        Console.Clear();

        Console.WriteLine("======== GESTIÓN DE PROFESORES ========");
        Console.WriteLine("\n\t1. Registrar Profesor");
        Console.WriteLine("\t2. Editar Profesor");
        Console.WriteLine("\t3. Listar Profesores");
        Console.WriteLine("\t4. Volver");

        Console.Write("\nSeleccione una opción: ");

        while (!int.TryParse(Console.ReadLine(), out opcion)) {
            Console.Write("Opción inválida. Intente nuevamente: ");
        }

        switch (opcion) {
            
            case 1:
                sistema.RegistrarProfesor();
                break;

            case 2:
                sistema.EditarProfesor();
                break;

            case 3:
                sistema.ListarProfesores();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("Opción incorrecta.");
                break;
        }

        if (opcion != 4) {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

    } while (opcion != 4);
}

static void MenuReservas(ReservaAulas sistema) {
    
    int opcion;

    do {
        
        Console.Clear();

        Console.WriteLine("======== GESTIÓN DE RESERVAS ========");
        Console.WriteLine("1. Registrar Reserva");
        Console.WriteLine("2. Editar Reserva");
        Console.WriteLine("3. Listar Reservas");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");

        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.Write("Opción inválida. Intente nuevamente: ");
        }

        switch (opcion) {
            
            case 1:
                sistema.RegistrarReserva();
                break;

            case 2:
                sistema.EditarReserva();
                break;

            case 3:
                sistema.ListarReservas();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("Opción incorrecta.");
                break;
        }

        if (opcion != 4) {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

    } while (opcion != 4);
}

