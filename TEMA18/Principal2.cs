using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA18
{
    class Principal2
    {
        static void Main1()
        {
            try
            {

                //PARAMETROS DE CONEXION CON MYSQL
                string server = "localhost"; //127.0.0.1
                string database = "centrobelleza";
                string uid = "root";
                string password = "12345678";
                int port = 3306; // Puerto MySQL predeterminado
                                 //CONSTRUIR LA CADENA DE CONEXION
                string cadena_conexion = $"Server={server};" +
                                          $"Port={port};" +
                                          $"Database={database};" +
                                          $"Uid={uid};" +
                                          $"Pwd={password};";


                MySqlConnection conexion = new MySqlConnection(cadena_conexion);

                conexion.Open();

                MySqlCommand comando = conexion.CreateCommand();

                Console.WriteLine("MONTO ACUMULADO POR CADA TRATAMIENTO");
                Console.WriteLine("------------------------------------");
                comando.CommandText = "SELECT tratamiento, sum(precio) " +
                                      "FROM Estetica " +
                                      "GROUP BY tratamiento";

                MySqlDataReader lector;

                lector = comando.ExecuteReader();//Abrir lector

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        string tratamiento = lector.GetString(0);
                        double monto = lector.GetDouble(1);
                        Console.WriteLine("{0,-40} {1,10:0.00}", tratamiento, monto);
                    }
                }
                else
                {
                    Console.WriteLine("AVISO: TABLA VACIA");
                }
                lector.Close(); //Cerrar lector

                Console.WriteLine("EL TRATAMIENTO CON MAYOR RENDIMIENTO EN MONTO");
                Console.WriteLine("---------------------------------------------");
                comando.CommandText = "SELECT tratamiento, sum(precio) " +
                                      "FROM Estetica " +
                                      "GROUP BY tratamiento " +
                                      "HAVING sum(precio) = (SELECT sum(precio) AS MONTO " +
                                      "FROM Estetica " +
                                      "GROUP BY tratamiento " +
                                      "ORDER BY MONTO DESC " +
                                      "LIMIT 1)";

                lector = comando.ExecuteReader();//Abrir lector

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        string tratamiento = lector.GetString(0);
                        double monto = lector.GetDouble(1);
                        Console.WriteLine("{0,-40} {1,10:0.00}", tratamiento, monto);
                    }
                }
                else
                {
                    Console.WriteLine("AVISO: TABLA VACIA");
                }
                lector.Close(); //Cerrar lector

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}