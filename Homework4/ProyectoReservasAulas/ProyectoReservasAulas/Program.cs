using ProyectoReservasAulas;
using ProyectoReservasAulas.Forms;

namespace ProyectoReservasAulas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPrincipal());
        }
    }
}