using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Alumno
{
    private int Id { get; set; }
    private string Nombre { get; set; }
    private string Apellido { get; set; }
    private int DNI { get; set; }
    public ListadoCursos Curso { get; set; }
    public Alumno(int id, string nombre, string apellido, int dNI, ListadoCursos curso)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        DNI = dNI;
        Curso = curso;
    }
    public string getInfo()
    {
        return $"{Id},{Apellido},{Nombre},{DNI}";
    }
}

