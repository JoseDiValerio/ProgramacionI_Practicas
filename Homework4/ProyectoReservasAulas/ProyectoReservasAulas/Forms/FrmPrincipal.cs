using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProyectoReservasAulas.Data;

namespace ProyectoReservasAulas.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (Conexion.ProbarConexion())
            {
                MessageBox.Show(
                    "Conexión realizada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // BOTONES
        private void btnAulas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAulas frm = new FrmAulas();
            frm.ShowDialog();
            this.Show();
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmProfesores frm = new FrmProfesores();
            frm.ShowDialog();
            this.Show();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmReservas frm = new FrmReservas();
            frm.ShowDialog();
            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;

            respuesta = MessageBox.Show(
                "¿Desea salir del sistema?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
