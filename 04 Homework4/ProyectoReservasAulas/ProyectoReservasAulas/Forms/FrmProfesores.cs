using ProyectoReservasAulas.Data;
using ProyectoReservasAulas.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoReservasAulas.Forms
{
    public partial class FrmProfesores : Form
    {
        private int idProfesor = 0;
        private bool editando = false;

        public FrmProfesores()
        {
            InitializeComponent();
        }

        private void FrmProfesores_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            BloquearCampos();
            btnGuardar.Enabled = false;
            timer1.Start();
        }

        // MOTODOS PRINCIPALES

        private void Limpiar()
        {
            txtNombre.Clear();
            txtMateria.Clear();
            txtCorreo.Clear();
            txtBuscar.Clear();

            idProfesor = 0;

            editando = false;
            txtNombre.Enabled = false;
            txtMateria.Enabled = false;
            txtCorreo.Enabled = false;
            btnGuardar.Enabled = false;

            txtNombre.Focus();
        }

        private void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtMateria.Enabled = true;
            txtCorreo.Enabled = true;
        }

        private void BloquearCampos()
        {
            txtNombre.Enabled = false;
            txtMateria.Enabled = false;
            txtCorreo.Enabled = false;
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Debe escribir el nombre del profesor.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMateria.Text))
            {
                MessageBox.Show(
                    "Debe escribir la materia del profesor.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMateria.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show(
                    "Debe escribir el correo del profesor.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }

            if (!txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show(
                    "El correo no tiene un formato válido.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }

            return true;
        }

        private void CargarProfesores()
        {
            using (ControlReservasContext db = new ControlReservasContext())
            {
                dgvProfesores.DataSource = db.Profesores
                    .OrderBy(p => p.Nombre)
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Materia,
                        p.Correo
                    })
                    .ToList();
            }

            dgvProfesores.Columns["Id"].Visible = false;
        }

        // BOTONES
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtMateria.Clear();
            txtCorreo.Clear();

            idProfesor = 0;
            editando = false;

            HabilitarCampos();

            btnGuardar.Enabled = true;

            txtNombre.Focus();
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
                    bool existe = db.Profesores.Any(
                        p => p.Correo == txtCorreo.Text.Trim());

                    if (existe)
                    {
                        MessageBox.Show(
                            "Ya existe un profesor con ese correo.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtCorreo.Focus();

                        return;
                    }

                    Profesor profesor = new Profesor();
                    profesor.Nombre = txtNombre.Text.Trim();
                    profesor.Materia = txtMateria.Text.Trim();
                    profesor.Correo = txtCorreo.Text.Trim();
                    db.Profesores.Add(profesor);
                    db.SaveChanges();

                    MessageBox.Show(
                        "Profesor registrado correctamente.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    bool existe = db.Profesores.Any(
                        p => p.Correo == txtCorreo.Text.Trim()
                        && p.Id != idProfesor);

                    if (existe)
                    {
                        MessageBox.Show(
                            "Ya existe otro profesor con ese correo.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtCorreo.Focus();

                        return;
                    }

                    Profesor? profesor = db.Profesores.Find(idProfesor);

                    if (profesor == null)
                    {
                        MessageBox.Show(
                            "No se encontró el profesor.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    profesor.Nombre = txtNombre.Text.Trim();
                    profesor.Materia = txtMateria.Text.Trim();
                    profesor.Correo = txtCorreo.Text.Trim();
                    db.SaveChanges();

                    MessageBox.Show(
                        "Profesor modificado correctamente.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                CargarProfesores();

                Limpiar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProfesor == 0)
            {
                MessageBox.Show(
                    "Seleccione un profesor para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            editando = true;

            HabilitarCampos();

            btnGuardar.Enabled = true;

            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProfesor == 0)
            {
                MessageBox.Show(
                    "Seleccione un profesor.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este profesor?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            using (ControlReservasContext db = new ControlReservasContext())
            {
                Profesor? profesor = db.Profesores.Find(idProfesor);

                if (profesor == null)
                {
                    MessageBox.Show(
                        "No se encontró el profesor.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                db.Profesores.Remove(profesor);

                db.SaveChanges();

                MessageBox.Show(
                    "Profesor eliminado correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarProfesores();

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

        // VISTA DE PROFESORES

        private void dgvProfesores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvProfesores.Rows[e.RowIndex];

            idProfesor = Convert.ToInt32(
                fila.Cells["Id"].Value);

            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtMateria.Text = fila.Cells["Materia"].Value.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value.ToString();

            // Solo visualizar
            editando = false;

            BloquearCampos();

            btnGuardar.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            using (ControlReservasContext db = new ControlReservasContext())
            {
                string texto = txtBuscar.Text.Trim();

                dgvProfesores.DataSource = db.Profesores
                    .Where(p =>
                        p.Nombre.Contains(texto) ||
                        p.Materia.Contains(texto) ||
                        p.Correo.Contains(texto))
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Materia,
                        p.Correo
                    })
                    .ToList();
            }

            dgvProfesores.Columns["Id"].Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

            lblHora.Text = "Hora: " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
