namespace DiagnosticoEnfermedades.Forms
{
    partial class RegistroForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.NumericUpDown nudEdad;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblGenero = new Label();
            cbGenero = new ComboBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEdad = new Label();
            nudEdad = new NumericUpDown();
            btnRegistrar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(55, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(241, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "🏥 Registro de Paciente";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(30, 45);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(87, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "👤 Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(130, 39);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(150, 27);
            txtUsuario.TabIndex = 2;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(30, 75);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(111, 20);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "🔒 Contraseña:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(130, 68);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(150, 27);
            txtContrasena.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(30, 105);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(92, 20);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "\U0001f9d1 Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 102);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 27);
            txtNombre.TabIndex = 6;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(30, 135);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(82, 20);
            lblCorreo.TabIndex = 7;
            lblCorreo.Text = "📧 Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(120, 132);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(150, 27);
            txtCorreo.TabIndex = 8;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(30, 165);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(108, 20);
            lblFechaNacimiento.TabIndex = 9;
            lblFechaNacimiento.Text = "📆 Fecha Nac.:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(140, 160);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(140, 27);
            dtpFechaNacimiento.TabIndex = 10;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(30, 195);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(85, 20);
            lblGenero.TabIndex = 11;
            lblGenero.Text = "⚧ Género:";
            // 
            // cbGenero
            // 
            cbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenero.FormattingEnabled = true;
            cbGenero.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            cbGenero.Location = new Point(120, 192);
            cbGenero.Name = "cbGenero";
            cbGenero.Size = new Size(150, 28);
            cbGenero.TabIndex = 12;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(30, 225);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(95, 20);
            lblTelefono.TabIndex = 13;
            lblTelefono.Text = "📞 Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(120, 222);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(150, 27);
            txtTelefono.TabIndex = 14;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(30, 255);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(71, 20);
            lblEdad.TabIndex = 15;
            lblEdad.Text = "🎂 Edad:";
            // 
            // nudEdad
            // 
            nudEdad.Location = new Point(120, 252);
            nudEdad.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudEdad.Name = "nudEdad";
            nudEdad.Size = new Size(60, 27);
            nudEdad.TabIndex = 16;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.MediumSeaGreen;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(40, 290);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(100, 30);
            btnRegistrar.TabIndex = 17;
            btnRegistrar.Text = "✅ Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.IndianRed;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(170, 290);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(100, 30);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "❌ Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // RegistroForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 340);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblGenero);
            Controls.Add(cbGenero);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblEdad);
            Controls.Add(nudEdad);
            Controls.Add(btnRegistrar);
            Controls.Add(btnSalir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegistroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crear Cuenta";
            ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}