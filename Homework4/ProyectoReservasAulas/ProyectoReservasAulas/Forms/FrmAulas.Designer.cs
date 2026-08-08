namespace ProyectoReservasAulas.Forms
{
    partial class FrmAulas
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
            lblCodigo = new Label();
            lblNombre = new Label();
            lblCapacidad = new Label();
            lblBusqueda = new Label();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            nudCapacidad = new NumericUpDown();
            txtBuscar = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            dgvAulas = new DataGridView();
            btnLimpiar = new Button();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblFecha = new Label();
            lblHora = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAulas).BeginInit();
            SuspendLayout();
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(41, 51);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(68, 21);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Codigo:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(41, 90);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(75, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCapacidad.Location = new Point(41, 135);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(90, 21);
            lblCapacidad.TabIndex = 2;
            lblCapacidad.Text = "Capacidad:";
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBusqueda.Location = new Point(41, 181);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(86, 21);
            lblBusqueda.TabIndex = 3;
            lblBusqueda.Text = "Busqueda:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(140, 49);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 5;
            // 
            // nudCapacidad
            // 
            nudCapacidad.Location = new Point(140, 133);
            nudCapacidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(100, 23);
            nudCapacidad.TabIndex = 6;
            nudCapacidad.TextAlign = HorizontalAlignment.Center;
            nudCapacidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(140, 179);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 23);
            txtBuscar.TabIndex = 7;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(40, 229);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(85, 30);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnGuardar.Location = new Point(140, 229);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 30);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEditar.Location = new Point(240, 229);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(85, 30);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEliminar.Location = new Point(340, 229);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(85, 30);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnSalir.Location = new Point(540, 229);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(85, 30);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvAulas
            // 
            dgvAulas.AllowUserToAddRows = false;
            dgvAulas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAulas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAulas.Location = new Point(41, 288);
            dgvAulas.MultiSelect = false;
            dgvAulas.Name = "dgvAulas";
            dgvAulas.ReadOnly = true;
            dgvAulas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAulas.Size = new Size(800, 150);
            dgvAulas.TabIndex = 15;
            dgvAulas.CellClick += dgvAulas_CellClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnLimpiar.Location = new Point(440, 229);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(85, 30);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(360, 82);
            label1.Name = "label1";
            label1.Size = new Size(481, 42);
            label1.TabIndex = 17;
            label1.Text = "Administra las aulas del centro, permitiendo registrar, consultar,\r\neditar y eliminar información como código, nombre y capacidad.";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(501, 43);
            label2.Name = "label2";
            label2.Size = new Size(202, 30);
            label2.TabIndex = 18;
            label2.Text = "REGISTRO DE AULA";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblFecha.Location = new Point(680, 140);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 19;
            lblFecha.Text = "Fecha:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblHora.Location = new Point(680, 170);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(47, 20);
            lblHora.TabIndex = 20;
            lblHora.Text = "Hora:";
            // 
            // FrmAulas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 461);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvAulas);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtBuscar);
            Controls.Add(nudCapacidad);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(lblBusqueda);
            Controls.Add(lblCapacidad);
            Controls.Add(lblNombre);
            Controls.Add(lblCodigo);
            Name = "FrmAulas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Aula";
            Load += FrmAulas_Load;
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAulas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigo;
        private Label lblNombre;
        private Label lblCapacidad;
        private Label lblBusqueda;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private NumericUpDown nudCapacidad;
        private TextBox txtBuscar;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnSalir;
        private DataGridView dgvAulas;
        private Button btnLimpiar;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Label lblFecha;
        private Label lblHora;
    }
}