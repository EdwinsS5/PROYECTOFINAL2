using System;
using System.Windows.Forms;

namespace DiagnosticoEnfermedades.Forms
{
    public partial class DiagnosticoForm : Form
    {
        private readonly int pacienteId;
        private readonly string pacienteNombre;

        // Variables para pasar a informe
        private int diagnosticoIdGenerado = 0;
        private string anamnesisIA, tratamientoIA, diagnosticoIA, fechaDiagnostico;

        public DiagnosticoForm(int pacienteId, string pacienteNombre)
        {
            InitializeComponent();
            this.pacienteId = pacienteId;
            this.pacienteNombre = pacienteNombre;
            txtNombre.Text = pacienteNombre;
            txtNombre.ReadOnly = true;
        }

        private async void btnDiagnosticar_Click(object sender, EventArgs e)
        {
            btnDiagnosticar.Enabled = false;
            txtResultadoIA.Text = "Consultando IA, por favor espere...";

            string sintomas = txtSintomas.Text.Trim();
            string edad = txtEdad.Text.Trim();
            DateTime fechaInicio = txtFechaInicio.Value;
            DateTime fecha = DateTime.Now;

            try
            {
                // Construye el prompt para la IA
                string prompt =
                    "Dado el siguiente caso clínico, responde SOLO con los siguientes apartados en español:\n\n" +
                    "Anamnesis:\n" +
                    "Diagnóstico:\n" +
                    "Tratamiento:\n\n" +
                    $"Paciente: {pacienteNombre}, Edad: {edad}. Síntomas: {sintomas}. Fecha de inicio: {fechaInicio.ToShortDateString()}.\n\n" +
                    "Por favor, responde exactamente en ese formato, usando los títulos 'Anamnesis:', 'Diagnóstico:' y 'Tratamiento:', cada uno en una línea diferente y sin agregar nada extra.";

                // Llama a la IA
                string resultadoIA = await DiagnosticoOpenAI.Diagnosticar(prompt, fechaInicio.ToShortDateString());

                // Extrae los campos del resultado de la IA
                string anamnesis = ExtraerCampo(resultadoIA, "Anamnesis:");
                string diagnostico = ExtraerCampo(resultadoIA, "Diagnóstico:");
                string tratamiento = ExtraerCampo(resultadoIA, "Tratamiento:");

                // Mostrar resultado en el textbox
                string textoMostrar = "";
                if (!string.IsNullOrWhiteSpace(anamnesis))
                    textoMostrar += "Anamnesis:\r\n" + anamnesis.Trim() + "\r\n\r\n";
                if (!string.IsNullOrWhiteSpace(diagnostico))
                    textoMostrar += "Diagnóstico:\r\n" + diagnostico.Trim() + "\r\n\r\n";
                if (!string.IsNullOrWhiteSpace(tratamiento))
                    textoMostrar += "Tratamiento:\r\n" + tratamiento.Trim();

                if (string.IsNullOrWhiteSpace(textoMostrar))
                {
                    textoMostrar = resultadoIA.Trim();
                    if (string.IsNullOrEmpty(textoMostrar))
                        textoMostrar = "La IA no devolvió información relevante. Intente nuevamente o revise los datos ingresados.";
                }

                txtResultadoIA.Text = textoMostrar.Trim();

                // Extrae el nombre de la enfermedad para la BD
                string nombreEnfermedad = ExtraerNombreEnfermedad(diagnostico?.Trim());
                if (string.IsNullOrWhiteSpace(nombreEnfermedad))
                    nombreEnfermedad = "Sin diagnóstico";

                int enfermedadId = DiagnosticoEnfermedades.BaseDatos.ObtenerEnfermedadIdPorNombre(nombreEnfermedad);
                if (enfermedadId == 0)
                    enfermedadId = DiagnosticoEnfermedades.BaseDatos.InsertarEnfermedad(nombreEnfermedad, "");

                // Guarda el diagnóstico SOLO UNA VEZ y obtiene el ID
                int diagnosticoId = DiagnosticoEnfermedades.BaseDatos.GuardarDiagnostico(
                    pacienteId,
                    enfermedadId,
                    anamnesis ?? "",
                    diagnostico ?? "",
                    tratamiento ?? "",
                    sintomas,
                    fecha
                );

                if (diagnosticoId == 0)
                    throw new Exception("No se pudo guardar el diagnóstico.");

                // Guarda los datos para informe
                diagnosticoIdGenerado = diagnosticoId;
                anamnesisIA = anamnesis;
                tratamientoIA = tratamiento;
                diagnosticoIA = diagnostico;
                fechaDiagnostico = fecha.ToString("yyyy-MM-dd");

                MessageBox.Show("Diagnóstico guardado correctamente. Puede generar el informe.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                txtResultadoIA.Text = "Ocurrió un error al consultar o guardar: " + ex.Message;
            }
            finally
            {
                btnDiagnosticar.Enabled = true;
            }
        }

        // Llama a este método desde el menú, otro form, o donde generes el informe
        public void GenerarInforme()
        {
            if (diagnosticoIdGenerado == 0)
            {
                MessageBox.Show("Primero debes realizar y guardar un diagnóstico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ventanaInforme = new GenerarInforme(
                diagnosticoIdGenerado,
                pacienteId,
                pacienteNombre,
                anamnesisIA,
                tratamientoIA,
                diagnosticoIA,
                fechaDiagnostico
            );
            ventanaInforme.ShowDialog();
        }

        private string ExtraerCampo(string texto, string campo)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            int idx = texto.IndexOf(campo, StringComparison.OrdinalIgnoreCase);
            if (idx < 0) return "";

            int start = idx + campo.Length;
            int end = texto.Length;

            string[] posiblesCampos = { "Anamnesis:", "Diagnóstico:", "Tratamiento:" };
            foreach (var siguienteCampo in posiblesCampos)
            {
                if (siguienteCampo.Equals(campo, StringComparison.OrdinalIgnoreCase)) continue;
                int siguienteIdx = texto.IndexOf("\n" + siguienteCampo, start, StringComparison.OrdinalIgnoreCase);
                if (siguienteIdx >= 0 && siguienteIdx < end)
                    end = siguienteIdx;
            }

            return texto.Substring(start, end - start).Trim();
        }

        private string ExtraerNombreEnfermedad(string diagnosticoCompleto)
        {
            if (string.IsNullOrWhiteSpace(diagnosticoCompleto)) return "Sin diagnóstico";
            int punto = diagnosticoCompleto.IndexOf('.');
            int dosPuntos = diagnosticoCompleto.IndexOf(':');
            int saltoLinea = diagnosticoCompleto.IndexOf('\n');
            int corte = diagnosticoCompleto.Length;
            if (punto >= 0 && punto < corte) corte = punto;
            if (dosPuntos >= 0 && dosPuntos < corte) corte = dosPuntos;
            if (saltoLinea >= 0 && saltoLinea < corte) corte = saltoLinea;
            string nombre = diagnosticoCompleto.Substring(0, corte).Trim();
            int maxLen = 50;
            if (nombre.Length > maxLen)
                nombre = nombre.Substring(0, maxLen);
            if (string.IsNullOrWhiteSpace(nombre))
                nombre = diagnosticoCompleto.Length > maxLen ? diagnosticoCompleto.Substring(0, maxLen) : diagnosticoCompleto;
            return nombre;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtEdad.Clear();
            txtSintomas.Clear();
            txtFechaInicio.Value = DateTime.Today;
            txtResultadoIA.Clear();
            diagnosticoIdGenerado = 0;
            anamnesisIA = tratamientoIA = diagnosticoIA = fechaDiagnostico = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}