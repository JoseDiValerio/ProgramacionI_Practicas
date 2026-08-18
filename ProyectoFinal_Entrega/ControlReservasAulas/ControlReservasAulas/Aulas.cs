namespace ControlReservasAulas;

public class Aulas
{
    public static void Registrar()
    {
        Console.Clear();

        Console.WriteLine("=================================");
        Console.WriteLine("          REGISTRAR AULA         ");
        Console.WriteLine("=================================");

        Console.Write("\nCódigo del aula: ");

        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("El código debe ser un número.");
            Console.ReadKey();
            return;
        }

        Console.Write("Nombre del aula: ");
        string nombre = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            Console.ReadKey();
            return;
        }

        Console.Write("Capacidad del aula: ");

        if (!int.TryParse(Console.ReadLine(), out int capacidad))
        {
            Console.WriteLine("La capacidad debe ser un número.");
            Console.ReadKey();
            return;
        }

        if (capacidad <= 0)
        {
            Console.WriteLine("La capacidad debe ser mayor que cero.");
            Console.ReadKey();
            return;
        }

        using (Conexion db = new Conexion())
        {
            Aula? aulaExistente = db.Aulas.FirstOrDefault(a => a.Codigo == codigo || a.Nombre == nombre);

            if (aulaExistente != null)
            {
                Console.WriteLine("\nYa existe un aula con ese código o con ese nombre.");
                Console.ReadKey();
                return;
            }

            Aula aula = new Aula();

            aula.Codigo = codigo;
            aula.Nombre = nombre;
            aula.Capacidad = capacidad;

            db.Aulas.Add(aula);
            db.SaveChanges();
        }

        Console.WriteLine("\nAula registrada correctamente.");
        Console.ReadKey();
    }
    public static void Mostrar()
    {

    }
    public static void Modificar()
    {

    }
    public static void Eliminar()
    {

    }
}