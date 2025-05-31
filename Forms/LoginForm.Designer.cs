namespace DiagnosticoEnfermedades.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblUsuario;
        private Label lblContrasena;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnLogin;
        private Button btnCrearCuenta;

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
            lblContrasena = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnLogin = new Button();
            btnCrearCuenta = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(45, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(232, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "\U0001f9fe Iniciar Sesión";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F);
            lblUsuario.Location = new Point(30, 70);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(100, 23);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "👤 Usuario:";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F);
            lblContrasena.Location = new Point(30, 110);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(129, 23);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "🔒 Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(130, 68);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(160, 27);
            txtUsuario.TabIndex = 2;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(130, 108);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '●';
            txtContrasena.Size = new Size(160, 27);
            txtContrasena.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightGreen;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.Location = new Point(40, 160);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(110, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "✅ Entrar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.BackColor = Color.LightGray;
            btnCrearCuenta.FlatStyle = FlatStyle.Flat;
            btnCrearCuenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrearCuenta.Location = new Point(180, 160);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(110, 40);
            btnCrearCuenta.TabIndex = 6;
            btnCrearCuenta.Text = "➕ Crear";
            btnCrearCuenta.UseVisualStyleBackColor = false;
            btnCrearCuenta.Click += btnCrearCuenta_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.medicina2;
            ClientSize = new Size(340, 230);
            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(btnLogin);
            Controls.Add(btnCrearCuenta);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
