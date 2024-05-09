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
    class Principal2
    {
        static void Main(string[] args)
        {
            string ruta_relativa = "data/Empleados2.json";
            InsertarTablaEmpleadoHasHobby(ruta_relativa);

        }

        public static string ObtenerIdHobby(string hobby)
        {
            string idHobby = "";
            string database = "empleadosjson";
            string cadena_conexion = "Server=localhost;" +
                                     "Port=3306;" +
                                     "Database=" + database +
                                     ";Uid=root;" +
                                     "Pwd=12345678;";
            string query = "SELECT idHobby FROM Hobby WHERE descripcion = @descripcion";
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                conexion.Open();
                MySqlCommand comando = conexion.CreateCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@descripcion", hobby);
                MySqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        idHobby = lector.GetString(0);
                    }
                }
                else
                {
                    Console.WriteLine("TABLA VACIA");
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: OBTENER ID HOBBY " + ex.Message);
            }
            return idHobby;
        }

        public static void InsertarTablaEmpleadoHasHobby(string ruta_relativa)
        {
            string database = "empleadosjson";
            string cadena_conexion = "Server=localhost;" +
                                     "Port=3306;" +
                                     "Database=" + database +
                                     ";Uid=root;" +
                                     "Pwd=12345678;";
            try
            {
                string query = "INSERT INTO Empleado_Has_Hobby(idEmpleado,idHobby) VALUES (@idEmpleado,@idHobby)";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                conexion.Open();
                MySqlCommand comando = conexion.CreateCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@idEmpleado", "");
                comando.Parameters.AddWithValue("@idHobby", "");

                string json = File.ReadAllText(ruta_relativa);
                List<Empleado> lista_empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);
                foreach (Empleado empleado in lista_empleados)
                {
                    string idEmpleado = empleado.idEmpleado;
                    List<string> hobbies = empleado.hobbies;
                    foreach (string hobby in hobbies)
                    {
                        string idHobby = ObtenerIdHobby(hobby);
                        comando.Parameters["@idEmpleado"].Value = idEmpleado;
                        comando.Parameters["@idHobby"].Value = idHobby;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: OBTENER HOBBIES DISTINTOS " + ex.Message);
            }
        }
    }
}