// See https://aka.ms/new-console-template for more information

using System;

static class Program
{
    static private NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    static List<Alumno> ListaDeAlumnos = new List<Alumno>();
    static public int Main(string[] args)
    {
        Mensajes.Titulo("BIENVENIDO");
        int opcion;
        do
        {
            Mensajes.TerminarLinea("MENU");
            Console.WriteLine("\t[1] Alta de alumnos");
            Console.WriteLine("\t[2] Borrar una lista");
            Console.WriteLine("\t[3] Eliminar todos los alumnos");
            Console.WriteLine("\t[4] Salir");
            Console.Write("Su opción: ");
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Opción inválida en el menú");
                opcion = -1;
            }
            switch (opcion)
            {
                case 1:
                    Logger.Info("Menú seleccion alta de alumnos");
                    Mensajes.TerminarLinea("Alta de alumnos");
                    CargarAlumnos(ListaDeAlumnos);
                    GenerarArchivos(ListaDeAlumnos);
                    break;
                case 2:
                    Logger.Info("Menú seleccion borrar una lista");
                    Mensajes.TerminarLinea("Borrar una lista");
                    ListadoCursos curso = SeleccionarCurso();
                    HelperDeArchivos.LimpiarArchivo(curso + ".csv");
                    Console.WriteLine($"Lista {curso} borrada");
                    break;
                case 3:
                    Logger.Info("Menú seleccion eliminar todos los alumnos");
                    Mensajes.TerminarLinea("Eliminar todos los alumnos");
                    HelperDeArchivos.LimpiarArchivos();
                    ListaDeAlumnos.Clear();
                    Console.WriteLine("Listados borrados");
                    break;
                case 4:
                    Logger.Info("Menú seleccion salir");
                    Console.WriteLine("\nGracias por utilizar el programa.\n");
                    break;
                default:
                    Logger.Info("Menú seleccion incorrecta");
                    Console.WriteLine("Opción no válida. Intente de nuevo");
                    break;
            }
        } while (opcion != 4);
        Logger.Info("Programa finalizado");
        return 0;
    }

    static void CargarAlumnos(List<Alumno> ListaDeAlumnos)
    {
        Logger.Info("Ingreso a la carga de alumnos");
        bool seguir = true;
        do
        {
            try
            {
                Console.Write("Ingrese la cantidad de alumnos a cargar: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= cantidad; i++)
                {
                    Console.WriteLine($"\nAlumno [{i}]:");
                    Alumno alumno = CargarAlumno(ListaDeAlumnos.Count() + 1);
                    ListaDeAlumnos.Add(alumno);
                }
                Console.WriteLine("\nFin de la carga.");
                seguir = false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Cantidad incorrecta de alumnos a dar de alta");
                Console.WriteLine("ERROR: El número ingresado no es válido. Intente nuevamente");
            }
        } while (seguir);
    }

    static Alumno CargarAlumno(int id)
    {
        do
        {
            Logger.Info("Cargando 1 alumno");
            try
            {
                Console.Write("Ingrese el apellido: ");
                string apellido = Console.ReadLine();
                Console.Write("Ingrese el nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese el DNI: ");
                int dni = Convert.ToInt32(Console.ReadLine());
                ListadoCursos curso = SeleccionarCurso();
                return new Alumno(id, nombre, apellido, dni, curso);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "DNI ingresado incorrectamente");
                Console.WriteLine("ERROR: DNI no válido. Ingrese nuevamente");
            }
        } while (true);
    }

    static ListadoCursos SeleccionarCurso()
    {
        ListadoCursos curso = ListadoCursos.Error;
        do
        {
            Logger.Info("Selección de curso");
            Console.Write("Ingrese el curso [1]Atletismo | [2]Voley | [3]Futbol: ");
            try
            {
                int numero = Convert.ToInt32(Console.ReadLine());
                switch (numero)
                {
                    case 1: curso = ListadoCursos.Atletismo; break;
                    case 2: curso = ListadoCursos.Voley; break;
                    case 3: curso = ListadoCursos.Futbol; break;
                    default: curso = ListadoCursos.Error; Console.WriteLine("ERROR: El curso ingresado no es válido"); break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error al seleccionar el curso");
            }
        } while (curso == ListadoCursos.Error);
        return curso;
    }

    static void GenerarArchivos(List<Alumno> ListaDeAlumnos)
    {
        HelperDeArchivos.LimpiarArchivos();
        foreach (Alumno alumno in ListaDeAlumnos)
        {
            string curso = alumno.Curso.ToString();
            HelperDeArchivos.EscribirLineaEnArchivo(curso + ".csv", alumno.getInfo());
        }
    }
}