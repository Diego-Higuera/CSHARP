using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient; // File

namespace PROYECTOCSHARP.TEMA20.ejemplo2
{
    class Principal1
    {
        static void Main1()
        {
            Console.WriteLine("EJEMPLO 1: LISTA CON DISTINTOS Y ORDENADA");
            SortedSet<string> lista_distintos_ordenada = new SortedSet<string>();

            lista_distintos_ordenada.Add("Viajar");
            lista_distintos_ordenada.Add("Viajar");
            lista_distintos_ordenada.Add("Leer");

            foreach (string s in lista_distintos_ordenada)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("EJEMPLO 2: LISTA");
            List<string> lista = new List<string>();

            lista.Add("Viajar");
            lista.Add("Viajar");
            lista.Add("Leer");

            foreach (string s in lista)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("EJEMPLO 3: LISTA");
            Console.WriteLine(string.Join(", ", lista));

            string ruta_relativa = "data/Empleados2.json";
            SortedSet<string> lista_hobbies = ObtenerListaHobbiesDistintos(ruta_relativa);
            InsertarHobbiesDisintosTablaHobby(lista_hobbies);

        }

        public static SortedSet<string> ObtenerListaHobbiesDistintos(string ruta_relativa)
        {
            SortedSet<string> hobbies_distintos = new SortedSet<string>();
            try
            {
                string json = File.ReadAllText(ruta_relativa);
                List<Empleado> lista_empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);
                foreach (Empleado empleado in lista_empleados)
                {
                    foreach (string hobby in empleado.hobbies)
                    {
                        hobbies_distintos.Add(hobby);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: OBTENER HOBBIES DISTINTOS " + ex.Message);
            }
            return hobbies_distintos;
        }

        public static void InsertarHobbiesDisintosTablaHobby(SortedSet<string> lista_hobbies)
        {
            try
            {
                string database = "empleadosjson";
                string cadena_conexion = "Server=localhost;" +
                                         "Port=3306;" +
                                         "Database=" + database +
                                         ";Uid=root;" +
                                         "Pwd=12345678;";

                string query = "INSERT INTO Hobby(idHobby, descripcion) VALUES(@idHobby, @descripcion)";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                conexion.Open();
                MySqlCommand comando = conexion.CreateCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@idHobby", "");
                comando.Parameters.AddWithValue("@descripcion", "");
                int i = 1;
                foreach (string hobby in lista_hobbies)
                {
                    comando.Parameters["@idHobby"].Value = "H" + i++;
                    comando.Parameters["@descripcion"].Value = hobby;

                    int n = comando.ExecuteNonQuery();
                    if (n == 1)
                    {
                        Console.WriteLine("OK: INSERT");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INSERT");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: INSERT TABLA HOBBY " + e.Message);
            }
        }
    }
}