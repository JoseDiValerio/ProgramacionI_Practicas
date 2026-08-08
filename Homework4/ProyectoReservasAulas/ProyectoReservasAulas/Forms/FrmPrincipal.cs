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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAulas frm = new FrmAulas();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmProfesores frm = new FrmProfesores();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmReservas frm = new FrmReservas();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
