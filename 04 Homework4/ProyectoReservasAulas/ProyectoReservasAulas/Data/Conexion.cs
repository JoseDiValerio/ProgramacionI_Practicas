using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoReservasAulas.Data
{
    public static class Conexion
    {
        public static bool ProbarConexion()
        {
            try
            {
                using (ControlReservasContext db = new ControlReservasContext())
                {
                    db.Database.CanConnect();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}