
var listaEmpleados = new List<Empleado>();
try
{
    Console.WriteLine("Ingrese un numero");
    int cantidadTrabajadores = Convert.ToInt32(Console.ReadLine());

    for (var i = 0; i < cantidadTrabajadores; i++)
    {
        Console.WriteLine("Ingrese el nombre");
        var nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el apellido");
        var apellido = Console.ReadLine();

        Console.WriteLine("Ingrese la dirección");
        var direccion = Console.ReadLine();

        Console.WriteLine("Ingrese el estado civil (1. Casado 2. Soltero)");
        var estadoCivil = Console.ReadLine().Equals("1") ? EstadoCivil.Casado : EstadoCivil.Soltero;

        Console.WriteLine("Ingrese cantidad de hijos");
        var cantidadHijos = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Tiene titulo universitario (1. Sí 2. No)");
        var tituloUniversitario = Console.ReadLine().Equals("1");

        Console.WriteLine("Universidad de la que se recibió");
        var universidadEgresada = Console.ReadLine();

        var empleado = new Empleado(nombre, apellido, direccion, cantidadHijos, estadoCivil, tituloUniversitario, universidadEgresada);
        listaEmpleados.Add(empleado);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

foreach (var empleado in listaEmpleados)
{
    Console.WriteLine(empleado.ToString());
}