using Agenda.negocio;
using System;
using System.Data;

NegocioAgenda negocio =
    new NegocioAgenda();

int opcion = 0;

while (opcion != 5)
{
    Console.Clear();

    Console.WriteLine("===== AGENDA =====");
    Console.WriteLine("1 - Agregar");
    Console.WriteLine("2 - Buscar");
    Console.WriteLine("3 - Modificar");
    Console.WriteLine("4 - Eliminar");
    Console.WriteLine("5 - Salir");

    Console.Write("Opcion: ");

    int.TryParse(
        Console.ReadLine(),
        out opcion
    );

    switch (opcion)
    {
        case 1:
            Agregar();
            break;

        case 2:
            Buscar();
            break;

        case 3:
            Modificar();
            break;

        case 4:
            Eliminar();
            break;
    }
}


void Agregar()
{
    Console.Clear();

    Console.WriteLine("===== AGREGAR CONTACTO =====");

    Contacto contacto =
        CargarContacto();

    bool resultado =
        negocio.AgregarContacto(contacto);

    if (resultado)
        Console.WriteLine(
            "Contacto agregado correctamente"
        );
    else
        Console.WriteLine(
            "No se pudo agregar"
        );

    Pausa();
}



void Buscar()
{
    Console.Clear();

    Console.WriteLine("===== BUSCAR CONTACTO =====");
    Console.WriteLine();
    Console.WriteLine("BUSCAR POR:");
    Console.WriteLine("1 - DNI");
    Console.WriteLine("2 - Apellido");
    Console.WriteLine("3 - Nombres");
    Console.WriteLine("4 - Calle");

    Console.Write("Opcion: ");

    string opcion =
        Console.ReadLine();

    DataTable tabla = null;

    switch (opcion)
    {
        case "1":

            Console.Write("DNI: ");

            tabla =
                negocio.BuscarPorDni(
                    Console.ReadLine()
                );

            break;


        case "2":

            Console.Write(
                "Apellido: "
            );

            tabla =
                negocio.BuscarPorApellido(
                    Console.ReadLine()
                );

            break;


        case "3":

            Console.Write(
                "Nombres: "
            );

            tabla =
                negocio.BuscarPorNombres(
                    Console.ReadLine()
                );

            break;


        case "4":

            Console.Write(
                "Calle: "
            );

            tabla =
                negocio.BuscarPorCalle(
                    Console.ReadLine()
                );

            break;


        default:

            Console.WriteLine(
                "Opcion incorrecta"
            );

            Pausa();

            return;
    }


    if (tabla.Rows.Count == 0)
    {
        Console.WriteLine(
            "No se encontraron contactos"
        );
    }
    else
    {
        foreach (DataRow fila
                 in tabla.Rows)
        {
            MostrarContacto(fila);
        }
    }

    Pausa();
}



void Modificar()
{
    Console.Clear();

    Console.WriteLine("===== MODIFICAR CONTACTO =====");

   
    Console.Write(
        "Ingrese el DNI actual del contacto: "
    );

    string dniOriginal =
        Console.ReadLine();


    Console.WriteLine();
    Console.WriteLine(
        "Ingrese los nuevos datos"
    );

    Contacto contacto =
        CargarContacto();



    bool resultado =
        negocio.ModificarContacto(
            dniOriginal,
            contacto
        );


    if (resultado)
        Console.WriteLine(
            "Contacto modificado"
        );
    else
        Console.WriteLine(
            "No se pudo modificar"
        );

    Pausa();
}




void Eliminar()
{
    Console.Clear();

    Console.WriteLine("===== ELIMINAR CONTACTO =====");

    Console.Write(
        "Ingrese DNI: "
    );

    string dni =
        Console.ReadLine();

    bool resultado =
        negocio.EliminarContacto(dni);

    if (resultado)
        Console.WriteLine(
            "Contacto eliminado"
        );
    else
        Console.WriteLine(
            "No se pudo eliminar"
        );

    Pausa();
}



Contacto CargarContacto()
{
    Contacto contacto =
        new Contacto();


    Console.Write("DNI: ");
    contacto.Dni =
        Console.ReadLine();

    Console.Write("Apellido: ");
    contacto.Apellido =
        Console.ReadLine();

    Console.Write("Nombres: ");
    contacto.Nombres =
        Console.ReadLine();

    Console.Write("CUIL/CUIT: ");
    contacto.CuilCuit =
        Console.ReadLine();

    Console.Write("Estado Civil: ");
    contacto.EstadoCivil =
        Console.ReadLine();

    Console.Write("Nacionalidad: ");
    contacto.Nacionalidad =
        Console.ReadLine();


    Console.Write("Calle: ");
    contacto.Calle =
        Console.ReadLine();

    Console.Write("Depto: ");
    contacto.Depto =
        Console.ReadLine();

    Console.Write("Piso: ");
    contacto.Piso =
        Console.ReadLine();

    Console.Write("Ciudad: ");
    contacto.Ciudad =
        Console.ReadLine();

    Console.Write("Provincia: ");
    contacto.Provincia =
        Console.ReadLine();

    Console.Write("Codigo Postal: ");
    contacto.CodigoPostal =
        Console.ReadLine();

    Console.Write("Barrio: ");
    contacto.Barrio =
        Console.ReadLine();


    Console.Write("Telefono: ");
    contacto.Telefono =
        Console.ReadLine();

    Console.Write("Telefono Alternativo: ");
    contacto.TelefonoAlternativo =
        Console.ReadLine();

    Console.Write("Email: ");
    contacto.Email =
        Console.ReadLine();

    Console.Write("Instagram: ");
    contacto.Instagram =
        Console.ReadLine();



    Console.Write("Profesion/Ocupacion: ");
    contacto.ProfesionOcupacion =
        Console.ReadLine();

    Console.Write("Empresa/Lugar de Trabajo: ");
    contacto.EmpresaLugarTrabajo =
        Console.ReadLine();

    Console.Write("Nivel de Estudios: ");
    contacto.NivelEstudios =
        Console.ReadLine();



    Console.Write("Estado (Activo/Inactivo): ");
    contacto.Estado =
        Console.ReadLine();

    Console.Write("Metodo de Pago Preferido: ");
    contacto.MetodoPagoPreferido =
        Console.ReadLine();

    Console.Write("Observaciones/Notas: ");
    contacto.Observaciones =
        Console.ReadLine();



    Console.Write(
        "Fecha de Alta (dd/mm/aaaa): "
    );

    DateTime fechaAlta;

    while (!DateTime.TryParse(
        Console.ReadLine(),
        out fechaAlta))
    {
        Console.Write(
            "Fecha incorrecta. Ingrese nuevamente (dd/mm/aaaa): "
        );
    }

    contacto.FechaAlta =
        fechaAlta;




    Console.WriteLine();
    Console.WriteLine("===== DATOS DE CUENTA CORRIENTE =====");

    Console.Write(
        "Fecha de Apertura (dd/mm/aaaa): "
    );

    DateTime fechaApertura;

    while (!DateTime.TryParse(
        Console.ReadLine(),
        out fechaApertura))
    {
        Console.Write(
            "Fecha incorrecta. Ingrese nuevamente (dd/mm/aaaa): "
        );
    }

    contacto.FechaApertura =
        fechaApertura;


    Console.Write(
        "Limite de Credito: "
    );

    decimal limiteCredito;

    while (!decimal.TryParse(
        Console.ReadLine(),
        out limiteCredito))
    {
        Console.Write(
            "Valor incorrecto. Ingrese nuevamente: "
        );
    }

    contacto.LimiteCredito =
        limiteCredito;


    Console.Write(
        "Estado de Credito (Activo/Suspendido): "
    );

    contacto.EstadoCredito =
        Console.ReadLine();


    return contacto;
}


void MostrarContacto(DataRow fila)
{
    Console.WriteLine();
    Console.WriteLine(
        "------------------------"
    );

    Console.WriteLine(
        "DNI: " +
        fila["Dni"]
    );

    Console.WriteLine(
        "Apellido: " +
        fila["Apellido"]
    );

    Console.WriteLine(
        "Nombres: " +
        fila["Nombres"]
    );

    Console.WriteLine(
        "CUIL/CUIT: " +
        fila["CuilCuit"]
    );

    Console.WriteLine(
        "Fecha de Alta: " +
        fila["FechaAlta"]
    );

    Console.WriteLine(
        "Estado Civil: " +
        fila["EstadoCivil"]
    );

    Console.WriteLine(
        "Nacionalidad: " +
        fila["Nacionalidad"]
    );

    Console.WriteLine(
        "Calle: " +
        fila["Calle"]
    );

    Console.WriteLine(
        "Depto: " +
        fila["Depto"]
    );

    Console.WriteLine(
        "Piso: " +
        fila["Piso"]
    );

    Console.WriteLine(
        "Ciudad: " +
        fila["Ciudad"]
    );

    Console.WriteLine(
        "Provincia: " +
        fila["Provincia"]
    );

    Console.WriteLine(
        "Codigo Postal: " +
        fila["CodigoPostal"]
    );

    Console.WriteLine(
        "Barrio: " +
        fila["Barrio"]
    );

    Console.WriteLine(
        "Telefono: " +
        fila["Telefono"]
    );

    Console.WriteLine(
        "Telefono Alternativo: " +
        fila["TelefonoAlternativo"]
    );

    Console.WriteLine(
        "Email: " +
        fila["Email"]
    );

    Console.WriteLine(
        "Instagram: " +
        fila["Instagram"]
    );

    Console.WriteLine(
        "Profesion/Ocupacion: " +
        fila["ProfesionOcupacion"]
    );

    Console.WriteLine(
        "Empresa/Lugar de Trabajo: " +
        fila["EmpresaLugarTrabajo"]
    );

    Console.WriteLine(
        "Nivel de Estudios: " +
        fila["NivelEstudios"]
    );

    Console.WriteLine(
        "Estado: " +
        fila["Estado"]
    );

    Console.WriteLine(
        "Metodo de Pago Preferido: " +
        fila["MetodoPagoPreferido"]
    );

    Console.WriteLine(
        "Observaciones/Notas: " +
        fila["Observaciones"]
    );

    Console.WriteLine(
        "Fecha de Apertura: " +
        fila["FechaApertura"]
    );

    Console.WriteLine(
        "Limite de Credito: " +
        fila["LimiteCredito"]
    );

    Console.WriteLine(
        "Estado de Credito: " +
        fila["EstadoCredito"]
    );

    Console.WriteLine(
        "------------------------"
    );
}

void Pausa()
{
    Console.WriteLine();
    Console.WriteLine(
        "Presione una tecla..."
    );

    Console.ReadKey();
}

