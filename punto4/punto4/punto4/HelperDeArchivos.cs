using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HelperDeArchivos
{
    public static void LimpiarArchivo(string NombreDelArchivo)
    {
        if (File.Exists(NombreDelArchivo))
        {
            using (var FS = new FileStream(NombreDelArchivo, FileMode.Truncate))
            {
            }
        }
    }

    public static void LimpiarArchivos()
    {
        foreach (ListadoCursos curso in Enum.GetValues(typeof(ListadoCursos)))
        {
            LimpiarArchivo(curso + ".csv");
        }
    }

    public static void EscribirLineaEnArchivo(string NombreDelArchivo, string TextoAGuardar) //SIMEPRE AGREGA. NO BORRA LO ANTERIOR
    {
        using (TextWriter TW = File.AppendText(NombreDelArchivo))
        {
            TW.WriteLine(TextoAGuardar);
            TW.Close();
        }
    }
}

