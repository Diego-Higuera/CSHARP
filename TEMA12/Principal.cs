using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PROYECTOCSHARP.TEMA12
{
    class Principal1
    {
        static void Main1(string[] args)
        {
            //PARAMETROS DE CONEXION CON MYSQL
            string server = "localhost"; //127.0.0.1
            string database = "instituto";
            string uid = "root";
            string password = "12345678";
            int port = 3306; // Puerto MySQL predeterminado
            //CONSTRUIR LA CADENA DE CONEXION
            string connectionString = $"Server={server};" +
                                      $"Port={port};" +
                                      $"Database={database};" +
                                      $"Uid={uid};" +
            $"Pwd={password};";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                //string query = "SELECT * FROM Alumno Where idAlumno = @idAlumno";
                string query = "SELECT * FROM Alumno";
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    //comando.Parameters.AddWithValue("@idAlumno", 5);
                    using (MySqlDataReader leer = comando.ExecuteReader())
                    {
                        while (leer.Read())
                        {
                            Console.WriteLine("{0,10} {1,-10} {2,-10} {3,10} {4,10}", leer.GetInt32(0),
                                                                                   leer.GetString(1),
                                                                                   leer.GetString(2),
                                                                                   leer.GetString(3),
                                                                                   leer.GetString(4)
                                                                                   );
                        }

                    }
                }

            }
            Console.Read();
        }

    }
}