using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA19
{
    class Principal4
    {
        static void Main1()
        {
            Console.WriteLine("PROCESO DE MIGRAR ARCHIVO CSV A JSON");
            List<string> listaFilasCsv = obtenerTodasFilasArchivoCsv();
            List<Dictionary<string, object>> listaDeDiccionarios = obtenerListaDeDiccionarios(listaFilasCsv);
            if (crearArchivoJson(listaDeDiccionarios))
            {
                Console.WriteLine("OK: CREAR ARCHIVO JSON");
            }
            else
            {
                Console.WriteLine("ERROR: CREAR ARCHIVO JSON");
            }
        }

        static List<string> obtenerTodasFilasArchivoCsv()
        {
            string ruta_relativa = "data/Estetica.csv";
            string ruta_absoluta = Path.GetFullPath(ruta_relativa);

            List<string> estetica = new List<string>();
            StreamReader sr = new StreamReader(ruta_absoluta);
            string fila = "";
            int i = 0;
            while ((fila = sr.ReadLine()) != null)
            {
                if (i != 0)
                {
                    estetica.Add(fila);
                }
                i++;
            }
            return estetica;
        }

        static List<Dictionary<string, object>> obtenerListaDeDiccionarios(List<string> listaFilasCsv)
        {
            List<Dictionary<string, object>> listaDeDiccionarios = new List<Dictionary<string, object>>();
            Dictionary<string, object> estetica_dic;

            foreach (string fila in listaFilasCsv)
            {
                string[] partes = fila.Split(';');

                estetica_dic = new Dictionary<string, object>();
                estetica_dic["id"] = partes[0];
                estetica_dic["fecha"] = partes[1];
                estetica_dic["categoria"] = partes[2];
                estetica_dic["tratamiento"] = partes[3];
                estetica_dic["esteticista"] = partes[4];
                estetica_dic["precio"] = partes[5];
                estetica_dic["descuento"] = partes[6];

                listaDeDiccionarios.Add(estetica_dic);
            }
            return listaDeDiccionarios;
        }

        static bool crearArchivoJson(List<Dictionary<string, object>> listaDeDiccionarios)
        {
            bool bandera = true;
            try
            {
                Console.WriteLine("Datos:");
                foreach (var item in listaDeDiccionarios)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
                }

                string ruta_relativa = @"data/Estetica.json";

                using (StreamWriter sw = new StreamWriter(ruta_relativa))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(listaDeDiccionarios, Formatting.Indented));
                }

                Console.WriteLine("OK: ESCRIBIR");

            }
            catch (Exception e)
            {
                bandera = false;
            }
            return bandera;
        }
    }
}