namespace ProyectoReservasAulas.Forms
{
    partial class FrmPrincipal
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
            label1 = new Label();
            btnAulas = new Button();
            btnProfesores = new Button();
            btnReservas = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(215, 38);
            label1.Name = "label1";
            label1.Size = new Size(409, 32);
            label1.TabIndex = 0;
            label1.Text = "CONTROL DE RESERVAS DE AULAS";
            // 
            // btnAulas
            // 
            btnAulas.BackColor = Color.RoyalBlue;
            btnAulas.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnAulas.Location = new Point(296, 108);
            btnAulas.Name = "btnAulas";
            btnAulas.Size = new Size(220, 55);
            btnAulas.TabIndex = 0;
            btnAulas.Text = "AULAS";
            btnAulas.UseVisualStyleBackColor = false;
            btnAulas.Click += btnAulas_Click;
            // 
            // btnProfesores
            // 
            btnProfesores.BackColor = Color.RoyalBlue;
            btnProfesores.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnProfesores.Location = new Point(296, 192);
            btnProfesores.Name = "btnProfesores";
            btnProfesores.Size = new Size(220, 55);
            btnProfesores.TabIndex = 1;
            btnProfesores.Text = "PROFESORES";
            btnProfesores.UseVisualStyleBackColor = false;
            btnProfesores.Click += btnProfesores_Click;
            // 
            // btnReservas
            // 
            btnReservas.BackColor = Color.RoyalBlue;
            btnReservas.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnReservas.Location = new Point(296, 278);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(220, 55);
            btnReservas.TabIndex = 2;
            btnReservas.Text = "RESERVAS";
            btnReservas.UseVisualStyleBackColor = false;
            btnReservas.Click += btnReservas_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.RoyalBlue;
            btnSalir.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSalir.Location = new Point(296, 360);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(220, 55);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(884, 461);
            Controls.Add(btnSalir);
            Controls.Add(btnReservas);
            Controls.Add(btnProfesores);
            Controls.Add(btnAulas);
            Controls.Add(label1);
            ForeColor = SystemColors.Window;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de Reservas de Aulas";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAulas;
        private Button btnProfesores;
        private Button btnReservas;
        private Button btnSalir;
    }
}