using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA09
{
    class Principal4
    {
        static void Main1(string[] args)
        {
            string opcion;
            do
            {
                Cls();
                Console.Write("Ingrese tipo de trabajador? ");
                int tipo = int.Parse(Console.ReadLine());
                leerArchivoCsv(tipo);

                Console.Write("Desea continuar S/N? ");
                opcion = Console.ReadLine();
            } while (opcion == "S");
            Console.WriteLine("ADIOS. GRACIAS POR SU VISITA");
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

        public static void leerArchivoCsv(int tipo)
        {
            try
            {
                string rutaRelativa = "data/trabajador.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
                Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
                string fila = "";

                List<String> trabajadores = new List<String>();

                using (StreamReader sr = new StreamReader(rutaAbsoluta))
                {
                    string[] partes;
                    int c = 0;
                    cabecera();
                    while ((fila = sr.ReadLine()) != null)
                    {
                        partes = fila.Split(';');
                        if (int.Parse(partes[3]) == tipo)
                        {
                            cuerpo(fila);
                            //escrbirArchivoCsv(fila);
                            trabajadores.Add(fila);
                            c++;
                        }
                    }
                    Console.WriteLine($"Cantidad de trabajadores tipo {tipo} es {c}");
                    escribirArchivoCsv1(trabajadores);
                    Console.WriteLine("FIN DE LECTURA");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: LECTURA " + e.Message);
            }
        }

        public static void escrbirArchivoCsv(string fila) //NO ES EFICIENTE
        {
            try
            {
                string rutaRelativa = "data/tipotrabajador.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
                Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);

                StreamWriter sw = new StreamWriter(rutaAbsoluta, true);
                sw.WriteLine(fila);
                if (sw != null)
                {
                    sw.Close();
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: ESCRITURA " + e.Message);
            }
        }

        public static void escribirArchivoCsv1(List<String> trabajadores) //ESTO ES MAS EFICIENTE
        {
            try
            {
                string rutaRelativa = "data/tipotrabajador.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
                Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);

                StreamWriter sw = new StreamWriter(rutaAbsoluta);

                foreach (String fila in trabajadores)
                {
                    sw.WriteLine(fila);
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: ESCRITURA " + e.Message);
            }
        }

        public static void Cls()
        {
            Console.Clear();
        }

    }
}