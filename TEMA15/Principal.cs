using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCSHARP.TEMA15
{
    class Principal
    {
        private static readonly string DATABASE = "";
        private static readonly string CADENA_CONEXION = "Server=localhost;" +
                                                         "Port=3307;" +
                                                         "Database=" + DATABASE +
                                                         ";Uid=root;" +
                                                         "Pwd=12345678;";

        static void Main1(string[] args)
        {
            try
            {
                string query1 = "DROP DATABASE IF EXISTS BDTEMA15";
                string query2 = "CREATE DATABASE IF NOT EXISTS BDTEMA15";
                string query3 = "USE BDTEMA15";
                string query4 = "CREATE TABLE IF NOT EXISTS Empleado(" +
                                "id_empleado VARCHAR(10) NOT NULL PRIMARY KEY," +
                                "nombre      VARCHAR(30) NOT NULL)";
                string query5 = "INSERT INTO Empleado(id_empleado,nombre) VALUES (@id_empleado," +
                                "@nombre)";

                string query6 = "SELECT * FROM Empleado";

                string query7 = "SELECT * FROM Empleado WHERE id_empleado = @id_empleadoBuscar";

                string query8 = "DELETE FROM Empleado WHERE id_empleado = @id_empleadoEliminar";

                string query9 = "UPDATE Empleado SET nombre = @nuevoNombre WHERE id_empleado = @id_empleadoActualizar";

                string query10 = "DESCRIBE Empleado";

                string query11 = "SHOW DATABASES";

                string[][] datos = new string[][]
                {
                    new string[] {"E1","Luis"},
                    new string[] {"E2","Miguel"},
                    new string[] {"E3","Carlos"},
                    new string[] {"E4","María"},
                    new string[] {"E5","Arturo"}
                };


                using (MySqlConnection conexion = new MySqlConnection(CADENA_CONEXION))
                {
                    conexion.Open();
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

                        comando.CommandText = query5;
                        comando.Parameters.AddWithValue("@id_empleado", "");
                        comando.Parameters.AddWithValue("@nombre", "");

                        foreach (string[] registro in datos)
                        {
                            comando.Parameters["@id_empleado"].Value = registro[0];
                            comando.Parameters["@nombre"].Value = registro[1];
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

                        MySqlDataReader lector;

                        comando.CommandText = query6;
                        lector = comando.ExecuteReader();
                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                string idEmpleado = lector.GetString(0);
                                string nombre = lector.GetString(1);
                                Console.WriteLine("{0,-10} {1,-10}", idEmpleado, nombre);
                            }
                        }
                        else
                        {
                            Console.WriteLine("TABLA EMPLEADO VACIA");
                        }
                        lector.Close();
                        Console.WriteLine("OK: SELECT MOSTRAR");

                        string idEmpleadobuscar = "E1";
                        comando.CommandText = query7;
                        comando.Parameters.AddWithValue("@id_empleadoBuscar", idEmpleadobuscar);
                        lector = comando.ExecuteReader();
                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                string idEmpleado = lector.GetString(0);
                                string nombre = lector.GetString(1);
                                Console.WriteLine("{0,-10} {1,-10}", idEmpleado, nombre);
                            }
                        }
                        else
                        {
                            Console.WriteLine("EMPLEADO NO EXISTE");
                        }
                        lector.Close();
                        Console.WriteLine("OK: SELECT BUSCAR");

                        int filasAfectadas;

                        string idEmpleadoEliminar = "E1";
                        comando.CommandText = query8;
                        comando.Parameters.AddWithValue("@id_empleadoEliminar", idEmpleadoEliminar);
                        filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("OK: DELETE");
                        }
                        else
                        {
                            Console.WriteLine("AVISO: EMPLEADO NO EXISTE");
                        }

                        comando.CommandText = query9;
                        comando.Parameters.AddWithValue("@nuevoNombre", "Gerson");
                        comando.Parameters.AddWithValue("@id_empleadoActualizar", "E2");
                        filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("OK: UPDATE");
                        }
                        else
                        {
                            Console.WriteLine("AVISO: EMPLEADO NO EXISTE");
                        }

                        comando.CommandText = query10;
                        lector = comando.ExecuteReader();
                        while (lector.Read())
                        {
                            for (int i = 0; i < lector.FieldCount; i++)
                            {
                                Console.Write(lector[i] + "\t");
                            }
                            Console.WriteLine();
                        }
                        lector.Close();

                        string basedatosBuscar = "BDTEMA15";
                        comando.CommandText = query11;
                        lector = comando.ExecuteReader();
                        bool bandera = false;
                        while (lector.Read())
                        {
                            string basedatos = lector.GetString(0);
                            if (basedatos == basedatosBuscar.ToLower())
                            {
                                bandera = true;
                                break;
                            }
                        }
                        if (bandera)
                        {
                            Console.WriteLine("SI EXISTE");
                        }
                        else
                        {
                            Console.WriteLine("NO EXISTE");
                        }
                        lector.Close();

                        //MOSTRAR LAS TABLAS DE UNA BASE DE DATOS CUALQUIERA
                        string basedatos1 = "bdtema15";
                        comando.CommandText = "USE " + basedatos1;
                        comando.ExecuteNonQuery();
                        Console.WriteLine("OK: USE DATABASE");
                        comando.CommandText = "SHOW TABLES";
                        lector = comando.ExecuteReader();
                        while (lector.Read())
                        {
                            Console.WriteLine(lector.GetString(0));
                        }
                        lector.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("ERROR: " + ex.ToString());

                Console.WriteLine("ERROR: CONEXION");
            }
        }
        static void Pause()
        {
            Console.Write("Presione una tecla para continuar...");
            Console.Read();
        }


    }
}