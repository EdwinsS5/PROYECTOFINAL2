using System;
using System.Windows.Forms;

namespace DiagnosticoEnfermedades.Forms
{
    public partial class HospitalForm : Form
    {
        private int pacienteId;
        private string nombrePaciente;

        public HospitalForm(int idPaciente, string nombre)
        {
            InitializeComponent();
            pacienteId = idPaciente;
            nombrePaciente = nombre;
            txtNombre.Text = nombrePaciente;
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("⚠️ Por favor, ingrese dirección y teléfono.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BaseDatos.RegistrarSolicitudVisita(pacienteId, direccion, telefono);
                MessageBox.Show("✅ Solicitud registrada.\nEl hospital se comunicará con usted próximamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ocurrió un error al registrar la solicitud:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}