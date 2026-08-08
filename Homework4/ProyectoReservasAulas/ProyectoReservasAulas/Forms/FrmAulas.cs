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
        private bool editando = false;

        public FrmAulas()
        {
            InitializeComponent();
        }

        private void FrmAulas_Load(object sender, EventArgs e)
        {
            CargarAulas();
            BloquearCampos();
            btnGuardar.Enabled = false;
            timer1.Start();
        }

        // METODOS PRINCIPALES

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtBuscar.Clear();

            nudCapacidad.Value = 1;

            idAula = 0;
            editando = false;

            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            nudCapacidad.Enabled = false;

            btnGuardar.Enabled = false;

            txtCodigo.Focus();
        }

        private bool Validar()
        {
            txtCodigo.Text = txtCodigo.Text.Trim();
            txtNombre.Text = txtNombre.Text.Trim();

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

        private void HabilitarCampos()
        {
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            nudCapacidad.Enabled = true;
        }

        private void BloquearCampos()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            nudCapacidad.Enabled = false;
        }

        // BOTONES PRINCIPALES

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();

            nudCapacidad.Value = 1;

            idAula = 0;
            editando = false;

            HabilitarCampos();

            btnGuardar.Enabled = true;

            txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            using (ControlReservasContext db = new ControlReservasContext())
            {
                if (!editando)
                {
                    // Verificar si el código ya existe
                    bool existe = db.Aulas.Any(
                        a => a.Codigo == txtCodigo.Text.Trim());

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

                    // Crear una nueva aula
                    Aula aula = new Aula();

                    aula.Codigo = txtCodigo.Text.Trim();
                    aula.Nombre = txtNombre.Text.Trim();
                    aula.Capacidad = (int)nudCapacidad.Value;

                    // Agregar el aula
                    db.Aulas.Add(aula);

                    // Guardar en SQL Server
                    db.SaveChanges();

                    MessageBox.Show(
                        "Aula registrada correctamente.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    // Verificar que no exista otro aula con ese código
                    bool existe = db.Aulas.Any(
                        a => a.Codigo == txtCodigo.Text.Trim()
                        && a.Id != idAula);

                    if (existe)
                    {
                        MessageBox.Show(
                            "Ya existe otra aula con ese código.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtCodigo.Focus();

                        return;
                    }

                    // Buscar el aula que estamos editando
                    Aula? aula = db.Aulas.Find(idAula);

                    if (aula == null)
                    {
                        MessageBox.Show(
                            "No se encontró el aula.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    // Modificar los datos
                    aula.Codigo = txtCodigo.Text.Trim();
                    aula.Nombre = txtNombre.Text.Trim();
                    aula.Capacidad = (int)nudCapacidad.Value;

                    // Guardar los cambios
                    db.SaveChanges();

                    MessageBox.Show(
                        "Aula modificada correctamente.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                CargarAulas();
                Limpiar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idAula == 0)
            {
                MessageBox.Show(
                    "Seleccione un aula para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            editando = true;

            HabilitarCampos();

            btnGuardar.Enabled = true;

            txtCodigo.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAula == 0)
            {
                MessageBox.Show(
                    "Seleccione un aula.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar esta aula?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            using (ControlReservasContext db = new ControlReservasContext())
            {
                Aula? aula = db.Aulas.Find(idAula);

                if (aula == null)
                {
                    MessageBox.Show("No se encontró el aula.");
                    return;
                }

                db.Aulas.Remove(aula);

                db.SaveChanges();

                MessageBox.Show(
                    "Aula eliminada correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarAulas();

                Limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // VISTA DE AULAS

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //btnBuscar.PerformClick();

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

        private void dgvAulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvAulas.Rows[e.RowIndex];

            idAula = Convert.ToInt32(fila.Cells["Id"].Value);

            txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();

            nudCapacidad.Value = Convert.ToDecimal(fila.Cells["Capacidad"].Value);

            // No estamos editando todavía
            editando = false;

            // Los campos solamente sirven para visualizar
            BloquearCampos();

            // Guardar se activa únicamente al presionar Editar
            btnGuardar.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

            lblHora.Text = "Hora: " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
