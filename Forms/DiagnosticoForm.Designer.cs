namespace DiagnosticoEnfermedades.Forms
{
    partial class DiagnosticoForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtEdad = new TextBox();
            txtSintomas = new TextBox();
            txtFechaInicio = new DateTimePicker();
            lblNombre = new Label();
            lblEdad = new Label();
            lblSintomas = new Label();
            lblFechaInicio = new Label();
            btnDiagnosticar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            txtResultadoIA = new TextBox();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(137, 29);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(251, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(137, 72);
            txtEdad.Margin = new Padding(3, 4, 3, 4);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(68, 27);
            txtEdad.TabIndex = 1;
            // 
            // txtSintomas
            // 
            txtSintomas.Location = new Point(137, 115);
            txtSintomas.Margin = new Padding(3, 4, 3, 4);
            txtSintomas.Multiline = true;
            txtSintomas.Name = "txtSintomas";
            txtSintomas.Size = new Size(251, 79);
            txtSintomas.TabIndex = 2;
            // 
            // txtFechaInicio
            // 
            txtFechaInicio.Format = DateTimePickerFormat.Short;
            txtFechaInicio.Location = new Point(167, 210);
            txtFechaInicio.Margin = new Padding(3, 4, 3, 4);
            txtFechaInicio.Name = "txtFechaInicio";
            txtFechaInicio.Size = new Size(137, 27);
            txtFechaInicio.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(46, 33);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(92, 20);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "👤 Nombre:";
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(46, 76);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(71, 20);
            lblEdad.TabIndex = 5;
            lblEdad.Text = "🎂 Edad:";
            // 
            // lblSintomas
            // 
            lblSintomas.AutoSize = true;
            lblSintomas.Location = new Point(46, 119);
            lblSintomas.Name = "lblSintomas";
            lblSintomas.Size = new Size(98, 20);
            lblSintomas.TabIndex = 6;
            lblSintomas.Text = "📝 Síntomas:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(46, 215);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(115, 20);
            lblFechaInicio.TabIndex = 7;
            lblFechaInicio.Text = "📅 Fecha Inicio:";
            // 
            // btnDiagnosticar
            // 
            btnDiagnosticar.BackColor = Color.ForestGreen;
            btnDiagnosticar.FlatStyle = FlatStyle.Flat;
            btnDiagnosticar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDiagnosticar.ForeColor = Color.White;
            btnDiagnosticar.Location = new Point(46, 267);
            btnDiagnosticar.Margin = new Padding(3, 4, 3, 4);
            btnDiagnosticar.Name = "btnDiagnosticar";
            btnDiagnosticar.Size = new Size(160, 47);
            btnDiagnosticar.TabIndex = 8;
            btnDiagnosticar.Text = "💡 Diagnosticar";
            btnDiagnosticar.UseVisualStyleBackColor = false;
            btnDiagnosticar.Click += btnDiagnosticar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.DodgerBlue;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(229, 267);
            btnLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(160, 47);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "\U0001f9f9 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.IndianRed;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(46, 507);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(343, 47);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "🚪 Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // txtResultadoIA
            // 
            txtResultadoIA.Location = new Point(47, 367);
            txtResultadoIA.Margin = new Padding(3, 4, 3, 4);
            txtResultadoIA.Multiline = true;
            txtResultadoIA.Name = "txtResultadoIA";
            txtResultadoIA.ReadOnly = true;
            txtResultadoIA.ScrollBars = ScrollBars.Vertical;
            txtResultadoIA.Size = new Size(342, 132);
            txtResultadoIA.TabIndex = 11;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(46, 333);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(185, 20);
            lblResultado.TabIndex = 12;
            lblResultado.Text = "📄 Diagnóstico generado:";
            // 
            // DiagnosticoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.medicina;
            ClientSize = new Size(439, 575);
            Controls.Add(lblResultado);
            Controls.Add(txtResultadoIA);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnDiagnosticar);
            Controls.Add(lblFechaInicio);
            Controls.Add(lblSintomas);
            Controls.Add(lblEdad);
            Controls.Add(lblNombre);
            Controls.Add(txtFechaInicio);
            Controls.Add(txtSintomas);
            Controls.Add(txtEdad);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DiagnosticoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Diagnóstico por IA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtSintomas;
        private System.Windows.Forms.DateTimePicker txtFechaInicio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblSintomas;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Button btnDiagnosticar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtResultadoIA;
        private System.Windows.Forms.Label lblResultado;
    }
}