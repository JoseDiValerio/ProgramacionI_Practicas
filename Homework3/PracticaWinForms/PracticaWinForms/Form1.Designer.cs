namespace PracticaWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textNombre = new TextBox();
            textTelefono = new TextBox();
            textCorreo = new TextBox();
            textApellido = new TextBox();
            button1 = new Button();
            button2 = new Button();
            bSalir = new Button();
            listContactos = new ListBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 50);
            label1.Name = "label1";
            label1.Size = new Size(94, 30);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F);
            label2.Location = new Point(50, 100);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 1;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F);
            label3.Location = new Point(50, 150);
            label3.Name = "label3";
            label3.Size = new Size(80, 30);
            label3.TabIndex = 2;
            label3.Text = "Correo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F);
            label4.Location = new Point(50, 200);
            label4.Name = "label4";
            label4.Size = new Size(97, 30);
            label4.TabIndex = 3;
            label4.Text = "Telefono:";
            label4.Click += label4_Click;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(150, 57);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(320, 23);
            textNombre.TabIndex = 0;
            // 
            // textTelefono
            // 
            textTelefono.Location = new Point(150, 207);
            textTelefono.Name = "textTelefono";
            textTelefono.Size = new Size(320, 23);
            textTelefono.TabIndex = 3;
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(150, 157);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(320, 23);
            textCorreo.TabIndex = 2;
            // 
            // textApellido
            // 
            textApellido.Location = new Point(150, 107);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(320, 23);
            textApellido.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            button1.Location = new Point(50, 280);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 4;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            button2.Location = new Point(200, 280);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 5;
            button2.Text = "Borrar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // bSalir
            // 
            bSalir.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold);
            bSalir.Location = new Point(350, 280);
            bSalir.Name = "bSalir";
            bSalir.Size = new Size(120, 40);
            bSalir.TabIndex = 6;
            bSalir.Text = "Salir";
            bSalir.UseVisualStyleBackColor = true;
            bSalir.Click += bSalir_Click;
            // 
            // listContactos
            // 
            listContactos.FormattingEnabled = true;
            listContactos.Location = new Point(530, 60);
            listContactos.Name = "listContactos";
            listContactos.Size = new Size(400, 259);
            listContactos.TabIndex = 11;
            listContactos.SelectedIndexChanged += listContactos_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(660, 30);
            label5.Name = "label5";
            label5.Size = new Size(142, 21);
            label5.TabIndex = 12;
            label5.Text = "Lista de contactos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 361);
            Controls.Add(label5);
            Controls.Add(listContactos);
            Controls.Add(bSalir);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textApellido);
            Controls.Add(textCorreo);
            Controls.Add(textTelefono);
            Controls.Add(textNombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textNombre;
        private TextBox textTelefono;
        private TextBox textCorreo;
        private TextBox textApellido;
        private Button button1;
        private Button button2;
        private Button bSalir;
        private ListBox listContactos;
        private Label label5;
    }
}
