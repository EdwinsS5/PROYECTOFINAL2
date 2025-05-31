namespace DiagnosticoEnfermedades.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnDiagnostico;
        private System.Windows.Forms.Button btnInforme;
        private System.Windows.Forms.Button btnHospital;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblBienvenida = new Label();
            btnDiagnostico = new Button();
            btnInforme = new Button();
            btnHospital = new Button();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBienvenida.Location = new Point(70, 20);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(183, 32);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "🏠 Bienvenido";
            // 
            // btnDiagnostico
            // 
            btnDiagnostico.Font = new Font("Segoe UI", 10F);
            btnDiagnostico.Location = new Point(40, 70);
            btnDiagnostico.Name = "btnDiagnostico";
            btnDiagnostico.Size = new Size(200, 35);
            btnDiagnostico.TabIndex = 1;
            btnDiagnostico.Text = "📝 Nuevo Diagnóstico";
            btnDiagnostico.UseVisualStyleBackColor = true;
            btnDiagnostico.Click += btnDiagnostico_Click;
            // 
            // btnInforme
            // 
            btnInforme.Font = new Font("Segoe UI", 10F);
            btnInforme.Location = new Point(40, 120);
            btnInforme.Name = "btnInforme";
            btnInforme.Size = new Size(200, 35);
            btnInforme.TabIndex = 2;
            btnInforme.Text = "📄 Generar Informe";
            btnInforme.UseVisualStyleBackColor = true;
            btnInforme.Click += btnInforme_Click;
            // 
            // btnHospital
            // 
            btnHospital.Font = new Font("Segoe UI", 10F);
            btnHospital.Location = new Point(40, 220);
            btnHospital.Name = "btnHospital";
            btnHospital.Size = new Size(200, 35);
            btnHospital.TabIndex = 4;
            btnHospital.Text = "🏥 Solicitar Visita Hospitalaria";
            btnHospital.UseVisualStyleBackColor = true;
            btnHospital.Click += btnHospital_Click;
            // 
            // MainForm
            // 
            BackgroundImage = Properties.Resources.medicina3;
            ClientSize = new Size(284, 291);
            Controls.Add(lblBienvenida);
            Controls.Add(btnDiagnostico);
            Controls.Add(btnInforme);
            Controls.Add(btnHospital);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
