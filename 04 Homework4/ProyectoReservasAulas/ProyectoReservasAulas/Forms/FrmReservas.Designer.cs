namespace ProyectoReservasAulas.Forms
{
    partial class FrmReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblAula = new Label();
            cmbAula = new ComboBox();
            lblProfesor = new Label();
            cmbProfesor = new ComboBox();
            lblFechaReserva = new Label();
            dtpFecha = new DateTimePicker();
            lblHoraInicio = new Label();
            dtpHoraInicio = new DateTimePicker();
            lblHoraFin = new Label();
            dtpHoraFin = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            lblFecha = new Label();
            lblHora = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            lblBusqueda = new Label();
            txtBuscar = new TextBox();
            dgvReservas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            SuspendLayout();
            // 
            // lblAula
            // 
            lblAula.AutoSize = true;
            lblAula.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAula.Location = new Point(41, 51);
            lblAula.Name = "lblAula";
            lblAula.Size = new Size(46, 21);
            lblAula.TabIndex = 0;
            lblAula.Text = "Aula:";
            // 
            // cmbAula
            // 
            cmbAula.FormattingEnabled = true;
            cmbAula.Location = new Point(145, 49);
            cmbAula.Name = "cmbAula";
            cmbAula.Size = new Size(155, 23);
            cmbAula.TabIndex = 1;
            // 
            // lblProfesor
            // 
            lblProfesor.AutoSize = true;
            lblProfesor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfesor.Location = new Point(41, 90);
            lblProfesor.Name = "lblProfesor";
            lblProfesor.Size = new Size(78, 21);
            lblProfesor.TabIndex = 2;
            lblProfesor.Text = "Profesor:";
            // 
            // cmbProfesor
            // 
            cmbProfesor.FormattingEnabled = true;
            cmbProfesor.Location = new Point(145, 92);
            cmbProfesor.Name = "cmbProfesor";
            cmbProfesor.Size = new Size(250, 23);
            cmbProfesor.TabIndex = 3;
            // 
            // lblFechaReserva
            // 
            lblFechaReserva.AutoSize = true;
            lblFechaReserva.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFechaReserva.Location = new Point(41, 135);
            lblFechaReserva.Name = "lblFechaReserva";
            lblFechaReserva.Size = new Size(56, 21);
            lblFechaReserva.TabIndex = 4;
            lblFechaReserva.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(145, 135);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 5;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblHoraInicio.Location = new Point(41, 181);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(94, 21);
            lblHoraInicio.TabIndex = 6;
            lblHoraInicio.Text = "Hora Inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(145, 181);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(200, 23);
            dtpHoraInicio.TabIndex = 7;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblHoraFin.Location = new Point(41, 230);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(75, 21);
            lblHoraFin.TabIndex = 8;
            lblHoraFin.Text = "Hora Fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(145, 230);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(200, 23);
            dtpHoraFin.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(596, 29);
            label2.Name = "label2";
            label2.Size = new Size(244, 30);
            label2.TabIndex = 19;
            label2.Text = "REGISTRO DE RESERVAS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(478, 69);
            label1.Name = "label1";
            label1.Size = new Size(481, 42);
            label1.TabIndex = 20;
            label1.Text = "Administra las reservas del centro; permitiendo registrar,\r\nconsultar, editar y eliminar información de las mismas ya creadas.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblFecha.Location = new Point(740, 138);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 21;
            lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblHora.Location = new Point(740, 181);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(47, 20);
            lblHora.TabIndex = 22;
            lblHora.Text = "Hora:";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnNuevo.Location = new Point(40, 280);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(85, 30);
            btnNuevo.TabIndex = 23;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnGuardar.Location = new Point(145, 280);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 30);
            btnGuardar.TabIndex = 24;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEditar.Location = new Point(249, 280);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(85, 30);
            btnEditar.TabIndex = 25;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEliminar.Location = new Point(349, 280);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(85, 30);
            btnEliminar.TabIndex = 26;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnLimpiar.Location = new Point(449, 280);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(85, 30);
            btnLimpiar.TabIndex = 27;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnSalir.Location = new Point(549, 280);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(85, 30);
            btnSalir.TabIndex = 28;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBusqueda.Location = new Point(41, 353);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(86, 21);
            lblBusqueda.TabIndex = 29;
            lblBusqueda.Text = "Busqueda:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(145, 351);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(289, 23);
            txtBuscar.TabIndex = 30;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(40, 400);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(900, 230);
            dgvReservas.TabIndex = 31;
            dgvReservas.CellClick += dataGridView1_CellClick;
            // 
            // FrmReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(dgvReservas);
            Controls.Add(txtBuscar);
            Controls.Add(lblBusqueda);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(dtpHoraFin);
            Controls.Add(lblHoraFin);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblHoraInicio);
            Controls.Add(dtpFecha);
            Controls.Add(lblFechaReserva);
            Controls.Add(cmbProfesor);
            Controls.Add(lblProfesor);
            Controls.Add(cmbAula);
            Controls.Add(lblAula);
            Name = "FrmReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Reservas";
            Load += FrmReservas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAula;
        private ComboBox cmbAula;
        private Label lblProfesor;
        private ComboBox cmbProfesor;
        private Label lblFechaReserva;
        private DateTimePicker dtpFecha;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblHoraFin;
        private DateTimePicker dtpHoraFin;
        private Label label2;
        private Label label1;
        private Label lblFecha;
        private Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnSalir;
        private Label lblBusqueda;
        private TextBox txtBuscar;
        private DataGridView dgvReservas;
    }
}