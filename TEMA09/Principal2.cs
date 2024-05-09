using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA09
{
    class Principal2
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
                    cabecera();
                    while ((fila = sr.ReadLine()) != null)
                    {
                        cuerpo(fila);
                    }
                    Console.WriteLine("FIN DE LECTURA");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: LECTURA " + e.Message);
            }
        }

        public static void cabecera()
        {
            Console.WriteLine("{0,-13} {1,-15} {2,-15} {3,4} {4,10}", "IDENTIFICADOR", "NOMBRE", "PATERNO", "TIPO", "PARAMETROS");
            Console.WriteLine("{0,-13} {1,-15} {2,-15} {3,4} {4,10}", "-------------", "------", "-------", "----", "----------");
        }

        public static void cuerpo(string fila)
        {
            string[] partes = fila.Split(';');
            Console.WriteLine("{0,-13} {1,-15} {2,-15} {3,4} {4,10}", partes[0], partes[1], partes[2], partes[3], partes[4]);
        }

    }
}