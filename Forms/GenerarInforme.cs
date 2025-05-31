using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DiagnosticoEnfermedades.Helpers;

namespace DiagnosticoEnfermedades.Forms
{
    public partial class GenerarInforme : Form
    {
        // Recibe el ID del diagnóstico YA GUARDADO
        private readonly int diagnosticoId;
        private readonly string anamnesisIA;
        private readonly string tratamientoIA;
        private readonly string diagnosticoIA;
        private readonly int pacienteId;
        private readonly string nombrePaciente;
        private readonly string fechaDiagnostico;

        // Modifica el constructor para recibir el ID del diagnóstico ya guardado
        public GenerarInforme(
            int diagnosticoId,
            int pacienteId,
            string nombre,
            string anamnesis,
            string tratamiento,
            string diagnostico,
            string fechaDiagnostico)
        {
            InitializeComponent();
            this.diagnosticoId = diagnosticoId;
            this.pacienteId = pacienteId;
            this.anamnesisIA = anamnesis;
            this.tratamientoIA = tratamiento;
            this.diagnosticoIA = diagnostico;
            this.nombrePaciente = nombre;
            this.fechaDiagnostico = fechaDiagnostico;
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            string nombre = nombrePaciente;
            string fecha = fechaDiagnostico;

            string dpi = txtDpi.Text.Trim();
            string domicilio = txtDireccion.Text.Trim();

            if (!int.TryParse(txtEdad.Text.Trim(), out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SOLO GUARDAMOS EL INFORME, NO EL DIAGNÓSTICO
            DiagnosticoEnfermedades.BaseDatos.GuardarInforme(
                diagnosticoId,
                nombre,
                dpi,
                edad,
                domicilio,
                anamnesisIA,
                tratamientoIA,
                diagnosticoIA
            );

            var campos = new Dictionary<string, string>
            {
                { "PacienteNombre", nombre },
                { "DPI", dpi },
                { "Edad", edad.ToString() },
                { "Domicilio", domicilio },
                { "Anamnesis", anamnesisIA },
                { "Tratamiento", tratamientoIA },
                { "DiagnosticoTexto", diagnosticoIA },
                { "Fecha", DateTime.TryParse(fecha, out DateTime fechaDt)
                    ? fechaDt.ToString("dd 'de' MMMM 'de' yyyy")
                    : DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy") }
            };

            // Ruta robusta para la plantilla
            string plantillaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "plantilla_informe.docx");
            if (!File.Exists(plantillaPath))
            {
                MessageBox.Show("No se encontró la plantilla de informe en: " + plantillaPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Guardar Informe";
                saveDialog.Filter = "Documento Word (*.docx)|*.docx";
                saveDialog.FileName = $"informe_{nombre.Replace(" ", "_")}_{DateTime.Now:yyyyMMddHHmmss}.docx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string resultadoPath = saveDialog.FileName;
                    File.Copy(plantillaPath, resultadoPath, true);

                    using (WordprocessingDocument doc = WordprocessingDocument.Open(resultadoPath, true))
                    {
                        var body = doc.MainDocumentPart.Document.Body;
                        WordReplaceHelper.ReemplazarMarcadoresRobusto(body, campos);
                        doc.MainDocumentPart.Document.Save();
                    }

                    MessageBox.Show("Informe generado y guardado correctamente en:\n" + resultadoPath,
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + resultadoPath + "\"");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}