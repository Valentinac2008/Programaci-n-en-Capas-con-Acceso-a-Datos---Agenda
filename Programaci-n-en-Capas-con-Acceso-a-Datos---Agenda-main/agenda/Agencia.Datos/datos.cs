using MySql.Data.MySqlClient;
using System.Data;

namespace Agenda.Datos
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
            string email,
            DateTime fechaApertura,
            decimal limiteCredito,
            string estadoCredito)
        {
            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                conexion.Open();

                MySqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    string queryPersona = @"
                        INSERT INTO contactos
                        (Dni, Apellido, Nombres, Calle, Depto,
                         Piso, Ciudad, Telefono, Email)
                        VALUES
                        (@Dni, @Apellido, @Nombres, @Calle, @Depto,
                         @Piso, @Ciudad, @Telefono, @Email)";

                    MySqlCommand comandoPersona =
                        new MySqlCommand(
                            queryPersona,
                            conexion,
                            transaccion
                        );

                    comandoPersona.Parameters.AddWithValue("@Dni", dni);
                    comandoPersona.Parameters.AddWithValue("@Apellido", apellido);
                    comandoPersona.Parameters.AddWithValue("@Nombres", nombres);
                    comandoPersona.Parameters.AddWithValue("@Calle", calle);
                    comandoPersona.Parameters.AddWithValue("@Depto", depto);
                    comandoPersona.Parameters.AddWithValue("@Piso", piso);
                    comandoPersona.Parameters.AddWithValue("@Ciudad", ciudad);
                    comandoPersona.Parameters.AddWithValue("@Telefono", telefono);
                    comandoPersona.Parameters.AddWithValue("@Email", email);

                    comandoPersona.ExecuteNonQuery();

                    long idPersona =
                        comandoPersona.LastInsertedId;


                    string queryCuenta = @"
                        INSERT INTO CuentaCte
                        (IdPersona, FechaApertura,
                         LimiteCredito, EstadoCredito)
                        VALUES
                        (@IdPersona, @FechaApertura,
                         @LimiteCredito, @EstadoCredito)";

                    MySqlCommand comandoCuenta =
                        new MySqlCommand(
                            queryCuenta,
                            conexion,
                            transaccion
                        );

                    comandoCuenta.Parameters.AddWithValue(
                        "@IdPersona",
                        idPersona
                    );

                    comandoCuenta.Parameters.AddWithValue(
                        "@FechaApertura",
                        fechaApertura
                    );

                    comandoCuenta.Parameters.AddWithValue(
                        "@LimiteCredito",
                        limiteCredito
                    );

                    comandoCuenta.Parameters.AddWithValue(
                        "@EstadoCredito",
                        estadoCredito
                    );

                    comandoCuenta.ExecuteNonQuery();

                    transaccion.Commit();

                    return true;
                }
                catch
                {
                    transaccion.Rollback();

                    return false;
                }
            }
        }



        public DataTable BuscarPorDni(string dni)
        {
            string query = @"
                SELECT contactos.*,
                       CuentaCte.IdCuentaCte,
                       CuentaCte.FechaApertura,
                       CuentaCte.LimiteCredito,
                       CuentaCte.EstadoCredito

                FROM contactos

                LEFT JOIN CuentaCte
                ON contactos.IdPersona = CuentaCte.IdPersona

                WHERE contactos.Dni = @Dni";

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



        public DataTable BuscarPorApellido(string apellido)
        {
            string query = @"
                SELECT contactos.*,
                       CuentaCte.IdCuentaCte,
                       CuentaCte.FechaApertura,
                       CuentaCte.LimiteCredito,
                       CuentaCte.EstadoCredito

                FROM contactos

                LEFT JOIN CuentaCte
                ON contactos.IdPersona = CuentaCte.IdPersona

                WHERE contactos.Apellido LIKE @Apellido";

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



        public DataTable BuscarPorNombres(string nombres)
        {
            string query = @"
                SELECT contactos.*,
                       CuentaCte.IdCuentaCte,
                       CuentaCte.FechaApertura,
                       CuentaCte.LimiteCredito,
                       CuentaCte.EstadoCredito

                FROM contactos

                LEFT JOIN CuentaCte
                ON contactos.IdPersona = CuentaCte.IdPersona

                WHERE contactos.Nombres LIKE @Nombres";

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



        public DataTable BuscarPorCalle(string calle)
        {
            string query = @"
                SELECT contactos.*,
                       CuentaCte.IdCuentaCte,
                       CuentaCte.FechaApertura,
                       CuentaCte.LimiteCredito,
                       CuentaCte.EstadoCredito

                FROM contactos

                LEFT JOIN CuentaCte
                ON contactos.IdPersona = CuentaCte.IdPersona

                WHERE contactos.Calle LIKE @Calle";

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



        public bool Modificar(
            string dniOriginal,
            string dniNuevo,
            string apellido,
            string nombres,
            string calle,
            string depto,
            string piso,
            string ciudad,
            string telefono,
            string email,
            DateTime fechaApertura,
            decimal limiteCredito,
            string estadoCredito)
        {
            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                conexion.Open();

                MySqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    string buscarId = @"
                        SELECT IdPersona
                        FROM contactos
                        WHERE Dni = @DniOriginal";

                    MySqlCommand comandoBuscar =
                        new MySqlCommand(
                            buscarId,
                            conexion,
                            transaccion
                        );

                    comandoBuscar.Parameters.AddWithValue(
                        "@DniOriginal",
                        dniOriginal
                    );

                    object resultado =
                        comandoBuscar.ExecuteScalar();

                    if (resultado == null)
                    {
                        transaccion.Rollback();
                        return false;
                    }

                    int idPersona =
                        Convert.ToInt32(resultado);


                    string queryPersona = @"
                        UPDATE contactos
                        SET
                            Dni = @DniNuevo,
                            Apellido = @Apellido,
                            Nombres = @Nombres,
                            Calle = @Calle,
                            Depto = @Depto,
                            Piso = @Piso,
                            Ciudad = @Ciudad,
                            Telefono = @Telefono,
                            Email = @Email
                        WHERE IdPersona = @IdPersona";

                    MySqlCommand comandoPersona =
                        new MySqlCommand(
                            queryPersona,
                            conexion,
                            transaccion
                        );

                    comandoPersona.Parameters.AddWithValue(
                        "@IdPersona",
                        idPersona
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@DniNuevo",
                        dniNuevo
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Apellido",
                        apellido
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Nombres",
                        nombres
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Calle",
                        calle
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Depto",
                        depto
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Piso",
                        piso
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Ciudad",
                        ciudad
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Telefono",
                        telefono
                    );

                    comandoPersona.Parameters.AddWithValue(
                        "@Email",
                        email
                    );

                    comandoPersona.ExecuteNonQuery();


                    string queryCuenta = @"
                        UPDATE CuentaCte
                        SET
                            FechaApertura = @FechaApertura,
                            LimiteCredito = @LimiteCredito,
                            EstadoCredito = @EstadoCredito
                        WHERE IdPersona = @IdPersona";

                    MySqlCommand comandoCuenta =
                        new MySqlCommand(
                            queryCuenta,
                            conexion,
                            transaccion
                        );

                    comandoCuenta.Parameters.AddWithValue(
                        "@IdPersona",
                        idPersona
                    );

                    comandoCuenta.Parameters.AddWithValue(
                        "@FechaApertura",
                        fechaApertura
                    );

                    comandoCuenta.Parameters.AddWithValue(
                        "@LimiteCredito",
                        limiteCredito
                    );

                    comandoCuenta.Parameters.AddWithValue(
                        "@EstadoCredito",
                        estadoCredito
                    );

                    comandoCuenta.ExecuteNonQuery();

                    transaccion.Commit();

                    return true;
                }
                catch
                {
                    transaccion.Rollback();

                    return false;
                }
            }
        }
    }
}