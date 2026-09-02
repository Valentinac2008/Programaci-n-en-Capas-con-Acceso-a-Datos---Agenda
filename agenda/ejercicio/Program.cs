using Agenda.negocio;

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
    Console.WriteLine(
        "Ingrese los nuevos datos"
    );

    Contacto contacto =
        CargarContacto();

    bool resultado =
        negocio.ModificarContacto(
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

    Console.Write("Telefono: ");
    contacto.Telefono =
        Console.ReadLine();

    Console.Write("Email: ");
    contacto.Email =
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
        "Telefono: " +
        fila["Telefono"]
    );

    Console.WriteLine(
        "Email: " +
        fila["Email"]
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