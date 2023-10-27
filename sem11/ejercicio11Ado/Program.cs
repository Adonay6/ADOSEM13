//using ejercicio11Ado;

//using (var contextdb = new Context())
//{
//    foreach (var item in contextdb.Estudiante)
//    {
//        Console.WriteLine($"Datos: Id: {item.Id}, Nombre: {item.Nombres}, Apellidos: {item.Apellidos}, Edad: {item.Edad}, Sexo: {item.Sexo}");

//    }
//}

//bool agregarMasRegistros = true;

//while (agregarMasRegistros)
//{
//    Console.WriteLine("Ingrese los datos del estudiante:");

//    Console.Write("Nombre: ");
//    string nombre = Console.ReadLine();

//    Console.Write("Apellidos: ");
//    string apellidos = Console.ReadLine();

//    Console.Write("Sexo: ");
//    string sexo = Console.ReadLine();

//    Console.Write("Edad: ");
//    int edad = Convert.ToInt32(Console.ReadLine());

//    using (var contextdb = new Context())
//    {
//        contextdb.Database.EnsureCreated();

//        var nuevoEstudiante = new Estudiante()
//        {
//            Nombres = nombre,
//            Apellidos = apellidos,
//            Sexo = sexo,
//            Edad = edad
//        };

//        contextdb.Add(nuevoEstudiante);
//        contextdb.SaveChanges();
//    }

//    Console.WriteLine("¿Desea agregar más registros? (Sí/No)");
//    string respuesta = Console.ReadLine();
//    agregarMasRegistros = respuesta.StartsWith("S", StringComparison.OrdinalIgnoreCase);
//}

//using (var contextdb = new Context())
//{
//    foreach (var estudiante in contextdb.Estudiante)
//    {
//        Console.WriteLine($"Estudiante: {estudiante.Nombres} {estudiante.Apellidos}, Sexo: {estudiante.Sexo}, Edad: {estudiante.Edad}");
//    }
//}


using ejercicio11Ado;

while (true)
{
    Console.Clear();
    Console.WriteLine("Menú Principal:");
    Console.WriteLine("1. Mostrar Estudiantes");
    Console.WriteLine("2. Agregar Estudiante");
    Console.WriteLine("3. Modificar Estudiante");
    Console.WriteLine("4. Eliminar Estudiante");
    Console.WriteLine("5. Salir");

    int opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            MostrarEstudiantes();
            break;
        case 2:
            AgregarEstudiante();
            break;
        case 3:
            ModificarEstudiante();
            break;
        case 4:
            EliminarEstudiante();
            break;
        case 5:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor seleccione una opción válida.");
            break;
    }
}


static void MostrarEstudiantes()
{
    Console.Clear();
    using (var context = new Context())
    {
        foreach (var estudiante in context.Estudiante)
        {
            Console.WriteLine($"Datos: Id: {estudiante.Id}, Nombre: {estudiante.Nombres}, Apellidos: {estudiante.Apellidos}, Edad: {estudiante.Edad}, Sexo: {estudiante.Sexo}");
        }
    }
    Console.WriteLine("Presione enter para continuar");
    Console.ReadLine();
}

static void AgregarEstudiante()
{
    Console.Clear();
    Console.WriteLine("Agregar Estudiante");
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();
    Console.Write("Apellidos: ");
    string apellidos = Console.ReadLine();
    Console.Write("Sexo: ");
    string sexo = Console.ReadLine();
    Console.Write("Edad: ");
    int edad = Convert.ToInt32(Console.ReadLine());

    using (var context = new Context())
    {
        context.Database.EnsureCreated();

        var nuevoEstudiante = new Estudiante()
        {
            Nombres = nombre,
            Apellidos = apellidos,
            Sexo = sexo,
            Edad = edad
        };

        context.Estudiante.Add(nuevoEstudiante);
        context.SaveChanges();
    }

    Console.WriteLine("Estudiante agregado exitosamente, Presione enter para continuar.");
    Console.ReadLine();
}

static void ModificarEstudiante()
{
    Console.Clear();
    Console.Write("ID del estudiante a modificar: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var context = new Context())
    {
        var estudiante = context.Estudiante.SingleOrDefault(e => e.Id == id);

        if (estudiante != null)
        {
            Console.WriteLine("Estudiante actual:");
            Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombres}, Apellidos: {estudiante.Apellidos}, Edad: {estudiante.Edad}, Sexo: {estudiante.Sexo}");
            Console.WriteLine("¿Qué atributo desea modificar?");
            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Apellidos");
            Console.WriteLine("3. Edad");
            Console.WriteLine("4. Sexo");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nuevo nombre: ");
                    estudiante.Nombres = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nuevos apellidos: ");
                    estudiante.Apellidos = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Nueva edad: ");
                    estudiante.Edad = Convert.ToInt32(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Nuevo sexo: ");
                    estudiante.Sexo = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            context.SaveChanges();
            Console.WriteLine("Estudiante modificado exitosamente, Presione enter para continuar.");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    Console.ReadLine();
}

static void EliminarEstudiante()
{
    Console.Clear();
    Console.WriteLine("Eliminar Estudiante");
    Console.Write("ID del estudiante a eliminar: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var context = new Context())
    {
        var estudiante = context.Estudiante.SingleOrDefault(e => e.Id == id);

        if (estudiante != null)
        {
            context.Estudiante.Remove(estudiante);
            context.SaveChanges();
            Console.WriteLine("Estudiante eliminado exitosamente. Presione enter para continuar");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    Console.ReadLine();
}