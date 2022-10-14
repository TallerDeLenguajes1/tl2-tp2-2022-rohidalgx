using System;
public static class Program
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public static void Main(string[] args)
    {
        var listaEmpleados = new List<Empleado>();

        try
        {
            Console.WriteLine("Ingrese la cantidad de empleados");
            int cantidadTrabajadores = Convert.ToInt32(Console.ReadLine());

            Logger.Debug("Input succeeded");

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

                var empleado = new Empleado(nombre, apellido, direccion, cantidadHijos, estadoCivil,
                    tituloUniversitario, universidadEgresada);
                listaEmpleados.Add(empleado);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main failed");
        }

        foreach (var empleado in listaEmpleados)
        {
            Console.WriteLine(empleado.ToString());
        }

        Logger.Info("Main succeeded");
    }
}