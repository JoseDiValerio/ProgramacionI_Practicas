namespace ProyectoReservasAulas.Forms
{
    partial class FrmProfesores
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
            btnLimpiar = new Button();
            btnSalir = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            label2 = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            dgvProfesores = new DataGridView();
            lblBusqueda = new Label();
            txtBuscar = new TextBox();
            txtMateria = new TextBox();
            lblMateria = new Label();
            lblHora = new Label();
            lblFecha = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).BeginInit();
            SuspendLayout();
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnLimpiar.Location = new Point(550, 238);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(85, 30);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnSalir.Location = new Point(650, 238);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(85, 30);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEliminar.Location = new Point(450, 238);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(85, 30);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEditar.Location = new Point(350, 238);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(85, 30);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnGuardar.Location = new Point(250, 238);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 30);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(150, 238);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(85, 30);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(315, 15);
            label2.Name = "label2";
            label2.Size = new Size(251, 30);
            label2.TabIndex = 24;
            label2.Text = "REGISTRO DE PROFESOR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 43);
            label1.Name = "label1";
            label1.Size = new Size(716, 21);
            label1.TabIndex = 23;
            label1.Text = "Administra los profesores del centro, permitiendo registrar, consultar, editar y eliminar sus datos.";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(354, 87);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(195, 23);
            txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(182, 87);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(153, 21);
            lblNombre.TabIndex = 25;
            lblNombre.Text = "Nombre y Apellido:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(354, 157);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(195, 23);
            txtCorreo.TabIndex = 2;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(270, 159);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(65, 21);
            lblCorreo.TabIndex = 27;
            lblCorreo.Text = "Correo:";
            // 
            // dgvProfesores
            // 
            dgvProfesores.AllowUserToAddRows = false;
            dgvProfesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesores.Location = new Point(40, 285);
            dgvProfesores.MultiSelect = false;
            dgvProfesores.Name = "dgvProfesores";
            dgvProfesores.ReadOnly = true;
            dgvProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesores.Size = new Size(800, 160);
            dgvProfesores.TabIndex = 10;
            dgvProfesores.CellClick += dgvProfesores_CellClick;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBusqueda.Location = new Point(249, 197);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(86, 21);
            lblBusqueda.TabIndex = 30;
            lblBusqueda.Text = "Busqueda:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(354, 195);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(195, 23);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // txtMateria
            // 
            txtMateria.Location = new Point(354, 122);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(195, 23);
            txtMateria.TabIndex = 1;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMateria.Location = new Point(265, 124);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(70, 21);
            lblMateria.TabIndex = 32;
            lblMateria.Text = "Materia:";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblHora.Location = new Point(650, 121);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(47, 20);
            lblHora.TabIndex = 34;
            lblHora.Text = "Hora:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblFecha.Location = new Point(650, 86);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 33;
            lblFecha.Text = "Fecha:";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // FrmProfesores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 461);
            Controls.Add(lblHora);
            Controls.Add(lblFecha);
            Controls.Add(txtMateria);
            Controls.Add(lblMateria);
            Controls.Add(txtBuscar);
            Controls.Add(lblBusqueda);
            Controls.Add(dgvProfesores);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLimpiar);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Name = "FrmProfesores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Profesor";
            Load += FrmProfesores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLimpiar;
        private Button btnSalir;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private DataGridView dgvProfesores;
        private Label lblBusqueda;
        private TextBox txtBuscar;
        private TextBox txtMateria;
        private Label lblMateria;
        private Label lblHora;
        private Label lblFecha;
        private System.Windows.Forms.Timer timer1;
    }
}