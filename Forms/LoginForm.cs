using System;
using System.Windows.Forms;

namespace DiagnosticoEnfermedades.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Debe llenar usuario y contraseña.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pacienteId;
            string nombreUsuario;
            if (BaseDatos.ValidarUsuario(txtUsuario.Text, txtContrasena.Text, out pacienteId, out nombreUsuario))
            {
                this.Hide();
                MainForm main = new MainForm(pacienteId, nombreUsuario);
                main.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Si no tienes cuenta, pulsa 'Crear Cuenta'.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            RegistroForm registro = new RegistroForm();
            registro.ShowDialog();
        }
    }
}
