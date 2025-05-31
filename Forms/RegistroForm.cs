using System;
using System.Windows.Forms;

namespace DiagnosticoEnfermedades.Forms
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string nombreCompleto = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            DateTime fechaNacimiento = dtpFechaNacimiento.Value.Date;
            string genero = cbGenero.SelectedItem?.ToString() ?? "";
            string telefono = txtTelefono.Text.Trim();
            int edad = (int)nudEdad.Value;

            // Validación
            if (string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(contrasena) ||
                string.IsNullOrEmpty(nombreCompleto) ||
                string.IsNullOrEmpty(genero) ||
                string.IsNullOrEmpty(telefono) ||
                edad <= 0)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string error;
            bool exito = BaseDatos.RegistrarUsuario(
                usuario,
                contrasena,
                nombreCompleto,
                correo,
                fechaNacimiento,
                genero,
                telefono,
                edad,
                out error
            );

            if (exito)
            {
                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el usuario: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
