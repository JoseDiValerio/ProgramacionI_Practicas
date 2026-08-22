# ControlRegistroAulas

Proyecto de consola en C# con .NET 10, Entity Framework Core y SQL Server.

## Las 3 capas

- ControlRegistroAulas.Presentacion
  - Menús
  - Console.WriteLine
  - Console.ReadLine
  - Validaciones
  - Interacción con el usuario

- ControlRegistroAulas.Negocio
  - ServicioAulas
  - ServicioProfesores
  - ServicioReservas
  - Operaciones y reglas sencillas del sistema

- ServicioBaseDatos
  - Creación inicial de la base de datos

- ControlRegistroAulas.Datos
  - Modelos
  - AppDbContext
  - Entity Framework Core
  - Conexión a SQL Server

## Funciones

### Aulas
- Registrar
- Editar
- Listar
- Eliminar

### Profesores
- Registrar
- Editar
- Listar
- Eliminar

### Reservas
- Registrar
- Editar
- Listar
- Eliminar
- Validar disponibilidad del aula

## Antes de ejecutar

El proyecto conserva la misma instancia de SQL Server del proyecto original:

Server=DESKTOP-E9V3MBP\SQLEXPRESS

La base de datos utilizada ahora es:

ControlRegistroAulas

Si tu instancia de SQL Server tiene otro nombre, cambia solamente la conexión en:

ControlRegistroAulas.Datos/AppDbContext.cs

## Crear la base de datos

No es necesario crear manualmente las tablas.

Al iniciar el programa se ejecuta:

db.Database.EnsureCreated();

Entity Framework creará la base de datos y las tablas si todavía no existen.

## Ejecutar

Desde la carpeta de la solución:

dotnet restore

dotnet run --project ControlRegistroAulas.Presentacion

También se puede abrir:

ControlRegistroAulas.sln

en Visual Studio.

## Importante

El proyecto fue mantenido deliberadamente con un nivel de programación principiante:

- while
- if
- switch
- List
- TryParse
- using
- clases sencillas
- métodos sencillos
- Entity Framework básico

No se agregaron API, servidor, repositorios, interfaces, DTO, patrones avanzados ni arquitectura innecesariamente compleja.
