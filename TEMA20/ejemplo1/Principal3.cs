using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using PROYECTOCSHARP.TEMA07;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA20.ejemplo1
{
    class Principal3
    {
        static void Main1()
        {
            Random rnd = new Random();
            Console.Write("Ingresar la cantidad de objetos que desea de tipo Circulo1? ");
            int n = int.Parse(Console.ReadLine());

            //CREAR OBJETOS

            List<Circulo3> lista_circulos = new List<Circulo3>();

            Circulo1.Cabecera(1);
            for (int i = 0; i < n; i++)
            {
                Circulo3 circulo = new Circulo3((i + 1), rnd.Next(10, 101));    //Radio Aleatorio [10,100]
                lista_circulos.Add(circulo);
                circulo.Cuerpo();
            }
            Pause();

            //GRABACION DE LISTA EN FORMATO JSON

            List<Dictionary<string, object>> lista_diccionarios = new List<Dictionary<string, object>>(); //Lista guarda diccionarios(json)

            foreach (Circulo3 circulo in lista_circulos)
            {
                lista_diccionarios.Add(circulo.GetDiccionario());
            }

            if (crearArchivoJson(lista_diccionarios))
            {
                Console.WriteLine("OK: CREAR ARCHIVO JSON");
            }
            else
            {
                Console.WriteLine("ERROR: CREAR ARCHIVO JSON");
            }

            //GRABACION DE LISTA EN FORMATO CSV
            if (crearArchivoCsv(lista_circulos))
            {
                Console.WriteLine("OK: CREAR ARCHIVO CSV");
            }
            else
            {
                Console.WriteLine("ERROR: CREAR ARCHIVO CSV");
            }

            //GRABACION DE LISTA EN FORMATO SQL
            if (crearBaseDatosSql(lista_circulos))
            {
                Console.WriteLine("OK: CREAR BASE DATOS");
            }
            else
            {
                Console.WriteLine("ERROR: CREAR BASE DATOS");
            }

        }

        static bool crearArchivoJson(List<Dictionary<string, object>> listaDeDiccionarios)
        {
            bool bandera = true;
            try
            {
                foreach (var item in listaDeDiccionarios)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
                }

                string ruta_relativa = @"data/Circulo.json";

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

        static void Pause()
        {
            Console.Write("Presione una tecla para continuar...");
            Console.Read();
        }

        public static bool crearArchivoCsv(List<Circulo3> lista_circulos) //ESTO ES MAS EFICIENTE
        {
            bool bandera = true;
            try
            {
                string rutaRelativa = "data/Circulo.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);

                StreamWriter sw = new StreamWriter(rutaAbsoluta);

                foreach (Circulo3 circulo in lista_circulos)
                {
                    sw.WriteLine(circulo.GetCsv());
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
            catch (IOException e)
            {
                bandera = false;
            }
            return bandera;
        }

        public static bool crearBaseDatosSql(List<Circulo3> lista_circulos)
        {
            bool bandera = true;
            try
            {
                string database = "";
                string cadena_conexion = "Server=localhost;" +
                                         "Port=3307;" +
                                         "Database=" + database +
                                         ";Uid=root;" +
                                         "Pwd=12345678;";

                string query1 = "DROP DATABASE IF EXISTS BDCIRCULO";
                string query2 = "CREATE DATABASE IF NOT EXISTS BDCIRCULO";
                string query3 = "USE BDCIRCULO";
                string query4 = "CREATE TABLE IF NOT EXISTS Circulo(" +
                                "id_circulo INT    NOT NULL PRIMARY KEY," +
                                "radio      DOUBLE NOT NULL," +
                                "area       DOUBLE NOT NULL," +
                                "perimetro  DOUBLE NOT NULL)";
                string query5 = "INSERT INTO Circulo(id_circulo,radio,area,perimetro) VALUES (@id_circulo,@radio,@area,@perimetro)";
                string query6 = "SELECT * FROM Circulo";
                string query7 = "DELETE FROM Circulo WHERE id_circulo >= 10 AND id_circulo<=20";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                conexion.Open();
                MySqlCommand comando = conexion.CreateCommand();

                comando.CommandText = query1;
                comando.ExecuteNonQuery();
                Console.WriteLine("OK: DROP DATABASE");

                comando.CommandText = query2;
                comando.ExecuteNonQuery();
                Console.WriteLine("OK: CREATE DATABASE");

                comando.CommandText = query3;
                comando.ExecuteNonQuery();
                Console.WriteLine("OK: USE DATABASE");

                comando.CommandText = query4;
                comando.ExecuteNonQuery();
                Console.WriteLine("OK: CREATE TABLE");

                comando.CommandText = query5;
                comando.Parameters.AddWithValue("@id_circulo", 0);
                comando.Parameters.AddWithValue("@radio", 0.0);
                comando.Parameters.AddWithValue("@area", 0.0);
                comando.Parameters.AddWithValue("@perimetro", 0.0);

                foreach (Circulo3 circulo in lista_circulos)
                {

                    comando.Parameters["@id_circulo"].Value = circulo.idCirculo;
                    comando.Parameters["@radio"].Value = circulo.radio;
                    comando.Parameters["@area"].Value = circulo.GetArea();
                    comando.Parameters["@perimetro"].Value = circulo.GetPerimetro();

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

                comando.CommandText = query6;
                MySqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    Circulo3.Cabecera();
                    while (lector.Read())
                    {
                        int id_circulo = lector.GetInt32(0);
                        double radio = lector.GetDouble(1);
                        double area = lector.GetDouble(2);
                        double perimetro = lector.GetDouble(3);
                        Circulo3 circulo = new Circulo3(id_circulo, radio);
                        circulo.Cuerpo();
                    }
                }
                else
                {
                    Console.WriteLine("TABLA CIRCULO VACIA");
                }
                lector.Close();
                Console.WriteLine("OK: SELECT MOSTRAR");
            }
            catch (MySqlException e)
            {
                bandera = false;
                Console.WriteLine(e.Message);
            }
            return bandera;

        }

    }
}