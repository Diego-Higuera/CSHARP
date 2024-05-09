using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA09
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            try
            {
                string rutaRelativa = "data/trabajador.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
                Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
                string fila = "";

                using (StreamReader sr = new StreamReader(rutaAbsoluta))
                {
                    while ((fila = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(fila);
                    }
                    Console.WriteLine("FIN DE LECTURA");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: LECTURA " + e.Message);
            }
        }
    }
}