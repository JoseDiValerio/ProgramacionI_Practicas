using Microsoft.Data.SqlClient;
public class Conexion
{
    private string cadenaConexion =
    "Server=DESKTOP-E9V3MBP\\SQLEXPRESS;Database=ClassroomReservations;Trusted_Connection=True;TrustServerCertificate=True;";

    public SqlConnection ObtenerConexion()
    {
        return new SqlConnection(cadenaConexion);
    }
}