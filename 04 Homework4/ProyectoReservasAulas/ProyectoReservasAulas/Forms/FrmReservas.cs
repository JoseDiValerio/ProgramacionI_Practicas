using ProyectoReservasAulas.Data;
using ProyectoReservasAulas.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoReservasAulas.Forms
{
    public partial class FrmReservas : Form
    {
        private int idReserva = 0;
        private bool editando = false;

        public FrmReservas()
        {
            InitializeComponent();
        }

        private void FrmReservas_Load(object sender, EventArgs e)
        {
            CargarAulas();
            CargarProfesores();
            CargarReservas();

            BloquearCampos();

            btnGuardar.Enabled = false;
        }

        // METODOS PRINCIPALES

        private void CargarAulas()
        {
            using (ControlReservasContext db = new ControlReservasContext())
            {
                cmbAula.DataSource = db.Aulas
                    .OrderBy(a => a.Codigo)
                    .ToList();

                cmbAula.DisplayMember = "Codigo";
                cmbAula.ValueMember = "Id";
            }
        }
        private void CargarProfesores()
        {
            using (ControlReservasContext db = new ControlReservasContext())
            {
                cmbProfesor.DataSource = db.Profesores
                    .OrderBy(p => p.Nombre)
                    .ThenBy(p => p.Materia)
                    .Select(p => new
                    {
                        p.Id,
                        NombreMateria = p.Nombre + " - " + p.Materia
                    })
                    .ToList();

                cmbProfesor.DisplayMember = "NombreMateria";
                cmbProfesor.ValueMember = "Id";
            }
        }

        private void CargarReservas()
        {
            using (ControlReservasContext db = new ControlReservasContext())
            {
                var reservas = db.Reservas
                    .OrderBy(r => r.Fecha)
                    .ThenBy(r => r.HoraInicio)
                    .Select(r => new
                    {
                        r.Id,
                        Aula = r.Aula.Codigo,
                        Profesor = r.Profesor.Nombre,
                        Materia = r.Profesor.Materia,
                        Correo = r.Profesor.Correo,
                        r.Fecha,
                        r.HoraInicio,
                        r.HoraFin
                    })
                    .ToList();

                dgvReservas.DataSource = reservas
                    .Select(r => new
                    {
                        r.Id,
                        r.Aula,
                        r.Profesor,
                        r.Materia,
                        r.Correo,
                        r.Fecha,
                        HoraInicio = DateTime.Today.Add(r.HoraInicio).ToString("hh:mm tt"),
                        HoraFin = DateTime.Today.Add(r.HoraFin).ToString("hh:mm tt")
                    })
                    .ToList();
            }

            dgvReservas.Columns["Id"].Visible = false;
        }

        private void HabilitarCampos()
        {
            cmbAula.Enabled = true;
            cmbProfesor.Enabled = true;
            dtpFecha.Enabled = true;
            dtpHoraInicio.Enabled = true;
            dtpHoraFin.Enabled = true;
        }

        private void BloquearCampos()
        {
            cmbAula.Enabled = false;
            cmbProfesor.Enabled = false;
            dtpFecha.Enabled = false;
            dtpHoraInicio.Enabled = false;
            dtpHoraFin.Enabled = false;
        }

        private bool Validar()
        {
            if (cmbAula.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un aula.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbAula.Focus();

                return false;
            }

            if (cmbProfesor.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un profesor.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbProfesor.Focus();

                return false;
            }

            if (dtpHoraFin.Value.TimeOfDay <= dtpHoraInicio.Value.TimeOfDay)
            {
                MessageBox.Show(
                    "La hora de finalización debe ser mayor que la hora de inicio.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpHoraFin.Focus();

                return false;
            }

            return true;
        }

        private void Limpiar()
        {
            cmbAula.SelectedIndex = -1;
            cmbProfesor.SelectedIndex = -1;

            dtpFecha.Value = DateTime.Today;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFin.Value = DateTime.Today.AddHours(10);

            idReserva = 0;
            editando = false;

            BloquearCampos();

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            cmbAula.Focus();
        }

        // BOTONES

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editando = false;
            idReserva = 0;

            HabilitarCampos();

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            cmbAula.SelectedIndex = -1;
            cmbProfesor.SelectedIndex = -1;

            dtpFecha.Value = DateTime.Today;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFin.Value = DateTime.Today.AddHours(10);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            int aulaId = Convert.ToInt32(cmbAula.SelectedValue);
            int profesorId = Convert.ToInt32(cmbProfesor.SelectedValue);

            DateTime fecha = dtpFecha.Value.Date;

            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = dtpHoraFin.Value.TimeOfDay;

            using (ControlReservasContext db = new ControlReservasContext())
            {
                // Buscar el correo del profesor seleccionado
                string correoProfesor = db.Profesores
                    .Where(p => p.Id == profesorId)
                    .Select(p => p.Correo)
                    .First();

                // Verificar si el aula está ocupada
                bool aulaOcupada = db.Reservas.Any(r =>
                    r.AulaId == aulaId &&
                    r.Fecha >= fecha &&
                    r.Fecha < fecha.AddDays(1) &&
                    r.HoraInicio < horaFin &&
                    r.HoraFin > horaInicio &&
                    r.Id != idReserva);

                // Verificar si el profesor está ocupado
                bool profesorOcupado = db.Reservas.Any(r =>
                    r.Profesor.Correo == correoProfesor &&
                    r.Fecha >= fecha &&
                    r.Fecha < fecha.AddDays(1) &&
                    r.HoraInicio < horaFin &&
                    r.HoraFin > horaInicio &&
                    r.Id != idReserva);

                if (aulaOcupada)
                {
                    MessageBox.Show(
                        "El aula ya está reservada en ese horario.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (profesorOcupado)
                {
                    MessageBox.Show(
                        "El profesor ya tiene una reserva en ese horario.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (editando == false)
                {
                    Reserva reserva = new Reserva();

                    reserva.AulaId = aulaId;
                    reserva.ProfesorId = profesorId;
                    reserva.Fecha = fecha;
                    reserva.HoraInicio = horaInicio;
                    reserva.HoraFin = horaFin;

                    db.Reservas.Add(reserva);

                    db.SaveChanges();

                    MessageBox.Show(
                        "Reserva registrada correctamente.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    Reserva reserva = db.Reservas.Find(idReserva);

                    if (reserva != null)
                    {
                        reserva.AulaId = aulaId;
                        reserva.ProfesorId = profesorId;
                        reserva.Fecha = fecha;
                        reserva.HoraInicio = horaInicio;
                        reserva.HoraFin = horaFin;

                        db.SaveChanges();

                        MessageBox.Show(
                            "Reserva modificada correctamente.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }

            CargarReservas();
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idReserva == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar una reserva.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            editando = true;

            HabilitarCampos();

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idReserva == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar una reserva.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta reserva?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            using (ControlReservasContext db = new ControlReservasContext())
            {
                Reserva reserva = db.Reservas.Find(idReserva);

                if (reserva != null)
                {
                    db.Reservas.Remove(reserva);

                    db.SaveChanges();

                    MessageBox.Show(
                        "Reserva eliminada correctamente.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            CargarReservas();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            using (ControlReservasContext db = new ControlReservasContext())
            {
                var reservas = db.Reservas
                    .Where(r =>
                        r.Aula.Codigo.Contains(texto) ||
                        r.Profesor.Nombre.Contains(texto))
                    .OrderBy(r => r.Fecha)
                    .ThenBy(r => r.HoraInicio)
                    .Select(r => new
                    {
                        r.Id,
                        Aula = r.Aula.Codigo,
                        Profesor = r.Profesor.Nombre,
                        Materia = r.Profesor.Materia,
                        Correo = r.Profesor.Correo,
                        r.Fecha,
                        r.HoraInicio,
                        r.HoraFin
                    })
                    .ToList();

                dgvReservas.DataSource = reservas
                    .Select(r => new
                    {
                        r.Id,
                        r.Aula,
                        r.Profesor,
                        r.Materia,
                        r.Correo,
                        r.Fecha,
                        HoraInicio = DateTime.Today.Add(r.HoraInicio).ToString("hh:mm tt"),
                        HoraFin = DateTime.Today.Add(r.HoraFin).ToString("hh:mm tt")
                    })
                    .ToList();
            }
            dgvReservas.Columns["Id"].Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

            lblHora.Text = "Hora: " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        // VISTA DE RESERVAS

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            idReserva = Convert.ToInt32(
                dgvReservas.Rows[e.RowIndex].Cells["Id"].Value
            );

            using (ControlReservasContext db = new ControlReservasContext())
            {
                Reserva reserva = db.Reservas.Find(idReserva);

                if (reserva != null)
                {
                    cmbAula.SelectedValue = reserva.AulaId;
                    cmbProfesor.SelectedValue = reserva.ProfesorId;

                    dtpFecha.Value = reserva.Fecha;
                    dtpHoraInicio.Value = DateTime.Today.Add(reserva.HoraInicio);
                    dtpHoraFin.Value = DateTime.Today.Add(reserva.HoraFin);

                    BloquearCampos();

                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;

                    editando = true;
                }
            }
        }
    }
}
