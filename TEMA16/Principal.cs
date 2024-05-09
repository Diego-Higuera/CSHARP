using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA16
{
    class Principal
    {
        static void Main1(string[] args)
        {

            string database = "";
            string cadena_conexion = "Server=localhost;" +
                                     "Port=3307;" +
                                     "Database=" + database +
                                     ";Uid=root;" +
            "Pwd=12345678;";
            MySqlConnection conexion = new MySqlConnection(cadena_conexion);

            try
            {
                conexion.Open();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    Menu(conexion);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR: CONEXION" + ex.Message);
            }
        }

        public static void Menu(MySqlConnection conexion)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Magenta;
            do
            {
                Cls();
                Console.WriteLine("MENU");
                Console.WriteLine("----");
                Console.WriteLine("[1] LEER ARCHIVO Y MOSTRAR LAS CADENAS");
                Console.WriteLine("[2] LEER ARCHIVO - GRABAR BASE DATOS");
                Console.WriteLine("[3] LEER BASE DATOS PARA VER LO GRABADO");
                Console.WriteLine("[0] SALIR");

                Console.Write("\nINGRESE OPCION? ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Cls();
                        Opcion1();
                        Pause();
                        break;
                    case "2":
                        Cls();
                        Opcion2(conexion);
                        Pause();
                        break;
                    case "3":
                        Cls();
                        Opcion3(conexion);
                        Pause();
                        break;
                    case "4":
                        Cls();
                        // Opcion4(conexion);
                        Pause();
                        break;
                    case "5":
                        Cls();
                        //Opcion5(conexion);
                        Pause();
                        break;
                    case "6":
                        Cls();
                        //Opcion6(conexion);
                        Pause();
                        break;
                    case "0":
                        Cls();
                        Console.WriteLine("GRACIAS POR SU VISITA");
                        Pause();
                        Cls();
                        Environment.Exit(0);
                        break;
                }
            } while (true);

        }

        static void Cls()
        {
            Console.Clear();
        }

        static void Pause()
        {
            Console.Write("Presione una tecla para continuar...");
            Console.Read();
        }

        static int tresAst(char[] v)
        {
            int contador = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == '*')
                {
                    contador = contador + 1; //contador++
                    if (contador >= 3)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        static void Opcion1()
        {
            Console.WriteLine("[1] LEER ARCHIVO Y MOSTRAR LAS CADENAS");
            Console.WriteLine("--------------------------------------");
            try
            {
                string rutaRelativa = "data/cadenas.csv";
                string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
                //Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
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

        static void Opcion2(MySqlConnection conexion)
        {
            Console.WriteLine("[2] LEER ARCHIVO - GRABAR BASE DATOS");
            Console.WriteLine("------------------------------------");
            if (crearBaseDatosTabla(conexion))
            {
                string query = "INSERT INTO Resultado(cadena, estado) VALUE (@cadena, @estado)";
                try
                {
                    string rutaRelativa = "data/cadenas.csv";
                    string rutaAbsoluta = Path.GetFullPath(rutaRelativa);
                    //Console.WriteLine("RUTA ABSOLUTA: " + rutaAbsoluta);
                    string fila = "";
                    MySqlCommand comando = conexion.CreateCommand();
                    comando.Parameters.AddWithValue("@cadena", "");
                    comando.Parameters.AddWithValue("@estado", "");
                    using (StreamReader sr = new StreamReader(rutaAbsoluta))
                    {
                        while ((fila = sr.ReadLine()) != null)
                        {
                            //Console.WriteLine(fila);
                            char[] vector = fila.ToCharArray();
                            int x = tresAst(vector);
                            comando.CommandText = query;
                            comando.Parameters["@cadena"].Value = fila;
                            comando.Parameters["@estado"].Value = x;
                            int n = comando.ExecuteNonQuery();
                            if (n == 1)
                            {
                                Console.WriteLine("OK: INSERT");
                            }
                            else
                            {
                                Console.WriteLine("ERROR: INSERT");
                            }

                            //Console.WriteLine(fila + "  " + x);


                        }
                        Console.WriteLine("FIN DE LECTURA");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: LECTURA " + e.Message);
                }



                Console.WriteLine("OK: CREAR BASE DATOS Y TABLA");





            }
            else
            {
                Console.WriteLine("ERROR: CREAR BASE DATOS Y TABLA");
            }
        }

        static bool crearBaseDatosTabla(MySqlConnection conexion)
        {
            bool correcto = true;
            string query1 = "DROP DATABASE IF EXISTS BDTEMA16";
            string query2 = "CREATE DATABASE IF NOT EXISTS BDTEMA16";
            string query3 = "USE BDTEMA16";
            string query4 = "CREATE TABLE IF NOT EXISTS Resultado(" +
                            "id      INT          NOT NULL PRIMARY KEY AUTO_INCREMENT," +
                            "cadena  VARCHAR(100) NOT NULL," +
                            "estado  BOOLEAN      NOT NULL)";

            try
            {
                using (MySqlCommand comando = conexion.CreateCommand())
                {
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
                }
            }
            catch (MySqlException ex)
            {
                correcto = false;
            }
            return correcto;
        }

        static void Opcion3(MySqlConnection conexion)
        {
            Console.WriteLine("[3] LEER BASE DATOS PARA VER LO GRABADO");
            Console.WriteLine("---------------------------------------");
            string query1 = "USE BDTEMA16";



            string query = "SELECT * FROM Resultado";

            try
            {
                MySqlCommand comando = conexion.CreateCommand();
                comando.CommandText = query1;
                comando.ExecuteNonQuery();
                Console.WriteLine("OK: USE DATABASE");

                comando.CommandText = query;

                MySqlDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        int id = lector.GetInt32(0);
                        string cadena = lector.GetString(1);
                        bool estado = lector.GetBoolean(2);
                        Console.WriteLine("{0,3} {1,-30} {2,-5}", id, cadena, estado);

                    }

                }
                else
                {
                    Console.WriteLine("TABLA NO TIENE REGISTROS");
                }
                lector.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR: SELECT");
            }


        }
    }
}

/*
Implementar la función int tresAst(char v[], int lon) 
que devuelve 1 si el array de caracteres 'v' 
contiene al menos tres asteriscos. Implementar también 
la alternativa que indica si hay únicamente tres asteriscos.

CREAR UNA BASE DATOS
CREAMOS LA TABLA: CADENA, TRUE/FALSE

 * */