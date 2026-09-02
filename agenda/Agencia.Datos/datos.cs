using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Data;


namespace Datos
{
    public class DatosAgenda
    {
        private string _conexionString =
            "Server=localhost;Database=agenda;Uid=root;Pwd=TU_CLAVE;";


        public bool Agregar(
            string dni,
            string apellido,
            string nombres,
            string calle,
            string depto,
            string piso,
            string ciudad,
            string telefono,
            string email)
        {
            string query = @"INSERT INTO contactos
                            (Dni, Apellido, Nombres, Calle, Depto, Piso, Ciudad, Telefono, Email)
                            VALUES
                            (@Dni, @Apellido, @Nombres, @Calle, @Depto, @Piso, @Ciudad, @Telefono, @Email)";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Nombres", nombres);
                comando.Parameters.AddWithValue("@Calle", calle);
                comando.Parameters.AddWithValue("@Depto", depto);
                comando.Parameters.AddWithValue("@Piso", piso);
                comando.Parameters.AddWithValue("@Ciudad", ciudad);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Email", email);

                conexion.Open();

                int filasAfectadas =
                    comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }


        public bool Modificar(
            string dni,
            string apellido,
            string nombres,
            string calle,
            string depto,
            string piso,
            string ciudad,
            string telefono,
            string email)
        {
            string query = @"UPDATE contactos
                            SET Apellido = @Apellido,
                                Nombres = @Nombres,
                                Calle = @Calle,
                                Depto = @Depto,
                                Piso = @Piso,
                                Ciudad = @Ciudad,
                                Telefono = @Telefono,
                                Email = @Email
                            WHERE Dni = @Dni";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Nombres", nombres);
                comando.Parameters.AddWithValue("@Calle", calle);
                comando.Parameters.AddWithValue("@Depto", depto);
                comando.Parameters.AddWithValue("@Piso", piso);
                comando.Parameters.AddWithValue("@Ciudad", ciudad);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Email", email);

                conexion.Open();

                int filasAfectadas =
                    comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }


        public bool Eliminar(string dni)
        {
            string query =
                "DELETE FROM contactos WHERE Dni = @Dni";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue(
                    "@Dni",
                    dni
                );

                conexion.Open();

                int filasAfectadas =
                    comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }


        public DataTable BuscarPorDni(string dni)
        {
            string query =
                "SELECT * FROM contactos WHERE Dni = @Dni";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue(
                    "@Dni",
                    dni
                );

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(comando);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                return tabla;
            }
        }


        public DataTable BuscarPorApellido(
            string apellido)
        {
            string query =
                "SELECT * FROM contactos WHERE Apellido LIKE @Apellido";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue(
                    "@Apellido",
                    "%" + apellido + "%"
                );

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(comando);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                return tabla;
            }
        }


        public DataTable BuscarPorNombres(
            string nombres)
        {
            string query =
                "SELECT * FROM contactos WHERE Nombres LIKE @Nombres";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue(
                    "@Nombres",
                    "%" + nombres + "%"
                );

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(comando);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                return tabla;
            }
        }


        public DataTable BuscarPorCalle(
            string calle)
        {
            string query =
                "SELECT * FROM contactos WHERE Calle LIKE @Calle";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue(
                    "@Calle",
                    "%" + calle + "%"
                );

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(comando);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                return tabla;
            }
        }
    }
}