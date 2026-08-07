namespace PracticaWinForms
{
    public partial class Form1 : Form
    {
        List<Contacto> contactos = new List<Contacto>();

        private void MostrarContactos()
        {
            listContactos.Items.Clear();

            foreach (Contacto contacto in contactos)
            {
                listContactos.Items.Add(contacto.Nombre + " " + contacto.Apellido + " " + contacto.Telefono + " " + contacto.Correo);
            }
        }

        public Form1()
        {
            InitializeComponent();

            textNombre.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textNombre.Text) ||
                string.IsNullOrEmpty(textApellido.Text) ||
                string.IsNullOrEmpty(textCorreo.Text) ||
                string.IsNullOrEmpty(textTelefono.Text))
            {
                MessageBox.Show(this, "Debe completar todos los campos.", "Advertencia.", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Contacto nuevo = new Contacto();

            nuevo.Nombre = textNombre.Text;
            nuevo.Apellido = textApellido.Text;
            nuevo.Correo = textCorreo.Text;
            nuevo.Telefono = textTelefono.Text;

            contactos.Add(nuevo);

            MostrarContactos();

            MessageBox.Show(this, "Contacto guardado.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textNombre.Clear();
            textApellido.Clear();
            textCorreo.Clear();
            textTelefono.Clear();

            textNombre.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textNombre.Focus();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textNombre.Clear();
            textApellido.Clear();
            textCorreo.Clear();
            textTelefono.Clear();
        }

        private void listContactos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
