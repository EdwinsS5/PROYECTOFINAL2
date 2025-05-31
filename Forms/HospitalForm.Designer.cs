namespace DiagnosticoEnfermedades.Forms
{
    partial class HospitalForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnSolicitar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picLogo = new PictureBox();
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            btnSolicitar = new Button();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.logo_hospital;
            picLogo.Location = new Point(12, 10);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(52, 48);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(70, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(587, 37);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agendar cita al Hospital Nacional de Jutiapa";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F);
            lblNombre.Location = new Point(30, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(105, 23);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "👤 Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 68);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(220, 27);
            txtNombre.TabIndex = 3;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 10F);
            lblDireccion.Location = new Point(30, 110);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(113, 23);
            lblDireccion.TabIndex = 4;
            lblDireccion.Text = "📍 Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(130, 108);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(220, 27);
            txtDireccion.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 10F);
            lblTelefono.Location = new Point(30, 150);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(106, 23);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "📞 Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(130, 148);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(220, 27);
            txtTelefono.TabIndex = 7;
            // 
            // btnSolicitar
            // 
            btnSolicitar.BackColor = Color.LightGreen;
            btnSolicitar.FlatStyle = FlatStyle.Flat;
            btnSolicitar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSolicitar.Location = new Point(130, 190);
            btnSolicitar.Name = "btnSolicitar";
            btnSolicitar.Size = new Size(220, 40);
            btnSolicitar.TabIndex = 8;
            btnSolicitar.Text = "✅ Solicitar Visita";
            btnSolicitar.UseVisualStyleBackColor = false;
            btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // HospitalForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.medicina;
            ClientSize = new Size(390, 260);
            Controls.Add(picLogo);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(btnSolicitar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "HospitalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agendar cita al Hospital Nacional de Jutiapa";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}