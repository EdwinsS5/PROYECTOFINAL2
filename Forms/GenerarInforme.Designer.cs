namespace DiagnosticoEnfermedades.Forms
{
    partial class GenerarInforme
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtDpi = new TextBox();
            txtEdad = new TextBox();
            txtDireccion = new TextBox();
            lblTitulo = new Label();
            lblNombre = new Label();
            lblDpi = new Label();
            lblEdad = new Label();
            lblDireccion = new Label();
            btnGenerarInforme = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(149, 76);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(251, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtDpi
            // 
            txtDpi.Location = new Point(149, 123);
            txtDpi.Margin = new Padding(3, 4, 3, 4);
            txtDpi.Name = "txtDpi";
            txtDpi.Size = new Size(251, 27);
            txtDpi.TabIndex = 4;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(149, 169);
            txtEdad.Margin = new Padding(3, 4, 3, 4);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(91, 27);
            txtEdad.TabIndex = 6;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(149, 216);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(251, 27);
            txtDireccion.TabIndex = 8;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(14, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(411, 47);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "🏥 Generar Informe de Diagnóstico";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(34, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(92, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "👤 Nombre:";
            // 
            // lblDpi
            // 
            lblDpi.AutoSize = true;
            lblDpi.Location = new Point(34, 127);
            lblDpi.Name = "lblDpi";
            lblDpi.Size = new Size(60, 20);
            lblDpi.TabIndex = 3;
            lblDpi.Text = "🆔 DPI:";
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(34, 173);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(71, 20);
            lblEdad.TabIndex = 5;
            lblEdad.Text = "🎂 Edad:";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(34, 220);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(100, 20);
            lblDireccion.TabIndex = 7;
            lblDireccion.Text = "🏠 Dirección:";
            // 
            // btnGenerarInforme
            // 
            btnGenerarInforme.BackColor = Color.MediumSeaGreen;
            btnGenerarInforme.ForeColor = Color.White;
            btnGenerarInforme.Location = new Point(57, 280);
            btnGenerarInforme.Margin = new Padding(3, 4, 3, 4);
            btnGenerarInforme.Name = "btnGenerarInforme";
            btnGenerarInforme.Size = new Size(149, 47);
            btnGenerarInforme.TabIndex = 9;
            btnGenerarInforme.Text = "✅ Generar";
            btnGenerarInforme.UseVisualStyleBackColor = false;
            btnGenerarInforme.Click += btnGenerarInforme_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.IndianRed;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(229, 280);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 47);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "❌ Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // GenerarInforme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.medicina1;
            ClientSize = new Size(439, 348);
            Controls.Add(btnSalir);
            Controls.Add(btnGenerarInforme);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(txtEdad);
            Controls.Add(lblEdad);
            Controls.Add(txtDpi);
            Controls.Add(lblDpi);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GenerarInforme";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generar Informe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDpi;
        private System.Windows.Forms.TextBox txtDpi;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGenerarInforme;
        private System.Windows.Forms.Button btnSalir;
    }
}
