// Proyecto Final - Reserva de Aulas
// Jose Daniel Di Valerio 2025-1887
using Classroom_Booking;
using Microsoft.Data.SqlClient;

try
{
    Conexion conexion = new Conexion();

    using (SqlConnection cn = conexion.ObtenerConexion())
    {
        cn.Open();
        Console.WriteLine("Conectado correctamente a MySQL");
    }

    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine("Error al conectar con SQL Server.");
    Console.WriteLine(ex.Message);
    Console.ReadKey();
    return;
}

ClassroomBooking system = new ClassroomBooking();

int option;

do
{
    Console.Clear();

    Console.WriteLine("========================================");
    Console.WriteLine("      CLASSROOM BOOKING SYSTEM");
    Console.WriteLine("========================================");
    Console.WriteLine("\n\t1. Manage Classrooms");
    Console.WriteLine("\t2. Manage Teachers");
    Console.WriteLine("\t3. Manage Reservations");
    Console.WriteLine("\t4. Exit");
    Console.WriteLine("\n========================================");
    Console.Write("\nSelect an option: ");

    while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
    {
        Console.Write("\nInvalid option. Please try again.: ");
    }

    switch (option)
    {
        case 1:
            ClassroomsMenu(system);
            break;

        case 2:
            TeachersMenu(system);
            break;

        case 3:
            MenuReservations(system);
            break;

        case 4:
            Console.WriteLine("\nThank you for using the system.");
            break;
    }
} while (option != 4);

static void ClassroomsMenu(ClassroomBooking system)
{

    int option;

    do
    {
        Console.Clear();

        Console.WriteLine("======== Classroom Management ========");
        Console.WriteLine("\n\t1. Register Classroom");
        Console.WriteLine("\t2. Edit Classroom");
        Console.WriteLine("\t3. List Classrooms");
        Console.WriteLine("\t4. Delete Classroom");
        Console.WriteLine("\t5. Return");

        Console.Write("\nSelect an option: ");

        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
        {
            Console.Write("\nInvalid option. Please try again: ");
        }

        switch (option)
        {

            case 1:
                system.RegisterClassroom();
                break;

            case 2:
                system.EditClassroom();
                break;

            case 3:
                system.ListClassrooms();
                break;

            case 4:
                system.DeleteClassroom();
                break;
        }
    } while (option != 5);
}
static void TeachersMenu(ClassroomBooking system)
{

    int option;

    do
    {
        Console.Clear();

        Console.WriteLine("======== TEACHER MANAGEMENT ========");
        Console.WriteLine("\n\t1. Register Professor");
        Console.WriteLine("\t2. Edit Professor");
        Console.WriteLine("\t3. List Professors");
        Console.WriteLine("\t4. Delete Teacher");
        Console.WriteLine("\t5. Return");

        Console.Write("\nSelect an option: ");

        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
        {
            Console.Write("\nInvalid option. Please try again: ");
        }

        switch (option)
        {

            case 1:
                system.RegisterProfessor();
                break;

            case 2:
                system.EditProfessor();
                break;

            case 3:
                system.ListProfessors();
                break;

            case 4:
                system.DeleteTeacher();
                break;

            case 5:
                break;
        }
    } while (option != 5);
}
static void MenuReservations(ClassroomBooking system)
{

    int option;

    do
    {
        Console.Clear();

        Console.WriteLine("======== RESERVATION MANAGEMENT ========");
        Console.WriteLine("\n\t1. Record Reservation");
        Console.WriteLine("\t2. Edit Reservation");
        Console.WriteLine("\t3. List Reservations");
        Console.WriteLine("\t4. Return");

        Console.Write("\nSelect an option: ");

        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
        {
            Console.Write("\nInvalid option. Please try again: ");
        }

        switch (option)
        {

            case 1:
                system.RegisterReservation();
                break;

            case 2:
                system.EditReservation();
                break;

            case 3:
                system.ListReservations();
                break;
        }
    } while (option != 4);
}
