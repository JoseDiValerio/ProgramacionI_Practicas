//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

using ProyectoReservasAulas.Data;
using ProyectoReservasAulas.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoReservasAulas.Forms
{
    public partial class FrmAulas : Form
    {
        private int idAula = 0;

        public FrmAulas()
        {
            InitializeComponent();
        }

        private void FrmAulas_Load(object sender, EventArgs e)
        {
            CargarAulas();
        }

        // Metodos
        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            nudCapacidad.Value = 1;
            txtBuscar.Clear();
            idAula = 0;
            txtCodigo.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show(
                    "Debe escribir el código del aula.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCodigo.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe escribir el nombre del aula.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();

                return false;
            }

            if (nudCapacidad.Value <= 0)
            {
                MessageBox.Show(
                    "La capacidad debe ser mayor que cero.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void CargarAulas()
        {
            using (ControlReservasContext db = new ControlReservasContext())
            {
                dgvAulas.DataSource = db.Aulas
                    .OrderBy(a => a.Codigo)
                    .Select(a => new
                    {
                        a.Id,
                        a.Codigo,
                        a.Nombre,
                        a.Capacidad
                    })
                    .ToList();
            }

            dgvAulas.Columns["Id"].Visible = false;
        }

        // Botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            using (ControlReservasContext db = new ControlReservasContext())
            {
                // Verificar si el código ya existe
                bool existe = db.Aulas.Any(a => a.Codigo == txtCodigo.Text.Trim());

                if (existe)
                {
                    MessageBox.Show(
                        "Ya existe un aula con ese código.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCodigo.Focus();

                    return;
                }

                Aula aula = new Aula();

                aula.Codigo = txtCodigo.Text.Trim();

                aula.Nombre = txtNombre.Text.Trim();

                aula.Capacidad = (int)nudCapacidad.Value;

                db.Aulas.Add(aula);

                db.SaveChanges();

                MessageBox.Show(
                    "Aula registrada correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarAulas();

                Limpiar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (ControlReservasContext db = new ControlReservasContext())
            {
                string texto = txtBuscar.Text.Trim();

                dgvAulas.DataSource = db.Aulas
                    .Where(a =>
                        a.Codigo.Contains(texto) ||
                        a.Nombre.Contains(texto))
                    .Select(a => new
                    {
                        a.Id,
                        a.Codigo,
                        a.Nombre,
                        a.Capacidad
                    })
                    .ToList();
            }

            dgvAulas.Columns["Id"].Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvAulas.Rows[e.RowIndex];

            idAula = Convert.ToInt32(fila.Cells["Id"].Value);

            txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();

            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();

            nudCapacidad.Value = Convert.ToDecimal(fila.Cells["Capacidad"].Value);
        }
    }
}
