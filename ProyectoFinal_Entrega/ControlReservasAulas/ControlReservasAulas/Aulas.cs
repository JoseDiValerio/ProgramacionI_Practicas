namespace ControlReservasAulas;

public class Aulas
{
    /*public static void Registrar()
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
    }*/

    public static void Registrar()
    {
        Console.Clear();
        
        string opcionSalir = "";
        do
        {

            Console.WriteLine("=================================");
            Console.WriteLine("          REGISTRAR AULA         ");
            Console.WriteLine("=================================");

            int codigo = 0;
            string nombre = "";
            int capacidad = 0;

            // 1. BUCLE PARA EL CÓDIGO
            while (true)
            {
                Console.Write("\nCódigo del aula: ");
                if (int.TryParse(Console.ReadLine(), out codigo))
                {
                    break; // Si es un número válido, sale del bucle y continúa abajo
                }
                Console.WriteLine("❌ El código debe ser un número entero. Inténtalo de nuevo.");
            }

            // 2. BUCLE PARA EL NOMBRE
            while (true)
            {
                Console.Write("Nombre del aula: ");
                nombre = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    break; // Si no está vacío, sale del bucle
                }
                Console.WriteLine("❌ El nombre no puede estar vacío. Inténtalo de nuevo.");
            }

            // 3. BUCLE PARA LA CAPACIDAD
            while (true)
            {
                Console.Write("Capacidad del aula: ");
                if (int.TryParse(Console.ReadLine(), out capacidad) && capacidad > 0)
                {
                    break; // Si es un número válido Y mayor a cero, sale del bucle
                }
                Console.WriteLine("❌ La capacidad debe ser un número mayor que cero. Inténtalo de nuevo.");
            }

            // 4. PROCESO DE BASE DE DATOS
            using (Conexion db = new Conexion())
            {
                // Validación de duplicados usando las variables limpias que conseguimos arriba
                Aula? aulaExistente = db.Aulas.FirstOrDefault(a => a.Codigo == codigo || a.Nombre == nombre);

                if (aulaExistente != null)
                {
                    Console.WriteLine("\n❌ Ya existe un aula con ese código o con ese nombre en la base de datos.");
                    Console.ReadKey();
                    return; // Aquí sí usamos return porque el proceso falló por duplicado en la BD
                }

                // Si todo está bien, guardamos
                Aula aula = new Aula();
                aula.Codigo = codigo;
                aula.Nombre = nombre;
                aula.Capacidad = capacidad;

                db.Aulas.Add(aula);
                db.SaveChanges();
            }

            Console.WriteLine("\n✅ Aula registrada correctamente.");
            Console.ReadKey();

            Console.WriteLine("\n-------------------------------------------------");
            Console.Write("¿Deseas registrar otra aula? (S/N): ");
            opcionSalir = Console.ReadLine() ?? "";

        } while (opcionSalir.ToLower() == "s");
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