public class Empleado
{

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public int CantidadHijos { get; set; }

    public DateTime FechaIngreso { get; set; }
    public DateTime FechaDivorcio { get; set; }
    public EstadoCivil EstadoCivil { get; set; }

    public int Antiguedad { get; set; }
    public int Edad { get; set; }
    public float Salario { get; set; }
    public bool TieneTitulo { get; set; }
    public string UniversidadEgresada { get; set; }

    private const float Descuento = 0.15f;

    public Empleado(string nombre, string apellido, string direccion, int cantidadHijos, EstadoCivil estadoCivil, bool tieneTitulo, string universidadEgresada)
    {
        Nombre = nombre;
        Apellido = apellido;
        Direccion = direccion;
        CantidadHijos = cantidadHijos;
        EstadoCivil = estadoCivil;
        TieneTitulo = tieneTitulo;
        UniversidadEgresada = universidadEgresada;
    }

    public Empleado(string nombre, string apellido, string direccion, int cantidadHijos, DateTime fechaIngreso,
        DateTime fechaDivorcio, EstadoCivil estadoCivil, int antiguedad, int edad, float salario)
    {
        Nombre = nombre;
        Apellido = apellido;
        Direccion = direccion;
        CantidadHijos = cantidadHijos;
        FechaIngreso = fechaIngreso;
        FechaDivorcio = fechaDivorcio;
        EstadoCivil = estadoCivil;
        Antiguedad = antiguedad;
        Edad = edad;
        Salario = salario;
    }

    public float CalcularSalario()
    {
        float adicional;

        switch (Antiguedad)
        {
            case <= 1:
                adicional = 1;
                break;
            case <= 2:
                adicional = 2;
                break;
            case <= 15:
                adicional = 15;
                break;
            default:
                adicional = 25;
                break;
        }

        return Salario + (Antiguedad * adicional) - (Descuento * Salario);
    }

    public override string ToString()
    {
        return "Nombre Completo: " + Apellido + " " + Nombre + "\n" +
               "Edad: " + Edad + ", " + "Antiguedad: " + Antiguedad + "\n" +
               "Salario: " + Salario;
    }
}