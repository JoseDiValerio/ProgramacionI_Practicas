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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            maskedTextBox1 = new MaskedTextBox();
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
            // textBox1
            // 
            textBox1.Location = new Point(150, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(283, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(150, 207);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(283, 23);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(150, 157);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(283, 23);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(150, 107);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(283, 23);
            textBox4.TabIndex = 7;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F);
            button1.Location = new Point(150, 300);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 8;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15.75F);
            button2.Location = new Point(300, 300);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 9;
            button2.Text = "Borrar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 15.75F);
            button3.Location = new Point(450, 300);
            button3.Name = "button3";
            button3.Size = new Size(120, 40);
            button3.TabIndex = 10;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(150, 247);
            maskedTextBox1.Mask = "(999)000-0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(283, 23);
            maskedTextBox1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 411);
            Controls.Add(maskedTextBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Button button3;
        private MaskedTextBox maskedTextBox1;
    }
}
