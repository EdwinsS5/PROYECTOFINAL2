using System;
using System.Windows.Forms;

namespace DiagnosticoEnfermedades.Forms
{
    public partial class MainForm : Form
    {
        private int pacienteId;
        private string nombrePaciente;

        public MainForm(int id, string nombre)
        {
            InitializeComponent();
            pacienteId = id;
            nombrePaciente = nombre;
            lblBienvenida.Text = $"?? Bienvenido, {nombrePaciente}";
        }

        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            DiagnosticoForm diag = new DiagnosticoForm(pacienteId, nombrePaciente);
            diag.ShowDialog();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            var row = DiagnosticoEnfermedades.BaseDatos.ObtenerUltimoDiagnosticoDePaciente(pacienteId);
            if (row == null)
            {
                MessageBox.Show(
                    "Primero debes realizar un diagnóstico con IA antes de poder generar un informe.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            int diagnosticoId = Convert.ToInt32(row["Id"]);
            string anamnesisIA = row["Anamnesis"]?.ToString() ?? "";
            string tratamientoIA = row["Tratamiento"]?.ToString() ?? "";
            string diagnosticoIA = row["Diagnostico"]?.ToString() ?? "";
            string fechaDiagnostico = row["Fecha"]?.ToString() ?? DateTime.Now.ToString("dd/MM/yyyy");

            GenerarInforme inf = new GenerarInforme(
                diagnosticoId,
                pacienteId,
                nombrePaciente,
                anamnesisIA,
                tratamientoIA,
                diagnosticoIA,
                fechaDiagnostico
            );
            inf.ShowDialog();
        }

        private void btnHospital_Click(object sender, EventArgs e)
        {
            HospitalForm hosp = new HospitalForm(pacienteId, nombrePaciente);
            hosp.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}