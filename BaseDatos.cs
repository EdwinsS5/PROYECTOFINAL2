using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DiagnosticoEnfermedades
{
    public static class BaseDatos
    {
        private static string connectionString = "Server=DESKTOP-P5L5BPG\\SQLEXPRESS01;Database=SistemaSalud;Integrated Security=True; TrustServerCertificate=True; ";

        public static bool ValidarUsuario(string usuario, string contrasena, out int pacienteId, out string nombre)
        {
            pacienteId = 0;
            nombre = "";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string sql = "SELECT P.Id, P.NombreCompleto FROM Usuarios U INNER JOIN Pacientes P ON U.Usuario = P.Usuario WHERE U.Usuario=@usuario AND U.Contrasena=@contrasena";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pacienteId = reader.GetInt32(0);
                        nombre = reader.GetString(1);
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool UsuarioExiste(string usuario)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                conexion.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        /// <summary>
        /// Registra un nuevo usuario y paciente con todos los campos requeridos. Devuelve si fue exitoso y el mensaje de error (si hay).
        /// </summary>
        public static bool RegistrarUsuario(
            string usuario,
            string contrasena,
            string nombreCompleto,
            string correo,
            DateTime fechaNacimiento,
            string genero,
            string telefono,
            int edad,
            out string error)
        {
            error = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlTransaction trans = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Verifica si el usuario ya existe
                            string checkUserQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario";
                            SqlCommand checkCmd = new SqlCommand(checkUserQuery, conexion, trans);
                            checkCmd.Parameters.AddWithValue("@usuario", usuario);
                            int exists = (int)checkCmd.ExecuteScalar();
                            if (exists > 0)
                            {
                                error = "El nombre de usuario ya está registrado. Elija otro.";
                                trans.Rollback();
                                return false;
                            }

                            // Insertar en tabla Usuarios
                            string sqlUser = "INSERT INTO Usuarios (Usuario, Contrasena, NombreCompleto, Correo) VALUES (@usuario, @contrasena, @nombreCompleto, @correo)";
                            SqlCommand cmdUser = new SqlCommand(sqlUser, conexion, trans);
                            cmdUser.Parameters.AddWithValue("@usuario", usuario);
                            cmdUser.Parameters.AddWithValue("@contrasena", contrasena);
                            cmdUser.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                            cmdUser.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(correo) ? (object)DBNull.Value : correo);
                            cmdUser.ExecuteNonQuery();

                            // Insertar en tabla Pacientes (con todos los campos nuevos)
                            string sqlPaciente = @"INSERT INTO Pacientes 
                                (Usuario, NombreCompleto, FechaNacimiento, Genero, Telefono, Edad)
                                VALUES (@usuario, @nombreCompleto, @fechaNacimiento, @genero, @telefono, @edad)";
                            SqlCommand cmdPaciente = new SqlCommand(sqlPaciente, conexion, trans);
                            cmdPaciente.Parameters.AddWithValue("@usuario", usuario);
                            cmdPaciente.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                            cmdPaciente.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                            cmdPaciente.Parameters.AddWithValue("@genero", genero);
                            cmdPaciente.Parameters.AddWithValue("@telefono", telefono);
                            cmdPaciente.Parameters.AddWithValue("@edad", edad);
                            cmdPaciente.ExecuteNonQuery();

                            trans.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            error = "Error al registrar usuario: " + ex.Message;
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Error general: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Guarda un diagnóstico en la tabla Diagnosticos con los campos IA.
        /// </summary>
        public static int GuardarDiagnostico(
            int pacienteId,
            int enfermedadId,
            string anamnesis,
            string diagnostico,
            string tratamiento,
            string observaciones,
            DateTime fecha
        )
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Diagnosticos
                    (PacienteId, EnfermedadId, Anamnesis, Diagnostico, Tratamiento, Observaciones, Fecha)
                    OUTPUT INSERTED.Id
                    VALUES
                    (@pacienteId, @enfermedadId, @anamnesis, @diagnostico, @tratamiento, @observaciones, @fecha)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@pacienteId", pacienteId);
                cmd.Parameters.AddWithValue("@enfermedadId", enfermedadId);
                cmd.Parameters.AddWithValue("@anamnesis", anamnesis ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@diagnostico", diagnostico ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@tratamiento", tratamiento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@observaciones", observaciones ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                conexion.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Busca el Id de la enfermedad por nombre. Si no existe, devuelve 0.
        /// </summary>
        public static int ObtenerEnfermedadIdPorNombre(string nombreEnfermedad)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id FROM Enfermedades WHERE Nombre = @nombre";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", nombreEnfermedad);
                conexion.Open();
                var result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                    return id;
                return 0;
            }
        }

        /// <summary>
        /// Inserta una nueva enfermedad y devuelve su Id.
        /// </summary>
        public static int InsertarEnfermedad(string nombre, string descripcion)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Enfermedades (Nombre, Descripcion) OUTPUT INSERTED.Id VALUES (@nombre, @descripcion)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion ?? (object)DBNull.Value);
                conexion.Open();
                var result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                    return id;
                return 0;
            }
        }

        public static void GuardarInforme(
            int diagnosticoId,
            string pacienteNombre,
            string dpi,
            int edad,
            string domicilio,
            string anamnesis,
            string tratamiento,
            string diagnosticoTexto
        )
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Informes 
                    (DiagnosticoId, Fecha, PacienteNombre, DPI, Edad, Domicilio, Anamnesis, Tratamiento, DiagnosticoTexto) 
                    VALUES 
                    (@diagnosticoId, @fecha, @pacienteNombre, @dpi, @edad, @domicilio, @anamnesis, @tratamiento, @diagnosticoTexto)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@diagnosticoId", diagnosticoId);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@pacienteNombre", pacienteNombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@dpi", dpi ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.Parameters.AddWithValue("@domicilio", domicilio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@anamnesis", anamnesis ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@tratamiento", tratamiento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@diagnosticoTexto", diagnosticoTexto ?? (object)DBNull.Value);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static DataRow ObtenerUltimoDiagnosticoDePaciente(int pacienteId)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string sql = "SELECT TOP 1 * FROM Diagnosticos WHERE PacienteId = @pacienteId ORDER BY Fecha DESC";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@pacienteId", pacienteId);
                conexion.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                    return null;
                }
            }
        }

        public static DataRow ObtenerInformePorDiagnostico(int diagnosticoId)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string sql = "SELECT TOP 1 * FROM Informes WHERE DiagnosticoId = @diagnosticoId ORDER BY Fecha DESC";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@diagnosticoId", diagnosticoId);
                conexion.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                    return null;
                }
            }
        }

        public static void RegistrarSolicitudVisita(int pacienteId, string direccion, string telefono)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                // Usa los nombres correctos de columnas según tu tabla: FechaSolicitud en vez de Fecha y Estado obligatorio
                string sql = "INSERT INTO SolicitudesVisita (PacienteId, FechaSolicitud, Direccion, Telefono, Estado) VALUES (@pacienteId, @fechaSolicitud, @direccion, @telefono, @estado)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@pacienteId", pacienteId);
                cmd.Parameters.AddWithValue("@fechaSolicitud", DateTime.Now);
                cmd.Parameters.AddWithValue("@direccion", direccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@estado", "Pendiente");
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static DataRow ObtenerDiagnosticoDetallado(int diagnosticoId, int pacienteId)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string sql = @"SELECT D.*, P.NombreCompleto
                               FROM Diagnosticos D
                               INNER JOIN Pacientes P ON D.PacienteId = P.Id
                               WHERE D.Id = @diagnosticoId AND D.PacienteId = @pacienteId";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@diagnosticoId", diagnosticoId);
                cmd.Parameters.AddWithValue("@pacienteId", pacienteId);
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                return null;
            }
        }
    }
}