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

    while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4) {
        Console.Write("\nOpción inválida. Intente nuevamente: ");
    }

    switch (opcion) {
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

        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4) {
            Console.Write("\nOpción inválida. Intente nuevamente: ");
        }

        switch (opcion) {
            
            case 1:
                sistema.RegistrarAula();
                break;

            case 2:
                sistema.EditarAula();
                break;

            case 3:
                sistema.ListarAulas();
                break;
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

        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4) {
            Console.Write("\nOpción inválida. Intente nuevamente: ");
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
        }
    } while (opcion != 4);
}
static void MenuReservas(ReservaAulas sistema) {
    
    int opcion;

    do {
        Console.Clear();

        Console.WriteLine("======== GESTIÓN DE RESERVAS ========");
        Console.WriteLine("\n\t1. Registrar Reserva");
        Console.WriteLine("\t2. Editar Reserva");
        Console.WriteLine("\t3. Listar Reservas");
        Console.WriteLine("\t4. Volver");

        Console.Write("\nSeleccione una opción: ");

        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4) {
            Console.Write("\nOpción inválida. Intente nuevamente: ");
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
        }
    } while (opcion != 4);
}
