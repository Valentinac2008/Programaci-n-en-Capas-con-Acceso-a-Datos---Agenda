using Agenda.Datos;
using System.Data;

namespace Agenda.negocio
{
    public class Contacto
    {
        public string Dni { get; set; }

        public string Apellido { get; set; }

        public string Nombres { get; set; }

        public string Calle { get; set; }

        public string Depto { get; set; }

        public string Piso { get; set; }

        public string Ciudad { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }


        public DateTime FechaApertura { get; set; }

        public decimal LimiteCredito { get; set; }

        public string EstadoCredito { get; set; }
    }


    public class NegocioAgenda
    {
        private DatosAgenda _datos =
            new DatosAgenda();



        public bool AgregarContacto(
            Contacto contacto)
        {
            if (contacto == null)
                return false;

            if (string.IsNullOrWhiteSpace(
                contacto.Dni))
                return false;

            if (string.IsNullOrWhiteSpace(
                contacto.Apellido))
                return false;

            if (string.IsNullOrWhiteSpace(
                contacto.Nombres))
                return false;

            if (contacto.LimiteCredito < 0)
                return false;

            if (contacto.EstadoCredito != "Activo" &&
                contacto.EstadoCredito != "Suspendido")
                return false;


            return _datos.Agregar(
                contacto.Dni,
                contacto.Apellido,
                contacto.Nombres,
                contacto.Calle,
                contacto.Depto,
                contacto.Piso,
                contacto.Ciudad,
                contacto.Telefono,
                contacto.Email,
                contacto.FechaApertura,
                contacto.LimiteCredito,
                contacto.EstadoCredito
            );
        }



        public DataTable BuscarPorDni(
            string dni)
        {
            return _datos.BuscarPorDni(dni);
        }



        public DataTable BuscarPorApellido(
            string apellido)
        {
            return _datos.BuscarPorApellido(
                apellido
            );
        }



        public DataTable BuscarPorNombres(
            string nombres)
        {
            return _datos.BuscarPorNombres(
                nombres
            );
        }



        public DataTable BuscarPorCalle(
            string calle)
        {
            return _datos.BuscarPorCalle(
                calle
            );
        }



        public bool EliminarContacto(
            string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;

            return _datos.Eliminar(dni);
        }



        public bool ModificarContacto(
            string dniOriginal,
            Contacto contacto)
        {
            if (contacto == null)
                return false;

            if (string.IsNullOrWhiteSpace(
                dniOriginal))
                return false;

            if (string.IsNullOrWhiteSpace(
                contacto.Dni))
                return false;

            if (string.IsNullOrWhiteSpace(
                contacto.Apellido))
                return false;

            if (string.IsNullOrWhiteSpace(
                contacto.Nombres))
                return false;

            if (contacto.LimiteCredito < 0)
                return false;

            if (contacto.EstadoCredito != "Activo" &&
                contacto.EstadoCredito != "Suspendido")
                return false;


            return _datos.Modificar(
                dniOriginal,
                contacto.Dni,
                contacto.Apellido,
                contacto.Nombres,
                contacto.Calle,
                contacto.Depto,
                contacto.Piso,
                contacto.Ciudad,
                contacto.Telefono,
                contacto.Email,
          