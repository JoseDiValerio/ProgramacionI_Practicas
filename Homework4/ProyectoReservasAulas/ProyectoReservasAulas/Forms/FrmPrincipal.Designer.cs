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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
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
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            button1.Location = new Point(296, 108);
            button1.Name = "button1";
            button1.Size = new Size(220, 55);
            button1.TabIndex = 1;
            button1.Text = "AULAS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            button2.Location = new Point(296, 192);
            button2.Name = "button2";
            button2.Size = new Size(220, 55);
            button2.TabIndex = 2;
            button2.Text = "PROFESORES";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.RoyalBlue;
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            button3.Location = new Point(296, 278);
            button3.Name = "button3";
            button3.Size = new Size(220, 55);
            button3.TabIndex = 3;
            button3.Text = "RESERVAS";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.RoyalBlue;
            button4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            button4.Location = new Point(296, 360);
            button4.Name = "button4";
            button4.Size = new Size(220, 55);
            button4.TabIndex = 4;
            button4.Text = "SALIR";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(884, 461);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}