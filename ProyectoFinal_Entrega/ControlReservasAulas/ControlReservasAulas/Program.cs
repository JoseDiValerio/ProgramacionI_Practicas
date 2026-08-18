using ControlReservasAulas;

var db = new Conexion();

if (db.Database.CanConnect())
{
    Console.WriteLine("¡Conexión exitosa! Todo está bien configurado.");
}
else
{
    Console.WriteLine("Error: No se pudo conectar a la base de datos.");
}
Console.ReadKey();

int opcion;

do
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("   CONTROL DE RESERVAS DE AULAS  ");
    Console.WriteLine("=================================");
    Console.WriteLine("\n1. Registrar aula");
    Console.WriteLine("2. Registrar profesor");
    Console.WriteLine("3. Registrar reserva");
    Console.WriteLine("4. Mostrar información");
    Console.WriteLine("5. Modificar información");
    Console.WriteLine("6. Eliminar información");
    Console.WriteLine("7. Salir");
    Console.Write("\nSeleccione una opción: ");

    int.TryParse(Console.ReadLine(), out opcion);

    switch (opcion)
    {
        case 1:
            Aulas.Registrar();
            break;

        case 2:
            //Profesores.Registrar();
            break;

        case 3:
            //Reservas.Registrar();
            break;

        case 4:
            // Menú mostrar
            break;

        case 5:
            // Menú modificar
            break;

        case 6:
            // Menú eliminar
            break;

        case 7:
            Console.WriteLine("Saliendo de la aplicacion.");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            Console.ReadKey();
            break;
    }
} while (opcion != 7);